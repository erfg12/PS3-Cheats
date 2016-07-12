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
                    MessageBox.Show("Successfully Connected to Target!", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                PS3.AttachProcess();
                MessageBox.Show("Successfully Attached to Proccess!", "Attached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failed to Attached", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                PS3.Extension.WriteByte(0xD003CADC + 0x000002E4, 0x14); //max hp = 20
        }
    }
}
