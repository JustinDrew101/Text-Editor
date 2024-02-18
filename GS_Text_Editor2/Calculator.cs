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
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a, b, c;
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox3.Text);
                c = a + b;
                textBox2.Text = c.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a, b, c;
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox3.Text);
                c = a - b;
                textBox2.Text = c.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a, b, c;
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox3.Text);
                c = a / b;
                textBox2.Text = c.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int a, b, c;
                a = Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox3.Text);
                c = a / b * 100;
                textBox2.Text = c.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.instance.rct1.Text = Form1.instance.rct1.Text + textBox2.Text;
        }
    }
}
