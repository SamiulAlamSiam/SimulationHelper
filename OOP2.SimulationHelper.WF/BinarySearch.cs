using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;

namespace OOP2.SimulationHelper.WF
{
    public partial class BinarySearch : MetroFramework.Forms.MetroForm
    {

         //List<Button> allBtns1 = new List<Button>();
        int i1 = 0, j1 = 0;
        //int w = 15, l = 75;
        int prevX1 = 0, count1 = 0;
        StepsEnum currentStep1;

        private string TitleName;

        Button firstButton, secondButton;

        SpeechSynthesizer sp = new SpeechSynthesizer();

        List<int> ParentInputs = new List<int>(); 

        List<Button> allBtns = new List<Button>();
        private int w = 15, l = 75, m = 0, n = 1;
        private int prevX = 0, count = 0;
        StepsEnum currentStep;

       // List<Button> allButtons = new List<Button>();
        private int i = -1, j = -1, selectedIndex = 0;
        private Button btnCompare, btnfirst, btnSecond;


        public BinarySearch()
        {
            InitializeComponent();
        }

        public BinarySearch(string titleName)
        {
            this.TitleName = titleName;
            InitializeComponent();
            this.LoadInputs();
        }

        public BinarySearch(List<int> parentInputs)
        {
            this.ParentInputs = parentInputs;
            InitializeComponent();
            this.LoadInputs();
        }

        private void LoadInputs()
        {
            if (ParentInputs.Count > 2)
            {
                lbArrayItem.DataSource = ParentInputs;
                //foreach (var parentInput in ParentInputs)
                //{
                //    lblArrayItem.Items.Add(parentInput.ToString());
                //}
            }
        }

        private void BinarySearch_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentStep = StepsEnum.Start;
            currentStep1 = StepsEnum.Start;
            i1 = j1 = -1;
            i = j = -1;

            int itemsCount = lbArrayItem.Items.Count;

            if (itemsCount < 2)
            {
                ItemAdd();
                return;
            }

            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please Insert a Value for Sraeching ");
                txtSearch.Focus();
                txtSearch.Text = "";
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

            foreach (var item in lbArrayItem.Items)
            {
                Button btn = new Button();
                btn.Text = item.ToString();
                btn.Location = new Point(w, l);
                btn.Size = new Size(75, 25);
                btn.BackColor = Color.DarkCyan;
                btn.ForeColor = Color.White;

                this.metroPanel1.Controls.Add(btn);
                //allButtons.Add(btn);
                allBtns.Add(btn);
                //allBtns1.Add(btn);

                w += 85;
            }

            metroPanel4.Visible = false;
            btnSort.Visible = true;
            btnSort.Enabled = true;

            btnNext.Visible = true;
            btnNext.Enabled = false;
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
                Comparie();
            }
            else if (currentStep == StepsEnum.Success)
            {
                MessageBox.Show("matched");
                btnNext.Enabled = false;
            }
            else if (currentStep == StepsEnum.Failure)
            {
                Failure();
            }

