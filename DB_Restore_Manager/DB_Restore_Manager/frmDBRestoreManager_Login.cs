using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace DB_Restore_Manager
{
    public partial class frmDBRestoreManager_Login : Form
    {
        public frmDBRestoreManager_Login()
        {
            InitializeComponent();
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

        private void btn_restoreLogin_Click(object sender, EventArgs e)
        {
            string url = "http://www.linktechbd.com/expressretail_re/" + txtRestorepassword.Text + ".html";
            if (checkurl(url))
            {
                frmDBRestoreManager frm = new frmDBRestoreManager();
                frm.Show();
                this.ShowInTaskbar = false;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRestorepassword.Focus();
            }
        }

        

    }
}
