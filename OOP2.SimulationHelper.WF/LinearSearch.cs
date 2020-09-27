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
    public partial class LinearSearch : MetroFramework.Forms.MetroForm
    {
        SpeechSynthesizer sp = new SpeechSynthesizer();

        private int i = 0;
        private int j = 0;
        private int w = 15, l = 185;

        private string TitleName;
        private bool check = false;

        private StepsEnum currentStep;

        List<int> ParentInputs = new List<int>(); 

        List<Button> allBtns = new List<Button>(); 
        public LinearSearch()
        {
            InitializeComponent();
        }

        public LinearSearch(List<int> parentInputs)
        {
            this.ParentInputs = parentInputs;
            InitializeComponent();
            this.LoadInputs();
        }

        public LinearSearch(string titleName)
        {
            this.TitleName = titleName;
            InitializeComponent();
            this.LoadInputs();
        }

        private void LoadInputs()
        {
            if (ParentInputs.Count > 2)
            {
                lblArrayItem.DataSource = ParentInputs;
                //foreach (var parentInput in ParentInputs)
                //{
                //    lblArrayItem.Items.Add(parentInput.ToString());
                //}
            }
        }

        private void LinearSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show(" Please Insert Searching Value ");
                txtSearch.Focus();
                return;
            }

            int search;

            if (!Int32.TryParse(txtSearch.Text, out search))
            {
                MessageBox.Show("Please Insert valid Input ");
                txtSearch.Focus();
                txtSearch.Text = "";
                return;
            }

            currentStep = StepsEnum.Start;
            i = j = -1;
            foreach (var item in lblArrayItem.Items)
            {
                Button btn = new Button();
                btn.Text = item.ToString();
                btn.Location = new Point(w, l);
                btn.Size = new Size(75, 25);
                btn.BackColor = Color.DarkCyan;
                btn.ForeColor = Color.White;

                this.panel1.Controls.Add(btn);
                allBtns.Add(btn);
                //sortedBtns.Add(btn);

                w += 85;
            }

            //txtSearch.Dispose();
            panel2.Dispose();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".csv") || openFileDialog1.FileName.EndsWith(".CSV"))
                {
                    var lines = File.ReadAllLines(openFileDialog1.FileName);
                    //lbArrayItem.DataSource = lines;

                    foreach (var line in lines)
                    {
                        lblArrayItem.Items.Add(line);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid File");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ItemAdd();
        }

        private void ItemAdd()
        {
            if (txtAdd.Text == "")
            {
                MessageBox.Show("Please Insert Some Value");
                txtAdd.Focus();
                txtAdd.Text = "";
                return;
            }

            int value;
            if (!Int32.TryParse(txtAdd.Text, out value))
            {
                MessageBox.Show("Please Insert Some valid Value");
                txtAdd.Focus();
                txtAdd.Text = "";
                return;
            }

            lblArrayItem.Items.Add(value.ToString());

            txtAdd.Text = "";
            txtAdd.Focus();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UserInputManager uim = new UserInputManager(this);
            uim.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            foreach (var button in allBtns)
            {
                button.BackColor = Color.DarkCyan; 
            }

            if (currentStep == StepsEnum.Start)
                Start();
            else if (currentStep == StepsEnum.Selection)
                Selection();
            else if (currentStep == StepsEnum.Comparison)
                CompaireValue();
            else if (currentStep == StepsEnum.Success)
                Success();
            else if (currentStep == StepsEnum.Failure)
                Failure();

            Speech();
        }

        private void Speech()
        {
            if (txtAction.Text == "")
                return;
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female);
            sp.SpeakAsync(txtAction.Text);

        }

        private void Failure()
        {
            i++;
            currentStep = StepsEnum.Selection;
            Selection();
        }

        private void Success()
        {
            i++;
            currentStep = StepsEnum.Selection;
            check = true;
            Selection();
            MessageBox.Show(" Matched ");
        }

        private void CompaireValue()
        {
            int f = Int32.Parse(allBtns[i].Text);
            int s = Int32.Parse(txtSearch.Text);

            if (f == s)
            {
                currentStep = StepsEnum.Success;
                allBtns[i].BackColor = Color.DarkGreen;
                txtAction.Text = allBtns[i].Text + " Button Is Our Desired Output ";
            }

            else
            {
                currentStep = StepsEnum.Failure;
                allBtns[i].BackColor = Color.DarkRed;
                txtAction.Text = allBtns[i].Text + " Button Is Not Our Desired Output ";
            }
        }

        private void Selection()
        {
            if (i == -1 && j == -1)
            {
                i = 0;
                j = 0;
            }

            else if (i == lblArrayItem.Items.Count-1)
            {
                if (check)
                    txtAction.Text = " Successfully Search Operation Done , Found Desire Output ";
                else
                    txtAction.Text = " Successfully Search Operation Done , Not Found Desire Output ";
                btnNext.Enabled = false;
            }

            allBtns[i].BackColor = Color.DarkBlue;
            //i++;
            txtAction.Text = allBtns[i].Text + " Button Is Selected "; 
            currentStep = StepsEnum.Comparison;
        }

        private void Start()
        {
            currentStep = StepsEnum.Selection;
            i = j = -1;
            txtAction.Text = " Binary Search Is Going To Start ";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lblArrayItem.Items.Count < 2)
            {
                MessageBox.Show("Please Insert Value");
                txtAdd.Focus();
                return;
            }
            string number = "";

            foreach (var item in lblArrayItem.Items)
            {
                number += item + ",";
            }

            number = number.Substring(0, number.Length - 1);

            txtAdd.Dispose();
            //lbArrayItem.Dispose();
            btnAdd.Dispose();
            btnDelete.Dispose();
            btnBrows.Dispose();
            metroButton1.Dispose();
            btnLoad.Dispose();

            InputTitleName itn = new InputTitleName(this, number);
            itn.Show();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblArrayItem.Items.Remove(lblArrayItem.SelectedItem);
        }
    }
}
