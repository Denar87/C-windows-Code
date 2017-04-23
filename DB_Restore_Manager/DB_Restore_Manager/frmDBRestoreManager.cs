using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Restore_Manager
{
    public partial class frmDBRestoreManager : Form
    {
        public frmDBRestoreManager()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void frmDBRestoreManager_Load(object sender, EventArgs e)
        {
            serverName(".");
        }

        public void serverName(string str)
        {
            con = new SqlConnection("Data Source=" + str + ";Database=Master;data source=.\\sqlexpress; uid=sa; pwd=link320;");
            con.Open();
            cmd = new SqlCommand("select * from sysservers  where srvproduct='SQL Server'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbServer.Items.Add(dr[2]);
            }
            dr.Close();
        }

        public void Createconnection()
        {
            con = new SqlConnection("Data Source=" + (cmbServer.Text) + ";Database=Master;data source=.\\sqlexpress; uid=sa; pwd=link320;");
            con.Open();
            cmbDataBase.Items.Clear();
            cmd = new SqlCommand("select * from sysdatabases", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDataBase.Items.Add(dr[0]);
            }
            dr.Close();
        }

        public void query(string que)
        {
            // ERROR: Not supported in C#: OnErrorStatement
            cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
        }

        public void blank(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbDataBase.Text) | string.IsNullOrEmpty(cmbDataBase.Text))
                {
                    MessageBox.Show("Server Name & Database can not be Blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    if (str == "restore")
                    {
                        openFileDialog1.ShowDialog();
                        //query("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + cmbDataBase.Text + "') DROP DATABASE " + cmbDataBase.Text + " RESTORE DATABASE " + cmbDataBase.Text + " FROM DISK = '" + openFileDialog1.FileName + "'");
                        query(@"USE MASTER RESTORE DATABASE " + cmbDataBase.Text + " FROM DISK ='" + openFileDialog1.FileName + "' WITH REPLACE");
                        BackupProgress.Visible = true;
                        tmrRestore.Enabled = true;
                        //MessageBox.Show("Database Restored Successfully.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Database Restoring Failed.","Data Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Database Restoring Failed."+ error.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            blank("restore"); 
        }

        private void txtServerName_TextChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void tmrRestore_Tick(object sender, EventArgs e)
        {
            try
            {
                BackupProgress.Value = BackupProgress.Value + 5;
                if (BackupProgress.Value == 100)
                {
                    this.BackupProgress.Value = 0;
                    tmrRestore.Stop();
                    BackupProgress.Visible = false;
                    MessageBox.Show("Database Restored Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }   

    }
}
