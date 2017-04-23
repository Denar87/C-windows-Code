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
    public partial class UnitOfMeasurementForm : Form
    {
        UnitOfMeasurementBusiness aUnitOfMeasurementBusiness = new UnitOfMeasurementBusiness();
        int selectedIndex = 0;
        ProductBusiness aProductBusiness = new ProductBusiness();
        List<Tbl_Unit> lstUnitList = new List<Tbl_Unit>();
        public UnitOfMeasurementForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvunit.AutoGenerateColumns = false;
            lstUnitList = aUnitOfMeasurementBusiness.GetAllUnit();
            dgvunit.DataSource = lstUnitList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Unit aTbl_Unit = new Tbl_Unit();
            try
            {
                aTbl_Unit.Unit_Name = txtUOMName.Text;
                aTbl_Unit.Status = "A";
                aTbl_Unit.AddBy = SplashForm.username;
                aTbl_Unit.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aUnitOfMeasurementBusiness.validateOnSave(aTbl_Unit);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aUnitOfMeasurementBusiness.Insert(aTbl_Unit);
                if (res)
                {
                    LoadGrid();
                    txtUOMName.Text = string.Empty;
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
                aTbl_Unit = null;
                txtUOMName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtUOMName.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Unit aTbl_Unit = lstUnitList[selectedIndex];
            try
            {
                aTbl_Unit.Unit_Name = txtUOMName.Text;
                aTbl_Unit.Status = "A";
                aTbl_Unit.UpdateBy = SplashForm.username;
                aTbl_Unit.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aUnitOfMeasurementBusiness.validateOnUpdate(aTbl_Unit);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aUnitOfMeasurementBusiness.Update(aTbl_Unit);
                if (res)
                {
                    LoadGrid();
                    txtUOMName.Text = string.Empty;
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
                aTbl_Unit = null;
                txtUOMName.Focus();
            }
        }

        private void dgvCategoryProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvCategoryProduct_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstUnitList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsUnit.Visible = true;
                    cmsUnit.Items.Clear();
                    cmsUnit.Items.Add("Edit");
                    cmsUnit.Items.Add("Delete");
                    cmsUnit.Show(dgvunit, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsUnit_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsUnit.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtUOMName.Text = lstUnitList[selectedIndex].Unit_Name;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_Unit aTbl_Unit = lstUnitList[selectedIndex];
                    try
                    {
                        int id = lstUnitList[selectedIndex].Unit_SlNo;
                        List<Tbl_Product> lstProduct = new List<Tbl_Product>();
                        lstProduct = aProductBusiness.GetAllProductByUnit(id);
                        if (lstProduct.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        aTbl_Unit.Status = "D";
                        aTbl_Unit.UpdateBy = SplashForm.username;
                        aTbl_Unit.UpdateTime = DateTime.UtcNow.AddHours(6);
                        bool res = aUnitOfMeasurementBusiness.Update(aTbl_Unit);
                        if (res)
                        {
                            txtUOMName.Text = string.Empty;
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
                        aTbl_Unit = null;
                        txtUOMName.Focus();
                    }
                }
            }
        }

        private void UnitOfMeasurementForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
