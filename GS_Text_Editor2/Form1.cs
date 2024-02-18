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
using System.Speech.Synthesis;
using Microsoft.Win32;

namespace GS_Text_Editor2
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public RichTextBox rct1;
        public RichTextBox linmber;
        private Boolean BS = false;
        public Boolean TShow;
        public Boolean LTheme;
        public Boolean WTBMode;
        public Boolean DTheme;
        private String opn2space;
        public String width;
        public String height;
        public String XVal;
        public String yVal;
        private String TempMusicTitle;
        private Boolean wordwrap;
        private Boolean linenumshow = false;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            rct1 = richTextBox1;
            linmber = LineNumberTextBox;
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1
            int line = richTextBox1.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox1.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox1.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox1.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            panel1.Hide();
            axWindowsMediaPlayer1.Hide();
            timer2.Start();
            webBrowser1.Hide();
            StreamReader sw = new StreamReader(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Time");
            if (File.Exists(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Time"))
            {
                String cont = sw.ReadToEnd();
                if (cont.Contains("Ttrue"))
                {
                    label2.Show();
                    TShow = true;
                }
                else if (cont.Contains("ftrue"))
                {
                    label2.Hide();
                    TShow = false;
                }
                sw.Close();
            }

            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Theme");
            string contents = sr.ReadToEnd();
            if (File.Exists(Environment.CurrentDirectory + "\\Assets\\Log\\Settings\\Appearance\\Theme"))
            {
                if (contents.Contains("Defualt"))
                {
                    menuStrip1.BackColor = Color.Gray;
                    panel3.BackColor = Color.FromArgb(23, 36, 44);
                    richTextBox1.BackColor = Color.FromArgb(31, 35, 37);
                    label3.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    richTextBox1.ForeColor = Color.White;
                    LineNumberTextBox.ForeColor = Color.White;
                    LineNumberTextBox.BackColor = Color.FromArgb(31, 35, 37);
                    sr.Close();
                    DTheme = true;
                }
                else if (contents.Contains("Light"))
                {
                    menuStrip1.BackColor = Color.White;
                    panel3.BackColor = Color.FromArgb(211, 211, 211);
                    richTextBox1.BackColor = Color.White;
                    label3.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    richTextBox1.ForeColor = Color.Black;
                    LineNumberTextBox.ForeColor = Color.Black;
                    LineNumberTextBox.BackColor = Color.White;
                    sr.Close();
                    LTheme = true;
                }
                else if (contents.Contains("WTB"))
                {
                    richTextBox1.BackColor = Color.White;
                    richTextBox1.ForeColor = Color.Black;
                    sr.Close();
                    WTBMode = true;
                }
                sr.Close();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.FormBorderStyle = FormBorderStyle.Sizable;
            f1.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.FileName.Length == 0)
            {
                label3.Text = "";
                saveFileDialog1.FileName = "";
                openFileDialog1.FileName = "";
                richTextBox1.Clear();
                richTextBox1.ForeColor = Color.White;
                richTextBox1.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            }
            else
            {
                if (MessageBox.Show("Do You Want to Save?", "CS Wording", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!File.Exists(saveFileDialog1.FileName))
                    {
                        if (saveFileDialog1.FileName.Length == 0)
                        {
                            saveFileDialog1.FileName = "Untitled Document";
                            saveFileDialog1.Title = "Browse Text Files";
                            saveFileDialog1.DefaultExt = "txt";
                            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                                writer.Write(richTextBox1.Text);
                                writer.Close();
                                label3.Text = Path.GetFileName(saveFileDialog1.FileName);
                            }
                        }
                        else
                        {
                            MessageBox.Show("File doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            saveFileDialog1.FileName = "";
                            label3.Text = "";
                            openFileDialog1.FileName = "";
                        }
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                        writer.Write(richTextBox1.Text);
                        writer.Close();
                    }
                }
                else if (MessageBox.Show("Do You Want to Save?", "CS Wording", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    label3.Text = "";
                    saveFileDialog1.FileName = "";
                    openFileDialog1.FileName = "";
                    richTextBox1.Clear();
                    richTextBox1.ForeColor = Color.White;
                    richTextBox1.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = text;
                label3.Text = Path.GetFileName(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(saveFileDialog1.FileName))
            {
                if (saveFileDialog1.FileName.Length == 0)
                {
                    if (label3.Text.Length == 0)
                    {
                        saveFileDialog1.FileName = "Untitled Document";
                        saveFileDialog1.Title = "Browse Text Files";
                        saveFileDialog1.DefaultExt = "txt";
                        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                            writer.Write(richTextBox1.Text);
                            writer.Close();
                            label3.Text = Path.GetFileName(saveFileDialog1.FileName);
                        }
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(openFileDialog1.FileName);
                        writer.Write(richTextBox1.Text);
                        writer.Close();
                    }
                }
                else
                {
                    MessageBox.Show("File doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    saveFileDialog1.FileName = "";
                    label3.Text = "";
                }
            }
            else
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Untitled Document";
            saveFileDialog1.Title = "Browse Text Files";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
                label3.Text = Path.GetFileName(saveFileDialog1.FileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Save?", "CS Wording", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!File.Exists(saveFileDialog1.FileName))
                {
                    if (saveFileDialog1.FileName.Length == 0)
                    {
                        saveFileDialog1.FileName = "Untitled Document";
                        saveFileDialog1.Title = "Browse Text Files";
                        saveFileDialog1.DefaultExt = "txt";
                        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                            writer.Write(richTextBox1.Text);
                            writer.Close();
                            label3.Text = Path.GetFileName(saveFileDialog1.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        saveFileDialog1.FileName = "";
                        label3.Text = "";
                    }
                }
                else
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                    writer.Write(richTextBox1.Text);
                    writer.Close();
                }
            }
            else if (MessageBox.Show("Do You Want to Save?", "CS Wording", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + DateTime.Now;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void clearTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Please enter a text for the system to speak.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string toSpeak = richTextBox1.Text;
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.Speak(toSpeak);
                speechSynthesizer.Dispose();
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace f2 = new Replace();
            f2.ShowDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo f2 = new GoTo();
            f2.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find f2 = new Find();
            f2.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator f2 = new Calculator();
            f2.ShowDialog();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(31, 35, 37);
            richTextBox1.ForeColor = Color.White;
        }

        private void whiteTextBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }

        private void feedBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedBack f2 = new FeedBack();
            f2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings f2 = new Settings();
            f2.Show();
        }

        private void showWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS == false)
            {
                showWebBrowserToolStripMenuItem.Text = "Hide Web Browser";
                var appname = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
                using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                    key.SetValue(appname, 99999, RegistryValueKind.DWord);
                webBrowser1.Show();
                webBrowser1.Dock = DockStyle.Fill;
                BS = true;
            }
            else
            {
                showWebBrowserToolStripMenuItem.Text = "Show Web Browser";
                webBrowser1.Navigate("https://www.google.com/");
                webBrowser1.Hide();
                BS = false;
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MusicOpenFileDialog.FileName.Length == 0)
            {
                MusicOpenFileDialog.FileName = "";
                MusicOpenFileDialog.Title = "Open Music Files";
                MusicOpenFileDialog.Filter = "All Music Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mp3;*.mpa;*.mpe;*.m3u;";
                if (MusicOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    axWindowsMediaPlayer1.URL = MusicOpenFileDialog.FileName;
                    TempMusicTitle = label3.Text;
                    label3.Text = Path.GetFileName(MusicOpenFileDialog.FileName);
                    timer1.Start();
                }
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            MusicOpenFileDialog.FileName = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = TempMusicTitle;
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Width2.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Boxes if you want to Auto Resize then enter a random width height and then click on Auto Resize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Height2.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Boxes if you want to Auto Resize then enter a random width height and then click on Auto Resize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PathX.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Boxes if you want to Auto Resize then enter a random width height and then click on Auto Resize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PathY.Text.Length == 0)
            {
                MessageBox.Show("Please Fill All The Boxes if you want to Auto Resize then enter a random width height and then click on Auto Resize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                opn2.Title = ("Add Images");
                opn2.FileName = "";
                opn2.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|GIF files|*.gif|TIFF files|*.tif|Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                if (opn2.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(opn2.FileName);
                    width = Width2.Text;
                    height = Height2.Text;
                    XVal = PathX.Text;
                    yVal = PathY.Text;
                }
            }
        }

        private void addImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel1.Dock = DockStyle.Fill;
        }

        private void Width2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opn2.FileName.Length != 0)
            {
                if (PathX.Text.Length == 0)
                {
                    MessageBox.Show("Please Fill the both X and Y Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (PathY.Text.Length == 0)
                {
                    MessageBox.Show("Please Fill the both X and Y Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Width2.Text = "800";
                    Height2.Text = "600";
                    width = Width2.Text;
                    height = Height2.Text;
                    XVal = PathX.Text;
                    yVal = PathY.Text;
                    panel1.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please Select the image first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (opn2.FileName.Length == 0)
            {
                e.Graphics.DrawString(richTextBox1.Text, new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style), Brushes.Black, 150, 125);
            }
            else
            {
                Bitmap bmp = new Bitmap(opn2.FileName);
                Image img = bmp;
                e.Graphics.DrawImage(img, Convert.ToInt32(XVal), Convert.ToInt32(yVal), Convert.ToInt32(width), Convert.ToInt32(height));
                e.Graphics.DrawString(richTextBox1.Text, new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style), Brushes.Black, 150, 125);
            }
        }

        private void disbaleWordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordwrap == true)
            {
                richTextBox1.WordWrap = false;
                wordwrap = false;
                disbaleWordWrapToolStripMenuItem.Text = "Enable WordWrap";
            }
            else
            {
                richTextBox1.WordWrap = true;
                wordwrap = true;
                disbaleWordWrapToolStripMenuItem.Text = "Disable WordWrap";
            }
        }

        private void wordCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordCount f2 = new WordCount();
            f2.ShowDialog();
        }

        private void Width2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Height2.Focus();
            }
        }

        private void Height2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PathX.Focus();
            }
        }

        private void PathX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PathY.Focus();
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = richTextBox1.Font;
            richTextBox1.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }
    }
}
