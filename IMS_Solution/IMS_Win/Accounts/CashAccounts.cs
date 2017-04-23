using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Business;
using Utility;
using IMS_Entity;
using CrystalDecisions.Shared;

namespace IMS_Win
{
    public partial class CashAccounts : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        List<Tbl_CashTransaction> lstCashTransactionList = new List<Tbl_CashTransaction>();
        AccountBusiness aAccountBusiness = new AccountBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        Qry_Customer acustomer = new Qry_Customer();
        Qry_Supplier aSupplier = new Qry_Supplier();
        Tbl_Account aAccount = new Tbl_Account();
        Tbl_CashTransaction aTbl_CashTransaction = new Tbl_CashTransaction();
        int selectedIndex = 0;
        List<Qry_CashTransaction> lstQryCashTransactionList = new List<Qry_CashTransaction>();
        List<Get_Expense_Statement> lstExpense = new List<Get_Expense_Statement>();
        List<Get_Cash_TransactionByCode> lstTransaction = new List<Get_Cash_TransactionByCode>();

        public CashAccounts()
        {

            InitializeComponent();
        }

        private void GetAccountType()
        {
            try
            {
                cmbAccType.DataSource = null;
                cmbAccType.DisplayMember = "Acc_Type";
                cmbAccType.ValueMember = "Acc_SlNo";
                cmbAccType.DataSource = aAccountBusiness.GetAllAccount();
                //cmbCountry.SelectedItem = cmbCountry.Items[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadGrid()
        {
            dgvCashAccount.AutoGenerateColumns = false;
            lstQryCashTransactionList = aCashAccountBusiness.GetAllQryCashTransactionByDate(dtpDate.Value.Date);
            lstQryCashTransactionList = lstQryCashTransactionList.OrderByDescending(x => x.Tr_Id).ToList();
            dgvCashAccount.DataSource = lstQryCashTransactionList;
        }

        private void CashAccounts_Load(object sender, EventArgs e)
        {
            txtTrID.Text = aCashAccountBusiness.GenerateTrCode();
            loadGrid();
        }

        void GetAccount()
        {
            List<Tbl_Account> lstSupplierList = aAccountBusiness.GetAllAccountbyCode(txtAccID.Text).Where(x=>x.Acc_Type=="Official").ToList();
            AccountListView.Items.Clear();
            if (lstSupplierList.Any())
            {
                AccountListView.Visible = true;
                foreach (Tbl_Account aAccount in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aAccount;
                    aListViewItem.Text = aAccount.Acc_Code;
                    aListViewItem.SubItems.Add(aAccount.Acc_Name);
                    aListViewItem.SubItems.Add(aAccount.Acc_Description);
                    AccountListView.Items.Add(aListViewItem);
                }
            }
        }

        void GetSupplier()
        {
            List<Qry_Supplier> lstSupplierList = aSupplierBusiness.GetSupplierbyCode(txtAccID.Text);
            AccountListView.Items.Clear();
            if (lstSupplierList.Any())
            {
                AccountListView.Visible = true;

                foreach (Qry_Supplier asupplier in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = asupplier;
                    aListViewItem.Text = asupplier.Supplier_Code;
                    aListViewItem.SubItems.Add(asupplier.Supplier_Name);
                    aListViewItem.SubItems.Add(asupplier.Supplier_Address);
                    AccountListView.Items.Add(aListViewItem);
                }
            }
        }

        void GetCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetCustomerbyCode(txtAccID.Text);
            AccountListView.Items.Clear();
            if (lstCustomerList.Any())
            {
                AccountListView.Visible = true;
                foreach (Qry_Customer customer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = customer;
                    aListViewItem.Text = customer.Customer_Code;
                    aListViewItem.SubItems.Add(customer.Customer_Name);
                    aListViewItem.SubItems.Add(customer.Customer_Address);
                    AccountListView.Items.Add(aListViewItem);
                }
            }
        }

        private void txtAccID_TextChanged(object sender, EventArgs e)
        {
            if (cmbAccType.Text == "Supplier")
            {
                if (txtAccID.Text != string.Empty)
                {
                    GetSupplier();
                }
            }
            if (cmbAccType.Text == "Customer")
            {
                if (txtAccID.Text != string.Empty)
                {
                    GetCustomer();
                }
            }
            if (cmbAccType.Text == "Official")
            {
                if (txtAccID.Text != string.Empty)
                {
                    GetAccount();
                }
            }
        }

        private void txtAccID_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbAccType.Text == "Customer")
            {
                if (e.KeyCode == Keys.Escape)
                {
                    AccountListView.Hide();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    AccountListView.Focus();
                }
                else
                {
                    GetCustomer();
                }
            }
            if (cmbAccType.Text == "Supplier")
            {
                if (e.KeyCode == Keys.Escape)
                {
                    AccountListView.Hide();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    AccountListView.Focus();
                }
                else
                {
                    GetSupplier();
                }
            }
            if (cmbAccType.Text == "Official")
            {
                if (e.KeyCode == Keys.Escape)
                {
                    AccountListView.Hide();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    AccountListView.Focus();
                }
                else
                {
                    GetAccount();
                }
            }
        }

        private void txtAccID_Click(object sender, EventArgs e)
        {
            if (cmbAccType.Text == "Supplier")
            {
                GetSupplier();
            }
            else if (cmbAccType.Text == "Customer")
            {
                GetCustomer();
            }
            else if (cmbAccType.Text == "Official")
            {
                GetAccount();
            }
        }

        private void AccountListView_Click(object sender, EventArgs e)
        {
            getSupplier_CustomerDue();
        }

        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccType.Text == "Customer" || cmbAccType.Text == "Supplier")
            {
                lblDue.Visible = true;
                groupboxDue.Visible = true;
            }
            else
            {
                lblDue.Visible = false;
                groupboxDue.Visible = false;
            }
        }

        private void clearform()
        {
            txtTrID.Text = aCashAccountBusiness.GenerateTrCode();
            cmbTrType.Text = "";
            cmbAccType.Text = "";
            txtAccID.Text = "";
            txtAccName.Text = "";
            txtDescription.Text = "";
            txtAmount.Text = "0";
            lblDue.Text = "";
            groupboxDue.Visible = false;
            lblDue.Visible = false;
            AccountListView.Hide();
            loadGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tbl_CashTransaction aTbl_CashTransaction = new Tbl_CashTransaction();
            try
            {

                aTbl_CashTransaction.Tr_Id = aCashAccountBusiness.GenerateTrCode();

                if (cmbTrType.Text == "Cash Receive")
                {
                    if (cmbAccType.Text == "Customer")
                    {
                        aTbl_CashTransaction.Customer_SlNo = acustomer.Customer_SlNo;
                        aTbl_CashTransaction.Acc_Code = acustomer.Customer_Code;
                        aTbl_CashTransaction.In_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.Out_Amount = 0;
                    }
                    else if (cmbAccType.Text == "Supplier")
                    {
                        aTbl_CashTransaction.Supplier_SlNo = aSupplier.Supplier_SlNo;
                        aTbl_CashTransaction.Acc_Code = aSupplier.Supplier_Code;
                        aTbl_CashTransaction.In_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.Out_Amount = 0;
                    }
                    else
                    {
                        aTbl_CashTransaction.Acc_SlNo = aAccount.Acc_SlNo;
                        aTbl_CashTransaction.Acc_Code = aAccount.Acc_Code;
                        aTbl_CashTransaction.In_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.Out_Amount = 0;
                    }
                }
                if (cmbTrType.Text == "Cash Payment")
                {
                    if (cmbAccType.Text == "Supplier")
                    {
                        aTbl_CashTransaction.Supplier_SlNo = aSupplier.Supplier_SlNo;
                        aTbl_CashTransaction.Acc_Code = aSupplier.Supplier_Code;
                        aTbl_CashTransaction.Out_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.In_Amount = 0;
                    }
                    else if (cmbAccType.Text == "Customer")
                    {
                        aTbl_CashTransaction.Customer_SlNo = acustomer.Customer_SlNo;
                        aTbl_CashTransaction.Acc_Code = acustomer.Customer_Code;
                        aTbl_CashTransaction.Out_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.In_Amount = 0;
                    }
                    else
                    {
                        aTbl_CashTransaction.Acc_SlNo = aAccount.Acc_SlNo;
                        aTbl_CashTransaction.Acc_Code = aAccount.Acc_Code;
                        aTbl_CashTransaction.Out_Amount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashTransaction.In_Amount = 0;
                    }
                }
                if (cmbTrType.Text == "Deposit To Bank" && cmbAccType.Text == "Official")
                {
                    aTbl_CashTransaction.Acc_SlNo = aAccount.Acc_SlNo;
                    aTbl_CashTransaction.Acc_Code = aAccount.Acc_Code;
                    aTbl_CashTransaction.Out_Amount = Convert.ToInt32(txtAmount.Text);
                    aTbl_CashTransaction.In_Amount = 0;
                }

                if (cmbTrType.Text == "Withdraw from Bank" && cmbAccType.Text == "Official")
                {
                    aTbl_CashTransaction.Acc_SlNo = aAccount.Acc_SlNo;
                    aTbl_CashTransaction.Acc_Code = aAccount.Acc_Code;
                    aTbl_CashTransaction.In_Amount = Convert.ToInt32(txtAmount.Text);
                    aTbl_CashTransaction.Out_Amount = 0;
                }

                aTbl_CashTransaction.Tr_Type = cmbTrType.Text;
                aTbl_CashTransaction.Tr_date = dtpDate.Value.Date;
                aTbl_CashTransaction.Tr_Description = txtDescription.Text;
                aTbl_CashTransaction.Status = "A";
                aTbl_CashTransaction.AddBy = SplashForm.username;
                aTbl_CashTransaction.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aCashAccountBusiness.validateOnSave(aTbl_CashTransaction);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    cmbTrType.Focus();
                    return;
                }
                if (cmbAccType.Text == "")
                {
                    MessageBox.Show("Select an Account Type !", "Warning");
                    return;
                }
                if (txtAccID.Text == "" || aTbl_CashTransaction.Acc_SlNo == 0)
                {
                    MessageBox.Show("Select an Account ID !", "Warning");
                    return;
                }
                if (txtAmount.Text == "0")
                {
                    MessageBox.Show("Enter Amount !", "Warning");
                    txtAmount.Focus();
                    return;
                }
                if ((MessageBox.Show("Do You Want To Save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                {
                    return;
                }
                bool res = aCashAccountBusiness.Insert(aTbl_CashTransaction);


                /// Insert into cash register

                List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                aTbl_CashRegister.Transaction_Date = dtpDate.Value.Date;

                if (cmbTrType.Text == "Cash Receive")
                {
                    if (cmbAccType.Text == "Customer")
                    {
                        aTbl_CashRegister.Narration = "Due Payment";
                        aTbl_CashRegister.InAmount = Convert.ToDecimal(txtAmount.Text);
                        aTbl_CashRegister.OutAmount = 0;
                    }
                    else
                    {
                        aTbl_CashRegister.Narration = txtAccName.Text;
                        aTbl_CashRegister.InAmount = Convert.ToDecimal(txtAmount.Text);
                        aTbl_CashRegister.OutAmount = 0;
                    }
                }

                if (cmbTrType.Text == "Cash Payment")
                {
                    if (cmbAccType.Text == "Supplier")
                    {
                        aTbl_CashRegister.Narration = "Due Payment";
                        aTbl_CashRegister.OutAmount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashRegister.InAmount = 0;
                    }
                    else if (cmbAccType.Text == "Customer")
                    {
                        aTbl_CashRegister.Narration = "Pay To Customer";
                        aTbl_CashRegister.OutAmount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashRegister.InAmount = 0;
                    }
                    else
                    {
                        aTbl_CashRegister.Narration = txtAccName.Text;
                        aTbl_CashRegister.OutAmount = Convert.ToInt32(txtAmount.Text);
                        aTbl_CashRegister.InAmount = 0;
                    }
                }

                if (cmbTrType.Text == "Deposit To Bank" && cmbAccType.Text == "Official")
                {
                    aTbl_CashRegister.Narration = "Deposit To Bank";
                    aTbl_CashRegister.OutAmount = Convert.ToInt32(txtAmount.Text);
                    aTbl_CashRegister.InAmount = 0;
                }

                if (cmbTrType.Text == "Withdraw from Bank" && cmbAccType.Text == "Official")
                {
                    aTbl_CashRegister.Narration = "Withdraw from Bank";
                    aTbl_CashRegister.InAmount = Convert.ToInt32(txtAmount.Text);
                    aTbl_CashRegister.OutAmount = 0;
                }

                aTbl_CashRegister.IdentityNo = txtTrID.Text;
                aTbl_CashRegister.Status = "A";
                aTbl_CashRegister.Description = txtDescription.Text;
                aTbl_CashRegister.Saved_By = SplashForm.username;
                aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);

                /// end

                if (res)
                {
                    clearform();

                    UtilityBusiness.DisplayAlertMessage('S', "Inserted Successfully.");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Inserted Failed.");
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_CashTransaction = null;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //if ((cmbTrType.Text == "Cash Receive" && cmbAccType.Text == "Customer") || (cmbTrType.Text == "Cash Payment" && cmbAccType.Text=="Supplier"))
            //{
            //    if (Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(lblDue.Text))
            //    {
            //        MessageBox.Show("Amount Can't Be Greater Than Due !","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        txtAmount.Focus();
            //        return;
            //    }
            //}

            //}
            //catch
            //{
            //}
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
                UtilityBusiness.DisplayAlertMessage('W', "Enter Number");
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                UtilityBusiness.DisplayAlertMessage('W', "Enter Number");
            }
            base.OnKeyPress(e);
        }

        private void cmbTrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrType.Text == "Deposit To Bank" || cmbTrType.Text == "Withdraw from Bank")
            {
                cmbAccType.Text = "Official";
            }
        }

        private void dgvCashAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedIndex = e.RowIndex;
                txtTrID.Text = lstQryCashTransactionList[selectedIndex].Tr_Id;
                cmbTrType.Text = lstQryCashTransactionList[selectedIndex].Tr_Type;
                
                //if (lstQryCashTransactionList[selectedIndex].Acc_Type == "Customer")
                //{
                //    cmbAccType.Text = "Customer";
                //}
                //else if (lstQryCashTransactionList[selectedIndex].Acc_Type == "Official")
                //{
                //    cmbAccType.Text = "Official";
                //}
                //else
                //{
                //    cmbAccType.Text = "Supplier";
                //}

                txtAccID.Text = lstQryCashTransactionList[selectedIndex].Acc_Code;
                AccountListView.Visible = false;
                txtAccName.Text = lstQryCashTransactionList[selectedIndex].Acc_Name;
                txtDescription.Text = lstQryCashTransactionList[selectedIndex].Tr_Description;

                if (cmbTrType.Text == "Cash Receive" || cmbTrType.Text == "Withdraw from Bank")
                {
                    txtAmount.Text = Math.Round(lstQryCashTransactionList[selectedIndex].In_Amount, 2).ToString();
                }
                if (cmbTrType.Text == "Cash Payment" || cmbTrType.Text == "Deposit To Bank")
                {
                    txtAmount.Text = Math.Round(lstQryCashTransactionList[selectedIndex].Out_Amount, 2).ToString();
                }
                dtpDate.Value = lstQryCashTransactionList[selectedIndex].Tr_date;
            }
            catch
            {
            }
        }

        private void getSupplier_CustomerDue()
        {
            try
            {
                if (cmbAccType.Text == "Supplier")
                {
                    aSupplier = (Qry_Supplier)AccountListView.SelectedItems[0].Tag;
                    txtAccID.Text = aSupplier.Supplier_Code;
                    txtAccName.Text = aSupplier.Supplier_Name;

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
                    lblDue.Text = Math.Round(result, 2).ToString();

                    AccountListView.Visible = false;
                    txtAmount.Focus();
                }
                if (cmbAccType.Text == "Customer")
                {
                    acustomer = (Qry_Customer)AccountListView.SelectedItems[0].Tag;
                    txtAccID.Text = acustomer.Customer_Code;
                    txtAccName.Text = acustomer.Customer_Name;

                    // get customerdue
                    decimal salesedue = 0;
                    decimal paidamt = 0;
                    decimal paytoCustomer = 0;
                    decimal result = 0;
                    List<Tbl_SalesMaster> lstMasterList = aSalesBusiness.GetAllSaleMasterByCustomer(acustomer.Customer_SlNo);
                    if (lstMasterList.Any())
                    {
                        salesedue = lstMasterList.Where(x => x.SaleMaster_DueAmount > 0).Sum(y => y.SaleMaster_DueAmount);

                        List<Tbl_CashTransaction> lstCashAccountCustomerDueList = aCashAccountBusiness.GetAllCashAccountByCustomer(acustomer.Customer_SlNo);
                        if (lstCashAccountCustomerDueList.Any())
                        {
                            paidamt = lstCashAccountCustomerDueList.Sum(x => x.In_Amount);
                            paytoCustomer = lstCashAccountCustomerDueList.Sum(x => x.Out_Amount);
                        }
                    }
                    result = (salesedue + paytoCustomer) - paidamt;
                    lblDue.Text = Math.Round(result, 2).ToString();

                    AccountListView.Visible = false;
                    txtAmount.Focus();
                }
                if (cmbAccType.Text == "Official")
                {
                    aAccount = (Tbl_Account)AccountListView.SelectedItems[0].Tag;
                    txtAccID.Text = aAccount.Acc_Code;
                    txtAccName.Text = aAccount.Acc_Name;
                    AccountListView.Visible = false;
                    txtAmount.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void AccountListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                getSupplier_CustomerDue();
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AccountSetting ob = new AccountSetting();
            ob.ShowDialog();
        }

        private void dgvCashAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstQryCashTransactionList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsCashTransaction.Visible = true;
                    cmsCashTransaction.Items.Clear();
                    cmsCashTransaction.Items.Add("Print");
                    cmsCashTransaction.Show(dgvCashAccount, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsCashTransaction_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsCashTransaction.Visible = false;
            if (e.ClickedItem.Text == "Print")
            {
                //lstCashTransactionList[selectedIndex].ProductCategory_SlNo;
                try
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstTransaction = aCashAccountBusiness.Get_Cash_TransactionByCode(lstQryCashTransactionList[selectedIndex].Tr_Id).ToList();
                    Reports.CRIndividualTransaction rpt = new Reports.CRIndividualTransaction();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    //define parameter fields....
                    ParameterFields paramFields = new ParameterFields();

                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();
                    //objParameterField.Name = "StartDate";
                    //objDiscreteValue.Value = dateTimePickerstart.Value;
                    //objParameterField.CurrentValues.Add(objDiscreteValue);
                    //paramFields.Add(objParameterField);

                    //objDiscreteValue = new ParameterDiscreteValue();
                    //objParameterField = new ParameterField();
                    //objParameterField.Name = "EndDate";
                    //objDiscreteValue.Value = dateTimePickerend.Value;
                    //objParameterField.CurrentValues.Add(objDiscreteValue);
                    //paramFields.Add(objParameterField);

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(lstTransaction);
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
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearform();
        }



    }
}
