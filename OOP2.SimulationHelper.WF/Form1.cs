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


namespace OOP2.SimulationHelper.WF
{
    public partial class LOgInManager : Form
    {
        public LOgInManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            SimulationHelperContext context = new SimulationHelperContext();

            var obj = context.UserInfoes.FirstOrDefault(u => u.UserName.Equals(txtUserName.Text) && u.Password.Equals(txtPassword.Text));
            if (obj == null)
            {
                MetroFramework.MetroMessageBox.Show(this, " Invalid UserName or Password ");
                txtPassword.Focus();
                return;
            }

            var op = new UserProfile()
            {
                ID = obj.ID,
                Name = obj.Name,
                UserName = obj.UserName,
                UserTypeID = obj.UserTypeID
            };

            LogInHelper.UserProfile = op;

            //MetroFramework.MetroMessageBox.Show(this, " Valid UserName or Password ");
            if (obj.UserTypeID == (int) EnumCollection.userType.Admin)
            {
                AdminManager am = new AdminManager();
                am.Show();
            }
            else if (obj.UserTypeID == (int)EnumCollection.userType.Student)
            {
                StudentManager sm = new StudentManager();
                sm.Show();
            }
            this.Hide();

        }

        private void LOgInManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Home h=new Home();
            h.Show();
        }
    }
}
