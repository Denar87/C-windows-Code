using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class SalesBusiness
    {
        SalesService aSalesService = new SalesService();
        ~SalesBusiness()
       {
           aSalesService.Dispose();
           aSalesService = null;
       }

        #region SalesMaster

        public bool Insert_SaleMaster_1(Tbl_SalesMaster_1 aTbl_SalesMaster_1)
        {
            return aSalesService.Insert_SaleMaster_1(aTbl_SalesMaster_1) > 0;
        }

        public bool delete_SaleMasterDetail_1(string userId)
        {
            return aSalesService.delete_SaleMasterDetail_1(userId) > 0;
        }

        public string ValidateMasterOnSave(Tbl_SalesMaster aTbl_SaleMaster)
        {
            if (aTbl_SaleMaster.Customer_SlNo == null)
            {
                return "Enter Customer!";
            }
            if (aTbl_SaleMaster.SaleMaster_InvoiceNo == string.Empty)
            {
                return "Enter Invoice!";
            }
            //if (GetInvoiceNo(aTbl_SaleMaster.SaleMaster_InvoiceNo) != null)
            //{
            //    return "Invoice No. already exist!";
            //}
            return string.Empty;
        }

        public string validateDetailsOnSave(Tbl_SaleDetails aTbl_SaleDetails)
        {
            if (aTbl_SaleDetails.Product_SlNo == 0)
            {
                return "Enter Product";
            }
            if (aTbl_SaleDetails.SaleDetails_TotalQuantity == 0)
            {
                return "Enter Quantity";
            }
            return string.Empty;
        }

        public Tbl_SalesMaster GetInvoiceNo(string invoiceNo)
        {
            return aSalesService.GetInvoiceNo(invoiceNo);
        }

        public Tbl_SalesMaster GetAllSalesMaster(int id)
        {
            return aSalesService.GetAllSalesMaster(id);
        }

        public List<Tbl_SalesMaster> GetAllSaleMasterByCustomer(int customer)
        {
            return aSalesService.GetAllSaleMasterByCustomer(customer);
        }

        public List<Tbl_SalesMaster> GetAllSalesMaster()
        {
            return aSalesService.GetAllSalesMaster();
        }

        public Tbl_SalesMaster GetSalesMaster()
        {
            return aSalesService.GetSalesMaster();
        }

        public List<Tbl_SalesChallan> GetAllSalesChallan()
        {
            return aSalesService.GetAllSalesChallan();

        }
        public List<Tbl_SalesMaster> GetAllInvoiceNo(string invoice)
        {
            return aSalesService.GetAllInvoiceNo(invoice);
        }

        public Tbl_SalesMaster GetAllSalesMaster(string voucherId)
        {
            return aSalesService.GetAllSalesMaster(voucherId);
        }

        public List<Qry_SalesMaster> GetAllQrySalesMaster()
        {
            return aSalesService.GetAllQrySalesMaster();
        }
        public Qry_SalesMaster GetAllQrySalesMaster(int id)
        {
            return aSalesService.GetAllQrySalesMaster(id);
        }
        public List<Qry_SalesMaster> GetAllQrySalesMaster(string invoiceNo)
        {
            return aSalesService.GetAllQrySalesMaster(invoiceNo);
        }

        public bool InsertSalesMaster(Tbl_SalesMaster aTbl_SalesMaster)
        {
            return aSalesService.InsertSalesMaster(aTbl_SalesMaster) > 0;
        }

        public bool UpdateSalesMaster(Tbl_SalesMaster aTbl_SalesMaster)
        {
            return aSalesService.UpdateSalesMaster(aTbl_SalesMaster) > 0;
        }

        public Tbl_SalesMaster GetLastSalesMaster()
        {
            return aSalesService.GetLastSalesMaster();
        }

        public string GenerateInvoiceNo()
        {
            string prefix = DateTime.UtcNow.AddHours(6).ToString("yyyy-MM-dd");
            int cnt = 0;
            Tbl_SalesMaster master = GetLastSalesMaster();
            if (master != null)
            {
                string ff = master.SaleMaster_InvoiceNo.Substring(10).ToString();
                string date = master.SaleMaster_InvoiceNo.Substring(0, 10).ToString();
                if (date.Equals(prefix))
                {
                    cnt = Convert.ToInt32(ff);
                    cnt++;
                }
                else
                {
                    cnt++;
                }
                return prefix + cnt.ToString("0000");
            }
            else
            {
                cnt++;
                return prefix + cnt.ToString("0000");
            }
        }



        public List<Qry_SalesInvoice> GetAllQrySalesInvoiceByInvoice(string voucherId)
        {
            return aSalesService.GetAllQrySalesInvoiceByInvoice(voucherId);
        }
        public List<Get_SaleInvoice> GetAllSalesInvoiceByInvoice(string voucherId)
        {
            return aSalesService.GetAllSalesInvoiceByInvoice(voucherId);
        }

        public List<Get_SaleInvoice_1> GetAllSalesInvoiceByInvoice_1(string voucherId)
        {
            return aSalesService.GetAllSalesInvoiceByInvoice_1(voucherId);
        }

        public List<Get_SaleInvoiceByChallan> GetAllSalesInvoiceByChallan(string voucherId, string challanNo)
        {
            return aSalesService.GetAllSalesInvoiceByChallan(voucherId, challanNo);
        }

        public List<Get_SaleInvoiceByChallan> GetAllChallanDetails()
        {
            return aSalesService.GetAllChallanDetails();
        }

        #endregion

        #region SalesDetails

        public Tbl_SaleDetails GetAllSaleDetails(int id)
        {
            return aSalesService.GetAllSaleDetails(id);
        }
        public Tbl_SaleDetails GetAllTbl_SaleDetailsByid(int id)
        {
            return aSalesService.GetAllTbl_SaleDetailsByid(id);
        }
        public List<Tbl_SaleDetails> GetAllSalesDetails(int id)
        {
            return aSalesService.GetAllSalesDetails(id);
        }
        public List<Tbl_SaleDetails> GetAllSalesDetails()
        {
            return aSalesService.GetAllSalesDetails();
        }
        public List<Tbl_SaleDetails> GetAllSaleByProductID(int id)
        {
            return aSalesService.GetAllSaleByProductID(id);
        }
  
        public List<Qry_SalesDetails> GetAllQrySalesDetails(int id)
        {
            return aSalesService.GetAllQrySalesDetails(id);
        }

        public bool InsertSalesDetail(List<Tbl_SaleDetails> lstTbl_SalesDetails)
        {
            return aSalesService.InsertSalesDetail(lstTbl_SalesDetails) > 0;
        }

        public bool InsertSalesDetail_1(List<Tbl_SaleDetails_1> lstTbl_SalesDetails_1)
        {
            return aSalesService.InsertSalesDetail_1(lstTbl_SalesDetails_1) > 0;
        }

        public bool UpdateSalesDetail(Tbl_SaleDetails aTbl_SalesDetails)
        {
            return aSalesService.UpdateSalesDetail(aTbl_SalesDetails) > 0;
        }
        public bool UpdateSalesDetail(List<Tbl_SaleDetails> aTbl_SaleDetails)
        {
            return aSalesService.UpdateSalesDetail(aTbl_SaleDetails) > 0;
        }
        #endregion

        #region SalesInventory

        public bool InsertorUpdateSalesInventory(List<Tbl_SaleInventory> lstInventory)
        {
            return aSalesService.InsertorUpdateSalesInventory(lstInventory) > 0;
        }

        public Tbl_SaleInventory GetAllSalesInventory(int productId)
        {
            return aSalesService.GetAllSalesInventory(productId);
        }

        public void SaveSaleReturn(List<Tbl_SaleReturn> lstmaster, List<Tbl_SaleReturnDetails> lstdetails, List<Tbl_SaleInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            aSalesService.SaveSaleReturn(lstmaster, lstdetails, lstinventory, lstcurInventory);
        }

        public List<Qry_SalesInventory> GetAllQrySalesInventory()
        {
            return aSalesService.GetAllQrySalesInventory();
        }

        #endregion

        #region SaleReturn

        public List<Tbl_SaleReturn> GetAllSaleReturn()
        {
            return aSalesService.GetAllSaleReturn();
        }

        public List<Tbl_SaleReturn> GetAllSaleReturn(string invoiceNo)
        {
            return aSalesService.GetAllSaleReturn(invoiceNo);
        }

        public List<Qry_SaleReturnMasterDetails> GetAllSaleReturnMasterDetails()
        {
            return aSalesService.GetAllSaleReturnMasterDetails();
        }

        public List<Qry_SaleReturnMasterDetails> GetAllSaleReturnMasterDetails(string invoiceNo)
        {
            return aSalesService.GetAllSaleReturnMasterDetails(invoiceNo);
        }

        public bool InsertOrUpdateSaleReturn(Tbl_SaleReturn aTbl_SaleReturn)
        {
            return aSalesService.InsertOrUpdateSaleReturn(aTbl_SaleReturn) > 0;
        }

        public bool InsertOrUpdateSaleReturnDetails(List<Tbl_SaleReturnDetails> lstTbl_SaleReturnDetails)
        {
            return aSalesService.InsertOrUpdateSaleReturnDetails(lstTbl_SaleReturnDetails) > 0;
        }

        #endregion

        #region SaleMasterDetails

        public List<Qry_SaleMasterDetails> GetAllQrySaleMasterDetails()
        {
            return aSalesService.GetAllQrySaleMasterDetails();
        }

        public List<GetSaleMasterDetails> GetAllSaleMasterDetails()
        {
            return aSalesService.GetAllSaleMasterDetails();
        }

        public List<Get_SaleMaster> Get_AllSaleMaster()
        {
            return aSalesService.Get_AllSaleMaster();
        }

        public List<Qry_SalesPurchaseDetails> GetAllQry_SalesPurchaseDetails()
        {
            return aSalesService.GetAllQry_SalesPurchaseDetails();
        }

        public List<Qry_SaleMasterDetails> GetAllSaleMasterDetails(string productid)
        {
            return aSalesService.GetAllSaleMasterDetails(productid);
        }

        public List<Qry_SaleMasterDetails> GetAllSaleMasterDetailsByInvoice(string invoiceid)
        {
            return aSalesService.GetAllSaleMasterDetailsByInvoice(invoiceid);
        }

        #endregion

        #region SaveSale

        public void SaveSale(List<Tbl_SalesMaster> lstmaster, List<Tbl_SaleDetails> lstdetails, List<Tbl_SaleInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            aSalesService.SaveSale(lstmaster, lstdetails, lstinventory, lstcurInventory);

        }

        #endregion

        #region Tbl_SalesChallan

        public bool InsertSaleChallan(Tbl_SalesChallan aTbl_SalesChallan)
        {
            return aSalesService.InsertSaleChallan(aTbl_SalesChallan) > 0;
        }

        public Tbl_SalesChallan GetLastSalesChallan()
        {
            return aSalesService.GetLastSalesChallan();
        }

        public Tbl_QuotationMaster GetLastQuotationNo()
        {
            return aSalesService.GetLastQuotationNo();
        }
        public string GenerateSaleChallanNo()
        {
            Tbl_SalesChallan challan = GetLastSalesChallan();
            string prefix = "CH";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (challan != null)
            {
                subprefix = challan.SaleChallanNo;
                subprefix = subprefix.Substring(2).ToString();
                cnt = Convert.ToInt32(subprefix);
                cnt++;
                code = prefix + cnt.ToString("0000");
            }
            else
            {
                cnt++;

                code = prefix + cnt.ToString("0000");
            }
            return code;
        }

        public string GenerateQuotationNo()
        {
            Tbl_QuotationMaster quotation = GetLastQuotationNo();
            string prefix = "Q-";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (quotation != null)
            {
                subprefix = quotation.QuotationMaster_InvoiceNo;
                subprefix = subprefix.Substring(2).ToString();
                cnt = Convert.ToInt32(subprefix);
                cnt++;
                code = prefix + cnt.ToString("00000");
            }
            else
            {
                cnt++;

                code = prefix + cnt.ToString("00000");
            }
            return code;
        }

        #endregion

        #region QuotionMaster

        public string ValidateMasterOnSave(Tbl_QuotationMaster aTbl_QuotationMaster)
        {
            if (aTbl_QuotationMaster.Customer_SlNo == null)
            {
                return "Enter Customer!";
            }
            if (aTbl_QuotationMaster.QuotationMaster_InvoiceNo == string.Empty)
            {
                return "Enter Quotation No.!";
            }
            return string.Empty;
        }

        public bool InsertQuotationMaster(Tbl_QuotationMaster aTbl_QuotationMaster)
        {
            return aSalesService.InsertQuotationMaster(aTbl_QuotationMaster) > 0;
        }

        public bool UpdateQuotationMaster(Tbl_QuotationMaster aTbl_QuotationMaster)
        {
            return aSalesService.UpdateQuotationMaster(aTbl_QuotationMaster) > 0;
        }

        public Tbl_QuotationMaster GetAllQuotationMaster(int id)
        {
            return aSalesService.GetAllQuotationMaster(id);
        }

        public List<Tbl_QuotationMaster> GetAllQuotationMaster()
        {
            return aSalesService.GetAllQuotationMaster();
        }

        public string validateDetailsOnSave(Tbl_QuotationDetails aTbl_QuotationDetails)
        {
            if (aTbl_QuotationDetails.Product_SlNo == 0)
            {
                return "Enter Product";
            }
            if (aTbl_QuotationDetails.QuotationDetails_TotalQuantity == 0)
            {
                return "Enter Quantity";
            }
            return string.Empty;
        }

        public bool InsertQuotationDetail(List<Tbl_QuotationDetails> lstTbl_QuotationDetails)
        {
            return aSalesService.InsertQuotationDetail(lstTbl_QuotationDetails) > 0;
        }

        public bool UpdateQuotationDetail(List<Tbl_QuotationDetails> aTbl_QuotationDetails)
        {
            return aSalesService.UpdateQuotationDetail(aTbl_QuotationDetails) > 0;

        }
        public Tbl_QuotationDetails GetAllTbl_QuotationDetailsByid(int id)
        {
            return aSalesService.GetAllTbl_QuotationDetailsByid(id);
        }
        public List<Tbl_QuotationDetails> GetAllQryQuotationDetails(int id)
        {
            return aSalesService.GetAllQryQuotationDetails(id);
        }

        public List<Get_SaleInvoiceByQuotation> GetQuotationByNo(string quotationNo)
        {
            return aSalesService.GetQuotationByNo(quotationNo);
        }

        public List<Get_SaleInvoiceByQuotation> GetAllQuotationDetails()
        {
            return aSalesService.GetAllQuotationDetails();
        }


        #endregion


    }
}
