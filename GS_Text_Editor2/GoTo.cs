using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_Text_Editor2
{
    public partial class GoTo : Form
    {
        public GoTo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = Form1.instance.rct1.GetFirstCharIndexFromLine(Convert.ToInt32(textBox1.Text));
            int length = Form1.instance.rct1.Lines[Convert.ToInt32(textBox1.Text)].Length;
            Form1.instance.rct1.Select(start, length);
            Close();
        }
    }
}
