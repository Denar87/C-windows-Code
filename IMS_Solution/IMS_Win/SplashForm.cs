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
using System.Net.Mail;

namespace IMS_Win
{
    public partial class SplashForm : Form
    {
        UserBusiness aUserBusiness = new UserBusiness();
        Tbl_System aTbl_System = new Tbl_System();
        public SplashForm()
        {
            InitializeComponent();
        }

        public static string username = "";

        private void SplashForm_Load(object sender, EventArgs e)
        {
            lblUserID.Visible = false;
            lblPassword.Visible = false;
            txtUserID.Visible = false;
            txtPassword.Visible = false;
            vistaBtnExit.Visible = false;
            
            btnLogin.Visible = false;
            if (verifyLicence())
            {
                splashProgressBar.Visible = true;
                bgw.RunWorkerAsync();
            }


        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            bgw.ReportProgress(5);
            Thread.Sleep(200);
            bgw.ReportProgress(10);
            Thread.Sleep(200);
            bgw.ReportProgress(15);
            Thread.Sleep(200);
            bgw.ReportProgress(20);
            Thread.Sleep(200);
            bgw.ReportProgress(25);
            Thread.Sleep(200);
            bgw.ReportProgress(30);
            Thread.Sleep(200);
            bgw.ReportProgress(35);
            Thread.Sleep(200);
            bgw.ReportProgress(40);

            Thread.Sleep(200);

            bgw.ReportProgress(45);
            Thread.Sleep(200);
            bgw.ReportProgress(50);
            Thread.Sleep(200);
            bgw.ReportProgress(55);
            Thread.Sleep(200);
            bgw.ReportProgress(60);
            Thread.Sleep(200);
            bgw.ReportProgress(65);
            Thread.Sleep(200);
            bgw.ReportProgress(70);
            Thread.Sleep(300);
            bgw.ReportProgress(80);
            Thread.Sleep(300);
            bgw.ReportProgress(90);
            Thread.Sleep(600);
            bgw.ReportProgress(100);
            Thread.Sleep(200);
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            splashProgressBar.Value = e.ProgressPercentage;
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblUserID.Visible = true;
            lblPassword.Visible = true;
            txtUserID.Visible = true;
            txtPassword.Visible = true;
            vistaBtnExit.Visible = true;
            btnLogin.Visible = true;
            
            txtUserID.Focus();
            splashProgressBar.Visible = false;
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
                MessageBox.Show("Invalid Licence Key", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string msg = aUserBusiness.ValidateLogIn(txtUserID.Text, CryptographyManager.Encrypt("abcd", txtPassword.Text));
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                Tbl_User aTbl_User = aUserBusiness.GetAllUser(txtUserID.Text, CryptographyManager.Encrypt("abcd", txtPassword.Text));

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

        bool verifyLicence()
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
            if (lstLicenceListTemp.Any())
            {
                DateTime endDate = lstLicenceListTemp.FirstOrDefault().Licence_EndDate;

                if (endDate < DateTime.UtcNow.AddHours(6).Date)
                {
                    if (MessageBox.Show("Licence Expired! If You Want To Renew Your Licence Please Contact With Provider", "Licence", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lblUserID.Visible = false;
                        lblPassword.Visible = false;
                        txtUserID.Visible = false;
                        txtPassword.Visible = false;
                        vistaBtnExit.Visible = false;
                        
                        btnLogin.Visible = false;
                        splashProgressBar.Visible = false;
                        lblProductKey.Visible = true;
                        txtKey.Visible = true;
                        btnGo.Visible = true;
                        lblActivationContact.Visible = true;
                        return false;
                    }
                    else
                    {
                        lblUserID.Visible = false;
                        lblPassword.Visible = false;
                        txtUserID.Visible = false;
                        txtPassword.Visible = false;
                        vistaBtnExit.Visible = false;
                        btnLogin.Visible = false;
                        
                        splashProgressBar.Visible = false;
                        lblProductKey.Visible = true;
                        txtKey.Visible = true;
                        btnGo.Visible = true;
                        lblActivationContact.Visible = true;
                        return false;
                    }
                }
                else
                {
                    if (DateTime.UtcNow.AddHours(6).Date.Month == endDate.Date.Month && DateTime.UtcNow.AddHours(6).Date.Year == endDate.Date.Year)
                    {
                        int totaldays = Convert.ToInt32((endDate.Date - DateTime.UtcNow.AddHours(6).Date).TotalDays);

                        if (MessageBox.Show("Your Licence Will Be Expired In " + totaldays + " Days, If You Want To Renew Your Licence Please Contact With Provider", "Licence", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lblUserID.Visible = false;
                            lblPassword.Visible = false;
                            txtUserID.Visible = false;
                            txtPassword.Visible = false;
                            vistaBtnExit.Visible = false;
                            btnLogin.Visible = false;
                            
                            splashProgressBar.Visible = false;
                            lblProductKey.Visible = true;
                            txtKey.Visible = true;
                            btnGo.Visible = true;
                            lblActivationContact.Visible = true;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                lblUserID.Visible = false;
                lblPassword.Visible = false;
                txtUserID.Visible = false;
                txtPassword.Visible = false;
                vistaBtnExit.Visible = false;
                btnLogin.Visible = false;
                
                splashProgressBar.Visible = false;
                lblProductKey.Visible = true;
                txtKey.Visible = true;
                btnGo.Visible = true;
                lblActivationContact.Visible = true;
                return false;
            }
        }

        bool checkurl(string url)
        {
            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://www.linktechbd.com/expressretail/" + txtKey.Text + ".html";
                if (checkurl(url))
                {
                    List<Tbl_System> lstLicenceList = aUserBusiness.getLicence();
                    if (lstLicenceList.Any())
                    {
                        lstLicenceList.FirstOrDefault().Licence_Key = CryptographyManager.Encrypt("abcd", txtKey.Text);
                        lstLicenceList.FirstOrDefault().Licence_StartDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.ToString());
                        lstLicenceList.FirstOrDefault().Licence_EndDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.AddYears(1).ToString());
                        lstLicenceList.FirstOrDefault().Licence_NoticeDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.AddYears(1).AddDays(-15).ToString());
                        aUserBusiness.UpdateLicence(lstLicenceList.FirstOrDefault());

                        //sending mail to provider
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("shopmanagerbd@gmail.com", "a74747474");
                        MailMessage mm = new MailMessage("mail@linktechbd.com", "mozammel.hrm@gmail.com", "Renew Activation", "Renewal proccess of Express Retail is successful." + Environment.NewLine + "Activation Code : " + txtKey.Text + Environment.NewLine + "Host Name : " + Dns.GetHostName());
                        mm.BodyEncoding = UTF8Encoding.UTF8;
                        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        client.Send(mm);
                        //

                        lblProductKey.Visible = false;
                        txtKey.Visible = false;
                        btnGo.Visible = false;

                        MessageBox.Show("Congratulation! Renewal Proccess Successful For 365 Days", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        splashProgressBar.Visible = true;
                        bgw.RunWorkerAsync();
                    }
                    else
                    {
                        Tbl_System aTbl_System = new Tbl_System();
                        aTbl_System.Licence_Key = CryptographyManager.Encrypt("abcd", txtKey.Text);
                        aTbl_System.Licence_StartDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.ToString());
                        aTbl_System.Licence_EndDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.AddYears(1).ToString());
                        aTbl_System.Licence_NoticeDate = UtilityBusiness.Base64Encode(DateTime.UtcNow.AddHours(6).Date.AddYears(1).AddDays(-15).ToString());
                        aUserBusiness.InsertLicence(aTbl_System);

                        //sending mail to provider
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("shopmanagerbd@gmail.com", "a74747474");
                        MailMessage mm = new MailMessage("mail@linktechbd.com", "mozammel.hrm@gmail.com", "New Activation", "New Activation Proccess of Express Retail is successful." + Environment.NewLine + "Activation Code : " + txtKey.Text + Environment.NewLine + "Host Name : " + Dns.GetHostName());
                        mm.BodyEncoding = UTF8Encoding.UTF8;
                        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        client.Send(mm);
                        //

                        MessageBox.Show("Congratulation! Activation Successful For 365 Days", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        splashProgressBar.Visible = true;
                        bgw.RunWorkerAsync();

                        lblProductKey.Visible = false;
                        txtKey.Visible = false;
                        btnGo.Visible = false;
                        lblActivationContact.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Licence Key", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblUserID.Visible = false;
                    lblPassword.Visible = false;
                    txtUserID.Visible = false;
                    txtPassword.Visible = false;
                    vistaBtnExit.Visible = false;
                    btnLogin.Visible = false;
                    
                    splashProgressBar.Visible = false;
                    lblProductKey.Visible = true;
                    txtKey.Visible = true;
                    btnGo.Visible = true;
                    lblActivationContact.Visible = true;
                }
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.linktechbd.com");
        }



    }
}
