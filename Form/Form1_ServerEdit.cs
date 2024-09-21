using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cfmanager
{
    public partial class Form1_ServerEdit : Form
    {
        public Form1_ServerEdit()
        {
            InitializeComponent();
        }
        public string srvname { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string srv_yxj { get { return comboBox1.Text; } set { srv_yxj_private = value; } }
        public bool srv_hidden { get { return checkBox1.Checked; } set { checkBox1.Checked = value; } }
        public string srv_path { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string srv_params { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string srv_cores { get { return get_cores(); } set { srv_cores_private = value; } }
        private string srv_cores_private = "";
        private string srv_yxj_private = "";

        private void Form1_ServerEdit_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 4;
            this.Size = new Size(this.Size.Width, 242);
            groupBox1.Visible = false;

            bool state = this.Text == "新增服务器" ? true : false;
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                checkedListBox1.Items.Add("CPU_" + i);
                checkedListBox1.SetItemChecked(i, state);
            }
            if (srv_cores_private.Length > 1)
            {
                foreach (string s in srv_cores_private.Split('|'))
                {
                    if (s.Length < 1) { continue; }
                    try { checkedListBox1.SetItemChecked(Int32.Parse(s), true); }
                    catch { MessageBox.Show("配置中勾选了不存在的内核, 请不要套用配置文件或修改配置文件.\n更换电脑应重新配置.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); button3_Click(null, null); break; }
                }
            }
            if (srv_yxj_private.Length > 1)
            {
                switch (srv_yxj_private)
                {
                    case "低": comboBox1.SelectedIndex = 0; break;
                    case "低于正常": comboBox1.SelectedIndex = 1; break;
                    case "正常": comboBox1.SelectedIndex = 2; break;
                    case "高于正常": comboBox1.SelectedIndex = 3; break;
                    case "高": comboBox1.SelectedIndex = 4; break;
                    case "实时": comboBox1.SelectedIndex = 5; break;
                }
            }

        }

        public string get_cores()
        {
            string used_core_string = "";
            foreach (string cb in checkedListBox1.CheckedItems)
            {
                used_core_string += cb.Substring(4) + "|";
            }
            return used_core_string;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "处理器相关性 >>")
            {
                this.Size = new Size(this.Size.Width, 422);
                groupBox1.Visible = true;
                button3.Text = "<< 处理器相关性";
            }
            else
            {
                this.Size = new Size(this.Size.Width, 242);
                groupBox1.Visible = false;
                button3.Text = "处理器相关性 >>";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "仅支持SRCDS.exe服务端进程|srcds.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 1 || textBox2.Text.Trim().Length < 1 || textBox3.Text.Trim().Length < 1 || checkedListBox1.CheckedItems.Count < 1)
            {
                MessageBox.Show("有数据未输入.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!textBox3.Text.Contains("-ip ") || !textBox3.Text.Contains("-port "))
            {
                MessageBox.Show("启动项中没有-ip参数或没有-port参数", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }






    }
}
