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
    public partial class ServiceSaleForm : Form
    {
        ProductBusiness aProductBusiness = new ProductBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        EmployeeBusiness aEmployeeBusiness = new EmployeeBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        Tbl_Employee aEmployee = new Tbl_Employee();
        Qry_Customer acustomer = new Qry_Customer();
        List<Qry_SalesDetails> lstSalesDetailsList = new List<Qry_SalesDetails>();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        SalesBusiness aSalesdetailsBusiness = new SalesBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();

        public ServiceSaleForm()
        {
            InitializeComponent();
            
        }

        void GetProduct()
        {
            List<Qry_Product> lstSalesDetailsList = aProductBusiness.GetAllQryProductService(txtProductID.Text, chkService.Checked);
            productListView.Items.Clear();
            if (lstSalesDetailsList.Any())
            {
                productListView.Visible = true;
                foreach (Qry_Product aProduct in lstSalesDetailsList)
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

        void GetCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtcustomercode.Text);
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

        void loadGrid()
        {
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = lstSalesDetailsList;
            txtSubTotal.Text = Math.Round(lstSalesDetailsList.Sum(x => x.SaleDetails_TotalAmount), 2).ToString();
            txtProductTotal.Text = txtSubTotal.Text;
            txtPaid.Text = txtSubTotal.Text;
            lbltotalamount.Text = txtProductTotal.Text;

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            
            txtProductID.Focus();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ProductForm ob = new ProductForm();
            ob.Show();
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
            aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

            txtProductID.Text = aTbl_Product.Product_Code;
            txtProductName.Text = aTbl_Product.Product_Name;
            txtRate.Text =Math.Round( aTbl_Product.Product_SellingPrice,2).ToString();
            lblunit.Text = aTbl_Product.Unit_Name;
            productListView.Visible = false;
            txtQuantity.Focus();
        }

        private void txtProductID_Click(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          if (lstSalesDetailsList.Any())
            {
                if (e.ColumnIndex == 5)
                {
                    lstSalesDetailsList.RemoveAt(e.RowIndex);
                    loadGrid();
                }
            }
        }

        void NewSales()
        {
            txtDescription.Text = "";
            lbltotalamount.Text = "0";
            txtDue.Text = "0";
            txtPaid.Text = "0";
            txtProductTotal.Text = "0";
            txtDiscountAmount.Text = "0";
            txtDiscountPercent.Text = "0";
            txtfreight.Text = "0";
            txtVatAmount.Text = "0";
            txtVatPercent.Text = "0";
            txtSubTotal.Text = "0";
            txtRate.Text = "0";
            lblunit.Text = "";
            txtQuantity.Text = "0";
            txtProductName.Text = "";
            txtProductID.Text = "";
            txtcontact.Text = "";
            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtcustomercode.Text = "";
            customerlistView.Hide();
            productListView.Hide();
            txtcustomercode.Focus();
            dgvProduct.DataSource = null;
            lstSalesDetailsList.Clear();
        }

        decimal pre_due;
        decimal due;
        decimal payment;
        decimal Total_Due;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!lstSalesDetailsList.Any())
            {
                UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List");
                return;
            }
            if ((MessageBox.Show("Do You Want To Save These Entries. Continue? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
            {
                return;
            }
            //validation for credit limit

            List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDueByCustomerCode(txtcustomercode.Text).ToList();
            if (lstCustomerDueList.Any())
            {
                due = lstCustomerDueList.Sum(x => x.SaleMaster_DueAmount);
            }

            List<Qry_CustomerPayment> lstCustomerPayment = aCashAccountBusiness.GetAllCashAccountByCustomerID(txtcustomercode.Text);
            if (lstCustomerPayment.Any())
            {
                payment = lstCustomerPayment.Sum(x => x.In_Amount);
            }

            pre_due = due - payment;
            Total_Due = pre_due + Convert.ToDecimal(txtDue.Text);

            Tbl_Customer aTbl_Customer = aCustomerBusiness.GetAllCustomerByCode(txtcustomercode.Text);

            if (Total_Due > aTbl_Customer.Customer_Credit_Limit)
            {
                UtilityBusiness.DisplayAlertMessage('W', "Credit Limit Exist");
                return;
            }

            List<Tbl_SalesMaster> lstMasterList = new List<Tbl_SalesMaster>();
            Tbl_SalesMaster master = new Tbl_SalesMaster();
            master.SaleMaster_InvoiceNo = txtInvoice.Text;
            master.SaleMaster_CalanNo = "";
            master.SaleMaster_Description = txtDescription.Text;
            master.Employee_SlNo = aEmployee.Employee_SlNo;
            master.Customer_SlNo = acustomer.Customer_SlNo;
            master.SaleMaster_SaleDate = dtpSaleDate.Value.Date;
            master.SaleMaster_SaleType = "CASH";
            master.SaleMaster_SubTotalAmount = Convert.ToDecimal(txtSubTotal.Text); ;
            master.SaleMaster_TotalDiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
            master.SaleMaster_TaxAmount = Convert.ToDecimal(txtVatAmount.Text);
            master.SaleMaster_Freight = Convert.ToDecimal(txtfreight.Text);
            master.SaleMaster_TotalSaleAmount = Convert.ToDecimal(txtProductTotal.Text);
            master.SaleMaster_PaidAmount = Convert.ToDecimal(txtPaid.Text);
            master.SaleMaster_DueAmount = Convert.ToDecimal(txtDue.Text);
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
           
            aSalesBusiness.InsertSalesMaster(master);
            lstMasterList.Add(master);
            List<Tbl_SaleDetails> lstDetailsList = new List<Tbl_SaleDetails>();
            List<Tbl_SaleInventory> lstInventoryList = new List<Tbl_SaleInventory>();
            List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();

            foreach (Qry_SalesDetails div in lstSalesDetailsList)
            {
                Tbl_SaleDetails details = new Tbl_SaleDetails();
                details.SaleMaster_SlNo = master.SaleMaster_SlNo;
                details.Product_SlNo = div.Product_SlNo;
                details.SaleDetails_TotalQuantity = div.SaleDetails_TotalQuantity;
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

                Tbl_SaleInventory inventory = new Tbl_SaleInventory();
                Tbl_SaleInventory existData = aSalesdetailsBusiness.GetAllSalesInventory(div.Product_SlNo);
                if (existData != null)
                {
                    inventory = existData;
                }
                inventory.Product_SlNo = div.Product_SlNo;
                inventory.SaleInventory_TotalQuantity+= div.SaleDetails_TotalQuantity;
                inventory.SaleInventory_ReceiveQuantity += div.SaleDetails_TotalQuantity;
                inventory.SaleInventory_ReturnQuantity += 0;
                inventory.SaleInventory_DamageQuantity += 0;
                inventory.AddBy = SplashForm.username;
                inventory.AddTime = DateTime.UtcNow.AddHours(6);
                lstInventoryList.Add(inventory);
            }
            aSalesBusiness.InsertSalesDetail(lstDetailsList);
            aSalesdetailsBusiness.InsertorUpdateSalesInventory(lstInventoryList);
            
            NewSales();
            txtDue.Text = "0";
            UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
            
            dgvProduct.DataSource = null;
            lstDetailsList = new List<Tbl_SaleDetails>();
            lstInventoryList = new List<Tbl_SaleInventory>();
            lstSalesDetailsList = new List<Qry_SalesDetails>();

            if (MessageBox.Show("Do You Want To Generate Report? ", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalesInvoiceReportForm ob = new SalesInvoiceReportForm(txtInvoice.Text);
                ob.Show();
                txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
            }
            txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
        }

        private void ProductSalesForm_Load(object sender, EventArgs e)
        {
            txtInvoice.Text = aSalesBusiness.GenerateInvoiceNo();
            txtEmployeeID.Text = SplashForm.username;
            txtProductID.Focus();
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
                txtDiscountAmount.Focus();
            }
            catch
            {
            }
        }

        void calculatetotal()
        {
            try
            {

                int qty = Convert.ToInt32(txtQuantity.Text);
                decimal rate = Convert.ToDecimal(txtRate.Text);
                decimal amount = qty * rate;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                UtilityBusiness.DisplayAlertMessage('W', "Enter Number");
            }

            base.OnKeyPress(e);
        }

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
                if (Convert.ToInt32(txtQuantity.Text) == 0)
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
                if (lstSalesDetailsList.Any(x => x.Product_SlNo == aTbl_Product.Product_SlNo))
                {
                    UtilityBusiness.DisplayAlertMessage('W', "Data already exist");
                    return;
                }
                Qry_SalesDetails details = new Qry_SalesDetails();
                details.Product_SlNo = aTbl_Product.Product_SlNo;
                details.Product_Name = aTbl_Product.Product_Name;
                details.SaleDetails_TotalQuantity = Convert.ToInt32(txtQuantity.Text);
                details.SaleDetails_Rate = Convert.ToDecimal(txtRate.Text);
                details.SaleDetails_Discount = Convert.ToDecimal(txtVatAmount.Text);
                details.SaleDetails_Tax = Convert.ToDecimal(txtDiscountAmount.Text);
                details.SaleDetails_Freight = Convert.ToDecimal(txtfreight.Text);
                details.SaleDetails_TotalAmount = Convert.ToDecimal(txtAmount.Text);
                details.Unit_Name = aTbl_Product.Unit_Name;
                lstSalesDetailsList.Add(details);
                loadGrid();
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtQuantity.Text = "0";
                txtRate.Text = "0";
                txtProductID.Focus();
            }
            catch
            {
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
                txtProductID.Focus();
            }
            catch
            {
            }
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomercode.Text != string.Empty)
            {
                GetCustomer();
            }
            if (txtcustomercode.Text == "C0001")
            {
                txtPaid.Enabled = false;
            }
            else
            {
                txtPaid.Enabled = true;
            }
        }

        private void txtcustomercode_Click(object sender, EventArgs e)
        {
            GetCustomer();
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
            try
            {
                SalesInvoiceReportForm ob = new SalesInvoiceReportForm("");
                ob.Show();
            }
            catch
            {
            }
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
            try
            {
                txtPaid.Text = txtProductTotal.Text;
            }
            catch
            {
            }
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewSales();
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
            if(e.KeyChar==13)
            {
                try
                {
                    acustomer = (Qry_Customer)customerlistView.SelectedItems[0].Tag;
                    txtcustomercode.Text = acustomer.Customer_Code;
                    txtCustomerName.Text = acustomer.Customer_Name;
                    txtAddress.Text = acustomer.Customer_Address;
                    txtcontact.Text = acustomer.Customer_Mobile;
                    customerlistView.Visible = false;
                    txtProductID.Focus();
                }
                catch
                {
                }
            }
        }

        private void productListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                txtProductID.Text = aTbl_Product.Product_Code;
                txtProductName.Text = aTbl_Product.Product_Name;
                txtRate.Text = Math.Round(aTbl_Product.Product_SellingPrice, 2).ToString();
                lblunit.Text = aTbl_Product.Unit_Name;
                productListView.Visible = false;
                txtQuantity.Focus();
            }
        }

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
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
    }
}
