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
using CrystalDecisions.Shared;

namespace IMS_Win
{
    public partial class PurchaseInvoiceReportForm : Form
    {
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        public PurchaseInvoiceReportForm(string voucherId)
        {
            InitializeComponent();
            txtInvoiceNo.Text = voucherId;
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                List<Qry_PurchaseInvoice> lstPurchaseInvoiceList = aPurchaseBusiness.GetAllQryPurchaseInvoiceByInvoice(txtInvoiceNo.Text);
                Reports.CRPurchaseInvoice rpt = new Reports.CRPurchaseInvoice();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(lstPurchaseInvoiceList);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "TotalInWord";
                objDiscreteValue.Value = AmountFormatBusiness.GetTakaInWords(lstPurchaseInvoiceList[0].PurchaseMaster_TotalAmount, "", "") + " Only";
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }
            catch
            {
            }
        }

        private void PurchaseInvoiceReportForm_Load(object sender, EventArgs e)
        {
            ShowReport();
            GetInvoiceNoToListBox();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void txtInvoiceNo_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listBox1.Visible = true;
                listBox1.Focus();
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox1.Visible = true;
            }
        }
        private void GetInvoiceNoToListBox()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DisplayMember = "PurchaseMaster_InvoiceNo";
                //listBox1.ValueMember = "SaleMaster_InvoiceNo";
                listBox1.DataSource = aPurchaseBusiness.GetAllPurchaseMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceNo.Text = listBox1.Text.ToString();
                listBox1.Visible = false;
                btnShow.Focus();
            }
            catch
            {
                MessageBox.Show("Please Select any Invoice!");
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtInvoiceNo.Text = listBox1.Text.ToString();
                listBox1.Visible = false;
                btnShow.Focus();
            }
            catch
            {
                MessageBox.Show("Please Select any Invoice!");
            }
        }
        
    }
}
