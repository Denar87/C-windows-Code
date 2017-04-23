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
   public class PurchaseService:IDisposable
    {
         IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
         ~PurchaseService()
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

        #region PurchaseMaster

        public Tbl_PurchaseMaster GetLastPurchaseMaster()
        {
            return context.Tbl_PurchaseMaster.Where(x => x.Status.Trim() == "A").OrderByDescending(x=>x.PurchaseMaster_SlNo).FirstOrDefault();
        }
        public Tbl_PurchaseMaster GetAllPurchaseMaster(string voucherId)
        {
            return context.Tbl_PurchaseMaster.Where(x => x.PurchaseMaster_InvoiceNo == voucherId && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_PurchaseMaster GetAllPurchaseMaster(int id)
        {
            return context.Tbl_PurchaseMaster.Where(x => x.PurchaseMaster_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_PurchaseMaster GetPurchaseMaster()
        {
            return context.Tbl_PurchaseMaster.Where(x => x.Status.Trim() == "A").FirstOrDefault();
        }

        public List<Tbl_PurchaseMaster> GetAllPurchaseMaster()
        {
            return context.Tbl_PurchaseMaster.Where(x=>x.Status.Trim()=="A").OrderByDescending(x=>x.PurchaseMaster_InvoiceNo).ToList();
        }
        public List<Tbl_PurchaseMaster> GetAllPurchaseMasterByID(int id)
        {
            return context.Tbl_PurchaseMaster.Where(x => x.PurchaseMaster_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseMaster> GetAllPurchaseMasterBySupplier(int supplier)
        {
            return context.Tbl_PurchaseMaster.Where(x =>x.Supplier_SlNo==supplier && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseMaster> GetAllEmployeeByPurchase(int employee)
        {
            return context.Tbl_PurchaseMaster.Where(x => x.Employee_SlNo == employee && x.Status.Trim() == "A").ToList();
        }

        public Qry_PurchaseMaster GetAllQryPurchaseMaster(int id)
        {
            return context.Qry_PurchaseMaster.Where(x => x.PurchaseMaster_SlNo == id).FirstOrDefault();
        }
        public List<Qry_PurchaseInvoice> GetAllQryPurchaseInvoiceByInvoice(string voucherId)
        {
            return context.Qry_PurchaseInvoice.Where(x => x.PurchaseMaster_InvoiceNo == voucherId).ToList();
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMaster()
        {
            return context.Qry_PurchaseMaster.ToList();
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMasterByid(int id)
        {
            return context.Qry_PurchaseMaster.Where(x => x.PurchaseMaster_SlNo == id).ToList();
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMaster(string invoiceNo)
        {
            return context.Qry_PurchaseMaster.Where(x=>x.PurchaseMaster_InvoiceNo==invoiceNo).ToList();
        }

        public int InsertPurchaseMaster(Tbl_PurchaseMaster aTbl_PurchaseMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_PurchaseMaster.Add(aTbl_PurchaseMaster);
            return context.SaveChanges();
        }
        public int UpdatePurchaseMaster(Tbl_PurchaseMaster aTbl_PurchaseMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_PurchaseMaster.Attach(aTbl_PurchaseMaster);
            context.Entry(aTbl_PurchaseMaster).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int UpdatePurchaseMaster(List<Tbl_PurchaseMaster> lstTbl_PurchaseMaster)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_PurchaseMaster aTbl_PurchaseMaster in lstTbl_PurchaseMaster)
            {
                context.Tbl_PurchaseMaster.Attach(aTbl_PurchaseMaster);
                context.Entry(aTbl_PurchaseMaster).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }

        public void SavePurchase(List<Tbl_PurchaseMaster> lstmaster, List<Tbl_PurchaseDetails> lstdetails, List<Tbl_PurchaseInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            var master = new SqlParameter("tvpPurchaseMaster", SqlDbType.Structured);
            master.Value = UtilityBusiness.GenericListToDataTable1 < Tbl_PurchaseMaster >(lstmaster);
            master.TypeName = "dbo.Tbl_PurchaseMasterType";

            var detail = new SqlParameter("tvpPurchaseDetails", SqlDbType.Structured);
            detail.Value = UtilityBusiness.GenericListToDataTable1 < Tbl_PurchaseDetails > (lstdetails);
            detail.TypeName = "dbo.Tbl_PurchaseDetailsType";

            var inventory = new SqlParameter("tvpPurchaseInventory", SqlDbType.Structured);
            inventory.Value = UtilityBusiness.GenericListToDataTable1 < Tbl_PurchaseInventory > (lstinventory);
            inventory.TypeName = "dbo.Tbl_PurchaseInventoryType";

            var curinventory = new SqlParameter("tvpCurrentInventory", SqlDbType.Structured);
            curinventory.Value = UtilityBusiness.GenericListToDataTable1 < Tbl_CurrentInventory >( lstcurInventory);
            curinventory.TypeName = "dbo.Tbl_CurrentInventoryType";

            context.Database.ExecuteSqlCommand("exec Func_PurchaseInsert @tvpPurchaseMaster,@tvpPurchaseDetails,@tvpPurchaseInventory,@tvpCurrentInventory  ", master, detail,inventory,curinventory);
        }

        #endregion

        #region Purchase Details

        public Tbl_PurchaseDetails GetAllPurchaseDetailsByProduct(int id)
        {
            return context.Tbl_PurchaseDetails.Where(x => x.Product_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_PurchaseDetails GetAllPurchaseDetailsByid(int id)
        {
            return context.Tbl_PurchaseDetails.Where(x => x.PurchaseDetails_SlNo == id && x.Status.Trim() == "A").FirstOrDefault();
        }

        public List<Tbl_PurchaseDetails> GetAllPurchaseDetails()
        {
            return context.Tbl_PurchaseDetails.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseDetails> GetAllPurchaseDetails(int id)
        {
            return context.Tbl_PurchaseDetails.Where(x => x.PurchaseMaster_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseDetails> GetAllPurchaseByProductid(int id)
        {
            return context.Tbl_PurchaseDetails.Where(x => x.Product_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Qry_PurchaseDetails> GetAllQry_PurchaseDetails(int id)
        {
            return context.Qry_PurchaseDetails.Where(x => x.PurchaseMaster_SlNo == id).ToList();
        }

        public int InsertPurchaseDetail(List<Tbl_PurchaseDetails> lstTbl_PurchaseDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_PurchaseDetails aTbl_PurchaseDetails in lstTbl_PurchaseDetails)
            {
                context.Tbl_PurchaseDetails.Add(aTbl_PurchaseDetails);
            }
            return context.SaveChanges();
        }

        public int UpdatePurchaseDetail(Tbl_PurchaseDetails aTbl_PurchaseDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_PurchaseDetails.Attach(aTbl_PurchaseDetails);
            context.Entry(aTbl_PurchaseDetails).State = EntityState.Modified;
            return context.SaveChanges();
        }
        public int UpdatePurchaseDetail(List<Tbl_PurchaseDetails> lstTbl_PurchaseDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_PurchaseDetails aTbl_PurchaseDetails in lstTbl_PurchaseDetails)
            {
                context.Tbl_PurchaseDetails.Attach(aTbl_PurchaseDetails);
                context.Entry(aTbl_PurchaseDetails).State = EntityState.Modified;
            }
           
            return context.SaveChanges();
        }

        #endregion

        #region Inventory

        public int InsertorUpdatePurchaseInventory(List<Tbl_PurchaseInventory> lstInventory)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_PurchaseInventory inventory in lstInventory)
            {
                if (inventory.PurchaseInventory_SlNo == 0)
                {
                    context.Tbl_PurchaseInventory.Add(inventory);
                }
                else
                {
                    context.Tbl_PurchaseInventory.Attach(inventory);
                    context.Entry(inventory).State = EntityState.Modified;
                }
            }
            return context.SaveChanges();
        }
        public Tbl_PurchaseInventory GetAllPurchaseInventory(int productId)
        {
            return context.Tbl_PurchaseInventory.Where(x => x.Product_SlNo == productId).FirstOrDefault();
        }

        public List<Qry_PurchaseInventory> GetAllQryPurchaseInventory()
        {
            return context.Qry_PurchaseInventory.OrderBy(x => x.ProductCategory_Name).ToList();
        }
        #endregion

        #region Purchase Return

        public List<Tbl_PurchaseReturnDetails> GetAllPurchaseReturnByProductID(int id)
        {
            return context.Tbl_PurchaseReturnDetails.Where(x => x.Product_SlNo == id && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseReturn> GetAllPurchaseReturn()
        {
            return context.Tbl_PurchaseReturn.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseReturn> GetAllPurchaseReturnbySupplier(int supplier)
        {
            return context.Tbl_PurchaseReturn.Where(x =>x.Supplier_SlNo==supplier && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_PurchaseReturn> GetAllPurchaseReturn(string invoiceNo)
        {
            return context.Tbl_PurchaseReturn.Where(x => x.Status.Trim() == "A" && x.PurchaseMaster_InvoiceNo == invoiceNo).ToList();
        }
        public List<Qry_PurchaseReturnMasterDetails> GetAllPurchaseReturnMasterDetails(string invoiceNo)
        {
            return context.Qry_PurchaseReturnMasterDetails.Where(x => x.PurchaseMaster_InvoiceNo == invoiceNo).ToList();
        }

        public List<Qry_PurchaseReturnMasterDetails> GetAllPurchaseReturnMasterDetails()
        {
            return context.Qry_PurchaseReturnMasterDetails.ToList();
        }

        public int InsertOrUpdatePurchaseReturn(Tbl_PurchaseReturn aTbl_PurchaseReturn)
        {
            if (aTbl_PurchaseReturn.PurchaseReturn_SlNo != 0)
            {
                context.Tbl_PurchaseReturn.Attach(aTbl_PurchaseReturn);
                context.Entry(aTbl_PurchaseReturn).State = EntityState.Modified;
            }
            else
            {
                context.Tbl_PurchaseReturn.Add(aTbl_PurchaseReturn);
            }
            return context.SaveChanges();
        }

        public int InsertOrUpdatePurchaseReturnDetails(List<Tbl_PurchaseReturnDetails> lstTbl_PurchaseReturnDetails)
        {
            foreach (var aTbl_PurchaseReturnDetails in lstTbl_PurchaseReturnDetails)
            {
                if (aTbl_PurchaseReturnDetails.PurchaseReturnDetails_SlNo == 0)
                {
                    context.Tbl_PurchaseReturnDetails.Add(aTbl_PurchaseReturnDetails);
                }
                else
                {
                    context.Tbl_PurchaseReturnDetails.Attach(aTbl_PurchaseReturnDetails);
                    context.Entry(aTbl_PurchaseReturnDetails).State = EntityState.Modified;
                }
            }
            return context.SaveChanges();
        }

        public void SavePurchaseReturn(List<Tbl_PurchaseReturn> lstmaster, List<Tbl_PurchaseReturnDetails> lstdetails, List<Tbl_PurchaseInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            var master = new SqlParameter("tvpPurchaseReturn", SqlDbType.Structured);
            master.Value = UtilityBusiness.GenericListToDataTable1<Tbl_PurchaseReturn>(lstmaster);
            master.TypeName = "dbo.Tbl_PurchaseReturnType";

            var detail = new SqlParameter("tvpPurchaseReturnDetails", SqlDbType.Structured);
            detail.Value = UtilityBusiness.GenericListToDataTable1<Tbl_PurchaseReturnDetails>(lstdetails);
            detail.TypeName = "dbo.Tbl_PurchaseReturnDetailsType";

            var inventory = new SqlParameter("tvpPurchaseInventory", SqlDbType.Structured);
            inventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_PurchaseInventory>(lstinventory);
            inventory.TypeName = "dbo.Tbl_PurchaseInventoryType";

            var curinventory = new SqlParameter("tvpCurrentInventory", SqlDbType.Structured);
            curinventory.Value = UtilityBusiness.GenericListToDataTable1<Tbl_CurrentInventory>(lstcurInventory);
            curinventory.TypeName = "dbo.Tbl_CurrentInventoryType";

            context.Database.ExecuteSqlCommand("exec Func_PurchaseReturn @tvpPurchaseReturn,@tvpPurchaseReturnDetails,@tvpPurchaseInventory,@tvpCurrentInventory  ", master, detail, inventory, curinventory);

        }
        #endregion

        #region Qry_PurchaseMasterDetails

        public List<Qry_PurchaseMasterDetails> GetAllQryPurchaseMasterDetails()
        {
            return context.Qry_PurchaseMasterDetails.ToList();
        }

        public List<Qry_PurchaseMasterDetails> GetAllPurchaseMasterDetails(string invoiceNo)
        {
            return context.Qry_PurchaseMasterDetails.Where(x => x.PurchaseMaster_InvoiceNo == invoiceNo).ToList();
        }

        public List<Qry_PurchaseMasterDetails> GetAllPurchaseMasterDetailsByProduct(string productid)
        {
            return context.Qry_PurchaseMasterDetails.Where(x => x.Product_Code == productid).ToList();
        }
        #endregion
    }
}
