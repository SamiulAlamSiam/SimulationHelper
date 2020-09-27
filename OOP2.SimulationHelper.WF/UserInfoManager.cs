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
using System.Speech;
using System.Speech.Synthesis;

namespace OOP2.SimulationHelper.WF
{
    public partial class UserInfoManager : Form
    {
        SpeechSynthesizer sp = new SpeechSynthesizer();

        UserInfoRepo repo = new UserInfoRepo();

        private List<UserInfo> CurrentDatas = new List<UserInfo>();

        private UserInfo SelectedData { get; set; }

        public UserInfoManager()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            ddlUserType.Items.Add("Admin");
            ddlUserType.Items.Add("Student");
            ddlUserType.Items.Add("Teacher");
            //SimulationHelperContext context=new SimulationHelperContext();
            //dgvUserInfo.DataSource = repo.GetAll("");
            //dgvUserInfo.DataSource = context.UserInfoes;
            try
            {
                this.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Init()
        {
            txtSearch.Text = "";
            this.LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            var result = repo.GetAll(txtSearch.Text);

            if (result.HasError == true)
            {
                MetroFramework.MetroMessageBox.Show(this, result.Message);
                return;
            }

            CurrentDatas = result.Data.ToList();
            


            if (CurrentDatas.Count > 0)
                SelectedData = CurrentDatas[0];
            else
                SelectedData=new UserInfo();

            this.PopulateData();
            this.RefreshDGV();

        }

        private void PopulateData()
        {
            TxtID.Text = SelectedData.ID == 0 ? "Auto Generate " : SelectedData.ID.ToString();
            txtName.Text = SelectedData.Name;
            txtUserName.Text = SelectedData.UserName;
            txtPassword.Text = SelectedData.Password;

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

        private void RefreshDGV()
        {
            dgvUserInfo.AutoGenerateColumns = false;
            dgvUserInfo.DataSource = CurrentDatas.ToList();           
            dgvUserInfo.Refresh();
        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void New()
        {
            dgvUserInfo.ClearSelection();
            //ddlUserType.Items.Remove("Admin");
            SelectedData = new UserInfo();
            this.PopulateData();
        }

        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Int32.Parse(dgvUserInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
                SelectedData = CurrentDatas.FirstOrDefault(c => c.ID == id) ?? new UserInfo();
                this.PopulateData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadUserInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedData.ID == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Selected a Row First ");
                return;
            }

            if(SelectedData.UserTypeID == (int)EnumCollection.userType.Admin && SelectedData.UserTypeID!=LogInHelper.UserProfile.ID)
            {
                MetroFramework.MetroMessageBox.Show(this, " Sorry Admin Can Not Be Delete ");
                return;
            }

            if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var result = repo.Delete(SelectedData.ID);

            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }

            CurrentDatas.Remove(SelectedData);

            this.New();
            this.RefreshDGV();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Fill();

            bool isNew = SelectedData.ID == 0;

            var result = repo.Save(SelectedData);

            if (result.HasError)
            {
                MessageBox.Show(result.Message);
                return;
            }

            if (isNew == true)
            {
                CurrentDatas.Add(SelectedData);
            }
            else
            {
                var objToChange = CurrentDatas.FirstOrDefault(c => c.ID == result.Data.ID);

                if (objToChange != null)
                {
                    objToChange.Name = result.Data.Name;
                    objToChange.Password = result.Data.Password;
                    objToChange.UserName = result.Data.Password;
                    objToChange.UserTypeID = result.Data.UserTypeID;
                }
            }

            SelectedData = result.Data;
            this.PopulateData();
            this.RefreshDGV();

            

            string speech = " Successfully Save ";
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female);
            sp.SpeakAsync(speech);

            MessageBox.Show(" Successfully Save ");
        }

        private void Fill()
        { 
            SelectedData.Name = txtName.Text;
            SelectedData.Password = txtPassword.Text;
            SelectedData.UserName = txtUserName.Text;

            if (ddlUserType.Text == EnumCollection.userType.Admin.ToString())
                SelectedData.UserTypeID = (int) EnumCollection.userType.Admin;
            else if (ddlUserType.Text == EnumCollection.userType.Student.ToString())
                SelectedData.UserTypeID = (int)EnumCollection.userType.Student;
            else if (ddlUserType.Text == EnumCollection.userType.Teacher.ToString())
                SelectedData.UserTypeID = (int)EnumCollection.userType.Teacher;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            this.LoadUserInfo();
        }
    }
}
