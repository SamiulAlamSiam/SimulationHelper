namespace OOP2.SimulationHelper.WF
{
    partial class InputTitleName
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
            this.txtTitleName = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtTitleName
            // 
            // 
            // 
            // 
            this.txtTitleName.CustomButton.Image = null;
            this.txtTitleName.CustomButton.Location = new System.Drawing.Point(323, 2);
            this.txtTitleName.CustomButton.Name = "";
            this.txtTitleName.CustomButton.Size = new System.Drawing.Size(47, 47);
            this.txtTitleName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTitleName.CustomButton.TabIndex = 1;
            this.txtTitleName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTitleName.CustomButton.UseSelectable = true;
            this.txtTitleName.CustomButton.Visible = false;
            this.txtTitleName.Lines = new string[0];
            this.txtTitleName.Location = new System.Drawing.Point(174, 82);
            this.txtTitleName.MaxLength = 32767;
            this.txtTitleName.Multiline = true;
            this.txtTitleName.Name = "txtTitleName";
            this.txtTitleName.PasswordChar = '\0';
            this.txtTitleName.PromptText = "Title Name";
            this.txtTitleName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTitleName.SelectedText = "";
            this.txtTitleName.SelectionLength = 0;
            this.txtTitleName.SelectionStart = 0;
            this.txtTitleName.ShortcutsEnabled = true;
            this.txtTitleName.Size = new System.Drawing.Size(373, 52);
            this.txtTitleName.TabIndex = 1;
            this.txtTitleName.UseSelectable = true;
            this.txtTitleName.WaterMark = "Title Name";
            this.txtTitleName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTitleName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(68, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title :";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(347, 189);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(154, 37);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseSelectable = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // InputTitleName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 265);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitleName);
            this.Name = "InputTitleName";
            this.Text = "InputTitleName";
            this.Load += new System.EventHandler(this.InputTitleName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtTitleName;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btnOK;
    }
}