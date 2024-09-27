using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace cfmanager
{
    class socket
    {
        private static socket s;
        private Socket socks;
        private socket() { reset_socket(); }
        public static socket Get
        {
            get { return s = s ?? new socket(); }
        }

        private string localip;
        public string localhost
        {
            get { return localip = localip ?? get_local_ipv4(); }
        }
        private string get_local_ipv4()
        {
            try
            {
                foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork) { return ip.ToString(); }
                }
            }
            catch { }
            return "127.0.0.1";
        }
        private void reset_socket()
        {
            if (socks != null) socks.Close();
            socks = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socks.ReceiveTimeout = 50;
        }

        public string[] a2sinfo(string ip, int port)
        {
            List<byte> bytelist = new List<byte>();
            bytelist.AddRange(new byte[] { 0xff, 0xff, 0xff, 0xff });
            bytelist.AddRange(Encoding.UTF8.GetBytes("TSource Engine Query\0"));

            IPEndPoint ipport = new IPEndPoint(IPAddress.Parse(ip), port);

            byte[] infobag1 = bytelist.ToArray();
            socks.SendTo(infobag1, infobag1.Length, SocketFlags.None, ipport);

            byte[] srvback = new byte[4096];
            int srvbacklen = 0;

            try
            {
                srvbacklen = socks.Receive(srvback);
            }
            catch (Exception e)
            {
                reset_socket();
                return new string[] { "ERROR", e.Message };
            }

            //如果是挑战包.
            if (srvback[4] == 0x41)
            {
                bytelist.AddRange(new byte[] { srvback[5], srvback[6], srvback[7], srvback[8] });
                byte[] infobag2 = bytelist.ToArray();
                socks.SendTo(infobag2, infobag2.Length, SocketFlags.None, ipport);

                try
                {
                    srvbacklen = socks.Receive(srvback);
                }
                catch (Exception e)
                {
                    reset_socket();
                    return new string[] { "ERROR", e.Message };
                }
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(srvback, 0, srvbacklen);
            byte[] succdata = ms.ToArray();
            ms.Close();
            ms.Dispose();

            Queue<byte> qdata = new Queue<byte>();
            foreach (byte b in succdata) { qdata.Enqueue(b); }
            if (qdata.Count > 5 && qdata.Dequeue() == 0xff && qdata.Dequeue() == 0xff && qdata.Dequeue() == 0xff && qdata.Dequeue() == 0xff && qdata.Dequeue() == 0x49)
            {
                List<byte> bufferlist = new List<byte> { };

                //协议
                int protocol = qdata.Dequeue();
                //if (qdata.Peek() == 0xef) { qdata.Dequeue(); qdata.Dequeue(); qdata.Dequeue(); }

                //服务器名
                while (qdata.Peek() != 0x00) { qdata.Dequeue(); }

                //地图名
                qdata.Dequeue(); //分隔符不要 0x00
                while (qdata.Peek() != 0x00)
                {
                    bufferlist.Add(qdata.Dequeue());
                }
                string mapname = Encoding.UTF8.GetString(bufferlist.ToArray());
                bufferlist.Clear();

                //小写游戏名
                qdata.Dequeue();
                while (qdata.Peek() != 0x00) { qdata.Dequeue(); }

                //正写游戏名
                qdata.Dequeue();
                while (qdata.Peek() != 0x00) { qdata.Dequeue(); }

                //ID
                qdata.Dequeue();//分隔符不要 0x00
                qdata.Dequeue();
                qdata.Dequeue();

                //Player
                int players = qdata.Dequeue();
                int maxplayers = qdata.Dequeue();

                //END
                qdata.Clear();

                return new string[]{ "OK", mapname, string.Format("{0}/{1}", players, maxplayers) };
            }

            return new string[]{"ERROR", "final_fatal_error"};
        }



    }
}
