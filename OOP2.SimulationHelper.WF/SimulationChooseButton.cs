using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2.SimulationHelper.WF
{
    public partial class SimulationChooseButton : Form
    {
        public SimulationChooseButton()
        {
            InitializeComponent();
        }

        private void SimulationChooseButton_Load(object sender, EventArgs e)
        {

        }

        private void mbtnBubbleSort_Click(object sender, EventArgs e)
        {
            BubbleSort bs=new BubbleSort();
            bs.Show();
            this.Hide();
        }

        private void mbtnSelectionSort_Click(object sender, EventArgs e)
        {
            SelectionSort ss=new SelectionSort();
            ss.Show();
            this.Hide();
        }

        private void mbtnBinarySearch_Click(object sender, EventArgs e)
        {
            BinarySearch bs=new BinarySearch();
            bs.Show();
            this.Hide();
        }

        private void mbtnInsertionSort_Click(object sender, EventArgs e)
        {
            InsertionSort ins = new InsertionSort();
            ins.Show();
            this.Hide();
        }

        private void mbtnLinearSearch_Click(object sender, EventArgs e)
        {
            LinearSearch ls = new LinearSearch();
            ls.Show();
            this.Hide();
        }
    }
}
