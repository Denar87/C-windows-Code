using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Entity;
using IMS_Business;
using Utility;

namespace IMS_Win
{
    public partial class DepartmentForm : Form
    {
        DepartmentBusiness aDepartmentBusiness = new DepartmentBusiness();
        int selectedIndex = 0;
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        List<Tbl_Department> lstDepartmentList = new List<Tbl_Department>();
        public DepartmentForm()
        {
            
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvDepartment.AutoGenerateColumns = false;
            lstDepartmentList = aDepartmentBusiness.GetAllDepartment();
            dgvDepartment.DataSource = lstDepartmentList;

        }
        private void dgvDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Department aTbl_Department = new Tbl_Department();
            try
            {
                aTbl_Department.Department_Name = txtDepartment.Text;
                aTbl_Department.Status = "A";
                aTbl_Department.AddBy = SplashForm.username;
                aTbl_Department.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aDepartmentBusiness.validateOnSave(aTbl_Department);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aDepartmentBusiness.Insert(aTbl_Department);
                if (res)
                {
                    LoadGrid();
                    txtDepartment.Text = string.Empty;
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
                aTbl_Department = null;
                txtDepartment.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtDepartment.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Department aTbl_Department = lstDepartmentList[selectedIndex];
            try
            {
                aTbl_Department.Department_Name = txtDepartment.Text;
                aTbl_Department.Status = "A";
                aTbl_Department.UpdateBy = SplashForm.username;
                aTbl_Department.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aDepartmentBusiness.validateOnUpdate(aTbl_Department);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aDepartmentBusiness.Update(aTbl_Department);
                if (res)
                {
                    LoadGrid();
                    txtDepartment.Text = string.Empty;
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
                aTbl_Department = null;
                txtDepartment.Focus();
            }
        }

        private void dgvDepartment_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstDepartmentList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsDpartment.Visible = true;
                    cmsDpartment.Items.Clear();
                    cmsDpartment.Items.Add("Edit");
                    cmsDpartment.Items.Add("Delete");
                    cmsDpartment.Show(dgvDepartment, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsDpartment_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsDpartment.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtDepartment.Text = lstDepartmentList[selectedIndex].Department_Name;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                {
                    Tbl_Department aTbl_Dpartment = lstDepartmentList[selectedIndex];
                    try
                    {
                        int id = lstDepartmentList[selectedIndex].Department_SlNo;

                        List<Tbl_Employee> lstEmployee = new List<Tbl_Employee>();
                        lstEmployee = aEmployeeBusiness.GetAllEmployeeByDepartment(id);
                        if (lstEmployee.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        aTbl_Dpartment.Status = "D";
                        aTbl_Dpartment.UpdateBy = SplashForm.username;
                        aTbl_Dpartment.UpdateTime = DateTime.UtcNow.AddHours(6);

                        bool res = aDepartmentBusiness.Update(aTbl_Dpartment);
                        if (res)
                        {
                            txtDepartment.Text = string.Empty;
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
                        aTbl_Dpartment = null;
                        txtDepartment.Focus();
                    }
                }
            }
        }
        }
    }
