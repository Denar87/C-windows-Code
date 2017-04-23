﻿using System;
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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace IMS_Win
{
    public partial class ProductSalesForm_exchange : Form
    {
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        Tbl_Employee aEmployee = new Tbl_Employee();
        Qry_Customer acustomer = new Qry_Customer();
        List<Qry_SalesDetails> lstProductList = new List<Qry_SalesDetails>();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        SalesBusiness aSalesdetailsBusiness = new SalesBusiness();
        List<Qry_Customer> lstCustomerList = new List<Qry_Customer>();
        Tbl_SalesMaster aTbl_SalesMaster = new Tbl_SalesMaster();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();

        List<Qry_SalesMaster> lstQry_SalesMaster = new List<Qry_SalesMaster>();

        public ProductSalesForm_exchange()
        {
            InitializeComponent();
        }

        public int id = 0;

        void GetProduct()
        {
            try
            {
                List<Qry_Product> lstProductList = aProductBusiness.GetAllQryProductByProductType(txtProductID.Text, chkProduct.Checked);
                lstProductList = lstProductList.OrderBy(x => x.Product_Name).ToList();
                productListView.Items.Clear();
                if (lstProductList.Any())
                {
                    productListView.Visible = true;

                    foreach (Qry_Product aProduct in lstProductList)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        aListViewItem.Tag = aProduct;
                        aListViewItem.Text = aProduct.Product_Code;
                        aListViewItem.SubItems.Add(aProduct.Product_Name);
                        aListViewItem.SubItems.Add(aProduct.ProductCategory_Name);
                        aListViewItem.SubItems.Add(aProduct.Unit_Name);
                        productListView.Items.Add(aListViewItem);
                    }
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        void GetCustomer()
        {
            try
            {
                if (localRadioButton.Checked)
                {
                    lstCustomerList = aCustomerBusiness.GetAllCustomerbyType(txtcustomercode.Text, "Local").ToList();
                }
                else if (foreignRadioButton.Checked)
                {
                    lstCustomerList = aCustomerBusiness.GetAllCustomerbyType(txtcustomercode.Text, "Foreign").ToList();
                }

                customerlistView.Items.Clear();
                if (lstCustomerList.Any())
                {
                    customerlistView.Visible = true;
                    foreach (Qry_Customer customer in lstCustomerList)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        aListViewItem.Tag = customer;
                        aListViewItem.Text = customer.Customer_Code;
                        aListViewItem.SubItems.Add(customer.Customer_Name);
                        aListViewItem.SubItems.Add(customer.Customer_Address);
                        aListViewItem.SubItems.Add(customer.Customer_Mobile);
                        customerlistView.Items.Add(aListViewItem);
                    }
                }
            }
            catch
            {
            }
        }

        void loadGrid()
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = lstProductList;
                txtSubTotal.Text = Math.Round(lstProductList.Sum(x => x.SaleDetails_TotalAmount), 2).ToString();
                txtProductTotal.Text = txtSubTotal.Text;
                txtRecieved.Text = txtSubTotal.Text;
                lbltotalamount.Text = txtProductTotal.Text;

                txtProductID.Text = "";
                txtProductName.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                txtAvailable.Text = "0";
                txtProductID.Focus();
            }
            catch
            {
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            if (txtProductID.Text != string.Empty)
            {
                GetProduct();
            }
        }

        private void productListView_Click(object sender, EventArgs e)
        {
            try
            {
                aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                txtProductID.Text = aTbl_Product.Product_Code;
                txtProductName.Text = aTbl_Product.Product_Name;
                txtRate.Text = Math.Round(aTbl_Product.Product_SellingPrice, 2).ToString();
                lblVatParcent.Text = aTbl_Product.Product_VatPercent.ToString();
                lblunit.Text = aTbl_Product.Unit_Name;

                GetItemCurrentStock lstGetItemCurrentStock = aCurrentInventoryBusiness.GetInventoryByProductId2(aTbl_Product.Product_SlNo);

                if (lstGetItemCurrentStock != null)
                {
                    productListView.Visible = false;
                    txtAvailable.Text = lstGetItemCurrentStock.CurrentInventory_CurrentQuantity.ToString();
                }

                else
                {
                    productListView.Visible = false;
                    txtAvailable.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Purchase Record Found Of This Product!");
                }

                txtProductID.BackColor = Color.MintCream;
                txtQuantity.Focus();
                txtQuantity.BackColor = Color.LightCyan;
            }
            catch
            {
            }
        }

        private void txtProductID_Click(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (id == 0)
                    {
                        lstProductList.RemoveAt(e.RowIndex);
                        loadGrid();
                        txtVatAmount.Text = Math.Round(lstProductList.Sum(x => x.SaleDetails_Tax), 2).ToString();
                    }
                    else
                    {
                        if (lstProductList[e.RowIndex].SaleDetails_SlNo == 0)
                        {
                            lstProductList.RemoveAt(e.RowIndex);
                            loadGrid();
                        }
                        else
                        {
                            var objd = lstProductList[e.RowIndex];
                            var detailList = aSalesBusiness.GetAllTbl_SaleDetailsByid(objd.SaleDetails_SlNo);
                            List<Tbl_SaleDetails> lstUpdate = new List<Tbl_SaleDetails>();
                            List<Tbl_CurrentInventory> lstupdateCurrentInventory = new List<Tbl_CurrentInventory>();
                            List<Tbl_SaleInventory> lstUpdateSalesInveontory = new List<Tbl_SaleInventory>();

                            var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(detailList.Product_SlNo);
                            var salesinventory = aSalesBusiness.GetAllSalesInventory(detailList.Product_SlNo);
                            if (currentinventory != null)
                            {
                                currentinventory.CurrentInventory_CurrentQuantity += detailList.SaleDetails_TotalQuantity;
                                if (currentinventory.CurrentInventory_CurrentQuantity < 0)
                                {
                                    currentinventory.CurrentInventory_CurrentQuantity = 0;
                                }
                                lstupdateCurrentInventory.Add(currentinventory);
                            }
                            if (salesinventory != null)
                            {
                                salesinventory.SaleInventory_TotalQuantity -= detailList.SaleDetails_TotalQuantity;
                                if (salesinventory.SaleInventory_TotalQuantity < 0)
                                {
                                    salesinventory.SaleInventory_TotalQuantity = 0;
                                }
                                lstUpdateSalesInveontory.Add(salesinventory);
                            }
                            detailList.Status = "D";
                            detailList.UpdateBy = SplashForm.username;
                            detailList.UpdateTime = DateTime.UtcNow.AddHours(6);
                            lstUpdate.Add(detailList);

                            aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstupdateCurrentInventory);
                            aSalesBusiness.InsertorUpdateSalesInventory(lstUpdateSalesInveontory);
                            aSalesBusiness.UpdateSalesDetail(lstUpdate);

                            lstProductList.Remove(objd);
                            loadGrid();

                            //Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(aTbl_Product.Product_SlNo);
                            //if (curinv != null)
                            //{
                            //    txtAvailable.Text = curinv.CurrentInventory_CurrentQuantity.ToString();
                            //}
                        }
                    }



                }
            }
            catch
            {
            }
        }

        void NewSales()
        {
            try
            {
                txtProductName.Text = "";
                txtProductID.Text = "";
                txtcontact.Text = "";
                txtAddress.Text = "";
                txtCustomerName.Text = "";
                //txtcustomercode.Text = "";
                txtAvailable.Text = "";
                lblunit.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                txtSubTotal.Text = "0";
                txtVatPercent.Text = "0";
                txtVatAmount.Text = "0";
                txtfreight.Text = "0";
                txtDiscountAmount.Text = "0";
                txtDiscountPercent.Text = "0";
                txtProductTotal.Text = "0";
                txtRecieved.Text = "0";
                txtExchange.Text = "0";
                lbltotalamount.Text = "0";
                txtDescription.Text = "";

                btnSave.Visible = true;
                btnEditSell.Visible = false;

                localRadioButton.Checked = true;
                customerlistView.Hide();
                productListView.Hide();
                txtcustomercode.Focus();
                dgvProduct.DataSource = null;
                lstCustomerList.Clear();
                lstProductList.Clear();
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lstProductList.Any())
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List");
                    return;
                }

                if (Convert.ToDecimal(txtRecieved.Text) < Convert.ToDecimal(txtProductTotal.Text))
                {
                    MessageBox.Show("Recieved Amount Can't Be less Than Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecieved.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtDiscountAmount.Text) > Convert.ToDecimal(txtProductTotal.Text))
                {
                    MessageBox.Show("Discount Can't Be More Than Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountAmount.Focus();
                    return;
                }

                if ((MessageBox.Show("Do You Want To Save These Entries?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                {
                    return;
                }

                // get prevoius due

                decimal pre_due;
                decimal due = 0;
                decimal payment = 0;
                decimal paytoCustomer = 0;
                decimal Total_Due;

                List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDueByCustomerCode(txtcustomercode.Text).ToList();
                if (lstCustomerDueList.Any())
                {
                    due = lstCustomerDueList.Sum(x => x.SaleMaster_DueAmount);
                }

                List<Qry_CustomerPayment> lstCustomerPayment = aCashAccountBusiness.GetAllCashAccountByCustomerID(txtcustomercode.Text);
                if (lstCustomerPayment.Any())
                {
                    payment = lstCustomerPayment.Sum(x => x.In_Amount);
                    paytoCustomer = lstCustomerPayment.Sum(x => x.Out_Amount);
                }

                pre_due = (due + paytoCustomer) - payment;

                //

                List<Tbl_SalesMaster> lstMasterList = new List<Tbl_SalesMaster>();
                Tbl_SalesMaster master = new Tbl_SalesMaster();
                master.SaleMaster_InvoiceNo = aSalesBusiness.GenerateInvoiceNo();
                master.SaleMaster_CalanNo = "";
                master.SaleMaster_Description = txtDescription.Text;
                master.Employee_SlNo = aEmployee.Employee_SlNo;//if employee id

                if (txtCustomerName.ReadOnly == false && txtCustomerName.Text != "General Customer")
                {
                    master.Customer_SlNo = 0;
                }
                else
                {
                    master.Customer_SlNo = acustomer.Customer_SlNo;
                }

                master.Customer_Name = txtCustomerName.Text;
                master.Customer_Address = txtAddress.Text;
                master.Customer_Phone = "";
                master.Customer_Mobile = txtcontact.Text;
                master.Customer_Email = "";
                master.SaleMaster_SaleDate = dtpSaleDate.Value.Date;
                master.SaleMaster_SaleType = "CASH";
                master.SaleMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                master.SaleMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
                master.SaleMaster_Freight = Convert.ToDecimal(txtfreight.Text);
                master.SaleMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                master.SaleMaster_TotalSaleAmount = Convert.ToDecimal(txtProductTotal.Text);
                master.SaleMaster_PaidAmount = Convert.ToDecimal(txtProductTotal.Text);
                master.SaleMaster_DueAmount = 0;
                //master.SaleMaster_TotalDue = pre_due;
                master.SaleMaster_TotalDue = 0;

                master.SaleMaster_RecievedAmount = Convert.ToDecimal(txtRecieved.Text);
                master.SaleMaster_ExchangeAmount = Convert.ToDecimal(txtExchange.Text);

                master.Status = "A";
                master.AddBy = SplashForm.username;
                master.AddTime = DateTime.UtcNow.AddHours(6);
                master.SaleMaster_GUID = Guid.NewGuid();

                string msg = aSalesBusiness.ValidateMasterOnSave(master);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //validation for duplicate invoice no.
                if (lstQry_SalesMaster.Any())
                {
                    var result = aSalesBusiness.GetSalesMaster();

                    if (result.SaleMaster_InvoiceNo == txtInvoice.Text)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', "Invoice No. already exist. Pls check your date!");
                        return;
                    }
                }

                //validation for credit limit

                Total_Due = pre_due + 0;

                Tbl_Customer aTbl_Customer = aCustomerBusiness.GetAllCustomerByCode(txtcustomercode.Text);

                if (Total_Due > aTbl_Customer.Customer_Credit_Limit)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Credit Limit Exist");
                    return;
                }

                lstMasterList.Add(master);

                
                //delete previous sale master & detail ndata by user from report table
                
                aSalesBusiness.delete_SaleMasterDetail_1(SplashForm.username);


                //  insert master data in extra table for report show

                List<Tbl_SalesMaster_1> lstMasterList_1 = new List<Tbl_SalesMaster_1>();
                Tbl_SalesMaster_1 master_1 = new Tbl_SalesMaster_1();
                master_1.SaleMaster_InvoiceNo = aSalesBusiness.GenerateInvoiceNo();
                master_1.SaleMaster_CalanNo = "";
                master_1.SaleMaster_Description = txtDescription.Text;
                master_1.Employee_SlNo = aEmployee.Employee_SlNo;//if employee id

                if (txtCustomerName.ReadOnly == false && txtCustomerName.Text != "General Customer")
                {
                    master_1.Customer_SlNo = 0;
                }
                else
                {
                    master_1.Customer_SlNo = acustomer.Customer_SlNo;
                }

                master_1.Customer_Name = txtCustomerName.Text;
                master_1.Customer_Address = txtAddress.Text;
                master_1.Customer_Phone = "";
                master_1.Customer_Mobile = txtcontact.Text;
                master_1.Customer_Email = "";
                master_1.SaleMaster_SaleDate = dtpSaleDate.Value.Date;
                master_1.SaleMaster_SaleType = "CASH";
                master_1.SaleMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                master_1.SaleMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
                master_1.SaleMaster_Freight = Convert.ToDecimal(txtfreight.Text);
                master_1.SaleMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                master_1.SaleMaster_TotalSaleAmount = Convert.ToDecimal(txtProductTotal.Text);
                master_1.SaleMaster_PaidAmount = Convert.ToDecimal(txtProductTotal.Text);
                master_1.SaleMaster_DueAmount = 0;
                //master.SaleMaster_TotalDue = pre_due;
                master_1.SaleMaster_TotalDue = 0;

                master_1.SaleMaster_RecievedAmount = Convert.ToDecimal(txtRecieved.Text);
                master_1.SaleMaster_ExchangeAmount = Convert.ToDecimal(txtExchange.Text);

                master_1.Status = "A";
                master_1.AddBy = SplashForm.username;
                master_1.AddTime = DateTime.UtcNow.AddHours(6);
                master_1.SaleMaster_GUID = Guid.NewGuid();

                aSalesBusiness.Insert_SaleMaster_1(master_1);

                //


                // cash register entry

                List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                aTbl_CashRegister.Transaction_Date = dtpSaleDate.Value.Date;
                aTbl_CashRegister.IdentityNo = master.SaleMaster_InvoiceNo;
                aTbl_CashRegister.Narration = "Sales";
                aTbl_CashRegister.InAmount = Convert.ToDecimal(txtProductTotal.Text);
                aTbl_CashRegister.OutAmount = 0;
                aTbl_CashRegister.Description = txtDescription.Text;
                aTbl_CashRegister.Status = "A";
                aTbl_CashRegister.Saved_By = SplashForm.username;
                aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);

                //
                List<Tbl_SaleDetails> lstDetailsList = new List<Tbl_SaleDetails>();
                List<Tbl_SaleDetails_1> lstDetailsList_1 = new List<Tbl_SaleDetails_1>();
                List<Tbl_SaleInventory> lstInventoryList = new List<Tbl_SaleInventory>();
                List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();

                foreach (Qry_SalesDetails div in lstProductList)
                {
                    Tbl_Product tbl_Product = aProductBusiness.GetAllProduct(div.Product_SlNo);

                    Tbl_SaleDetails details = new Tbl_SaleDetails();
                    details.SaleMaster_SlNo = master.SaleMaster_SlNo;
                    details.Product_SlNo = div.Product_SlNo;
                    details.SaleDetails_TotalQuantity = div.SaleDetails_TotalQuantity;
                    details.Purchase_Rate = tbl_Product.Product_Purchase_Rate;
                    details.SaleDetails_Rate = div.SaleDetails_Rate;
                    details.SaleDetails_Discount = div.SaleDetails_Discount;
                    details.SaleDetails_Tax = div.SaleDetails_Tax;
                    details.SaleDetails_Freight = div.SaleDetails_Freight;
                    details.SaleDetails_TotalAmount = div.SaleDetails_TotalAmount;
                    details.Status = "A";
                    details.AddBy = SplashForm.username;
                    details.AddTime = DateTime.UtcNow.AddHours(6);

                    msg = aSalesBusiness.validateDetailsOnSave(details);
                    if (msg != string.Empty)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', msg);
                        return;
                    }
                    lstDetailsList.Add(details);

                    //
                    Tbl_SaleDetails_1 details_1 = new Tbl_SaleDetails_1();
                    details_1.SaleMaster_SlNo = master_1.SaleMaster_SlNo;
                    details_1.Product_SlNo = div.Product_SlNo;
                    details_1.SaleDetails_TotalQuantity = div.SaleDetails_TotalQuantity;
                    details_1.Purchase_Rate = tbl_Product.Product_Purchase_Rate;
                    details_1.SaleDetails_Rate = div.SaleDetails_Rate;
                    details_1.SaleDetails_Discount = div.SaleDetails_Discount;
                    details_1.SaleDetails_Tax = div.SaleDetails_Tax;
                    details_1.SaleDetails_Freight = div.SaleDetails_Freight;
                    details_1.SaleDetails_TotalAmount = div.SaleDetails_TotalAmount;
                    details_1.Status = "A";
                    details_1.AddBy = SplashForm.username;
                    details_1.AddTime = DateTime.UtcNow.AddHours(6);

                    lstDetailsList_1.Add(details_1);
                    //

                    Tbl_SaleInventory inventory = new Tbl_SaleInventory();
                    Tbl_SaleInventory existData = aSalesdetailsBusiness.GetAllSalesInventory(div.Product_SlNo);
                    if (existData != null)
                    {
                        inventory = existData;
                    }
                    inventory.Product_SlNo = div.Product_SlNo;
                    inventory.SaleInventory_TotalQuantity += div.SaleDetails_TotalQuantity;
                    inventory.SaleInventory_ReceiveQuantity += div.SaleDetails_TotalQuantity;
                    inventory.SaleInventory_ReturnQuantity += 0;
                    inventory.SaleInventory_DamageQuantity += 0;
                    inventory.AddBy = SplashForm.username;
                    inventory.AddTime = DateTime.UtcNow.AddHours(6);
                    lstInventoryList.Add(inventory);

                    //current inventory
                    Tbl_CurrentInventory aTbl_CurrentInventory = new Tbl_CurrentInventory();
                    Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                    if (curinv != null)
                    {
                        aTbl_CurrentInventory = curinv;
                    }
                    else
                    {
                        UtilityBusiness.DisplayAlertMessage('W', "No Data Found");
                        return;
                    }
                    aTbl_CurrentInventory.Product_SlNo = div.Product_SlNo;
                    aTbl_CurrentInventory.CurrentInventory_CurrentQuantity -= div.SaleDetails_TotalQuantity;

                    if (aTbl_CurrentInventory.CurrentInventory_CurrentQuantity < 0)
                    {
                        aTbl_CurrentInventory.CurrentInventory_CurrentQuantity = 0;
                    }
                    lstCurrentInventoryList.Add(aTbl_CurrentInventory);
                }

                //aSalesBusiness.InsertSalesDetail(lstDetailsList);

                //aSalesdetailsBusiness.InsertorUpdateSalesInventory(lstInventoryList);
                //aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstCurrentInventoryList);


                // save detail data in extra table for show report

                aSalesBusiness.InsertSalesDetail_1(lstDetailsList_1);

                //

                aSalesBusiness.SaveSale(lstMasterList, lstDetailsList, lstInventoryList, lstCurrentInventoryList);

                NewSales();

                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");

                lstDetailsList = new List<Tbl_SaleDetails>();
                lstDetailsList_1 = new List<Tbl_SaleDetails_1>();
                lstInventoryList = new List<Tbl_SaleInventory>();
                lstProductList = new List<Qry_SalesDetails>();


                //for direct printing

                Tbl_Company aTbl_Company = aCompanyBusiness.GetAllCompanyByInvoiceType();

                if (aTbl_Company.AutoInvoicePrint == true)
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    //List<Get_SaleInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByInvoice(txtInvoice.Text);
                    List<Get_SaleInvoice_1> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByInvoice_1(txtInvoice.Text);
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_SaleInvoice_1>(lstSalesInvoiceList);

                    // for A4 size print
                    if (aTbl_Company.Invoice_Type == 1)
                    {
                        Reports.CRSalesInvoice rpt = new Reports.CRSalesInvoice();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 900;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    // for half of A4 size print
                    else if (aTbl_Company.Invoice_Type == 2)
                    {
                        Reports.CRSalesInvoice_halfA4 rpt = new Reports.CRSalesInvoice_halfA4();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    //for a4 size invoice with customer due
                    else if (aTbl_Company.Invoice_Type == 3)
                    {
                        Reports.CRSalesInvoiceWithDue rpt = new Reports.CRSalesInvoiceWithDue();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                     //for half of a4 size invoice with customer due 
                    else if (aTbl_Company.Invoice_Type == 4)
                    {
                        Reports.CRSalesInvoice_halfA4_WithDue rpt = new Reports.CRSalesInvoice_halfA4_WithDue();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    // for half of A4 right size print
                    else if (aTbl_Company.Invoice_Type == 5)
                    {
                        Reports.CRSalesInvoice_halfA4_right rpt = new Reports.CRSalesInvoice_halfA4_right();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    //for half of a4 right size invoice with customer due 
                    else if (aTbl_Company.Invoice_Type == 6)
                    {
                        Reports.CRSalesInvoice_halfA4_WithDue_Right rpt = new Reports.CRSalesInvoice_halfA4_WithDue_Right();
                        rpt.Subreports[0].SetDataSource(lstCompanyList);
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    // for POS Printer with Exchange amount
                    else if (aTbl_Company.Invoice_Type == 7)
                    {
                        Reports.CRSaleInvoiceForPOS_Exchange rpt = new Reports.CRSaleInvoiceForPOS_Exchange();
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }

                    // for POS Printer
                    else if (aTbl_Company.Invoice_Type == 0)
                    {
                        Reports.CRSaleInvoiceForPOS rpt = new Reports.CRSaleInvoiceForPOS();
                        rpt.SetDataSource(dt);

                        ////----------Print to Printer----------------
                        PageMargins margins;
                        System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
                        margins = rpt.PrintOptions.PageMargins;
                        margins.bottomMargin = 0;
                        margins.leftMargin = 0;
                        margins.rightMargin = 0;
                        margins.topMargin = 0;
                        rpt.PrintOptions.ApplyPageMargins(margins);
                        rpt.PrintOptions.PrinterName = settings.PrinterName;
                        rpt.PrintToPrinter(settings, new PageSettings() { }, false);
                    }
                }

                else
                {
                    if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        SalesInvoiceForm ob = new SalesInvoiceForm(txtInvoice.Text);  // for normal invoice print
                        ob.Show();
                    }

                    if (Text == "Sales Product")
                    {
                        txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
                    }
                }

                if (Text == "Sales Product")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductSalesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;

                if (Text == "Sales Product")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
                }
                txtEmployeeID.Text = SplashForm.username;

                Qry_SalesMaster lstQrySalesMasterList = aSalesBusiness.GetAllQrySalesMaster(id);
                if (lstQrySalesMasterList != null)
                {
                    txtInvoice.Text = lstQrySalesMasterList.SaleMaster_InvoiceNo;
                    dtpSaleDate.Value = lstQrySalesMasterList.SaleMaster_SaleDate;
                    txtcustomercode.Text = lstQrySalesMasterList.Customer_Code;
                    txtCustomerName.Text = lstQrySalesMasterList.Customer_Name;
                    txtAddress.Text = lstQrySalesMasterList.Customer_Address;
                    txtDescription.Text = lstQrySalesMasterList.SaleMaster_Description;

                    acustomer.Customer_SlNo = Convert.ToInt32(lstQrySalesMasterList.Customer_SlNo);
                    acustomer.Customer_Name = lstQrySalesMasterList.Customer_Name;
                    acustomer.Customer_Address = lstQrySalesMasterList.Customer_Address;

                    List<Qry_SalesDetails> lstQry_SalesDetailsList = aSalesBusiness.GetAllQrySalesDetails(id);
                    lstProductList = lstQry_SalesDetailsList;
                    loadGrid();

                    txtExchange.Text = "0";
                    txtProductTotal.Text = Math.Round((lstQrySalesMasterList.SaleMaster_PaidAmount), 2).ToString();
                    txtProductTotal.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TotalSaleAmount), 2).ToString();
                    lbltotalamount.Text = txtProductTotal.Text;
                    txtDiscountAmount.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TotalDiscountAmount), 2).ToString();
                    txtfreight.Text = Math.Round((lstQrySalesMasterList.SaleMaster_Freight), 2).ToString();
                    txtVatAmount.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TaxAmount), 2).ToString();

                    customerlistView.Hide();
                    btnEditSell.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    NewSales();
                }
            }
            catch
            {
            }
        }

        void Vat_Calculation()
        {
            try
            {
                decimal vatparcent = Convert.ToDecimal(txtVatPercent.Text);
                decimal total = Convert.ToDecimal(txtSubTotal.Text);

                txtVatAmount.Text = ((total * vatparcent) / 100).ToString();
            }
            catch
            {
            }
        }

        void discount_Calculation()
        {
            try
            {
                decimal discount = Convert.ToDecimal(txtDiscountPercent.Text);
                decimal subtotal = Convert.ToDecimal(txtSubTotal.Text);

                txtDiscountAmount.Text = ((subtotal * discount) / 100).ToString();
                //txtDiscountAmount.Focus();
            }
            catch
            {
            }
        }

        void calculatetotal()
        {
            try
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                decimal rate = Convert.ToDecimal(txtRate.Text);
                decimal amount = (decimal)qty * rate;
                txtAmount.Text = amount.ToString();

                decimal subtotal = Convert.ToDecimal(txtSubTotal.Text);
                decimal vatamount = Convert.ToDecimal(txtVatAmount.Text);
                decimal frieght = Convert.ToDecimal(txtfreight.Text);
                decimal discountamount = Convert.ToDecimal(txtDiscountAmount.Text);
                decimal total = (subtotal + vatamount + frieght) - discountamount;
                txtProductTotal.Text = total.ToString();
                lbltotalamount.Text = txtProductTotal.Text;
            }
            catch
            {
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTaxPercent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                UtilityBusiness.DisplayAlertMessage('W', "Enter Number");
            }
            base.OnKeyPress(e);
        }

        //decimal individualItem_taxAmount;

        private void btnAddtocart_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text == string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Enter Product");
                    txtProductID.Focus();
                    return;
                }
                if (Convert.ToDouble(txtQuantity.Text) == 0)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Enter Quantity");
                    txtQuantity.Focus();
                    return;
                }
                if (Convert.ToDecimal(txtRate.Text) == 0)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Enter Rate");
                    txtRate.Focus();
                    return;
                }

                var checkproduct = aProductBusiness.GetAllQryProductByCode(txtProductID.Text);
                if (!checkproduct.Any())
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Product not found");
                    return;
                }
                if (lstProductList.Any(x => x.Product_SlNo == aTbl_Product.Product_SlNo))
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Data Already Exist");
                    return;
                }

                Qry_SalesDetails details = new Qry_SalesDetails();
                details.Product_SlNo = aTbl_Product.Product_SlNo;
                details.Product_Name = aTbl_Product.Product_Name;

                //Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(aTbl_Product.Product_SlNo);
                GetItemCurrentStock lstGetItemCurrentStock = aCurrentInventoryBusiness.GetInventoryByProductId2(aTbl_Product.Product_SlNo);
                //var row = lstGetItemCurrentStock.First();
                if (lstGetItemCurrentStock.CurrentInventory_CurrentQuantity >= Convert.ToDouble(txtQuantity.Text))
                {
                    details.SaleDetails_TotalQuantity = Convert.ToDouble(txtQuantity.Text);
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Insufficient Product");
                    return;
                }

                //add individual item vat
                decimal individualItem_taxAmount = ((((Convert.ToDecimal(txtRate.Text) * Convert.ToDecimal(lblVatParcent.Text)) / 100)) * Convert.ToDecimal(txtQuantity.Text));

                txtVatAmount.Text = (Convert.ToDecimal(txtVatAmount.Text) + individualItem_taxAmount).ToString();

                details.SaleDetails_Rate = Convert.ToDecimal(txtRate.Text);
                details.SaleDetails_Discount = Convert.ToDecimal(txtDiscountAmount.Text);
                details.SaleDetails_Tax = individualItem_taxAmount;
                details.SaleDetails_Freight = Convert.ToDecimal(txtfreight.Text);
                details.SaleDetails_TotalAmount = Convert.ToDecimal(txtAmount.Text);
                details.Unit_Name = aTbl_Product.Unit_Name;
                lstProductList.Add(details);
                loadGrid();
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                lblVatParcent.Text = "0";
                //btnSave.Focus();
                txtProductID.Focus();
            }
            catch
            {
                UtilityBusiness.DisplayAlertMessage('W', "Stock is Empty");
                return;
            }
        }

        private void customerlistView_Click(object sender, EventArgs e)
        {
            try
            {
                acustomer = (Qry_Customer)customerlistView.SelectedItems[0].Tag;

                txtcustomercode.Text = acustomer.Customer_Code;
                txtCustomerName.Text = acustomer.Customer_Name;
                txtAddress.Text = acustomer.Customer_Address;
                txtcontact.Text = acustomer.Customer_Mobile;
                customerlistView.Visible = false;
                txtcustomercode.BackColor = Color.MintCream;
                txtProductID.Focus();
                txtProductID.BackColor = Color.LightCyan;
            }
            catch
            {
            }
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
            //txtcustomercode.Text = "Enter Customer ID/Name";
            //txtcustomercode.ForeColor = Color.Gray;
            if (txtcustomercode.Text != string.Empty)
            {
                GetCustomer();
            }
            if (txtcustomercode.Text == "C0001")
            {
                txtCustomerName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtcontact.ReadOnly = false;
            }
            else
            {
                txtCustomerName.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtcontact.ReadOnly = true;
            }
        }

        private void txtcustomercode_Click(object sender, EventArgs e)
        {
            GetCustomer();
            if (txtcustomercode.Text == "Enter Customer ID/Name")
            {
                txtcustomercode.Text = "";
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                productListView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                productListView.Focus();
            }
            else
            {
                GetProduct();
            }
        }

        private void txtcustomercode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                customerlistView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                customerlistView.Focus();
            }
            else
            {
                GetCustomer();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SalesInvoiceReportForm ob = new SalesInvoiceReportForm("");
            ob.Show();
        }

        private void txtVatPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtVatPercent.Text) > 100)
                {
                    MessageBox.Show("VAT Can't Be More Than 100%", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVatPercent.Focus();
                    return;
                }
                Vat_Calculation();
            }
            catch
            {
            }
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtDiscountPercent.Text) > 100)
                {
                    MessageBox.Show("Discount Can't Be More Than 100%", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountPercent.Focus();
                    return;
                }
                discount_Calculation();
            }
            catch
            {
            }
        }

        private void txtfreight_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtProductTotal_TextChanged(object sender, EventArgs e)
        {
            txtRecieved.Text = txtProductTotal.Text;
        }

        private void txtVatAmount_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calculatetotal();
            }
            catch
            {
            }
        }

        void Calculate_Payment()
        {
            try
            {
                decimal payment = Convert.ToDecimal(txtRecieved.Text);
                decimal total = Convert.ToDecimal(txtProductTotal.Text);

                txtExchange.Text = (payment - total).ToString();
            }
            catch
            {
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Calculate_Payment();
                txtExchange.ForeColor = Color.Blue;
            }
            catch
            {
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm ob = new CustomerForm();
            ob.Show();
        }

        private void localRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (localRadioButton.Checked)
                {
                    GetCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void foreignRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (foreignRadioButton.Checked)
                {
                    GetCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (Text == "Sales Product")
            {
                NewSales();
                txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
            }
            else
            {
                MessageBox.Show("Access Denied!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtfreight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void customerlistView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    acustomer = (Qry_Customer)customerlistView.SelectedItems[0].Tag;

                    txtcustomercode.Text = acustomer.Customer_Code;
                    txtCustomerName.Text = acustomer.Customer_Name;
                    txtAddress.Text = acustomer.Customer_Address;
                    txtcontact.Text = acustomer.Customer_Mobile;
                    customerlistView.Visible = false;
                    txtcustomercode.BackColor = Color.MintCream;
                    txtProductID.Focus();
                    txtProductID.BackColor = Color.LightCyan;
                }
            }
            catch
            {

            }
        }

        private void ProductSalesForm_Click(object sender, EventArgs e)
        {
            customerlistView.Hide();
            productListView.Hide();
        }

        private void productListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                    txtProductID.Text = aTbl_Product.Product_Code;
                    txtProductName.Text = aTbl_Product.Product_Name;
                    txtRate.Text = Math.Round(aTbl_Product.Product_SellingPrice, 2).ToString();
                    lblunit.Text = aTbl_Product.Unit_Name;
                    lblVatParcent.Text = aTbl_Product.Product_VatPercent.ToString();

                    GetItemCurrentStock lstGetItemCurrentStock = aCurrentInventoryBusiness.GetInventoryByProductId2(aTbl_Product.Product_SlNo);

                    if (lstGetItemCurrentStock != null)
                    {
                        productListView.Visible = false;
                        txtAvailable.Text = lstGetItemCurrentStock.CurrentInventory_CurrentQuantity.ToString();
                    }

                    else
                    {
                        productListView.Visible = false;
                        txtAvailable.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Purchase Record Found Of This Product!");
                    }

                    //productListView.Visible = false;
                    txtProductID.BackColor = Color.MintCream;
                    txtQuantity.Focus();
                    txtQuantity.BackColor = Color.LightCyan;
                }
            }
            catch
            {
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm ob = new CustomerForm();
            ob.ShowDialog();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtRate.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtProductID.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddtocart.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtQuantity.Focus();
            }
        }

        private void txtPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDiscountAmount.Focus();
            }
        }

        private void txtDiscountAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRecieved.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtRecieved.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDiscountPercent.Focus();
            }
        }

        private void txtfreight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscountPercent.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtDiscountPercent.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtVatAmount.Focus();
            }
        }

        private void txtVatPercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtfreight.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtfreight.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtProductID.Focus();
            }
        }

        private void txtcustomercode_Leave(object sender, EventArgs e)
        {
            txtcustomercode.BackColor = Color.MintCream;
            if (txtcustomercode.Text == "" && customerlistView.Visible == false)
            {
                txtcustomercode.Text = "Enter Customer ID/Name";
                if (txtcustomercode.Text == "Enter Customer ID/Name")
                {
                    txtcustomercode.ForeColor = Color.Gray;
                }
            }
        }

        private void txtProductID_Leave(object sender, EventArgs e)
        {
            txtProductID.BackColor = Color.MintCream;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            txtQuantity.BackColor = Color.MintCream;
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            txtRate.BackColor = Color.MintCream;
        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            txtRate.BackColor = Color.LightCyan;
        }

        private void txtcustomercode_Enter(object sender, EventArgs e)
        {
            txtcustomercode.BackColor = Color.LightCyan;
        }

        private void txtProductID_Enter(object sender, EventArgs e)
        {
            txtProductID.BackColor = Color.LightCyan;
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            txtQuantity.BackColor = Color.LightCyan;
        }

        private void txtVatPercent_Enter(object sender, EventArgs e)
        {
            txtVatPercent.BackColor = Color.LightCyan;
        }

        private void txtVatPercent_Leave(object sender, EventArgs e)
        {
            txtVatPercent.BackColor = Color.MintCream;
        }

        private void txtfreight_Enter(object sender, EventArgs e)
        {
            txtfreight.BackColor = Color.LightCyan;
        }

        private void txtfreight_Leave(object sender, EventArgs e)
        {
            txtfreight.BackColor = Color.MintCream;
        }

        private void txtDiscountPercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscountAmount.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtDiscountAmount.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtfreight.Focus();
            }
        }

        private void txtDiscountPercent_Enter(object sender, EventArgs e)
        {
            txtDiscountPercent.BackColor = Color.LightCyan;
        }

        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            txtDiscountPercent.BackColor = Color.MintCream;
        }

        private void txtDiscountAmount_Enter(object sender, EventArgs e)
        {
            txtDiscountAmount.BackColor = Color.LightCyan;
        }

        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {
            txtDiscountAmount.BackColor = Color.MintCream;
        }

        private void txtPaid_Enter(object sender, EventArgs e)
        {
            txtRecieved.BackColor = Color.LightCyan;
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            txtRecieved.BackColor = Color.MintCream;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            //if (txtCustomerName.Text == "General Customer")
            //{
            //    txtRecieved.Enabled = false;
            //}
            //else
            //{
            //    txtRecieved.Enabled = true;
            //}
        }

        private void btnEditSell_Click(object sender, EventArgs e)
        {
            if (!lstProductList.Any())
            {
                UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List");
                return;
            }
            if ((MessageBox.Show("Do You Want To Update These Entries?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
            {
                return;
            }

            Tbl_SalesMaster aTbl_SalesMaster = aSalesBusiness.GetAllSalesMaster(id);
            Tbl_CashRegister aTbl_CashRegister = aCashAccountBusiness.GetAllCashRegister(txtInvoice.Text);

            try
            {
                aTbl_SalesMaster.Customer_SlNo = acustomer.Customer_SlNo;
                aTbl_SalesMaster.Employee_SlNo = aEmployee.Employee_SlNo;
                aTbl_SalesMaster.SaleMaster_SaleDate = dtpSaleDate.Value.Date;
                aTbl_SalesMaster.SaleMaster_Description = txtDescription.Text;
                aTbl_SalesMaster.SaleMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                aTbl_SalesMaster.SaleMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
                aTbl_SalesMaster.SaleMaster_Freight = Convert.ToDecimal(txtfreight.Text);
                aTbl_SalesMaster.SaleMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                aTbl_SalesMaster.SaleMaster_TotalSaleAmount = Convert.ToDecimal(txtProductTotal.Text);
                aTbl_SalesMaster.SaleMaster_PaidAmount = Convert.ToDecimal(txtProductTotal.Text);
                aTbl_SalesMaster.SaleMaster_DueAmount = 0;
                aTbl_SalesMaster.Status = "A";
                aTbl_SalesMaster.UpdateBy = SplashForm.username;
                aTbl_SalesMaster.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aSalesBusiness.ValidateMasterOnSave(aTbl_SalesMaster);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //edit from cash register table
                aTbl_CashRegister.Transaction_Date = dtpSaleDate.Value.Date;
                aTbl_CashRegister.InAmount = Convert.ToDecimal(txtProductTotal.Text);
                aTbl_CashRegister.Status = "A";
                aTbl_CashRegister.Description = txtDescription.Text;
                aTbl_CashRegister.Edited_By = SplashForm.username;
                aTbl_CashRegister.Edited_Time = DateTime.UtcNow.AddHours(6);
                //

                List<Tbl_SaleDetails> lstUpdate = new List<Tbl_SaleDetails>();
                List<Tbl_SaleDetails> lstInsert = new List<Tbl_SaleDetails>();
                List<Tbl_CurrentInventory> lstupdateCurrentInventory = new List<Tbl_CurrentInventory>();
                List<Tbl_SaleInventory> lstUpdateTbl_SaleInventory = new List<Tbl_SaleInventory>();

                foreach (Qry_SalesDetails div in lstProductList)
                {
                    Tbl_SaleDetails details = aSalesBusiness.GetAllTbl_SaleDetailsByid(div.SaleDetails_SlNo);
                    if (details != null)
                    {
                        details.Product_SlNo = div.Product_SlNo;
                        details.SaleDetails_TotalQuantity = div.SaleDetails_TotalQuantity;
                        details.SaleDetails_Rate = div.SaleDetails_Rate;
                        details.SaleDetails_Discount = div.SaleDetails_Discount;
                        details.SaleDetails_Tax = div.SaleDetails_Tax;
                        details.SaleDetails_Freight = div.SaleDetails_Freight;
                        details.SaleDetails_TotalAmount = div.SaleDetails_TotalAmount;
                        details.Status = "A";
                        details.UpdateBy = SplashForm.username;
                        details.UpdateTime = DateTime.UtcNow.AddHours(6);
                        msg = aSalesBusiness.validateDetailsOnSave(details);
                        if (msg != string.Empty)
                        {
                            UtilityBusiness.DisplayAlertMessage('W', msg);
                            return;
                        }
                        lstUpdate.Add(details);
                    }
                    else
                    {
                        details = new Tbl_SaleDetails();
                        details.Product_SlNo = div.Product_SlNo;
                        details.SaleMaster_SlNo = id;
                        details.SaleDetails_TotalQuantity = div.SaleDetails_TotalQuantity;
                        details.SaleDetails_Rate = div.SaleDetails_Rate;
                        details.SaleDetails_Discount = div.SaleDetails_Discount;
                        details.SaleDetails_Tax = div.SaleDetails_Tax;
                        details.SaleDetails_Freight = div.SaleDetails_Freight;
                        details.SaleDetails_TotalAmount = div.SaleDetails_TotalAmount;
                        details.Status = "A";
                        details.UpdateBy = SplashForm.username;
                        details.UpdateTime = DateTime.UtcNow.AddHours(6);
                        msg = aSalesBusiness.validateDetailsOnSave(details);
                        if (msg != string.Empty)
                        {
                            UtilityBusiness.DisplayAlertMessage('W', msg);
                            return;
                        }
                        lstInsert.Add(details);

                        Tbl_SaleInventory objsInventory = new Tbl_SaleInventory();
                        var Salesinventory = aSalesBusiness.GetAllSalesInventory(div.Product_SlNo);
                        if (Salesinventory != null)
                        {
                            objsInventory = Salesinventory;
                        }
                        objsInventory.Product_SlNo = div.Product_SlNo;
                        objsInventory.SaleInventory_TotalQuantity += div.SaleDetails_TotalQuantity;
                        objsInventory.SaleInventory_ReturnQuantity += 0;
                        objsInventory.SaleInventory_DamageQuantity += 0;
                        objsInventory.UpdateBy = SplashForm.username;
                        objsInventory.UpdateTime = DateTime.UtcNow.AddHours(6);

                        if (objsInventory.SaleInventory_TotalQuantity < 0)
                        {
                            objsInventory.SaleInventory_TotalQuantity = 0;
                        }
                        lstUpdateTbl_SaleInventory.Add(objsInventory);

                        Tbl_CurrentInventory objcurinventory = new Tbl_CurrentInventory();

                        var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                        if (currentinventory != null)
                        {
                            objcurinventory = currentinventory;
                        }
                        objcurinventory.Product_SlNo = div.Product_SlNo;
                        objcurinventory.CurrentInventory_CurrentQuantity -= div.SaleDetails_TotalQuantity;

                        if (objcurinventory.CurrentInventory_CurrentQuantity < 0)
                        {
                            objcurinventory.CurrentInventory_CurrentQuantity = 0;
                        }
                        lstupdateCurrentInventory.Add(objcurinventory);
                    }
                }
                aSalesBusiness.UpdateSalesDetail(lstUpdate);
                aSalesBusiness.InsertSalesDetail(lstInsert);
                aSalesBusiness.InsertorUpdateSalesInventory(lstUpdateTbl_SaleInventory);
                aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstupdateCurrentInventory);
                aSalesBusiness.UpdateSalesMaster(aTbl_SalesMaster);
                aCashAccountBusiness.UpdateCashRegister(aTbl_CashRegister);

                UtilityBusiness.DisplayAlertMessage('S', "Updated Successfully");
                lstUpdate = new List<Tbl_SaleDetails>();
                lstUpdateTbl_SaleInventory = new List<Tbl_SaleInventory>();

                //lstProductList = new List<Qry_SalesDetails>();

                if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SalesInvoiceReportForm ob = new SalesInvoiceReportForm(txtInvoice.Text);
                    ob.Show();
                    if (Text == "Sales Product")
                    {
                        txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
                    }
                }
                if (Text == "Sales Product")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_SalesMaster = null;
            }
        }

        private void ProductSalesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Text == "Edit Sales Product")
            {
                if (dgvProduct.Rows.Count == 0)
                {
                    MessageBox.Show("Product list is empty !", "Data Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

    }
}
