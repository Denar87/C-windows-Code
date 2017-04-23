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
    public partial class SaleReturnForm : Form
    {
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        SalesBusiness aSaleBusincess = new SalesBusiness();
        List<returnProduct> lstReturnProductList = new List<returnProduct>();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        SalesBusiness aSalesdetailsBusiness = new SalesBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        public SaleReturnForm()
        {
            InitializeComponent();
        }

        private void GetInvoiceNoToListBox()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DisplayMember = "SaleMaster_InvoiceNo";
                //listBox1.ValueMember = "SaleMaster_InvoiceNo";
                listBox1.DataSource = aSalesBusiness.GetAllSalesMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstReturnProductList.Clear();
            List<Qry_SaleMasterDetails> lstSaleList = aSaleBusincess.GetAllSaleMasterDetailsByInvoice(txtInvoice.Text);
            var row = lstSaleList.First();
            lblCustomerName.Text = row.Customer_Name;

            List<Qry_SaleReturnMasterDetails> lstReturnList = aSaleBusincess.GetAllSaleReturnMasterDetails(txtInvoice.Text);
            if (lstSaleList.Any())
            {
                foreach (var Sale in lstSaleList)
                {
                    returnProduct areturnProduct = new returnProduct();
                    areturnProduct.Product_SlNo = Sale.Product_SlNo;
                    areturnProduct.Product_Name = Sale.Product_Name;
                    areturnProduct.TotalQuantity = Sale.SaleDetails_TotalQuantity;
                    areturnProduct.TotalAmount = Sale.SaleDetails_TotalAmount;
                    areturnProduct.Customer_Name = Sale.Customer_Name;

                    if (lstReturnList.Any(x => x.Product_SlNo == Sale.Product_SlNo))
                    {
                        areturnProduct.AlreadyReturnQuantity = lstReturnList.Where(x => x.Product_SlNo == Sale.Product_SlNo).Sum(x => x.SaleReturnDetails_ReturnQuantity);
                    }
                    else
                    {
                        areturnProduct.AlreadyReturnQuantity = 0;
                    }
                    if (lstReturnList.Any(x => x.Product_SlNo == Sale.Product_SlNo))
                    {
                        areturnProduct.AlreadyReturnAmount = lstReturnList.Where(x => x.Product_SlNo == Sale.Product_SlNo).Sum(x => x.SaleReturnDetails_ReturnAmount);
                    }
                    else
                    {
                        areturnProduct.AlreadyReturnAmount = 0;
                    }

                    areturnProduct.ReturnQuantity = 0;
                    areturnProduct.ReturnAmount = 0;

                    lstReturnProductList.Add(areturnProduct);
                }

                dgvSale.DataSource = null;
                dgvSale.DataSource = lstReturnProductList;

                //txtReturnAmount.Text = Math.Round(lstReturnProductList.Sum(x => x.ReturnAmount), 2).ToString();
            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                lstReturnProductList = new List<returnProduct>();
                dgvSale.DataSource = null;
                //txtReturnAmount.Text = string.Empty;
            }

        }

        private void SaleReturnForm_Load(object sender, EventArgs e)
        {
            GetInvoiceNoToListBox();
            dgvSale.AutoGenerateColumns = false;
            txtInvoice.Focus();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txtInvoice.Text = listBox1.Text.ToString();
                listBox1.Visible = false;
                btnSearch.Focus();
            }
            catch
            {
                MessageBox.Show("Please Select An Invoice!");
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtInvoice.Text = listBox1.Text.ToString();
                    listBox1.Visible = false;
                    btnSearch.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Select any Invoice!");
                }
            }
        }

        private void txtInvoice_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox1.Visible = true;
            }
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listBox1.Visible = true;
                listBox1.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstReturnProductList.Any())
            {
                if ((MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                {
                    return;
                }

                // get customerdue
                decimal salesedue = 0;
                decimal paidamt = 0;
                decimal paytoCustomer = 0;
                decimal customerdue = 0;

                List<Qry_SaleMasterDetails> lstSaleList = aSaleBusincess.GetAllSaleMasterDetailsByInvoice(txtInvoice.Text);
                var row = lstSaleList.First();

                List<Tbl_SalesMaster> lstMasterList = aSalesBusiness.GetAllSaleMasterByCustomer(Convert.ToInt16(row.Customer_SlNo));
                if (lstMasterList.Any())
                {
                    salesedue = lstMasterList.Where(x => x.SaleMaster_DueAmount > 0).Sum(y => y.SaleMaster_DueAmount);

                    List<Tbl_CashTransaction> lstCashAccountCustomerDueList = aCashAccountBusiness.GetAllCashAccountByCustomer(Convert.ToInt16(row.Customer_SlNo));
                    if (lstCashAccountCustomerDueList.Any())
                    {
                        paidamt = lstCashAccountCustomerDueList.Sum(x => x.In_Amount);
                        paytoCustomer = lstCashAccountCustomerDueList.Sum(x => x.Out_Amount);
                    }
                }
                customerdue = (salesedue + paytoCustomer) - paidamt;
                //

                //if (customerdue > 0)
                //{
                //        UtilityBusiness.DisplayAlertMessage('W', "This cutomer has due!");
                //        return;
                //}

                Tbl_SaleReturn aTbl_SaleReturn = new Tbl_SaleReturn();
                aTbl_SaleReturn.SaleMaster_InvoiceNo = txtInvoice.Text;
                aTbl_SaleReturn.SaleReturn_Description = txtDescription.Text;
                aTbl_SaleReturn.SaleReturn_ReturnDate = dtpDate.Value.Date;
                aTbl_SaleReturn.SaleReturn_ReturnQuantity = lstReturnProductList.Sum(x => x.ReturnQuantity);
                aTbl_SaleReturn.SaleReturn_ReturnAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                aTbl_SaleReturn.Status = "A";
                aTbl_SaleReturn.AddBy = SplashForm.username;
                aTbl_SaleReturn.AddTime = DateTime.UtcNow.AddHours(6);

                if (lstReturnProductList.Sum(x => x.ReturnQuantity) > (lstReturnProductList.Sum(x => x.TotalQuantity) - lstReturnProductList.Sum(x => x.AlreadyReturnQuantity)))
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Return quantity can't be greater than total quantity");
                    return;
                }
                if (lstReturnProductList.Sum(x => x.ReturnAmount) > (lstReturnProductList.Sum(x => x.TotalAmount) - lstReturnProductList.Sum(x => x.AlreadyReturnAmount)))
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Return Amount can't be greater than total amount");
                    return;
                }

                if (customerdue < lstReturnProductList.Sum(x => x.ReturnAmount) && customerdue > 0)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Return amount can't be greater than due");
                    return;
                }

                aSaleBusincess.InsertOrUpdateSaleReturn(aTbl_SaleReturn);

                if (customerdue > 0)
                {
                    // cash transaction entry to receive due
                    Tbl_CashTransaction aTbl_CashTransaction = new Tbl_CashTransaction();
                    aTbl_CashTransaction.Tr_Id = aCashAccountBusiness.GenerateTrCode();
                    aTbl_CashTransaction.Customer_SlNo = row.Customer_SlNo;
                    aTbl_CashTransaction.Acc_Code = row.Customer_Code;
                    aTbl_CashTransaction.In_Amount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashTransaction.Out_Amount = 0;
                    aTbl_CashTransaction.Tr_Type = "Due Adjustment";
                    aTbl_CashTransaction.Tr_date = dtpDate.Value.Date;
                    aTbl_CashTransaction.Tr_Description = "Customer due adjustment";
                    aTbl_CashTransaction.Status = "A";
                    aTbl_CashTransaction.AddBy = SplashForm.username;
                    aTbl_CashTransaction.AddTime = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.Insert(aTbl_CashTransaction);

                    // cash register entry
                    List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                    Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                    aTbl_CashRegister.Transaction_Date = dtpDate.Value.Date;
                    aTbl_CashRegister.IdentityNo = aTbl_SaleReturn.SaleReturn_SlNo.ToString();
                    aTbl_CashRegister.Narration = "Due adjustment";
                    aTbl_CashRegister.OutAmount = 0;
                    aTbl_CashRegister.InAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashRegister.Description = txtDescription.Text;
                    aTbl_CashRegister.Status = "A";
                    aTbl_CashRegister.Saved_By = SplashForm.username;
                    aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);
                    //
                }

                else
                {
                    // cash register entry
                    List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                    Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                    aTbl_CashRegister.Transaction_Date = dtpDate.Value.Date;
                    aTbl_CashRegister.IdentityNo = aTbl_SaleReturn.SaleReturn_SlNo.ToString();
                    aTbl_CashRegister.Narration = "Sell Return"; 
                    aTbl_CashRegister.OutAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashRegister.InAmount = 0;
                    aTbl_CashRegister.Description = txtDescription.Text;
                    aTbl_CashRegister.Status = "A";
                    aTbl_CashRegister.Saved_By = SplashForm.username;
                    aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);
                    //
                }

                List<Tbl_SaleReturnDetails> lstReturnDetailList = new List<Tbl_SaleReturnDetails>();
                List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();
                List<Tbl_SaleInventory> lstInventoryList = new List<Tbl_SaleInventory>();
                foreach (var detail in lstReturnProductList)
                {
                    Tbl_SaleReturnDetails returndetails = new Tbl_SaleReturnDetails();
                    returndetails.Product_SlNo = detail.Product_SlNo;
                    returndetails.SaleReturn_SlNo = aTbl_SaleReturn.SaleReturn_SlNo;
                    returndetails.SaleReturnDetails_SaleQuantity = detail.TotalQuantity;
                    returndetails.SaleReturnDetails_ReturnDate = dtpDate.Value.Date;

                    //if (customerdue > detail.ReturnAmount)
                    //{
                    //    UtilityBusiness.DisplayAlertMessage('W', "Return amount can't be greater than due");
                    //    return;
                    //}

                    if (detail.ReturnQuantity > detail.TotalQuantity - detail.AlreadyReturnQuantity)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', "Return quantity can't be greater than total quantity");
                        return;
                    }

                    returndetails.SaleReturnDetails_ReturnQuantity = detail.ReturnQuantity;
                    returndetails.SaleReturnDetails_ReturnAmount = detail.ReturnAmount;
                    returndetails.Status = "A";
                    returndetails.AddBy = SplashForm.username;
                    returndetails.AddTime = DateTime.UtcNow.AddHours(6);
                    lstReturnDetailList.Add(returndetails);

                    Tbl_SaleInventory inventory = new Tbl_SaleInventory();
                    Tbl_SaleInventory existData = aSalesdetailsBusiness.GetAllSalesInventory(returndetails.Product_SlNo);

                    if (existData != null)
                    {
                        inventory = existData;
                    }

                    inventory.Product_SlNo = returndetails.Product_SlNo;
                    inventory.SaleInventory_ReturnQuantity += returndetails.SaleReturnDetails_ReturnQuantity;

                    lstInventoryList.Add(inventory);

                    Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(returndetails.Product_SlNo);
                    if (curinv != null)
                    {
                        curinv.CurrentInventory_CurrentQuantity += detail.ReturnQuantity;
                        if (curinv.CurrentInventory_CurrentQuantity < 0)
                        {
                            curinv.CurrentInventory_CurrentQuantity = 0;
                        }
                        lstCurrentInventoryList.Add(curinv);
                    }
                }

                //aSaleBusincess.SaveSaleReturn(lstmasterList, lstReturnDetailList, lstInventoryList, lstCurrentInventoryList);
                aSaleBusincess.InsertOrUpdateSaleReturnDetails(lstReturnDetailList);
                aSalesdetailsBusiness.InsertorUpdateSalesInventory(lstInventoryList);
                aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstCurrentInventoryList);
                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
                dgvSale.DataSource = null;
                lstReturnProductList = new List<returnProduct>();
                txtInvoice.Text = string.Empty;
                lblCustomerName.Text = "";
                txtInvoice.Focus();
            }

            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }
    }
}
