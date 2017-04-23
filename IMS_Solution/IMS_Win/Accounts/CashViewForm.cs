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
    public partial class CashViewForm : Form
    {
        SalesBusiness aSalesBusiness = new SalesBusiness();
        CashAccountBusiness aCashAccountBusiness = new CashAccountBusiness();
        PurchaseBusiness aPurchaseBusiness = new PurchaseBusiness();
        Tbl_SalesMaster aTbl_SalesMaster = new Tbl_SalesMaster();

        public CashViewForm()
        {
            InitializeComponent();
        }

        decimal salepaid;
        decimal purchasepaid;
        decimal salereturn;
        decimal purchasereturn;
        decimal inamount;
        decimal outamount;
        decimal cashinhand;
        decimal bankbalance;
        decimal bankdeposit;
        decimal bankwithdraw;
        
        void loadCashInHand()
        {
            List<Tbl_SalesMaster> lstsalemasterList = aSalesBusiness.GetAllSalesMaster();

            if (lstsalemasterList != null)
            {
                salepaid = lstsalemasterList.Sum(x => x.SaleMaster_PaidAmount);
            }
            List<Tbl_PurchaseMaster> lstpurchasemasterList = aPurchaseBusiness.GetAllPurchaseMaster();
            if (lstpurchasemasterList != null)
            {
                purchasepaid = lstpurchasemasterList.Sum(x => x.PurchaseMaster_PaidAmount);
            }
            List<Tbl_SaleReturn> lstsalereturnList = aSalesBusiness.GetAllSaleReturn();
            if (lstsalereturnList != null)
            {
                salereturn = lstsalereturnList.Sum(x => x.SaleReturn_ReturnAmount);
            }
            List<Tbl_PurchaseReturn> lstpurchasereturnList = aPurchaseBusiness.GetAllPurchaseReturn();
            if (lstpurchasereturnList != null)
            {
                purchasereturn = lstpurchasereturnList.Sum(x => x.PurchaseReturn_ReturnAmount);
            }
            List<Tbl_CashTransaction> lstCashTransacionList = aCashAccountBusiness.GetAllCashTransaction();
            if (lstCashTransacionList != null)
            {
                inamount = lstCashTransacionList.Sum(x => x.In_Amount);
                outamount = lstCashTransacionList.Sum(x=> x.Out_Amount);
            }
            
          cashinhand=(salepaid+inamount+purchasereturn)-(purchasepaid+salereturn+outamount);

          lblCashInHand.Text =Math.Round (cashinhand,2).ToString();

        }

        void loadBankBalance()
        {
            List<Tbl_CashTransaction> lstCashTransacionList = aCashAccountBusiness.GetAllCashTransaction();
            if (lstCashTransacionList != null)
            {
                bankwithdraw = lstCashTransacionList.Where(x => x.Tr_Type == "Withdraw from Bank").Sum(x => x.In_Amount);
                bankdeposit = lstCashTransacionList.Where(x => x.Tr_Type == "Deposit To Bank").Sum(x => x.Out_Amount);
            }
            bankbalance = bankdeposit - bankwithdraw;

            lblBankBalance.Text = Math.Round(bankbalance,2).ToString();
        }

        void TotalCurrentAsset()
        {
            lblTotalCurrentAsset.Text = Math.Round(cashinhand + bankbalance,2).ToString();
        }

        private void CashViewForm_Load(object sender, EventArgs e)
        {
            loadCashInHand();
            loadBankBalance();
            TotalCurrentAsset();
        }


    }
}
