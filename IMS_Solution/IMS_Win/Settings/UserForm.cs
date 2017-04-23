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
    public partial class UserForm : Form
    {
        UserBusiness aUserBusiness = new UserBusiness();
        int SelectedIndex = 0;
        List<Tbl_User> lstUserList = new List<Tbl_User>();
        public UserForm()
        {
            InitializeComponent();
        }


        void LoadGrid()
        {
            dgvUser.AutoGenerateColumns = false;
            lstUserList = aUserBusiness.GetAllUser().Where(x=>x.User_ID != "Admin").ToList();
            dgvUser.DataSource = lstUserList;
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                txtUseName.Focus();
            }
            if(e.KeyChar==(char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtUseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                txtUseName.Focus();
            }
        }

        private void txtUseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtPassword.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtUserID.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtUseName.Focus();
            }
            if(e.KeyCode==Keys.Down)
            {
                txtConfirmPassword.Focus();
            }
        }

        void SetNew()
        {
            txtUserID.Text = "";
            txtUseName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtUseName.Focus();
            LoadGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            SetNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_User aTbl_User = lstUserList[SelectedIndex];
            try
            {
                aTbl_User.User_ID = txtUserID.Text;
                aTbl_User.User_Name = txtUseName.Text;
                aTbl_User.User_Password = CryptographyManager.Encrypt("abcd",txtPassword.Text);
                aTbl_User.UserType = cmbUserType.Text;
                aTbl_User.Status = "A";
                aTbl_User.UpdateBy = SplashForm.username;
                aTbl_User.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aUserBusiness.validateOnUpdate(aTbl_User);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtUserID.Focus();
                    return;
                }
                if (txtUseName.Text == "" || txtUseName.Text == null)
                {
                    MessageBox.Show("Enter User Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUseName.Focus();
                    return;
                }
                if (txtPassword.Text == "" || txtPassword.Text == null)
                {
                    MessageBox.Show("Enter Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (txtPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password must be 4 digit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (cmbUserType.Text == "" || cmbUserType.Text == null)
                {
                    MessageBox.Show("Select User Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUserType.Focus();
                    return;
                }
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    bool res = aUserBusiness.Update(aTbl_User);
                    if (res)
                    {
                        SetNew();
                        btnAdd.Visible = true;
                        btnCancel.Visible = false;
                        btnUpdate.Visible = false;
                        UtilityBusiness.DisplayAlertMessage('S', "Updated Successfully");
                        SetNew();
                    }
                    else
                    {
                        UtilityBusiness.DisplayAlertMessage('E', "Updated Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Password does not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Text = "";
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tbl_User aTbl_User = new Tbl_User();
            try
            {
                aTbl_User.User_ID = txtUserID.Text;
                aTbl_User.User_Name = txtUseName.Text;
                aTbl_User.User_Password = CryptographyManager.Encrypt("abcd",txtPassword.Text);
                aTbl_User.UserType = cmbUserType.Text;
                aTbl_User.Status = "A";
                aTbl_User.AddBy = SplashForm.username;
                aTbl_User.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aUserBusiness.validateOnSave(aTbl_User);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtUserID.Focus();
                    return;
                }

                if (txtUseName.Text == "" || txtUseName.Text==null)
                {
                    MessageBox.Show("Enter User Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUseName.Focus();
                    return;
                }
                if (txtPassword.Text == "" || txtPassword.Text == null)
                {
                    MessageBox.Show("Enter Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (txtPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password must be 4 digit","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (cmbUserType.Text == "" || cmbUserType.Text == null)
                {
                    MessageBox.Show("Select User Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUserType.Focus();
                    return;
                }
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    bool res = aUserBusiness.Insert(aTbl_User);
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
                else
                {
                    MessageBox.Show("Password does not match", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtConfirmPassword.Text = "";
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_User = null;
            }
        }

        private void cmsUserInformation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsUserInformation.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtUserID.Text = lstUserList[SelectedIndex].User_ID;
                txtUseName.Text = lstUserList[SelectedIndex].User_Name;
                cmbUserType.Text = lstUserList[SelectedIndex].UserType;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_User aTbl_User = lstUserList[SelectedIndex];
                    try
                    {
                        aTbl_User.Status = "D";
                        aTbl_User.UpdateBy = SplashForm.username;
                        aTbl_User.UpdateTime = DateTime.UtcNow.AddHours(6);

                        bool res = aUserBusiness.Update(aTbl_User);
                        if (res)
                        {
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
                        aTbl_User = null;
                        txtUserID.Focus();
                    }
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            SetNew();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedIndex = e.RowIndex;
        }

        private void dgvUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstUserList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsUserInformation.Visible = true;
                    cmsUserInformation.Items.Clear();
                    cmsUserInformation.Items.Add("Edit");
                    cmsUserInformation.Items.Add("Delete");
                    cmsUserInformation.Show(dgvUser, new Point(e.X, e.Y));
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtConfirmPassword.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbUserType.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtPassword.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                cmbUserType.Focus();
            }
        }
    }
}
