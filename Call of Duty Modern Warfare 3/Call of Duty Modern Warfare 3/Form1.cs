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
            {
                //health
                PS3.Extension.WriteByte(0x0122743B, 0x64);
                PS3.Extension.WriteByte(0x010EEC2B, 0x64);
                //armor
                if (PS3.Extension.ReadInt32(0x01BEDEE0) > 1)
                    PS3.Extension.WriteByte(0x01BEDEE0, 0xFF);
                if (PS3.Extension.ReadInt32(0x01CB42C0) > 1)
                    PS3.Extension.WriteByte(0x01CB42C0, 0xFF);
            }
            if (checkBox2.Checked)
            {
                //current magazine
                PS3.Extension.WriteByte(0x012276CC, 0x63);
                PS3.Extension.WriteByte(0x012276A8, 0x63);
                PS3.Extension.WriteByte(0x012276AA, 0x63); //campaign
                PS3.Extension.WriteByte(0x012276B7, 0x63); //campaign
                //max ammo
                PS3.Extension.WriteByte(0x01227648, 0x63);
                PS3.Extension.WriteByte(0x01227630, 0x63);
                PS3.Extension.WriteByte(0x01227632, 0x63); //campaign
                //grenades
                PS3.Extension.WriteByte(0x012276B7, 0x4);
                //non-lethal
                PS3.Extension.WriteByte(0x012276C3, 0x4);

                //claymores
                if (PS3.Extension.ReadInt32(0x012276D8) > 1)
                    PS3.Extension.WriteByte(0x012276D8, 0x63);
                //C4
                if (PS3.Extension.ReadInt32(0x012276E4) > 1)
                    PS3.Extension.WriteByte(0x012276E4, 0x63);
            }
            if (checkBox3.Checked)
            {
                if (PS3.Extension.ReadInt32(0x01BEE590) > 1)
                    PS3.Extension.WriteInt32(0x01BEE590, 99999);
                if (PS3.Extension.ReadInt32(0x01BEDDA0) > 1)
                    PS3.Extension.WriteInt32(0x01BEDDA0, 99999);
            }
            if (checkBox4.Checked)
            {
                if (PS3.Extension.ReadInt32(0x01BEE5A0) > 1)
                    PS3.Extension.WriteInt32(0x01BEE5A0, 16777215);
                if (PS3.Extension.ReadInt32(0x01CB6090) > 1)
                    PS3.Extension.WriteInt32(0x01CB6090, 16777215);
            }
        }
    }
}
