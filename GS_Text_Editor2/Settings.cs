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
    public partial class Settings : Form
    {
        Boolean apre = false;
        public Settings()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            apre = true;
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            loadform(new SettingsAppearance());
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            apre = true;
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(32, 32, 32);
            loadform(new SettingsAppearance());
        }
    }
}
