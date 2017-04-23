using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Business;
using IMS_Entity;
using Utility;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;

namespace IMS_Win
{
    public partial class DataImport : Form
    {
        //string filepath = null;

        public DataImport()
        {
            InitializeComponent();
        }


        public void importdatafromexcel(string excelfilepath)
        {
            //string excelConnectionString = string.Format(@"Provider=microsoft.jet.oledb.4.0;Data Source={0};Extended Properties=""Excel 8.0 Xml;HDR=YES;""", excelfilepath);

            //// Create Connection to Excel Workbook
            //using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            //{
            //    OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection);

            //    connection.Open();

            //    // Create DbDataReader to Data Worksheet
            //    using (DbDataReader dr = command.ExecuteReader())
            //    {

            //        // SQL Server Connection String
            //        string sqlConnectionString = @"Data Source=denar;Initial Catalog=XpressRetail;user id=sa;password=sa123;Integrated Security=True";

            //        // Bulk Copy to SQL Server
            //        using (SqlBulkCopy bulkCopy =
            //                   new SqlBulkCopy(sqlConnectionString))
            //        {
            //            bulkCopy.DestinationTableName = "tStudent";
            //            bulkCopy.WriteToServer(dr);
            //            MessageBox.Show("The data has been exported successfuly from Excel to SQL");
            //        }
            //    }
            //}


            //declare variables - edit these based on your particular situation
            string ssqltable = "tStudent";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            string myexceldataquery = "select STUDENT,ROLLNO,COURSE from [sheet1$]";
            try
            {
                //create our connection strings
                string sexcelconnectionstring = string.Format("provider=microsoft.jet.oledb.12.0;data source={0};extended properties=excel 12.0;HDR=NO;IMEX=1", excelfilepath);
                string ssqlconnectionstring = "server=denar;user id=sa;password=sa123;database=XpressRetail;connection reset=false";
                //execute a query to erase any previous data from our destination table
                string sclearsql = "delete from " + ssqltable;
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }

                oledbconn.Close();
                MessageBox.Show("Data imorted successfuly");
            }
            catch
            {
                //handle exception
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.4.0;Data Source=C:/Users/Linktechbd/Documents/sheet1.xls;Extended Properties=""Excel 8.0,HDR=Yes;IMEX=1""";

            //using (OleDbConnection connection =
            //             new OleDbConnection(excelConnectionString))
            //{
            //    OleDbCommand command = new OleDbCommand
            //            ("Select * FROM [sheet1$]", connection);

            //    connection.Open();

            //    // Create DbDataReader to Data Worksheet
            //    using (DbDataReader dr = command.ExecuteReader())
            //    {
            //        // SQL Server Connection String
            //        string sqlConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=XpressRetail;user id=sa;password=link320;Integrated Security=True";

            //        // Bulk Copy to SQL Server
            //        using (SqlBulkCopy bulkCopy =
            //                   new SqlBulkCopy(sqlConnectionString))
            //        {
            //            bulkCopy.DestinationTableName = "tStudent";
            //            bulkCopy.WriteToServer(dr);
            //            MessageBox.Show("Data Exoprted To Sql Server Successfully");
            //        }
            //    }

            //}



            importdatafromexcel(txtfilePath.Text);
            //MessageBox.Show("Data Imported Successfully.");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtfilePath.Text = openFileDialog1.FileName;
            }

        }

        //private void btnProccess_Click(object sender, EventArgs e)
        //{
        //    string connetionString = null;
        //    SqlConnection cnn;
        //    connetionString = "Data Source=.\\sqlexpress;Initial Catalog=XpressRetail;user id=sa;password=link320;Integrated Security=SSPI;";
        //    cnn = new SqlConnection(connetionString);
        //    try
        //    {
        //        cnn.Open();
        //        MessageBox.Show("Connection Open ! ");
        //        cnn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Can not open connection ! ");
        //    }
        //}





    }
}
