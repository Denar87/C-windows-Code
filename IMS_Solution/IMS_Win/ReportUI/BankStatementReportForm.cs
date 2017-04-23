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
    public partial class BankStatementReportForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Tbl_CashTransaction aTbl_CashTransaction = new Tbl_CashTransaction();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        List<Func_Get_BankStatement> lsbankstatemennList = new List<Func_Get_BankStatement>();
        public BankStatementReportForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lsbankstatemennList = aCashAccountBusiness.GetBankStatement().Where(x => x.Tr_date >= dtpStart.Value.Date && x.Tr_date <= dtpEnd.Value.Date).ToList();

                Reports.CRBankStatement rpt = new Reports.CRBankStatement();
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

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "StartDate";
                objDiscreteValue.Value = dtpStart.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "EndDate";
                objDiscreteValue.Value = dtpEnd.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                rpt.SetDataSource(lsbankstatemennList);
                ReportViewer.ParameterFieldInfo = paramFields;
                ReportViewer.ReportSource = rpt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BankStatementReportForm_Load(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
