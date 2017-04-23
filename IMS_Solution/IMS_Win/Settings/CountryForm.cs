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
    public partial class CountryForm : Form
    {
        CountryBusiness aCountryBusiness = new CountryBusiness();
        int selectedIndex = 0;
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        List<Tbl_Country> lstCountryList = new List<Tbl_Country>();
        public CountryForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvCountry.AutoGenerateColumns = false;
            lstCountryList = aCountryBusiness.GetAllCountry();
            dgvCountry.DataSource = lstCountryList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtCountry.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Country aTbl_Country = new Tbl_Country();
            try
            {
                aTbl_Country.CountryName = txtCountry.Text;
                aTbl_Country.Status = "A";
                aTbl_Country.AddBy = SplashForm.username;
                aTbl_Country.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aCountryBusiness.validateOnSave(aTbl_Country);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aCountryBusiness.Insert(aTbl_Country);
                if (res)
                {
                    LoadGrid();
                    txtCountry.Text = string.Empty;
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
                aTbl_Country = null;
                txtCountry.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Country aTbl_Country = lstCountryList[selectedIndex];
            try
            {
                aTbl_Country.CountryName = txtCountry.Text;
                aTbl_Country.Status = "A";
                aTbl_Country.UpdateBy = SplashForm.username;
                aTbl_Country.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aCountryBusiness.validateOnUpdate(aTbl_Country);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aCountryBusiness.Update(aTbl_Country);
                if (res)
                {
                    LoadGrid();
                    txtCountry.Text = string.Empty;
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
                aTbl_Country = null;
                txtCountry.Focus();
            }
        }

        private void dgvCountry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvCountry_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstCountryList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsCountry.Visible = true;
                    cmsCountry.Items.Clear();
                    cmsCountry.Items.Add("Edit");
                    cmsCountry.Items.Add("Delete");
                    cmsCountry.Show(dgvCountry, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsCountry_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsCountry.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtCountry.Text = lstCountryList[selectedIndex].CountryName;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_Country aTbl_Country = lstCountryList[selectedIndex];
                    try
                    {
                        int id = lstCountryList[selectedIndex].Country_SlNo;
                        
                        List<Tbl_Supplier> lstSupplier = new List<Tbl_Supplier>();
                        lstSupplier = aSupplierBusiness.GetAllSupplierByCountry(id);
                        if (lstSupplier.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<Tbl_Customer> lstcustomer= new List<Tbl_Customer>();
                        lstcustomer = aCustomerBusiness.GetAllCustomerByCountry(id);
                        if (lstcustomer.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        aTbl_Country.Status = "D";
                        aTbl_Country.UpdateBy = SplashForm.username;
                        aTbl_Country.UpdateTime = DateTime.UtcNow.AddHours(6);

                        bool res = aCountryBusiness.Update(aTbl_Country);
                        if (res)
                        {
                            txtCountry.Text = string.Empty;
                            LoadGrid();
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
                        aTbl_Country = null;
                        txtCountry.Focus();
                    }
                }
            }
        }

        private void CountryForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

    }
}
