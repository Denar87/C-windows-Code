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

namespace IMS_Win
{
    public partial class MainForm : Form
    {
        UserBusiness aUserBusiness = new UserBusiness();
        
        public MainForm(string uid)
        {
            InitializeComponent();
            lblUserID.Text = uid;
        }
        
        private void Enable_Controls()
        {
            
            tsbProduct.Enabled = true;
            tsbVendor.Enabled = true;
            tsbCustomer.Enabled = true;
            tsbPurchase.Enabled = true;
            tsbTransaction.Enabled = true;
            tsbStock.Enabled = true;
            tsbLock.Enabled = true;
            tsbSales.Enabled = true;
            tsbService.Enabled = true;
            tsbLogout.Enabled = true;

            btnSales.Enabled = true;
            btnService.Enabled = true;
            btnSaleReturn.Enabled = true;
            btnPurchase.Enabled = true;
            btnPurchaseReturn.Enabled = true;
            btnTransaction.Enabled = true;

            btnSaleInvoice.Enabled = true;
            btnPurchaseInvoice.Enabled = true;
            btnStock.Enabled = true;
            btnTotalSale.Enabled = true;
            btnTotalPurchase.Enabled = true;
            btnPriceChart.Enabled = true;
            btnAllReports.Enabled = true;

            ToolStripMenuItemMaster.Enabled = true;
            ToolStripMenuItemSupplier.Enabled = true;
            ToolStripMenuItemCustomer.Enabled = true;
            ToolStripMenuItemPurchase.Enabled = true;
            ToolStripMenuItemSales.Enabled = true;
            ToolStripMenuItemAccounts.Enabled = true;
            toolStripMenuItemEmployee.Enabled = true;
            ToolStripMenuItemReports.Enabled = true;
            ToolStripMenuItemSettings.Enabled = true;
            ToolStripMenuItemHelp.Enabled = true;
            toolsToolStripMenuItem.Enabled = true;
        }

        private void Disable_Controls()
        {
            tsbProduct.Enabled = false;
            tsbVendor.Enabled = false;
            tsbCustomer.Enabled = false;
            tsbPurchase.Enabled = false;
            tsbTransaction.Enabled = false;
            tsbStock.Enabled = false;
            tsbLock.Enabled = true;
            tsbSales.Enabled = true;
            tsbService.Enabled = true;
            tsbLogout.Enabled = true;

            btnSales.Enabled = true;
            btnService.Enabled = true;
            btnSaleReturn.Enabled = true;
            btnPurchase.Enabled = false;
            btnPurchaseReturn.Enabled = false;
            btnTransaction.Enabled = false;
            btnAllReports.Enabled = false;

            btnSaleInvoice.Enabled = true;
            btnPurchaseInvoice.Enabled = false;
            btnStock.Enabled = false;
            btnTotalSale.Enabled = false;
            btnTotalPurchase.Enabled = false;
            btnPriceChart.Enabled = true;

            ToolStripMenuItemMaster.Enabled = true;
            ToolStripMenuItemSupplier.Enabled = false;
            ToolStripMenuItemCustomer.Enabled = false;
            ToolStripMenuItemPurchase.Enabled = false;
            ToolStripMenuItemSales.Enabled = true;
            ToolStripMenuItemAccounts.Enabled = false;
            toolStripMenuItemEmployee.Enabled = false;
            ToolStripMenuItemReports.Enabled = false;
            ToolStripMenuItemSettings.Enabled = false;
            ToolStripMenuItemHelp.Enabled = true;
            toolsToolStripMenuItem.Enabled = true;
        }

        private void tbrCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm ob = new CustomerForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrVendor_Click(object sender, EventArgs e)
        {
            SupplierForm ob = new SupplierForm();
            ob.MdiParent = this.MdiParent;
            ob.ShowDialog();
        }

