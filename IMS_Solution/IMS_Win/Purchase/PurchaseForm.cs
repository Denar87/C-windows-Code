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
    public partial class PurchaseForm : Form
    {
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        PurchaseBusiness aPurchaseBusincess = new PurchaseBusiness();
        PurchaseBusiness aPurchaseInventoryBusincess = new PurchaseBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        Qry_Supplier aSupplier = new Qry_Supplier();
        Tbl_Employee aEmployee = new Tbl_Employee();
        List<Qry_PurchaseDetails> lstGridList = new List<Qry_PurchaseDetails>();
        List<Qry_Supplier> lstSupplierList = new List<Qry_Supplier>();
        Tbl_PurchaseMaster aTbl_PurchaseMaster = new Tbl_PurchaseMaster();
        List<Qry_PurchaseMaster> lstQry_PurchaseMaster = new List<Qry_PurchaseMaster>();

        public PurchaseForm()
        {
            InitializeComponent();
        }


        public int id = 0;

        void Vat_Calculation()
        {
            try
            {
                decimal vat = Convert.ToDecimal(txtTax.Text);
                decimal subtotal = Convert.ToDecimal(txtsubTotal.Text);

                txtTaxAmount.Text = ((subtotal * vat) / 100).ToString();
            }
            catch
            {
            }
        }

        void calculatetotal()
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(txtsubTotal.Text);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal taxamount = Convert.ToDecimal(txtTaxAmount.Text);
                decimal frieght = Convert.ToDecimal(txtFrieght.Text);
                decimal total = (subtotal + taxamount + frieght) - discount;
                txtTotal.Text = total.ToString();
                lblTotal.Text = txtTotal.Text;
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
                decimal total = Convert.ToDecimal(txtTotal.Text);

                txtDue.Text = (total - payment).ToString();
            }
            catch
            {
            }
        }

        void GetProduct()
        {
            try
            {
                List<Qry_Product> lstProductList = aProductBusiness.GetAllQryProductByCode(txtProduct.Text);
                lstProductList = lstProductList.Where(x => x.Product_IsFinishedGoods).ToList();
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
            }
            catch
            {
            }
        }

        void GetSupplier()
        {
            try
            {
                if (rbLocal.Checked)
                {
                    lstSupplierList = aSupplierBusiness.GetAllSupplierbyType(txtSupplierCode.Text, "Local").ToList();
                }
                if (rbForeign.Checked)
                {
                    lstSupplierList = aSupplierBusiness.GetAllSupplierbyType(txtSupplierCode.Text, "Foreign").ToList();
                }
                supplierListView.Items.Clear();
                if (lstSupplierList.Any())
                {
                    supplierListView.Visible = true;

                    foreach (Qry_Supplier asupplier in lstSupplierList)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        aListViewItem.Tag = asupplier;
                        aListViewItem.Text = asupplier.Supplier_Code;
                        aListViewItem.SubItems.Add(asupplier.Supplier_Name);
                        aListViewItem.SubItems.Add(asupplier.Supplier_Address);

                        supplierListView.Items.Add(aListViewItem);
                    }

                }
            }
            catch
            {
            }
        }

        void GetEmployee()
        {
            try
            {
                List<Tbl_Employee> lstEmployeeList = aEmployeeBusiness.GetAllEmployeeByID(txtEmployeeID.Text);
                employeelistView.Items.Clear();
                if (lstEmployeeList.Any())
                {
                    employeelistView.Visible = true;
                    foreach (Tbl_Employee employee in lstEmployeeList)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        aListViewItem.Tag = employee;
                        aListViewItem.Text = employee.Employee_ID;
                        aListViewItem.SubItems.Add(employee.Employee_Name);

                        employeelistView.Items.Add(aListViewItem);
                    }
                }
            }
            catch
            {
            }
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;

                if (Text == "Purchase Product")
                {
                    txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
                }
                Qry_PurchaseMaster lstQry_PurchaseMasterList = aPurchaseBusincess.GetAllQryPurchaseMaster(id);
                if (lstQry_PurchaseMasterList != null)
                {
                    txtInvoice.Text = lstQry_PurchaseMasterList.PurchaseMaster_InvoiceNo;
                    txtEmployeeID.Text = lstQry_PurchaseMasterList.Employee_ID;
                    txtSupplierCode.Text = lstQry_PurchaseMasterList.Supplier_Code;
                    txtSupplierName.Text = lstQry_PurchaseMasterList.Supplier_Name;
                    txtSupplierAddress.Text = lstQry_PurchaseMasterList.Supplier_Address;
                    dtpOrderDate.Value = lstQry_PurchaseMasterList.PurchaseMaster_OrderDate;
                    txtDescription.Text = lstQry_PurchaseMasterList.PurchaseMaster_Description;

                    aSupplier.Supplier_SlNo = lstQry_PurchaseMasterList.Supplier_SlNo;
                    aSupplier.Supplier_Name = lstQry_PurchaseMasterList.Supplier_Name;
                    aSupplier.Supplier_Address = lstQry_PurchaseMasterList.Supplier_Address;
                    aEmployee.Employee_ID = lstQry_PurchaseMasterList.Employee_ID;
                    aEmployee.Employee_SlNo = lstQry_PurchaseMasterList.Employee_SlNo;
                    aEmployee.Employee_Name = lstQry_PurchaseMasterList.Employee_Name;

                    List<Qry_PurchaseDetails> lstQry_PurchaseDetailsList = aPurchaseBusincess.GetAllQry_PurchaseDetails(id);
                    lstGridList = lstQry_PurchaseDetailsList;
                    LoadGrid();

                    txtDue.Text = Math.Round(lstQry_PurchaseMasterList.PurchaseMaster_DueAmount, 2).ToString();
                    txtPaid.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_PaidAmount), 2).ToString();
                    txtTotal.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_TotalAmount), 2).ToString();
                    lblTotal.Text = txtTotal.Text;
                    txtDiscount.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_DiscountAmount), 2).ToString();
                    txtFrieght.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_Freight), 2).ToString();
                    txtTaxAmount.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_Tax), 2).ToString();
                    txtsubTotal.Text = Math.Round((lstQry_PurchaseMasterList.PurchaseMaster_SubTotalAmount), 2).ToString();

                    employeelistView.Hide();
                    supplierListView.Hide();
                    btnEditPurchase.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    NewPurchase();
                }
            }
            catch
            {
            }
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtProduct.Text != string.Empty)
            {
                GetProduct();
            }
        }

        private void txtProduct_Click(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void supplierListView_Click(object sender, EventArgs e)
        {
            try
            {
                aSupplier = (Qry_Supplier)supplierListView.SelectedItems[0].Tag;
                txtSupplierCode.Text = aSupplier.Supplier_Code;
                txtSupplierName.Text = aSupplier.Supplier_Name;
                txtSupplierAddress.Text = aSupplier.Supplier_Address;
                supplierListView.Visible = false;
                txtProduct.Focus();
            }
            catch
            {
            }
        }

        void LoadGrid()
        {
            try
            {
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = lstGridList;

                txtsubTotal.Text = Math.Round(lstGridList.Sum(x => x.PurchaseDetails_TotalAmount), 2).ToString();
                txtTotal.Text = txtsubTotal.Text;
                txtPaid.Text = txtsubTotal.Text;
                lblTotal.Text = txtTotal.Text;
            }
            catch
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProduct.Text == string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Enter Product");
                    txtProduct.Focus();
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
                List<Qry_Product> lstProductList = aProductBusiness.GetAllQryProductByCode(txtProduct.Text);
                if (!lstProductList.Any())
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Product not found");
                    return;
                }
                if (lstGridList.Any(x => x.Product_SlNo == aTbl_Product.Product_SlNo))
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Data Already Exist");
                    return;
                }
                Qry_PurchaseDetails aQry_PurchaseDetails = new Qry_PurchaseDetails();
                aQry_PurchaseDetails.Product_SlNo = aTbl_Product.Product_SlNo;
                aQry_PurchaseDetails.Product_Name = aTbl_Product.Product_Name;
                aQry_PurchaseDetails.PurchaseDetails_TotalQuantity = Convert.ToDouble(txtQuantity.Text);
                aQry_PurchaseDetails.PurchaseDetails_Rate = Convert.ToDecimal(txtRate.Text);
                aQry_PurchaseDetails.PurchaseDetails_TotalAmount = (decimal)aQry_PurchaseDetails.PurchaseDetails_TotalQuantity * aQry_PurchaseDetails.PurchaseDetails_Rate;
                aQry_PurchaseDetails.PurchaseDetails_Discount = 0;
                aQry_PurchaseDetails.PurchaseDetails_Tax = 0;
                aQry_PurchaseDetails.PurchaseDetails_Freight = 0;
                aQry_PurchaseDetails.PurchaseDetails_ExpireDate = DateTime.UtcNow.AddHours(6).AddYears(6);
                aQry_PurchaseDetails.PurchaseDetail_ReceiveQuantity = aQry_PurchaseDetails.PurchaseDetails_TotalQuantity;
                aQry_PurchaseDetails.Unit_Name = aTbl_Product.Unit_Name;
                lstGridList.Add(aQry_PurchaseDetails);

                LoadGrid();
                txtProduct.Text = "";
                txtname.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                txtProduct.Focus();
            }
            catch
            {
            }
        }

        private void productListView_Click(object sender, EventArgs e)
        {
            try
            {
                aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                txtProduct.Text = aTbl_Product.Product_Code;
                txtname.Text = aTbl_Product.Product_Name;
                txtRate.Text = Math.Round(aTbl_Product.Product_Purchase_Rate, 2).ToString();
                productListView.Visible = false;
                txtQuantity.Focus();
            }
            catch
            {
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (id == 0)
                    {
                        lstGridList.RemoveAt(e.RowIndex);
                        LoadGrid();
                    }
                    else
                    {
                        if (lstGridList[e.RowIndex].PurchaseDetails_SlNo == 0)
                        {
                            lstGridList.RemoveAt(e.RowIndex);
                            LoadGrid();
                        }
                        else
                        {
                            var objd = lstGridList[e.RowIndex];
                            var detailList = aPurchaseBusincess.GetAllPurchaseDetailsByid(objd.PurchaseDetails_SlNo);
                            List<Tbl_PurchaseDetails> lstUpdate = new List<Tbl_PurchaseDetails>();
                            List<Tbl_CurrentInventory> lstupdateCurrentInventory = new List<Tbl_CurrentInventory>();
                            List<Tbl_PurchaseInventory> lstUpdatePurchaseInveontory = new List<Tbl_PurchaseInventory>();

                            var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(detailList.Product_SlNo);
                            var purchaseinventory = aPurchaseBusincess.GetAllPurchaseInventory(detailList.Product_SlNo);
                            if (currentinventory != null)
                            {
                                currentinventory.CurrentInventory_CurrentQuantity -= detailList.PurchaseDetails_TotalQuantity;
                                if (currentinventory.CurrentInventory_CurrentQuantity < 0)
                                {
                                    currentinventory.CurrentInventory_CurrentQuantity = 0;
                                }
                                lstupdateCurrentInventory.Add(currentinventory);
                            }
                            if (purchaseinventory != null)
                            {
                                purchaseinventory.PurchaseInventory_TotalQuantity -= detailList.PurchaseDetails_TotalQuantity;
                                if (purchaseinventory.PurchaseInventory_TotalQuantity < 0)
                                {
                                    purchaseinventory.PurchaseInventory_TotalQuantity = 0;
                                }
                                lstUpdatePurchaseInveontory.Add(purchaseinventory);
                            }
                            detailList.Status = "D";
                            detailList.UpdateBy = SplashForm.username;
                            detailList.UpdateTime = DateTime.UtcNow.AddHours(6);
                            lstUpdate.Add(detailList);

                            aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstupdateCurrentInventory);
                            aPurchaseBusincess.InsertorUpdatePurchaseInventory(lstUpdatePurchaseInveontory);
                            aPurchaseBusincess.UpdatePurchaseDetail(lstUpdate);

                            lstGridList.Remove(objd);

                            LoadGrid();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        void NewPurchase()
        {
            try
            {
                txtEmployeeID.Text = "";
                rbLocal.Checked = true;
                txtSupplierCode.Text = "";
                txtProduct.Text = "";
                txtSupplierName.Text = "";
                txtSupplierAddress.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                txtDiscount.Text = "0";
                txtFrieght.Text = "0";
                txtPaid.Text = "0";
                txtQuantity.Text = "0";
                txtsubTotal.Text = "0";
                txtTotal.Text = "0";
                lblTotal.Text = "0";
                txtTax.Text = "0";
                txtTaxAmount.Text = "0";
                txtDue.Text = "0";

                employeelistView.Hide();
                supplierListView.Hide();
                productListView.Hide();

                btnSave.Visible = true;
                btnEditPurchase.Visible = false;

                txtEmployeeID.Focus();
                dgvProduct.DataSource = null;
                lstGridList.Clear();
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lstGridList.Any())
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List");
                    return;
                }
                if (txtEmployeeID.Text == null)
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Please select an employee");
                    txtEmployeeID.Focus();
                    return;
                }
                if ((MessageBox.Show("Do You Want To Save These Entries?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                {
                    return;
                }
                List<Tbl_PurchaseMaster> lstmasterList = new List<Tbl_PurchaseMaster>();
                Tbl_PurchaseMaster master = new Tbl_PurchaseMaster();
                master.Supplier_SlNo = aSupplier.Supplier_SlNo;
                master.Employee_SlNo = aEmployee.Employee_SlNo;//use employee
                master.PurchaseMaster_InvoiceNo = aPurchaseBusincess.GenerateInvoiceNo(); //invoice
                master.PurchaseMaster_OrderDate = dtpOrderDate.Value.Date;
                master.PurchaseMaster_Description = txtDescription.Text;
                master.PurchaseMaster_PurchaseType = "CASH";
                master.PurchaseMaster_ReceiveDate = dtpOrderDate.Value.Date;
                master.PurchaseMaster_SubTotalAmount = Convert.ToDecimal(txtsubTotal.Text);
                master.PurchaseMaster_Tax = Convert.ToDecimal(txtTaxAmount.Text);
                master.PurchaseMaster_Freight = Convert.ToDecimal(txtFrieght.Text);
                master.PurchaseMaster_DiscountAmount = Convert.ToDecimal(txtDiscount.Text);
                master.PurchaseMaster_TotalAmount = Convert.ToDecimal(txtTotal.Text);
                master.PurchaseMaster_PaidAmount = Convert.ToDecimal(txtPaid.Text);
                master.PurchaseMaster_DueAmount = Convert.ToDecimal(txtDue.Text);
                if (master.PurchaseMaster_DueAmount > 0)
                {
                    master.PurchaseMaster_Status = "Partial";
                }
                else
                {
                    master.PurchaseMaster_Status = "Full";
                }
                master.Status = "A";
                master.AddBy = SplashForm.username;
                master.AddTime = DateTime.UtcNow.AddHours(6);
                string msg = aPurchaseBusincess.ValidateMasterOnSave(master);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //validation for duplicate invoice no.
                if (lstQry_PurchaseMaster.Any())
                {
                    var result = aPurchaseBusincess.GetPurchaseMaster();

                    if (result.PurchaseMaster_InvoiceNo == txtInvoice.Text)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', "Invoice No. already exist.pls check your date!");
                        return;
                    }
                }
                // aPurchaseBusincess.InsertPurchaseMaster(master);
                lstmasterList.Add(master);

                // cash register entry

                List<Tbl_CashRegister> lstCashRegisterList = new List<Tbl_CashRegister>();
                Tbl_CashRegister aTbl_CashRegister = new Tbl_CashRegister();
                aTbl_CashRegister.Transaction_Date = dtpOrderDate.Value.Date;
                aTbl_CashRegister.IdentityNo = txtInvoice.Text;
                aTbl_CashRegister.Narration = "Purchase";
                aTbl_CashRegister.OutAmount = Convert.ToDecimal(txtPaid.Text);
                aTbl_CashRegister.InAmount = 0;
                aTbl_CashRegister.Status = "A";
                aTbl_CashRegister.Description = txtDescription.Text;
                aTbl_CashRegister.Saved_By = SplashForm.username;
                aTbl_CashRegister.Saved_Time = DateTime.UtcNow.AddHours(6);
                aCashAccountBusiness.InsertCashRegister(aTbl_CashRegister);

                //

                List<Tbl_PurchaseDetails> lstDetailsList = new List<Tbl_PurchaseDetails>();
                List<Tbl_PurchaseInventory> lstInventoryList = new List<Tbl_PurchaseInventory>();
                List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();

                foreach (Qry_PurchaseDetails div in lstGridList)
                {
                    Tbl_PurchaseDetails details = new Tbl_PurchaseDetails();
                    details.PurchaseMaster_SlNo = master.PurchaseMaster_SlNo;
                    details.Product_SlNo = div.Product_SlNo;
                    details.PurchaseDetails_TotalQuantity = div.PurchaseDetails_TotalQuantity;
                    details.PurchaseDetail_ReceiveQuantity = div.PurchaseDetail_ReceiveQuantity;
                    details.PurchaseDetails_Rate = div.PurchaseDetails_Rate;
                    details.PurchaseDetails_ExpireDate = div.PurchaseDetails_ExpireDate;
                    details.PurchaseDetails_Discount = div.PurchaseDetails_Discount;
                    details.PurchaseDetails_Tax = div.PurchaseDetails_Tax;
                    details.PurchaseDetails_Freight = div.PurchaseDetails_Freight;
                    details.PurchaseDetails_TotalAmount = div.PurchaseDetails_TotalAmount;
                    details.Status = "A";
                    details.AddBy = SplashForm.username;
                    details.AddTime = DateTime.UtcNow.AddHours(6);
                    msg = aPurchaseBusincess.validateDetailsOnSave(details);
                    if (msg != string.Empty)
                    {
                        UtilityBusiness.DisplayAlertMessage('W', msg);
                        return;
                    }
                    lstDetailsList.Add(details);

                    Tbl_PurchaseInventory inventory = new Tbl_PurchaseInventory();
                    Tbl_PurchaseInventory existData = aPurchaseInventoryBusincess.GetAllPurchaseInventory(div.Product_SlNo);
                    if (existData != null)
                    {
                        inventory = existData;
                    }
                    inventory.Product_SlNo = div.Product_SlNo;
                    inventory.PurchaseInventory_TotalQuantity += div.PurchaseDetails_TotalQuantity;
                    inventory.PurchaseInventory_ReceiveQuantity += div.PurchaseDetail_ReceiveQuantity;
                    inventory.PurchaseInventory_ReturnQuantity += 0;
                    inventory.PurchaseInventory_DamageQuantity += 0;
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
                    aTbl_CurrentInventory.Product_SlNo = div.Product_SlNo;
                    aTbl_CurrentInventory.CurrentInventory_CurrentQuantity += div.PurchaseDetails_TotalQuantity;
                    //aTbl_CurrentInventory.CurrentInventory_CurrentQuantity = aTbl_CurrentInventory.CurrentInventory_CurrentQuantity + div.PurchaseDetails_TotalQuantity;
                    lstCurrentInventoryList.Add(aTbl_CurrentInventory);
                }

                //aPurchaseBusincess.InsertPurchaseDetail(lstDetailsList);
                //aPurchaseInventoryBusincess.InsertorUpdatePurchaseInventory(lstInventoryList);
                //aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstCurrentInventoryList);
                aPurchaseBusincess.SavePurchase(lstmasterList, lstDetailsList, lstInventoryList, lstCurrentInventoryList);

                NewPurchase();
                UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
                lstDetailsList = new List<Tbl_PurchaseDetails>();
                lstInventoryList = new List<Tbl_PurchaseInventory>();
                lstGridList = new List<Qry_PurchaseDetails>();

                if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PurchaseInvoiceReportForm ob = new PurchaseInvoiceReportForm(txtInvoice.Text);
                    ob.Show();

                    if (Text == "Purchase Product")
                    {
                        txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
                    }
                }
                if (Text == "Purchase Product")
                {
                    txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEmployeeID_Click(object sender, EventArgs e)
        {
            GetEmployee();
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFrieght_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                employeelistView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                employeelistView.Focus();
            }
            else
            {
                GetEmployee();
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text != string.Empty)
            {
                GetEmployee();
            }
        }

        private void employeelistView_Click(object sender, EventArgs e)
        {
            try
            {
                aEmployee = (Tbl_Employee)employeelistView.SelectedItems[0].Tag;

                txtEmployeeID.Text = aEmployee.Employee_ID;
                employeelistView.Visible = false;
                txtSupplierCode.Focus();
            }
            catch
            {
            }
        }

        private void txtSupplierCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierCode.Text != string.Empty)
            {
                GetSupplier();
            }

            if (txtSupplierCode.Text == "S0001")
            {
                txtSupplierName.ReadOnly = false;
                txtSupplierAddress.ReadOnly = false;
            }
            else
            {
                txtSupplierName.ReadOnly = true;
                txtSupplierAddress.ReadOnly = true;
            }
        }

        private void txtSupplierCode_Click(object sender, EventArgs e)
        {
            try
            {
                GetSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    supplierListView.Hide();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    supplierListView.Focus();
                }
                else
                {
                    GetSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PurchaseInvoiceReportForm ob = new PurchaseInvoiceReportForm("");
            ob.Show();
        }


        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtTax.Text) > 100)
                {
                    MessageBox.Show("Tax Can't Be More Than 100%", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTax.Focus();
                    return;
                }
                Vat_Calculation();
            }
            catch
            {
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtDiscount.Text) > Convert.ToDecimal(txtTotal.Text))
                {
                    MessageBox.Show("Discount Can't Be More Than Total Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return;
                }
                calculatetotal();
            }
            catch
            {
            }
        }

        private void txtTaxAmount_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtFrieght_TextChanged(object sender, EventArgs e)
        {
            calculatetotal();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtPaid.Text = txtTotal.Text;
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtPaid.Text) > Convert.ToDecimal(txtTotal.Text))
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

        private void rbLocal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbLocal.Checked)
                {
                    GetSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbForeign_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbForeign.Checked)
                {
                    GetSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (Text == "Purchase Product")
            {
                NewPurchase();
                txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
            }
            else
            {
                MessageBox.Show("Access Denied!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void supplierListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aSupplier = (Qry_Supplier)supplierListView.SelectedItems[0].Tag;
                    txtSupplierCode.Text = aSupplier.Supplier_Code;
                    txtSupplierName.Text = aSupplier.Supplier_Name;
                    txtSupplierAddress.Text = aSupplier.Supplier_Address;
                    supplierListView.Visible = false;
                    txtProduct.Focus();
                }
            }
            catch
            {
            }
        }

        private void productListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                    txtProduct.Text = aTbl_Product.Product_Code;
                    txtname.Text = aTbl_Product.Product_Name;
                    txtRate.Text = Math.Round(aTbl_Product.Product_Purchase_Rate, 2).ToString();
                    productListView.Visible = false;
                    txtQuantity.Focus();
                }
            }
            catch
            {
            }
        }

        private void employeelistView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aEmployee = (Tbl_Employee)employeelistView.SelectedItems[0].Tag;

                    txtEmployeeID.Text = aEmployee.Employee_ID;
                    employeelistView.Visible = false;
                    txtSupplierCode.Focus();
                }
            }
            catch
            {
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm ob = new SupplierForm();
            ob.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm ob = new ProductForm();
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
                txtProduct.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnAdd.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtQuantity.Focus();
            }
        }

        private void txtTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFrieght.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtFrieght.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtProduct.Focus();
            }
        }

        private void txtFrieght_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscount.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtDiscount.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtTax.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
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
                txtFrieght.Focus();
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
                txtDiscount.Focus();
            }
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierName.Text == "General Supplier")
            {
                txtPaid.Enabled = false;
            }
            else
            {
                txtPaid.Enabled = true;
            }
        }

        private void btnEditPurchase_Click(object sender, EventArgs e)
        {
            if (!lstGridList.Any())
            {
                UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List");
                return;
            }
            if ((MessageBox.Show("Do You Want To Update These Entries?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
            {
                return;
            }

            Tbl_PurchaseMaster aTbl_PurchaseMaster = aPurchaseBusincess.GetAllPurchaseMaster(id);
            Tbl_CashRegister aTbl_CashRegister = aCashAccountBusiness.GetAllCashRegister(txtInvoice.Text);

            try
            {
                aTbl_PurchaseMaster.Supplier_SlNo = aSupplier.Supplier_SlNo;
                aTbl_PurchaseMaster.Employee_SlNo = aEmployee.Employee_SlNo;
                aTbl_PurchaseMaster.PurchaseMaster_OrderDate = dtpOrderDate.Value.Date;
                aTbl_PurchaseMaster.PurchaseMaster_Description = txtDescription.Text;
                aTbl_PurchaseMaster.PurchaseMaster_SubTotalAmount = Convert.ToDecimal(txtsubTotal.Text);
                aTbl_PurchaseMaster.PurchaseMaster_Tax = Convert.ToDecimal(txtTaxAmount.Text);
                aTbl_PurchaseMaster.PurchaseMaster_Freight = Convert.ToDecimal(txtFrieght.Text);
                aTbl_PurchaseMaster.PurchaseMaster_DiscountAmount = Convert.ToDecimal(txtDiscount.Text);
                aTbl_PurchaseMaster.PurchaseMaster_TotalAmount = Convert.ToDecimal(txtTotal.Text);
                aTbl_PurchaseMaster.PurchaseMaster_PaidAmount = Convert.ToDecimal(txtPaid.Text);
                aTbl_PurchaseMaster.PurchaseMaster_DueAmount = Convert.ToDecimal(txtDue.Text);
                if (aTbl_PurchaseMaster.PurchaseMaster_DueAmount > 0)
                {
                    aTbl_PurchaseMaster.PurchaseMaster_Status = "Partial";
                }
                else
                {
                    aTbl_PurchaseMaster.PurchaseMaster_Status = "Full";
                }
                aTbl_PurchaseMaster.Status = "A";
                aTbl_PurchaseMaster.UpdateBy = SplashForm.username;
                aTbl_PurchaseMaster.UpdateTime = DateTime.UtcNow.AddHours(6);
                string msg = aPurchaseBusincess.ValidateMasterOnSave(aTbl_PurchaseMaster);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }

                //edit from cash register table
                aTbl_CashRegister.Transaction_Date = dtpOrderDate.Value.Date;
                aTbl_CashRegister.InAmount = Convert.ToDecimal(txtPaid.Text);
                aTbl_CashRegister.Status = "A";
                aTbl_CashRegister.Description = txtDescription.Text;
                aTbl_CashRegister.Edited_By = SplashForm.username;
                aTbl_CashRegister.Edited_Time = DateTime.UtcNow.AddHours(6);
                //

                List<Tbl_PurchaseDetails> lstUpdate = new List<Tbl_PurchaseDetails>();
                List<Tbl_PurchaseDetails> lstInsert = new List<Tbl_PurchaseDetails>();
                List<Tbl_CurrentInventory> lstupdateCurrentInventory = new List<Tbl_CurrentInventory>();
                List<Tbl_PurchaseInventory> lstUpdatePurchaseInveontory = new List<Tbl_PurchaseInventory>();

                foreach (Qry_PurchaseDetails div in lstGridList)
                {
                    Tbl_PurchaseDetails details = aPurchaseBusincess.GetAllPurchaseDetailsByid(div.PurchaseDetails_SlNo);
                    if (details != null)
                    {
                        details.Product_SlNo = div.Product_SlNo;
                        details.PurchaseDetails_TotalQuantity = div.PurchaseDetails_TotalQuantity;
                        details.PurchaseDetail_ReceiveQuantity = div.PurchaseDetail_ReceiveQuantity;
                        details.PurchaseDetails_Rate = div.PurchaseDetails_Rate;
                        details.PurchaseDetails_ExpireDate = div.PurchaseDetails_ExpireDate;
                        details.PurchaseDetails_Discount = div.PurchaseDetails_Discount;
                        details.PurchaseDetails_Tax = div.PurchaseDetails_Tax;
                        details.PurchaseDetails_Freight = div.PurchaseDetails_Freight;
                        details.PurchaseDetails_TotalAmount = div.PurchaseDetails_TotalAmount;
                        details.Status = "A";
                        details.UpdateBy = SplashForm.username;
                        details.UpdateTime = DateTime.UtcNow.AddHours(6);
                        msg = aPurchaseBusincess.validateDetailsOnSave(details);
                        if (msg != string.Empty)
                        {
                            UtilityBusiness.DisplayAlertMessage('W', msg);
                            return;
                        }
                        lstUpdate.Add(details);
                    }
                    else
                    {
                        details = new Tbl_PurchaseDetails();
                        details.Product_SlNo = div.Product_SlNo;
                        details.PurchaseMaster_SlNo = id;
                        details.PurchaseDetails_TotalQuantity = div.PurchaseDetails_TotalQuantity;
                        details.PurchaseDetail_ReceiveQuantity = div.PurchaseDetail_ReceiveQuantity;
                        details.PurchaseDetails_Rate = div.PurchaseDetails_Rate;
                        details.PurchaseDetails_ExpireDate = div.PurchaseDetails_ExpireDate;
                        details.PurchaseDetails_Discount = div.PurchaseDetails_Discount;
                        details.PurchaseDetails_Tax = div.PurchaseDetails_Tax;
                        details.PurchaseDetails_Freight = div.PurchaseDetails_Freight;
                        details.PurchaseDetails_TotalAmount = div.PurchaseDetails_TotalAmount;
                        details.Status = "A";
                        details.UpdateBy = SplashForm.username;
                        details.UpdateTime = DateTime.UtcNow.AddHours(6);
                        msg = aPurchaseBusincess.validateDetailsOnSave(details);
                        if (msg != string.Empty)
                        {
                            UtilityBusiness.DisplayAlertMessage('W', msg);
                            return;
                        }
                        lstInsert.Add(details);

                        Tbl_PurchaseInventory objpInventory = new Tbl_PurchaseInventory();
                        var purchaseinventory = aPurchaseBusincess.GetAllPurchaseInventory(div.Product_SlNo);
                        if (purchaseinventory != null)
                        {
                            objpInventory = purchaseinventory;
                        }
                        objpInventory.Product_SlNo = div.Product_SlNo;
                        objpInventory.PurchaseInventory_TotalQuantity += div.PurchaseDetails_TotalQuantity;
                        objpInventory.PurchaseInventory_ReceiveQuantity += div.PurchaseDetail_ReceiveQuantity;
                        objpInventory.PurchaseInventory_ReturnQuantity += 0;
                        objpInventory.PurchaseInventory_DamageQuantity += 0;
                        objpInventory.UpdateBy = SplashForm.username;
                        objpInventory.UpdateTime = DateTime.UtcNow.AddHours(6);

                        if (objpInventory.PurchaseInventory_TotalQuantity < 0)
                        {
                            objpInventory.PurchaseInventory_TotalQuantity = 0;
                        }
                        lstUpdatePurchaseInveontory.Add(objpInventory);

                        Tbl_CurrentInventory objcurinventory = new Tbl_CurrentInventory();

                        var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                        if (currentinventory != null)
                        {
                            objcurinventory = currentinventory;
                        }

                        objcurinventory.Product_SlNo = div.Product_SlNo;
                        objcurinventory.CurrentInventory_CurrentQuantity += div.PurchaseDetails_TotalQuantity;

                        if (objcurinventory.CurrentInventory_CurrentQuantity < 0)
                        {
                            objcurinventory.CurrentInventory_CurrentQuantity = 0;
                        }
                        lstupdateCurrentInventory.Add(objcurinventory);
                    }
                }
                aPurchaseBusincess.UpdatePurchaseDetail(lstUpdate);
                aPurchaseBusincess.InsertPurchaseDetail(lstInsert);
                aPurchaseBusincess.InsertorUpdatePurchaseInventory(lstUpdatePurchaseInveontory);
                aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstupdateCurrentInventory);
                aPurchaseBusincess.UpdatePurchaseMaster(aTbl_PurchaseMaster);
                aCashAccountBusiness.UpdateCashRegister(aTbl_CashRegister);

                UtilityBusiness.DisplayAlertMessage('S', "Updated Successfully");
                lstUpdate = new List<Tbl_PurchaseDetails>();
                lstUpdatePurchaseInveontory = new List<Tbl_PurchaseInventory>();
                //lstGridList = new List<Qry_PurchaseDetails>();

                if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PurchaseInvoiceReportForm ob = new PurchaseInvoiceReportForm(txtInvoice.Text);
                    ob.Show();
                    if (Text == "Purchase Product")
                    {
                        txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
                    }
                }
                if (Text == "Purchase Product")
                {
                    txtInvoice.Text = aPurchaseBusincess.GenerateInvoiceNo();
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_PurchaseMaster = null;
            }
        }

        private void PurchaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Text == "Edit Purchase Product")
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