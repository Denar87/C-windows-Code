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
    public partial class SalesChallanForm : Form
    {
        SalesBusiness aSalesBusiness = new SalesBusiness();
        
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Tbl_SalesMaster aSaleMaster = new Tbl_SalesMaster();

        public SalesChallanForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtSaleInvoiceNo.Text == "")
            {
                MessageBox.Show("Enter Sales Invoice No.!", "Warning");
                txtSaleInvoiceNo.Focus();
                return;
            }

            List<Get_SaleInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByInvoice(txtSaleInvoiceNo.Text);
            var row = lstSalesInvoiceList.FirstOrDefault();

            if (lstSalesInvoiceList.Any())
            {
                List<Tbl_SalesChallan> lstTbl_SalesChallan = aSalesBusiness.GetAllSalesChallan().Where(x => x.SaleInvoiceNo == txtSaleInvoiceNo.Text.ToString()).ToList();

                if (lstTbl_SalesChallan.Any())
                {
                    MessageBox.Show("Challan already created for this Invoice No.!", "Warning");
                    txtSaleInvoiceNo.Focus();
                    return;
                }

                Tbl_SalesChallan aTbl_SalesChallan = new Tbl_SalesChallan();
                aTbl_SalesChallan.SaleInvoiceNo = txtSaleInvoiceNo.Text;
                aTbl_SalesChallan.SaleChallanNo = aSalesBusiness.GenerateSaleChallanNo();
                aTbl_SalesChallan.Remarks = "n/a";
                aTbl_SalesChallan.Status = "A";
                aTbl_SalesChallan.AddBy = SplashForm.username;
                aTbl_SalesChallan.AddDate = DateTime.UtcNow.AddHours(6);
                aSalesBusiness.InsertSaleChallan(aTbl_SalesChallan);

                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");

                txtSaleChallanNo.Text = aTbl_SalesChallan.SaleChallanNo;
                lblCustomerInfo.Text = row.Customer_Name + "-" + row.Customer_Code;
            }
            else
            {
                MessageBox.Show("Invoice No. not found!", "Warning");
                txtSaleInvoiceNo.Focus();
            }
        }

        void ShowReport()
        {
            Tbl_Company aTbl_Company = aCompanyBusiness.GetAllCompanyByInvoiceType();
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            List<Get_SaleInvoiceByChallan> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByChallan(txtSaleInvoiceNo.Text, txtSaleChallanNo.Text);
            DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_SaleInvoiceByChallan>(lstSalesInvoiceList);
            ReportViewerForm frm = new ReportViewerForm();

            // for A4 size print
            //if (aTbl_Company.Invoice_Type == 1)
            //{
                Reports.CRSalesInvoicewithChallan rpt = new Reports.CRSalesInvoicewithChallan();
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

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            //}

            // for half of A4 size print
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (txtSaleInvoiceNo.Text == "")
            {
                MessageBox.Show("Enter Sales Invoice No.!", "Warning");
                txtSaleInvoiceNo.Focus();
                return;
            }

            if (txtSaleChallanNo.Text == "")
            {
                MessageBox.Show("Enter Sales Challan No.!", "Warning");
                txtSaleChallanNo.Focus();
                return;
            }

            List<Get_SaleInvoiceByChallan> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByChallan(txtSaleInvoiceNo.Text, txtSaleChallanNo.Text);
            var row = lstSalesInvoiceList.FirstOrDefault();

            if (lstSalesInvoiceList.Count > 0)
            {
                lblCustomerInfo.Text = row.Customer_Name + "-" + row.Customer_Code;

                ShowReport();
            }
            else
            {
                MessageBox.Show("No Data Found!", "Warning");
            }

        }

        private void SalesChallanForm_Load(object sender, EventArgs e)
        {
            txtSaleChallanNo.Text = aSalesBusiness.GenerateSaleChallanNo();
        }

    }
}