            Speech();
        }

        private void Failure()
        {
            int btnNumber = Int32.Parse(btnCompare.Text);
            int txtNumber = Int32.Parse(txtSearch.Text);

            var delButtons = new List<Button>();

            if (btnNumber > txtNumber)
            {
                for (int k = selectedIndex; k < allBtns.Count; k++)
                {
                    delButtons.Add(allBtns[k]);
                }

                txtAction.Text = btnNumber + " Button Ig Bigger Than Our desired Output" + txtNumber + " , So The Right Button are Deleted as Because The right button is bigger than " + btnNumber;
            }
            else if (btnNumber < txtNumber)
            {
                for (int k = 0; k <= selectedIndex; k++)
                {
                    delButtons.Add(allBtns[k]);
                }

                txtAction.Text = btnNumber + " Button Ig Smaller Than Our desired Output"+ txtNumber+ " , So The Left Button are Deleted as Because The Left button is Smaller than " + btnNumber;
            }

            foreach (var delButton in delButtons)
            {
                allBtns.Remove(delButton);
                delButton.Dispose();
            }

            currentStep = StepsEnum.Selection;
        }

        private void Comparie()
        {
            if (btnCompare.Text == txtSearch.Text)
            {
                btnCompare.BackColor = Color.DarkGreen;
                currentStep = StepsEnum.Success;

                txtAction.Text = btnCompare.Text + " Button is Our Desire Output ";
            }
            else
            {
                btnCompare.BackColor = Color.DarkRed;
                currentStep = StepsEnum.Failure;
                txtAction.Text = btnCompare.Text + " Button is Our Not Desire Output ";
            }
        }

        private void Selection()
        {
            i = allBtns.Count / 2;
            selectedIndex = i;
            allBtns[i].BackColor = Color.DarkBlue;
            btnCompare = allBtns[i];

            txtAction.Text = btnCompare.Text + " Button Is Selected ";

            currentStep = StepsEnum.Comparison;
        }

        private void Start()
        {
            currentStep = StepsEnum.Selection;
            txtAction.Text = " Binary Search Operation is going to Start ";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnfirst = allBtns[m];
            btnSecond = allBtns[n];

            prevX = btnfirst.Location.X;

            btnfirst.BackColor = Color.DarkBlue;
            btnSecond.BackColor = Color.DarkBlue;

            int fnum, snum;
            Int32.TryParse(btnfirst.Text, out fnum);
            Int32.TryParse(btnSecond.Text, out snum);

            if (fnum > snum)
            {
                var temp = allBtns[m];
                allBtns[m] = allBtns[n];
                allBtns[n] = temp;


                if (btnfirst.Location.X == prevX && count <= 5)
                {
                    btnfirst.Location = new Point(btnfirst.Location.X, btnfirst.Location.Y - 5);
                    btnSecond.Location = new Point(btnSecond.Location.X, btnSecond.Location.Y + 5);
                    count++;
                }
                else if (btnSecond.Location.X > prevX)
                {
                    btnfirst.Location = new Point(btnfirst.Location.X + 5, btnfirst.Location.Y);
                    btnSecond.Location = new Point(btnSecond.Location.X - 5, btnSecond.Location.Y);
                }
                else if (btnfirst.Location.X != prevX && count > 1)
                {
                    btnfirst.Location = new Point(btnfirst.Location.X, btnfirst.Location.Y + 5);
                    btnSecond.Location = new Point(btnSecond.Location.X, btnSecond.Location.Y - 5);
                    count--;
                }
                else
                {
                    if(n==allBtns.Count)
                        timer1.Stop();
                    //btnNext.Enabled = true;
                }
            }

            m++;
            n = m + 1;


        }


        private void btnSort_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < allBtns.Count; k++)
            {
                allBtns[k].BackColor = Color.DarkCyan;
            }

            if (currentStep1 == StepsEnum.Start)
            {
                lblStatus.Text = "Started";
                txtAction.Text = "Selection Sort Is Going To Start ";
                currentStep1 = StepsEnum.Selection;
            }
            else if (currentStep1 == StepsEnum.Selection)
            {
                Selection1();
            }
            else if (currentStep1 == StepsEnum.Comparison)
            {
                int f = Int32.Parse(firstButton.Text);
                int s = Int32.Parse(secondButton.Text);

                if (f > s)
                {
                    currentStep1 = StepsEnum.Success;
                    firstButton.BackColor = Color.DarkGreen;
                    secondButton.BackColor = Color.DarkGreen;
                    lblStatus.Text = "Success";

                    txtAction.Text = firstButton.Text + " Is Greater Then  " + secondButton.Text + "\n So It Has Been Sorting ";
                }
                else
                {
                    currentStep1 = StepsEnum.Failure;
                    firstButton.BackColor = Color.DarkRed;
                    secondButton.BackColor = Color.DarkRed;
                    lblStatus.Text = "Failure";

                    txtAction.Text = firstButton.Text + " Is Not Greater Then  " + secondButton.Text + "\n So It Has Not Been Sorting ";
                }
                //txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Comparing ";
            }
            else if (currentStep1 == StepsEnum.Success)
            {
                Button temp = allBtns[i1];
                allBtns[i1] = allBtns[j1];
                allBtns[j1] = temp;
                prevX1 = firstButton.Location.X;
                count1 = 1;
                btnSort.Enabled = false;
                txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Sorting ";
                timer2.Start();
            }
            else if (currentStep1 == StepsEnum.Failure)
            {
                currentStep1 = StepsEnum.Selection;
                Selection1();
            }
            Speech();
        }

        private void Selection1()
        {

            lblStatus.Text = "Selection";

            if (i1 == -1 || j1 == -1)
            {
                i1 = 0;
                j1 = 1;
            }
            else if (i1 == allBtns.Count - 2)
            {
                lblStatus.Text = "Finished";
                btnNext.Enabled = true;
                btnSort.Enabled = false;
            }
            else if (j1 == allBtns.Count - 1)
            {
                i1++;
                j1 = i1 + 1;
            }
            else
            {
                j1++;
            }

            firstButton = allBtns[i1];
            secondButton = allBtns[j1];

            firstButton.BackColor = Color.DarkBlue;
            secondButton.BackColor = Color.DarkBlue;

            txtAction.Text = firstButton.Text + " And " + secondButton.Text + " Button Is Selected ";

            currentStep1 = StepsEnum.Comparison;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (firstButton.Location.X == prevX1 && count1 <= 5)
            {
                firstButton.Location = new Point(firstButton.Location.X, firstButton.Location.Y - 5);
                secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y + 5);
                count1++;
            }
            else if (secondButton.Location.X > prevX1)
            {
                firstButton.Location = new Point(firstButton.Location.X + 5, firstButton.Location.Y);
                secondButton.Location = new Point(secondButton.Location.X - 5, secondButton.Location.Y);
            }
            else if (firstButton.Location.X != prevX1 && count1 > 1)
            {
                firstButton.Location = new Point(firstButton.Location.X, firstButton.Location.Y + 5);
                secondButton.Location = new Point(secondButton.Location.X, secondButton.Location.Y - 5);
                count1--;
            }
            else
            {
                timer2.Stop();
                btnSort.Enabled = true;

                currentStep1 = StepsEnum.Selection;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UserInputManager uim = new UserInputManager(this);
            uim.Show();
            this.Hide();
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if (lbArrayItem.Items.Count < 2)
            {
                MessageBox.Show("Please Insert Value");
                txtAdd.Focus();
                return;
            }
            string number = "";

            foreach (var item in lbArrayItem.Items)
            {
                number += item + ",";
            }

            number = number.Substring(0, number.Length - 1);

            txtAdd.Dispose();
            //lbArrayItem.Dispose();
            btnAdd.Dispose();
            btnDelete.Dispose();
            btnBrows.Dispose();
            btnSaveInput.Dispose();
            btnLoad.Dispose();

            InputTitleName itn = new InputTitleName(this, number);
            itn.Show();
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
    }
}
