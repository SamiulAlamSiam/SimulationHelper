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
using OOP2.SimulationHelper.Data;
using OOp2.SimulationHelper.Framework;
using OOP2.SimulationHelper.Repo;

namespace OOP2.SimulationHelper.WF
{
    public partial class Registration : Form
    {
        UserInfoRepo repo = new UserInfoRepo();

        SpeechSynthesizer sp = new SpeechSynthesizer();

        private List<UserInfo> CurrentDatas = new List<UserInfo>();

        private int ParentID = -1;

        private UserInfo SelectedData =new UserInfo();

        public Registration()
        {
            InitializeComponent();
        }

        public Registration(int parentID)
        {
            this.ParentID = parentID;
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            if (ParentID != -1)
            {
                this.LoadUserInfo();
            }
        }

        private void LoadUserInfo()
        {
            var result = repo.GetAll(LogInHelper.UserProfile.ID + "");
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
                SelectedData = new UserInfo();
            }

            this.populateData();
        }

        private void populateData()
        {
            txtID.Text = SelectedData.ID == 0 ? "Auto Generate " : SelectedData.ID.ToString();
            txtName.Text = SelectedData.Name;
            txtUserName.Text = SelectedData.UserName;
            txtPassword.Text = SelectedData.Password;
            txtCPassword.Text = SelectedData.Password;

            if (SelectedData.UserTypeID == (int)EnumCollection.userType.Admin)
            {
                ddlUserType.Items.Add("Admin");
                ddlUserType.Text = "Admin";
            }
            else if (SelectedData.UserTypeID == (int)EnumCollection.userType.Student)
            {
                ddlUserType.Items.Add("Student");
                ddlUserType.Text = "Student";
            }
            else if (SelectedData.UserTypeID == (int)EnumCollection.userType.Teacher)
            {
                ddlUserType.Items.Add("Teacher");
                ddlUserType.Text = "Teacher";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text == "")
            {
                MessageBox.Show(" Please Insert Name First ");
                txtName.Focus();
                return;
            }

            if (txtUserName.Text == "")
            {
                MessageBox.Show(" Please Insert UserName First ");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show(" Password's Length Should Be Greater or Equal 5 char ");
                txtPassword.Clear();
                txtCPassword.Clear();
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show(" Password & Confirm Password Should Same ");
                txtCPassword.Clear();
                txtCPassword.Focus();
                return;
            }


            if (ddlUserType.Text == "")
            {
                MessageBox.Show(" Choose Student Or Teacher ");
                ddlUserType.Focus();
                return;
            }

            this.Fill();

            bool isNew = SelectedData.ID == 0;

            var result = repo.Save(SelectedData);

            if (isNew)
            {
                SelectedData=new UserInfo();
                CurrentDatas.Add(SelectedData);
            }

            else
            {
                var objToChange = CurrentDatas.FirstOrDefault(c => c.ID == result.Data.ID);

                if (objToChange != null)
                {
                    objToChange.Name = result.Data.Name;
                    objToChange.Password = result.Data.Password;
                    objToChange.UserName = result.Data.UserName;
                    objToChange.UserTypeID = result.Data.UserTypeID;
                }
            }

            SelectedData = result.Data;
            this.populateData();



            string speech = " Successfully Save ";
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female);
            sp.SpeakAsync(speech);

            MessageBox.Show(" Successfully Save ");

            if(isNew)
                txtID.Text = txtName.Text = txtPassword.Text = txtCPassword.Text = txtUserName.Text = "";
        }
        private void Fill()
        {
            SelectedData.Name = txtName.Text;
            SelectedData.UserName = txtUserName.Text;
            SelectedData.Password = txtPassword.Text;

            if (ddlUserType.Text == EnumCollection.userType.Admin.ToString())
                SelectedData.UserTypeID = (int)EnumCollection.userType.Admin;
            else if (ddlUserType.Text == EnumCollection.userType.Student.ToString())
                SelectedData.UserTypeID = (int)EnumCollection.userType.Student;
            else if (ddlUserType.Text == EnumCollection.userType.Teacher.ToString())
                SelectedData.UserTypeID = (int)EnumCollection.userType.Teacher;
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".jpg") || openFileDialog1.FileName.EndsWith(".JPG"))
                {
                    var path = openFileDialog1.FileName;
                    //pictureBox1.ImageLocation = path;
                }
                else
                {
                    MessageBox.Show("Invalid File");
                }
            }
        }
    }
}
