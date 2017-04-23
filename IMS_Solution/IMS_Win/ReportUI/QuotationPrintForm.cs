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
    public partial class QuotationPrintForm : Form
    {
        SalesBusiness aSalesBusiness = new SalesBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Tbl_SalesMaster aSaleMaster = new Tbl_SalesMaster();

        public QuotationPrintForm(string voucherId)
        {
            InitializeComponent();
            txtInvoiceNo.Text = voucherId;

        }

        private void GetInvoiceNoToListBox()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DisplayMember = "QuotationMaster_InvoiceNo";
                //listBox1.ValueMember = "SaleMaster_InvoiceNo";
                listBox1.DataSource = aSalesBusiness.GetAllQuotationMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ShowReport()
        {
            Tbl_Company aTbl_Company = aCompanyBusiness.GetAllCompanyByInvoiceType();
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            //List<Qry_SalesInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllQrySalesInvoiceByInvoice(txtInvoiceNo.Text);
            List<Get_SaleInvoiceByQuotation> lstQuotationInvoiceList = aSalesBusiness.GetQuotationByNo(txtInvoiceNo.Text);
            DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_SaleInvoiceByQuotation>(lstQuotationInvoiceList);

            // for A4 size print
            //if (aTbl_Company.Invoice_Type == 1)
            //{
            Reports.CRQuotationInvoice rpt = new Reports.CRQuotationInvoice();
            rpt.Subreports[0].SetDataSource(lstCompanyList);
            rpt.SetDataSource(dt);

            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            ParameterField objParameterField = new ParameterField();

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "@LoggedUser";
            objDiscreteValue.Value = SplashForm.username;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            crystalReportViewer1.ParameterFieldInfo = paramFields;
            crystalReportViewer1.ReportSource = rpt;
            //}

            //// for half of A4 size print
            //else if (aTbl_Company.Invoice_Type == 2)
            //{
            //    Reports.CRSalesInvoice_halfA4 rpt = new Reports.CRSalesInvoice_halfA4();
            //    rpt.Subreports[0].SetDataSource(lstCompanyList);
            //    rpt.SetDataSource(dt);

            //    ParameterFields paramFields = new ParameterFields();
            //    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            //    ParameterField objParameterField = new ParameterField();

            //    objDiscreteValue = new ParameterDiscreteValue();
            //    objParameterField = new ParameterField();
            //    objParameterField.Name = "@LoggedUser";
            //    objDiscreteValue.Value = SplashForm.username;
            //    objParameterField.CurrentValues.Add(objDiscreteValue);
            //    paramFields.Add(objParameterField);

            //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            //    crystalReportViewer1.ReportSource = rpt;
            //}

            //// for half of A4 right size print
            //else if (aTbl_Company.Invoice_Type == 5)
            //{
            //    Reports.CRSalesInvoice_halfA4_right rpt = new Reports.CRSalesInvoice_halfA4_right();
            //    rpt.Subreports[0].SetDataSource(lstCompanyList);
            //    rpt.SetDataSource(dt);

            //    ParameterFields paramFields = new ParameterFields();
            //    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            //    ParameterField objParameterField = new ParameterField();

            //    objDiscreteValue = new ParameterDiscreteValue();
            //    objParameterField = new ParameterField();
            //    objParameterField.Name = "@LoggedUser";
            //    objDiscreteValue.Value = SplashForm.username;
            //    objParameterField.CurrentValues.Add(objDiscreteValue);
            //    paramFields.Add(objParameterField);

            //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            //    crystalReportViewer1.ReportSource = rpt;
            //}

            ////for a4 size invoice with customer due
            //else if (aTbl_Company.Invoice_Type == 3)
            //{
            //    Reports.CRSalesInvoiceWithDue rpt = new Reports.CRSalesInvoiceWithDue();
            //    rpt.Subreports[0].SetDataSource(lstCompanyList);
            //    rpt.SetDataSource(dt);

            //    ParameterFields paramFields = new ParameterFields();
            //    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            //    ParameterField objParameterField = new ParameterField();

            //    objDiscreteValue = new ParameterDiscreteValue();
            //    objParameterField = new ParameterField();
            //    objParameterField.Name = "@LoggedUser";
            //    objDiscreteValue.Value = SplashForm.username;
            //    objParameterField.CurrentValues.Add(objDiscreteValue);
            //    paramFields.Add(objParameterField);

            //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            //    crystalReportViewer1.ReportSource = rpt;
            //}

            ////for half of a4 size invoice with customer due 
            //else if (aTbl_Company.Invoice_Type == 4)
            //{
            //    Reports.CRSalesInvoice_halfA4_WithDue rpt = new Reports.CRSalesInvoice_halfA4_WithDue();
            //    rpt.Subreports[0].SetDataSource(lstCompanyList);
            //    rpt.SetDataSource(dt);

            //    ParameterFields paramFields = new ParameterFields();
            //    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            //    ParameterField objParameterField = new ParameterField();

            //    objDiscreteValue = new ParameterDiscreteValue();
            //    objParameterField = new ParameterField();
            //    objParameterField.Name = "@LoggedUser";
            //    objDiscreteValue.Value = SplashForm.username;
            //    objParameterField.CurrentValues.Add(objDiscreteValue);
            //    paramFields.Add(objParameterField);

            //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            //    crystalReportViewer1.ReportSource = rpt;
            //}

            ////for half of a4 right size invoice with customer due 
            //else if (aTbl_Company.Invoice_Type == 6)
            //{
            //    Reports.CRSalesInvoice_halfA4_WithDue_Right rpt = new Reports.CRSalesInvoice_halfA4_WithDue_Right();
            //    rpt.Subreports[0].SetDataSource(lstCompanyList);
            //    rpt.SetDataSource(dt);

            //    ParameterFields paramFields = new ParameterFields();
            //    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            //    ParameterField objParameterField = new ParameterField();

            //    objDiscreteValue = new ParameterDiscreteValue();
            //    objParameterField = new ParameterField();
            //    objParameterField.Name = "@LoggedUser";
            //    objDiscreteValue.Value = SplashForm.username;
            //    objParameterField.CurrentValues.Add(objDiscreteValue);
            //    paramFields.Add(objParameterField);

            //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            //    crystalReportViewer1.ReportSource = rpt;
            //}

            //// for POS Printer
            //else if (aTbl_Company.Invoice_Type == 0)
            //{
            //    Reports.CRSaleInvoiceForPOS rpt = new Reports.CRSaleInvoiceForPOS();
            //    rpt.SetDataSource(dt);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox1.Visible = true;
            }
        }

        private void txtInvoiceNo_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
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

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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

        private void QuotationPrintForm_Load(object sender, EventArgs e)
        {
            ShowReport();
            GetInvoiceNoToListBox();
            txtInvoiceNo.Focus();
        }


    }
}
