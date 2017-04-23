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
    public partial class SalesInvoiceForm : Form
    {
        SalesBusiness aSalesBusiness = new SalesBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Tbl_SalesMaster aSaleMaster = new Tbl_SalesMaster();

        public SalesInvoiceForm(string voucherId)
        {
            InitializeComponent();
            txtInvoiceNo.Text = voucherId;

        }
        
        void ShowReport()
        {
            Tbl_Company aTbl_Company = aCompanyBusiness.GetAllCompanyByInvoiceType();
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            //List<Qry_SalesInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllQrySalesInvoiceByInvoice(txtInvoiceNo.Text);
            List<Get_SaleInvoice_1> lstSalesInvoiceList_1 = aSalesBusiness.GetAllSalesInvoiceByInvoice_1(txtInvoiceNo.Text);
            DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_SaleInvoice_1>(lstSalesInvoiceList_1);

            // for A4 size print
            if (aTbl_Company.Invoice_Type == 1)
            {
                Reports.CRSalesInvoice rpt = new Reports.CRSalesInvoice();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //for parameter value in report

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;
                
                crystalReportViewer1.ReportSource = rpt;
            }

            // for half of A4 size print
            else if (aTbl_Company.Invoice_Type == 2)
            {
                Reports.CRSalesInvoice_halfA4 rpt = new Reports.CRSalesInvoice_halfA4();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            // for half of A4 right size print
            else if (aTbl_Company.Invoice_Type == 5)
            {
                Reports.CRSalesInvoice_halfA4_right rpt = new Reports.CRSalesInvoice_halfA4_right();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            //for a4 size invoice with customer due
            else if (aTbl_Company.Invoice_Type == 3)
            {
                Reports.CRSalesInvoiceWithDue rpt = new Reports.CRSalesInvoiceWithDue();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            //for half of a4 size invoice with customer due 
            else if (aTbl_Company.Invoice_Type == 4)
            {
                Reports.CRSalesInvoice_halfA4_WithDue rpt = new Reports.CRSalesInvoice_halfA4_WithDue();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            //for half of a4 right size invoice with customer due 
            else if (aTbl_Company.Invoice_Type == 6)
            {
                Reports.CRSalesInvoice_halfA4_WithDue_Right rpt = new Reports.CRSalesInvoice_halfA4_WithDue_Right();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            // for POS Printer with Exchange amount
            else if (aTbl_Company.Invoice_Type == 7)
            {
                Reports.CRSaleInvoiceForPOS_Exchange rpt = new Reports.CRSaleInvoiceForPOS_Exchange();
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
            }

            //for a4 bangla size invoice 
            else if (aTbl_Company.Invoice_Type == 8)
            {
                Reports.CRSalesInvoice_Bangla rpt = new Reports.CRSalesInvoice_Bangla();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            //for half of a4 bangla invoice 
            else if (aTbl_Company.Invoice_Type == 9)
            {
                Reports.CRSalesInvoice_halfA4_Bangla rpt = new Reports.CRSalesInvoice_halfA4_Bangla();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.Subreports[1].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                //ParameterField objParameterField = new ParameterField();

                //objDiscreteValue = new ParameterDiscreteValue();
                //objParameterField = new ParameterField();
                //objParameterField.Name = "@LoggedUser";
                //objDiscreteValue.Value = SplashForm.username;
                //objParameterField.CurrentValues.Add(objDiscreteValue);
                //paramFields.Add(objParameterField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                crystalReportViewer1.ReportSource = rpt;
            }

            // for POS Printer
            else if (aTbl_Company.Invoice_Type == 0)
            {
                Reports.CRSaleInvoiceForPOS rpt = new Reports.CRSaleInvoiceForPOS();
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        private void SalesInvoiceReportForm_Load(object sender, EventArgs e)
        {
            ShowReport();
        }

    }
}
