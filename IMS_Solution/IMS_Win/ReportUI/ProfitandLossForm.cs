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
    public partial class ProfitandLossForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        public ProfitandLossForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            decimal totalPurchase = 0;
            decimal totalSales = 0;

            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            List<Tbl_PurchaseMaster> lstPurchaseMasterList = aPurchaseBusiness.GetAllPurchaseMaster().Where(x => x.PurchaseMaster_OrderDate >= dateTimePickerstart.Value.Date && x.PurchaseMaster_OrderDate <= dateTimePickerend.Value.Date).ToList();
            totalPurchase = Math.Abs(lstPurchaseMasterList.Sum(x => x.PurchaseMaster_TotalAmount));

            List<Tbl_SalesMaster> lstSalesMasterList = aSalesBusiness.GetAllSalesMaster().Where(x => x.SaleMaster_SaleDate >= dateTimePickerstart.Value.Date && x.SaleMaster_SaleDate <= dateTimePickerend.Value.Date).ToList();
            totalSales = Math.Abs(lstSalesMasterList.Sum(x => x.SaleMaster_TotalSaleAmount));

            ReportViewerForm frm = new ReportViewerForm();
            Reports.CRProfitOrLoss rpt = new Reports.CRProfitOrLoss();

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
            objParameterField.Name = "StartDate";
            objDiscreteValue.Value = dateTimePickerstart.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "EndDate";
            objDiscreteValue.Value = dateTimePickerend.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "paramPurchase";
            objDiscreteValue.Value = totalPurchase;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "paramSales";
            objDiscreteValue.Value = totalSales;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            rpt.Subreports[0].SetDataSource(lstCompanyList);
            frm.ReportViewer.ParameterFieldInfo = paramFields;
            frm.ReportViewer.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
