using PS3Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS3_RTM_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static PS3API PS3 = new PS3API();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget())
                    //MessageBox.Show("Successfully Connected to Target!", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusLabel.Text = "Status: Connected/Not Attached";
                else
                    MessageBox.Show("Failed to Connect", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Failed to Connect", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.AttachProcess())
                    //MessageBox.Show("Successfully Attached to Proccess!", "Attached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusLabel.Text = "Status: Connected/Attached";
                else
                    MessageBox.Show("Failed to Attach", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Failed to Attach", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PS3.Extension.WriteInt32(0x0163D770, 11927552); //character1
                PS3.Extension.WriteInt32(0x0163D774, 11927552);
                PS3.Extension.WriteInt32(0x016428D0, 11927552); //character2
                PS3.Extension.WriteInt32(0x016428D4, 11927552);
            }
        }
    }
}
