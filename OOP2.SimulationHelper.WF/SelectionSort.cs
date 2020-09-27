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
using OOP2.SimulationHelper.Data;
using OOp2.SimulationHelper.Framework;
using OOP2.SimulationHelper.Repo;

namespace OOP2.SimulationHelper.WF
{
    public enum StepsEnum
    {
        Start = 0,
        Selection = 1,
        Comparison = 2,
        Success = 3,
        Failure = 4
    }

    public partial class SelectionSort : MetroFramework.Forms.MetroForm
    {
        List<Button> allBtns = new List<Button>();
        int i = 0, j = 0;
        int w = 15, l = 75;
        int prevX = 0, count = 0;
        StepsEnum currentStep;

        private string TitleName;

        Button firstButton, secondButton;

        SpeechSynthesizer sp=new SpeechSynthesizer();

        UserInputRepo repo = new UserInputRepo();
        List<int> ParentInputs = new List<int>(); 


        public SelectionSort()
        {
            InitializeComponent();
        }

        public SelectionSort(List<int> parentInputs )
        {
            this.ParentInputs = parentInputs;

            InitializeComponent();
            this.LoadInputs();
        }

        public SelectionSort(string titleName)
        {
            this.TitleName = titleName;
            InitializeComponent();
            LoadInputs();
        }

        private void SelectionSort_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < allBtns.Count; k++)
            {
                allBtns[k].BackColor = Color.DarkCyan;
            }

            if (currentStep == StepsEnum.Start)
            {
                Start();
            }
            else if (currentStep == StepsEnum.Selection)
            {
                Selection();
            }
            else if (currentStep == StepsEnum.Comparison)
            {
                ComparisonValue();
                //txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Comparing ";
            }
            else if (currentStep == StepsEnum.Success)
            {
                Button temp = allBtns[i];
                allBtns[i] = allBtns[j];
                allBtns[j] = temp;
                prevX = firstButton.Location.X;
                count = 1;
                btnNext.Enabled = false;
                txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Sorting ";
                timer1.Start();
            }
            else if (currentStep == StepsEnum.Failure)
            {
                currentStep = StepsEnum.Selection;
                Selection();
            }

            Speech();
        }


        private void Start()
        {
            lblStatus.Text = "Started";
            txtAction.Text = "Selection Sort Is Going To Start ";
            currentStep = StepsEnum.Selection;
        }

        private void Selection()
        {
            lblStatus.Text = "Selection";

            if (i == -1 || j == -1)
            {
                i = 0;
                j = 1;
            }
            else if (i == allBtns.Count - 2)
            {
                lblStatus.Text = "Finished";
                btnNext.Enabled = false;
            }
            else if (j == allBtns.Count - 1)
            {
                i++;
                j = i + 1;
            }
            else
            {
                j++;
            }

            firstButton = allBtns[i];
            secondButton = allBtns[j];

            firstButton.BackColor = Color.DarkBlue;
            secondButton.BackColor = Color.DarkBlue;

            txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Selected ";

            currentStep = StepsEnum.Comparison;
        }

        private void ComparisonValue()
        {
            int f = Int32.Parse(firstButton.Text);
            int s = Int32.Parse(secondButton.Text);

            if (f > s)
            {
                currentStep = StepsEnum.Success;
                firstButton.BackColor = Color.DarkGreen;
                secondButton.BackColor = Color.DarkGreen;
                lblStatus.Text = "Success";

                txtAction.Text = firstButton.Text + " Is Greater Then  " + secondButton.Text +"\n So It Has Been Sorting ";
            }
            else
            {
                currentStep = StepsEnum.Failure;
                firstButton.BackColor = Color.DarkRed;
                secondButton.BackColor = Color.DarkRed;
                lblStatus.Text = "Failure";

               txtAction.Text = firstButton.Text + " Is Not Greater Then  " + secondButton.Text + "\n So It Has Not Been Sorting ";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentStep = StepsEnum.Start;
            i = j = -1;

            int itemsCount = lbArrayItem.Items.Count;

            //MessageBox.Show(itemsCount.ToString());

            if (itemsCount < 2)
            {
                ItemAdd();
                return;
            }

            //int x = 15;
            //this.metroPanel1.Controls.Clear();
            foreach (var item in lbArrayItem.Items)
            {
                Button btn = new Button();
                btn.Text = item.ToString();
                btn.Location = new Point(w, l);
                btn.Size = new Size(75, 25);
                btn.BackColor = Color.DarkCyan;
                btn.ForeColor = Color.White;

                this.metroPanel1.Controls.Add(btn);
                allBtns.Add(btn);

                w += 85;
            }

            metroPanel4.Visible = false;
            btnNext.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbArrayItem.Items.Remove(lbArrayItem.SelectedItem);
            //foreach (var eachItem in lbArrayItem.SelectedItems)
            //{
            //    lbArrayItem.Items.Remove(eachItem);
            //}
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

            

            lbArrayItem.Items.Add(value.ToString());

            txtAdd.Text = "";
            txtAdd.Focus();
        }

        private void LoadInputs()
        {
            if (ParentInputs.Count > 2)
            {
                lbArrayItem.DataSource = ParentInputs;
            }

            metroButton1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstButton.Location.X == prevX && count <= 5)
            {
                firstButton.Location = new Point(firstButton.Location.X, firstButton.Location.Y - 5);
                secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y + 5);
                count++;
            }
            else if (secondButton.Location.X > prevX)
            {
                firstButton.Location = new Point(firstButton.Location.X + 5, firstButton.Location.Y);
                secondButton.Location = new Point(secondButton.Location.X - 5, secondButton.Location.Y);
            }
            else if (firstButton.Location.X != prevX && count > 1)
            {
                firstButton.Location = new Point(firstButton.Location.X, firstButton.Location.Y + 5);
                secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y - 5);
                count--;
            }
            else
            {
                timer1.Stop();
                btnNext.Enabled = true;
                
                currentStep = StepsEnum.Selection;
            }
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
                        lbArrayItem.Items.Add(line);
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
            ItemAdd();
        }

        private void txtAction_Enter(object sender, EventArgs e)
        {
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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lbArrayItem.Items.Count < 2)
            {
                MessageBox.Show("Please Insert Value");
                txtAdd.Focus();
                return;
            }
            //var userInput = new UserInput();

            //if (txtSaveInputsName.Text == "")
            //{
            //    MessageBox.Show(" Please Set A Name First ");
            //    txtSaveInputsName.Focus();
            //    return;
            //}

            //userInput.Title = txtSaveInputsName.Text;
            //userInput.UserID = LogInHelper.UserProfile.ID;

            string number = "";

            foreach (var item in lbArrayItem.Items)
            {
                number += item + ",";
            }

            number = number.Substring(0, number.Length - 1);

            //userInput.Inputs = number;

            //var result = repo.Save(userInput);

            //if (result.HasError)
            //{
            //    MessageBox.Show(result.Message);
            //    return;
            //}
            
            txtAdd.Dispose();
            //lbArrayItem.Dispose();
            btnAdd.Dispose();
            btnDelete.Dispose();
            btnBrows.Dispose();
            metroButton1.Dispose();
            btnLoad.Dispose();

            InputTitleName itn = new InputTitleName(this, number);
            itn.Show();
            //this.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UserInputManager uim = new UserInputManager(this);
            uim.Show();
            this.Hide();
        }

        private void lbArrayItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
