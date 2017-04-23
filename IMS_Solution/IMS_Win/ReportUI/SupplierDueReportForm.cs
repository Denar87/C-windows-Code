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
    public partial class SupplierDueReportForm : Form
    {
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        Tbl_Supplier aTbl_Supplier = new Tbl_Supplier();
        Qry_Supplier aSupplier = new Qry_Supplier();
        List<Qry_Supplier> lstSupplierList = new List<Qry_Supplier>();
        Tbl_PurchaseMaster aPurchaseMaster = new Tbl_PurchaseMaster();
        public SupplierDueReportForm()
        {
            InitializeComponent();
        }

        void GetSupplier()
        {
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyCode(txtCode.Text);

            SupplierListView.Items.Clear();
            if (lstSupplierList.Any())
            {
                SupplierListView.Visible = true;

                foreach (Qry_Supplier aSupplier in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aSupplier;
                    aListViewItem.Text = aSupplier.Supplier_Code;
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Name);
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Address);

                    SupplierListView.Items.Add(aListViewItem);
                }
            }
        }

        private void SupplierDueReportForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            List<Qry_SupplierDue> lstSupplierDueList = new List<Qry_SupplierDue>();

            if (cmbSearchType.Text == "All")
            {
                PurchaseMaster_InvoiceNo.Visible = false;
                Out_Amount.Visible = false;
                lstSupplierDueList = aSupplierBusiness.GetAllQrySupplierDue().Where(x=>x.PurchaseMaster_DueAmount>0).ToList();

                var groupdue = lstSupplierDueList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();
                
                List<Qry_SupplierDue> lstGridList = new List<Qry_SupplierDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_SupplierDue aQry_SupplierDue = new Qry_SupplierDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountBySupplier(g.Supplier_SlNo);
                    lstCash = lstCash.Where(x => x.Out_Amount > 0).ToList();
                    aQry_SupplierDue.Supplier_Code = g.Supplier_Code;
                    aQry_SupplierDue.Supplier_Name = g.Supplier_Name;
                    aQry_SupplierDue.Supplier_Address = g.Supplier_Address;
                    aQry_SupplierDue.Supplier_Mobile = g.Supplier_Mobile;
                    aQry_SupplierDue.PurchaseMaster_DueAmount = lstSupplierDueList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.PurchaseMaster_DueAmount) + lstCash.Sum(x => x.In_Amount) - lstCash.Sum(x => x.Out_Amount);

                    lstGridList.Add(aQry_SupplierDue);
                }
                dgvSupplierDueList.AutoGenerateColumns = false;
                dgvSupplierDueList.DataSource = null;
                dgvSupplierDueList.DataSource = lstGridList;


                int sum = 0;
                for (int i = 0; i < dgvSupplierDueList.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvSupplierDueList.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            //else
            //{
            //    PurchaseMaster_InvoiceNo.Visible = true;
            //    Out_Amount.Visible = true;
            //    dgvSupplierDueList.AutoGenerateColumns = false;
            //    lstSupplierDueList = aSupplierBusiness.GetAllQrySupplierDueBySupplier(aSupplier.Supplier_SlNo).Where(x => x.PurchaseMaster_DueAmount > 0).ToList();
            //    dgvSupplierDueList.DataSource = null;
            //    dgvSupplierDueList.DataSource = lstSupplierDueList;

            //    int sumdue = 0;
            //    int sumpaid = 0;
            //    for (int i = 0; i < dgvSupplierDueList.Rows.Count; ++i)
            //    {
            //        sumdue += Convert.ToInt32(dgvSupplierDueList.Rows[i].Cells[4].Value);
            //        sumpaid += Convert.ToInt32(dgvSupplierDueList.Rows[i].Cells[5].Value);
            //    }
            //    txtTotal.Text = (sumdue-sumpaid).ToString();
            //}
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            ReportViewerForm frm = new ReportViewerForm();
            Reports.CRSupplierDue rpt = new Reports.CRSupplierDue();
            Reports.CRSupplierWiseDue rptt = new Reports.CRSupplierWiseDue();

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
            if (cmbSearchType.Text == "All")
            {

                List<Qry_SupplierDue> lstSupplierDueList = new List<Qry_SupplierDue>();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                lstSupplierDueList = aSupplierBusiness.GetAllQrySupplierDue().Where(x => x.PurchaseMaster_DueAmount > 0).ToList();

                var groupdue = lstSupplierDueList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();

                List<Qry_SupplierDue> lstGridList = new List<Qry_SupplierDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_SupplierDue aQry_SupplierDue = new Qry_SupplierDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountBySupplier(g.Supplier_SlNo);
                    lstCash = lstCash.Where(x => x.Out_Amount > 0).ToList();
                    aQry_SupplierDue.Supplier_Code = g.Supplier_Code;
                    aQry_SupplierDue.Supplier_Name = g.Supplier_Name;
                    aQry_SupplierDue.Supplier_Address = g.Supplier_Address;
                    aQry_SupplierDue.Supplier_Mobile = g.Supplier_Mobile;
                    aQry_SupplierDue.PurchaseMaster_DueAmount = lstSupplierDueList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.PurchaseMaster_DueAmount) + lstCash.Sum(x => x.In_Amount) - lstCash.Sum(x => x.Out_Amount);

                    lstGridList.Add(aQry_SupplierDue);
                }
                DataTable dt = UtilityBusiness.GenericListToDataTable1(lstGridList);
                rpt.SetDataSource(dt);
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            //else
            //{
            //    List<Qry_SupplierDue> lsSupplierDueBySupplierList = aSupplierBusiness.GetAllQrySupplierDueBySupplier(aSupplier.Supplier_SlNo).Where(x => x.PurchaseMaster_DueAmount > 0).ToList();
            //    rptt.Subreports[0].SetDataSource(lstCompanyList);

            //    DataTable dt = UtilityBusiness.GenericListToDataTable1(lsSupplierDueBySupplierList);
            //    rptt.SetDataSource(dt);
            //    frm.ReportViewer.ReportSource = rptt;
            //    frm.ShowDialog();
            //}
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text != string.Empty)
            {
                GetSupplier();
            }
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void SupplierListView_Click(object sender, EventArgs e)
        {
            aSupplier = (Qry_Supplier)SupplierListView.SelectedItems[0].Tag;
            txtCode.Text = aSupplier.Supplier_Code;
            txtName.Text = aSupplier.Supplier_Name;
            SupplierListView.Visible = false;
            btnView.Focus();
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Single")
            {
                lblcode.Visible = true;
                lblname.Visible = true;
                txtCode.Visible = true;
                txtName.Visible = true;
                txtCode.Focus();
            }
            if (cmbSearchType.Text == "All")
            {
                lblcode.Visible = false;
                lblname.Visible = false;
                txtCode.Visible = false;
                txtName.Visible = false;
                SupplierListView.Visible = false;
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SupplierListView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SupplierListView.Focus();
            }
            else
            {
                GetSupplier();
            }
        }

        private void SupplierListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aSupplier = (Qry_Supplier)SupplierListView.SelectedItems[0].Tag;
                txtCode.Text = aSupplier.Supplier_Code;
                txtName.Text = aSupplier.Supplier_Name;
                SupplierListView.Visible = false;
                btnView.Focus();
            }
        }
    }
}
