namespace OOP2.SimulationHelper.WF
{
    partial class SimulationChooseButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.mbtnLinearSearch = new MetroFramework.Controls.MetroTile();
            this.mbtnBinarySearch = new MetroFramework.Controls.MetroTile();
            this.mbtnInsertionSort = new MetroFramework.Controls.MetroTile();
            this.mbtnBubbleSort = new MetroFramework.Controls.MetroTile();
            this.mbtnSelectionSort = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mbtnLinearSearch);
            this.panel1.Controls.Add(this.mbtnBinarySearch);
            this.panel1.Controls.Add(this.mbtnInsertionSort);
            this.panel1.Controls.Add(this.mbtnBubbleSort);
            this.panel1.Controls.Add(this.mbtnSelectionSort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 640);
            this.panel1.TabIndex = 0;
            // 
            // mbtnLinearSearch
            // 
            this.mbtnLinearSearch.ActiveControl = null;
            this.mbtnLinearSearch.Location = new System.Drawing.Point(494, 297);
            this.mbtnLinearSearch.Name = "mbtnLinearSearch";
            this.mbtnLinearSearch.Size = new System.Drawing.Size(194, 125);
            this.mbtnLinearSearch.TabIndex = 5;
            this.mbtnLinearSearch.Text = "Linear Search";
            this.mbtnLinearSearch.UseSelectable = true;
            this.mbtnLinearSearch.Click += new System.EventHandler(this.mbtnLinearSearch_Click);
            // 
            // mbtnBinarySearch
            // 
            this.mbtnBinarySearch.ActiveControl = null;
            this.mbtnBinarySearch.Location = new System.Drawing.Point(178, 297);
            this.mbtnBinarySearch.Name = "mbtnBinarySearch";
            this.mbtnBinarySearch.Size = new System.Drawing.Size(194, 125);
            this.mbtnBinarySearch.TabIndex = 4;
            this.mbtnBinarySearch.Text = "Binary Search";
            this.mbtnBinarySearch.UseSelectable = true;
            this.mbtnBinarySearch.Click += new System.EventHandler(this.mbtnBinarySearch_Click);
            // 
            // mbtnInsertionSort
            // 
            this.mbtnInsertionSort.ActiveControl = null;
            this.mbtnInsertionSort.Location = new System.Drawing.Point(605, 34);
            this.mbtnInsertionSort.Name = "mbtnInsertionSort";
            this.mbtnInsertionSort.Size = new System.Drawing.Size(194, 125);
            this.mbtnInsertionSort.TabIndex = 2;
            this.mbtnInsertionSort.Text = "Insertion Sort";
            this.mbtnInsertionSort.UseSelectable = true;
            this.mbtnInsertionSort.Click += new System.EventHandler(this.mbtnInsertionSort_Click);
            // 
            // mbtnBubbleSort
            // 
            this.mbtnBubbleSort.ActiveControl = null;
            this.mbtnBubbleSort.Location = new System.Drawing.Point(353, 34);
            this.mbtnBubbleSort.Name = "mbtnBubbleSort";
            this.mbtnBubbleSort.Size = new System.Drawing.Size(194, 125);
            this.mbtnBubbleSort.TabIndex = 1;
            this.mbtnBubbleSort.Text = "Bubble Sort";
            this.mbtnBubbleSort.UseSelectable = true;
            this.mbtnBubbleSort.Click += new System.EventHandler(this.mbtnBubbleSort_Click);
            // 
            // mbtnSelectionSort
            // 
            this.mbtnSelectionSort.ActiveControl = null;
            this.mbtnSelectionSort.Location = new System.Drawing.Point(99, 34);
            this.mbtnSelectionSort.Name = "mbtnSelectionSort";
            this.mbtnSelectionSort.Size = new System.Drawing.Size(194, 125);
            this.mbtnSelectionSort.TabIndex = 0;
            this.mbtnSelectionSort.Text = "Selection Sort";
            this.mbtnSelectionSort.UseSelectable = true;
            this.mbtnSelectionSort.Click += new System.EventHandler(this.mbtnSelectionSort_Click);
            // 
            // SimulationChooseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 640);
            this.Controls.Add(this.panel1);
            this.Name = "SimulationChooseButton";
            this.Text = "SimulationChooseButton";
            this.Load += new System.EventHandler(this.SimulationChooseButton_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile mbtnLinearSearch;
        private MetroFramework.Controls.MetroTile mbtnBinarySearch;
        private MetroFramework.Controls.MetroTile mbtnInsertionSort;
        private MetroFramework.Controls.MetroTile mbtnBubbleSort;
        private MetroFramework.Controls.MetroTile mbtnSelectionSort;
    }
}