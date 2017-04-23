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
    public partial class SupplierForm : Form
    {
        CountryBusiness aCountryBisiness = new CountryBusiness();
        AccountBusiness aAccountBusiness = new AccountBusiness();
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();

        int selectedIndex = 0;
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        List<Tbl_Supplier> lstSupplierList = new List<Tbl_Supplier>();
        public SupplierForm()
        {
            InitializeComponent();
        }

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

        private void GetCountryForComboBox()
        {
            try
            {
                cmbCountry.DataSource = null;
                cmbCountry.DisplayMember = "CountryName";
                cmbCountry.ValueMember = "Country_SlNo";
                cmbCountry.DataSource = aCountryBisiness.GetAllCountry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadGrid()
        {
            dgvSupplier.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplier();
            dgvSupplier.DataSource = lstSupplierList;
        }

        void AddSupplier()
        {
            Tbl_Supplier aTbl_Supplier = new Tbl_Supplier();
            try
            {
                aTbl_Supplier.Supplier_Code = aSupplierBusiness.GenerateSupplierCode();
                aTbl_Supplier.Supplier_Name = txtSupplierName.Text;
                if (localRadioButton.Checked == true)
                {
                    aTbl_Supplier.Supplier_Type = "Local";
                }
                else
                {
                    aTbl_Supplier.Supplier_Type = "Foreign";
                }
                aTbl_Supplier.Supplier_Address = txtaddress.Text;
                aTbl_Supplier.District_SlNo = Convert.ToInt16(cmbDistrict.SelectedValue);
                aTbl_Supplier.Country_SlNo = Convert.ToInt16(cmbCountry.SelectedValue);
                aTbl_Supplier.Supplier_Phone = txtPhone.Text;
                aTbl_Supplier.Supplier_Mobile = txtMobile.Text;
                aTbl_Supplier.Supplier_OfficePhone = txtofficephone.Text;
                aTbl_Supplier.Supplier_Email = txtemail.Text;
                aTbl_Supplier.Supplier_Web = txtweb.Text;
                aTbl_Supplier.Status = "A";
                aTbl_Supplier.AddBy = SplashForm.username;
                aTbl_Supplier.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aSupplierBusiness.validateOnSave(aTbl_Supplier);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtSupplierName.Focus();
                    return;
                }
                if (txtaddress.Text == "")
                {
                    MessageBox.Show("Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtaddress.Focus();
                    return;
                }
                if (aTbl_Supplier.District_SlNo == 0 )
                {
                    MessageBox.Show("Select a District", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDistrict.Focus();
                    return;
                }
                if (aTbl_Supplier.Country_SlNo == 0)
                {
                    MessageBox.Show("Select a Country", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCountry.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("Enter Contact No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobile.Focus();
                    return;
                }
                bool res = aSupplierBusiness.Insert(aTbl_Supplier);

                //create new account for transaction

                Tbl_Account aTbl_Account = new Tbl_Account();

                aTbl_Account.Acc_Code = txtSupplierCode.Text;
                aTbl_Account.Acc_Name = txtSupplierName.Text;
                aTbl_Account.Acc_Type = "Supplier";
                aTbl_Account.Acc_Description = "";
                aTbl_Account.Status = "A";
                aTbl_Account.AddBy = SplashForm.username;
                aTbl_Account.AddTime = DateTime.UtcNow.AddHours(6);

                string msg1 = aAccountBusiness.validateOnSave(aTbl_Account);
                if (msg1 != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                aAccountBusiness.Insert(aTbl_Account);
                ///
                
                
                if (res)
                {
                    SetNew();
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
                aTbl_Supplier = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSupplier();  
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Supplier aTbl_Supplier = lstSupplierList[selectedIndex];
            try
            {
                aTbl_Supplier.Supplier_Name = txtSupplierName.Text;
                if (localRadioButton.Checked == true)
                {
                    aTbl_Supplier.Supplier_Type = "Local";
                }
                else
                {
                    aTbl_Supplier.Supplier_Type = "Foreign";
                }
                aTbl_Supplier.Supplier_Address = txtaddress.Text;
                aTbl_Supplier.District_SlNo = Convert.ToInt16(cmbDistrict.SelectedValue);
                aTbl_Supplier.Country_SlNo = Convert.ToInt16(cmbCountry.SelectedValue);
                aTbl_Supplier.Supplier_Phone = txtPhone.Text;
                aTbl_Supplier.Supplier_Mobile = txtMobile.Text;
                aTbl_Supplier.Supplier_OfficePhone = txtofficephone.Text;
                aTbl_Supplier.Supplier_Email = txtemail.Text;
                aTbl_Supplier.Supplier_Web = txtweb.Text;
                aTbl_Supplier.Status = "A";
                aTbl_Supplier.UpdateBy = SplashForm.username;
                aTbl_Supplier.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aSupplierBusiness.validateOnUpdate(aTbl_Supplier);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtSupplierName.Focus();
                    return;
                }
                if (aTbl_Supplier.District_SlNo == 0 || cmbDistrict.Text == "")
                {
                    MessageBox.Show("Select an Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDistrict.Focus();
                    return;
                }
                if (aTbl_Supplier.Country_SlNo == 0 || cmbCountry.Text == "")
                {
                    MessageBox.Show("Select a Country", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCountry.Focus();
                    return;
                }
                if (txtaddress.Text == "")
                {
                    MessageBox.Show("Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtaddress.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("Enter Contact No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobile.Focus();
                    return;
                }
                bool res = aSupplierBusiness.Update(aTbl_Supplier);
                if (res)
                {
                    //update in tbl_account
                    string code = lstSupplierList[selectedIndex].Supplier_Code;
                    List<Tbl_Account> lstTbl_Account = new List<Tbl_Account>();
                    lstTbl_Account = aAccountBusiness.GetAllAccount().Where(x => x.Acc_Code == code).ToList();
                    if (lstTbl_Account.Any())
                    {
                        Tbl_Account aTbl_Account = lstTbl_Account.FirstOrDefault();
                        aTbl_Account.Acc_Name = txtSupplierName.Text;
                        aTbl_Account.UpdateBy = SplashForm.username;
                        aTbl_Account.UpdateTime = DateTime.UtcNow.AddHours(6);

                        aAccountBusiness.Update(aTbl_Account);
                    }
                    //
                    
                    SetNew();
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
                aTbl_Supplier = null;
            }
        }

        private void SetNew()
        {
            txtSupplierName.Text = "";
            txtaddress.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtofficephone.Text = "";
            txtemail.Text = "";
            txtweb.Text = "";
            localRadioButton.Checked = true;
            foreignRadioButton.Checked = false;
            txtSupplierName.Focus();
            
            GenerateCode();
            LoadGrid();
            GetDistrictsForComboBox();
            GetCountryForComboBox();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetNew();
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        private void supplierNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                localRadioButton.Focus();
            }
            if (e.KeyChar == (Char)Keys.Escape)
            {
                Close();
            }
        }

        private void localRadioButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtaddress.Focus();
            }
            if (e.KeyChar == (Char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                localRadioButton.Focus();
            }
        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                cmbCountry.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                cmbCountry.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtaddress.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMobile.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtMobile.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbCountry.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtofficephone.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtofficephone.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtPhone.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtofficephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtemail.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtemail.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtMobile.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtweb.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtweb.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtofficephone.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtweb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtemail.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if(e.KeyCode==Keys.Enter)
            {
                AddSupplier();
            }
        }

        void GenerateCode()
        {
            txtSupplierCode.Text = aSupplierBusiness.GenerateSupplierCode();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            SetNew();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvSupplier_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstSupplierList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsSupplier.Visible = true;
                    cmsSupplier.Items.Clear();
                    cmsSupplier.Items.Add("Edit");
                    cmsSupplier.Items.Add("Delete");
                    cmsSupplier.Show(dgvSupplier, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsSupplier_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsSupplier.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtSupplierName.Text = lstSupplierList[selectedIndex].Supplier_Name;
                txtaddress.Text = lstSupplierList[selectedIndex].Supplier_Address;
                if (lstSupplierList[selectedIndex].Supplier_Type == "Local")
                {
                    localRadioButton.Checked = true;
                    foreignRadioButton.Checked = false;
                }
                else
                {
                    foreignRadioButton.Checked = true;
                    localRadioButton.Checked = false;
                }
                cmbDistrict.SelectedValue = lstSupplierList[selectedIndex].District_SlNo;
                cmbCountry.SelectedValue = lstSupplierList[selectedIndex].Country_SlNo;
                txtPhone.Text = lstSupplierList[selectedIndex].Supplier_Phone;
                txtMobile.Text = lstSupplierList[selectedIndex].Supplier_Mobile;
                txtofficephone.Text = lstSupplierList[selectedIndex].Supplier_OfficePhone;
                txtemail.Text = lstSupplierList[selectedIndex].Supplier_Email;
                txtweb.Text = lstSupplierList[selectedIndex].Supplier_Web;

                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_Supplier aTbl_Supplier = lstSupplierList[selectedIndex];
                    try
                    {
                        int id = lstSupplierList[selectedIndex].Supplier_SlNo;
                        string code = lstSupplierList[selectedIndex].Supplier_Code;

                        List<Tbl_PurchaseMaster> lstPurchaseMaster = new List<Tbl_PurchaseMaster>();
                        lstPurchaseMaster = aPurchaseBusiness.GetAllPurchaseMasterBySupplier(id);
                        if (lstPurchaseMaster.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<Tbl_CashTransaction> lstTbl_CashTransaction = new List<Tbl_CashTransaction>();
                        lstTbl_CashTransaction = aCashAccountBusiness.GetAllCashTransaction().Where(x => x.Acc_Code == code).ToList();
                        if (lstTbl_CashTransaction.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        aTbl_Supplier.Status = "D";
                        aTbl_Supplier.UpdateBy = SplashForm.username;
                        aTbl_Supplier.UpdateTime = DateTime.UtcNow.AddHours(6);

                        bool res = aSupplierBusiness.Update(aTbl_Supplier);
                        if (res)
                        {
                            //delete from tbl_account
                            List<Tbl_Account> lstTbl_Account = new List<Tbl_Account>();
                            lstTbl_Account = aAccountBusiness.GetAllAccount().Where(x => x.Acc_Code == code).ToList();
                            if (lstTbl_Account.Any())
                            {
                                Tbl_Account aTbl_Account = lstTbl_Account.FirstOrDefault();
                                aTbl_Account.Status = "D";
                                aTbl_Account.UpdateBy = SplashForm.username;
                                aTbl_Account.UpdateTime = DateTime.UtcNow.AddHours(6);

                                aAccountBusiness.Update(aTbl_Account);
                            }
                            //
                            
                            SetNew();                            
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
                        aTbl_Supplier = null;
                        txtSupplierName.Focus();
                    }
                }
            }
        }

        private void localRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                txtaddress.Focus();
            }
            if(e.KeyCode==Keys.Up)
            {
                txtSupplierName.Focus();
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            CountryForm ob = new CountryForm();
            ob.ShowDialog();
            GetCountryForComboBox();
        }

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictEntryForm ob = new DistrictEntryForm();
            ob.ShowDialog();
            GetDistrictsForComboBox();
        }

        private void cmbDistrict_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCountry.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

    }
}
