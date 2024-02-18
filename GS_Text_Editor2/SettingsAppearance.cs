using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GS_Text_Editor2
{
    public partial class SettingsAppearance : Form
    {
        Boolean Dchk = false;
        Boolean lchk = false;
        Boolean wtbchk = false;
        Boolean time = false;
        public SettingsAppearance()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                StreamWriter sr = new StreamWriter(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Time");
                sr.Write("");
                sr.Write("Ttrue");
                sr.Close();
            }
            else if (time == false)
            {
                StreamWriter sr = new StreamWriter(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Time");
                sr.Write("");
                sr.Write("ftrue");
                sr.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Theme");
                sw.Write("");
                sw.Write("Defualt");
                sw.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                StreamWriter sr = new StreamWriter(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Theme");
                sr.Write("");
                sr.Write("Light");
                sr.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Theme");
            if (radioButton3.Checked == true)
            {
                sr.Write("");
                sr.Write("WTB");
                sr.Close();
            }
        }

        private void SettingsAppearance_Load(object sender, EventArgs e)
        {
            if (Form1.instance.TShow == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (Form1.instance.LTheme == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton3.Checked = false;
            }
            else if (Form1.instance.WTBMode == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = true;
            }
            else if (Form1.instance.DTheme == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }
    }
}
