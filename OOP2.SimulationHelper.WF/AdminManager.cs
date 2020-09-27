using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOp2.SimulationHelper.Framework;
using System.Speech;
using System.Speech.Synthesis;

namespace OOP2.SimulationHelper.WF
{
    public partial class AdminManager : MetroFramework.Forms.MetroForm
    {
        SpeechSynthesizer sp=new SpeechSynthesizer();

        public AdminManager()
        {
            InitializeComponent();
        }

        private void AdminManager_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, "+LogInHelper.UserProfile.Name;
            this.Speech();
        }

        private void AdminManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home h=new Home();
            h.Show();
        }

        private void mbtnProfile_Click(object sender, EventArgs e)
        {

        }

        private void mbtnProfile_Click_1(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();
            Registration r = new Registration(LogInHelper.UserProfile.ID);
            r.TopLevel = false;
            r.AutoScroll = true;
            r.FormBorderStyle = FormBorderStyle.None;
            r.Dock = DockStyle.Fill;
            this.metroPanel2.Controls.Add(r);
            r.Show();
        }

        private void mbtnUsers_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();
            UserInfoManager ui = new UserInfoManager();
            ui.TopLevel = false;
            ui.AutoScroll = true;
            ui.FormBorderStyle = FormBorderStyle.None;
            ui.Dock = DockStyle.Fill;
            this.metroPanel2.Controls.Add(ui);
            ui.Show();
        }

        private void Speech()
        {
            string speech = lblWelcome.Text;
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female);
            sp.SpeakAsync(speech);
        }

        private void mbtnLogOut_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void mbtnSimulation_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();
            SimulationChooseButton scb = new SimulationChooseButton();
            scb.TopLevel = false;
            scb.AutoScroll = true;
            scb.FormBorderStyle = FormBorderStyle.None;
            scb.Dock = DockStyle.Fill;
            this.metroPanel2.Controls.Add(scb);
            scb.Show();
        }
    }
}
