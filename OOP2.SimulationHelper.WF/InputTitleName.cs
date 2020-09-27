using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP2.SimulationHelper.Data;
using OOp2.SimulationHelper.Framework;
using OOP2.SimulationHelper.Repo;

namespace OOP2.SimulationHelper.WF
{
    public partial class InputTitleName : MetroFramework.Forms.MetroForm
    {
        UserInputRepo repo = new UserInputRepo();
        private List<int> finalInputs = new List<int>(); 
        private object Parent;
        private string Number;
        public InputTitleName()
        {
            InitializeComponent();
        }

        public InputTitleName(object parent,string number)
        {
            this.Parent = parent;
            this.Number = number;
            InitializeComponent();
        }

        public InputTitleName(object parent)
        {
            this.Parent = parent;
            InitializeComponent();
        }

        private void InputTitleName_Load(object sender, EventArgs e)
        {

        }

        public string TitleName()
        {
            return txtTitleName.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var userInput = new UserInput();

            if (txtTitleName.Text == "")
            {
                MessageBox.Show(" Please Set A Name First ");
                txtTitleName.Focus();
                return;
            }

            userInput.Title = txtTitleName.Text;
            userInput.UserID = LogInHelper.UserProfile.ID;

            //string number = "";

            //foreach (var item in lbArrayItem.Items)
            //{
            //    number += item + ",";
            //}

            //number = number.Substring(0, number.Length - 1);

            userInput.Inputs = Number;

            var result = repo.Save(userInput);

            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }

            MessageBox.Show(" Successfully Saved Your Inputs ");

            if (Parent.GetType().Equals(typeof(SelectionSort)))
            {
                SelectionSort ss = new SelectionSort(txtTitleName.Text);
                ss.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(BubbleSort)))
            {
                BubbleSort bs = new BubbleSort(txtTitleName.Text);
                bs.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(InsertionSort)))
            {
                InsertionSort ins = new InsertionSort(txtTitleName.Text);
                ins.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(BinarySearch)))
            {
                BinarySearch bns = new BinarySearch(txtTitleName.Text);
                bns.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(LinearSearch)))
            {
                LinearSearch bns = new LinearSearch(txtTitleName.Text);
                bns.Show();
                this.Hide();
            }
        }
    }
}
