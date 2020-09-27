namespace OOP2.SimulationHelper.WF
{
    partial class StudentManager
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
            this.lblWelcome = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mbtnLogOut = new MetroFramework.Controls.MetroTile();
            this.mbtnSimulation = new MetroFramework.Controls.MetroTile();
            this.mbtnProfile = new MetroFramework.Controls.MetroTile();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(964, 28);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(84, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "metroLabel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1325, 651);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(199, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1123, 645);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mbtnLogOut);
            this.panel1.Controls.Add(this.mbtnSimulation);
            this.panel1.Controls.Add(this.mbtnProfile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 645);
            this.panel1.TabIndex = 0;
            // 
            // mbtnLogOut
            // 
            this.mbtnLogOut.ActiveControl = null;
            this.mbtnLogOut.Location = new System.Drawing.Point(20, 230);
            this.mbtnLogOut.Name = "mbtnLogOut";
            this.mbtnLogOut.Size = new System.Drawing.Size(153, 59);
            this.mbtnLogOut.TabIndex = 2;
            this.mbtnLogOut.Text = "Log Out";
            this.mbtnLogOut.UseSelectable = true;
            this.mbtnLogOut.Click += new System.EventHandler(this.mbtnLogOut_Click);
            // 
            // mbtnSimulation
            // 
            this.mbtnSimulation.ActiveControl = null;
            this.mbtnSimulation.Location = new System.Drawing.Point(20, 138);
            this.mbtnSimulation.Name = "mbtnSimulation";
            this.mbtnSimulation.Size = new System.Drawing.Size(153, 59);
            this.mbtnSimulation.TabIndex = 1;
            this.mbtnSimulation.Text = "Simulation";
            this.mbtnSimulation.UseSelectable = true;
            this.mbtnSimulation.Click += new System.EventHandler(this.mbtnSimulation_Click);
            // 
            // mbtnProfile
            // 
            this.mbtnProfile.ActiveControl = null;
            this.mbtnProfile.Location = new System.Drawing.Point(20, 40);
            this.mbtnProfile.Name = "mbtnProfile";
            this.mbtnProfile.Size = new System.Drawing.Size(153, 59);
            this.mbtnProfile.TabIndex = 0;
            this.mbtnProfile.Text = "Profile";
            this.mbtnProfile.UseSelectable = true;
            this.mbtnProfile.Click += new System.EventHandler(this.mbtnProfile_Click);
            // 
            // StudentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 731);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentManager";
            this.Text = "StudentManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentManager_FormClosing);
            this.Load += new System.EventHandler(this.StudentManager_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblWelcome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile mbtnLogOut;
        private MetroFramework.Controls.MetroTile mbtnSimulation;
        private MetroFramework.Controls.MetroTile mbtnProfile;
    }
}