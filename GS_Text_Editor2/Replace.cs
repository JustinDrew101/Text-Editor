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
    public partial class Replace : Form
    {
        public Replace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.instance.rct1.Text.Contains(textBox1.Text))
            {
                string find = textBox1.Text.Trim();
                string replace = textBox2.Text.Trim();
                string newText = Form1.instance.rct1.Text.Replace(find, replace);
                Form1.instance.rct1.Text = newText;
                int index = 0;
                String temp = Form1.instance.rct1.Text;
                Form1.instance.rct1.Text = "";
                Form1.instance.rct1.Text = temp;
                while (index < Form1.instance.rct1.Text.LastIndexOf(textBox2.Text))
                {
                    Form1.instance.rct1.Find(textBox2.Text, index, Form1.instance.rct1.TextLength, RichTextBoxFinds.None);
                    Form1.instance.rct1.Select();
                    index = Form1.instance.rct1.Text.IndexOf(textBox2.Text, index) + 1;
                }
                Close();
            }
            else
            {
                Close();
                MessageBox.Show("Cannot Find " + textBox1.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
