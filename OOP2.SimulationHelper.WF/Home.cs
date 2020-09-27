using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace OOP2.SimulationHelper.WF
{
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        SpeechSynthesizer sp=new SpeechSynthesizer();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Speech();
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mbtnLogin_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            lblWelcome.Text = label1.Text = label2.Text = "";
            LOgInManager lim = new LOgInManager();
            lim.TopLevel = false;
            lim.AutoScroll = true;
            lim.FormBorderStyle = FormBorderStyle.None;
            lim.Dock = DockStyle.Fill;
            this.pictureBox1.Controls.Add(lim);
            lim.Show();
        }

        private void Speech()
        {
            //string speech = "shagotom";
            string speech = lblWelcome.Text + "\n" + label1.Text + label2.Text;
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female);
            sp.SpeakAsync(speech);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
        }

        private void backroundPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".jpg") || openFileDialog1.FileName.EndsWith(".JPG"))
                {
                    var path = openFileDialog1.FileName;
                    pictureBox1.ImageLocation = path;
                }
                else
                {
                    MessageBox.Show("Invalid File");
                }
            }
        }

        private void mbtnRegistration_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            lblWelcome.Text = label1.Text = label2.Text = "";
            Registration r = new Registration(-1);
            r.TopLevel = false;
            r.AutoScroll = true;
            r.FormBorderStyle = FormBorderStyle.None;
            r.Dock = DockStyle.Fill;
            this.pictureBox1.Controls.Add(r);
            r.Show();
        }
    }
}
