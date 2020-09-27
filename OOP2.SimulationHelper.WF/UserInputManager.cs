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
    public partial class UserInputManager : MetroFramework.Forms.MetroForm
    {
        UserInputRepo repo = new UserInputRepo();
        private string[] splitString;

        private object Parent;

        private List<UserInput> CurrentDatas = new List<UserInput>();

        private List<int> finalInputs = new List<int>(); 

        int[] inp = new int[6];

        private UserInput SelectedData { get; set; }

        public UserInputManager()
        {
            InitializeComponent();
        }

        public UserInputManager(object parent)
        {
            this.Parent = parent;
            
            InitializeComponent();
        }

        private void UserInputManager_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            this.loaadUserInput();
        }

        private void loaadUserInput()
        {
            var result = repo.GetAll();

            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }

            CurrentDatas = result.Data.ToList();

            if (CurrentDatas.Count > 0)
            {
                SelectedData = CurrentDatas[0];
            }
            else
            {
                SelectedData = new UserInput();
            }

            RefreshDGV();
        }

        private void RefreshDGV()
        {
            dgvUserInput.AutoGenerateColumns = false;
            dgvUserInput.DataSource = CurrentDatas.ToList();
            dgvUserInput.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var inputs = SelectedData.Inputs;


            splitString = inputs.Split(',');

            foreach (var s in splitString)
                finalInputs.Add(Int32.Parse(s));

            if (Parent.GetType().Equals(typeof(SelectionSort)))
            {
                SelectionSort ss = new SelectionSort(finalInputs);

                ss.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof (BubbleSort)))
            {
                BubbleSort bs = new BubbleSort(finalInputs);
                bs.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(InsertionSort)))
            {
                InsertionSort ins = new InsertionSort(finalInputs);
                ins.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(BinarySearch)))
            {
                BinarySearch bns = new BinarySearch(finalInputs);
                bns.Show();
                this.Hide();
            }

            else if (Parent.GetType().Equals(typeof(LinearSearch)))
            {
                LinearSearch bns = new LinearSearch(finalInputs);
                bns.Show();
                this.Hide();
            }
        }

        private void dgvUserInput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvUserInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //int id = Int32.Parse(dgvUserInput.Rows[e.RowIndex].Cells[0].Value.ToString());
                //SelectedData = CurrentDatas.FirstOrDefault(c => c.ID == id) ?? new UserInput();
               // this.PopulateData();

                SelectedData = CurrentDatas[e.RowIndex];
            }
        }
    }
}
