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
using CrystalDecisions.Shared;

namespace IMS_Win
{
    public partial class StockLevelReportsForm : Form
    {
        SalesBusiness aSalesBusincess = new SalesBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        List<Func_TotalStock> lsTotalStockList = new List<Func_TotalStock>();
        List<Func_TotalStockwithValue> lsTotalStockwithValueList = new List<Func_TotalStockwithValue>();
        List<Qry_CurrentInventory> lstCurrentStockList = new List<Qry_CurrentInventory>();
        ProductBusiness aProductBusiness = new ProductBusiness();
        ProductCategoryBusiness aProductCategoryBusiness = new ProductCategoryBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        public StockLevelReportsForm()
        {
            InitializeComponent();
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
                cmbProduct.Text = "Select Product";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                cmbProduct.Text = "Select Category";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
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

                if (cmbStockType.Text == "Current Stock")
                {
                    List<Qry_CurrentInventory> lstCurrentInventoryList = aCurrentInventoryBusiness.GetAllQryCurrentInventory();
                    Reports.CRCurrentInventory rpt = new Reports.CRCurrentInventory();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(lstCurrentInventoryList);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbStockType.Text == "Total Stock")
                {
                    lsTotalStockList = aProductBusiness.GetAllFunc_TotalStock().Where(x => x.Product_IsFinishedGoods == true).ToList();
                    Reports.CRTotalStock rpt = new Reports.CRTotalStock();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(lsTotalStockList);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbStockType.Text == "Productwise Stock")
                {
                    lsTotalStockList = aProductBusiness.GetAllFunc_TotalStock();
                    lsTotalStockList = lsTotalStockList.Where(x => x.Product_SlNo == Convert.ToInt32(cmbProduct.SelectedValue)).ToList();
                    Reports.CRTotalStock rpt = new Reports.CRTotalStock();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(lsTotalStockList);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbStockType.Text == "Categorywise Stock")
                {
                    lsTotalStockwithValueList = aProductBusiness.GetAllStockwithValue();
                    lsTotalStockwithValueList = lsTotalStockwithValueList.Where(x => x.ProductCategory_Name == cmbProduct.Text).ToList();
                    Reports.CRTotalStock rpt = new Reports.CRTotalStock();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(lsTotalStockwithValueList);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StockLevelReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void viewstock()
        {
            try
            {
                if (cmbStockType.Text == "Current Stock")
                {
                    cmbProduct.Visible = false;
                    clmPurchaseInventory_DamageQuantity.Visible = false;
                    clmPurchaseInventory_ReturnQuantity.Visible = false;
                    clmPurchaseInventory_TotalQuantity.Visible = false;
                    clmSaleInventory_ReturnQuantity.Visible = false;
                    clmSaleInventory_TotalQuantity.Visible = false;
                    clmCurrentInventory_CurrentQuantity.Visible = false;
                    clm_CurrentQuantity.Visible = true;

                    dgvTotalStock.AutoGenerateColumns = false;
                    lstCurrentStockList = aCurrentInventoryBusiness.GetAllQryCurrentInventory();
                    lstCurrentStockList = lstCurrentStockList.OrderBy(x => x.ProductCategory_Name).ToList();
                    dgvTotalStock.DataSource = lstCurrentStockList;

                    double quantity;
                    decimal rate;
                    decimal sum = 0;
                    for (int i = 0; i < dgvTotalStock.Rows.Count; i++)
                    {
                        if (double.TryParse(dgvTotalStock.Rows[i].Cells[9].Value.ToString(), out quantity) && decimal.TryParse(dgvTotalStock.Rows[i].Cells[11].Value.ToString(), out rate))
                        {
                            decimal price = (decimal)quantity * rate;
                            dgvTotalStock.Rows[i].Cells[12].Value = Math.Round(price, 2).ToString();
                            sum += Convert.ToDecimal(dgvTotalStock.Rows[i].Cells[12].Value);
                        }
                        txtTotal.Text = sum.ToString();
                    }
                }

                if (cmbStockType.Text == "Total Stock")
                {
                    clmPurchaseInventory_DamageQuantity.Visible = true;
                    clmPurchaseInventory_ReturnQuantity.Visible = true;
                    clmPurchaseInventory_TotalQuantity.Visible = true;
                    clmCurrentInventory_CurrentQuantity.Visible = true;
                    clmSaleInventory_ReturnQuantity.Visible = true;
                    clmSaleInventory_TotalQuantity.Visible = true;
                    clmProduct_Purchase_Rate.Visible = true;
                    clmTotal_Amount.Visible = true;

                    clm_CurrentQuantity.Visible = false;
                    cmbProduct.Visible = false;

                    dgvTotalStock.AutoGenerateColumns = false;
                    lsTotalStockwithValueList = aProductBusiness.GetAllStockwithValue().Where(x => x.Product_IsFinishedGoods == true).ToList();
                    lsTotalStockwithValueList = lsTotalStockwithValueList.OrderBy(x => x.ProductCategory_Name).ToList();
                    dgvTotalStock.DataSource = lsTotalStockwithValueList;

                    double quantity;
                    decimal rate;
                    decimal sum = 0;
                    for (int i = 0; i < dgvTotalStock.Rows.Count; i++)
                    {
                        if (double.TryParse(dgvTotalStock.Rows[i].Cells[8].Value.ToString(), out quantity) && decimal.TryParse(dgvTotalStock.Rows[i].Cells[11].Value.ToString(), out rate))
                        {
                            decimal price = (decimal)quantity * rate;
                            dgvTotalStock.Rows[i].Cells[12].Value = Math.Round(price, 2).ToString();
                            sum += Convert.ToDecimal(dgvTotalStock.Rows[i].Cells[12].Value);
                        }
                        txtTotal.Text = sum.ToString();
                    }
                }

                if (cmbStockType.Text == "Productwise Stock")
                {
                    clmPurchaseInventory_DamageQuantity.Visible = true;
                    clmPurchaseInventory_ReturnQuantity.Visible = true;
                    clmPurchaseInventory_TotalQuantity.Visible = true;
                    clmCurrentInventory_CurrentQuantity.Visible = true;
                    clmSaleInventory_ReturnQuantity.Visible = true;
                    clmSaleInventory_TotalQuantity.Visible = true;
                    clm_CurrentQuantity.Visible = false;

                    dgvTotalStock.AutoGenerateColumns = false;
                    lsTotalStockwithValueList = aProductBusiness.GetAllStockwithValue();
                    lsTotalStockwithValueList = lsTotalStockwithValueList.Where(x => x.Product_SlNo == Convert.ToInt32(cmbProduct.SelectedValue)).ToList();
                    dgvTotalStock.DataSource = null;
                    dgvTotalStock.DataSource = lsTotalStockwithValueList;

                    double quantity;
                    decimal rate;
                    decimal sum = 0;
                    for (int i = 0; i < dgvTotalStock.Rows.Count; i++)
                    {
                        if (double.TryParse(dgvTotalStock.Rows[i].Cells[8].Value.ToString(), out quantity) && decimal.TryParse(dgvTotalStock.Rows[i].Cells[11].Value.ToString(), out rate))
                        {
                            decimal price = (decimal)quantity * rate;
                            dgvTotalStock.Rows[i].Cells[12].Value = Math.Round(price, 2).ToString();
                            sum += Convert.ToDecimal(dgvTotalStock.Rows[i].Cells[12].Value);
                        }
                        txtTotal.Text = sum.ToString();
                    }
                }

                if (cmbStockType.Text == "Categorywise Stock")
                {
                    clmPurchaseInventory_DamageQuantity.Visible = false;
                    clmPurchaseInventory_ReturnQuantity.Visible = false;
                    clmPurchaseInventory_TotalQuantity.Visible = false;
                    clmCurrentInventory_CurrentQuantity.Visible = true;
                    clmSaleInventory_ReturnQuantity.Visible = false;
                    clmSaleInventory_TotalQuantity.Visible = false;
                    clm_CurrentQuantity.Visible = false;
                    clmProduct_Purchase_Rate.Visible = true;
                    clmTotal_Amount.Visible = true;

                    dgvTotalStock.AutoGenerateColumns = false;
                    lsTotalStockwithValueList = aProductBusiness.GetAllStockwithValue();
                    lsTotalStockwithValueList = lsTotalStockwithValueList.Where(x => x.ProductCategory_Name == cmbProduct.Text).ToList();
                    dgvTotalStock.DataSource = null;
                    dgvTotalStock.DataSource = lsTotalStockwithValueList;

                    double quantity;
                    decimal rate;
                    decimal sum = 0;
                    for (int i = 0; i < dgvTotalStock.Rows.Count; i++)
                    {
                        if (double.TryParse(dgvTotalStock.Rows[i].Cells[8].Value.ToString(), out quantity) && decimal.TryParse(dgvTotalStock.Rows[i].Cells[11].Value.ToString(), out rate))
                        {
                            decimal price = (decimal)quantity * rate;
                            dgvTotalStock.Rows[i].Cells[12].Value = Math.Round(price, 2).ToString();
                            sum += Convert.ToDecimal(dgvTotalStock.Rows[i].Cells[12].Value);
                        }
                        txtTotal.Text = sum.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            viewstock();
        }

        private void cmbStockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStockType.Text == "Current Stock")
            {
                cmbProduct.Visible = false;
                dgvTotalStock.DataSource = null;
                txtTotal.Text = "0";
            }
            if (cmbStockType.Text == "Total Stock")
            {
                cmbProduct.Visible = false;
                dgvTotalStock.DataSource = null;
                txtTotal.Text = "0";
            }
            if (cmbStockType.Text == "Productwise Stock")
            {
                GetProduct();
                dgvTotalStock.DataSource = null;
                txtTotal.Text = "0";
            }
            else if (cmbStockType.Text == "Categorywise Stock")
            {
                GetCategory();
                dgvTotalStock.DataSource = null;
                txtTotal.Text = "0";
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_Click(object sender, EventArgs e)
        {
            if (cmbProduct.Text == "")
            {
                cmbProduct.Text = "Select Product";
            }
        }

    }
}
