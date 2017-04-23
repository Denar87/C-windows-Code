using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using IMS_Business;
using IMS_Entity;
using Utility;
using System.Net;
using System.IO;
namespace IMS_Win
{
    public partial class LogInForm : Form
    {
        UserBusiness aUserBusiness = new UserBusiness();
        public LogInForm()
        {
            InitializeComponent();
        }

        public static string username = "";
        
        private void SplashForm_Load(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }

        void login()
        {
            List<Tbl_System> lstLicenceList = aUserBusiness.getLicence();

            //encrypting date
            List<Tbl_SystemTemp> lstLicenceListTemp = new List<Tbl_SystemTemp>();
            foreach (var licence in lstLicenceList)
            {
                Tbl_SystemTemp aTbl_SystemTemp = new Tbl_SystemTemp();
                aTbl_SystemTemp.Licence_SlNo = licence.Licence_SlNo;
                aTbl_SystemTemp.Licence_Key = licence.Licence_Key;
                aTbl_SystemTemp.Licence_StartDate = Convert.ToDateTime(UtilityBusiness.Base64Decode(licence.Licence_StartDate));
                aTbl_SystemTemp.Licence_EndDate = Convert.ToDateTime(UtilityBusiness.Base64Decode(licence.Licence_EndDate));
                aTbl_SystemTemp.Licence_NoticeDate = Convert.ToDateTime(UtilityBusiness.Base64Decode(licence.Licence_NoticeDate));
                lstLicenceListTemp.Add(aTbl_SystemTemp);
            }
            //
            DateTime startDate = lstLicenceListTemp.FirstOrDefault().Licence_StartDate;

            if (startDate > DateTime.UtcNow.AddHours(6).Date)
            {
                MessageBox.Show("Invalid License!");
            }
            else
            {
                string msg = aUserBusiness.ValidateLogIn(txtUserID.Text, CryptographyManager.Encrypt("abcd",txtPassword.Text));
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                Tbl_User aTbl_User = aUserBusiness.GetAllUser(txtUserID.Text, CryptographyManager.Encrypt("abcd",txtPassword.Text));
                if (aTbl_User != null)
                {
                    if (txtUserID.Text != aTbl_User.User_ID)
                    {
                        MessageBox.Show("Invalid User Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserID.Focus();
                        return;
                    }

                    //if (txtPassword.Text != aTbl_User.User_Password)
                    //{
                    //    MessageBox.Show("Invalid Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtPassword.Focus();
                    //    return;
                    //}

                    //if (txtUserID.Text != aTbl_User.User_ID && txtPassword.Text == aTbl_User.User_Password)
                    //{
                    //    MessageBox.Show("Invalid User Id & Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtUserID.Focus();
                    //    return;
                    //}

                    username = txtUserID.Text;
                    MainForm frm = new MainForm(txtUserID.Text);
                    frm.Show();
                    this.ShowInTaskbar = false;
                    this.Hide();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();     
        }

        private void vistaBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUserID.Focus();
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtPassword.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.linktechbd.com");
        }
    }
}
