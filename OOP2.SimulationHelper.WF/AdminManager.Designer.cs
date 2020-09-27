namespace OOP2.SimulationHelper.WF
{
    partial class AdminManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mbtnUsers = new MetroFramework.Controls.MetroTile();
            this.mbtnLogOut = new MetroFramework.Controls.MetroTile();
            this.mbtnSimulation = new MetroFramework.Controls.MetroTile();
            this.mbtnProfile = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(785, 29);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(84, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "metroLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 631);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.9409F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.0591F));
            this.tableLayoutPanel1.Controls.Add(this.metroPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1318, 631);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(213, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1102, 625);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.mbtnUsers);
            this.metroPanel1.Controls.Add(this.mbtnLogOut);
            this.metroPanel1.Controls.Add(this.mbtnSimulation);
            this.metroPanel1.Controls.Add(this.mbtnProfile);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(204, 625);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mbtnUsers
            // 
            this.mbtnUsers.ActiveControl = null;
            this.mbtnUsers.Location = new System.Drawing.Point(24, 201);
            this.mbtnUsers.Name = "mbtnUsers";
            this.mbtnUsers.Size = new System.Drawing.Size(153, 58);
            this.mbtnUsers.TabIndex = 6;
            this.mbtnUsers.Text = "Users";
            this.mbtnUsers.UseSelectable = true;
            this.mbtnUsers.Click += new System.EventHandler(this.mbtnUsers_Click);
            // 
            // mbtnLogOut
            // 
            this.mbtnLogOut.ActiveControl = null;
            this.mbtnLogOut.Location = new System.Drawing.Point(24, 307);
            this.mbtnLogOut.Name = "mbtnLogOut";
            this.mbtnLogOut.Size = new System.Drawing.Size(153, 59);
            this.mbtnLogOut.TabIndex = 5;
            this.mbtnLogOut.Text = "Log Out";
            this.mbtnLogOut.UseSelectable = true;
            this.mbtnLogOut.Click += new System.EventHandler(this.mbtnLogOut_Click);
            // 
            // mbtnSimulation
            // 
            this.mbtnSimulation.ActiveControl = null;
            this.mbtnSimulation.Location = new System.Drawing.Point(24, 113);
            this.mbtnSimulation.Name = "mbtnSimulation";
            this.mbtnSimulation.Size = new System.Drawing.Size(153, 59);
            this.mbtnSimulation.TabIndex = 4;
            this.mbtnSimulation.Text = "Simulation";
            this.mbtnSimulation.UseSelectable = true;
            this.mbtnSimulation.Click += new System.EventHandler(this.mbtnSimulation_Click);
            // 
            // mbtnProfile
            // 
            this.mbtnProfile.ActiveControl = null;
            this.mbtnProfile.Location = new System.Drawing.Point(24, 15);
            this.mbtnProfile.Name = "mbtnProfile";
            this.mbtnProfile.Size = new System.Drawing.Size(153, 59);
            this.mbtnProfile.TabIndex = 3;
            this.mbtnProfile.Text = "Profile";
            this.mbtnProfile.UseSelectable = true;
            this.mbtnProfile.Click += new System.EventHandler(this.mbtnProfile_Click_1);
            // 
            // AdminManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 711);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Name = "AdminManager";
            this.Text = "AdminManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminManager_FormClosing);
            this.Load += new System.EventHandler(this.AdminManager_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mbtnUsers;
        private MetroFramework.Controls.MetroTile mbtnLogOut;
        private MetroFramework.Controls.MetroTile mbtnSimulation;
        private MetroFramework.Controls.MetroTile mbtnProfile;
    }
}