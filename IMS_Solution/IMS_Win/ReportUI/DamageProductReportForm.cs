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
using Utility;

namespace IMS_Win
{
    public partial class DamageProductReportForm : Form
    {
        DamageBusiness aDamageBusiness = new DamageBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        List<Get_DamagedProduct> lstDamageList = new List<Get_DamagedProduct>();
        public DamageProductReportForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvDamageProductList.AutoGenerateColumns = false;
            lstDamageList = aDamageBusiness.GetDamageProduct();
            dgvDamageProductList.DataSource = lstDamageList;
        }
        private void DamageProductReportForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void showreport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstDamageList = aDamageBusiness.GetDamageProduct();
                Reports.CRDamageList rpt = new Reports.CRDamageList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_DamagedProduct>(lstDamageList);
                rpt.SetDataSource(dt);
                ReportViewerForm frm = new ReportViewerForm();

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);


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
            showreport();
        }
    }
}
