using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IMS_Win
{
    public partial class BackUpManagerForm : Form
    {
        public BackUpManagerForm()
        {
            InitializeComponent();
        }
        string filename;

        private void tmrBackup_Tick(object sender, EventArgs e)
        {
            try
            {
                BackupProgress.Value = BackupProgress.Value + 5;
                if (BackupProgress.Value == 100)
                {
                    this.BackupProgress.Value = 0;
                    tmrBackup.Stop();
                    BackupProgress.Visible = false;
                    MessageBox.Show("Database Backup Completed Successfully.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //private void tmrRestore_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RestoreProgress.Visible = true;
        //        RestoreProgress.Value = RestoreProgress.Value + 5;

        //        if (RestoreProgress.Value == 100)
        //        {
        //            RestoreProgress.Visible = false;
        //            MessageBox.Show("Database Restored Successfully.", "Express Retail Restore", MessageBoxButtons.OK,MessageBoxIcon.Information);
        //            tmrRestore.Stop();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Express Retail Data Backup(*.bak)|*.bak*";
                dlg.RestoreDirectory = true;
                DialogResult dr = dlg.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    filename = dlg.FileName.ToString();
                    conn obcon = new conn();
                    SqlConnection ob = new SqlConnection(obcon.StrCon);
                    SqlCommand cmd = new SqlCommand("BACKUP DATABASE XpressRetail TO DISK='" + filename + "'", ob);
                    cmd.CommandType = CommandType.Text;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();
                    //MessageBox.Show("Database Has Been Backuped Successfully !", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filename = "";
                    
                    BackupProgress.Visible = true;
                    tmrBackup.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("System Was Unable To Take Backup ! " + error.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Express Retail Data Restore(*.*)|*.*";
                dlg.RestoreDirectory = true;
                dlg.Multiselect = false;
                DialogResult dr = dlg.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    filename = dlg.FileName.ToString();
                    conn obcon = new conn();
                    SqlConnection ob = new SqlConnection(obcon.StrCon);
                    SqlCommand cmd = new SqlCommand(@"RESTORE DATABASE XpressRetail FROM DISK='" + filename + @"' WITH RECOVERY, MOVE 'XpressRetail' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\XpressRetail.mdf', MOVE 'XpressRetail_log' TO 'C:\Proram Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\XpressRetail_log.ldf', REPLACE", ob);
                    cmd.CommandType = CommandType.Text;

                    ob.Open();
                    cmd.ExecuteNonQuery();
                    ob.Close();

                    MessageBox.Show("Database Restored Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filename = "";
                    //tmrRestore.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Database Was Unable To Restore ! " + error.Message.ToString(), "Restore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //private void btnRestore_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OpenFileDialog dlg = new OpenFileDialog();
        //        dlg.Filter = "Express Retail Data Restore(*.*)|*.*";
        //        dlg.RestoreDirectory = true;
        //        dlg.Multiselect = false;
        //        DialogResult dr = dlg.ShowDialog();

        //        if (dr == DialogResult.OK)
        //        {
        //            filename = dlg.FileName.ToString();
        //            conn obcon = new conn();
        //            SqlConnection ob = new SqlConnection(obcon.backupString);
        //            SqlCommand cmd = new SqlCommand("RESTORE DATABASE XpressRetail FROM DISK='" + filename + "'", ob);
        //            cmd.CommandType = CommandType.Text;

        //            ob.Open();
        //            cmd.ExecuteNonQuery();
        //            ob.Close();

        //            MessageBox.Show("Database Has Been Restored Successfully !", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            filename = "";
        //            tmrRestore.Enabled = true;
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show("Database Was Unable To Restore ! " + error.Message.ToString(), "Restore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

    }
}
