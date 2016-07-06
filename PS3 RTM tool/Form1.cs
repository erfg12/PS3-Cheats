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

        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] norecoilon = new byte[] { 0x60, 0x00, 0x00, 0x00 };

            uint address = 0x0014492C;

            PS3.SetMemory(address, norecoilon); //set byte(s)
            PS3.Extension.WriteFloat(address, 1000 * 2); //float
            PS3.Extension.WriteInt16(address + 2, 500); //int16
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint randBuff = PS3.Extension.ReadUInt32(0x10045000);
            MessageBox.Show("Value in memory is: " + randBuff.ToString("X8"));
        }
    }
}
