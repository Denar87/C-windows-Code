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
using CrystalDecisions.Shared;

namespace IMS_Win
{
    public partial class ReorderListForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        List<func_GetReorderProduct> lsReorderList = new List<func_GetReorderProduct>();
        public ReorderListForm()
        {
            InitializeComponent();
        }


        void LoadGrid()
        {
            dgvProductList.AutoGenerateColumns = false;
            lsReorderList = aProductBusiness.GetAllReOrderProduct();
            dgvProductList.DataSource = lsReorderList;
        }

        private void ReorderListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lsReorderList = aProductBusiness.GetAllReOrderProduct();
                Reports.CRReOrederProduct rpt = new Reports.CRReOrederProduct();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                rpt.SetDataSource(lsReorderList);
                ReportViewerForm frm = new ReportViewerForm();
                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
