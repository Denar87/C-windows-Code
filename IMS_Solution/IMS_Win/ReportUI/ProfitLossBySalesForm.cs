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
    public partial class ProfitLossBySalesForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        List<Qry_SaleMasterDetails> lstSalesMasterDetailsList = new List<Qry_SaleMasterDetails>();
        List<Qry_SalesPurchaseDetails> lstSalesMasterPurchaseDetailsList = new List<Qry_SalesPurchaseDetails>();
        public ProfitLossBySalesForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            try
            {
                if (DateTime.Compare(dtpEnd.Value.Date, dtpStart.Value.Date) < 0)
                {
                    MessageBox.Show("to Date must be equal or greater than from date");
                    return;
                }

                dgvProfitLossBySale.AutoGenerateColumns = false;
                lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderByDescending(x => x.SaleMaster_SaleDate).ToList();
                dgvProfitLossBySale.DataSource = lstSalesMasterDetailsList;

                decimal totalsale = 0, netprofitloss = 0;
                for (int i = 0; i < dgvProfitLossBySale.Rows.Count; ++i)
                {
                    
                    dgvProfitLossBySale.Rows[i].Cells[7].Value = Convert.ToInt32(dgvProfitLossBySale.Rows[i].Cells[4].Value) * Convert.ToDecimal(dgvProfitLossBySale.Rows[i].Cells[6].Value);
                    dgvProfitLossBySale.Rows[i].Cells[9].Value = Convert.ToDecimal(dgvProfitLossBySale.Rows[i].Cells[8].Value) - Convert.ToInt32(dgvProfitLossBySale.Rows[i].Cells[7].Value);
                    
                    totalsale += Convert.ToInt32(dgvProfitLossBySale.Rows[i].Cells[8].Value);
                    netprofitloss += Convert.ToInt32(dgvProfitLossBySale.Rows[i].Cells[9].Value);
                }
                lblTotalSale.Text = Math.Round(totalsale,2).ToString();
                lblProfitLoss.Text = Math.Round(netprofitloss,2).ToString();
            }
            catch
            {
            }
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails();
                Reports.CRProfitLossBySales rpt = new Reports.CRProfitLossBySales();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
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

                lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderByDescending(x => x.SaleMaster_SaleDate).ToList();

                DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_SaleMasterDetails>(lstSalesMasterDetailsList);
                DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                rpt.Subreports[0].SetDataSource(dt1);
                rpt.SetDataSource(dt);

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void ProfitLossBySalesForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
