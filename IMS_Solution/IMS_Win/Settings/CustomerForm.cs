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
    public partial class CustomerForm : Form
    {
        CountryBusiness aCountryBusiness = new CountryBusiness();
        AccountBusiness aAccountBusiness = new AccountBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();

        int selectedIndex = 0;
        SalesBusiness aSalesBusiness = new SalesBusiness();
        List<Tbl_Customer> lstCustomerList = new List<Tbl_Customer>();
        Tbl_Customer aTbl_Customer = new Tbl_Customer();
        
        public CustomerForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvCustomer.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllCustomer();
            dgvCustomer.DataSource = lstCustomerList;
        }

        void GenerateCode()
        {
            txtCustomerCode.Text = aCustomerBusiness.GenerateCustomerCode();
        }

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                localRadioButton.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void localRadioButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAddress.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Down)
            {
                localRadioButton.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
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

        private void txtWebsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==27)
            {
                Close();
            }
            if(e.KeyChar==13)
            {
                AddCustomer();
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOfficePhone.Focus();
            }
            if(e.KeyCode==Keys.Up)
            {
                txtPhone.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtOfficePhone.Focus();
            }
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                localRadioButton.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                cmbCountry.Focus();
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

        private void txtOfficePhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtMobile.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtEmail.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWebsite.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtOfficePhone.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtWebsite.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                txtEmail.Focus();
            }
            if(e.KeyCode==Keys.Down)
            {
                txtCreditLimit.Focus();
            }
            if(e.KeyCode==Keys.Enter)
            {
                txtCreditLimit.Focus();
            }
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerName.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtCustomerName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        
        private void GetCountryForComboBox()
        {
            try
            {
                cmbCountry.DataSource = null;
                cmbCountry.DisplayMember = "CountryName";
                cmbCountry.ValueMember = "Country_SlNo";
                cmbCountry.DataSource = aCountryBusiness.GetAllCountry();
                //cmbCountry.SelectedItem = cmbCountry.Items[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void SetNew()
        {
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtOfficePhone.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
            txtCreditLimit.Text = "0";
            cmbCountry.SelectedValue = 0;
            cmbDistrict.SelectedValue = 0;
            localRadioButton.Checked = true;
            foreignRadioButton.Checked = false;
            txtCustomerName.Focus();

            GenerateCode();
            LoadGrid();
            GetCountryForComboBox();
            GetDistrictsForComboBox();
        }

        void AddCustomer()
        {
            aTbl_Customer = new Tbl_Customer();
            try
            {
                aTbl_Customer.Customer_Code = aCustomerBusiness.GenerateCustomerCode();
                aTbl_Customer.Customer_Name = txtCustomerName.Text;
                if (localRadioButton.Checked == true)
                {
                    aTbl_Customer.Customer_Type = "Local";
                }
                else
                {
                    aTbl_Customer.Customer_Type = "Foreign";
                }
                aTbl_Customer.Customer_Address = txtAddress.Text;
                aTbl_Customer.Country_SlNo = Convert.ToInt16(cmbCountry.SelectedValue);
                aTbl_Customer.District_SlNo = Convert.ToInt16(cmbDistrict.SelectedValue);
                aTbl_Customer.Customer_Phone = txtPhone.Text;
                aTbl_Customer.Customer_Mobile = txtMobile.Text;
                aTbl_Customer.Customer_OfficePhone = txtOfficePhone.Text;
                aTbl_Customer.Customer_Email = txtEmail.Text;
                aTbl_Customer.Customer_Web = txtWebsite.Text;
                aTbl_Customer.Customer_Credit_Limit = Convert.ToDecimal(txtCreditLimit.Text);
                aTbl_Customer.Status = "A";
                aTbl_Customer.AddBy = SplashForm.username;
                aTbl_Customer.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aCustomerBusiness.validateOnSave(aTbl_Customer);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtCustomerName.Focus();
                    return;
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Enter Address", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }
                if (aTbl_Customer.Country_SlNo == 0 || cmbCountry.Text == "")
                {
                    MessageBox.Show("Select a Country", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCountry.Focus();
                    return;
                }
                if (aTbl_Customer.District_SlNo == 0 || cmbDistrict.Text == "")
                {
                    MessageBox.Show("Select an Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDistrict.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("Enter Contact No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobile.Focus();
                    return;
                }

                bool res = aCustomerBusiness.Insert(aTbl_Customer);

                //create new account for transaction

                Tbl_Account aTbl_Account = new Tbl_Account();
           
                aTbl_Account.Acc_Code = txtCustomerCode.Text;
                aTbl_Account.Acc_Name = txtCustomerName.Text;
                aTbl_Account.Acc_Type = "Customer";
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
                //

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
                aTbl_Customer = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomer();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {        
            Tbl_Customer aTbl_Customer = lstCustomerList[selectedIndex];

            try
            {
                aTbl_Customer.Customer_Name = txtCustomerName.Text;
                if(localRadioButton.Checked==true)
                {
                    aTbl_Customer.Customer_Type = "Local";
                }
                else
                {
                    aTbl_Customer.Customer_Type = "Foreign";
                }
                aTbl_Customer.Customer_Address = txtAddress.Text;
                aTbl_Customer.Country_SlNo = Convert.ToInt16(cmbCountry.SelectedValue);
                aTbl_Customer.District_SlNo = Convert.ToInt16(cmbDistrict.SelectedValue);
                aTbl_Customer.Customer_Phone = txtPhone.Text;
                aTbl_Customer.Customer_Mobile = txtMobile.Text;
                aTbl_Customer.Customer_OfficePhone = txtOfficePhone.Text;
                aTbl_Customer.Customer_Email = txtEmail.Text;
                aTbl_Customer.Customer_Web = txtWebsite.Text;
                aTbl_Customer.Customer_Credit_Limit = Convert.ToDecimal(txtCreditLimit.Text);
                aTbl_Customer.Status = "A";
                aTbl_Customer.UpdateBy = SplashForm.username;
                aTbl_Customer.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aCustomerBusiness.validateOnUpdate(aTbl_Customer);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtCustomerName.Focus();
                    return;
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (aTbl_Customer.District_SlNo == 0 || cmbDistrict.Text == "")
                {
                    MessageBox.Show("Select an Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDistrict.Focus();
                    return;
                }

                if (aTbl_Customer.Country_SlNo == 0 || cmbCountry.Text == "")
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

                bool res = aCustomerBusiness.Update(aTbl_Customer);
                if (res)
                {
                    //update in tbl_account
                    string code = lstCustomerList[selectedIndex].Customer_Code;
                    List<Tbl_Account> lstTbl_Account = new List<Tbl_Account>();
                    lstTbl_Account = aAccountBusiness.GetAllAccount().Where(x => x.Acc_Code == code).ToList();
                    if (lstTbl_Account.Any())
                    {
                        Tbl_Account aTbl_Account = lstTbl_Account.FirstOrDefault();
                        aTbl_Account.Acc_Name = txtCustomerName.Text;
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
                aTbl_Customer = null; 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetNew();
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstCustomerList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsCustomer.Visible = true;
                    cmsCustomer.Items.Clear();
                    cmsCustomer.Items.Add("Edit");
                    cmsCustomer.Items.Add("Delete");
                    cmsCustomer.Show(dgvCustomer, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsCustomer_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                cmsCustomer.Visible = false;
                if (e.ClickedItem.Text == "Edit")
                {
                    txtCustomerCode.Text = lstCustomerList[selectedIndex].Customer_Code;
                    txtCustomerName.Text = lstCustomerList[selectedIndex].Customer_Name;
                    if (lstCustomerList[selectedIndex].Customer_Type == "Local")
                    {
                        localRadioButton.Checked = true;
                        foreignRadioButton.Checked = false;
                    }
                    else
                    {
                        foreignRadioButton.Checked = true;
                        localRadioButton.Checked = false;
                    }
                    txtAddress.Text = lstCustomerList[selectedIndex].Customer_Address;
                    cmbCountry.SelectedValue = lstCustomerList[selectedIndex].Country_SlNo;
                    cmbDistrict.SelectedValue = lstCustomerList[selectedIndex].District_SlNo;
                    txtPhone.Text = lstCustomerList[selectedIndex].Customer_Phone;
                    txtMobile.Text = lstCustomerList[selectedIndex].Customer_Mobile;
                    txtOfficePhone.Text = lstCustomerList[selectedIndex].Customer_OfficePhone;
                    txtEmail.Text = lstCustomerList[selectedIndex].Customer_Email;
                    txtWebsite.Text = lstCustomerList[selectedIndex].Customer_Web;
                    txtCreditLimit.Text = Math.Round(lstCustomerList[selectedIndex].Customer_Credit_Limit,2).ToString();
                    btnAdd.Visible = false;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Tbl_Customer aTbl_Customer = lstCustomerList[selectedIndex];
                        try
                        {
                            int id = lstCustomerList[selectedIndex].Customer_SlNo;
                            string code = lstCustomerList[selectedIndex].Customer_Code;

                            List<Tbl_SalesMaster> lstSalesMaster = new List<Tbl_SalesMaster>();
                            lstSalesMaster = aSalesBusiness.GetAllSaleMasterByCustomer(id);
                            if (lstSalesMaster.Any())
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

                            aTbl_Customer.Status = "D";
                            aTbl_Customer.UpdateBy = SplashForm.username;
                            aTbl_Customer.UpdateTime = DateTime.UtcNow.AddHours(6);

                            bool res = aCustomerBusiness.Update(aTbl_Customer);
                            
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
                            aTbl_Customer = null;
                            SetNew();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            SetNew();
        }

        private void txtMobile_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtOfficePhone.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtOfficePhone.Focus();
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

        private void localRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                txtAddress.Focus();
            }
            if(e.KeyCode==Keys.Up)
            {
                txtCustomerName.Focus();
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            CountryForm ob = new CountryForm();
            ob.Show();
        }

        private void btnAddCountry_Click_1(object sender, EventArgs e)
        {
            CountryForm ob = new CountryForm();
            ob.ShowDialog();
            GetCountryForComboBox();
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtWebsite.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictEntryForm ob = new DistrictEntryForm();
            ob.ShowDialog();
            GetDistrictsForComboBox();
        }

    }
}
