using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Entity;
using IMS_Business;


namespace IMS_Win
{
    public partial class SalesStockListForm : Form
    {
        SalesBusiness aSalesBusincess = new SalesBusiness();
        List<Qry_SalesInventory> lstSalesStockList = new List<Qry_SalesInventory>();
        public SalesStockListForm()
        {
            InitializeComponent();
        }
        void LoadGrid()
        {
            dgvSalesStock.AutoGenerateColumns = false;
            lstSalesStockList = aSalesBusincess.GetAllQrySalesInventory();
            dgvSalesStock.DataSource = lstSalesStockList;
        }

        private void SalesStockListForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
 
    }
}
