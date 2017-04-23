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
    public partial class AllReportForm : Form
    {
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        AccountBusiness aAccountBusiness = new AccountBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Qry_Supplier aSupplier = new Qry_Supplier();
        List<Qry_Supplier> lstSupplierList = new List<Qry_Supplier>();
        Tbl_PurchaseMaster aPurchaseMaster = new Tbl_PurchaseMaster();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();

        Qry_Customer aTbl_Customer = new Qry_Customer();
        List<Get_Expense_Statement> lstExpense = new List<Get_Expense_Statement>();
        List<Get_Financial_Statement> lstIncomeExpense = new List<Get_Financial_Statement>();
        List<Get_Financial_Statement_All> lstGet_Financial_Statement_All = new List<Get_Financial_Statement_All>();
        List<Get_Financial_Statement_CustomerWise> lstFinancialStatement_CustomerWise = new List<Get_Financial_Statement_CustomerWise>();
        List<Qry_SupplierPayment> lstQry_SupplierPayment = new List<Qry_SupplierPayment>();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();

        public AllReportForm()
        {
            InitializeComponent();
        }

        #region Supplier Due Report

        void GetSupplier()
        {
            lstSupplierList = aSupplierBusiness.GetSupplierbyCode(txtCode.Text);

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


        void SupplierDue()
        {
            List<Qry_SupplierDue> lstSupplierDueList = new List<Qry_SupplierDue>();
            List<Qry_SupplierDue> lstGridList = new List<Qry_SupplierDue>();
            List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

            if (cmbSearch.Text == "All")
            {
                lblstockamount.Visible = true;
                txtTotal.Visible = true;
                dgvSupplierDueList.Visible = true;

                lstSupplierDueList = aSupplierBusiness.GetAllQrySupplierDue().Where(x => x.PurchaseMaster_DueAmount > 0).ToList();
                var groupdue = lstSupplierDueList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();

                foreach (var g in groupdue)
                {
                    Qry_SupplierDue aQry_SupplierDue = new Qry_SupplierDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountBySupplier(g.Supplier_SlNo);
                    //lstCash = lstCash.Where(x => x.Out_Amount > 0).ToList();

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
                    sum += Convert.ToInt32(dgvSupplierDueList.Rows[i].Cells[3].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            else
            {
                dgvSupplierDueList.Visible = false;
                // get supplierdue
                decimal purchasedue = 0;
                decimal paidamt = 0;
                decimal recievefromSupplier = 0;
                decimal result = 0;
                List<Tbl_PurchaseMaster> lstMasterList = aPurchaseBusiness.GetAllPurchaseMasterBySupplier(aSupplier.Supplier_SlNo);
                if (lstMasterList.Any())
                {
                    purchasedue = lstMasterList.Where(x => x.PurchaseMaster_DueAmount > 0).Sum(y => y.PurchaseMaster_DueAmount);

                    List<Tbl_CashTransaction> lstCashTransactionList = aCashAccountBusiness.GetAllCashAccountBySupplier(aSupplier.Supplier_SlNo);
                    if (lstCashTransactionList.Any())
                    {
                        paidamt = lstCashTransactionList.Sum(x => x.Out_Amount);
                        recievefromSupplier = lstCashTransactionList.Sum(x => x.In_Amount);
                    }
                }

                result = (purchasedue + recievefromSupplier) - paidamt;
                txtTotal.Text = Math.Round(result, 2).ToString();

                //lblstockamount.Visible = false;
                //txtTotal.Visible = false;

                //lstSupplierDueList = aSupplierBusiness.GetAllQrySupplierDueBySupplier(aSupplier.Supplier_SlNo).Where(x => x.PurchaseMaster_DueAmount > 0).ToList();
                //var groupdue = lstSupplierDueList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();

                //foreach (var g in groupdue)
                //{
                //    Qry_SupplierDue aQry_SupplierDue = new Qry_SupplierDue();

                //    lstCash = aCashAccountBusiness.GetAllCashAccountBySupplier(aSupplier.Supplier_SlNo);

                //    aQry_SupplierDue.Supplier_Code = g.Supplier_Code;
                //    aQry_SupplierDue.Supplier_Name = g.Supplier_Name;
                //    aQry_SupplierDue.Supplier_Address = g.Supplier_Address;
                //    aQry_SupplierDue.Supplier_Mobile = g.Supplier_Mobile;
                //    aQry_SupplierDue.PurchaseMaster_DueAmount = lstSupplierDueList.Sum(z => z.PurchaseMaster_DueAmount) + lstCash.Sum(x => x.In_Amount) - lstCash.Sum(x => x.Out_Amount);

                //    lstGridList.Add(aQry_SupplierDue);
                //}

                //dgvSupplierDueList.AutoGenerateColumns = false;
                //dgvSupplierDueList.DataSource = null;
                //dgvSupplierDueList.DataSource = lstSupplierDueList;
            }
        }

        private void btnviewSupplier_Click(object sender, EventArgs e)
        {
            SupplierDue();
        }

        private void btnSupplierReport_Click(object sender, EventArgs e)
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
            if (cmbSearch.Text == "All")
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
                    //lstCash = lstCash.Where(x => x.Out_Amount > 0).ToList();
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
            else
            {
                MessageBox.Show("All due list is printable");
                //List<Qry_SupplierDue> lsSupplierDueBySupplierList = aSupplierBusiness.GetAllQrySupplierDueBySupplier(aSupplier.Supplier_SlNo).Where(x => x.PurchaseMaster_DueAmount > 0).ToList();
                //rptt.Subreports[0].SetDataSource(lstCompanyList);

                //DataTable dt = UtilityBusiness.GenericListToDataTable1(lsSupplierDueBySupplierList);
                //rptt.SetDataSource(dt);
                //frm.ReportViewer.ReportSource = rptt;
                //frm.ShowDialog();
            }
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
            txtCode.Focus();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "All")
            {
                lblsupplierid.Visible = false;
                lblSuppliername.Visible = false;
                txtCode.Visible = false;
                txtName.Visible = false;
                SupplierListView.Visible = false;
            }
            else
            {
                lblsupplierid.Visible = true;
                lblSuppliername.Visible = true;
                txtCode.Visible = true;
                txtName.Visible = true;
                txtCode.Text = "";
                txtName.Text = "";
                txtCode.Focus();
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
                txtCode.Focus();
            }
        }

        #endregion

        #region Customer Due Report

        private void GetDistrictsForComboBox()
        {
            try
            {
                cmbDistrict.DataSource = null;
                cmbDistrict.DisplayMember = "District_Name";
                cmbDistrict.ValueMember = "District_SlNo";
                cmbDistrict.DataSource = aDistrictBusiness.GetAllDistrict();
                //cmbDistrict.Text = "Dhaka";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSearchType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "All")
            {
                lblcode.Visible = false;
                lblname.Visible = false;
                txtCustomerCode.Visible = false;
                txtCustomerName.Visible = false;
                customerListView.Visible = false;
                lblArea.Visible = false;
                cmbDistrict.Visible = false;
            }
            else if (cmbSearchType.Text == "Select Customer")
            {
                lblcode.Visible = true;
                lblname.Visible = true;
                txtCustomerCode.Visible = true;
                txtCustomerName.Visible = true;

                lblArea.Visible = false;
                cmbDistrict.Visible = false;

                txtCustomerCode.Text = "";
                txtCustomerName.Text = "";
                txtCustomerCode.Focus();
            }
            else if (cmbSearchType.Text == "Select Area")
            {
                lblcode.Visible = false;
                lblname.Visible = false;
                txtCustomerCode.Visible = false;
                txtCustomerName.Visible = false;

                lblArea.Visible = true;
                cmbDistrict.Visible = true;

                GetDistrictsForComboBox();
                cmbDistrict.Focus();
            }
        }

        private void customerListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
                txtCustomerCode.Text = aTbl_Customer.Customer_Code;
                txtCustomerName.Text = aTbl_Customer.Customer_Name;
                customerListView.Visible = false;
                txtCustomerCode.Focus();
            }
        }

        void CustomerDue()
        {
            dgvCustomerDueList.Visible = true;

            List<Qry_CustomerDue> lstCustomerDueList = new List<Qry_CustomerDue>();

            if (cmbSearchType.Text == "All")
            {
                lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();

                var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                    //lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();

                    aQry_CustomerDue.Customer_Code = g.Customer_Code;
                    aQry_CustomerDue.Customer_Name = g.Customer_Name;
                    aQry_CustomerDue.Customer_Address = g.Customer_Address;
                    aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                    aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                    lstGridList.Add(aQry_CustomerDue);
                }
                dgvCustomerDueList.AutoGenerateColumns = false;
                dgvCustomerDueList.DataSource = null;
                dgvCustomerDueList.DataSource = lstGridList;

                int sum = 0;
                for (int i = 0; i < dgvCustomerDueList.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvCustomerDueList.Rows[i].Cells[3].Value);
                }
                txtCustomerTotalDue.Text = sum.ToString();
            }
            else if (cmbSearchType.Text == "Select Customer")
            {
                dgvCustomerDueList.Visible = false;

                // get individual customerdue

                decimal salesedue = 0;
                decimal paidamt = 0;
                decimal paytoCustomer = 0;
                decimal result = 0;
                List<Tbl_SalesMaster> lstMasterList = aSalesBusiness.GetAllSaleMasterByCustomer(aTbl_Customer.Customer_SlNo);
                if (lstMasterList.Any())
                {
                    salesedue = lstMasterList.Where(x => x.SaleMaster_DueAmount > 0).Sum(y => y.SaleMaster_DueAmount);

                    List<Tbl_CashTransaction> lstCashAccountCustomerDueList = aCashAccountBusiness.GetAllCashAccountByCustomer(aTbl_Customer.Customer_SlNo);
                    if (lstCashAccountCustomerDueList.Any())
                    {
                        paidamt = lstCashAccountCustomerDueList.Sum(x => x.In_Amount);
                        paytoCustomer = lstCashAccountCustomerDueList.Sum(x => x.Out_Amount);
                    }
                    result = (salesedue + paytoCustomer) - paidamt;
                    txtCustomerTotalDue.Text = Math.Round(result, 2).ToString();
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                    txtCustomerTotalDue.Text = "0";
                }
            }

            else if (cmbSearchType.Text == "Select Area")
            {
                int districtId = Convert.ToInt16(cmbDistrict.SelectedValue);
                lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0 && x.District_SlNo == districtId).ToList();

                if (lstCustomerDueList.Count == 0)
                {
                    dgvCustomerDueList.DataSource = null;
                    txtCustomerTotalDue.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                    return;
                }

                var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                    //lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();

                    aQry_CustomerDue.Customer_Code = g.Customer_Code;
                    aQry_CustomerDue.Customer_Name = g.Customer_Name;
                    aQry_CustomerDue.Customer_Address = g.Customer_Address;
                    aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                    aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                    lstGridList.Add(aQry_CustomerDue);
                }
                dgvCustomerDueList.AutoGenerateColumns = false;
                dgvCustomerDueList.DataSource = null;
                dgvCustomerDueList.DataSource = lstGridList;

                int sum = 0;
                for (int i = 0; i < dgvCustomerDueList.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvCustomerDueList.Rows[i].Cells[3].Value);
                }
                txtCustomerTotalDue.Text = sum.ToString();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            CustomerDue();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            ReportViewerForm frm = new ReportViewerForm();
            Reports.CRCustomerDue rpt = new Reports.CRCustomerDue();
            Reports.CRCustomerDueByArea rpt1 = new Reports.CRCustomerDueByArea();
            Reports.CRCustomerWiseDue rptt = new Reports.CRCustomerWiseDue();

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
                List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();

                if (lstCustomerDueList.Count == 0)
                {
                    dgvCustomerDueList.DataSource = null;
                    txtCustomerTotalDue.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                    return;
                }

                rpt.Subreports[0].SetDataSource(lstCompanyList);

                lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();

                var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                    //lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();
                    aQry_CustomerDue.Customer_Code = g.Customer_Code;
                    aQry_CustomerDue.Customer_Name = g.Customer_Name;
                    aQry_CustomerDue.Customer_Address = g.Customer_Address;
                    aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                    aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                    lstGridList.Add(aQry_CustomerDue);
                }

                DataTable dt = UtilityBusiness.GenericListToDataTable1(lstGridList);
                rpt.SetDataSource(dt);
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            else if (cmbSearchType.Text == "Select Area")
            {
                int districtId = Convert.ToInt16(cmbDistrict.SelectedValue);

                List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();
                rpt1.Subreports[0].SetDataSource(lstCompanyList);

                lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0 && x.District_SlNo == districtId).ToList();

                if (lstCustomerDueList.Count == 0)
                {
                    dgvCustomerDueList.DataSource = null;
                    txtCustomerTotalDue.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                    return;
                }

                var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                foreach (var g in groupdue)
                {
                    Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                    //lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();
                    aQry_CustomerDue.Customer_Code = g.Customer_Code;
                    aQry_CustomerDue.Customer_Name = g.Customer_Name;
                    aQry_CustomerDue.Customer_Address = g.Customer_Address;
                    aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                    aQry_CustomerDue.District_Name = g.District_Name;
                    aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                    lstGridList.Add(aQry_CustomerDue);
                }

                DataTable dt = UtilityBusiness.GenericListToDataTable1(lstGridList);
                rpt1.SetDataSource(dt);
                frm.ReportViewer.ReportSource = rpt1;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("All due list/Area wise due is printable");
                //List<Qry_CustomerDue> lstCustomerDueByCustomerList = aCustomerBusiness.GetAllQryCustomerDueByCustomer(aTbl_Customer.Customer_SlNo).Where(x => x.SaleMaster_DueAmount > 0).ToList();
                //rptt.Subreports[0].SetDataSource(lstCompanyList);

                //DataTable dt = UtilityBusiness.GenericListToDataTable1(lstCustomerDueByCustomerList);
                //rptt.SetDataSource(dt);
                //frm.ReportViewer.ReportSource = rptt;
                //frm.ShowDialog();
            }
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Single")
            {
                lblcode.Visible = true;
                lblname.Visible = true;
                txtCustomerCode.Visible = true;
                txtCustomerName.Visible = true;
                txtCustomerCode.Focus();
            }
            if (cmbSearchType.Text == "All")
            {
                lblcode.Visible = false;
                lblname.Visible = false;
                txtCustomerCode.Visible = false;
                txtCustomerName.Visible = false;
                customerListView.Visible = false;
            }
        }

        void GetCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtCustomerCode.Text).Where(x => x.Customer_Code != "C0001").ToList(); ;

            customerListView.Items.Clear();
            if (lstCustomerList.Any())
            {
                customerListView.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    customerListView.Items.Add(aListViewItem);
                }
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerCode.Text != string.Empty)
            {
                GetCustomer();
            }
        }

        private void txtCustomerCode_Click(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void customerListView_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
            txtCustomerCode.Text = aTbl_Customer.Customer_Code;
            txtCustomerName.Text = aTbl_Customer.Customer_Name;
            customerListView.Visible = false;
            txtCustomerCode.Focus();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                customerListView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                customerListView.Focus();
            }
            else
            {
                GetCustomer();
            }
        }
        #endregion

        #region Official Statement

        void ViewIndividual_OfficialStatement()
        {

            try
            {
                lstExpense = aCashAccountBusiness.GetAllExpense(Convert.ToInt32(cmbAccName.SelectedValue)).Where(x => x.Tr_date >= dateTimePickerstart.Value.Date && x.Tr_date <= dateTimePickerend.Value.Date).ToList();
                if (lstExpense.Any())
                {
                    dgvOfficialReport.AutoGenerateColumns = false;
                    dgvOfficialReport.DataSource = null;
                    dgvOfficialReport.DataSource = lstExpense;
                }
                else
                {
                    dgvOfficialReport.DataSource = null;
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnviewOfficial_Click(object sender, EventArgs e)
        {
            if (rdbAllTransaction.Checked == true)
            {
                GetAllTotal_IncomeExpense();
            }
            else if (rdbDetailTransaction.Checked == true)
            {
                UtilityBusiness.DisplayAlertMessage('W', "Click 'Show Report' Button For Detail Statement.");
            }
            else if (rdbIndividualTransaction.Checked == true && txtCustomer_Id.Text == "")
            {
                ViewIndividual_OfficialStatement();
            }
            else if (rdbIndividualTransaction.Checked == true && txtCustomer_Id.Text != "")
            {
                UtilityBusiness.DisplayAlertMessage('W', "Click 'Show Report' Button For Customerwise Statement.");
            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "Select Information For Search.");
            }
        }

        private void GetAccountName()
        {
            try
            {
                cmbAccName.DataSource = null;
                cmbAccName.DisplayMember = "Acc_Name";
                cmbAccName.ValueMember = "Acc_SlNo";
                cmbAccName.DataSource = aAccountBusiness.GetAllAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAccountNameByType()
        {
            try
            {
                cmbAccName.DataSource = null;
                cmbAccName.DisplayMember = "Acc_Name";
                cmbAccName.ValueMember = "Acc_SlNo";
                cmbAccName.DataSource = aAccountBusiness.GetAllAccountByType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAllTotal_IncomeExpense()
        {
            try
            {
                lstExpense = aCashAccountBusiness.GetAllExpense().Where(x => x.Tr_date >= dateTimePickerstart.Value.Date && x.Tr_date <= dateTimePickerend.Value.Date).ToList();
                if (lstExpense.Any())
                {
                    dgvOfficialReport.AutoGenerateColumns = false;
                    dgvOfficialReport.DataSource = null;
                    dgvOfficialReport.DataSource = lstExpense;
                }
                else
                {
                    dgvOfficialReport.DataSource = null;
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllReportForm_Load(object sender, EventArgs e)
        {
            SupplierDue();
            CustomerDue();
            //SupplierDuePayment();
            //CustomerPaymentView();
            //GetAccountName();
            GetAccountNameByType();
        }

        void ShowIndividual_OfficialReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstExpense = aCashAccountBusiness.GetAllExpense(Convert.ToInt32(cmbAccName.SelectedValue)).Where(x => x.Tr_date >= dateTimePickerstart.Value.Date && x.Tr_date <= dateTimePickerend.Value.Date).ToList();

                if (lstExpense.Any())
                {
                    Reports.CRExpenseStatement rpt = new Reports.CRExpenseStatement();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    //define parameter fields....
                    ParameterFields paramFields = new ParameterFields();

                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();
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
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(lstExpense);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAllReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstExpense = aCashAccountBusiness.GetAllExpense().Where(x => x.Tr_date >= dateTimePickerstart.Value.Date && x.Tr_date <= dateTimePickerend.Value.Date).ToList();
                Reports.CRAllExpenseStatement rpt = new Reports.CRAllExpenseStatement();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                //define parameter fields....
                ParameterFields paramFields = new ParameterFields();

                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();
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
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                rpt.SetDataSource(lstExpense);
                ReportViewerForm frm = new ReportViewerForm();
                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// from cash register
        /// </summary>

        private void ShowTotal_IncomeExpense()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstIncomeExpense = aCashAccountBusiness.Get_FinancialStatement().Where(x => x.Transaction_Date >= dateTimePickerstart.Value.Date && x.Transaction_Date <= dateTimePickerend.Value.Date).ToList();

                if (lstIncomeExpense.Any())
                {
                    Reports.CRAllIncomeExpenseStatement rpt = new Reports.CRAllIncomeExpenseStatement();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    //define parameter fields....
                    ParameterFields paramFields = new ParameterFields();

                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();
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
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);


                    var groupstat = lstIncomeExpense.GroupBy(x => x.Narration).Select(y => y.First()).ToList();

                    List<Get_Financial_Statement> lstFinancialStatList = new List<Get_Financial_Statement>();

                    foreach (var stat in groupstat)
                    {
                        Get_Financial_Statement aGet_Financial_Statement = new Get_Financial_Statement();

                        aGet_Financial_Statement.Narration = stat.Narration;
                        aGet_Financial_Statement.InAmount = lstIncomeExpense.Where(y => y.Narration == stat.Narration).Sum(z => z.InAmount);
                        aGet_Financial_Statement.OutAmount = lstIncomeExpense.Where(y => y.Narration == stat.Narration).Sum(z => z.OutAmount);

                        lstFinancialStatList.Add(aGet_Financial_Statement);
                    }

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstFinancialStatList);
                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// from cash transaction
        /// </summary>
        private void ShowAll_IncomeExpense()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstIncomeExpense = aCashAccountBusiness.Get_FinancialStatement().Where(x => x.Transaction_Date >= dateTimePickerstart.Value.Date && x.Transaction_Date <= dateTimePickerend.Value.Date).ToList();
                Reports.CRAllIncomeExpenseStatement rpt = new Reports.CRAllIncomeExpenseStatement();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                //define parameter fields....
                ParameterFields paramFields = new ParameterFields();

                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();
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
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                rpt.SetDataSource(lstIncomeExpense);
                ReportViewerForm frm = new ReportViewerForm();
                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetStatement_CustomerWise()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstFinancialStatement_CustomerWise = aCashAccountBusiness.Get_FinancialStatement_CustomerWise(aTbl_Customer.Customer_SlNo).Where(x => x.Transaction_Date >= dateTimePickerstart.Value.Date && x.Transaction_Date <= dateTimePickerend.Value.Date).ToList();

                if (lstFinancialStatement_CustomerWise.Any())
                {
                    Reports.CRCustomerStatement rpt = new Reports.CRCustomerStatement();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    //define parameter fields....
                    ParameterFields paramFields = new ParameterFields();

                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();
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
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    //var groupstat = lstFinancialStatement_CustomerWise.GroupBy(x => x.Narration).Select(y => y.First()).ToList();

                    //List<Get_Financial_Statement_CustomerWise> lstFinancialStatList = new List<Get_Financial_Statement_CustomerWise>();

                    //foreach (var stat in groupstat)
                    //{
                    //    Get_Financial_Statement_CustomerWise aGet_Financial_Statement = new Get_Financial_Statement_CustomerWise();

                    //    aGet_Financial_Statement.Narration = stat.Narration;
                    //    aGet_Financial_Statement.InAmount = lstFinancialStatement_CustomerWise.Where(y => y.Narration == stat.Narration).Sum(z => z.InAmount);
                    //    aGet_Financial_Statement.OutAmount = lstFinancialStatement_CustomerWise.Where(y => y.Narration == stat.Narration).Sum(z => z.OutAmount);

                    //    lstFinancialStatList.Add(aGet_Financial_Statement);
                    //}

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstFinancialStatement_CustomerWise);
                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAllDetail_FinancialStatement()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstGet_Financial_Statement_All = aCashAccountBusiness.Get_FinancialStatement_All().Where(x => x.Transaction_Date >= dateTimePickerstart.Value.Date && x.Transaction_Date <= dateTimePickerend.Value.Date).ToList();

                if (lstGet_Financial_Statement_All.Any())
                {
                    Reports.CRAllFinancialStatement rpt = new Reports.CRAllFinancialStatement();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    //define parameter fields....
                    ParameterFields paramFields = new ParameterFields();

                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();
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
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    //var groupstat = lstFinancialStatement_CustomerWise.GroupBy(x => x.Narration).Select(y => y.First()).ToList();

                    //List<Get_Financial_Statement_CustomerWise> lstFinancialStatList = new List<Get_Financial_Statement_CustomerWise>();

                    //foreach (var stat in groupstat)
                    //{
                    //    Get_Financial_Statement_CustomerWise aGet_Financial_Statement = new Get_Financial_Statement_CustomerWise();

                    //    aGet_Financial_Statement.Narration = stat.Narration;
                    //    aGet_Financial_Statement.InAmount = lstFinancialStatement_CustomerWise.Where(y => y.Narration == stat.Narration).Sum(z => z.InAmount);
                    //    aGet_Financial_Statement.OutAmount = lstFinancialStatement_CustomerWise.Where(y => y.Narration == stat.Narration).Sum(z => z.OutAmount);

                    //    lstFinancialStatList.Add(aGet_Financial_Statement);
                    //}

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstGet_Financial_Statement_All);
                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowOfficialReport_Click(object sender, EventArgs e)
        {
            if (rdbAllTransaction.Checked == true)
            {
                ShowTotal_IncomeExpense();
            }
            else if (rdbDetailTransaction.Checked == true)
            {
                GetAllDetail_FinancialStatement();
            }
            else if (rdbIndividualTransaction.Checked == true && txtCustomer_Id.Text != "")
            {
                GetStatement_CustomerWise();
            }
            else if (rdbIndividualTransaction.Checked == true && txtCustomer_Id.Text == "")
            {
                ShowIndividual_OfficialReport();
            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "Select Information For Search.");
            }
        }

        #endregion

        #region Customer Payment Report

        void GetCustomerforpay()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtcustomerid.Text).Where(x => x.Customer_Code != "C0001").ToList();

            listViewCustomer.Items.Clear();
            if (lstCustomerList.Any())
            {
                listViewCustomer.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    listViewCustomer.Items.Add(aListViewItem);
                }
            }
        }

        private void txtcustomerid_Click(object sender, EventArgs e)
        {
            GetCustomerforpay();
        }

        private void txtcustomerid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewCustomer.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewCustomer.Focus();
            }
            else
            {
                GetCustomerforpay();
            }
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomerid.Text != string.Empty)
            {
                GetCustomerforpay();
            }
        }

        private void listViewCustomer_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)listViewCustomer.SelectedItems[0].Tag;
            txtcustomerid.Text = aTbl_Customer.Customer_Code;
            txtCustomer_name.Text = aTbl_Customer.Customer_Name;
            listViewCustomer.Visible = false;
            btnShowCustomerPayment.Focus();
        }

        private void cmbSearchCustomerpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchCustomerpay.Text == "Select Customer")
            {
                label8.Visible = true;
                label9.Visible = true;
                txtcustomerid.Visible = true;
                txtCustomer_name.Visible = true;
                txtcustomerid.Text = "";
                txtCustomer_name.Text = "";
                txtcustomerid.Focus();
            }
            if (cmbSearchCustomerpay.Text == "All")
            {
                label8.Visible = false;
                label9.Visible = false;
                txtcustomerid.Visible = false;
                txtCustomer_name.Visible = false;
                listViewCustomer.Visible = false;
            }
        }

        void CustomerPaymentView()
        {
            List<Qry_CustomerPayment> lstCustomerPayList = new List<Qry_CustomerPayment>();

            if (DateTime.Compare(dtpCustomerPayEnd.Value.Date, dtpCustomerPayStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }
            if (cmbSearchCustomerpay.Text == "All")
            {
                Tr_Id.Visible = false;
                Tr_date.Visible = false;
                clm_Description.Visible = false;
                clm_Customer_Code.Visible = true;
                clm_Customer_name.Visible = true;
                clm_Customer_Mobile.Visible = true;
                dgvCustomerpay.AutoGenerateColumns = false;
                lstCustomerPayList = aCustomerBusiness.GetAllCustomerPayment().Where(x => (x.In_Amount > 0 || x.Out_Amount > 0) && x.Tr_date >= dtpCustomerPayStart.Value.Date && x.Tr_date <= dtpCustomerPayEnd.Value.Date).ToList();

                if (lstCustomerPayList.Any())
                {
                    var grouppay = lstCustomerPayList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                    List<Qry_CustomerPayment> lstpayGridList = new List<Qry_CustomerPayment>();

                    foreach (var g in grouppay)
                    {
                        Qry_CustomerPayment aQry_Customerpay = new Qry_CustomerPayment();

                        aQry_Customerpay.Customer_Code = g.Customer_Code;
                        aQry_Customerpay.Customer_Name = g.Customer_Name;
                        aQry_Customerpay.Customer_Address = g.Customer_Address;
                        aQry_Customerpay.Customer_Mobile = g.Customer_Mobile;
                        aQry_Customerpay.In_Amount = lstCustomerPayList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.In_Amount);
                        aQry_Customerpay.Out_Amount = lstCustomerPayList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.Out_Amount);

                        lstpayGridList.Add(aQry_Customerpay);
                    }
                    dgvCustomerpay.AutoGenerateColumns = false;
                    dgvCustomerpay.DataSource = null;
                    dgvCustomerpay.DataSource = lstpayGridList;


                    int sum = 0;
                    for (int i = 0; i < dgvCustomerpay.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvCustomerpay.Rows[i].Cells[6].Value);
                    }
                    txttotalcustomerpay.Text = sum.ToString();
                }
                else
                {
                    dgvCustomerpay.DataSource = null;
                    txttotalcustomerpay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            else
            {
                Tr_Id.Visible = true;
                Tr_date.Visible = true;
                clm_Description.Visible = true;
                clm_Customer_Code.Visible = false;
                clm_Customer_name.Visible = false;
                clm_Customer_Mobile.Visible = false;
                dgvCustomerpay.AutoGenerateColumns = false;
                lstCustomerPayList = aCustomerBusiness.GetAllQryCustomerPayByCustomer(aTbl_Customer.Customer_SlNo).Where(x => (x.In_Amount > 0 || x.Out_Amount > 0) && x.Tr_date >= dtpCustomerPayStart.Value.Date && x.Tr_date <= dtpCustomerPayEnd.Value.Date).ToList();

                if (lstCustomerPayList.Any())
                {
                    dgvCustomerpay.DataSource = null;
                    dgvCustomerpay.DataSource = lstCustomerPayList;

                    int sumpaid = 0;
                    for (int i = 0; i < dgvCustomerpay.Rows.Count; ++i)
                    {
                        sumpaid += Convert.ToInt32(dgvCustomerpay.Rows[i].Cells[6].Value);
                    }
                    txttotalcustomerpay.Text = sumpaid.ToString();
                }
                else
                {
                    dgvCustomerpay.DataSource = null;
                    txttotalcustomerpay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
        }

        private void btnShowCustomerPayment_Click(object sender, EventArgs e)
        {
            CustomerPaymentView();
        }

        private void btnReportCustomerPay_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpCustomerPayEnd.Value.Date, dtpCustomerPayStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            List<Qry_CustomerPayment> lstCustomerPayList = new List<Qry_CustomerPayment>();
            ReportViewerForm frm = new ReportViewerForm();
            Reports.CRCustomerPayment rpt = new Reports.CRCustomerPayment();
            Reports.CRCustomerwisePayment rptt = new Reports.CRCustomerwisePayment();

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
            objDiscreteValue.Value = dtpCustomerPayStart.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "EndDate";
            objDiscreteValue.Value = dtpCustomerPayEnd.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            frm.ReportViewer.ParameterFieldInfo = paramFields;
            if (cmbSearchCustomerpay.Text == "All")
            {
                lstCustomerPayList = aCustomerBusiness.GetAllCustomerPayment().Where(x => (x.In_Amount > 0 || x.Out_Amount > 0) && x.Tr_date >= dtpCustomerPayStart.Value.Date && x.Tr_date <= dtpCustomerPayEnd.Value.Date).ToList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                if (lstCustomerPayList.Any())
                {
                    var grouppay = lstCustomerPayList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                    List<Qry_CustomerPayment> lstpayGridList = new List<Qry_CustomerPayment>();

                    foreach (var g in grouppay)
                    {
                        Qry_CustomerPayment aQry_Customerpay = new Qry_CustomerPayment();

                        aQry_Customerpay.Customer_Code = g.Customer_Code;
                        aQry_Customerpay.Customer_Name = g.Customer_Name;
                        aQry_Customerpay.Customer_Address = g.Customer_Address;
                        aQry_Customerpay.Customer_Mobile = g.Customer_Mobile;
                        aQry_Customerpay.In_Amount = lstCustomerPayList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.In_Amount);
                        aQry_Customerpay.Out_Amount = lstCustomerPayList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.Out_Amount);

                        lstpayGridList.Add(aQry_Customerpay);
                    }

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstpayGridList);
                    rpt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvCustomerpay.DataSource = null;
                    txttotalcustomerpay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }

            }
            else
            {
                lstCustomerPayList = aCustomerBusiness.GetAllQryCustomerPayByCustomer(aTbl_Customer.Customer_SlNo).Where(x => (x.In_Amount > 0 || x.Out_Amount > 0) && x.Tr_date >= dtpCustomerPayStart.Value.Date && x.Tr_date <= dtpCustomerPayEnd.Value.Date).ToList();
                rptt.Subreports[0].SetDataSource(lstCompanyList);

                if (lstCustomerPayList.Any())
                {
                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstCustomerPayList);
                    rptt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rptt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvCustomerpay.DataSource = null;
                    txttotalcustomerpay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
        }

        private void listViewCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Customer = (Qry_Customer)listViewCustomer.SelectedItems[0].Tag;
                txtcustomerid.Text = aTbl_Customer.Customer_Code;
                txtCustomer_name.Text = aTbl_Customer.Customer_Name;
                listViewCustomer.Visible = false;
                btnViewSupplierpay.Focus();
            }
        }

        #endregion

        #region Supplier Payment Report

        void GetSupplierforpay()
        {
            lstSupplierList = aSupplierBusiness.GetSupplierbyCode(txtSupplierid.Text);

            listViewSupplierpay.Items.Clear();
            if (lstSupplierList.Any())
            {
                listViewSupplierpay.Visible = true;

                foreach (Qry_Supplier aSupplier in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aSupplier;
                    aListViewItem.Text = aSupplier.Supplier_Code;
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Name);
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Address);

                    listViewSupplierpay.Items.Add(aListViewItem);
                }

            }
        }

        private void cmbSearchTypeSupplierPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchTypeSupplierPay.Text == "Select Supplier")
            {
                label13.Visible = true;
                label14.Visible = true;
                txtSupplierid.Visible = true;
                txtSuppliername.Visible = true;
                txtSupplierid.Text = "";
                txtSuppliername.Text = "";
                txtSupplierid.Focus();
            }
            if (cmbSearchTypeSupplierPay.Text == "All")
            {
                label13.Visible = false;
                label14.Visible = false;
                txtSupplierid.Visible = false;
                txtSuppliername.Visible = false;
                listViewSupplierpay.Visible = false;
            }
        }

        private void txtSupplierid_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierid.Text != string.Empty)
            {
                GetSupplierforpay();
            }
        }

        private void txtSupplierid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewSupplierpay.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewSupplierpay.Focus();
            }
            else
            {
                GetSupplierforpay();
            }
        }

        private void txtSupplierid_Click(object sender, EventArgs e)
        {
            GetSupplierforpay();
        }

        private void listViewSupplierpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aSupplier = (Qry_Supplier)listViewSupplierpay.SelectedItems[0].Tag;
                txtSupplierid.Text = aSupplier.Supplier_Code;
                txtSuppliername.Text = aSupplier.Supplier_Name;
                listViewSupplierpay.Visible = false;
                btnViewSupplierpay.Focus();
            }
        }

        private void listViewSupplierpay_Click(object sender, EventArgs e)
        {
            aSupplier = (Qry_Supplier)listViewSupplierpay.SelectedItems[0].Tag;
            txtSupplierid.Text = aSupplier.Supplier_Code;
            txtSuppliername.Text = aSupplier.Supplier_Name;
            listViewSupplierpay.Visible = false;
            btnViewSupplierpay.Focus();
        }

        void SupplierDuePayment()
        {
            List<Qry_SupplierPayment> lstSupplierPayList = new List<Qry_SupplierPayment>();
            if (DateTime.Compare(dtpSupplierPayEnd.Value.Date, dtpSupplierPayStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }
            if (cmbSearchTypeSupplierPay.Text == "All")
            {
                clm_Tr_Id.Visible = false;
                clm_Tr_Date.Visible = false;
                clm_TrDescription.Visible = false;
                clm_suppliername.Visible = true;
                clm_Suppliermobile.Visible = true;
                lstSupplierPayList = aSupplierBusiness.GetAllSupplierPayment().Where(x => (x.Out_Amount > 0 || x.In_Amount > 0) && x.Tr_date >= dtpSupplierPayStart.Value.Date && x.Tr_date <= dtpSupplierPayEnd.Value.Date).ToList();

                if (lstSupplierPayList.Any())
                {
                    var grouppay = lstSupplierPayList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();

                    List<Qry_SupplierPayment> lstSupplierpayGridList = new List<Qry_SupplierPayment>();

                    foreach (var g in grouppay)
                    {
                        Qry_SupplierPayment aQry_Supplier = new Qry_SupplierPayment();

                        aQry_Supplier.Supplier_Code = g.Supplier_Code;
                        aQry_Supplier.Supplier_Name = g.Supplier_Name;
                        aQry_Supplier.Supplier_Address = g.Supplier_Address;
                        aQry_Supplier.Supplier_Mobile = g.Supplier_Mobile;
                        aQry_Supplier.In_Amount = lstSupplierPayList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.In_Amount);
                        aQry_Supplier.Out_Amount = lstSupplierPayList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.Out_Amount);

                        lstSupplierpayGridList.Add(aQry_Supplier);
                    }
                    dgvSupplierPay.AutoGenerateColumns = false;
                    dgvSupplierPay.DataSource = null;
                    dgvSupplierPay.DataSource = lstSupplierpayGridList;

                    int sum = 0;
                    for (int i = 0; i < dgvSupplierPay.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvSupplierPay.Rows[i].Cells[7].Value);
                    }
                    txtTotalSupplierPay.Text = sum.ToString();
                }

                else
                {
                    dgvSupplierPay.DataSource = null;
                    txtTotalSupplierPay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            else
            {
                clm_Tr_Id.Visible = true;
                clm_Tr_Date.Visible = true;
                clm_TrDescription.Visible = true;
                clm_Supplierid.Visible = false;
                clm_suppliername.Visible = false;
                clm_Suppliermobile.Visible = false;
                dgvSupplierPay.AutoGenerateColumns = false;
                lstSupplierPayList = aSupplierBusiness.GetAllSupplierPaymentByID(aSupplier.Supplier_SlNo).Where(x => (x.Out_Amount > 0 || x.In_Amount > 0) && x.Tr_date >= dtpSupplierPayStart.Value.Date && x.Tr_date <= dtpSupplierPayEnd.Value.Date).ToList();

                if (lstSupplierPayList.Any())
                {
                    dgvSupplierPay.DataSource = null;
                    dgvSupplierPay.DataSource = lstSupplierPayList;

                    int sumpaid = 0;
                    for (int i = 0; i < dgvSupplierPay.Rows.Count; ++i)
                    {
                        sumpaid += Convert.ToInt32(dgvSupplierPay.Rows[i].Cells[7].Value);
                    }
                    txtTotalSupplierPay.Text = sumpaid.ToString();
                }
                else
                {
                    dgvSupplierPay.DataSource = null;
                    txtTotalSupplierPay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
        }

        private void btnViewSupplierpay_Click(object sender, EventArgs e)
        {
            SupplierDuePayment();
        }

        private void btnReportSupplirpay_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpSupplierPayEnd.Value.Date, dtpSupplierPayStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            List<Qry_SupplierPayment> lstSupplierPayList = new List<Qry_SupplierPayment>();
            ReportViewerForm frm = new ReportViewerForm();
            Reports.CRSupplierPayment rpt = new Reports.CRSupplierPayment();
            Reports.CRSupplierwisePayment rptt = new Reports.CRSupplierwisePayment();

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
            objDiscreteValue.Value = dtpSupplierPayStart.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "EndDate";
            objDiscreteValue.Value = dtpSupplierPayEnd.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            frm.ReportViewer.ParameterFieldInfo = paramFields;
            if (cmbSearchTypeSupplierPay.Text == "All")
            {
                lstSupplierPayList = aSupplierBusiness.GetAllSupplierPayment().Where(x => (x.Out_Amount > 0 || x.In_Amount > 0) && x.Tr_date >= dtpSupplierPayStart.Value.Date && x.Tr_date <= dtpSupplierPayEnd.Value.Date).ToList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);

                if (lstSupplierPayList.Any())
                {
                    var grouppay = lstSupplierPayList.GroupBy(x => x.Supplier_Code).Select(y => y.First()).ToList();

                    List<Qry_SupplierPayment> lstSupplierpayGridList = new List<Qry_SupplierPayment>();

                    foreach (var g in grouppay)
                    {
                        Qry_SupplierPayment aQry_Supplier = new Qry_SupplierPayment();

                        aQry_Supplier.Supplier_Code = g.Supplier_Code;
                        aQry_Supplier.Supplier_Name = g.Supplier_Name;
                        aQry_Supplier.Supplier_Address = g.Supplier_Address;
                        aQry_Supplier.Supplier_Mobile = g.Supplier_Mobile;
                        aQry_Supplier.In_Amount = lstSupplierPayList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.In_Amount);
                        aQry_Supplier.Out_Amount = lstSupplierPayList.Where(y => y.Supplier_Code == g.Supplier_Code).Sum(z => z.Out_Amount);

                        lstSupplierpayGridList.Add(aQry_Supplier);
                    }

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstSupplierpayGridList);
                    rpt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvSupplierPay.DataSource = null;
                    txtTotalSupplierPay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
            else
            {
                lstSupplierPayList = aSupplierBusiness.GetAllSupplierPaymentByID(aSupplier.Supplier_SlNo).Where(x => (x.Out_Amount > 0 || x.In_Amount > 0) && x.Tr_date >= dtpSupplierPayStart.Value.Date && x.Tr_date <= dtpSupplierPayEnd.Value.Date).ToList();
                rptt.Subreports[0].SetDataSource(lstCompanyList);

                if (lstSupplierPayList.Any())
                {
                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstSupplierPayList);
                    rptt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rptt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvSupplierPay.DataSource = null;
                    txtTotalSupplierPay.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                }
            }
        }

        #endregion

        void GetCustomerforStatement()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtCustomer_Id.Text).Where(x => x.Customer_Code != "C0001").ToList();

            listView_Customer.Items.Clear();
            if (lstCustomerList.Any())
            {
                listView_Customer.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    listView_Customer.Items.Add(aListViewItem);
                }
            }
        }

        private void txtCustomer_Id_Click(object sender, EventArgs e)
        {
            GetCustomerforStatement();
        }

        private void txtCustomer_Id_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomer_Id.Text != string.Empty)
            {
                GetCustomerforStatement();
            }
            else
            {
                lblCustomerName.Visible = false;
            }
        }

        private void listView_Customer_Click(object sender, EventArgs e)
        {
            lblCustomerName.Visible = true;
            aTbl_Customer = (Qry_Customer)listView_Customer.SelectedItems[0].Tag;
            txtCustomer_Id.Text = aTbl_Customer.Customer_Code;
            lblCustomerName.Text = aTbl_Customer.Customer_Name;
            listView_Customer.Visible = false;
            btnShowOfficialReport.Focus();
        }

        private void listView_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lblCustomerName.Visible = true;
                aTbl_Customer = (Qry_Customer)listView_Customer.SelectedItems[0].Tag;
                txtCustomer_Id.Text = aTbl_Customer.Customer_Code;
                lblCustomerName.Text = aTbl_Customer.Customer_Name;
                listView_Customer.Visible = false;
                btnShowOfficialReport.Focus();
            }
        }

        private void txtCustomer_Id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listView_Customer.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listView_Customer.Focus();
            }
            else
            {
                GetCustomerforStatement();
            }
        }

        private void rdbAllTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAllTransaction.Checked == true)
            {
                cmbAccName.Enabled = false;
                txtCustomer_Id.Text = "";
                txtCustomer_Id.Enabled = false;
                lblCustomerName.Visible = false;
                listView_Customer.Visible = false;
            }
            else
            {
                cmbAccName.Enabled = true;
                txtCustomer_Id.Enabled = true;
                lblCustomerName.Visible = true;
            }
        }

        private void rdbDetailTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDetailTransaction.Checked == true)
            {
                cmbAccName.Enabled = false;
                txtCustomer_Id.Text = "";
                txtCustomer_Id.Enabled = false;
                lblCustomerName.Visible = false;
                listView_Customer.Visible = false;
            }
            else
            {
                cmbAccName.Enabled = true;
                txtCustomer_Id.Enabled = true;
                lblCustomerName.Visible = true;
            }
        }

        private void rdbIndividualTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIndividualTransaction.Checked == true)
            {
                cmbAccName.Enabled = true;
                txtCustomer_Id.Enabled = true;
                lblCustomerName.Visible = false;
                listView_Customer.Visible = false;
            }
            else
            {
                cmbAccName.Enabled = false;
                txtCustomer_Id.Enabled = false;
                lblCustomerName.Visible = false;
            }
        }

    }
}
