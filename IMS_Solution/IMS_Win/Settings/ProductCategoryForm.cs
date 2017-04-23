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
    public partial class ProductCategoryForm : Form
    {
        ProductCategoryBusiness aProductCategoryBusiness = new ProductCategoryBusiness();
        int selectedIndex = 0;
        ProductBusiness aProductBusiness = new ProductBusiness();
        List<Tbl_ProductCategory> lstProductCategoryList = new List<Tbl_ProductCategory>();
        
        public ProductCategoryForm()
        {
            InitializeComponent();
        }

        void LoadGrid()
        {
            dgvCategoryProduct.AutoGenerateColumns = false;
            lstProductCategoryList = aProductCategoryBusiness.GetAllProductCategory();
            lstProductCategoryList = lstProductCategoryList.OrderByDescending(x=>x.ProductCategory_SlNo).ToList();
            dgvCategoryProduct.DataSource = lstProductCategoryList;
        }

        private void txtcategoryname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddCategory();
            }
            if (e.KeyChar == (Char)Keys.Escape)
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            setnew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_ProductCategory aTbl_ProductCategory = lstProductCategoryList[selectedIndex];
            try
            {
                aTbl_ProductCategory.ProductCategory_Name = txtcategoryname.Text;
                aTbl_ProductCategory.ProductCategory_Description = txtdescription.Text;
                aTbl_ProductCategory.Status = "A";
                aTbl_ProductCategory.UpdateBy = SplashForm.username;
                aTbl_ProductCategory.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aProductCategoryBusiness.validateOnUpdate(aTbl_ProductCategory);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aProductCategoryBusiness.Update(aTbl_ProductCategory);
                if (res)
                {
                    setnew();
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
                aTbl_ProductCategory = null;
            }
        }

        private void dgvCategoryProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        void setnew()
        {
            txtcategoryname.Text = "";
            txtdescription.Text = "";
            txtcategoryname.Focus();
            LoadGrid();
        }

        private void ProductCategoryForm_Load(object sender, EventArgs e)
        {
            setnew();
        }

        void AddCategory()
        {

            Tbl_ProductCategory aTbl_ProductCategory = new Tbl_ProductCategory();
            try
            {
                aTbl_ProductCategory.ProductCategory_Name = txtcategoryname.Text;
                aTbl_ProductCategory.ProductCategory_Description = txtdescription.Text;
                aTbl_ProductCategory.Status = "A";
                aTbl_ProductCategory.AddBy = SplashForm.username;
                aTbl_ProductCategory.AddTime = DateTime.UtcNow.AddHours(6);

                string msg = aProductCategoryBusiness.validateOnSave(aTbl_ProductCategory);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aProductCategoryBusiness.Insert(aTbl_ProductCategory);
                if (res)
                {
                    setnew();
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
                aTbl_ProductCategory = null;
            }
        }

        private void dgvCategoryProduct_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstProductCategoryList.Any())
            {

                if (e.Button == MouseButtons.Right)
                {
                    cmsProductCategory.Visible = true;
                    cmsProductCategory.Items.Clear();
                    cmsProductCategory.Items.Add("Edit");
                    cmsProductCategory.Items.Add("Delete");
                    cmsProductCategory.Show(dgvCategoryProduct, new Point(e.X, e.Y));
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void cmsProductCategory_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsProductCategory.Visible = false;
            if (e.ClickedItem.Text == "Edit")
            {
                txtcategoryname.Text = lstProductCategoryList[selectedIndex].ProductCategory_Name;
                txtdescription.Text = lstProductCategoryList[selectedIndex].ProductCategory_Description;
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
            }
            if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tbl_ProductCategory aTbl_ProductCategory = lstProductCategoryList[selectedIndex];
                    try
                    {
                        int id = lstProductCategoryList[selectedIndex].ProductCategory_SlNo;
                        List<Tbl_Product> lstProduct = new List<Tbl_Product>();
                        lstProduct = aProductBusiness.GetAllProductByCategoryID(id);
                        if (lstProduct.Any())
                        {
                            MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        aTbl_ProductCategory.Status = "D";
                        aTbl_ProductCategory.UpdateBy = SplashForm.username;
                        aTbl_ProductCategory.UpdateTime = DateTime.UtcNow.AddHours(6);


                        bool res = aProductCategoryBusiness.Update(aTbl_ProductCategory);
                        if (res)
                        {
                            setnew();
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
                        aTbl_ProductCategory = null;
                    }
                }
            }
        }

        private void txtcategoryname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                txtdescription.Focus();
            }
        }

        private void txtdescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }
    }
}
