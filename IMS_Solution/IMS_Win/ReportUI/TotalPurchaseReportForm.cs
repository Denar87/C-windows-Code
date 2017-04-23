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
    public partial class TotalPurchaseReportForm : Form
    {
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        List<Qry_PurchaseMaster> lstPurchaseMasterList = new List<Qry_PurchaseMaster>();
        List<Qry_PurchaseDetails> lstPruductList = new List<Qry_PurchaseDetails>();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        Qry_Product aTbl_Product = new Qry_Product();
        Qry_Supplier aTbl_Suplier = new Qry_Supplier();
        List<Qry_Supplier> lstSupplierList = new List<Qry_Supplier>();
        List<Qry_PurchaseMasterDetails> lstPurchaseMasterDetailsList = new List<Qry_PurchaseMasterDetails>();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        List<Qry_PurchaseReturnMasterDetails> lstQry_PurchaseReturnMasterDetails = new List<Qry_PurchaseReturnMasterDetails>();

        public TotalPurchaseReportForm()
        {
            InitializeComponent();
        }

        int selectedIndex = 0;

        #region PurchaseRecordBySupplier

        void LoadPurchaseBySupplier()
        {
            if (DateTime.Compare(dtpEnd.Value.Date, dtpStart.Value.Date) < 0)
            {
                MessageBox.Show("to Date must be equal or greater than from date");
                return;
            }
            if (cmbSearchBySupplier.Text == "All")
            {
                clmSupplier_Code.Visible = true;
                clmSupplier_Name.Visible = true;
                dgvPurchaseRecordBySupplier.AutoGenerateColumns = false;
                lstPurchaseMasterList = aPurchaseBusiness.GetAllQryPurchaseMaster().Where(x => x.PurchaseMaster_OrderDate >= dtpStart.Value.Date && x.PurchaseMaster_OrderDate <= dtpEnd.Value.Date).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();

                if (lstPurchaseMasterList.Any())
                {
                    dgvPurchaseRecordBySupplier.DataSource = lstPurchaseMasterList;

                    int totalamount = 0, totalpaid = 0, totaldue = 0;
                    for (int i = 0; i < dgvPurchaseRecordBySupplier.Rows.Count; ++i)
                    {
                        totalamount += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[6].Value);
                        totalpaid += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[7].Value);
                        totaldue += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[8].Value);
                    }
                    txtTotalAmountBySupplier.Text = totalamount.ToString();
                    txtTotalPaidBySupplier.Text = totalpaid.ToString();
                    txtTotaldueBySupplier.Text = totaldue.ToString();
                }
                else
                {
                    dgvPurchaseRecordBySupplier.DataSource = null;
                    txtTotalAmountBySupplier.Text = "0";
                    txtTotalPaidBySupplier.Text = "0";
                    txtTotaldueBySupplier.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
            else
            {
                clmSupplier_Code.Visible = false;
                clmSupplier_Name.Visible = false;
                dgvPurchaseRecordBySupplier.AutoGenerateColumns = false;
                lstPurchaseMasterList = aPurchaseBusiness.GetAllQryPurchaseMaster().Where(x => x.PurchaseMaster_OrderDate >= dtpStart.Value.Date && x.PurchaseMaster_OrderDate <= dtpEnd.Value.Date && x.Supplier_Code == txtSupplierid.Text).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();

                if (lstPurchaseMasterList.Any())
                {
                    dgvPurchaseRecordBySupplier.DataSource = lstPurchaseMasterList;

                    int totalamount = 0, totalpaid = 0, totaldue = 0;
                    for (int i = 0; i < dgvPurchaseRecordBySupplier.Rows.Count; ++i)
                    {
                        totalamount += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[6].Value);
                        totalpaid += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[7].Value);
                        totaldue += Convert.ToInt32(dgvPurchaseRecordBySupplier.Rows[i].Cells[8].Value);
                    }
                    txtTotalAmountBySupplier.Text = totalamount.ToString();
                    txtTotalPaidBySupplier.Text = totalpaid.ToString();
                    txtTotaldueBySupplier.Text = totaldue.ToString();
                }
                else
                {
                    dgvPurchaseRecordBySupplier.DataSource = null;
                    txtTotalAmountBySupplier.Text = "0";
                    txtTotalPaidBySupplier.Text = "0";
                    txtTotaldueBySupplier.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
        }

        void ShowReportBySupplier()
        {
            if (DateTime.Compare(dtpEnd.Value.Date, dtpStart.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }
            List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
            Reports.CRTotalPurchase rpt = new Reports.CRTotalPurchase();
            Reports.CRTotalPurchaseSupplierWise rpt1 = new Reports.CRTotalPurchaseSupplierWise();
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

            if (cmbSearchBySupplier.Text == "All")
            {
                lstPurchaseMasterList = aPurchaseBusiness.GetAllQryPurchaseMaster().Where(x => x.PurchaseMaster_OrderDate >= dtpStart.Value.Date && x.PurchaseMaster_OrderDate <= dtpEnd.Value.Date).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();
                if (lstPurchaseMasterList.Any())
                {
                    DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseMaster>(lstPurchaseMasterList);
                    DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                    rpt.Subreports[0].SetDataSource(dt1);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    dgvPurchaseRecordBySupplier.DataSource = null;
                    txtTotalAmountBySupplier.Text = "0";
                    txtTotalPaidBySupplier.Text = "0";
                    txtTotaldueBySupplier.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
            else
            {
                lstPurchaseMasterList = aPurchaseBusiness.GetAllQryPurchaseMaster().Where(x => x.PurchaseMaster_OrderDate >= dtpStart.Value.Date && x.PurchaseMaster_OrderDate <= dtpEnd.Value.Date && x.Supplier_Code == txtSupplierid.Text).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();
                if (lstPurchaseMasterList.Any())
                {
                    DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseMaster>(lstPurchaseMasterList);
                    DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                    rpt1.Subreports[0].SetDataSource(dt1);
                    rpt1.SetDataSource(dt);

                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt1;
                    frm.ShowDialog();
                }
                else
                {
                    dgvPurchaseRecordBySupplier.DataSource = null;
                    txtTotalAmountBySupplier.Text = "0";
                    txtTotalPaidBySupplier.Text = "0";
                    txtTotaldueBySupplier.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
        }

        void GetSupplier()
        {
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyCode(txtSupplierid.Text).ToList();

            listViewSupplier.Items.Clear();
            if (lstSupplierList.Any())
            {
                listViewSupplier.Visible = true;

                foreach (Qry_Supplier aSupplier in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aSupplier;
                    aListViewItem.Text = aSupplier.Supplier_Code;
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Name);
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Address);

                    listViewSupplier.Items.Add(aListViewItem);
                }
            }
        }

        private void btnviewBySupplier_Click(object sender, EventArgs e)
        {
            LoadPurchaseBySupplier();
        }

        private void btnReportBySupplier_Click(object sender, EventArgs e)
        {
            ShowReportBySupplier();
        }

        private void TotalPurchaseReportForm_Load(object sender, EventArgs e)
        {
            //LoadPurchaseBySupplier();
            //LoadPurchaseByProduct();
        }

        private void cmbSearchBySupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBySupplier.Text == "All")
            {
                label4.Visible = false;
                label5.Visible = false;
                txtSupplierid.Visible = false;
                txtSupplier_name.Visible = false;
                listViewSupplier.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
                txtSupplierid.Visible = true;
                txtSupplier_name.Visible = true;
                txtSupplierid.Text = "";
                txtSupplier_name.Text = "";
                txtSupplierid.Focus();
            }
        }

        private void txtSupplierid_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplierid.Text != string.Empty)
            {
                GetSupplier();
            }
        }

        private void txtSupplierid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listViewSupplier.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                listViewSupplier.Focus();
            }
            else
            {
                GetSupplier();
            }
        }

        private void txtSupplierid_Click(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void listViewSupplier_Click(object sender, EventArgs e)
        {
            aTbl_Suplier = (Qry_Supplier)listViewSupplier.SelectedItems[0].Tag;
            txtSupplierid.Text = aTbl_Suplier.Supplier_Code;
            txtSupplier_name.Text = aTbl_Suplier.Supplier_Name;
            listViewSupplier.Visible = false;
            btnviewBySupplier.Focus();
        }

        private void listViewSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Suplier = (Qry_Supplier)listViewSupplier.SelectedItems[0].Tag;
                txtSupplierid.Text = aTbl_Suplier.Supplier_Code;
                txtSupplier_name.Text = aTbl_Suplier.Supplier_Name;
                listViewSupplier.Visible = false;
                btnviewBySupplier.Focus();
            }
        }

        private void cmsPurchaseRecord_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                cmsPurchaseRecord.Visible = false;

                int id = lstPurchaseMasterList[selectedIndex].PurchaseMaster_SlNo;
                string invoiceNo = lstPurchaseMasterList[selectedIndex].PurchaseMaster_InvoiceNo;

                if (e.ClickedItem.Text == "Edit")
                {
                    var returninvoice = aPurchaseBusiness.GetAllPurchaseReturn(lstPurchaseMasterList[selectedIndex].PurchaseMaster_InvoiceNo);
                    if (returninvoice.Any())
                    {
                        MessageBox.Show("Invoice No:" + lstPurchaseMasterList[selectedIndex].PurchaseMaster_InvoiceNo + " is in use");
                        return;
                    }
                    PurchaseForm ob = new PurchaseForm();
                    ob.Text = "Edit Purchase Product";
                    ob.BackColor = Color.LightGray;
                    ob.BackgroundImage = null;
                    ob.id = id;
                    ob.ShowDialog();
                    LoadPurchaseBySupplier();
                }

                if (e.ClickedItem.Text == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Tbl_PurchaseMaster aTbl_PurchaseMaster = aPurchaseBusiness.GetAllPurchaseMaster(id);
                        Tbl_CashRegister aTbl_CashRegister = aCashAccountBusiness.GetAllCashRegister(invoiceNo);

                        try
                        {
                            aTbl_PurchaseMaster.Status = "D";
                            aTbl_PurchaseMaster.UpdateBy = SplashForm.username;
                            aTbl_PurchaseMaster.UpdateTime = DateTime.UtcNow.AddHours(6);

                            //delete(status changed) from cash register table
                            aTbl_CashRegister.Status = "D";
                            aTbl_CashRegister.Edited_By = SplashForm.username;
                            aTbl_CashRegister.Edited_Time = DateTime.UtcNow.AddHours(6);

                            var detailList = aPurchaseBusiness.GetAllPurchaseDetails(id);
                            List<Tbl_PurchaseDetails> lstUpdate = new List<Tbl_PurchaseDetails>();
                            List<Tbl_CurrentInventory> lstupdateCurrentInventory = new List<Tbl_CurrentInventory>();
                            List<Tbl_PurchaseInventory> lstUpdatePurchaseInveontory = new List<Tbl_PurchaseInventory>();
                            foreach (var div in detailList)
                            {
                                var returninvoice = aPurchaseBusiness.GetAllPurchaseReturn(lstPurchaseMasterList[selectedIndex].PurchaseMaster_InvoiceNo);
                                if (returninvoice.Any())
                                {
                                    MessageBox.Show("Invoice No:" + lstPurchaseMasterList[selectedIndex].PurchaseMaster_InvoiceNo + " is in use");
                                    return;
                                }
                                var currentinventory = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                                var purchaseinventory = aPurchaseBusiness.GetAllPurchaseInventory(div.Product_SlNo);
                                if (currentinventory != null)
                                {
                                    currentinventory.CurrentInventory_CurrentQuantity -= div.PurchaseDetails_TotalQuantity;
                                    if (currentinventory.CurrentInventory_CurrentQuantity < 0)
                                    {
                                        currentinventory.CurrentInventory_CurrentQuantity = 0;
                                    }
                                    lstupdateCurrentInventory.Add(currentinventory);
                                }
                                if (purchaseinventory != null)
                                {
                                    purchaseinventory.PurchaseInventory_TotalQuantity -= div.PurchaseDetails_TotalQuantity;
                                    if (purchaseinventory.PurchaseInventory_TotalQuantity < 0)
                                    {
                                        purchaseinventory.PurchaseInventory_TotalQuantity = 0;
                                    }
                                    lstUpdatePurchaseInveontory.Add(purchaseinventory);
                                }
                                div.Status = "D";
                                div.UpdateBy = SplashForm.username;
                                div.UpdateTime = DateTime.UtcNow.AddHours(6);
                                lstUpdate.Add(div);
                            }
                            aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstupdateCurrentInventory);
                            aPurchaseBusiness.InsertorUpdatePurchaseInventory(lstUpdatePurchaseInveontory);
                            aPurchaseBusiness.UpdatePurchaseDetail(lstUpdate);
                            aPurchaseBusiness.UpdatePurchaseMaster(aTbl_PurchaseMaster);
                            aCashAccountBusiness.UpdateCashRegister(aTbl_CashRegister);

                            LoadPurchaseBySupplier();
                            UtilityBusiness.DisplayAlertMessage('S', "Deleted Successfully");
                        }
                        catch (Exception ex)
                        {
                            UtilityBusiness.DisplayAlertMessage('E', ex.Message);
                        }
                        finally
                        {
                            aTbl_PurchaseMaster = null;
                            aTbl_CashRegister = null;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvPurchaseRecordBySupplier_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstPurchaseMasterList.Any())
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsPurchaseRecord.Visible = true;
                    cmsPurchaseRecord.Items.Clear();
                    cmsPurchaseRecord.Items.Add("Edit");
                    cmsPurchaseRecord.Items.Add("Delete");
                    cmsPurchaseRecord.Show(dgvPurchaseRecordBySupplier, new Point(e.X, e.Y));
                }
            }
        }

        private void dgvPurchaseRecordBySupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex; ;
        }

        #endregion

        #region PurchaseRecordByProduct

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

        void LoadPurchaseByProduct()
        {
            List<Qry_PurchaseMasterDetails> lstPurchaseMasterDetailsList = new List<Qry_PurchaseMasterDetails>();
            if (DateTime.Compare(dtpEndDate.Value.Date, dtpStartDate.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }
            if (cmbSearchByProduct.Text == "All")
            {
                clmPurchaseMaster_OrderDate.Visible = false;
                labelunitname.Visible = false;
                label17.Visible = false;
                txtTotalPurchaseQty.Visible = false;
                lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseDetails_TotalQuantity > 0 && x.PurchaseMaster_OrderDate >= dtpStartDate.Value.Date && x.PurchaseMaster_OrderDate <= dtpEndDate.Value.Date).ToList();

                var groupPurchase = lstPurchaseMasterDetailsList.GroupBy(x => x.Product_Code).Select(y => y.First()).ToList();

                List<Qry_PurchaseMasterDetails> lstQry_PurchaseMasterDetailsGridList = new List<Qry_PurchaseMasterDetails>();

                foreach (var g in groupPurchase)
                {
                    Qry_PurchaseMasterDetails aQry_PurchaseMasterDetails = new Qry_PurchaseMasterDetails();

                    aQry_PurchaseMasterDetails.Product_Code = g.Product_Code;
                    aQry_PurchaseMasterDetails.Product_Name = g.Product_Name;
                    aQry_PurchaseMasterDetails.ProductCategory_Name = g.ProductCategory_Name;
                    aQry_PurchaseMasterDetails.PurchaseDetails_TotalQuantity = lstPurchaseMasterDetailsList.Where(y => y.Product_Code == g.Product_Code).Sum(z => z.PurchaseDetails_TotalQuantity);
                    aQry_PurchaseMasterDetails.Unit_Name = g.Unit_Name;

                    lstQry_PurchaseMasterDetailsGridList.Add(aQry_PurchaseMasterDetails);
                }
                dgvPurchaseProductWise.AutoGenerateColumns = false;
                dgvPurchaseProductWise.DataSource = null;
                dgvPurchaseProductWise.DataSource = lstQry_PurchaseMasterDetailsGridList;

                //int sum = 0;
                //for (int i = 0; i < dgvPurchaseProductWise.Rows.Count; ++i)
                //{
                //    sum += Convert.ToInt32(dgvPurchaseProductWise.Rows[i].Cells[4].Value);
                //}
                //txtTotalPurchaseQty.Text = sum.ToString();
            }
            else
            {
                labelunitname.Visible = true;
                label17.Visible = true;
                txtTotalPurchaseQty.Visible = true;
                clmPurchaseMaster_OrderDate.Visible = true;
                dgvPurchaseProductWise.AutoGenerateColumns = false;
                lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllPurchaseMasterDetailsByProduct(txtProductid.Text).Where(x => x.PurchaseDetails_TotalQuantity > 0 && x.PurchaseMaster_OrderDate >= dtpStartDate.Value.Date && x.PurchaseMaster_OrderDate <= dtpEndDate.Value.Date).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();

                if (lstPurchaseMasterDetailsList.Any())
                {
                    dgvPurchaseProductWise.DataSource = null;
                    dgvPurchaseProductWise.DataSource = lstPurchaseMasterDetailsList;

                    labelunitname.Text = aTbl_Product.Unit_Name;
                    int sum = 0;
                    for (int i = 0; i < dgvPurchaseProductWise.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dgvPurchaseProductWise.Rows[i].Cells[4].Value);
                    }
                    txtTotalPurchaseQty.Text = sum.ToString();
                }
                else
                {
                    dgvPurchaseProductWise.DataSource = null;
                    txtTotalPurchaseQty.Text = "0";
                    UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                }
            }
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
                List<Qry_PurchaseMasterDetails> lstPurchaseMasterDetailsList = new List<Qry_PurchaseMasterDetails>();
                ReportViewerForm frm = new ReportViewerForm();
                Reports.CRTotalPurchaseProductWise rpt = new Reports.CRTotalPurchaseProductWise();
                Reports.CRTotalPurchaseSingleProductWise rptt = new Reports.CRTotalPurchaseSingleProductWise();

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
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseDetails_TotalQuantity > 0 && x.PurchaseMaster_OrderDate >= dtpStartDate.Value.Date && x.PurchaseMaster_OrderDate <= dtpEndDate.Value.Date).ToList();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    var groupPurchase = lstPurchaseMasterDetailsList.GroupBy(x => x.Product_Code).Select(y => y.First()).ToList();

                    List<Qry_PurchaseMasterDetails> lstQry_PurchaseMasterDetailsGridList = new List<Qry_PurchaseMasterDetails>();

                    foreach (var g in groupPurchase)
                    {
                        Qry_PurchaseMasterDetails aQry_PurchaseMasterDetails = new Qry_PurchaseMasterDetails();

                        aQry_PurchaseMasterDetails.Product_Code = g.Product_Code;
                        aQry_PurchaseMasterDetails.Product_Name = g.Product_Name;
                        aQry_PurchaseMasterDetails.ProductCategory_Name = g.ProductCategory_Name;
                        aQry_PurchaseMasterDetails.PurchaseDetails_TotalQuantity = lstPurchaseMasterDetailsList.Where(y => y.Product_Code == g.Product_Code).Sum(z => z.PurchaseDetails_TotalQuantity);
                        aQry_PurchaseMasterDetails.Unit_Name = g.Unit_Name;

                        lstQry_PurchaseMasterDetailsGridList.Add(aQry_PurchaseMasterDetails);
                    }

                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    DataTable dt = UtilityBusiness.GenericListToDataTable1(lstQry_PurchaseMasterDetailsGridList);
                    rpt.SetDataSource(dt);
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                else
                {
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllPurchaseMasterDetailsByProduct(txtProductid.Text).Where(x => x.PurchaseDetails_TotalQuantity > 0 && x.PurchaseMaster_OrderDate >= dtpStartDate.Value.Date && x.PurchaseMaster_OrderDate <= dtpEndDate.Value.Date).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();
                    if (lstPurchaseMasterDetailsList.Any())
                    {
                        rptt.Subreports[0].SetDataSource(lstCompanyList);
                        DataTable dt = UtilityBusiness.GenericListToDataTable1(lstPurchaseMasterDetailsList);
                        rptt.SetDataSource(dt);
                        frm.ReportViewer.ReportSource = rptt;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvPurchaseProductWise.DataSource = null;
                        txtTotalPurchaseQty.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnViewByProduct_Click(object sender, EventArgs e)
        {
            LoadPurchaseByProduct();
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

        # region purchase record

        private void cmbSearchByProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchByProduct.Text == "All")
            {
                label9.Visible = false;
                label10.Visible = false;
                txtProductid.Visible = false;
                txtProductName.Visible = false;
                productListView.Visible = false;
            }
            else
            {
                label9.Visible = true;
                label10.Visible = true;
                txtProductid.Visible = true;
                txtProductName.Visible = true;
                txtProductid.Text = "";
                txtProductName.Text = "";
                txtProductid.Focus();
            }
        }

        void GetPurchaseSupplier()
        {
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyCode(txtPurchaseSupplierID.Text).ToList();

            ListViewPurchaseSupplier.Items.Clear();
            if (lstSupplierList.Any())
            {
                ListViewPurchaseSupplier.Visible = true;

                foreach (Qry_Supplier aSupplier in lstSupplierList)
                {
                    ListViewItem aListViewItem = new ListViewItem();
                    aListViewItem.Tag = aSupplier;
                    aListViewItem.Text = aSupplier.Supplier_Code;
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Name);
                    aListViewItem.SubItems.Add(aSupplier.Supplier_Address);

                    ListViewPurchaseSupplier.Items.Add(aListViewItem);
                }
            }
        }

        private void txtPurchaseSupplierID_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseSupplierID.Text != string.Empty)
            {
                GetPurchaseSupplier();
            }
        }

        private void cmbPurchaseRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPurchaseRecord.Text == "All")
            {
                label15.Visible = false;
                label18.Visible = false;
                txtPurchaseSupplierID.Visible = false;
                txtPurchaseSuppierName.Visible = false;
                ListViewPurchaseSupplier.Visible = false;
            }
            else
            {
                label15.Visible = true;
                label18.Visible = true;
                txtPurchaseSupplierID.Visible = true;
                txtPurchaseSuppierName.Visible = true;
                txtPurchaseSupplierID.Text = "";
                txtPurchaseSuppierName.Text = "";
                txtPurchaseSupplierID.Focus();
            }
        }

        private void txtPurchaseSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ListViewPurchaseSupplier.Hide();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ListViewPurchaseSupplier.Focus();
            }
            else
            {
                GetPurchaseSupplier();
            }
        }

        private void txtPurchaseSupplierID_Click(object sender, EventArgs e)
        {
            GetPurchaseSupplier();
        }

        private void btnPurchaseView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Compare(dtpPurchaseTo.Value.Date, dtpPurchaseFrom.Value.Date) < 0)
                {
                    MessageBox.Show("To Date must be equal or greater than from date");
                    return;
                }
                if (cmbPurchaseRecord.Text == "All")
                {
                    clmSupplierCode.Visible = true;
                    clmSupplierName.Visible = true;

                    dgvPurchaseRecord.AutoGenerateColumns = false;
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseMaster_OrderDate >= dtpPurchaseFrom.Value.Date && x.PurchaseMaster_OrderDate <= dtpPurchaseTo.Value.Date).OrderBy(x => x.PurchaseMaster_OrderDate).ToList();

                    if (lstPurchaseMasterDetailsList.Any())
                    {
                        dgvPurchaseRecord.DataSource = lstPurchaseMasterDetailsList;

                        decimal totalsale = 0;
                        for (int i = 0; i < dgvPurchaseRecord.Rows.Count; ++i)
                        {
                            totalsale += Convert.ToInt32(dgvPurchaseRecord.Rows[i].Cells[8].Value);
                        }
                        txttotalPurchaseAmount.Text = Math.Round(totalsale, 2).ToString();
                    }
                    else
                    {
                        dgvPurchaseRecord.DataSource = null;
                        txttotalPurchaseAmount.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else
                {
                    clmSupplierCode.Visible = false;
                    clmSupplierName.Visible = false;

                    dgvPurchaseRecordBySupplier.AutoGenerateColumns = false;
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseMaster_OrderDate >= dtpPurchaseFrom.Value.Date && x.PurchaseMaster_OrderDate <= dtpPurchaseTo.Value.Date && x.Supplier_Code == txtPurchaseSupplierID.Text).OrderBy(x => x.PurchaseMaster_OrderDate).ToList();

                    if (lstPurchaseMasterDetailsList.Any())
                    {
                        dgvPurchaseRecord.DataSource = lstPurchaseMasterDetailsList;

                        decimal totalsale = 0;
                        for (int i = 0; i < dgvPurchaseRecord.Rows.Count; ++i)
                        {
                            totalsale += Convert.ToInt32(dgvPurchaseRecord.Rows[i].Cells[8].Value);
                        }
                        txttotalPurchaseAmount.Text = Math.Round(totalsale, 2).ToString();
                    }
                    else
                    {
                        dgvPurchaseRecord.DataSource = null;
                        txttotalPurchaseAmount.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
            }
            catch
            {
            }
        }

        void ShowAllPurchaseReport()
        {
            try
            {
                if (DateTime.Compare(dtpPurchaseTo.Value.Date, dtpPurchaseFrom.Value.Date) < 0)
                {
                    MessageBox.Show("to date must be equal or greater than from date");
                    return;
                }

                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails();
                Reports.CRProductPurchaseReportByAllSupplier rpt = new Reports.CRProductPurchaseReportByAllSupplier();
                Reports.CRProductPurchaseReportBySupplier rpt1 = new Reports.CRProductPurchaseReportBySupplier();
                //Reports.CRProductSaleReportByUser rpt2 = new Reports.CRProductSaleReportByUser();

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
                objDiscreteValue.Value = dtpPurchaseFrom.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "EndDate";
                objDiscreteValue.Value = dtpPurchaseTo.Value;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                if (cmbPurchaseRecord.Text == "All")
                {
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseMaster_OrderDate >= dtpPurchaseFrom.Value.Date && x.PurchaseMaster_OrderDate <= dtpPurchaseTo.Value.Date).OrderByDescending(x => x.PurchaseMaster_OrderDate).ToList();

                    if (lstPurchaseMasterDetailsList.Any())
                    {
                        DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseMasterDetails>(lstPurchaseMasterDetailsList);
                        DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                        rpt.Subreports[0].SetDataSource(dt1);
                        rpt.SetDataSource(dt);

                        frm.ReportViewer.ParameterFieldInfo = paramFields;
                        frm.ReportViewer.ReportSource = rpt;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvPurchaseRecord.DataSource = null;
                        txttotalPurchaseAmount.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                else if (cmbPurchaseRecord.Text == "Select Supplier")
                {
                    lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseMaster_OrderDate >= dtpPurchaseFrom.Value.Date && x.PurchaseMaster_OrderDate <= dtpPurchaseTo.Value.Date && x.Supplier_Code == txtPurchaseSupplierID.Text).OrderBy(x => x.PurchaseMaster_OrderDate).ToList();

                    if (lstPurchaseMasterDetailsList.Any())
                    {
                        DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseMasterDetails>(lstPurchaseMasterDetailsList);
                        DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                        rpt1.Subreports[0].SetDataSource(dt1);
                        rpt1.SetDataSource(dt);

                        frm.ReportViewer.ParameterFieldInfo = paramFields;
                        frm.ReportViewer.ReportSource = rpt1;
                        frm.ShowDialog();
                    }
                    else
                    {
                        dgvPurchaseRecord.DataSource = null;
                        txttotalPurchaseAmount.Text = "0";
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found");
                    }
                }
                //else if (cmbPurchaseRecord.Text == "Select User")
                //{
                //lstPurchaseMasterDetailsList = aPurchaseBusiness.GetAllQryPurchaseMasterDetails().Where(x => x.PurchaseMaster_OrderDate >= dtpPurchaseFrom.Value.Date && x.PurchaseMaster_OrderDate <= dtpPurchaseTo.Value.Date && x.AddBy == txtUserID.Text).OrderBy(x => x.SaleMaster_SaleDate).ToList();

                //DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseMasterDetails>(lstPurchaseMasterDetailsList);
                //DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                //rpt2.Subreports[0].SetDataSource(dt1);
                //rpt2.SetDataSource(dt);

                //frm.ReportViewer.ParameterFieldInfo = paramFields;
                //frm.ReportViewer.ReportSource = rpt2;
                //frm.ShowDialog();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            ShowAllPurchaseReport();
        }

        private void ListViewPurchaseSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                aTbl_Suplier = (Qry_Supplier)ListViewPurchaseSupplier.SelectedItems[0].Tag;
                txtPurchaseSupplierID.Text = aTbl_Suplier.Supplier_Code;
                txtPurchaseSuppierName.Text = aTbl_Suplier.Supplier_Name;
                ListViewPurchaseSupplier.Visible = false;
                btnPurchaseView.Focus();
            }
        }

        private void ListViewPurchaseSupplier_Click(object sender, EventArgs e)
        {
            aTbl_Suplier = (Qry_Supplier)ListViewPurchaseSupplier.SelectedItems[0].Tag;
            txtPurchaseSupplierID.Text = aTbl_Suplier.Supplier_Code;
            txtPurchaseSuppierName.Text = aTbl_Suplier.Supplier_Name;
            ListViewPurchaseSupplier.Visible = false;
            btnPurchaseView.Focus();
        }

        # endregion

        #region Product PurchaseReturn List

        private void btnPurchaseReturnList_Click(object sender, EventArgs e)
        {
            List<Qry_PurchaseReturnMasterDetails> lstReturnList = aPurchaseBusiness.GetAllPurchaseReturnMasterDetails().Where(x => x.PurchaseReturn_ReturnDate >= dtpPurchaseReturnFrom.Value.Date && x.PurchaseReturn_ReturnDate <= dtpPurchaseReturnTo.Value.Date).OrderBy(x => x.PurchaseReturn_ReturnDate).OrderBy(x => x.PurchaseReturn_ReturnDate).ToList();

            if (DateTime.Compare(dtpPurchaseReturnTo.Value.Date, dtpPurchaseReturnFrom.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }

            if (lstReturnList.Any())
            {
                dgvPurchaseRetrunList.AutoGenerateColumns = false;
                dgvPurchaseRetrunList.DataSource = null;
                dgvPurchaseRetrunList.DataSource = lstReturnList;

                decimal totalPurchaseReturn = 0;
                for (int i = 0; i < dgvPurchaseRetrunList.Rows.Count; ++i)
                {
                    totalPurchaseReturn += Convert.ToInt32(dgvPurchaseRetrunList.Rows[i].Cells[7].Value);
                }
                lblTotalPurchaseReturnAmt.Text = Math.Round(totalPurchaseReturn, 2).ToString();
            }
            else
            {
                dgvPurchaseRetrunList.DataSource = null;
                lblTotalPurchaseReturnAmt.Text = "0";
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        private void btnPurchaseRetrunReport_Click(object sender, EventArgs e)
        {
            lstQry_PurchaseReturnMasterDetails = aPurchaseBusiness.GetAllPurchaseReturnMasterDetails().Where(x => x.PurchaseReturn_ReturnDate >= dtpPurchaseReturnFrom.Value.Date && x.PurchaseReturn_ReturnDate <= dtpPurchaseReturnTo.Value.Date).OrderBy(x => x.PurchaseReturn_ReturnDate).OrderBy(x => x.PurchaseReturn_ReturnDate).ToList();

            if (DateTime.Compare(dtpPurchaseReturnTo.Value.Date, dtpPurchaseReturnFrom.Value.Date) < 0)
            {
                MessageBox.Show("to date must be equal or greater than from date");
                return;
            }

            if (lstQry_PurchaseReturnMasterDetails.Any())
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                Reports.CRPurchaseReturnProduct rpt = new Reports.CRPurchaseReturnProduct();
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


                DataTable dt = Utility.UtilityBusiness.GenericListToDataTable1<Qry_PurchaseReturnMasterDetails>(lstQry_PurchaseReturnMasterDetails);
                DataTable dt1 = Utility.UtilityBusiness.GenericListToDataTable1<Tbl_Company>(lstCompanyList);
                rpt.Subreports[0].SetDataSource(dt1);
                rpt.SetDataSource(dt);

                frm.ReportViewer.ParameterFieldInfo = paramFields;
                frm.ReportViewer.ReportSource = rpt;
                frm.ShowDialog();
            }
            else
            {
                dgvPurchaseRetrunList.DataSource = null;
                lblTotalPurchaseReturnAmt.Text = "0";
                UtilityBusiness.DisplayAlertMessage('W', "No Data found");
            }
        }

        #endregion


    }
}
