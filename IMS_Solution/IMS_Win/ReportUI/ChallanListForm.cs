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
    public partial class ChallanListForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();

        SalesBusiness aSalesBusiness = new SalesBusiness();

        int selectedIndex = 0;

        public ChallanListForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            Reports.CRQuotationDetailList rpt = new Reports.CRQuotationDetailList();
            rpt.Subreports[0].SetDataSource(lstCompanyList);
            ReportViewerForm frm = new ReportViewerForm();

            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            ParameterField objParameterField = new ParameterField();

            //objDiscreteValue = new ParameterDiscreteValue();
            //objParameterField = new ParameterField();
            //objParameterField.Name = "paramUser";
            //objDiscreteValue.Value = SplashForm.username;
            //objParameterField.CurrentValues.Add(objDiscreteValue);
            //paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "StartDate";
            objDiscreteValue.Value = dtpfrom.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "EndDate";
            objDiscreteValue.Value = dtpto.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);


            List<Get_SaleInvoiceByChallan> lstChallanDetailList = aSalesBusiness.GetAllChallanDetails().Where(x => x.SaleMaster_SaleDate >= dtpfrom.Value.Date && x.SaleMaster_SaleDate <= dtpto.Value.Date).ToList();

            if (lstChallanDetailList.Any())
            {
                DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Get_SaleInvoiceByChallan>(lstChallanDetailList);
                DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                rpt.Subreports[0].SetDataSource(dt1);
                rpt.SetDataSource(dt);

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            else
            {
                dgvChallanList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        void LoadGrid()
        {
            dgvChallanList.AutoGenerateColumns = false;
            List<Get_SaleInvoiceByChallan> lstChallanDetailList = aSalesBusiness.GetAllChallanDetails().Where(x => x.SaleMaster_SaleDate >= dtpfrom.Value.Date && x.SaleMaster_SaleDate <= dtpto.Value.Date).ToList();

            if (lstChallanDetailList.Any())
            {
                dgvChallanList.DataSource = lstChallanDetailList;
            }
            else
            {
                dgvChallanList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //ShowReport();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

    }
}