        private void tbrProduct_Click(object sender, EventArgs e)
        {
            ProductForm ob = new ProductForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrCategory_Click(object sender, EventArgs e)
        {
            ProductCategoryForm ob = new ProductCategoryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrUser_Click(object sender, EventArgs e)
        {
            UserForm ob = new UserForm();
            ob.MdiParent=this;
            ob.Show();
        }

        private void newVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierForm ob = new SupplierForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm ob = new CustomerForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Left = label3.Left - 1;
            if (label3.Left < -label3.Width)
            {
                label3.Left = panel7.Width;
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //or, System.Environment.Exit(0);
        }

        private void ToolStripMenuItemLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyProfileForm ob = new CompanyProfileForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm ob = new UserForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProductCategoryForm ob = new ProductCategoryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductForm ob = new ProductForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void unitOfMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitOfMeasurementForm ob = new UnitOfMeasurementForm();
            ob.MdiParent=this;
            ob.Show();
        }

        private void tbrStock_Click(object sender, EventArgs e)
        {
            StockLevelReportsForm ob = new StockLevelReportsForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrInvoice_Click(object sender, EventArgs e)
        {
            ProductSalesForm ob = new ProductSalesForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void designationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignationForm ob = new DesignationForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void departmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DepartmentForm ob = new DepartmentForm();
            ob.MdiParent = this;
            ob.Show();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            Tbl_User aTbl_User = aUserBusiness.GetAllUserByUser(lblUserID.Text);
            lblUserLevel.Text = aTbl_User.UserType;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            if (MessageBox.Show("Do you want exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    notifyIcon1.Visible = true;
            //    this.Hide();
            //    e.Cancel = true;
            //}
        }

        private void newPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseForm aPurchaseForm = new PurchaseForm();
            aPurchaseForm.MdiParent = this;
            aPurchaseForm.Show();
        }

        private void employeeInformationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EmployeeForm ob = new EmployeeForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void districtEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistrictEntryForm ob = new DistrictEntryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrBill_Click(object sender, EventArgs e)
        {
            PurchaseForm ob = new PurchaseForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void countryEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountryForm ob = new CountryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void productListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductListForm pp = new ProductListForm();
            pp.MdiParent = this;
            pp.Show();
        }

        private void supplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierListReportForm pp = new SupplierListReportForm();
            pp.MdiParent = this;
            pp.Show();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListForm pp = new CustomerListForm();
            pp.MdiParent = this;
            pp.Show();
        }

        private void stockLevelReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockLevelReportsForm ob = new StockLevelReportsForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void emplolyeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeListForm ob = new EmployeeListForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SalesStockListForm ob = new SalesStockListForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSalesForm ob = new ProductSalesForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void returnPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnForm ob = new PurchaseReturnForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void productPurchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseInvoiceReportForm ob = new PurchaseInvoiceReportForm("");
            ob.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesInvoiceReportForm ob = new SalesInvoiceReportForm("");
            ob.Show();
        }

        private void dueReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SupplierDueReportForm ob = new SupplierDueReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void dueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDueReportForm ob = new CustomerDueReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void returnSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnForm ob = new SaleReturnForm();
            ob.MdiParent = this;
            ob.Show();
        }
      
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DamageEntryForm bo = new DamageEntryForm();
            bo.MdiParent = this;
            bo.Show();
        }

