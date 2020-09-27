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
using OOP2.SimulationHelper.Data;
using OOp2.SimulationHelper.Framework;
using OOP2.SimulationHelper.Repo;
using System.Speech;
using System.Speech.Synthesis;

namespace OOP2.SimulationHelper.WF
{
    

    public partial class InsertionSort : MetroFramework.Forms.MetroForm
    {
        SpeechSynthesizer sp = new SpeechSynthesizer();

        private string TitleName;

        List<int> ParentInputs = new List<int>(); 

        public InsertionSort()
        {
            InitializeComponent();
        }

        public InsertionSort(List<int> parentInputs)
        {
            this.ParentInputs = parentInputs;
            InitializeComponent();
            this.LoadInputs(); 
        }

        public InsertionSort(string titleName)
        {
            this.TitleName = titleName;
            InitializeComponent();
            LoadInputs();
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

        private void InsertionSort_Load(object sender, EventArgs e)
        {

        }

        private int w = 15, l = 185;
        private int i = 0, j = 0;

        int sortedIndex=0;
        int index = 0;
        private int count = 0;
        private int t = 0;
        private int prevX = 0;

        List<Button> allBtns = new List<Button>();
        List<Button> sortedBtns = new List<Button>();
        List<Button> reverseBtns = new List<Button>();
        List<int> locationX = new List<int>();
        List<int> locationY = new List<int>(); 
        private bool test = true;

        private string Number;

        UserInputRepo repo = new UserInputRepo();

        Button firstButton, secondButton;
        

        private StepsEnum currentStep;

        private void btnStart_Click(object sender, EventArgs e)
        {
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

            //txtSaveInputsName.Dispose();
            panel2.Dispose();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < allBtns.Count; k++)
            {
                allBtns[k].BackColor = Color.DarkCyan;
            }

            if (currentStep == StepsEnum.Start)
                Start();
            else if (currentStep == StepsEnum.Selection)
                Selection();
            else if (currentStep == StepsEnum.Comparison)
                CompareValue();
            else if (currentStep == StepsEnum.Failure)
                Failure();
            else if (currentStep == StepsEnum.Success)
                Success();

            Speech();
        }

        private void Success()
        {
            if (sortedBtns.Count != 0 && locationX.Count != 0)
            {
                sortedBtns.Clear();
                locationX.Clear();
                j = 0;
            }
           
            for (int k = 0; k < allBtns.Count; k++)
            {
                if (index > sortedIndex)
                {
                    firstButton = allBtns[index - 1];
                    secondButton = allBtns[index];

                    sortedBtns.Add(firstButton);

                    prevX = firstButton.Location.X;

                    Button temp;
                    temp = allBtns[index];
                    allBtns[index] = allBtns[index - 1];
                    allBtns[index - 1] = temp;

                    

                    count = 1;
                }
                else
                {
                    break;
                }

                index--;
            }

            sortedIndex++;
            currentStep = StepsEnum.Selection;

            sortedBtns.Reverse();
            sortedBtns.Add(secondButton);

            foreach (var sortedBtn in sortedBtns)
            {
                locationX.Add(sortedBtn.Location.X);
                locationY.Add(sortedBtn.Location.Y);
            }

            timer1.Start();
            btnNext.Enabled = false;
            //Selection();
        }

        private void Failure()
        {
            sortedIndex++;
            currentStep = StepsEnum.Selection;
            Selection();
            allBtns[index].BackColor = Color.DarkRed;
        }

        private void CompareValue()
        {
            if (index == sortedIndex)
            {
                currentStep = StepsEnum.Failure;
                allBtns[index].BackColor = Color.DarkRed;

                txtAction.Text = allBtns[index].Text + " Button Is The Right Position , It Won't Be Change ";
            }

            else 
            {
                currentStep = StepsEnum.Success;
                allBtns[index].BackColor = Color.DarkGreen;
                txtAction.Text = allBtns[index].Text + " Button Is The Wrong Position , It Will Change ";
            }
        }

        private void Selection()
        {
            btnNext.Enabled = true;
            index = sortedIndex;

            if (sortedIndex == allBtns.Count-1)
            {
                btnNext.Enabled = false;

                txtAction.Text = " Insertion Sort Finish , Thank You " + LogInHelper.UserProfile.Name;
            }

            int min = Int32.Parse(allBtns[sortedIndex].Text);

            
            for (int i = sortedIndex; i < allBtns.Count; i++)
            {
                if (min > Int32.Parse(allBtns[i].Text))
                {
                    t = 1;
                    index = i;
                    min = Int32.Parse(allBtns[i].Text);
                }
                    
            }

            allBtns[index].BackColor = Color.DarkBlue;

            txtAction.Text = allBtns[index].Text + " Button Is Selected Because it is The "+ sortedIndex.ToString()+" Smallest Button ";

            currentStep = StepsEnum.Comparison;            

            //if(sortedIndex>0)
            //    allBtns.RemoveAt(sortedIndex-1);
        }

        private void Start()
        {
            currentStep = StepsEnum.Selection;
            txtAction.Text = "Insertion Sort Is Going To Start ";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(count!=2)
                i = sortedBtns.Count - 2;
                if (j < 5)
                {
                    secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y - 5);
                    j++;
                    count = 1;
                }

                else if (i < 0)
                {
                    timer1.Stop();
                    btnNext.Enabled = true;
                }

                else if (secondButton.Location.X > locationX[0])
                {
                    secondButton.Location = new Point(secondButton.Location.X - 5, secondButton.Location.Y);
                }

                else if (sortedBtns[i].Location.X > locationX[i + 1])
                {
                    count = 2;
                    i--;
                }

                else if (secondButton.Location.Y < locationY[0] && sortedBtns[0].Location.X > locationX[0] + 80)
                {
                    secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y + 5);
                }

                else 
                {
                    sortedBtns[i].Location = new Point(sortedBtns[i].Location.X + 5, sortedBtns[i].Location.Y);
                    count = 1;
                }     
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UserInputManager uim = new UserInputManager(this);
            uim.Show();
            this.Hide();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemAdd();
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lblArrayItem.Items.Count < 2)
            {
                MessageBox.Show("Please Insert Value");
                txtAdd.Focus();
                return;
            }
            //var userInput = new UserInput();
            ////userInput.ID = 2;
            //if (txtSaveInputsName.Text == "")
            //{
            //    MessageBox.Show(" Please Set A Name First ");
            //    txtSaveInputsName.Focus();
            //    return;
            //}

            //userInput.Title = txtSaveInputsName.Text;
            //userInput.UserID = LogInHelper.UserProfile.ID;

            string number = "";

            foreach (var item in lblArrayItem.Items)
            {
                number += item + ",";
            }

            number = number.Substring(0, number.Length - 1);

            Number=number;
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

            //DelegateCollection.inputSet inpset = new DelegateCollection.inputSet(SetInputs);

            InputTitleName itn = new InputTitleName(this, number);
            itn.Show();
            //this.Hide();
        }

        private void SetInputs(string s)
        {

            foreach (var n in s)
            {
                lblArrayItem.Items.Add(n);
            }
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

        public void SetInputs(InsertionSort ins,string num)
        {
            
            
        }

        private void txtAction_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblArrayItem.Items.Remove(lblArrayItem.SelectedItem);
        }
    }
}
