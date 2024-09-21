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
    public partial class Form1_Options : Form
    {
        public Form1_Options()
        {
            InitializeComponent();
        }

        private void Form1_Options_Shown(object sender, EventArgs e)
        {
            numericUpDown1.Value = Ctrl.Get.opt_sec;
            numericUpDown2.Value = Ctrl.Get.opt_prc;
            numericUpDown3.Value = Ctrl.Get.opt_nwc;
            numericUpDown4.Value = Ctrl.Get.opt_max;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int[] number_array = new int[4] {0,0,0,0};
            Int32.TryParse(numericUpDown1.Value.ToString(), out number_array[0]);
            Int32.TryParse(numericUpDown2.Value.ToString(), out number_array[1]);
            Int32.TryParse(numericUpDown3.Value.ToString(), out number_array[2]);
            Int32.TryParse(numericUpDown4.Value.ToString(), out number_array[3]);

            Ctrl.Get.SaveConfig(number_array);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
