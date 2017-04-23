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
    public partial class TotalSalesReportForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        SalesBusiness aSalesBusiness = new SalesBusiness();
        List<Qry_SalesMaster> lstSalesMasterList = new List<Qry_SalesMaster>();
        List<Qry_SaleReturnMasterDetails> lstQry_SaleReturnMasterDetails = new List<Qry_SaleReturnMasterDetails>();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        Qry_Customer aTbl_Customer = new Qry_Customer();
        Tbl_User aTbl_User = new Tbl_User();
        List<Qry_Customer> lstCustomerList = new List<Qry_Customer>();
        Qry_Product aTbl_Product = new Qry_Product();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        List<Qry_SaleMasterDetails> lstSalesMasterDetailsList = new List<Qry_SaleMasterDetails>();
        UserBusiness aUserBusiness = new UserBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        List<GetSaleMasterDetails> lstGetSaleMasterDetails = new List<GetSaleMasterDetails>();
        List<Get_SaleMaster> lstGet_SaleMaster = new List<Get_SaleMaster>();

        public TotalSalesReportForm()
        {
            InitializeComponent();
        }
        int selectedIndex = 0;


        #region SalesRecordByCustomer

        void LoadSaleByCustomer()
        {
            if (DateTime.Compare(dtpEnd.Value.Date, dtpStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }

            int totalvat = 0, totaldiscount = 0, totalamount = 0, totalpaid = 0, totaldue = 0;

            if (cmbSearchByCustomer.Text == "All")
            {
                clmCustomer_Code.Visible = true;
                clmCustomer_Name.Visible = true;
                dgvSalesRecordByInvoice.AutoGenerateColumns = false;

                lstGet_SaleMaster = aSalesBusiness.Get_AllSaleMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                //lstSalesMasterList = aSalesBusiness.GetAllQrySalesMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                if (lstGet_SaleMaster.Any())
                {
                    dgvSalesRecordByInvoice.DataSource = lstGet_SaleMaster;

                    for (int i = 0; i < dgvSalesRecordByInvoice.Rows.Count; ++i)
                    {
                        totalvat += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[5].Value);
                        totaldiscount += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[6].Value);
                        totalamount += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[7].Value);
                        totalpaid += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[8].Value);
                        totaldue += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[9].Value);
                    }

                    txtTotalVAT.Text = totalvat.ToString();
                    txtotalDiscount.Text = totaldiscount.ToString();
                    txtTotalAmountByInvoice.Text = totalamount.ToString();
                    txtTotalPaidByInvoice.Text = totalpaid.ToString();
                    txtTotaldueByInvoice.Text = totaldue.ToString();
                }
                else
                {
                    dgvSalesRecordByInvoice.DataSource = null;
                    txtTotalVAT.Text = "0";
                    txtotalDiscount.Text = "0";
                    txtTotalAmountByInvoice.Text = "0";
                    txtTotalPaidByInvoice.Text = "0";
                    txtTotaldueByInvoice.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
            else
            {
                clmCustomer_Code.Visible = false;
                clmCustomer_Name.Visible = false;
                dgvSalesRecordByInvoice.AutoGenerateColumns = false;

                lstSalesMasterList = aSalesBusiness.GetAllQrySalesMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date && x.Customer_Code == txtCustomerid.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();

                if (lstSalesMasterList.Any())
                {
                    dgvSalesRecordByInvoice.DataSource = lstSalesMasterList;

                    for (int i = 0; i < dgvSalesRecordByInvoice.Rows.Count; ++i)
                    {
                        totalvat += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[5].Value);
                        totaldiscount += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[6].Value);
                        totalamount += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[7].Value);
                        totalpaid += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[8].Value);
                        totaldue += Convert.ToInt32(dgvSalesRecordByInvoice.Rows[i].Cells[9].Value);
                    }

                    txtTotalVAT.Text = totalvat.ToString();
                    txtotalDiscount.Text = totaldiscount.ToString();
                    txtTotalAmountByInvoice.Text = totalamount.ToString();
                    txtTotalPaidByInvoice.Text = totalpaid.ToString();
                    txtTotaldueByInvoice.Text = totaldue.ToString();
                }
                else
                {
                    dgvSalesRecordByInvoice.DataSource = null;
                    txtTotalVAT.Text = "0";
                    txtotalDiscount.Text = "0";
                    txtTotalAmountByInvoice.Text = "0";
                    txtTotalPaidByInvoice.Text = "0";
                    txtTotaldueByInvoice.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
        }

        void ShowReportByCustomer()
        {
            if (DateTime.Compare(dtpEnd.Value.Date, dtpStart.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }

            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();

            Reports.CRTotalSales rpt = new Reports.CRTotalSales();
            Reports.CRTotalSalesCustomerWise rpt1 = new Reports.CRTotalSalesCustomerWise();
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

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "StartDate";
            objDiscreteValue.Value = dtpStart.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            objDiscreteValue = new ParameterDiscreteValue();
            objParameterField = new ParameterField();
            objParameterField.Name = "EndDate";
            objDiscreteValue.Value = dtpEnd.Value;
            objParameterField.CurrentValues.Add(objDiscreteValue);
            paramFields.Add(objParameterField);

            if (cmbSearchByCustomer.Text == "All")
            {
                lstGet_SaleMaster = aSalesBusiness.Get_AllSaleMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                //lstSalesMasterList = aSalesBusiness.GetAllQrySalesMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                if (lstGet_SaleMaster.Any())
                {
                    DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Get_SaleMaster>(lstGet_SaleMaster);
                    DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                    rpt.Subreports[0].SetDataSource(dt1);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvSalesRecordByInvoice.DataSource = null;
                    txtTotalVAT.Text = "0";
                    txtotalDiscount.Text = "0";
                    txtTotalAmountByInvoice.Text = "0";
                    txtTotalPaidByInvoice.Text = "0";
                    txtTotaldueByInvoice.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
            else
            {
                lstSalesMasterList = aSalesBusiness.GetAllQrySalesMaster().Where(x => x.SaleMaster_SaleDate >= dtpStart.Value.Date && x.SaleMaster_SaleDate <= dtpEnd.Value.Date && x.Customer_Code == txtCustomerid.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();

                if (lstSalesMasterList.Any())
                {
                    DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_SalesMaster>(lstSalesMasterList);
                    DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                    rpt1.Subreports[0].SetDataSource(dt1);
                    rpt1.SetDataSource(dt);

                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt1;
                    frm.ShowDialog();
                }
                else
                {
                    dgvSalesRecordByInvoice.DataSource = null;
                    txtTotalVAT.Text = "0";
                    txtotalDiscount.Text = "0";
                    txtTotalAmountByInvoice.Text = "0";
                    txtTotalPaidByInvoice.Text = "0";
                    txtTotaldueByInvoice.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
        }

        void GetCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtCustomerid.Text).ToList();

            listViewCustomer.Items.Clear();
            if (lstCustomerList.Any())
            {
                listViewCustomer.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    listViewCustomer.Items.Add(aListViewItem);
                }
            }
        }

        private void btnviewByInvoice_Click(object sender, EventArgs e)
        {
            LoadSaleByCustomer();
        }

        private void btnReportByInvoice_Click(object sender, EventArgs e)
        {
            ShowReportByCustomer();
        }

        private void TotalSalesReportForm_Load(object sender, EventArgs e)
        {
            //LoadSaleByCustomer();
            //LoadSaleByProduct();
        }

        private void cmbSearchByCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchByCustomer.Text == "All")
            {
                label2.Visible = false;
                label3.Visible = false;
                txtCustomerid.Visible = false;
                txtCustomer_name.Visible = false;
                listViewCustomer.Visible = false;
            }
            else
            {
                label2.Visible = true;
                label3.Visible = true;
                txtCustomerid.Visible = true;
                txtCustomer_name.Visible = true;
                txtCustomerid.Text = "";
                txtCustomer_name.Text = "";
                txtCustomerid.Focus();
            }
        }

        private void txtCustomerid_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerid.Text != string.Empty)
            {
                GetCustomer();
            }
        }

        private void txtCustomerid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewCustomer.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewCustomer.Focus();
            }
            else
            {
                GetCustomer();
            }
        }

        private void txtCustomerid_Click(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void listViewCustomer_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)listViewCustomer.SelectedItems[0].Tag;
            txtCustomerid.Text = aTbl_Customer.Customer_Code;
            txtCustomer_name.Text = aTbl_Customer.Customer_Name;
            listViewCustomer.Visible = false;
            btnviewByInvoice.Focus();
        }

        private void listViewCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Customer = (Qry_Customer)listViewCustomer.SelectedItems[0].Tag;
                txtCustomerid.Text = aTbl_Customer.Customer_Code;
                txtCustomer_name.Text = aTbl_Customer.Customer_Name;
                listViewCustomer.Visible = false;
                btnviewByInvoice.Focus();
            }
        }

        private void cmsSaleRecord_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                int id = lstGet_SaleMaster[selectedIndex].SaleMaster_SlNo;
                string invoiceNo = lstGet_SaleMaster[selectedIndex].SaleMaster_InvoiceNo;

                cmsSaleRecord.Visible = false;
                if (e.ClickedItem.Text == "Edit")
                {
                    var returninvoice = aSalesBusiness.GetAllSaleReturn(lstGet_SaleMaster[selectedIndex].SaleMaster_InvoiceNo);
                    if (returninvoice.Any())
                    {
                        MessageBox.Show("Invoice No:" + lstGet_SaleMaster[selectedIndex].SaleMaster_InvoiceNo + " is in use");
                        return;
                    }

                    ProductSalesForm ob = new ProductSalesForm();
                    ob.Text = "Edit Sales Product";
                    ob.BackColor = Color.LightGray;
                    ob.BackgroundImage = null;
                    ob.id = id;
                    ob.ShowDialog();
                    LoadSaleByCustomer();
                }
                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Tbl_SalesMaster aTbl_SalesMaster = aSalesBusiness.GetAllSalesMaster(id);
                        Tbl_CashRegister aTbl_CashRegister = aCashAccountBusiness.GetAllCashRegister(invoiceNo);

                        try
                        {
                            aTbl_SalesMaster.Status = "D";
                            aTbl_SalesMaster.UpdateBy = SplashForm.username;
                            aTbl_SalesMaster.UpdateTime = DateTime.UtcNow.AddHours(6);

                            //delete(status changed) from cash register table
                            aTbl_CashRegister.Status = "D";
                            aTbl_CashRegister.Edited_By = SplashForm.username;
                            aTbl_CashRegister.Edited_Time = DateTime.UtcNow.AddHours(6);

                            var detaillist = aSalesBusiness.GetAllSalesDetails(id);
                            List<Tbl_SaleDetails> lstUpdate = new List<Tbl_SaleDetails>();
                            List<Tbl_SaleInventory> lstUpdateSaleInventory = new List<Tbl_SaleInventory>();
                            List<Tbl_CurrentInventory> lstUpdateCurrentInventory = new List<Tbl_CurrentInventory>();
                            foreach (var div in detaillist)
                            {
                                var returninvoice = aSalesBusiness.GetAllSaleReturn(lstGet_SaleMaster[selectedIndex].SaleMaster_InvoiceNo);
                                if (returninvoice.Any())
                                {
                                    MessageBox.Show("Invoice No:" + lstGet_SaleMaster[selectedIndex].SaleMaster_InvoiceNo + " is in use");
                                    return;
                                }
                                var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                                var salesinventory = aSalesBusiness.GetAllSalesInventory(div.Product_SlNo);
                                if (currentinventory != null)
                                {
                                    currentinventory.CurrentInventory_CurrentQuantity += div.SaleDetails_TotalQuantity;
                                    if (currentinventory.CurrentInventory_CurrentQuantity < 0)
                                    {
                                        currentinventory.CurrentInventory_CurrentQuantity = 0;
                                    }
                                    lstUpdateCurrentInventory.Add(currentinventory);
                                }
                                if (salesinventory != null)
                                {
                                    salesinventory.SaleInventory_TotalQuantity -= div.SaleDetails_TotalQuantity;
                                    if (salesinventory.SaleInventory_TotalQuantity < 0)
                                    {
                                        salesinventory.SaleInventory_TotalQuantity = 0;
                                    }
                                    lstUpdateSaleInventory.Add(salesinventory);
                                }
                                div.Status = "D";
                                div.UpdateBy = SplashForm.username;
                                div.UpdateTime = DateTime.UtcNow.AddHours(6);
                                lstUpdate.Add(div);
                            }

                            aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstUpdateCurrentInventory);
                            aSalesBusiness.InsertorUpdateSalesInventory(lstUpdateSaleInventory);
                            aSalesBusiness.UpdateSalesDetail(lstUpdate);
                            aSalesBusiness.UpdateSalesMaster(aTbl_SalesMaster);
                            aCashAccountBusiness.UpdateCashRegister(aTbl_CashRegister);

                            LoadSaleByCustomer();
                            UtilityBusiness.DisplayAlertMessage('S', "Deleted Successfully");

                        }
                        catch (Exception ex)
                        {
                            UtilityBusiness.DisplayAlertMessage('E', ex.Message);
                        }
                        finally
                        {
                            aTbl_SalesMaster = null;
                            aTbl_CashRegister = null;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvSalesRecordByInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstGet_SaleMaster.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsSaleRecord.Visible = true;
                    cmsSaleRecord.Items.Clear();
                    cmsSaleRecord.Items.Add("Edit");
                    cmsSaleRecord.Items.Add("Delete");
                    cmsSaleRecord.Show(dgvSalesRecordByInvoice, new Point(e.X, e.Y));
                }
            }
        }

        private void dgvSalesRecordByInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex; ;
        }

        #endregion

        #region SalesRecordByProduct

        void GetProduct()
        {
            List<Qry_Product> lstProductList = aProductBusiness.GetAllQryProductByCode(txtProductid.Text).Where(x => x.Product_IsFinishedGoods == true).ToList();
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

        void LoadSaleByProduct()
        {
            List<Qry_SaleMasterDetails> lstSaleMasterDetailsList = new List<Qry_SaleMasterDetails>();

            if (DateTime.Compare(dtpEndDate.Value.Date, dtpStartDate.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }
            if (cmbSearchByProduct.Text == "All")
            {
                label17.Visible = false;
                labelunitname.Visible = false;
                txtTotalSalesQty.Visible = false;
                clmSaleMaster_SaleDate.Visible = false;

                lstSaleMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleDetails_TotalQuantity > 0 && x.SaleMaster_SaleDate >= dtpStartDate.Value.Date && x.SaleMaster_SaleDate <= dtpEndDate.Value.Date).OrderBy(x => x.ProductCategory_Name).OrderBy(x => x.Product_Name).ToList();

                var groupSale = lstSaleMasterDetailsList.GroupBy(x => x.Product_Code).Select(y => y.First()).ToList();

                List<Qry_SaleMasterDetails> lstQry_SaleMasterDetailsGridList = new List<Qry_SaleMasterDetails>();

                foreach (var g in groupSale)
                {
                    Qry_SaleMasterDetails aQry_SaleMasterDetails = new Qry_SaleMasterDetails();

                    aQry_SaleMasterDetails.Product_Code = g.Product_Code;
                    aQry_SaleMasterDetails.Product_Name = g.Product_Name;
                    aQry_SaleMasterDetails.ProductCategory_Name = g.ProductCategory_Name;
                    aQry_SaleMasterDetails.SaleDetails_TotalQuantity = lstSaleMasterDetailsList.Where(y => y.Product_Code == g.Product_Code).Sum(z => z.SaleDetails_TotalQuantity);
                    aQry_SaleMasterDetails.Unit_Name = g.Unit_Name;

                    lstQry_SaleMasterDetailsGridList.Add(aQry_SaleMasterDetails);
                }

                dgvSaleProductWise.AutoGenerateColumns = false;
                dgvSaleProductWise.DataSource = null;
                dgvSaleProductWise.DataSource = lstQry_SaleMasterDetailsGridList;

                //int sum = 0;
                //for (int i = 0; i < dgvSaleProductWise.Rows.Count; ++i)
                //{
                //    sum += Convert.ToInt32(dgvSaleProductWise.Rows[i].Cells[4].Value);
                //}
                //txtTotalSalesQty.Text = sum.ToString();
            }
            else
            {
                label17.Visible = true;
                labelunitname.Visible = true;
                txtTotalSalesQty.Visible = true;
                clmSaleMaster_SaleDate.Visible = true;
                dgvSaleProductWise.AutoGenerateColumns = false;

                lstSaleMasterDetailsList = aSalesBusiness.GetAllSaleMasterDetails(txtProductid.Text).Where(x => x.SaleDetails_TotalQuantity > 0 && x.SaleMaster_SaleDate >= dtpStartDate.Value.Date && x.SaleMaster_SaleDate <= dtpEndDate.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                if (lstSaleMasterDetailsList.Any())
                {
                    dgvSaleProductWise.DataSource = null;
                    dgvSaleProductWise.DataSource = lstSaleMasterDetailsList;

                    int sum = 0;
                    for (int i = 0; i < dgvSaleProductWise.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvSaleProductWise.Rows[i].Cells[4].Value);
                    }
                    txtTotalSalesQty.Text = sum.ToString();

                    labelunitname.Text = aTbl_Product.Unit_Name;
                }
                else
                {
                    dgvSaleProductWise.DataSource = null;
                    labelunitname.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }

            }
        }

        private void btnViewByProduct_Click(object sender, EventArgs e)
        {
            LoadSaleByProduct();
        }

        void ReportByProduct()
        {
            try
            {
                if (DateTime.Compare(dtpEndDate.Value.Date, dtpStartDate.Value.Date) < 0)
                {
                    MessageBox.Show("to date must be equal or greater than from date");
                    return;
                }

                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                List<Qry_SaleMasterDetails> lstSaleMasterDetailsList = new List<Qry_SaleMasterDetails>();

                ReportViewerForm frm = new ReportViewerForm();
                Reports.CRTotalSalesProductWise rpt = new Reports.CRTotalSalesProductWise();
                Reports.CRTotalSalesSingleProductWise rptt = new Reports.CRTotalSalesSingleProductWise();

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "StartDate";
                objDiscreteValue.Value = dtpStartDate.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "EndDate";
                objDiscreteValue.Value = dtpEndDate.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                frm.ReportViewer.ParameterFieldInfo = paramFields;

                if (cmbSearchByProduct.Text == "All")
                {
                    lstSaleMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleDetails_TotalQuantity > 0 && x.SaleMaster_SaleDate >= dtpStartDate.Value.Date && x.SaleMaster_SaleDate <= dtpEndDate.Value.Date).OrderBy(x => x.ProductCategory_Name).OrderBy(x => x.Product_Name).ToList();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    var groupSale = lstSaleMasterDetailsList.GroupBy(x => x.Product_Code).Select(y => y.First()).ToList();

                    List<Qry_SaleMasterDetails> lstQry_SaleMasterDetailsGridList = new List<Qry_SaleMasterDetails>();

                    foreach (var g in groupSale)
                    {
                        Qry_SaleMasterDetails aQry_SaleMasterDetails = new Qry_SaleMasterDetails();

                        aQry_SaleMasterDetails.Product_Code = g.Product_Code;
                        aQry_SaleMasterDetails.Product_Name = g.Product_Name;
                        aQry_SaleMasterDetails.ProductCategory_Name = g.ProductCategory_Name;
                        aQry_SaleMasterDetails.SaleDetails_TotalQuantity = lstSaleMasterDetailsList.Where(y => y.Product_Code == g.Product_Code).Sum(z => z.SaleDetails_TotalQuantity);
                        aQry_SaleMasterDetails.Unit_Name = g.Unit_Name;
                        lstQry_SaleMasterDetailsGridList.Add(aQry_SaleMasterDetails);
                    }

                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstQry_SaleMasterDetailsGridList);
                    rpt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    lstSaleMasterDetailsList = aSalesBusiness.GetAllSaleMasterDetails(txtProductid.Text).Where(x => x.SaleDetails_TotalQuantity > 0 && x.SaleMaster_SaleDate >= dtpStartDate.Value.Date && x.SaleMaster_SaleDate <= dtpEndDate.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();
                    if (lstSaleMasterDetailsList.Any())
                    {
                        rptt.Subreports[0].SetDataSource(lstCompanyList);
                        DataTable dt = UtilityBusiness.GenericListToDataTable1(lstSaleMasterDetailsList);
                        rptt.SetDataSource(dt);
                        frm.ReportViewer.ReportSource = rptt;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvSaleProductWise.DataSource = null;
                        labelunitname.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReportByProduct_Click(object sender, EventArgs e)
        {
            ReportByProduct();
        }

        private void txtProductid_Click(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void txtProductid_TextChanged(object sender, EventArgs e)
        {
            if (txtProductid.Text != string.Empty)
            {
                GetProduct();
            }
        }

        private void txtProductid_KeyDown(object sender, KeyEventArgs e)
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

        private void productListView_Click(object sender, EventArgs e)
        {
            aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

            txtProductid.Text = aTbl_Product.Product_Code;
            txtProductName.Text = aTbl_Product.Product_Name;
            productListView.Visible = false;
            btnViewByProduct.Focus();
        }

        private void productListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                    txtProductid.Text = aTbl_Product.Product_Code;
                    txtProductName.Text = aTbl_Product.Product_Name;
                    productListView.Visible = false;
                    btnViewByProduct.Focus();
                }
            }
            catch
            {
            }
        }

        private void cmbSearchByProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchByProduct.Text == "All")
            {
                label7.Visible = false;
                label8.Visible = false;
                txtProductid.Visible = false;
                txtProductName.Visible = false;
                productListView.Visible = false;
            }
            else
            {
                label7.Visible = true;
                label8.Visible = true;
                txtProductid.Visible = true;
                txtProductName.Visible = true;
                txtProductid.Text = "";
                txtProductName.Text = "";
                txtProductid.Focus();
            }
        }

        #endregion

        #region ProductSalesRecord

        private void btnProductSaleView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Compare(dtpproductsaleto.Value.Date, dtpproductsalefrom.Value.Date) < 0)
                {
                    MessageBox.Show("To Date must be equal or greater than from date");
                    return;
                }
                if (cmbProductSale.Text == "All")
                {
                    clmSaleCustomerID.Visible = true;
                    clmSaleCustomerName.Visible = true;
                    clmAddby.Visible = true;

                    dgvProductSale.AutoGenerateColumns = false;
                    lstGetSaleMasterDetails = aSalesBusiness.GetAllSaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    //lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                    if (lstGetSaleMasterDetails.Any())
                    {
                        dgvProductSale.DataSource = lstGetSaleMasterDetails;

                        decimal totalsale = 0;
                        for (int i = 0; i < dgvProductSale.Rows.Count; ++i)
                        {
                            totalsale += Convert.ToInt32(dgvProductSale.Rows[i].Cells[8].Value);
                        }
                        lblTotalSale.Text = Math.Round(totalsale, 2).ToString();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else if (cmbProductSale.Text == "Select Customer")
                {
                    clmSaleCustomerID.Visible = false;
                    clmSaleCustomerName.Visible = false;
                    clmAddby.Visible = true;

                    dgvProductSale.AutoGenerateColumns = false;
                    lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.Customer_Code == txtsalebyCustomerID.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    if (lstSalesMasterDetailsList.Any())
                    {
                        dgvProductSale.DataSource = lstSalesMasterDetailsList;

                        decimal totalsale = 0;
                        for (int i = 0; i < dgvProductSale.Rows.Count; ++i)
                        {
                            totalsale += Convert.ToInt32(dgvProductSale.Rows[i].Cells[8].Value);
                        }
                        lblTotalSale.Text = Math.Round(totalsale, 2).ToString();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else if (cmbProductSale.Text == "Select User")
                {
                    clmSaleCustomerID.Visible = true;
                    clmSaleCustomerName.Visible = true;
                    clmAddby.Visible = false;

                    dgvProductSale.AutoGenerateColumns = false;
                    lstGetSaleMasterDetails = aSalesBusiness.GetAllSaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.AddBy == txtUserID.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    //lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.AddBy == txtUserID.Text).OrderBy(x => x.SaleMaster_SaleDate).ToList();
                    
                    if (lstGetSaleMasterDetails.Any())
                    {
                        dgvProductSale.DataSource = lstGetSaleMasterDetails;

                        decimal totalsale = 0;
                        for (int i = 0; i < dgvProductSale.Rows.Count; ++i)
                        {
                            totalsale += Convert.ToInt32(dgvProductSale.Rows[i].Cells[8].Value);
                        }
                        lblTotalSale.Text = Math.Round(totalsale, 2).ToString();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
            }
            catch
            {
            }
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();

                Reports.CRProductSaleReportByAllCustomer rpt = new Reports.CRProductSaleReportByAllCustomer();
                Reports.CRProductSaleReportByCustomer rpt1 = new Reports.CRProductSaleReportByCustomer();
                Reports.CRProductSaleReportByUser rpt2 = new Reports.CRProductSaleReportByUser();

                rpt.Subreports[0].SetDataSource(lstCompanyList);
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

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "StartDate";
                objDiscreteValue.Value = dtpproductsalefrom.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "EndDate";
                objDiscreteValue.Value = dtpproductsaleto.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                if (cmbProductSale.Text == "All")
                {
                    lstGetSaleMasterDetails = aSalesBusiness.GetAllSaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    //lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                    if (lstGetSaleMasterDetails.Any())
                    {
                        DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<GetSaleMasterDetails>(lstGetSaleMasterDetails);
                        DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                        rpt.Subreports[0].SetDataSource(dt1);
                        rpt.SetDataSource(dt);

                        frm.ReportViewer.ParameterFieldInfo = paramFields;
                        frm.ReportViewer.ReportSource = rpt;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else if (cmbProductSale.Text == "Select Customer")
                {
                    lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.Customer_Code == txtsalebyCustomerID.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    if (lstSalesMasterDetailsList.Any())
                    {
                        DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_SaleMasterDetails>(lstSalesMasterDetailsList);
                        DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                        rpt1.Subreports[0].SetDataSource(dt1);
                        rpt1.SetDataSource(dt);

                        frm.ReportViewer.ParameterFieldInfo = paramFields;
                        frm.ReportViewer.ReportSource = rpt1;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else if (cmbProductSale.Text == "Select User")
                {
                    lstGetSaleMasterDetails = aSalesBusiness.GetAllSaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.AddBy == txtUserID.Text).OrderBy(x => x.SaleMaster_SaleDate).OrderBy(y => y.SaleMaster_InvoiceNo).ToList();
                    //lstSalesMasterDetailsList = aSalesBusiness.GetAllQrySaleMasterDetails().Where(x => x.SaleMaster_SaleDate >= dtpproductsalefrom.Value.Date && x.SaleMaster_SaleDate <= dtpproductsaleto.Value.Date && x.AddBy == txtUserID.Text).OrderBy(x => x.SaleMaster_SaleDate).ToList();
                    if (lstGetSaleMasterDetails.Any())
                    {
                        DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<GetSaleMasterDetails>(lstGetSaleMasterDetails);
                        DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                        rpt2.Subreports[0].SetDataSource(dt1);
                        rpt2.SetDataSource(dt);

                        frm.ReportViewer.ParameterFieldInfo = paramFields;
                        frm.ReportViewer.ReportSource = rpt2;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvProductSale.DataSource = null;
                        lblTotalSale.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProductSaleReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        #endregion

        private void cmbProductSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductSale.Text == "All")
            {
                label18.Visible = false;
                label19.Visible = false;
                txtsalebyCustomerID.Visible = false;
                txtSaleCustomerName.Visible = false;
                listViewCustomerList.Visible = false;

                label28.Visible = false;
                label26.Visible = false;
                txtUserID.Visible = false;
                txtUserName.Visible = false;
                listViewUser.Visible = false;
            }
            else if (cmbProductSale.Text == "Select Customer")
            {
                label18.Visible = true;
                label19.Visible = true;
                txtsalebyCustomerID.Visible = true;
                txtSaleCustomerName.Visible = true;
                txtsalebyCustomerID.Text = "";
                txtSaleCustomerName.Text = "";
                txtsalebyCustomerID.Focus();

                label28.Visible = false;
                label26.Visible = false;
                txtUserID.Visible = false;
                txtUserName.Visible = false;
                listViewUser.Visible = false;
            }
            else if (cmbProductSale.Text == "Select User")
            {
                label18.Visible = false;
                label19.Visible = false;
                txtsalebyCustomerID.Visible = false;
                txtSaleCustomerName.Visible = false;
                listViewCustomerList.Visible = false;

                label28.Visible = true;
                label26.Visible = true;
                txtUserID.Visible = true;
                txtUserName.Visible = true;
                txtUserID.Text = "";
                txtUserName.Text = "";
                txtUserID.Focus();
            }
        }

        void GetSaleCustomer()
        {
            List<Qry_Customer> lstCustomerList = aCustomerBusiness.GetAllCustomerbyCode(txtsalebyCustomerID.Text).ToList();

            listViewCustomerList.Items.Clear();
            if (lstCustomerList.Any())
            {
                listViewCustomerList.Visible = true;

                foreach (Qry_Customer aCustomer in lstCustomerList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aCustomer;
                    aListViewItem.Text = aCustomer.Customer_Code;
                    aListViewItem.SubItems.Add(aCustomer.Customer_Name);
                    aListViewItem.SubItems.Add(aCustomer.Customer_Address);

                    listViewCustomerList.Items.Add(aListViewItem);
                }
            }
        }

        void GetUser()
        {
            List<Tbl_User> lstUserList = aUserBusiness.GetAllUserByUserId(txtUserID.Text).ToList();

            listViewUser.Items.Clear();
            if (lstUserList.Any())
            {
                listViewUser.Visible = true;

                foreach (Tbl_User aUser in lstUserList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aUser;
                    aListViewItem.Text = aUser.User_ID;
                    aListViewItem.SubItems.Add(aUser.User_Name);
                    aListViewItem.SubItems.Add(aUser.UserType);

                    listViewUser.Items.Add(aListViewItem);
                }
            }
        }

        private void txtsalebyCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerid.Text != string.Empty)
            {
                GetSaleCustomer();
            }
        }

        private void txtsalebyCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewCustomerList.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewCustomerList.Focus();
            }
            else
            {
                GetSaleCustomer();
            }
        }

        private void txtsalebyCustomerID_Click(object sender, EventArgs e)
        {
            GetSaleCustomer();
        }

        private void listViewCustomerList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Customer = (Qry_Customer)listViewCustomerList.SelectedItems[0].Tag;
                txtsalebyCustomerID.Text = aTbl_Customer.Customer_Code;
                txtSaleCustomerName.Text = aTbl_Customer.Customer_Name;
                listViewCustomerList.Visible = false;
                btnProductSaleView.Focus();
            }
        }

        private void listViewCustomerList_Click(object sender, EventArgs e)
        {
            aTbl_Customer = (Qry_Customer)listViewCustomerList.SelectedItems[0].Tag;
            txtsalebyCustomerID.Text = aTbl_Customer.Customer_Code;
            txtSaleCustomerName.Text = aTbl_Customer.Customer_Name;
            listViewCustomerList.Visible = false;
            btnProductSaleView.Focus();
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (txtUserID.Text != string.Empty)
            {
                GetUser();
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewUser.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewUser.Focus();
            }
            else
            {
                GetUser();
            }
        }

        private void txtUserID_Click(object sender, EventArgs e)
        {
            GetUser();
        }

        private void listViewUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_User = (Tbl_User)listViewUser.SelectedItems[0].Tag;
                txtUserID.Text = aTbl_User.User_ID;
                txtUserName.Text = aTbl_User.User_Name;
                listViewUser.Visible = false;
                btnProductSaleView.Focus();
            }
        }

        private void listViewUser_Click(object sender, EventArgs e)
        {
            aTbl_User = (Tbl_User)listViewUser.SelectedItems[0].Tag;
            txtUserID.Text = aTbl_User.User_ID;
            txtUserName.Text = aTbl_User.User_Name;
            listViewUser.Visible = false;
            btnProductSaleView.Focus();
        }


        #region Product SalesReturn List

        private void btnReturnList_Click(object sender, EventArgs e)
        {
            List<Qry_SaleReturnMasterDetails> lstReturnList = aSalesBusiness.GetAllSaleReturnMasterDetails().Where(x => x.SaleReturn_ReturnDate >= dtpReturnFrom.Value.Date && x.SaleReturn_ReturnDate <= dtpReturnTo.Value.Date).OrderBy(x => x.SaleReturn_ReturnDate).ToList();

            if (DateTime.Compare(dtpReturnTo.Value.Date, dtpReturnFrom.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }

            if (lstReturnList.Any())
            {
                dgvSaleRetrunList.AutoGenerateColumns = false;
                dgvSaleRetrunList.DataSource = null;
                dgvSaleRetrunList.DataSource = lstReturnList;

                decimal totalSaleReturn = 0;
                for (int i = 0; i < dgvSaleRetrunList.Rows.Count; ++i)
                {
                    totalSaleReturn += Convert.ToInt32(dgvSaleRetrunList.Rows[i].Cells[7].Value);
                }
                lblTotalSaleReturnAmt.Text = Math.Round(totalSaleReturn, 2).ToString();
            }
            else
            {
                dgvSaleRetrunList.DataSource = null;
                lblTotalSaleReturnAmt.Text = "0";
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        private void btnRetrunReport_Click(object sender, EventArgs e)
        {
            lstQry_SaleReturnMasterDetails = aSalesBusiness.GetAllSaleReturnMasterDetails().Where(x => x.SaleReturn_ReturnDate >= dtpReturnFrom.Value.Date && x.SaleReturn_ReturnDate <= dtpReturnTo.Value.Date).OrderBy(x => x.SaleReturn_ReturnDate).ToList();

            if (DateTime.Compare(dtpReturnTo.Value.Date, dtpReturnFrom.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }

            if (lstQry_SaleReturnMasterDetails.Any())
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                Reports.CRSalesReturnProduct rpt = new Reports.CRSalesReturnProduct();
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

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "StartDate";
                objDiscreteValue.Value = dtpStart.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "EndDate";
                objDiscreteValue.Value = dtpEnd.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);


                DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_SaleReturnMasterDetails>(lstQry_SaleReturnMasterDetails);
                DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                rpt.Subreports[0].SetDataSource(dt1);
                rpt.SetDataSource(dt);

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            else
            {
                dgvSaleRetrunList.DataSource = null;
                lblTotalSaleReturnAmt.Text = "0";
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        #endregion


    }
}
