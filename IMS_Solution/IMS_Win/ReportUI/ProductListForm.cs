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
    public partial class ProductListForm : Form
    {
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        ProductCategoryBusiness aProductCategoryBusiness = new ProductCategoryBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        List<Qry_Product> lstProductList = new List<Qry_Product>();
        List<Tbl_Product> lstProduct = new List<Tbl_Product>();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        int selectedIndex = 0;

        public ProductListForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            Reports.CRProductReport rpt = new Reports.CRProductReport();
            ReportViewerForm frm = new ReportViewerForm();

            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
            ParameterField objParameterField = new ParameterField();

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "paramUser";
            objDiscreteValue.Value = SplashForm.username;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            frm.ReportViewer.ParameterFieldInfo = paramFields;

            if (cmbStockType.Text == "All")
            {
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true).ToList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(lstProductList);

                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            if (cmbStockType.Text == "Select Category")
            {
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true && x.ProductCategory_Name == cmbProduct.Text).ToList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(lstProductList);

                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            if (cmbStockType.Text == "Select Product")
            {
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true && x.Product_Name == cmbProduct.Text).ToList();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(lstProductList);

                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
        }

        void LoadGrid()
        {
            if (cmbStockType.Text == "All")
            {
                dgvProductList.AutoGenerateColumns = false;
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true).ToList();
                lstProductList = lstProductList.OrderBy(x => x.ProductCategory_Name).ToList();
                dgvProductList.DataSource = lstProductList;
            }
            if (cmbStockType.Text == "Select Category")
            {
                dgvProductList.AutoGenerateColumns = false;
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true && x.ProductCategory_Name == cmbProduct.Text).ToList();
                lstProductList = lstProductList.OrderBy(x => x.ProductCategory_Name).ToList();
                dgvProductList.DataSource = lstProductList;
            }
            if (cmbStockType.Text == "Select Product")
            {
                dgvProductList.AutoGenerateColumns = false;
                lstProductList = aProductBusiness.GetAllQryProduct().Where(x => x.Product_IsFinishedGoods == true && x.Product_Name == cmbProduct.Text).ToList();
                lstProductList = lstProductList.OrderBy(x => x.ProductCategory_Name).ToList();
                dgvProductList.DataSource = lstProductList;
            }
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void cmsProductlist_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                cmsProductlist.Visible = false;
                if (e.ClickedItem.Text == "Edit")
                {
                    int id = lstProductList[selectedIndex].Product_SlNo;
                    ProductForm ob = new ProductForm();
                    ob.id = id;
                    ob.ShowDialog();
                    LoadGrid();
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = lstProductList[selectedIndex].Product_SlNo;
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
                            aTbl_Product = null;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void GetCategory()
        {
            try
            {
                cmbProduct.Visible = true;
                cmbProduct.DataSource = null;
                cmbProduct.DisplayMember = "ProductCategory_Name";
                cmbProduct.ValueMember = "ProductCategory_SlNo";
                cmbProduct.DataSource = aProductCategoryBusiness.GetAllProductCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetProduct()
        {
            try
            {
                cmbProduct.Visible = true;
                cmbProduct.DataSource = null;
                cmbProduct.DisplayMember = "Product_Name";
                cmbProduct.ValueMember = "Product_SlNo";
                cmbProduct.DataSource = aProductBusiness.GetAllProduct().Where(x => x.Product_IsFinishedGoods == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbStockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStockType.Text == "All")
            {
                cmbProduct.Visible = false;
            }
            if (cmbStockType.Text == "Select Category")
            {
                GetCategory();
            }
            else if (cmbStockType.Text == "Select Product")
            {
                GetProduct();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dgvProductList_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstProductList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsProductlist.Visible = true;
                    cmsProductlist.Items.Clear();
                    cmsProductlist.Items.Add("Edit");
                    cmsProductlist.Items.Add("Delete");
                    cmsProductlist.Show(dgvProductList, new Point(e.X, e.Y));
                }
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }
    }
}
