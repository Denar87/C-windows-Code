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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BarcodeLib;

namespace IMS_Win
{
    public partial class ProductForm : Form
    {
        ProductBusiness aProductBusiness = new ProductBusiness();
        UnitOfMeasurementBusiness aUnitOfMeasurementBusiness = new UnitOfMeasurementBusiness();
        ProductCategoryBusiness aProductCategoryBusiness = new ProductCategoryBusiness();
        int selectedIndex = 0;
        public int id = 0;
        Tbl_Product aTbl_Product = new Tbl_Product();
        List<Tbl_Product> lstProductList = new List<Tbl_Product>();
        List<Qry_Product> lstQryProductList = new List<Qry_Product>();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        
        public ProductForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetNew();
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkFinishedGoods.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                chkFinishedGoods.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbProductCategory.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void chkRawMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReOrderLevel.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtReOrderLevel.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                chkFinishedGoods.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void chkFinishedGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkRawMaterial.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                chkRawMaterial.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtProductName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtReOrderLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPurchaseRate.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtPurchaseRate.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                chkFinishedGoods.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVATPercent.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtVATPercent.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtPurchaseRate.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void cmbUnitOfMeasurement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                AddProduct();
            }
        }

        void LoadGrid()
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;
                lstQryProductList = aProductBusiness.GetAllQryProduct();
                lstQryProductList = lstQryProductList.OrderByDescending(x => x.Product_Code).ToList();
                dgvProduct.DataSource = lstQryProductList;
            }
            catch { }
        }

        void GenerateCode()
        {
            txtProductCode.Text = aProductBusiness.GenerateProductCode();
        }

        private void GetProductCategory()
        {
            try
            {
                cmbProductCategory.DataSource = null;
                cmbProductCategory.DisplayMember = "ProductCategory_Name";
                cmbProductCategory.ValueMember = "ProductCategory_SlNo";
                cmbProductCategory.DataSource = aProductCategoryBusiness.GetAllProductCategory();
                cmbProductCategory.Text = "Select Category";
                cmbProductCategory.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetUnit()
        {
            try
            {
                cmbUnitOfMeasurement.DataSource = null;
                cmbUnitOfMeasurement.DisplayMember = "Unit_Name";
                cmbUnitOfMeasurement.ValueMember = "Unit_SlNo";
                cmbUnitOfMeasurement.DataSource = aUnitOfMeasurementBusiness.GetAllUnit();
                //cmbUnitOfMeasurement.SelectedItem = cmbUnitOfMeasurement.Items[1];
                cmbUnitOfMeasurement.Text = "Select Unit";
                cmbUnitOfMeasurement.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetNew()
        {
            txtArticleNo.Text = "";
            txtqty.Text = "";
            txtSearchProduct.Text = "";
            txtProductName.Text = "";
            txtPurchaseRate.Text = "0";
            txtSellingPrice.Text = "0";
            txtVATPercent.Text = "0";
            chkFinishedGoods.Checked = true;
            chkRawMaterial.Checked = false;
            txtReOrderLevel.Text = "0";
            cmbProductCategory.Focus();
            GenerateCode();
            LoadGrid();
            GetProductCategory();
            GetUnit();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void dgvProduct_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstQryProductList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsProduct.Visible = true;
                    cmsProduct.Items.Clear();
                    cmsProduct.Items.Add("Edit");
                    cmsProduct.Items.Add("Delete");
                    cmsProduct.Show(dgvProduct, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsProduct_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                cmsProduct.Visible = false;
                if (e.ClickedItem.Text == "Edit")
                {
                    cmbProductCategory.SelectedValue = lstQryProductList[selectedIndex].ProductCategory_SlNo;
                    txtProductCode.Text = lstQryProductList[selectedIndex].Product_Code;
                    txtProductName.Text = lstQryProductList[selectedIndex].Product_Name;


                    chkRawMaterial.Checked = false;
                    chkFinishedGoods.Checked = false;
                    if (lstQryProductList[selectedIndex].Product_IsRawMaterial)
                    {
                        chkRawMaterial.Checked = true;
                    }
                    if (lstQryProductList[selectedIndex].Product_IsFinishedGoods)
                    {
                        chkFinishedGoods.Checked = true;
                    }
                    txtReOrderLevel.Text = lstQryProductList[selectedIndex].Product_ReOrederLevel.ToString();
                    txtPurchaseRate.Text = Math.Round(lstQryProductList[selectedIndex].Product_Purchase_Rate, 2).ToString();
                    txtSellingPrice.Text = Math.Round(lstQryProductList[selectedIndex].Product_SellingPrice, 2).ToString();
                    txtVATPercent.Text = lstQryProductList[selectedIndex].Product_VatPercent.ToString(); 
                    cmbUnitOfMeasurement.SelectedValue = lstQryProductList[selectedIndex].Unit_SlNo;
                    btnAdd.Visible = false;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = lstQryProductList[selectedIndex].Product_SlNo;
                        Tbl_Product aTbl_Product = aProductBusiness.GetAllProduct(id);
                        try
                        {
                            //Validation for delete
                            List<Tbl_PurchaseDetails> lstTbl_PurchaseDetails = aPurchaseBusiness.GetAllPurchaseByProductid(id);
                            if (lstTbl_PurchaseDetails.Any())
                            {
                                MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            List<Tbl_SaleDetails> lstTbl_SaleDetails = aSalesBusiness.GetAllSaleByProductID(id);
                            if (lstTbl_SaleDetails.Any())
                            {
                                MessageBox.Show("It can't be deleted because it is in use", "Data In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            aTbl_Product.Status = "D";
                            aTbl_Product.UpdateBy = SplashForm.username;
                            aTbl_Product.UpdateTime = DateTime.UtcNow.AddHours(6);
                            bool res = aProductBusiness.Update(aTbl_Product);
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
                            aTbl_Product = null;
                        }
                    }
                }
            }
            catch { }
        }

        ToolTip TP = new ToolTip();

        private void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                TP.ShowAlways = true;
                TP.SetToolTip(cmbProductCategory, "Select a category");
                TP.SetToolTip(btnAddCategory, "Click here to add new category");
                TP.SetToolTip(txtProductName, "Enter new product for add");
                TP.SetToolTip(txtSearchProduct, "Enter product id or name for search");
                TP.SetToolTip(btnCancel, "Click here to cancel");
                TP.SetToolTip(btnUpdate, "Click here to update category");
                TP.SetToolTip(btnAdd, "Click here to add new category");
                TP.SetToolTip(btnAddUnit, "Click here to add new unit");
                txtSearchProduct.Text = "Search Product";

                GetProductCategory();
                GetUnit();
                LoadGrid();

                aTbl_Product = aProductBusiness.GetAllProduct(id);
                if (aTbl_Product != null)
                {
                    txtProductCode.Text = aTbl_Product.Product_Code;
                    txtProductName.Text = aTbl_Product.Product_Name;
                    cmbProductCategory.SelectedValue = aTbl_Product.ProductCategory_SlNo;
                    if (aTbl_Product.Product_IsRawMaterial)
                    {
                        chkRawMaterial.Checked = true;
                    }
                    if (aTbl_Product.Product_IsFinishedGoods)
                    {
                        chkFinishedGoods.Checked = true;
                    }
                    txtReOrderLevel.Text = Convert.ToInt32(aTbl_Product.Product_ReOrederLevel).ToString();
                    txtPurchaseRate.Text = Math.Round(Convert.ToDecimal(aTbl_Product.Product_Purchase_Rate), 2).ToString();
                    txtSellingPrice.Text = Math.Round(Convert.ToDecimal(aTbl_Product.Product_SellingPrice), 2).ToString();
                    cmbUnitOfMeasurement.SelectedValue = aTbl_Product.Unit_SlNo;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                }
                else
                {
                    SetNew();
                }
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = lstQryProductList[selectedIndex].Product_SlNo;
            Tbl_Product aTbl_Product = aProductBusiness.GetAllProduct(id);
            try
            {
                aTbl_Product.Product_Name = txtProductName.Text;
                aTbl_Product.ProductCategory_SlNo = Convert.ToInt16(cmbProductCategory.SelectedValue);
                if (chkRawMaterial.Checked)
                {
                    aTbl_Product.Product_IsRawMaterial = true;
                }
                if (chkFinishedGoods.Checked)
                {
                    aTbl_Product.Product_IsFinishedGoods = true;
                }
                aTbl_Product.Product_IsFinishedGoods = chkFinishedGoods.Checked;
                aTbl_Product.Product_ReOrederLevel = Convert.ToInt16(txtReOrderLevel.Text);
                aTbl_Product.Product_Purchase_Rate = Convert.ToDecimal(txtPurchaseRate.Text);
                aTbl_Product.Product_SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                aTbl_Product.Product_VatPercent = Convert.ToDouble(txtVATPercent.Text);
                aTbl_Product.Unit_SlNo = Convert.ToInt16(cmbUnitOfMeasurement.SelectedValue);
                aTbl_Product.Status = "A";
                aTbl_Product.UpdateBy = SplashForm.username;
                aTbl_Product.UpdateTime = DateTime.UtcNow.AddHours(6);

                if (cmbProductCategory.Text == "Select Category" || aTbl_Product.ProductCategory_SlNo == 0)
                {
                    MessageBox.Show("Select a Category", "Warning");
                    cmbProductCategory.Focus();
                    return;
                }
                string msg = aProductBusiness.validateOnUpdate(aTbl_Product);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtProductName.Focus();
                    return;
                }
                if (chkRawMaterial.Checked == false && chkFinishedGoods.Checked == false)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Select a Type");
                    chkRawMaterial.Focus();
                    return;
                }
                if (chkRawMaterial.Checked && chkFinishedGoods.Checked)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Select one Type");
                    return;
                }
                if (cmbUnitOfMeasurement.Text == "Select Unit" || aTbl_Product.Unit_SlNo == 0)
                {
                    MessageBox.Show("Select an Unit", "Warning");
                    cmbUnitOfMeasurement.Focus();
                    return;
                }
                bool res = aProductBusiness.Update(aTbl_Product);
                if (res)
                {
                    LoadGrid();
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
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
                aTbl_Product = null;

            }
        }

        void AddProduct()
        {

            try
            {
                Tbl_Product aTbl_Product = new Tbl_Product();
                aTbl_Product.Product_Code = txtProductCode.Text;
                aTbl_Product.Product_Name = txtProductName.Text;
                aTbl_Product.ProductCategory_SlNo = Convert.ToInt16(cmbProductCategory.SelectedValue);
                if (chkRawMaterial.Checked)
                {
                    aTbl_Product.Product_IsRawMaterial = true;
                }
                if (chkFinishedGoods.Checked)
                {
                    aTbl_Product.Product_IsFinishedGoods = true;
                }
                aTbl_Product.Product_IsFinishedGoods = chkFinishedGoods.Checked;
                aTbl_Product.Product_ReOrederLevel = Convert.ToInt16(txtReOrderLevel.Text);
                aTbl_Product.Product_Purchase_Rate = Convert.ToDecimal(txtPurchaseRate.Text);
                aTbl_Product.Product_SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                aTbl_Product.Product_VatPercent = Convert.ToDouble(txtVATPercent.Text);
                aTbl_Product.Unit_SlNo = Convert.ToInt16(cmbUnitOfMeasurement.SelectedValue);
                aTbl_Product.Status = "A";
                aTbl_Product.AddBy = SplashForm.username;
                aTbl_Product.AddTime = DateTime.UtcNow.AddHours(6);

                if (cmbProductCategory.Text == "Select Category" || aTbl_Product.ProductCategory_SlNo == 0)
                {
                    MessageBox.Show("Select a Category", "Warning");
                    cmbProductCategory.Focus();
                    return;
                }
                string msg = aProductBusiness.validateOnSave(aTbl_Product);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    txtProductName.Focus();
                    return;
                }
                if (chkRawMaterial.Checked == false && chkFinishedGoods.Checked == false)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Select a Type");
                    chkRawMaterial.Focus();
                    return;
                }
                if (chkRawMaterial.Checked && chkFinishedGoods.Checked)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Select one Type");
                    return;
                }
                //if (txtReOrderLevel.Text == "0")
                //{
                //    MessageBox.Show("Enter Reorder level!", "Warning");
                //    txtReOrderLevel.Focus();
                //    return;
                //}
                //if (txtPurchaseRate.Text == "0")
                //{
                //    MessageBox.Show("Enter Purchase Rate!", "Warning");
                //    txtPurchaseRate.Focus();
                //    return;
                //}
                //if (txtSellingPrice.Text == "0")
                //{
                //    MessageBox.Show("Enter Selling Price!", "Warning");
                //    txtSellingPrice.Focus();
                //    return;
                //}

                if (cmbUnitOfMeasurement.Text == "Select Unit" || aTbl_Product.Unit_SlNo == 0)
                {
                    MessageBox.Show("Select an Unit", "Warning");
                    cmbUnitOfMeasurement.Focus();
                    return;
                }
                bool res = aProductBusiness.Insert(aTbl_Product);
                if (res)
                {
                    txtProductName.Text = "";
                    txtPurchaseRate.Text = "0";
                    txtSellingPrice.Text = "0";
                    txtVATPercent.Text = "0";
                    chkFinishedGoods.Checked = true;
                    chkRawMaterial.Checked = false;
                    txtReOrderLevel.Text = "0";
                    txtProductName.Focus();
                    GenerateCode();
                    LoadGrid();
                    //GetProductCategory();
                    //GetUnit();
                    UtilityBusiness.DisplayAlertMessage('S', "Inserted Successfully");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Inserted Failed");
                }
            }
            //catch { }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_Product = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPurchaseRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPurchaseRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSellingPrice.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtSellingPrice.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtReOrderLevel.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void chkRawMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRawMaterial.Checked)
            {
                txtReOrderLevel.Visible = false;
                label5.Visible = false;
            }
            else
            {
                txtReOrderLevel.Visible = true;
                label5.Visible = true;
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ProductCategoryForm ob = new ProductCategoryForm();
            ob.ShowDialog();
            GetProductCategory();
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            UnitOfMeasurementForm ob = new UnitOfMeasurementForm();
            ob.ShowDialog();
            GetUnit();
        }

        private void cmbProductCategory_Click(object sender, EventArgs e)
        {
            if (cmbProductCategory.Text == "Select Category")
            {
                cmbProductCategory.Text = "";
            }
        }

        private void cmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbProductCategory.Text == "Select Category")
            //{
            //    cmbProductCategory.ForeColor = Color.Gray;
            //}
        }

        private void cmbProductCategory_Leave(object sender, EventArgs e)
        {
            if (cmbProductCategory.Text == "")
            {
                cmbProductCategory.Text = "Select Category";
                //if (cmbProductCategory.Text == "Select Category")
                //{
                //    cmbProductCategory.ForeColor = Color.Gray;
                //}
                //else
                //{
                //    cmbProductCategory.ForeColor = Color.Black;
                //}
            }
        }

        private void cmbProductCategory_MouseLeave(object sender, EventArgs e)
        {
            if (cmbProductCategory.Text == "")
            {
                cmbProductCategory.Text = "Select Category";
                //if (cmbProductCategory.Text == "Select Category")
                //{
                //    cmbProductCategory.ForeColor = Color.Gray;
                //}
                //else
                //{
                //    cmbProductCategory.ForeColor = Color.Black;
                //}
            }

        }

        private void cmbUnitOfMeasurement_Click(object sender, EventArgs e)
        {
            if (cmbUnitOfMeasurement.Text == "Select Unit")
            {
                cmbUnitOfMeasurement.Text = "";
            }
        }

        private void cmbUnitOfMeasurement_Leave(object sender, EventArgs e)
        {
            if (cmbUnitOfMeasurement.Text == "")
            {
                cmbUnitOfMeasurement.Text = "Select Unit";
            }
        }

        private void cmbUnitOfMeasurement_MouseLeave(object sender, EventArgs e)
        {
            if (cmbUnitOfMeasurement.Text == "")
            {
                cmbUnitOfMeasurement.Text = "Select Unit";
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.AutoGenerateColumns = false;
            lstQryProductList = aProductBusiness.GetAllQryProductByName(txtSearchProduct.Text);
            lstQryProductList = lstQryProductList.OrderByDescending(x => x.Product_Code).ToList();
            dgvProduct.DataSource = lstQryProductList;
        }


        /// barcode printing

        private void PrintBarcode(string productId)
        {
            int qty = Convert.ToInt16(txtqty.Text);
            Reports.Datasets.Barcodes barcodeDetails = new Reports.Datasets.Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            Reports.BarcodeReport Report = new Reports.BarcodeReport();

            int blank_labels = 0;
            int numberLabel = qty;
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                //string P_name = "DETAIL" + i.ToString();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += txtProductCode.Text;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = txtProductCode.Text;
                    drow["Product Name"] = txtProductName.Text;
                    drow["Cost"] = "Rs " + Convert.ToDecimal(this.txtSellingPrice.Text.Trim()) + "/-";
                    drow["Code"] = txtArticleNo.Text;
                    //drow["ShopName"] = "Shop Name";
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);

            ////----------Print to Printer----------------
            PageMargins margins;
            System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
            margins = Report.PrintOptions.PageMargins;
            margins.bottomMargin = 350;
            margins.leftMargin = 350;
            margins.rightMargin = 350;
            margins.topMargin = 350;
            Report.PrintOptions.ApplyPageMargins(margins);
            Report.PrintOptions.PrinterName = settings.PrinterName;
            Report.PrintToPrinter(1, false, 0, 0);
            MessageBox.Show("Barcode finished printing!");


            //productPrint ViewProduct = new productPrint();
            //ViewProduct.productId = txtProductCode.Text;
            //ViewProduct.productName = txtProductName.Text;
            //byte[] bcode = imageToByteArray(GiveBarcode(txtProductCode.Text.Trim()));
            //ViewProduct.BARCODE = bcode;
            //ViewProduct.ArticleNo = txtArticleNo.Text;
            //ViewProduct.SellPrice = Convert.ToDecimal(this.txtSellingPrice.Text.Trim());

            //List<productPrint> list = new List<productPrint>();
            //list.Add(ViewProduct);

            //Reports.rptPrintBarcode objCRpt = new Reports.rptPrintBarcode();
            //objCRpt.SetDataSource(list);//datasource

            ////-------Page top Data----------------
            //// objCRpt.SetParameterValue("RPT_TITLE", KeyConstants.RECEIPT_TITLE);
            ////objCRpt.SetParameterValue("RPT_DESCRIPTION", KeyConstants.RECEIPT_TYPE_CUSTOMER_ACCOUNT);

            ////----------Print to Printer----------------
            //PageMargins margins;
            //System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
            //margins = objCRpt.PrintOptions.PageMargins;
            //margins.bottomMargin = 350;
            //margins.leftMargin = 350;
            //margins.rightMargin = 350;
            //margins.topMargin = 350;
            //objCRpt.PrintOptions.ApplyPageMargins(margins);
            //objCRpt.PrintOptions.PrinterName = settings.PrinterName;
            //objCRpt.PrintToPrinter(1, false, 0, 0);
            //MessageBox.Show("Barcode finished printing!");
        }

        private void PreviewBarcode(string productId)
        {
            int qty = Convert.ToInt16(txtqty.Text);
            Reports.Datasets.Barcodes barcodeDetails = new Reports.Datasets.Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            Reports.BarcodeReport Report = new Reports.BarcodeReport();

            int blank_labels = 0;
            int numberLabel = qty;
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                //string P_name = "DETAIL" + i.ToString();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += txtProductCode.Text;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = txtProductCode.Text;
                    drow["Product Name"] = txtProductName.Text;
                    drow["Cost"] = "Tk. " + Convert.ToDecimal(this.txtSellingPrice.Text.Trim()) + "/-";
                    drow["Code"] = txtArticleNo.Text;
                    //drow["ShopName"] = "Shop Name";
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);

            ReportViewerForm objCRview = new ReportViewerForm();
            objCRview.Refresh();
            objCRview.ReportViewer.ReportSource = Report;
            objCRview.ShowDialog();


            //productPrint ViewProduct = new productPrint();
            //ViewProduct.productId = txtProductCode.Text;
            //ViewProduct.productName = txtProductName.Text;
            //byte[] bcode = imageToByteArray(GiveBarcode(txtProductCode.Text.Trim()));
            //ViewProduct.BARCODE = bcode;
            //ViewProduct.ArticleNo = txtArticleNo.Text;
            //ViewProduct.SellPrice = Convert.ToDecimal(this.txtSellingPrice.Text.Trim());

            //List<productPrint> list = new List<productPrint>();
            //list.Add(ViewProduct);


            //Reports.rptPrintBarcode objCRpt = new Reports.rptPrintBarcode();
            //objCRpt.SetDataSource(list);//datasource

            ////-------Page top Data----------------
            ////objCRpt.SetParameterValue("RPT_TITLE", KeyConstants.RECEIPT_TITLE);
            ////objCRpt.SetParameterValue("RPT_DESCRIPTION", KeyConstants.RECEIPT_TYPE_CUSTOMER_ACCOUNT);

            ////----------Run Viewer----------------
            //ReportViewerForm objCRview = new ReportViewerForm();
            //objCRview.Refresh();
            //objCRview.ReportViewer.ReportSource = objCRpt;
            //objCRview.ShowDialog();


        }

        //public Image GiveBarcode(string value)
        //{
        //    BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
        //    {
        //        IncludeLabel = true,
        //        Alignment = AlignmentPositions.CENTER,
        //        Width = 250,
        //        Height = 40,
        //        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
        //        BackColor = Color.White,
        //        ForeColor = Color.Black,

        //    };

        //    Image img = barcode.Encode(TYPE.CODE128B, value);
        //    return img;

        //}

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return ms.ToArray();
        //}

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (txtqty.Text == "" || txtProductCode.Text == "" || txtProductName.Text == "")
            {
                MessageBox.Show("Fill required fields!", "Warning");
                return;
            }
            PreviewBarcode(txtProductCode.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtqty.Text == "" || txtProductCode.Text == "" || txtProductName.Text == "")
            {
                MessageBox.Show("Fill required fields!", "Warning");
                return;
            }
            PrintBarcode(txtProductCode.Text);
        }

        private void txtVATPercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUnitOfMeasurement.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                cmbUnitOfMeasurement.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSellingPrice.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtVATPercent_KeyPress(object sender, KeyPressEventArgs e)
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




    }
}
