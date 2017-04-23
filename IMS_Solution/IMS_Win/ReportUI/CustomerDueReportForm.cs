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
using Utility;

namespace IMS_Win
{
    public partial class CustomerDueReportForm : Form
    {
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        Qry_Customer aTbl_Customer = new Qry_Customer();
        SalesBusiness aSalesBusiness = new SalesBusiness();

        public CustomerDueReportForm()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                ReportViewerForm frm = new ReportViewerForm();
                Reports.CRCustomerDue rpt = new Reports.CRCustomerDue();
                Reports.CRCustomerWiseDue rptt = new Reports.CRCustomerWiseDue();

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
                if (cmbSearchType.Text == "All")
                {
                    List<Qry_CustomerDue> lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();

                    var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                    List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                    List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();

                    foreach (var g in groupdue)
                    {
                        Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                        lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                        lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();
                        aQry_CustomerDue.Customer_Code = g.Customer_Code;
                        aQry_CustomerDue.Customer_Name = g.Customer_Name;
                        aQry_CustomerDue.Customer_Address = g.Customer_Address;
                        aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                        aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                        lstGridList.Add(aQry_CustomerDue);
                    }

                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstGridList);
                    rpt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                //else
                //{
                //    List<Qry_CustomerDue> lstCustomerDueByCustomerList = aCustomerBusiness.GetAllQryCustomerDueByCustomer(aTbl_Customer.Customer_SlNo).Where(x => x.SaleMaster_DueAmount > 0).ToList();
                //    rptt.Subreports[0].SetDataSource(lstCompanyList);

                //    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstCustomerDueByCustomerList);
                //    rptt.SetDataSource(dt);
                //    frm.ReportViewer.ReportSource = rptt;
                //    frm.ShowDialog();
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            List<Qry_CustomerDue> lstCustomerDueList = new List<Qry_CustomerDue>();
            
            if (cmbSearchType.Text == "All")
            {
                SaleMaster_InvoiceNo.Visible = false;
                In_Amount.Visible = false;
                dgvCustomerDueList.AutoGenerateColumns = false;
                lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDue().Where(x => x.SaleMaster_DueAmount > 0).ToList();

                var groupdue = lstCustomerDueList.GroupBy(x => x.Customer_Code).Select(y => y.First()).ToList();

                List<Qry_CustomerDue> lstGridList = new List<Qry_CustomerDue>();
                List<Tbl_CashTransaction> lstCash = new List<Tbl_CashTransaction>();
                
                foreach (var g in groupdue)
                {
                    Qry_CustomerDue aQry_CustomerDue = new Qry_CustomerDue();

                    lstCash = aCashAccountBusiness.GetAllCashAccountByCustomer(g.Customer_SlNo);
                    lstCash = lstCash.Where(x => x.In_Amount > 0).ToList();
                    aQry_CustomerDue.Customer_Code = g.Customer_Code;
                    aQry_CustomerDue.Customer_Name = g.Customer_Name;
                    aQry_CustomerDue.Customer_Address = g.Customer_Address;
                    aQry_CustomerDue.Customer_Mobile = g.Customer_Mobile;
                    aQry_CustomerDue.SaleMaster_DueAmount = lstCustomerDueList.Where(y => y.Customer_Code == g.Customer_Code).Sum(z => z.SaleMaster_DueAmount) + lstCash.Sum(x => x.Out_Amount) - lstCash.Sum(x => x.In_Amount);

                    lstGridList.Add(aQry_CustomerDue);
                }
                dgvCustomerDueList.AutoGenerateColumns = false;
                dgvCustomerDueList.DataSource = null;
                dgvCustomerDueList.DataSource = lstGridList;


                int sum = 0;
                for (int i = 0; i < dgvCustomerDueList.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dgvCustomerDueList.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            //else
            //{
            //    SaleMaster_InvoiceNo.Visible = true;
            //    In_Amount.Visible = true;
            //    dgvCustomerDueList.AutoGenerateColumns = false;
            //    lstCustomerDueList = aCustomerBusiness.GetAllQryCustomerDueByCustomer(aTbl_Customer.Customer_SlNo).Where(x => x.SaleMaster_DueAmount > 0).ToList();
            //    dgvCustomerDueList.DataSource = null;
            //    dgvCustomerDueList.DataSource = lstCustomerDueList;

            //    int sumdue = 0;
            //    int sumpaid = 0;
            //    for (int i = 0; i < dgvCustomerDueList.Rows.Count; ++i)
            //    {
            //        sumdue += Convert.ToInt32(dgvCustomerDueList.Rows[i].Cells[4].Value);
            //        sumpaid += Convert.ToInt32(dgvCustomerDueList.Rows[i].Cells[5].Value);
            //    }
            //    txtTotal.Text = (sumdue - sumpaid).ToString();
            //}
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Single")
            {
                lblcode.Visible = true;
                lblname.Visible = true;
                txtCustomerCode.Visible = true;
                txtCustomerName.Visible = true;
                txtCustomerCode.Focus();
            }
            if (cmbSearchType.Text == "All")
            {
                lblcode.Visible = false;
                lblname.Visible = false;
                txtCustomerCode.Visible = false;
                txtCustomerName.Visible = false;
                customerListView.Visible = false;
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
            if (txtCustomerCode.Text != string.Empty)
            {
                GetCustomer();
            }
        }

        private void txtCustomerCode_Click(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void customerListView_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
            txtCustomerCode.Text = aTbl_Customer.Customer_Code;
            txtCustomerName.Text = aTbl_Customer.Customer_Name;
            customerListView.Visible = false;
            btnView.Focus();
        }

        private void CustomerDueReportForm_Load(object sender, EventArgs e)
        {

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

        private void customerListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                aTbl_Customer = (Qry_Customer)customerListView.SelectedItems[0].Tag;
                txtCustomerCode.Text = aTbl_Customer.Customer_Code;
                txtCustomerName.Text = aTbl_Customer.Customer_Name;
                customerListView.Visible = false;
                btnView.Focus();
            }
        }

        
    }
}
