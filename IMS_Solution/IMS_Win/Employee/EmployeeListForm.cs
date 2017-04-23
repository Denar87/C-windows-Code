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
using CrystalDecisions.Shared;

namespace IMS_Win
{
    public partial class EmployeeListForm : Form
    {
        int selectedIndex = 0;
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        List<Tbl_Employee> lstEmployeeList = new List<Tbl_Employee>();
        List<Qry_Employee> lstQryEmployeeList = new List<Qry_Employee>();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        Tbl_Employee aEmployee = new Tbl_Employee();
        public EmployeeListForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            try
            {
                if (cmbSearchType.Text == "All")
                {
                    dgvEmployee.AutoGenerateColumns = false;
                    lstQryEmployeeList = aEmployeeBusiness.GetAllQryEmployee();
                    dgvEmployee.DataSource = lstQryEmployeeList;
                }
                else
                {
                    dgvEmployee.AutoGenerateColumns = false;
                    lstQryEmployeeList = aEmployeeBusiness.GetAllQry_EmployeeCode(txtEmployeeID.Text);
                    dgvEmployee.DataSource = lstQryEmployeeList;
                }
            }
            catch
            {
            }
        }
        
        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstQryEmployeeList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsEmployee.Visible = true;
                    cmsEmployee.Items.Clear();
                    cmsEmployee.Items.Add("Edit");
                    cmsEmployee.Items.Add("Delete");
                    cmsEmployee.Show(dgvEmployee, new Point(e.X, e.Y));
                }

            }
        }

        private void cmsEmployee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                cmsEmployee.Visible = false;
                if (e.ClickedItem.Text == "Edit")
                {
                    int id = lstQryEmployeeList[selectedIndex].Employee_SlNo;
                    EmployeeForm ob = new EmployeeForm();
                    ob.id = id;
                    ob.ShowDialog();
                    LoadGrid();
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = lstQryEmployeeList[selectedIndex].Employee_SlNo;
                        Tbl_Employee aTbl_Employee = aEmployeeBusiness.GetAllEmployee(id);
                        try
                        {
                            List<Tbl_PurchaseMaster> lstPurchase = new List<Tbl_PurchaseMaster>();
                            lstPurchase = aPurchaseBusiness.GetAllEmployeeByPurchase(id);
                            if (lstPurchase.Any())
                            {
                                MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            aTbl_Employee.Status = "D";
                            aTbl_Employee.UpdateBy = SplashForm.username;
                            aTbl_Employee.UpdateTime = DateTime.UtcNow.AddHours(6);


                            bool res = aEmployeeBusiness.Update(aTbl_Employee);
                            if (res)
                            {
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
                            aTbl_Employee = null;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvEmployee_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                Reports.CREmployeeList rpt = new Reports.CREmployeeList();

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                if (cmbSearchType.Text == "All")
                {
                    lstQryEmployeeList = aEmployeeBusiness.GetAllQryEmployee();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    rpt.SetDataSource(lstQryEmployeeList);

                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    lstQryEmployeeList = aEmployeeBusiness.GetAllQry_EmployeeCode(txtEmployeeID.Text);
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    rpt.SetDataSource(lstQryEmployeeList);

                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Select Employee")
            {
                label16.Visible = true;
                label2.Visible = true;
                txtEmployeeID.Visible = true;
                txtEmployeeName.Visible = true;
                txtEmployeeID.Text = "";
                txtEmployeeName.Text = "";
                txtEmployeeID.Focus();
            }
            if (cmbSearchType.Text == "All")
            {
                label16.Visible = false;
                label2.Visible = false;
                txtEmployeeID.Visible = false;
                txtEmployeeName.Visible = false;
                employeelistView.Visible = false;
            }
        }

        void GetEmployee()
        {
            List<Tbl_Employee> lstEmployeeList = aEmployeeBusiness.GetAllEmployeeByID(txtEmployeeID.Text);
            employeelistView.Items.Clear();
            if (lstEmployeeList.Any())
            {
                employeelistView.Visible = true;
                foreach (Tbl_Employee employee in lstEmployeeList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = employee;
                    aListViewItem.Text = employee.Employee_ID;
                    aListViewItem.SubItems.Add(employee.Employee_Name);

                    employeelistView.Items.Add(aListViewItem);
                }
            }
        }

        private void txtEmployeeID_Click(object sender, EventArgs e)
        {
            GetEmployee();
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                employeelistView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                employeelistView.Focus();
            }
            else
            {
                GetEmployee();
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != string.Empty)
            {
                GetEmployee();
            }
        }

        private void employeelistView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aEmployee = (Tbl_Employee)employeelistView.SelectedItems[0].Tag;

                    txtEmployeeID.Text = aEmployee.Employee_ID;
                    txtEmployeeName.Text = aEmployee.Employee_Name;
                    employeelistView.Visible = false;
                    btnView.Focus();
                }
            }
            catch
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch
            {
            }
        }

        private void employeelistView_Click(object sender, EventArgs e)
        {
            aEmployee = (Tbl_Employee)employeelistView.SelectedItems[0].Tag;

            txtEmployeeID.Text = aEmployee.Employee_ID;
            txtEmployeeName.Text = aEmployee.Employee_Name;
            employeelistView.Visible = false;
            btnView.Focus();
        }

        

       
    }
}
