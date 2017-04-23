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

namespace IMS_Win
{
    public partial class AccountSetting : Form
    {
        AccountBusiness aAccountBusiness = new AccountBusiness();
        int selectedIndex = 0;
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();

        List<Tbl_Account> lstAccountList = new List<Tbl_Account>();
        public AccountSetting()
        {
            InitializeComponent();
            
        }

        void LoadGrid()
        {
            dgvAccount.AutoGenerateColumns = false;
            lstAccountList = aAccountBusiness.GetAllAccount().Where(x=>x.Acc_Type=="Official").ToList();
            dgvAccount.DataSource = lstAccountList;

        }

        private void AccountSetting_Load(object sender, EventArgs e)
        {
            cmbAccountType.SelectedItem = cmbAccountType.Items[0];
            txtAccountID.Text = aAccountBusiness.GenerateCustomerCode();
            LoadGrid();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        void setnew()
        {
            LoadGrid();
            txtAccName.Text = string.Empty;
            txtAccDescription.Text = string.Empty;
            //cmbAccountType.Text = "";
            txtAccountID.Text = aAccountBusiness.GenerateCustomerCode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Account aTbl_Account = new Tbl_Account();
            try
            {
                aTbl_Account.Acc_Code = txtAccountID.Text;
                aTbl_Account.Acc_Name = txtAccName.Text;
                aTbl_Account.Acc_Type = cmbAccountType.Text;
                aTbl_Account.Acc_Description = txtAccDescription.Text;
                aTbl_Account.Status = "A";
                aTbl_Account.AddBy = SplashForm.username;
                aTbl_Account.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aAccountBusiness.validateOnSave(aTbl_Account);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aAccountBusiness.Insert(aTbl_Account);
                if (res)
                {
                    setnew();
                    UtilityBusiness.DisplayAlertMessage('S', "Inserted Successfully");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Inserted Failed");
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_Account = null;
                txtAccName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtAccName.Text = string.Empty;
            txtAccDescription.Text = string.Empty;
            cmbAccountType.Text = "Official";

            txtAccountID.Text = aAccountBusiness.GenerateCustomerCode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Account aTbl_Account = lstAccountList[selectedIndex];
            string code = lstAccountList[selectedIndex].Acc_Code;

            try
            {
                aTbl_Account.Acc_Name = txtAccName.Text;
                aTbl_Account.Acc_Type = cmbAccountType.Text;
                aTbl_Account.Acc_Description = txtAccDescription.Text;
                aTbl_Account.Status = "A";
                aTbl_Account.UpdateBy = SplashForm.username;
                aTbl_Account.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aAccountBusiness.validateOnUpdate(aTbl_Account);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aAccountBusiness.Update(aTbl_Account);
                if (res)
                {
                    //update in tbl_customer
                    List<Tbl_Customer> lstTbl_Customer = new List<Tbl_Customer>();
                    lstTbl_Customer = aCustomerBusiness.GetAllCustomer().Where(x => x.Customer_Code == code).ToList();
                    if (lstTbl_Customer.Any())
                    {
                        Tbl_Customer aTbl_Customer = lstTbl_Customer.FirstOrDefault();
                        aTbl_Customer.Customer_Name = txtAccName.Text;
                        aTbl_Customer.UpdateBy = SplashForm.username;
                        aTbl_Customer.UpdateTime = DateTime.UtcNow.AddHours(6);

                        aCustomerBusiness.Update(aTbl_Customer);
                    }
                    //

                    //update in tbl_supplier
                    List<Tbl_Supplier> lstTbl_Supplier = new List<Tbl_Supplier>();
                    lstTbl_Supplier = aSupplierBusiness.GetAllSupplier().Where(x => x.Supplier_Code == code).ToList();
                    if (lstTbl_Supplier.Any())
                    {
                        Tbl_Supplier aTbl_Supplier = lstTbl_Supplier.FirstOrDefault();
                        aTbl_Supplier.Supplier_Name = txtAccName.Text;
                        aTbl_Supplier.UpdateBy = SplashForm.username;
                        aTbl_Supplier.UpdateTime = DateTime.UtcNow.AddHours(6);

                        aSupplierBusiness.Update(aTbl_Supplier);
                    }
                    //

                    setnew();
                    btnAdd.Visible = true;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    UtilityBusiness.DisplayAlertMessage('S', "Updated Successfully");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Updated Failed");
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_Account = null;
                txtAccName.Focus();
            }
        }

        private void dgvAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstAccountList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsAccountSettings.Visible = true;
                    cmsAccountSettings.Items.Clear();
                    cmsAccountSettings.Items.Add("Edit");
                    cmsAccountSettings.Items.Add("Delete");
                    cmsAccountSettings.Show(dgvAccount, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsAccountSettings_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsAccountSettings.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtAccountID.Text = lstAccountList[selectedIndex].Acc_Code;
                txtAccName.Text = lstAccountList[selectedIndex].Acc_Name;
                cmbAccountType.Text = lstAccountList[selectedIndex].Acc_Type;
                txtAccDescription.Text = lstAccountList[selectedIndex].Acc_Description;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_Account aTbl_Account = lstAccountList[selectedIndex];
                    try
                    {
                        int id = lstAccountList[selectedIndex].Acc_SlNo;
                        string code = lstAccountList[selectedIndex].Acc_Code;

                        //existance checked by id
                        List<Tbl_CashTransaction> lstCashTransaction = new List<Tbl_CashTransaction>();
                        lstCashTransaction = aCashAccountBusiness.GetAllAccountByTransaction(id);
                        if (lstCashTransaction.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //existance checked by code
                        List<Tbl_CashTransaction> lstTbl_CashTransaction1 = new List<Tbl_CashTransaction>();
                        lstTbl_CashTransaction1 = aCashAccountBusiness.GetAllCashTransaction().Where(x => x.Acc_Code == code).ToList();
                        if (lstTbl_CashTransaction1.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //

                        aTbl_Account.Status = "D";
                        aTbl_Account.UpdateBy = SplashForm.username;
                        aTbl_Account.UpdateTime = DateTime.UtcNow.AddHours(6);

                        bool res = aAccountBusiness.Update(aTbl_Account);
                        if (res)
                        {
                            //delete from tbl_customer
                            List<Tbl_Customer> lstTbl_Customer = new List<Tbl_Customer>();
                            lstTbl_Customer = aCustomerBusiness.GetAllCustomer().Where(x => x.Customer_Code == code).ToList();
                            if (lstTbl_Customer.Any())
                            {
                                Tbl_Customer aTbl_Customer = lstTbl_Customer.FirstOrDefault();
                                aTbl_Customer.Status = "D";
                                aTbl_Customer.UpdateBy = SplashForm.username;
                                aTbl_Customer.UpdateTime = DateTime.UtcNow.AddHours(6);

                                aCustomerBusiness.Update(aTbl_Customer);
                            }
                            //

                            //delete from tbl_supplier
                            List<Tbl_Supplier> lstTbl_Supplier = new List<Tbl_Supplier>();
                            lstTbl_Supplier = aSupplierBusiness.GetAllSupplier().Where(x => x.Supplier_Code == code).ToList();
                            if (lstTbl_Supplier.Any())
                            {
                                Tbl_Supplier aTbl_Supplier = lstTbl_Supplier.FirstOrDefault();
                                aTbl_Supplier.Status = "D";
                                aTbl_Supplier.UpdateBy = SplashForm.username;
                                aTbl_Supplier.UpdateTime = DateTime.UtcNow.AddHours(6);

                                aSupplierBusiness.Update(aTbl_Supplier);
                            }
                            //

                            setnew();
                            txtAccountID.Text = aAccountBusiness.GenerateCustomerCode();
                            UtilityBusiness.DisplayAlertMessage('S', "Deleted Successfully");
                        }
                        else
                        {
                            UtilityBusiness.DisplayAlertMessage('E', "Deleted Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        UtilityBusiness.DisplayAlertMessage('E', ex.Message);
                    }
                    finally
                    {
                        aTbl_Account = null;
                        txtAccName.Focus();
                    }
                }
            }
        }

        
    }
}
