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
using System.IO;

namespace IMS_Win
{
    public partial class EmployeeForm : Form
    {
        DepartmentBusiness aDepartmentBusiness = new DepartmentBusiness();
        DesignationBusiness aDesignationBusiness = new DesignationBusiness();
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        Tbl_Employee employee = new Tbl_Employee();
        List<Tbl_Employee> lstEmployeeList = new List<Tbl_Employee>();
        
        //string defaultimg = "";
        byte[] picbyte1 = new byte[] { };
        public int id = 0;
        public EmployeeForm()
        {
            InitializeComponent();
        }
        private string imagePath = "no_image.jpeg";

        private void GetDepartmentForComboBox()
        {
            try
            {
                Cmb_department.DataSource = null;
                Cmb_department.DisplayMember = "Department_Name";
                Cmb_department.ValueMember = "Department_SlNo";
                Cmb_department.DataSource = aDepartmentBusiness.GetAllDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetDesignationForComboBox()
        {
            try
            {
                Cmb_Designation.DataSource = null;
                Cmb_Designation.DisplayMember = "Designation_Name";
                Cmb_Designation.ValueMember = "Designation_SlNo";
                Cmb_Designation.DataSource = aDesignationBusiness.GetAllDesignation();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                txtEmployeeName.Focus();
            }
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Cmb_Designation.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Cmb_Designation.Focus();
            }
            if(e.KeyCode==Keys.Up)
            {
                txtEmployeeID.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Cmb_Designation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Cmb_department.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Cmb_department.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtEmployeeName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        void GenerateCode()
        {
            txtEmployeeID.Text = aEmployeeBusiness.GenerateEmployeeCode();
        }

        private void SetNew()
        {
            txtEmployeeName.Focus();
            txtEmployeeName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtNID.Text = "";
            txtPresentAddress.Text = "";
            txtPermanent_Add.Text = "";
            txtContactNo.Text = "";
            txt_Emp_Email.Text = "";
            cmbGender.SelectedItem = cmbGender.Items[0];
            cmbMaritalStatus.SelectedItem = cmbMaritalStatus.Items[1];
            PictureBoxEmployee.ImageLocation =UtilityBusiness.DefaultNoImagePath;
            GenerateCode();
           
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            GetDepartmentForComboBox();
            GetDesignationForComboBox();

            employee = aEmployeeBusiness.GetAllEmployee(id);

            if (employee!=null)
            {
                txtEmployeeID.Text = employee.Employee_ID;
                txtEmployeeName.Text = employee.Employee_Name;
                Cmb_department.SelectedValue = employee.Department_SlNo;
                Cmb_Designation.SelectedValue = employee.Designation_SlNo;
                Dtp_Admitdate.Value = employee.Employee_JoinDate;
                txtFatherName.Text = employee.Employee_FatherName;
                txtMotherName.Text = employee.Employee_MotherName;
                cmbGender.Text = employee.Employee_Gender;
                dtpDOB.Value = employee.Employee_BirthDate;
                cmbMaritalStatus.Text = employee.Employee_MaritalStatus;
                txtNID.Text = employee.Employee_NID;
                txtPresentAddress.Text = employee.Employee_PrasentAddress;
                txtPermanent_Add.Text = employee.Employee_PermanentAddress;
                txtContactNo.Text = employee.Employee_ContactNo;
                txt_Emp_Email.Text = employee.Employee_Email;


                byte[] storedimg = (byte[])employee.Employee_Pic;
                picbyte1 = storedimg;
                Image newimg;
                using (MemoryStream stream = new MemoryStream(storedimg))
                {
                    newimg = Image.FromStream(stream);
                    PictureBoxEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
                    PictureBoxEmployee.Image = newimg;
                }

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                SetNew();
            }

        }

        private void Cmb_department_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Dtp_Admitdate.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Dtp_Admitdate.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                Cmb_Designation.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Dtp_Admitdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtFatherName.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherName.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                Cmb_department.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMotherName.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtMotherName.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                Dtp_Admitdate.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtMotherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
               cmbGender.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtFatherName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtpDOB.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                dtpDOB.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtMotherName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void dtpDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                cmbMaritalStatus.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                cmbMaritalStatus.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbGender.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtNID.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtNID.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                dtpDOB.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtPresentAddress.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtPresentAddress.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbMaritalStatus.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtPresentAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtPermanent_Add.Focus();
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtPermanent_Add.Focus();
            //}
            if (e.KeyCode == Keys.Up)
            {
                txtNID.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtPermanent_Add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtContactNo.Focus();
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtContactNo.Focus();
            //}
            if (e.KeyCode == Keys.Up)
            {
                txtPresentAddress.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txt_Emp_Email.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt_Emp_Email.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtPermanent_Add.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txt_Emp_Email_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                txtContactNo.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tbl_Employee aTbl_Employee = new Tbl_Employee();
            try
            {
                aTbl_Employee.Employee_ID = txtEmployeeID.Text;
                aTbl_Employee.Employee_Name = txtEmployeeName.Text;
                aTbl_Employee.Designation_SlNo = Convert.ToInt16(Cmb_Designation.SelectedValue);
                aTbl_Employee.Department_SlNo = Convert.ToInt16(Cmb_department.SelectedValue);
                aTbl_Employee.Employee_JoinDate = Dtp_Admitdate.Value.Date;
                aTbl_Employee.Employee_FatherName = txtFatherName.Text;
                aTbl_Employee.Employee_MotherName = txtMotherName.Text;
                aTbl_Employee.Employee_Gender = cmbGender.Text;
                aTbl_Employee.Employee_BirthDate = dtpDOB.Value.Date;
                aTbl_Employee.Employee_MaritalStatus = cmbMaritalStatus.Text;
                aTbl_Employee.Employee_NID = txtNID.Text;
                aTbl_Employee.Employee_PrasentAddress = txtPresentAddress.Text;
                aTbl_Employee.Employee_PermanentAddress = txtPermanent_Add.Text;
                aTbl_Employee.Employee_ContactNo = txtContactNo.Text;
                aTbl_Employee.Employee_Email = txt_Emp_Email.Text;
                aTbl_Employee.Status = "A";
                aTbl_Employee.AddBy = SplashForm.username;
                aTbl_Employee.AddTime = DateTime.UtcNow.AddHours(6);
                //aTbl_Employee.Employee_Pic = picbyte1;
                aTbl_Employee.Employee_Pic = UtilityBusiness.GetByteArrayFromFile(imagePath);

                string msg = aEmployeeBusiness.validateOnSave(aTbl_Employee);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtEmployeeName.Focus();
                    return;
                }

                if (Cmb_Designation.Text == "")
                {
                    MessageBox.Show("Select Designation!", "Warning");
                    Cmb_Designation.Focus();
                    return;
                }
                if (Cmb_department.Text == "")
                {
                    MessageBox.Show("Select Department!", "Warning");
                    Cmb_department.Focus();
                    return;
                }

                if (txtPresentAddress.Text == "")
                {
                    MessageBox.Show("Enter Present Address", "Warning");
                    txtPresentAddress.Focus();
                    return;
                }

                if (txtPermanent_Add.Text == "")
                {
                    MessageBox.Show("Enter Permanent Address", "Warning");
                    txtPermanent_Add.Focus();
                    return;
                }

                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Enter Contact No.", "Warning");
                    txtContactNo.Focus();
                    return;
                }
                
                bool res = aEmployeeBusiness.Insert(aTbl_Employee);
                
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
                aTbl_Employee = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = @":D\";
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                if (fldlg.ShowDialog() == DialogResult.OK)
                {
                    imagePath = fldlg.FileName;
                    Bitmap newimg = new Bitmap(imagePath);
                    PictureBoxEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
                    PictureBoxEmployee.Image = (Image)newimg;

                  picbyte1=  UtilityBusiness.GetByteArrayFromFile(imagePath);
                }
                fldlg = null;
            }
            catch (System.ArgumentException ae)
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                MessageBox.Show(ae.Message.ToString());
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void lblClearEmplyeeImage_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                Bitmap newimg = new Bitmap(imagePath);
                PictureBoxEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBoxEmployee.Image = (Image)newimg;
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            EmployeeListForm ob = new EmployeeListForm();
            ob.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Employee aTbl_Employee = employee;
            try
            {
                aTbl_Employee.Employee_Name = txtEmployeeName.Text;
                aTbl_Employee.Designation_SlNo = Convert.ToInt32(Cmb_Designation.SelectedValue);
                aTbl_Employee.Department_SlNo = Convert.ToInt32(Cmb_department.SelectedValue);
                aTbl_Employee.Employee_JoinDate = Dtp_Admitdate.Value.Date;
                aTbl_Employee.Employee_FatherName = txtFatherName.Text;
                aTbl_Employee.Employee_MotherName = txtMotherName.Text;
                aTbl_Employee.Employee_Gender = cmbGender.Text;
                aTbl_Employee.Employee_BirthDate = dtpDOB.Value.Date;
                aTbl_Employee.Employee_MaritalStatus = cmbMaritalStatus.Text;
                aTbl_Employee.Employee_NID = txtNID.Text;
                aTbl_Employee.Employee_PrasentAddress = txtPresentAddress.Text;
                aTbl_Employee.Employee_PermanentAddress = txtPermanent_Add.Text;
                aTbl_Employee.Employee_ContactNo = txtContactNo.Text;
                aTbl_Employee.Employee_Email = txt_Emp_Email.Text;
                aTbl_Employee.Status = "A";
                aTbl_Employee.UpdateBy = SplashForm.username;
                aTbl_Employee.UpdateTime = DateTime.UtcNow.AddHours(6);
                aTbl_Employee.Employee_Pic = picbyte1;

                string msg = aEmployeeBusiness.validateOnUpdate(aTbl_Employee);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtEmployeeName.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Enter Father Name", "Warning");
                    txtFatherName.Focus();
                    return;
                }
                if (txtNID.Text == "")
                {
                    MessageBox.Show("Enter National Id", "Warning");
                    txtNID.Focus();
                    return;
                }
                bool res = aEmployeeBusiness.Update(aTbl_Employee);
                if (res)
                {
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
                aTbl_Employee = null;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetNew();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            txtEmployeeName.Text = string.Empty;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            EmployeeListForm ob = new EmployeeListForm();
            ob.ShowDialog();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                Bitmap newimg = new Bitmap(imagePath);
                PictureBoxEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBoxEmployee.Image = (Image)newimg;
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            DesignationForm ob = new DesignationForm();
            ob.ShowDialog();
            GetDesignationForComboBox();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            DepartmentForm ob = new DepartmentForm();
            ob.ShowDialog();
            GetDepartmentForComboBox();
        }

       
    }
}
