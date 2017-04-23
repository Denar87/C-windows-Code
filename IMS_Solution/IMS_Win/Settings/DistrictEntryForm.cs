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
    public partial class DistrictEntryForm : Form
    {
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();
        int selectedIndex = 0;
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        List<Tbl_District> lstDistrictList = new List<Tbl_District>();
        public DistrictEntryForm()
        {
            InitializeComponent();
            
        }

        void LoadGrid()
        {
            dgvDistrict.AutoGenerateColumns = false;
            lstDistrictList = aDistrictBusiness.GetAllDistrict();
            dgvDistrict.DataSource = lstDistrictList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtDistrict.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_District aTbl_District = lstDistrictList[selectedIndex];
            try
            {
                aTbl_District.District_Name = txtDistrict.Text;
                aTbl_District.Status = "A";
                aTbl_District.UpdateBy = SplashForm.username;
                aTbl_District.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aDistrictBusiness.validateOnUpdate(aTbl_District);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aDistrictBusiness.Update(aTbl_District);
                if (res)
                {
                    LoadGrid();
                    txtDistrict.Text = string.Empty;
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
                aTbl_District = null;
                txtDistrict.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_District aTbl_District = new Tbl_District();
            try
            {
                aTbl_District.District_Name = txtDistrict.Text;
                aTbl_District.Status = "A";
                aTbl_District.AddBy = SplashForm.username;
                aTbl_District.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aDistrictBusiness.validateOnSave(aTbl_District);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aDistrictBusiness.Insert(aTbl_District);
                if (res)
                {
                    LoadGrid();
                    txtDistrict.Text = string.Empty;
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
                aTbl_District = null;
                txtDistrict.Focus();
            }

        }

        private void DistrictEntryForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void cmsDistrict_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsDistrict.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtDistrict.Text = lstDistrictList[selectedIndex].District_Name;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_District aTbl_District = lstDistrictList[selectedIndex];
                    try
                    {
                        int id = lstDistrictList[selectedIndex].District_SlNo;
                        List<Tbl_Supplier> lstSupplier = new List<Tbl_Supplier>();
                        lstSupplier = aSupplierBusiness.GetAllSupplierByDistrict(id);
                        if (lstSupplier.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        aTbl_District.Status = "D";
                        aTbl_District.UpdateBy = SplashForm.username;
                        aTbl_District.UpdateTime = DateTime.UtcNow.AddHours(6);


                        bool res = aDistrictBusiness.Update(aTbl_District);
                        if (res)
                        {
                            txtDistrict.Text = string.Empty;
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
                        aTbl_District = null;
                        txtDistrict.Focus();
                    }
                }
            }
        }

        private void dgvDistrict_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvDistrict_MouseDown(object sender, MouseEventArgs e)
        {
            if(lstDistrictList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsDistrict.Visible = true;
                    cmsDistrict.Items.Clear();
                    cmsDistrict.Items.Add("Edit");
                    cmsDistrict.Items.Add("Delete");
                    cmsDistrict.Show(dgvDistrict, new Point(e.X, e.Y));
                }

            }
        }
    }
}
