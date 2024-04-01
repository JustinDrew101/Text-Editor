using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web;

namespace GS_Text_Editor2
{
    public partial class FeedBack : Form
    {
        public FeedBack()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text.Contains("fuck") || textBox3.Text.Contains("Fuck") || textBox3.Text.Contains("FUCK"))
            {
                MessageBox.Show("We Don't Allow These Kind of Words", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MailMessage mail = new MailMessage("", "", textBox1.Text, "Name: " + textBox1.Text + "\n" + "Email: " + textBox2.Text + "\n" + "Message: " + textBox3.Text);
                SmtpClient client = new SmtpClient(textBox4.Text);
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("", "");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Feedback sent!", "Success", MessageBoxButtons.OK);
            }
        }
    }
}
