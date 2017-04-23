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
    public partial class DesignationForm : Form
    {
        DesignationBusiness aDesignationBusiness = new DesignationBusiness();
        int selectedIndex = 0;
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        List<Tbl_Designation> lstDesignationList = new List<Tbl_Designation>();
        public DesignationForm()
        {
            
            InitializeComponent();
        }
        void LoadGrid()
        {
            dgvDesignation.AutoGenerateColumns = false;
            lstDesignationList = aDesignationBusiness.GetAllDesignation();
            dgvDesignation.DataSource = lstDesignationList;
            
        }
        private void DesignationForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_Designation aTbl_Designation = new Tbl_Designation();
            try
            {
                aTbl_Designation.Designation_Name = txtName.Text;
                aTbl_Designation.Status = "A";
                aTbl_Designation.AddBy = SplashForm.username;
                aTbl_Designation.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aDesignationBusiness.validateOnSave(aTbl_Designation);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
              bool res=  aDesignationBusiness.Insert(aTbl_Designation);
              if (res)
              {
                  LoadGrid();
                  txtName.Text = string.Empty;
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
                aTbl_Designation = null;
                txtName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtName.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Designation aTbl_Designation = lstDesignationList[selectedIndex];
            try
            {
                aTbl_Designation.Designation_Name = txtName.Text;
                aTbl_Designation.Status = "A";
                aTbl_Designation.UpdateBy = SplashForm.username;
                aTbl_Designation.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aDesignationBusiness.validateOnUpdate(aTbl_Designation);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aDesignationBusiness.Update(aTbl_Designation);
                if (res)
                {
                    LoadGrid();
                    txtName.Text = string.Empty;
                    btnAdd.Visible = true;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    UtilityBusiness.DisplayAlertMessage('S', "Update Successful");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Update Failed");
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_Designation = null;
                txtName.Focus();
            }
        }

        private void dgvDesignation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvDesignation_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstDesignationList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsDesignation.Visible = true;
                    cmsDesignation.Items.Clear();
                    cmsDesignation.Items.Add("Edit");
                    cmsDesignation.Items.Add("Delete");
                    cmsDesignation.Show(dgvDesignation, new Point(e.X, e.Y));
                }

            }
        }

        private void cmsDesignation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsDesignation.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtName.Text = lstDesignationList[selectedIndex].Designation_Name;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                {
                    Tbl_Designation aTbl_Designation = lstDesignationList[selectedIndex];
                    try
                    {
                        int id = lstDesignationList[selectedIndex].Designation_SlNo;

                        List<Tbl_Employee> lstEmployee = new List<Tbl_Employee>();
                        lstEmployee = aEmployeeBusiness.GetAllEmployeeByDesignation(id);
                        if (lstEmployee.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        aTbl_Designation.Status = "D";
                        aTbl_Designation.UpdateBy = SplashForm.username;
                        aTbl_Designation.UpdateTime = DateTime.UtcNow.AddHours(6);


                        bool res = aDesignationBusiness.Update(aTbl_Designation);
                        if (res)
                        {
                            LoadGrid();
                            txtName.Text = string.Empty;
                            UtilityBusiness.DisplayAlertMessage('S', "Delete Successful");
                        }
                        else
                        {
                            UtilityBusiness.DisplayAlertMessage('E', "Delete Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        UtilityBusiness.DisplayAlertMessage('E', ex.Message);
                    }
                    finally
                    {
                        aTbl_Designation = null;
                        txtName.Focus();
                    }
                }
            }
        }

       
    }
}
