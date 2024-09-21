using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace cfmanager
{
    class Ctrl
    {
        static Ctrl c;
        private Ctrl() { }
        public static Ctrl Get
        {
            get { return c = c ?? new Ctrl(); }
        }

        static int system_core_count = 0;
        public int core_count
        {
            get { if (system_core_count < 1) { system_core_count = Environment.ProcessorCount; } return system_core_count; }
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public bool SetWindowState(string fid, bool state)
        {
            long window_id = 0L;
            if (long.TryParse(fid, out window_id) && window_id > 0L) { return ShowWindow((IntPtr)window_id, state ? 5 : 0); }
            return false;
        }

        private int check_sec = 5, check_process = 3, check_network = 15, check_max = 1;
        private string path = Directory.GetCurrentDirectory() + @"\options_data.txt";
        private string path2 = Directory.GetCurrentDirectory() + @"\servers_data.txt";
        public void ReadConfig()
        {
            if (File.Exists(path))
            {
                string[] read_array = File.ReadAllLines(path);
                check_sec = Int32.Parse(read_array[0]); check_process = Int32.Parse(read_array[1]); check_network = Int32.Parse(read_array[2]); check_max = Int32.Parse(read_array[3]);
            }
            else
            {
                File.WriteAllLines(path, new string[] { check_sec.ToString(), check_process.ToString(), check_network.ToString(), check_max.ToString() });
            }
        }
        public void SaveConfig(int[] number)
        {
            check_sec = number[0]; check_process = number[1]; check_network = number[2]; check_max = number[3];
            string[] convert_array = new string[number.Length];
            for (int i = 0; i < number.Length; i ++)
            {
                convert_array[i] = number[i].ToString();
            }
            File.WriteAllLines(path, convert_array);
        }
        public int opt_sec { get { return check_sec; } set { check_sec = value; } }
        public int opt_prc { get { return check_process; } set { check_process = value; } }
        public int opt_nwc { get { return check_network; } set { check_network = value; } }
        public int opt_max { get { return check_max; } set { check_max = value; } }

        public void SaveConfig_Servers(string[] data)
        {
            File.WriteAllLines(path2, data);
        }
        public string[] ReadConfig_Servers()
        {
            if (File.Exists(path2))
            {
                return File.ReadAllLines(path2);
            }
            return new string[] {};
        }

        public string[] process_restart(string path, string param, string yxj, string cores, bool show)
        {
            string[] result = new string[] { "0", "0" };
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = path;
            startinfo.Arguments = param;
            startinfo.UseShellExecute = false;
            startinfo.WorkingDirectory = path.Substring(0, path.LastIndexOf('\\'));

            if (!File.Exists(path)) { return result; }
            Process proc = Process.Start(startinfo);
            proc.WaitForInputIdle();

            //设置id
            result[0] = proc.Id.ToString();
            result[1] = proc.MainWindowHandle.ToString();

            process_priority(result[0], yxj);
            process_affinity(result[0], cores);
            process_show(result[1], show);

            return result;
        }

        public bool process_kill(int pid)
        {
            if (pid < 1) { return false; }
            bool result = false;
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
                result = true;
            }
            catch { }
            return result;
        }

        public bool process_check(string path)
        {
            Process[] process_list = Process.GetProcessesByName("srcds");
            foreach (Process proc in process_list) { if (proc.MainModule.FileName.Equals(path)) { return true; } }
            return false;
        }

        public string[] process_check_getall()
        {
            Process[] process_list = Process.GetProcessesByName("srcds");
            string[] result = new string[process_list.Length];
            for (int a = 0; a < process_list.Length; a++) { result[a] = process_list[a].MainModule.FileName; }
            return result;
        }

        public bool process_priority(string pid_str, string yxj)
        {
            bool result = false;
            int pid = 0;
            if (Int32.TryParse(pid_str, out pid) && pid > 0)
            {
                ProcessPriorityClass set_yxj = ProcessPriorityClass.Normal;
                switch (yxj)
                {
                    case "低": set_yxj = ProcessPriorityClass.Idle; break;
                    case "低于正常": set_yxj = ProcessPriorityClass.BelowNormal; break;
                    case "高于正常": set_yxj = ProcessPriorityClass.AboveNormal; break;
                    case "高": set_yxj = ProcessPriorityClass.High; break;
                    case "实时": set_yxj = ProcessPriorityClass.RealTime; break;
                }
                try
                {
                    Process proc = Process.GetProcessById(pid);
                    proc.PriorityClass = set_yxj;
                    result = true;
                }
                catch { }
            }
            return result;
        }

        public bool process_affinity(string pid_str, string cores)
        {
            bool result = false;
            int pid = 0;
            if (Int32.TryParse(pid_str, out pid) && pid > 0)
            {
                string[] cores_set = cores.Split('|');
                if ( (cores_set.Length -1) != Ctrl.Get.core_count )
                {
                    IntPtr cores_intptr = IntPtr.Zero;
                    foreach (string s in cores.Split('|'))
                    {
                        if (s.Length < 1) { continue; }
                        int core_int = Int32.Parse(s);
                        //cores_intptr = (IntPtr)((uint)(long)cores_intptr | (1u << core_int));
                        cores_intptr = (IntPtr)((long)cores_intptr | (1 << core_int));
                    }
                    try
                    {
                        Process proc = Process.GetProcessById(pid);
                        proc.ProcessorAffinity = cores_intptr;
                        result = true;
                    }
                    catch { }
                }
            }
            return result;
        }

        public bool process_show(string window_pid, bool show)
        {
            return SetWindowState(window_pid, show);
        }



    }
}