        private void cashAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashAccounts ob=new CashAccounts();
            ob.MdiParent = this;
            ob.Show();
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountSetting ob = new AccountSetting();
            ob.MdiParent = this;
            ob.Show();
        }

        private void todaySaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesReportForm ob = new TotalSalesReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void tbrTransaction_Click(object sender, EventArgs e)
        {
            CashAccounts ob = new CashAccounts();
            ob.MdiParent = this;
            ob.Show();
        }

        void Logout()
        {
            this.Hide();
            SplashForm frm = new SplashForm();
            frm.Show();
            frm.splashProgressBar.Visible = false;
            frm.lblUserID.Visible = true;
            frm.lblPassword.Visible = true;
            frm.txtUserID.Visible = true;
            frm.txtPassword.Visible = true;
            frm.vistaBtnExit.Visible = true;
            frm.btnLogin.Visible = true;
            frm.txtUserID.Focus();
        }

        private void tbrLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void toolStripButtonService_Click(object sender, EventArgs e)
        {
            ServiceSaleForm ob = new ServiceSaleForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void serviceSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceSaleForm ob = new ServiceSaleForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void cashViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashViewForm ob = new CashViewForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void employeeListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeListForm ob = new EmployeeListForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void bankStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankStatementReportForm ob = new BankStatementReportForm();
            ob.Show();
        }

        void Lock_System()
        {
            DialogResult rs = MessageBox.Show("Do you want to lock the system?", "Lock", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                LockerForm frm = new LockerForm();
                frm.Show();

                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void tbrLock_Click(object sender, EventArgs e)
        {
            Lock_System();
        }

        private void tbrBackup_Click(object sender, EventArgs e)
        {
            BackUpManagerForm ob = new BackUpManagerForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void ToolStripMenuItemLock_Click(object sender, EventArgs e)
        {
            Lock_System();
        }

        private void lblUserLevel_TextChanged(object sender, EventArgs e)
        {
            if (lblUserLevel.Text == "Admin")
            {
                Enable_Controls();
            }
            else if (lblUserLevel.Text == "User")
            {
                Disable_Controls();
            }
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpManagerForm ob = new BackUpManagerForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void reOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReorderListForm ob = new ReorderListForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnAllReports_Click(object sender, EventArgs e)
        {
            AllReportForm ob = new AllReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //label6.Text = DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString();
            label6.Text = System.DateTime.Now.ToString();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ServiceSaleForm ob = new ServiceSaleForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnPriceChart_Click(object sender, EventArgs e)
        {
            ProductListForm pp = new ProductListForm();
            pp.MdiParent = this;
            pp.Show();
        }

        private void btnTotalSale_Click(object sender, EventArgs e)
        {
            TotalSalesReportForm ob = new TotalSalesReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockLevelReportsForm ob = new StockLevelReportsForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            PurchaseInvoiceReportForm ob = new PurchaseInvoiceReportForm("");
            ob.Show();
        }

        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            SalesInvoiceReportForm ob = new SalesInvoiceReportForm("");
            ob.Show();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            CashAccounts ob = new CashAccounts();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ProductSalesForm ob = new ProductSalesForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnSaleReturn_Click(object sender, EventArgs e)
        {
            SaleReturnForm ob = new SaleReturnForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseForm aPurchaseForm = new PurchaseForm();
            aPurchaseForm.MdiParent = this;
            aPurchaseForm.Show();
        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            PurchaseReturnForm ob = new PurchaseReturnForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void expenseStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllReportForm ob = new AllReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void totalPurchaseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalPurchaseReportForm ob = new TotalPurchaseReportForm();
            ob.Show();
        }

        private void damageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageEntryForm ob = new DamageEntryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void purchaseStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseStockListForm ob = new PurchaseStockListForm();
            ob.MdiParent = this;
            ob.Show();
        }
        
        private void onlineSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.linktechbd.com");
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutusForm ob = new AboutusForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("Winword.exe");
        }

        

        private void damageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageProductReportForm ob = new DamageProductReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void addDistrictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistrictEntryForm ob = new DistrictEntryForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void profitLossStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitandLossForm ob = new ProfitandLossForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void btnTotalPurchase_Click(object sender, EventArgs e)
        {
            TotalPurchaseReportForm ob = new TotalPurchaseReportForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void resetSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ResetForm ob=new ResetForm();
            frmResetForm_Login ob = new frmResetForm_Login();
            ob.MdiParent=this;
            ob.Show();
        }

        private void exitCloseToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.notifyIcon1.Visible = false;
        }

        private void profitLossBySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitLossBySalesForm ob = new ProfitLossBySalesForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void databaseRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Utility\\DB_Restore_Manager.exe");
        }

        private void saleByBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSalesForm_Barcode ob = new ProductSalesForm_Barcode();
            ob.MdiParent = this;
            ob.Show();
        }

        private void dataImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataImport ob = new DataImport();
            ob.MdiParent = this;
            ob.Show();
        }

        private void salesInvoicewithDueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesInvoiceReport_WithDueForm ob = new SalesInvoiceReport_WithDueForm("","");
            //ob.MdiParent = this;
            ob.Show();
        }

        private void POS_SaletoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ProductSalesForm_exchange ob = new ProductSalesForm_exchange();
            ob.MdiParent = this;
            ob.Show();
        }

        private void SalesChallantoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SalesChallanForm ob = new SalesChallanForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductQuotationForm ob = new ProductQuotationForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void quotationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuotationListForm ob = new QuotationListForm();
            ob.MdiParent = this;
            ob.Show();
        }

        private void challanListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChallanListForm ob = new ChallanListForm();
            ob.MdiParent = this;
            ob.Show();
        }
    }
}
