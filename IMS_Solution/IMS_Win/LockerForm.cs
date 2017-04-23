using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Business;
using Utility;
using IMS_Entity;

namespace IMS_Win
{
    public partial class LockerForm : Form
    {
        UserBusiness aUserBusiness = new UserBusiness();
        public LockerForm()
        {
            InitializeComponent();
        }

        void Unlock_System()
        {
            string msg = aUserBusiness.ValidateLockIn(SplashForm.username, CryptographyManager.Encrypt("abcd",txtPassword.Text));
            if (msg != string.Empty)
            {
                UtilityBusiness.DisplayAlertMessage('W', msg);
                txtPassword.Text = "";
                return;
            }
            Tbl_User aTbl_User = aUserBusiness.GetAllUser(SplashForm.username, CryptographyManager.Encrypt("abcd", txtPassword.Text));
            if (aTbl_User != null)
            {
                MainForm frm = new MainForm(SplashForm.username);
                frm.Show();
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            Unlock_System();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Unlock_System();
            }
        }
    }
}
