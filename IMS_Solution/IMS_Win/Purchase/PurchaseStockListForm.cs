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
    public partial class PurchaseStockListForm : Form
    {
        PurchaseBusiness aPurchaseBusincess = new PurchaseBusiness();
        List<Qry_PurchaseInventory> lstPurchaseStockList = new List<Qry_PurchaseInventory>();
        public PurchaseStockListForm()
        {
            InitializeComponent();
        }


        void LoadGrid()
        {
            dgvPurchaseStock.AutoGenerateColumns = false;
            lstPurchaseStockList = aPurchaseBusincess.GetAllQryPurchaseInventory();
            dgvPurchaseStock.DataSource = lstPurchaseStockList;
        }

        private void PurchaseStockListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
