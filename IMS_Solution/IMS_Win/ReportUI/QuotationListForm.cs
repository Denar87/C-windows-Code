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
    public partial class QuotationListForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();

        SalesBusiness aSalesBusiness = new SalesBusiness();

        int selectedIndex = 0;

        public QuotationListForm()
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


            List<Get_SaleInvoiceByQuotation> lstQuotationDetailList = aSalesBusiness.GetAllQuotationDetails().Where(x => x.QuotationMaster_Date >= dtpfrom.Value.Date && x.QuotationMaster_Date <= dtpto.Value.Date).ToList();
            
            if (lstQuotationDetailList.Any())
            {
                DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Get_SaleInvoiceByQuotation>(lstQuotationDetailList);
                DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                rpt.Subreports[0].SetDataSource(dt1);
                rpt.SetDataSource(dt);

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            else
            {
                dgvQuotationList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        void LoadGrid()
        {
            dgvQuotationList.AutoGenerateColumns = false;
            List<Get_SaleInvoiceByQuotation> lstQuotationDetailList = aSalesBusiness.GetAllQuotationDetails().Where(x => x.QuotationMaster_Date >= dtpfrom.Value.Date && x.QuotationMaster_Date <= dtpto.Value.Date).ToList();
            
            if (lstQuotationDetailList.Any())
            {
                dgvQuotationList.DataSource = lstQuotationDetailList;
            }
            else
            {
                dgvQuotationList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

    }
}
