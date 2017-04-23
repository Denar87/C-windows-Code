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
    public partial class SalesInvoiceReport_WithDueForm : Form
    {
        SalesBusiness aSalesBusiness = new SalesBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        Tbl_SalesMaster aSaleMaster = new Tbl_SalesMaster();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        Qry_Customer aTbl_Customer = new Qry_Customer();

        public SalesInvoiceReport_WithDueForm(string voucherId,string customerCode)
        {
            InitializeComponent();
            txtInvoiceNo.Text = voucherId;
            //lblCustomerCode.Text = customerCode;
            txtCustomerCode.Text = customerCode;
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

        void ShowReport()
        {
            Tbl_Company aTbl_Company = aCompanyBusiness.GetAllCompanyByInvoiceType();
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            //List<Qry_SalesInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllQrySalesInvoiceByInvoice(txtInvoiceNo.Text);
            List<Get_SaleInvoice> lstSalesInvoiceList = aSalesBusiness.GetAllSalesInvoiceByInvoice(txtInvoiceNo.Text);

            DataTable dt = UtilityBusiness.GenericListToDataTable1<Get_SaleInvoice>(lstSalesInvoiceList);

            // count customer current previous due
            decimal Total_Due;
            decimal due = 0;
            decimal payment = 0;
            decimal paytoCustomer = 0;

            List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDueByCustomerCode(txtCustomerCode.Text).ToList();
            if (lstCustomerDueList.Any())
            {
                due = lstCustomerDueList.Sum(x => x.SaleMaster_DueAmount);
            }

            List<Qry_CustomerPayment> lstCustomerPayment = aCashAccountBusiness.GetAllCashAccountByCustomerID(txtCustomerCode.Text);
            if (lstCustomerPayment.Any())
            {
                payment = lstCustomerPayment.Sum(x => x.In_Amount);
                paytoCustomer = lstCustomerPayment.Sum(x => x.Out_Amount);
            }

            Total_Due = (due + paytoCustomer) - payment;

            // for A4 size Printing
            if (aTbl_Company.Invoice_Type == 1)
            {
                Reports.CRSalesInvoice rpt = new Reports.CRSalesInvoice();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "@LoggedUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }

            // for half of A4 size print
            else if (aTbl_Company.Invoice_Type == 2)
            {
                Reports.CRSalesInvoice_halfA4 rpt = new Reports.CRSalesInvoice_halfA4();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "@LoggedUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }

            //for a4 size invoice with customer due
            else if (aTbl_Company.Invoice_Type == 3)
            {
                Reports.CRSalesInvoiceWithDue rpt = new Reports.CRSalesInvoiceWithDue();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "@LoggedUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "TotalDue";
                objDiscreteValue.Value = Total_Due;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }

            //for half of a4 size invoice with customer due 
            else if (aTbl_Company.Invoice_Type == 4)
            {
                Reports.CRSalesInvoice_halfA4_WithDue rpt = new Reports.CRSalesInvoice_halfA4_WithDue();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "@LoggedUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "TotalDue";
                objDiscreteValue.Value = Total_Due;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }

            //for half of a4 right size invoice with customer due 
            else if (aTbl_Company.Invoice_Type == 6)
            {
                Reports.CRSalesInvoice_halfA4_WithDue_Right rpt = new Reports.CRSalesInvoice_halfA4_WithDue_Right();
                rpt.Subreports[0].SetDataSource(lstCompanyList);
                rpt.SetDataSource(dt);

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "@LoggedUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "TotalDue";
                objDiscreteValue.Value = Total_Due;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = rpt;
            }

            // for POS Printer
            else if (aTbl_Company.Invoice_Type == 0)
            {
                Reports.CRSaleInvoiceForPOS rpt = new Reports.CRSaleInvoiceForPOS();
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        private void SalesInvoiceReportForm_Load(object sender, EventArgs e)
        {
            ShowReport();
            GetInvoiceNoToListBox();
            txtInvoiceNo.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox1.Visible = true;
            }
        }

        private void txtInvoiceNo_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceNo.Text = listBox1.Text.ToString();
                listBox1.Visible = false;
                btnShow.Focus();
            }
            catch
            {
                MessageBox.Show("Please Select any Invoice!");
            }

        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
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

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtInvoiceNo.Text = listBox1.Text.ToString();
                    listBox1.Visible = false;
                    btnShow.Focus();
                }
                catch
                {
                    MessageBox.Show("Please Select any Invoice!");
                }
            }
        }

        void GetCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtCustomerCode.Text);

            customerListView.Items.Clear();
            if (lstCustomerList.Any())
            {
                customerListView.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    customerListView.Items.Add(aListViewItem);
                }

            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            //if (txtCustomerCode.Text != string.Empty)
            //{
            //    GetCustomer();
            //}
        }

        private void txtCustomerCode_Click(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                customerListView.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                customerListView.Focus();
            }
            else
            {
                GetCustomer();
            }
        }

        private void customerListView_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
            txtCustomerCode.Text = aTbl_Customer.Customer_Code;
            //txtCustomerName.Text = aTbl_Customer.Customer_Name;
            customerListView.Visible = false;
            //btnView.Focus();
        }

        private void customerListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
                txtCustomerCode.Text = aTbl_Customer.Customer_Code;
                //txtCustomerName.Text = aTbl_Customer.Customer_Name;
                customerListView.Visible = false;
                //btnView.Focus();
            }
        }


    }
}
