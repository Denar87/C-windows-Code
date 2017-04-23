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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace IMS_Win
{
    public partial class ProductQuotationForm : Form
    {
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        Tbl_Employee aEmployee = new Tbl_Employee();
        Qry_Customer acustomer = new Qry_Customer();
        List<Qry_QuotationDetails> lstProductList = new List<Qry_QuotationDetails>();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        SalesBusiness aSalesdetailsBusiness = new SalesBusiness();
        List<Qry_Customer> lstCustomerList = new List<Qry_Customer>();
        Tbl_QuotationMaster aTbl_QuotationMaster = new Tbl_QuotationMaster();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();

        List<Qry_SalesMaster> lstQry_SalesMaster = new List<Qry_SalesMaster>();

        public ProductQuotationForm()
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
                txtSubTotal.Text = Math.Round(lstProductList.Sum(x => x.QuotationDetails_TotalAmount), 2).ToString();
                txtProductTotal.Text = txtSubTotal.Text;
                txtPaid.Text = txtSubTotal.Text;
                lbltotalamount.Text = txtProductTotal.Text;

                txtProductID.Text = "";
                txtProductName.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                //txtAvailable.Text = "0";
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

                //Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(aTbl_Product.Product_SlNo);
                //GetItemCurrentStock lstGetItemCurrentStock = aCurrentInventoryBusiness.GetInventoryByProductId2(aTbl_Product.Product_SlNo);
                //var row = lstGetItemCurrentStock.First();

                //if (row != null)
                //{
                //    txtAvailable.Text = row.CurrentInventory_CurrentQuantity.ToString();
                //}
                productListView.Visible = false;
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
                        txtVatAmount.Text = Math.Round(lstProductList.Sum(x => x.QuotationDetails_Tax), 2).ToString();
                    }
                    else
                    {
                        if (lstProductList[e.RowIndex].QuotationDetails_SlNo == 0)
                        {
                            lstProductList.RemoveAt(e.RowIndex);
                            loadGrid();
                        }
                        else
                        {
                            var objd = lstProductList[e.RowIndex];
                            var detailList = aSalesBusiness.GetAllTbl_SaleDetailsByid(objd.QuotationDetails_SlNo);
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
                //txtAvailable.Text = "";
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
                txtPaid.Text = "0";
                txtDue.Text = "0";
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

                //List<Tbl_QuotationMaster> lstMasterList = new List<Tbl_QuotationMaster>();

                Tbl_QuotationMaster master = new Tbl_QuotationMaster();
                master.QuotationMaster_InvoiceNo = aSalesBusiness.GenerateQuotationNo();
                master.QuotationMaster_CallanNo = "n/a";
                master.QuotationMaster_Description = txtDescription.Text;
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
                master.QuotationMaster_Date = dtpSaleDate.Value.Date;
                master.QuotationMaster_Type = "CASH";
                master.QuotationMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                master.QuotationMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
                master.QuotationMaster_Freight = Convert.ToDecimal(txtfreight.Text);
                master.QuotationMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                master.QuotationMaster_TotalAmount = Convert.ToDecimal(txtProductTotal.Text);
                master.QuotationMaster_PaidAmount = Convert.ToDecimal(txtPaid.Text);
                master.QuotationMaster_DueAmount = Convert.ToDecimal(txtDue.Text);
                master.QuotationMaster_TotalDue = pre_due;
                master.Status = "A";
                master.AddBy = SplashForm.username;
                master.AddTime = DateTime.UtcNow.AddHours(6);
                master.QuotationMaster_GUID = Guid.NewGuid();

                string msg = aSalesBusiness.ValidateMasterOnSave(master);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //validation for duplicate invoice no.
                //if (lstQry_SalesMaster.Any())
                //{
                //    var result = aSalesBusiness.GetSalesMaster();

                //    if (result.SaleMaster_InvoiceNo == txtInvoice.Text)
                //    {
                //        UtilityBusiness.DisplayAlertMessage('W', "Invoice No. already exist. Pls check your date!");
                //        return;
                //    }
                //}

                //validation for credit limit

                Total_Due = pre_due + Convert.ToDecimal(txtDue.Text);

                Tbl_Customer aTbl_Customer = aCustomerBusiness.GetAllCustomerByCode(txtcustomercode.Text);

                if (Total_Due > aTbl_Customer.Customer_Credit_Limit)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Credit Limit Exist");
                    return;
                }

                //lstMasterList.Add(master);
                aSalesBusiness.InsertQuotationMaster(master);
                
                // cash register entry

                //List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                //Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                //aTbl_CashRegister.Transaction_Date = dtpSaleDate.Value.Date;
                //aTbl_CashRegister.IdentityNo = master.SaleMaster_InvoiceNo;
                //aTbl_CashRegister.Narration = "Sales";
                //aTbl_CashRegister.InAmount = Convert.ToDecimal(txtPaid.Text);
                //aTbl_CashRegister.OutAmount = 0;
                //aTbl_CashRegister.Description = txtDescription.Text;
                //aTbl_CashRegister.Status = "A";
                //aTbl_CashRegister.Saved_By = SplashForm.username;
                //aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                //aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);

                //
                
                
                List<Tbl_QuotationDetails> lstDetailsList = new List<Tbl_QuotationDetails>();

                foreach (Qry_QuotationDetails div in lstProductList)
                {
                    Tbl_Product tbl_Product = aProductBusiness.GetAllProduct(div.Product_SlNo);

                    Tbl_QuotationDetails details = new Tbl_QuotationDetails();
                    details.QuotationMaster_SlNo = master.QuotationMaster_SlNo;
                    details.Product_SlNo = div.Product_SlNo;
                    details.QuotationDetails_TotalQuantity = div.QuotationDetails_TotalQuantity;
                    details.Purchase_Rate = tbl_Product.Product_Purchase_Rate;
                    details.QuotationDetails_Rate = div.QuotationDetails_Rate;
                    details.QuotationDetails_Discount = div.QuotationDetails_Discount;
                    details.QuotationDetails_Tax = div.QuotationDetails_Tax;
                    details.QuotationDetails_Freight = div.QuotationDetails_Freight;
                    details.QuotationDetails_TotalAmount = div.QuotationDetails_TotalAmount;
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
                }

                aSalesBusiness.InsertQuotationDetail(lstDetailsList);

                //aSalesBusiness.SaveSale(lstMasterList, lstDetailsList);

                NewSales();


                //txtProductTotal.Text = "0";
                //txtPaid.Text = "0";
                //txtDue.Text = "0";
                //lbltotalamount.Text = "0";

                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");

                lstDetailsList = new List<Tbl_QuotationDetails>();

                if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    QuotationPrintForm ob = new QuotationPrintForm(txtInvoice.Text);  // for normal invoice print
                    ob.Show();

                    if (Text == "Quotation")
                    {
                        txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
                    }
                }
                if (Text == "Quotation")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                Qry_QuotationDetails details = new Qry_QuotationDetails();
                details.Product_SlNo = aTbl_Product.Product_SlNo;
                details.Product_Name = aTbl_Product.Product_Name;

                //check item stock

                //List<GetItemCurrentStock> lstGetItemCurrentStock = aCurrentInventoryBusiness.GetInventoryByProductId2(aTbl_Product.Product_SlNo);
                //var row = lstGetItemCurrentStock.First();
                //if (row.CurrentInventory_CurrentQuantity >= Convert.ToDouble(txtQuantity.Text))
                //{
                //    details.QuotationDetails_TotalQuantity = Convert.ToDouble(txtQuantity.Text);
                //}
                //else
                //{
                //    UtilityBusiness.DisplayAlertMessage('W', "Insufficient Product");
                //    return;
                //}

                //add individual item vat

                details.QuotationDetails_TotalQuantity = Convert.ToDouble(txtQuantity.Text);

                decimal individualItem_taxAmount = ((((Convert.ToDecimal(txtRate.Text) * Convert.ToDecimal(lblVatParcent.Text)) / 100)) * Convert.ToDecimal(txtQuantity.Text));

                txtVatAmount.Text = (Convert.ToDecimal(txtVatAmount.Text) + individualItem_taxAmount).ToString();

                details.QuotationDetails_Rate = Convert.ToDecimal(txtRate.Text);
                details.QuotationDetails_Discount = Convert.ToDecimal(txtDiscountAmount.Text);
                details.QuotationDetails_Tax = individualItem_taxAmount;
                details.QuotationDetails_Freight = Convert.ToDecimal(txtfreight.Text);
                details.QuotationDetails_TotalAmount = Convert.ToDecimal(txtAmount.Text);
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
                //UtilityBusiness.DisplayAlertMessage('W', "Stock is Empty");
                //return;
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
            QuotationPrintForm ob = new QuotationPrintForm("");
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
            txtPaid.Text = txtProductTotal.Text;
        }

        private void txtVatAmount_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtDiscountAmount.Text) > Convert.ToDecimal(txtProductTotal.Text))
                {
                    MessageBox.Show("Discount Can't Be More Than Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountAmount.Focus();
                    return;
                }
                else
                {
                    calculatetotal();
                }
            }
            catch
            {
            }
        }

        void Calculate_Payment()
        {
            try
            {
                decimal payment = Convert.ToDecimal(txtPaid.Text);
                decimal total = Convert.ToDecimal(txtProductTotal.Text);

                txtDue.Text = (total - payment).ToString();
            }
            catch
            {
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtPaid.Text) > Convert.ToDecimal(txtProductTotal.Text))
                {
                    MessageBox.Show("Paid Amount Can't Be More Than Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaid.Focus();
                    return;
                }
                Calculate_Payment();
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
            if (Text == "Quotation")
            {
                NewSales();
                txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
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

                    //Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(aTbl_Product.Product_SlNo);
                    //if (curinv != null)
                    //{
                    //    txtAvailable.Text = curinv.CurrentInventory_CurrentQuantity.ToString();
                    //}
                    productListView.Visible = false;
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
                txtPaid.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtPaid.Focus();
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
            txtPaid.BackColor = Color.LightCyan;
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            txtPaid.BackColor = Color.MintCream;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "General Customer")
            {
                txtPaid.Enabled = false;
            }
            else
            {
                txtPaid.Enabled = true;
            }
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

            Tbl_QuotationMaster aTbl_QuotationMaster = aSalesBusiness.GetAllQuotationMaster(id);
            //Tbl_CashRegister aTbl_CashRegister = aCashAccountBusiness.GetAllCashRegister(txtInvoice.Text);

            try
            {
                aTbl_QuotationMaster.Customer_SlNo = acustomer.Customer_SlNo;
                aTbl_QuotationMaster.Employee_SlNo = aEmployee.Employee_SlNo;
                aTbl_QuotationMaster.QuotationMaster_Date = dtpSaleDate.Value.Date;
                aTbl_QuotationMaster.QuotationMaster_Description = txtDescription.Text;
                aTbl_QuotationMaster.QuotationMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                aTbl_QuotationMaster.QuotationMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
                aTbl_QuotationMaster.QuotationMaster_Freight = Convert.ToDecimal(txtfreight.Text);
                aTbl_QuotationMaster.QuotationMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                aTbl_QuotationMaster.QuotationMaster_TotalAmount = Convert.ToDecimal(txtProductTotal.Text);
                aTbl_QuotationMaster.QuotationMaster_PaidAmount = Convert.ToDecimal(txtPaid.Text);
                aTbl_QuotationMaster.QuotationMaster_DueAmount = Convert.ToDecimal(txtDue.Text);
                aTbl_QuotationMaster.Status = "A";
                aTbl_QuotationMaster.UpdateBy = SplashForm.username;
                aTbl_QuotationMaster.UpdateTime = DateTime.UtcNow.AddHours(6);

                string msg = aSalesBusiness.ValidateMasterOnSave(aTbl_QuotationMaster);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //edit from cash register table

                //aTbl_CashRegister.Transaction_Date = dtpSaleDate.Value.Date;
                //aTbl_CashRegister.InAmount = Convert.ToDecimal(txtPaid.Text);
                //aTbl_CashRegister.Status = "A";
                //aTbl_CashRegister.Description = txtDescription.Text;
                //aTbl_CashRegister.Edited_By = SplashForm.username;
                //aTbl_CashRegister.Edited_Time = DateTime.UtcNow.AddHours(6);
                //

                List<Tbl_QuotationDetails> lstUpdate = new List<Tbl_QuotationDetails>();
                List<Tbl_QuotationDetails> lstInsert = new List<Tbl_QuotationDetails>();

                foreach (Qry_QuotationDetails div in lstProductList)
                {
                    Tbl_QuotationDetails details = aSalesBusiness.GetAllTbl_QuotationDetailsByid(div.QuotationDetails_SlNo);
                    if (details != null)
                    {
                        details.Product_SlNo = div.Product_SlNo;
                        details.QuotationDetails_TotalQuantity = div.QuotationDetails_TotalQuantity;
                        details.QuotationDetails_Rate = div.QuotationDetails_Rate;
                        details.QuotationDetails_Discount = div.QuotationDetails_Discount;
                        details.QuotationDetails_Tax = div.QuotationDetails_Tax;
                        details.QuotationDetails_Freight = div.QuotationDetails_Freight;
                        details.QuotationDetails_TotalAmount = div.QuotationDetails_TotalAmount;
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
                        details = new Tbl_QuotationDetails();
                        details.Product_SlNo = div.Product_SlNo;
                        details.QuotationMaster_SlNo = id;
                        details.QuotationDetails_TotalQuantity = div.QuotationDetails_TotalQuantity;
                        details.QuotationDetails_Rate = div.QuotationDetails_Rate;
                        details.QuotationDetails_Discount = div.QuotationDetails_Discount;
                        details.QuotationDetails_Tax = div.QuotationDetails_Tax;
                        details.QuotationDetails_Freight = div.QuotationDetails_Freight;
                        details.QuotationDetails_TotalAmount = div.QuotationDetails_TotalAmount;
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
                    }
                }
                aSalesBusiness.UpdateQuotationDetail(lstUpdate);
                aSalesBusiness.InsertQuotationDetail(lstInsert);

                aSalesBusiness.UpdateQuotationMaster(aTbl_QuotationMaster);
                //aCashAccountBusiness.UpdateCashRegister(aTbl_CashRegister);

                UtilityBusiness.DisplayAlertMessage('S', "Updated Successfully");
                lstUpdate = new List<Tbl_QuotationDetails>();

                if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    QuotationPrintForm ob = new QuotationPrintForm(txtInvoice.Text);
                    ob.Show();
                    if (Text == "Quotation")
                    {
                        txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
                    }
                }
                if (Text == "Quotation")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_QuotationMaster = null;
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

        private void ProductQuotationForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;

                if (Text == "Quotation")
                {
                    txtInvoice.Text = aSalesBusiness.GenerateQuotationNo();
                }
                txtEmployeeID.Text = SplashForm.username;

                //Qry_SalesMaster lstQrySalesMasterList = aSalesBusiness.GetAllQrySalesMaster(id);
                //if (lstQrySalesMasterList != null)
                //{
                //    txtInvoice.Text = lstQrySalesMasterList.SaleMaster_InvoiceNo;
                //    dtpSaleDate.Value = lstQrySalesMasterList.SaleMaster_SaleDate;
                //    txtcustomercode.Text = lstQrySalesMasterList.Customer_Code;
                //    txtCustomerName.Text = lstQrySalesMasterList.Customer_Name;
                //    txtAddress.Text = lstQrySalesMasterList.Customer_Address;
                //    txtDescription.Text = lstQrySalesMasterList.SaleMaster_Description;

                //    acustomer.Customer_SlNo = Convert.ToInt32(lstQrySalesMasterList.Customer_SlNo);
                //    acustomer.Customer_Name = lstQrySalesMasterList.Customer_Name;
                //    acustomer.Customer_Address = lstQrySalesMasterList.Customer_Address;

                //    List<Qry_QuotationDetails> lstQry_SalesDetailsList = aSalesBusiness.GetAllQryQuotationDetails(id);
                //    lstProductList = lstQry_SalesDetailsList;
                //    loadGrid();

                //    txtDue.Text = Math.Round(lstQrySalesMasterList.SaleMaster_DueAmount, 2).ToString();
                //    txtPaid.Text = Math.Round((lstQrySalesMasterList.SaleMaster_PaidAmount), 2).ToString();
                //    txtProductTotal.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TotalSaleAmount), 2).ToString();
                //    lbltotalamount.Text = txtProductTotal.Text;
                //    txtDiscountAmount.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TotalDiscountAmount), 2).ToString();
                //    txtfreight.Text = Math.Round((lstQrySalesMasterList.SaleMaster_Freight), 2).ToString();
                //    txtVatAmount.Text = Math.Round((lstQrySalesMasterList.SaleMaster_TaxAmount), 2).ToString();

                //    customerlistView.Hide();
                //    btnEditSell.Visible = true;
                //    btnSave.Visible = false;
                //}
                //else
                //{
                    NewSales();
                //}
            }
            catch
            {
            }
        }




    }
}
