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
    public partial class PurchaseReturnForm : Form
    {
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        PurchaseBusiness aPurchaseBusincess = new PurchaseBusiness();
        List<returnProduct> lstReturnProductList = new List<returnProduct>();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        PurchaseBusiness aPurchaseInventoryBusincess = new PurchaseBusiness();
        int supplierId = 0;
        public PurchaseReturnForm()
        {
            InitializeComponent();
        }
        private void GetInvoiceNoToListBox()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DisplayMember = "PurchaseMaster_InvoiceNo";
                //listBox1.ValueMember = "SaleMaster_InvoiceNo";
                listBox1.DataSource = aPurchaseBusincess.GetAllPurchaseMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoice.Text == "")
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Enter Invoice No.!");
                    lstReturnProductList = new List<returnProduct>();
                    dgvPurchase.DataSource = null;
                    txtInvoice.Focus();
                    return;
                }

                lstReturnProductList.Clear();

                List<Qry_PurchaseMasterDetails> lstPurchaseList = aPurchaseBusincess.GetAllPurchaseMasterDetails(txtInvoice.Text);

                List<Qry_PurchaseReturnMasterDetails> lstReturnList = aPurchaseBusincess.GetAllPurchaseReturnMasterDetails(txtInvoice.Text);

                if (lstPurchaseList.Any())
                {
                    var row = lstPurchaseList.First();
                    lblSupplierName.Text = row.Supplier_Name;

                    supplierId = lstPurchaseList[0].Supplier_SlNo;
                    foreach (var purchase in lstPurchaseList)
                    {
                        returnProduct areturnProduct = new returnProduct();
                        areturnProduct.Product_SlNo = purchase.Product_SlNo;
                        areturnProduct.Product_Name = purchase.Product_Name;
                        areturnProduct.TotalQuantity = purchase.PurchaseDetails_TotalQuantity;
                        areturnProduct.TotalAmount = purchase.PurchaseDetails_TotalAmount;
                        areturnProduct.TotalAmount = purchase.PurchaseDetails_TotalAmount;

                        if (lstReturnList.Any(x => x.Product_SlNo == purchase.Product_SlNo))
                        {
                            areturnProduct.AlreadyReturnQuantity = lstReturnList.Where(x => x.Product_SlNo == purchase.Product_SlNo).Sum(x => x.PurchaseReturnDetails_ReturnQuantity);
                        }
                        else
                        {
                            areturnProduct.AlreadyReturnQuantity = 0;
                        }
                        if (lstReturnList.Any(x => x.Product_SlNo == purchase.Product_SlNo))
                        {
                            areturnProduct.AlreadyReturnAmount = lstReturnList.Where(x => x.Product_SlNo == purchase.Product_SlNo).Sum(x => x.PurchaseReturnDetails_ReturnAmount);
                        }
                        else
                        {
                            areturnProduct.AlreadyReturnAmount = 0;
                        }
                        areturnProduct.ReturnQuantity = 0;
                        areturnProduct.ReturnAmount = 0;

                        lstReturnProductList.Add(areturnProduct);
                    }

                    dgvPurchase.DataSource = null;
                    dgvPurchase.DataSource = lstReturnProductList;
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                    lstReturnProductList = new List<returnProduct>();
                    dgvPurchase.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PurchaseReturnForm_Load(object sender, EventArgs e)
        {
            GetInvoiceNoToListBox();
            dgvPurchase.AutoGenerateColumns = false;
            txtInvoice.Focus();
        }

        private void txtInvoice_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
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

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox1.Visible = true;
            }
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
                MessageBox.Show("Please Select any Invoice!");
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstReturnProductList.Any())
            {
                if ((MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                {
                    return;
                }

                // get supplierdue
                decimal purchasedue = 0;
                decimal paidamt = 0;
                decimal recievefromSupplier = 0;
                decimal supplierDue = 0;

                List<Qry_PurchaseMasterDetails> lstQry_PurchaseMasterDetails = aPurchaseBusincess.GetAllPurchaseMasterDetails(txtInvoice.Text);
                var row = lstQry_PurchaseMasterDetails.First();

                List<Tbl_PurchaseMaster> lstMasterList = aPurchaseInventoryBusincess.GetAllPurchaseMasterBySupplier(row.Supplier_SlNo);
                if (lstMasterList.Any())
                {
                    purchasedue = lstMasterList.Where(x => x.PurchaseMaster_DueAmount > 0).Sum(y => y.PurchaseMaster_DueAmount);

                    List<Tbl_CashTransaction> lstCashTransactionList = aCashAccountBusiness.GetAllCashAccountBySupplier(row.Supplier_SlNo);
                    if (lstCashTransactionList.Any())
                    {
                        paidamt = lstCashTransactionList.Sum(x => x.Out_Amount);
                        recievefromSupplier = lstCashTransactionList.Sum(x => x.In_Amount);
                    }
                }

                supplierDue = (purchasedue + recievefromSupplier) - paidamt;
                //

                //List<Tbl_PurchaseReturn> lstmasterList = new List<Tbl_PurchaseReturn>();
                Tbl_PurchaseReturn aTbl_PurchaseReturn = new Tbl_PurchaseReturn();
                aTbl_PurchaseReturn.PurchaseMaster_InvoiceNo = txtInvoice.Text;
                aTbl_PurchaseReturn.PurchaseReturn_Description = txtDescription.Text;
                aTbl_PurchaseReturn.PurchaseReturn_ReturnDate = dtpDate.Value.Date;
                aTbl_PurchaseReturn.PurchaseReturn_ReturnQuantity = lstReturnProductList.Sum(x => x.ReturnQuantity);
                aTbl_PurchaseReturn.PurchaseReturn_ReturnAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                aTbl_PurchaseReturn.Status = "A";
                aTbl_PurchaseReturn.AddBy = SplashForm.username;
                aTbl_PurchaseReturn.AddTime = DateTime.UtcNow.AddHours(6);
                aTbl_PurchaseReturn.Supplier_SlNo = supplierId;

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

                //lstmasterList.Add(aTbl_PurchaseReturn);
                aPurchaseBusincess.InsertOrUpdatePurchaseReturn(aTbl_PurchaseReturn);

                if (supplierDue > 0)
                {
                    // cash transaction entry to pay due
                    Tbl_CashTransaction aTbl_CashTransaction = new Tbl_CashTransaction();
                    aTbl_CashTransaction.Tr_Id = aCashAccountBusiness.GenerateTrCode();
                    aTbl_CashTransaction.Supplier_SlNo = row.Supplier_SlNo;
                    aTbl_CashTransaction.Acc_Code = row.Supplier_Code;
                    aTbl_CashTransaction.In_Amount = 0;
                    aTbl_CashTransaction.Out_Amount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashTransaction.Tr_Type = "Due Adjustment";
                    aTbl_CashTransaction.Tr_date = dtpDate.Value.Date;
                    aTbl_CashTransaction.Tr_Description = "Supplier due adjustment";
                    aTbl_CashTransaction.Status = "A";
                    aTbl_CashTransaction.AddBy = SplashForm.username;
                    aTbl_CashTransaction.AddTime = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.Insert(aTbl_CashTransaction);

                    // cash register entry
                    List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                    Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                    aTbl_CashRegister.Transaction_Date = dtpDate.Value.Date;
                    aTbl_CashRegister.Narration = "Supplier due adjustment";
                    aTbl_CashRegister.OutAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashRegister.InAmount = 0;
                    aTbl_CashRegister.Description = txtDescription.Text;
                    aTbl_CashRegister.Status = "A";
                    aTbl_CashRegister.Saved_By = SplashForm.username;
                    aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);
                    //
                }

                else
                {
                    //cash register entry

                    List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                    Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                    aTbl_CashRegister.Transaction_Date = dtpDate.Value.Date;
                    aTbl_CashRegister.Narration = "Return from Supplier";
                    aTbl_CashRegister.InAmount = lstReturnProductList.Sum(x => x.ReturnAmount);
                    aTbl_CashRegister.OutAmount = 0;
                    aTbl_CashRegister.Description = txtDescription.Text;
                    aTbl_CashRegister.Status = "A";
                    aTbl_CashRegister.Saved_By = SplashForm.username;
                    aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                    aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);
                }

                List<Tbl_PurchaseReturnDetails> lstReturnDetailList = new List<Tbl_PurchaseReturnDetails>();
                List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();
                List<Tbl_PurchaseInventory> lstInventoryList = new List<Tbl_PurchaseInventory>();
                foreach (var detail in lstReturnProductList)
                {
                    Tbl_PurchaseReturnDetails returndetails = new Tbl_PurchaseReturnDetails();
                    returndetails.Product_SlNo = detail.Product_SlNo;
                    returndetails.PurchaseReturn_SlNo = aTbl_PurchaseReturn.PurchaseReturn_SlNo;
                    returndetails.PurchaseReturnDetails_ReceiveQuantity = detail.TotalQuantity;
                    returndetails.PurchaseReturnDetails_ReturnDate = dtpDate.Value.Date;

                    if (detail.ReturnQuantity > detail.TotalQuantity - detail.AlreadyReturnQuantity)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', "Return quantity is can't be greater than total quantity");
                        return;
                    }

                    returndetails.PurchaseReturnDetails_ReturnQuantity = detail.ReturnQuantity;
                    returndetails.PurchaseReturnDetails_ReturnAmount = detail.ReturnAmount;
                    returndetails.Status = "A";
                    returndetails.AddBy = SplashForm.username;
                    returndetails.AddTime = DateTime.UtcNow.AddHours(6);
                    lstReturnDetailList.Add(returndetails);

                    Tbl_PurchaseInventory inventory = new Tbl_PurchaseInventory();
                    Tbl_PurchaseInventory existData = aPurchaseInventoryBusincess.GetAllPurchaseInventory(returndetails.Product_SlNo);

                    if (existData != null)
                    {
                        inventory = existData;
                    }

                    inventory.Product_SlNo = returndetails.Product_SlNo;
                    inventory.PurchaseInventory_ReturnQuantity += returndetails.PurchaseReturnDetails_ReturnQuantity;

                    lstInventoryList.Add(inventory);

                    Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(returndetails.Product_SlNo);
                    if (curinv != null)
                    {
                        curinv.CurrentInventory_CurrentQuantity -= detail.ReturnQuantity;
                        if (curinv.CurrentInventory_CurrentQuantity < 0)
                        {
                            curinv.CurrentInventory_CurrentQuantity = 0;
                        }
                        lstCurrentInventoryList.Add(curinv);
                    }
                }

                //aPurchaseBusincess.SavePurchaseReturn(lstmasterList, lstReturnDetailList, lstInventoryList, lstCurrentInventoryList);
                aPurchaseBusincess.InsertOrUpdatePurchaseReturnDetails(lstReturnDetailList);
                aPurchaseInventoryBusincess.InsertorUpdatePurchaseInventory(lstInventoryList);
                aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstCurrentInventoryList);
                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
                dgvPurchase.DataSource = null;
                lstReturnProductList = new List<returnProduct>();
                txtInvoice.Text = string.Empty;
                lblSupplierName.Text = "";
                txtInvoice.Focus();

            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }


    }

}
