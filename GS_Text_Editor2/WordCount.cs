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
    public partial class WordCount : Form
    {
        public WordCount()
        {
            InitializeComponent();
        }

        private void WordCount_Load(object sender, EventArgs e)
        {
            var lineCount = Form1.instance.rct1.Lines.Count();
            label9.Text = lineCount.ToString();
            string count = Form1.instance.rct1.Text;
            label6.Text = Convert.ToString(Form1.instance.rct1.Text.Length);
            label7.Text = (count.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
        }
    }
}
