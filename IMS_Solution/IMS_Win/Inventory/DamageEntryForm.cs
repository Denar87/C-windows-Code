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
    public partial class DamageEntryForm : Form
    {
        DamageBusiness aDamageBusiness = new DamageBusiness();
        ProductBusiness aProductBusiness = new ProductBusiness();
        PurchaseBusiness aPurchaseInventoryBusincess = new PurchaseBusiness();
        CurrentInventoryBusiness aCurrentInventoryBusiness = new CurrentInventoryBusiness();
        
        Qry_Product aTbl_Product = new Qry_Product();
        List<Qry_DamageDetails> lstDamageGridList = new List<Qry_DamageDetails>();
        public DamageEntryForm()
        {
            InitializeComponent();
        }

        void GetProduct()
        {
            List<Qry_Product> lstProductList = aProductBusiness.GetAllQryProductByCode(txtcode.Text).Where(x => x.Product_IsFinishedGoods == true).ToList();
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

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            if (txtcode.Text != string.Empty)
            {
                GetProduct();
            }
        }

        private void txtcode_KeyDown(object sender, KeyEventArgs e)
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

        private void txtcode_Click(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void productListView_Click(object sender, EventArgs e)
        {
            aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

            txtcode.Text = aTbl_Product.Product_Code;
            txtname.Text = aTbl_Product.Product_Name;
            lblunit.Text = aTbl_Product.Unit_Name;
            productListView.Visible = false;
            txtDescription.Focus();
        }

        private void DamageEntryForm_Load(object sender, EventArgs e)
        {
            NewDamage();
        }

        void NewDamage()
        {
            txtcode.Text = "";
            txtname.Text = "";
            txtDescription.Text = "";
            txtqty.Text = "0";
            txtInvoice.Text = aDamageBusiness.GenerateInvoiceNo();
            txtcode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!lstDamageGridList.Any())
            {
                UtilityBusiness.DisplayAlertMessage('W', "No data exist!");
                return;
            }
            if ((MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
            {
                return;
            }
            List<Tbl_Damage> lstMasterList = new List<Tbl_Damage>();
            Tbl_Damage master = new Tbl_Damage();
            master.Damage_InvoiceNo = txtInvoice.Text;
            master.Damage_Date = DateTime.UtcNow.AddHours(6);
            master.Damage_Description = txtDescription.Text;
            master.Status = "A";
            master.AddBy = SplashForm.username;
            master.AddTime = DateTime.UtcNow.AddHours(6);
            string msg = aDamageBusiness.validateOnSave(master);
            if (msg != string.Empty)
            {
                UtilityBusiness.DisplayAlertMessage('W', msg);
                return;
            }
            if (dgvDamageProduct.Rows.Count==0)
            {
                UtilityBusiness.DisplayAlertMessage('W', "Please Add Product To List!");
                return;
            }
            lstMasterList.Add(master);
            aDamageBusiness.InsertDamage(master);
            
            List<Tbl_DamageDetails> lstDamageDetailsList = new List<Tbl_DamageDetails>();
            List<Tbl_PurchaseInventory> lstInventoryList = new List<Tbl_PurchaseInventory>();
            List<Tbl_CurrentInventory> lstCurrentInventoryList = new List<Tbl_CurrentInventory>();

            foreach (Qry_DamageDetails div in lstDamageGridList)
            {
                Tbl_DamageDetails details = new Tbl_DamageDetails();
                details.Damage_SlNo = master.Damage_SlNo;
                details.Product_SlNo = div.Product_SlNo;
                details.DamageDetails_DamageQuantity = div.DamageDetails_DamageQuantity;
                details.Status = "A";
                master.AddBy = SplashForm.username;
                master.AddTime = DateTime.UtcNow.AddHours(6);
                msg = aDamageBusiness.validateDetailsOnSave(details);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                lstDamageDetailsList.Add(details);


                Tbl_PurchaseInventory inventory = new Tbl_PurchaseInventory();
                Tbl_PurchaseInventory existData = aPurchaseInventoryBusincess.GetAllPurchaseInventory(div.Product_SlNo);
                if (existData != null)
                {
                    inventory = existData;
                }

                inventory.Product_SlNo = div.Product_SlNo;

                inventory.PurchaseInventory_DamageQuantity += div.DamageDetails_DamageQuantity;
                lstInventoryList.Add(inventory);

                Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(div.Product_SlNo);
                if (curinv != null)
                {
                    curinv.CurrentInventory_CurrentQuantity -= div.DamageDetails_DamageQuantity;
                    if (curinv.CurrentInventory_CurrentQuantity < 0)
                    {
                        curinv.CurrentInventory_CurrentQuantity = 0;
                    }
                    lstCurrentInventoryList.Add(curinv);
                }
            }
            aDamageBusiness.InsertDamageDetail(lstDamageDetailsList);

            aPurchaseInventoryBusincess.InsertorUpdatePurchaseInventory(lstInventoryList);
            aCurrentInventoryBusiness.InsertorUpdateCurrentInventory(lstCurrentInventoryList);
            NewDamage();
            UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
            
            dgvDamageProduct.DataSource = null;
            lstDamageGridList.Clear();

        }

        void loadGrid()
        {
            dgvDamageProduct.AutoGenerateColumns = false;
            dgvDamageProduct.DataSource = null;
            dgvDamageProduct.DataSource = lstDamageGridList;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == string.Empty)
            {
                UtilityBusiness.DisplayAlertMessage('W', "Enter Product");
                txtcode.Focus();
                return;
            }
            if (Convert.ToDouble(txtqty.Text) == 0)
            {
                UtilityBusiness.DisplayAlertMessage('W', "Enter Quantity");
                txtqty.Focus();
                return;
            }
            if (lstDamageGridList.Any(x => x.Product_SlNo == aTbl_Product.Product_SlNo))
            {
                UtilityBusiness.DisplayAlertMessage('W', "Data Already Exist");
                return;
            }
            
            Qry_DamageDetails details = new Qry_DamageDetails();
            details.Product_SlNo = aTbl_Product.Product_SlNo;
            details.Product_Name = aTbl_Product.Product_Name;

            Tbl_CurrentInventory curinv = aCurrentInventoryBusiness.GetInventoryByProductId(aTbl_Product.Product_SlNo);
            if (curinv == null)
            {
                UtilityBusiness.DisplayAlertMessage('W',"Current Stock Is Empty");
                return;
            }
            if (curinv.CurrentInventory_CurrentQuantity >= Convert.ToDouble(txtqty.Text) )
            {
                details.DamageDetails_DamageQuantity = Convert.ToDouble(txtqty.Text);
            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('W', "Damaged Quantity Should Be Lower Than Available Quantity");
                return;
            }
            details.Unit_Name = aTbl_Product.Unit_Name;
            lstDamageGridList.Add(details);
            loadGrid();

            txtcode.Text = "";
            txtname.Text = "";
            txtqty.Text = "0";
            txtcode.Focus();
        }

        private void dgvDamageProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lstDamageGridList.Any())
            {
                if (e.ColumnIndex == 3)
                {
                    lstDamageGridList.RemoveAt(e.RowIndex);
                    loadGrid();
                }
            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void productListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                aTbl_Product = (Qry_Product)productListView.SelectedItems[0].Tag;

                txtcode.Text = aTbl_Product.Product_Code;
                txtname.Text = aTbl_Product.Product_Name;
                lblunit.Text = aTbl_Product.Unit_Name;
                productListView.Visible = false;
                txtDescription.Focus();
            }
        }
 



    }
}
