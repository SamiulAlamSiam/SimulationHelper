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
    public partial class BubbleSort : MetroFramework.Forms.MetroForm
    {

        UserInputRepo repo = new UserInputRepo();
        List<Button> allBtns = new List<Button>();
        List<int> ParentInputs = new List<int>(); 
        int i = 0, j = 0;
        int w = 15, l = 75;

        private string TitleName;
        int prevX = 0, count = 0, totalIteration = 1;
        StepsEnum currentStep;

        SpeechSynthesizer sp=new SpeechSynthesizer();

        Button firstButton, secondButton;

        public BubbleSort()
        {
            InitializeComponent();
        }

        public BubbleSort(List<int> parentInputs)
        {
            this.ParentInputs = parentInputs;
            InitializeComponent();
            this.LoadInputs();
        }

        public BubbleSort(string titleName)
        {
            this.TitleName = titleName;
            InitializeComponent();
            LoadInputs();
        }

        private void LoadInputs()
        {
            if (ParentInputs.Count > 2)
            {
                lbArrayItem.DataSource = ParentInputs;
            }
            metroButton1.Enabled = false;
        }

        private void BubbleSort_Load(object sender, EventArgs e)
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
                CompareValue();
            }
            else if (currentStep == StepsEnum.Failure)
            {
                currentStep = StepsEnum.Selection;
                Selection();
            }
            else if (currentStep == StepsEnum.Success)
            {
                var temp = allBtns[i];
                allBtns[i] = allBtns[j];
                allBtns[j] = temp;

                prevX = firstButton.Location.X;
                count= 1;

                btnNext.Enabled = false;
                txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Sorting ";
                timer1.Start();

            }
            lblStatus.Text = totalIteration.ToString();

            Speech();
        }

        private void CompareValue()
        {
            int f, s;
            f = Int32.Parse(firstButton.Text);
            s = Int32.Parse(secondButton.Text);

            if (f > s)
            {
                firstButton.BackColor = secondButton.BackColor = Color.DarkGreen;
                currentStep = StepsEnum.Success;

                txtAction.Text = firstButton.Text + " Is Greater Then  " + secondButton.Text + "\n So It Has Been Sorting ";
            }
            else
            {
                firstButton.BackColor = secondButton.BackColor = Color.DarkRed;

                txtAction.Text = firstButton.Text + " Is Not Greater Then  " + secondButton.Text + "\n So It Has Not Been Sorting ";
                currentStep = StepsEnum.Failure;
            }
        }

        private void Selection()
        {
            if (i == -1 && j == -1)
            {
                i = 0;
                j = 1;
            }

            else if (totalIteration > (allBtns.Count * allBtns.Count) - 1)
            {
                btnNext.Enabled = false;
            }

            else if (totalIteration % (allBtns.Count - 1) == 0)
            {
                i = 0;
                j = 1;
                totalIteration++;
            }

            else
            {
                i++;
                j++;
                totalIteration++;
            }

            firstButton = allBtns[i];
            secondButton = allBtns[j];

            firstButton.BackColor = secondButton.BackColor = Color.DarkBlue;

            txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Selected ";

            currentStep = StepsEnum.Comparison;
        }

        private void Start()
        {
            currentStep = StepsEnum.Selection;
            txtAction.Text = "Selection Sort Is Going To Start ";
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentStep = StepsEnum.Start;
            i = j = -1;

            int itemsCount = lbArrayItem.Items.Count;


            if (itemsCount < 2)
            {
                ItemAdd();
                return;
            }

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

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".csv") || openFileDialog1.FileName.EndsWith(".CSV"))
                {
                    var lines = File.ReadAllLines(openFileDialog1.FileName);
                    lbArrayItem.DataSource = lines;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbArrayItem.Items.Remove(lbArrayItem.SelectedItem);
            //foreach (ListViewItem eachItem in lbArrayItem.SelectedItems)
            //{
            //    lbArrayItem.Items.Remove(eachItem);
            //}
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lbArrayItem.Items.Count < 2)
            {
                MessageBox.Show("Please Insert Value");
                txtAdd.Focus();
                return;
            }
            //{
            //    var userInput = new UserInput();
            //    //userInput.ID = 2;
            //    if (txtSaveInputsName.Text == "")
            //    {
            //        MessageBox.Show(" Please Set A Name First ");
            //        txtSaveInputsName.Focus();
            //        return;
            //    }

            //    userInput.Title = txtSaveInputsName.Text;
            //    userInput.UserID = LogInHelper.UserProfile.ID;

                string number = "";

                foreach (var item in lbArrayItem.Items)
                {
                    number += item + ",";
                }

                number = number.Substring(0, number.Length - 1);

                //userInput.Inputs = number;

                //var result = repo.Save(userInput);


                //SimulationHelperContext context = new SimulationHelperContext();
                //context.UserInputs.Add(userInput);
                //context.SaveChanges();

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
    }
}
