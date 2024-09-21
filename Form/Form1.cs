using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace cfmanager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Ctrl.Get.ReadConfig();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            ReadAll_Servers_Data_FromFile();
            timer1.Enabled = true;
            timer1.Interval = Ctrl.Get.opt_sec * 1000;
            textBox1.AppendText(string.Format("[{0} {1}] - 进程启动.", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));

            //显示隐藏项HToolStripMenuItem_Click(null, null); //测试函数
        }
        public void log(string text)
        {
            this.Invoke(new EventHandler(delegate { textBox1.AppendText(string.Format("\r\n[{0} {1}] - {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), text)); }));
        }

        public void SaveAll_Servers_Data_ToFile()
        {
            string[] write_to_file = new string[listView1.Items.Count];
            int index = 0;
            foreach (ListViewItem ls in listView1.Items)
            {
                string ls_str = "";
                foreach (ListViewItem.ListViewSubItem s in ls.SubItems) { ls_str += s.Text + "`"; }
                write_to_file[index++] = ls_str.Substring(0, ls_str.Length - 1);
            }
            Ctrl.Get.SaveConfig_Servers(write_to_file);
        }
        public void ReadAll_Servers_Data_FromFile()
        {
            foreach (string s in Ctrl.Get.ReadConfig_Servers())
            {
                string[] split = s.Split('`');
                ListViewItem ls_item = new ListViewItem();
                ls_item.Text = split[0];
                for (int i = 1; i < split.Length; i++)
                {
                    ls_item.SubItems.Add(split[i]);
                }
                listView1.Items.Add(ls_item);
            }
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() => { MessageBox.Show("CF Server Monitor 是由春风编写的替换HLSM的软件.\n2024-09-06.", "关于 CF Server Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information); }).Start();
        }
        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1_Options form = new Form1_Options();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(MousePosition.X, MousePosition.Y);
            if (form.ShowDialog() == DialogResult.OK) { System.Media.SystemSounds.Exclamation.Play(); timer1.Interval = Ctrl.Get.opt_sec * 1000; }
        }
        private void 显示隐藏项HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool state = 显示隐藏项HToolStripMenuItem.Text.Equals("显示隐藏项(&H)");
            显示隐藏项HToolStripMenuItem.Text = state ? "不显示隐藏项(&H)" : "显示隐藏项(&H)";
            int final_int = state ? 90 : 0;
            for (int i = 10; i < 15; i++) { listView1.Columns[i].Width = final_int; }
            if (!state) { this.Size = new Size(1024, this.Size.Height); } else { this.Size = new Size(1500, this.Size.Height); }
        }
        private void 重启次数归零ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items[listView1.SelectedIndices[0]].SubItems[9].Text = "0";
        }
        private void 暂停监视PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1_SetSelectItemState(!暂停监视PToolStripMenuItem.Text.Equals("暂停监视(&P)"));
        }
        private void 隐藏服务器HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems) 
            {
                lvi.SubItems[12].Text = "隐藏";
                if (!lvi.SubItems[11].Text.Equals("0")) { Ctrl.Get.process_show(lvi.SubItems[11].Text, false); }
            }
            SaveAll_Servers_Data_ToFile();
        }
        private void 显示服务器SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems) 
            {
                lvi.SubItems[12].Text = "显示";
                if (!lvi.SubItems[11].Text.Equals("0")) { Ctrl.Get.process_show(lvi.SubItems[11].Text, true); }
            }
            SaveAll_Servers_Data_ToFile();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (显示隐藏项HToolStripMenuItem.Text.Equals("显示隐藏项(&H)") && e.ColumnIndex > 9) { e.NewWidth = 0; e.Cancel = true; }
        }

        private void listView1_SetSelectItemState(bool start)
        {
            foreach(ListViewItem lvi in listView1.SelectedItems)
            {
                if (start) { lvi.SubItems[5].Text = "-"; lvi.SubItems[6].Text = "-"; lvi.SubItems[7].Text = "-"; lvi.SubItems[8].Text = "-"; lvi.SubItems[9].Text = "0"; }
                else { lvi.SubItems[5].Text = "暂停监视"; lvi.SubItems[6].Text = "暂停监视"; lvi.SubItems[7].Text = "-"; lvi.SubItems[8].Text = "-"; lvi.SubItems[9].Text = "0"; }
            }
            SaveAll_Servers_Data_ToFile();
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count < 1)
                {
                    foreach (ToolStripItem button in contextMenuStrip1.Items) { button.Enabled = false; }
                    新增服务器NToolStripMenuItem.Enabled = true;
                    暂停监视PToolStripMenuItem.Text = "暂停监视(&P)";
                }
                else
                {
                    foreach (ToolStripItem button in contextMenuStrip1.Items) { button.Enabled = true; }
                    if (listView1.Items[listView1.SelectedIndices[0]].SubItems[5].Text.Equals("暂停监视")) { 暂停监视PToolStripMenuItem.Text = "恢复监视(&P)"; 重启次数归零ZToolStripMenuItem.Enabled = false; }
                    else { 暂停监视PToolStripMenuItem.Text = "暂停监视(&P)"; 重启次数归零ZToolStripMenuItem.Enabled = true; }

                    bool hidden_state = listView1.SelectedItems[0].SubItems[12].Text.Equals("显示");
                    显示服务器SToolStripMenuItem.Visible = !hidden_state; 隐藏服务器HToolStripMenuItem.Visible = hidden_state;
                    关闭服务器CToolStripMenuItem.Enabled = !listView1.SelectedItems[0].SubItems[10].Text.Equals("0");
                }
                if (listView1.SelectedItems.Count > 1) { 编辑服务器ToolStripMenuItem.Enabled = false; 显示服务器SToolStripMenuItem.Visible = true; 隐藏服务器HToolStripMenuItem.Visible = true; 关闭服务器CToolStripMenuItem.Enabled = true; }
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            listView1_SetSelectItemState(listView1.SelectedItems[0].SubItems[5].Text.Equals("暂停监视"));
        }


        private void 新增服务器NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems) { if (lvi.Selected) { lvi.Selected = false; } }
            Form1_ServerEdit form = new Form1_ServerEdit();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(MousePosition.X, MousePosition.Y);
            form.Text = "新增服务器";
            if (form.ShowDialog() == DialogResult.OK)
            {
                ListViewItem ls = new ListViewItem();
                ls.Text = form.srvname;
                ls.SubItems.Add("");
                ls.SubItems.Add(""); 

                //从启动项中取出ip和端口
                int split_index_added = 0;
                string[] split_param = form.srv_params.Split(' ');
                for (int i = 0; i < split_param.Length; i ++)
                {
                    if (split_param[i] == "-ip")   { ls.SubItems[1].Text = split_param[i + 1].Contains("0.0.0") ? socket.Get.localhost : split_param[i + 1]; split_index_added++; if (split_index_added >= 2) { break; } else { continue; } }
                    if (split_param[i] == "-port") { ls.SubItems[2].Text = split_param[i + 1]; split_index_added++; if (split_index_added >= 2) { break; } else { continue; } }
                }

                ls.SubItems.Add(form.srv_path);
                ls.SubItems.Add(form.srv_yxj);
                ls.SubItems.Add("暂停监视");
                ls.SubItems.Add("暂停监视");
                ls.SubItems.Add("-");
                ls.SubItems.Add("-");
                ls.SubItems.Add("-");
                ls.SubItems.Add("0");
                ls.SubItems.Add("0");
                ls.SubItems.Add(form.srv_hidden ? "隐藏" : "显示");
                ls.SubItems.Add(form.srv_cores);
                ls.SubItems.Add(form.srv_params);
                listView1.Items.Add(ls);
                SaveAll_Servers_Data_ToFile();
            }
        }


        private void 编辑服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem select_item = listView1.SelectedItems[0];
            Form1_ServerEdit form = new Form1_ServerEdit();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(MousePosition.X, MousePosition.Y);
            form.Text = "编辑服务器";
            form.srvname = select_item.Text;
            form.srv_yxj = select_item.SubItems[4].Text;
            form.srv_hidden = select_item.SubItems[12].Text.Equals("隐藏");
            form.srv_path = select_item.SubItems[3].Text;
            form.srv_params = select_item.SubItems[14].Text;
            form.srv_cores = select_item.SubItems[13].Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                int split_index_added = 0;
                string[] split_param = form.srv_params.Split(' ');
                for (int i = 0; i < split_param.Length; i++)
                {
                    if (split_param[i] == "-ip") { select_item.SubItems[1].Text = split_param[i + 1].Contains("0.0.0") ? socket.Get.localhost : split_param[i + 1]; split_index_added++; if (split_index_added >= 2) { break; } else { continue; } }
                    if (split_param[i] == "-port") { select_item.SubItems[2].Text = split_param[i + 1]; split_index_added++; if (split_index_added >= 2) { break; } else { continue; } }
                }
                select_item.Text = form.srvname;
                select_item.SubItems[3].Text = form.srv_path;
                select_item.SubItems[14].Text = form.srv_params;

                if (!select_item.SubItems[10].Text.Equals("0") && !form.srv_yxj.Equals(select_item.SubItems[4].Text)) { Ctrl.Get.process_priority(select_item.SubItems[10].Text, form.srv_yxj); }
                select_item.SubItems[4].Text = form.srv_yxj;

                if (!select_item.SubItems[10].Text.Equals("0") && !form.srv_cores.Equals(select_item.SubItems[13].Text)) { Ctrl.Get.process_affinity(select_item.SubItems[10].Text, form.srv_cores); }
                select_item.SubItems[13].Text = form.srv_cores;

                select_item.SubItems[12].Text = form.srv_hidden ? "隐藏" : "显示";
                if (!select_item.SubItems[11].Text.Equals("0")) { Ctrl.Get.process_show(select_item.SubItems[11].Text, !form.srv_hidden); }

                SaveAll_Servers_Data_ToFile();
            }
        }

        private void 删除服务器DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定删除选中项目?", "你确定", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems) { lvi.Remove(); }
                SaveAll_Servers_Data_ToFile();
            }
        }

        private void 重启服务器RToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("您确定重启选中的服务器吗？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
           {
               foreach (ListViewItem item in listView1.SelectedItems)
               {
                   if (!item.SubItems[10].Text.Equals("0")) { Ctrl.Get.process_kill(Int32.Parse(item.SubItems[10].Text)); item.SubItems[10].Text = "0"; item.SubItems[11].Text = "0"; }

                   new Thread(() =>
                   {
                       string[] pid_str = Ctrl.Get.process_restart(item.SubItems[3].Text, item.SubItems[14].Text, item.SubItems[4].Text, item.SubItems[13].Text, item.SubItems[12].Text.Equals("显示") ? true : false);
                       this.BeginInvoke((MethodInvoker)delegate
                       {
                           item.SubItems[10].Text = pid_str[0];
                           item.SubItems[11].Text = pid_str[1];
                       });
                   }).Start();
               }
           }
        }

        private void 关闭服务器CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定关闭选中的服务器吗？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    int pid = 0;
                    Int32.TryParse(item.SubItems[10].Text, out pid);
                    if (pid > 0) { Ctrl.Get.process_kill(pid); }
                    item.SubItems[10].Text = "0";
                    item.SubItems[11].Text = "0";
                    item.SubItems[5].Text = "暂停监视";
                    item.SubItems[6].Text = "暂停监视";
                    item.SubItems[7].Text = "-";
                    item.SubItems[8].Text = "-";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] process_allfilename = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[5].Text.Equals("暂停监视") || item.SubItems[5].Text.Equals("正在重启")) { continue; }
                if (process_allfilename == null) { process_allfilename = Ctrl.Get.process_check_getall(); }
                if (process_allfilename.Contains(item.SubItems[3].Text)) { if (!item.SubItems[5].Text.Equals("正常")) { item.SubItems[5].Text = "正常"; } }
                else { if (!item.SubItems[5].Text.Contains("丢失")) { item.SubItems[5].Text = "丢失(1/" + Ctrl.Get.opt_prc + ")"; item.SubItems[6].Text = "-"; item.SubItems[10].Text = "0"; item.SubItems[11].Text = "0"; item.SubItems[7].Text = "-"; item.SubItems[8].Text = "-"; continue; } }
                
                //进程已丢失
                string proc_state = item.SubItems[5].Text;
                if (proc_state.Contains("丢失(")) 
                {
                    proc_state = proc_state.Substring(3, proc_state.Length - 4);
                    string[] ds_split = proc_state.Split('/');
                    if (ds_split[0] != ds_split[1]) { item.SubItems[5].Text = string.Format("丢失({0}/{1})", Int32.Parse(ds_split[0]) + 1, ds_split[1]); continue; }
                    else { if (listview1_can_not_restart()) { custom_restart(item, "进程丢失"); } }
                    continue;
                }

                //进程正常的话判断网络状态
                if (item.SubItems[5].Text.Equals("正常"))
                {
                    string[] a2sinfo = socket.Get.a2sinfo(item.SubItems[1].Text, Int32.Parse(item.SubItems[2].Text));

                    if (a2sinfo[0].Equals("OK"))
                    { 
                        if (!item.SubItems[6].Text.Equals("正常")) { item.SubItems[6].Text = "正常"; } 
                        if (!item.SubItems[7].Text.Equals(a2sinfo[1])) { item.SubItems[7].Text = a2sinfo[1]; } 
                        if (!item.SubItems[8].Text.Equals(a2sinfo[2])) { item.SubItems[8].Text = a2sinfo[2]; }
                        continue;
                    }
                    else 
                    {
                        if (!item.SubItems[6].Text.Contains("超时")) { item.SubItems[6].Text = "超时(1/" + Ctrl.Get.opt_nwc + ")"; continue; } 
                    }

                    string netk_state = item.SubItems[6].Text;
                    if (netk_state.Contains("超时("))
                    {
                        netk_state = netk_state.Substring(3, netk_state.Length - 4);
                        string[] nt_split = netk_state.Split('/');
                        if (nt_split[0] != nt_split[1]) { item.SubItems[6].Text = string.Format("超时({0}/{1})", Int32.Parse(nt_split[0]) + 1, nt_split[1]); }
                        else { if (listview1_can_not_restart()) { custom_restart(item, "网络A2s不通"); } }
                        continue;
                    }
                }
            }
        }

        private void custom_restart(ListViewItem item, string reason)
        {
            item.SubItems[5].Text = "正在重启";
            int now_restart_countt = Int32.Parse(item.SubItems[9].Text);
            item.SubItems[9].Text = (++now_restart_countt).ToString();
            log("服务器 [" + item.Text + "] 因" + reason + "而重启.");
            if (!item.SubItems[10].Text.Equals("0")) { Ctrl.Get.process_kill(Int32.Parse(item.SubItems[10].Text)); item.SubItems[10].Text = "0"; item.SubItems[11].Text = "0"; }
            new Thread(() =>
            {
                string[] pid_str = Ctrl.Get.process_restart(item.SubItems[3].Text, item.SubItems[14].Text, item.SubItems[4].Text, item.SubItems[13].Text, item.SubItems[12].Text.Equals("显示") ? true : false);

                int intpid = 0;
                Int32.TryParse(pid_str[0], out intpid);

                string final_set = "正常";
                if (intpid < 1) { final_set = "丢失(1/" + Ctrl.Get.opt_prc + ")"; }
                this.BeginInvoke((MethodInvoker)delegate
                {
                    item.SubItems[10].Text = pid_str[0];
                    item.SubItems[11].Text = pid_str[1];
                    item.SubItems[6].Text = "-";
                    item.SubItems[5].Text = final_set;
                });
            }).Start();
        }

        private bool listview1_can_not_restart()
        {
            int restart_count = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[5].Text.Equals("正在重启")) { restart_count++; }
            }
            return restart_count < Ctrl.Get.opt_max ? true : false;
        }

    }
}