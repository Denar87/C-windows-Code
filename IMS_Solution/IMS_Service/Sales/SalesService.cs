using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace IMS_Service
{
    public class SalesService : IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~SalesService()
        {
            if (context != null)
            {
                try
                {
                    context.Dispose();
                    context = null;
                }
                catch { }

            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (context != null) { try { context.Dispose(); context = null; } catch { } }
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Tbl_SalesMaster

        public int Insert_SaleMaster_1(Tbl_SalesMaster_1 aTbl_SalesMaster_1)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_SalesMaster_1.Add(aTbl_SalesMaster_1);
            return context.SaveChanges();
        }

        public int delete_SaleMasterDetail_1(string userId)
        {
            var aTbl_SalesMaster_1 = context.Tbl_SalesMaster_1.Where(x => x.AddBy == userId);
            foreach (Tbl_SalesMaster_1 data in aTbl_SalesMaster_1)
            {
                context.Tbl_SalesMaster_1.Remove(data);
            }

            var aTbl_SaleDetails_1 = context.Tbl_SaleDetails_1.Where(x => x.AddBy == userId); ;
            foreach (Tbl_SaleDetails_1 data in aTbl_SaleDetails_1)
            {
                context.Tbl_SaleDetails_1.Remove(data);
            }

            return context.SaveChanges();
        }

        public Tbl_SalesMaster GetAllSalesMaster(int id)
        {
            return context.Tbl_SalesMaster.Where(x => x.SaleMaster_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_SalesMaster GetSalesMaster()
        {
            return context.Tbl_SalesMaster.Where(x => x.Status.Trim() == "A").FirstOrDefault();
        }

        public List<Qry_SalesInvoice> GetAllQrySalesInvoiceByInvoice(string voucherId)
        {
            return context.Qry_SalesInvoice.Where(x => x.SaleMaster_InvoiceNo == voucherId).ToList();
        }

        public List<Get_SaleInvoice> GetAllSalesInvoiceByInvoice(string voucherId)
        {
            return context.Get_SaleInvoice().Where(x => x.SaleMaster_InvoiceNo == voucherId).ToList();
        }

        public List<Get_SaleInvoice_1> GetAllSalesInvoiceByInvoice_1(string voucherId)
        {
            return context.Get_SaleInvoice_1().Where(x => x.SaleMaster_InvoiceNo == voucherId).ToList();
        }

        public List<Get_SaleInvoiceByChallan> GetAllSalesInvoiceByChallan(string voucherId, string challanNo)
        {
            return context.Get_SaleInvoiceByChallan().Where(x => x.SaleMaster_InvoiceNo == voucherId && x.SaleChallanNo==challanNo).ToList();
        }

        public List<Get_SaleInvoiceByChallan> GetAllChallanDetails()
        {
            return context.Get_SaleInvoiceByChallan().OrderByDescending(x => x.SaleMaster_SaleDate).ToList();
        }


        public List<Tbl_SalesChallan> GetAllSalesChallan()
        {
            return context.Tbl_SalesChallan.Where(x => x.Status.Trim() == "A").ToList();
        }

        public List<Tbl_SalesMaster> GetAllSaleMasterByCustomer(int customer)
        {
            return context.Tbl_SalesMaster.Where(x => x.Customer_SlNo == customer && x.Status.Trim() == "A").ToList();
        }

        public Tbl_SalesMaster GetLastSalesMaster()
        {
            return context.Tbl_SalesMaster.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.SaleMaster_SlNo).FirstOrDefault();
        }

        public List<Tbl_SalesMaster> GetAllSalesMaster()
        {
            return context.Tbl_SalesMaster.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.SaleMaster_InvoiceNo).ToList();
        }

        public List<Tbl_SalesMaster> GetAllInvoiceNo(string invoice)
        {
            return context.Tbl_SalesMaster.Where(x => x.SaleMaster_InvoiceNo == invoice && x.Status.Trim() == "A").ToList();
        }

        public Tbl_SalesMaster GetInvoiceNo(string invoiceNo)
        {
            return context.Tbl_SalesMaster.Where(x =>
                x.SaleMaster_InvoiceNo == invoiceNo &&
                x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_SalesMaster GetAllSalesMaster(string voucherId)
        {
            return context.Tbl_SalesMaster.Where(x => x.SaleMaster_InvoiceNo == voucherId && x.Status.Trim() == "A").FirstOrDefault();
        }

        public List<Qry_SalesMaster> GetAllQrySalesMaster()
        {
            return context.Qry_SalesMaster.ToList();
        }

        public Qry_SalesMaster GetAllQrySalesMaster(int id)
        {
            return context.Qry_SalesMaster.Where(x => x.SaleMaster_SlNo == id).FirstOrDefault();
        }
        public List<Qry_SalesMaster> GetAllQrySalesMaster(string invoiceNo)
        {
            return context.Qry_SalesMaster.Where(x => x.SaleMaster_InvoiceNo == invoiceNo).ToList();
        }

        public int InsertSalesMaster(Tbl_SalesMaster aTbl_SalesMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_SalesMaster.Add(aTbl_SalesMaster);
            return context.SaveChanges();
        }

        public int UpdateSalesMaster(Tbl_SalesMaster aTbl_SalesMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_SalesMaster.Attach(aTbl_SalesMaster);
            context.Entry(aTbl_SalesMaster).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int UpdateSalesMaster(List<Tbl_SalesMaster> lstTbl_SalesMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_SalesMaster aTbl_SalesMaster in lstTbl_SalesMaster)
            {
                context.Tbl_SalesMaster.Attach(aTbl_SalesMaster);
                context.Entry(aTbl_SalesMaster).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }

        #endregion

      
        #region Sales Details

        public Tbl_SaleDetails GetAllSaleDetails(int id)
        {
            return context.Tbl_SaleDetails.Where(x => x.SaleMaster_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_SaleDetails GetAllTbl_SaleDetailsByid(int id)
        {
            return context.Tbl_SaleDetails.Where(x => x.SaleDetails_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }
        public List<Tbl_SaleDetails> GetAllSaleByProductID(int id)
        {
            return context.Tbl_SaleDetails.Where(x => x.Product_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_SaleDetails> GetAllSalesDetails(int id)
        {
            return context.Tbl_SaleDetails.Where(x => x.SaleMaster_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_SaleDetails> GetAllSalesDetails()
        {
            return context.Tbl_SaleDetails.Where(x => x.Status.Trim() == "A").ToList();
        }

        public List<Qry_SalesDetails> GetAllQrySalesDetails(int id)
        {
            return context.Qry_SalesDetails.Where(x => x.SaleMaster_SlNo == id).ToList();
        }

        public int InsertSalesDetail(List<Tbl_SaleDetails> lstTbl_SalesDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_SaleDetails aTbl_SalesDetails in lstTbl_SalesDetails)
            {
                context.Tbl_SaleDetails.Add(aTbl_SalesDetails);
            }
            return context.SaveChanges();
        }

        public int InsertSalesDetail_1(List<Tbl_SaleDetails_1> lstTbl_SalesDetails_1)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_SaleDetails_1 aTbl_SalesDetails_1 in lstTbl_SalesDetails_1)
            {
                context.Tbl_SaleDetails_1.Add(aTbl_SalesDetails_1);
            }
            return context.SaveChanges();
        }

        public int UpdateSalesDetail(Tbl_SaleDetails aTbl_SalesDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_SaleDetails.Attach(aTbl_SalesDetails);
            context.Entry(aTbl_SalesDetails).State = EntityState.Modified;
            return context.SaveChanges();
        }
        public int UpdateSalesDetail(List<Tbl_SaleDetails> lstTbl_SalesDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            foreach (Tbl_SaleDetails aTbl_SaleDetails in lstTbl_SalesDetails)
            {
                context.Tbl_SaleDetails.Attach(aTbl_SaleDetails);
                context.Entry(aTbl_SaleDetails).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }
        #endregion

        #region Inventory
        public int InsertorUpdateSalesInventory(List<Tbl_SaleInventory> lstInventory)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_SaleInventory inventory in lstInventory)
            {
                if (inventory.SaleInventory_SlNo == 0)
                {
                    context.Tbl_SaleInventory.Add(inventory);
                }
                else
                {
                    context.Tbl_SaleInventory.Attach(inventory);
                    context.Entry(inventory).State = EntityState.Modified;
                }
            }
            return context.SaveChanges();
        }

        public Tbl_SaleInventory GetAllSalesInventory(int productId)
        {
            return context.Tbl_SaleInventory.Where(x => x.Product_SlNo == productId).FirstOrDefault();
        }


        public List<Qry_SalesInventory> GetAllQrySalesInventory()
        {
            return context.Qry_SalesInventory.OrderBy(x => x.ProductCategory_Name).ToList();

        }
        #endregion

        #region Sale Return
        public List<Tbl_SaleReturn> GetAllSaleReturn()
        {
            return context.Tbl_SaleReturn.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_SaleReturn> GetAllSaleReturn(string invoiceNo)
        {
            return context.Tbl_SaleReturn.Where(x => x.Status.Trim() == "A" && x.SaleMaster_InvoiceNo == invoiceNo).ToList();
        }

        public List<Qry_SaleReturnMasterDetails> GetAllSaleReturnMasterDetails()
        {
            return context.Qry_SaleReturnMasterDetails.ToList();
        }

        public List<Qry_SaleReturnMasterDetails> GetAllSaleReturnMasterDetails(string invoiceNo)
        {
            return context.Qry_SaleReturnMasterDetails.Where(x => x.SaleMaster_InvoiceNo == invoiceNo).ToList();
        }

        public int InsertOrUpdateSaleReturn(Tbl_SaleReturn aTbl_SaleReturn)
        {
            if (aTbl_SaleReturn.SaleReturn_SlNo != 0)
            {
                context.Tbl_SaleReturn.Attach(aTbl_SaleReturn);
                context.Entry(aTbl_SaleReturn).State = EntityState.Modified;
            }
            else
            {
                context.Tbl_SaleReturn.Add(aTbl_SaleReturn);
            }
            return context.SaveChanges();
        }

        public int InsertOrUpdateSaleReturnDetails(List<Tbl_SaleReturnDetails> lstTbl_SaleReturnDetails)
        {
            foreach (var aTbl_SaleReturnDetails in lstTbl_SaleReturnDetails)
            {
                if (aTbl_SaleReturnDetails.SaleReturnDetails_SlNo == 0)
                {
                    context.Tbl_SaleReturnDetails.Add(aTbl_SaleReturnDetails);
                }
                else
                {
                    context.Tbl_SaleReturnDetails.Attach(aTbl_SaleReturnDetails);
                    context.Entry(aTbl_SaleReturnDetails).State = EntityState.Modified;
                }
            }
            return context.SaveChanges();
        }

        public void SaveSaleReturn(List<Tbl_SaleReturn> lstmaster, List<Tbl_SaleReturnDetails> lstdetails, List<Tbl_SaleInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            var master = new SqlParameter("tvpSaleReturn", SqlDbType.Structured);
            master.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SaleReturn>(lstmaster);
            master.TypeName = "dbo.Tbl_SaleReturnType";

            var detail = new SqlParameter("tvpSaleReturnDetails", SqlDbType.Structured);
            detail.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SaleReturnDetails>(lstdetails);
            detail.TypeName = "dbo.Tbl_SaleReturnDetailsType";

            var inventory = new SqlParameter("tvpSaleInventory", SqlDbType.Structured);
            inventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SaleInventory>(lstinventory);
            inventory.TypeName = "dbo.Tbl_SaleInventoryType";

            var curinventory = new SqlParameter("tvpCurrentInventory", SqlDbType.Structured);
            curinventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_CurrentInventory>(lstcurInventory);
            curinventory.TypeName = "dbo.Tbl_CurrentInventoryType";

            context.Database.ExecuteSqlCommand("exec Func_SaleReturn @tvpSaleReturn,@tvpSaleReturnDetails,@tvpSaleInventory,@tvpCurrentInventory  ", master, detail, inventory, curinventory);

        }
        #endregion

        #region Qry_SaleMasterDetails

        public List<Qry_SaleMasterDetails> GetAllQrySaleMasterDetails()
        {
            return context.Qry_SaleMasterDetails.ToList();
        }

        public List<GetSaleMasterDetails> GetAllSaleMasterDetails()
        {
            return context.GetSaleMasterDetails().ToList();
        }

        public List<Get_SaleMaster> Get_AllSaleMaster()
        {
            return context.Get_SaleMaster().ToList();

        }

        public List<Qry_SalesPurchaseDetails> GetAllQry_SalesPurchaseDetails()
        {
            return context.Qry_SalesPurchaseDetails.OrderBy(x => x.ProductCategory_Name).ToList();
        }

        public List<Qry_SaleMasterDetails> GetAllSaleMasterDetails(string productid)
        {
            return context.Qry_SaleMasterDetails.Where(x => x.Product_Code == productid).ToList();
        }

        public List<Qry_SaleMasterDetails> GetAllSaleMasterDetailsByInvoice(string invoiceid)
        {
            return context.Qry_SaleMasterDetails.Where(x => x.SaleMaster_InvoiceNo == invoiceid).ToList();
        }

        #endregion


        public void SaveSale(List<Tbl_SalesMaster> lstmaster, List<Tbl_SaleDetails> lstdetails, List<Tbl_SaleInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            var master = new SqlParameter("tvpSaleMaster", SqlDbType.Structured);
            master.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SalesMaster>(lstmaster);
            master.TypeName = "dbo.Tbl_SaleMasterType";

            var detail = new SqlParameter("tvpSaleDetails", SqlDbType.Structured);
            detail.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SaleDetails>(lstdetails);
            detail.TypeName = "dbo.Tbl_SaleDetailsType";

            var inventory = new SqlParameter("tvpSaleInventory", SqlDbType.Structured);
            inventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_SaleInventory>(lstinventory);
            inventory.TypeName = "dbo.Tbl_SaleInventoryType";

            var curinventory = new SqlParameter("tvpCurrentInventory", SqlDbType.Structured);
            curinventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_CurrentInventory>(lstcurInventory);
            curinventory.TypeName = "dbo.Tbl_CurrentInventoryType";

            context.Database.ExecuteSqlCommand("exec Func_SalesInsert @tvpSaleMaster,@tvpSaleDetails,@tvpSaleInventory,@tvpCurrentInventory  ", master, detail, inventory, curinventory);

        }


        #region Tbl_SalesChallan

        public int InsertSaleChallan(Tbl_SalesChallan aTbl_SalesChallan)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_SalesChallan.Add(aTbl_SalesChallan);
            return context.SaveChanges();
        }

        public Tbl_SalesChallan GetLastSalesChallan()
        {
            return context.Tbl_SalesChallan.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.ChallanId).FirstOrDefault();
        }

        public Tbl_QuotationMaster GetLastQuotationNo()
        {
            return context.Tbl_QuotationMaster.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.QuotationMaster_SlNo).FirstOrDefault();
        }

        #endregion

        #region QuotationMaster

        public int InsertQuotationMaster(Tbl_QuotationMaster aTbl_QuotationMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_QuotationMaster.Add(aTbl_QuotationMaster);
            return context.SaveChanges();
        }

        public int UpdateQuotationMaster(Tbl_QuotationMaster aTbl_QuotationMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_QuotationMaster.Attach(aTbl_QuotationMaster);
            context.Entry(aTbl_QuotationMaster).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public Tbl_QuotationMaster GetAllQuotationMaster(int id)
        {
            return context.Tbl_QuotationMaster.Where(x => x.QuotationMaster_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }

        public List<Tbl_QuotationMaster> GetAllQuotationMaster()
        {
            return context.Tbl_QuotationMaster.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.QuotationMaster_InvoiceNo).ToList();
        }

        public int InsertQuotationDetail(List<Tbl_QuotationDetails> lstTbl_QuotationDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_QuotationDetails aTbl_QuotationDetails in lstTbl_QuotationDetails)
            {
                context.Tbl_QuotationDetails.Add(aTbl_QuotationDetails);
            }
            return context.SaveChanges();
        }

        public int UpdateQuotationDetail(List<Tbl_QuotationDetails> lstTbl_QuotationDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            foreach (Tbl_QuotationDetails aTbl_QuotationDetails in lstTbl_QuotationDetails)
            {
                context.Tbl_QuotationDetails.Attach(aTbl_QuotationDetails);
                context.Entry(aTbl_QuotationDetails).State = EntityState.Modified;
            }
            return context.SaveChanges();

        }

        public Tbl_QuotationDetails GetAllTbl_QuotationDetailsByid(int id)
        {
            return context.Tbl_QuotationDetails.Where(x => x.QuotationDetails_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();

        }

        public List<Tbl_QuotationDetails> GetAllQryQuotationDetails(int id)
        {
            return context.Tbl_QuotationDetails.Where(x => x.QuotationMaster_SlNo == id).ToList();
        }

        public List<Get_SaleInvoiceByQuotation> GetQuotationByNo(string quotationNo)
        {
            return context.Get_SaleInvoiceByQuotation().Where(x => x.QuotationMaster_InvoiceNo == quotationNo).ToList();
        }

        public List<Get_SaleInvoiceByQuotation> GetAllQuotationDetails()
        {
            return context.Get_SaleInvoiceByQuotation().OrderByDescending(x => x.QuotationMaster_Date).ToList();
        }

        #endregion
    }
}
