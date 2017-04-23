using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
   public class SupplierService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~SupplierService()
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

        public List<Qry_Supplier> GetAllSupplierbyCode(string code)
        {
            return context.Qry_Supplier.Where(x => x.Supplier_Code.StartsWith(code) || x.Supplier_Name.StartsWith(code)).ToList();
        }

        public List<Qry_Supplier> GetSupplierbyCode(string code)
        {
            return context.Qry_Supplier.Where(x => x.Supplier_Code!="S0001" && (x.Supplier_Code.StartsWith(code) || x.Supplier_Name.StartsWith(code))).ToList();
        }

        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyID(string code)
        {
            return context.Qry_SupplierTotalPurchaseList.Where(x => x.Supplier_Code == code).ToList();
        }

        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyName(string name)
        {
            return context.Qry_SupplierTotalPurchaseList.Where(x => x.Supplier_Name == name).ToList();
        }

        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyMobile(string mobile)
        {
            return context.Qry_SupplierTotalPurchaseList.Where(x => x.Supplier_Mobile == mobile).ToList();
        }

        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyDistrict(string district)
        {
            return context.Qry_SupplierTotalPurchaseList.Where(x => x.District_Name == district).OrderBy(x=>x.Supplier_Name).ToList();
        }

        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyCountry(string country)
        {
            return context.Qry_SupplierTotalPurchaseList.Where(x => x.CountryName == country).OrderBy(x => x.Supplier_Name).ToList();
        }

        public Tbl_Supplier GetLastSupplier()
        {
            return context.Tbl_Supplier.Where(x=>x.Status.Trim()=="A").OrderByDescending(x=>x.Supplier_SlNo).FirstOrDefault();
        }
        public List<Qry_Supplier> GetAllSupplierbyType(string code, string type)
        {
            return context.Qry_Supplier.Where(x => x.Supplier_Type == type && (x.Supplier_Code.StartsWith(code) || x.Supplier_Name.StartsWith(code) || x.Supplier_Mobile.StartsWith(code))).ToList();
        }
        public List<Qry_Supplier> GetAllQrySupplier()
        {
            return context.Qry_Supplier.ToList();
        }
        public List<Qry_SupplierTotalPurchaseList> GetAllSupplierTotalPurchase()
        {
            return context.Qry_SupplierTotalPurchaseList.OrderBy(x=>x.Supplier_Name).ToList();
        }
        public List<Qry_SupplierDue> GetAllQrySupplierDue()
        {
            return context.Qry_SupplierDue.OrderBy(x=>x.Supplier_Name).ToList();
        }
        public List<Qry_SupplierDue> GetAllQrySupplierDueBySupplier(int SupplierID)
        {
            return context.Qry_SupplierDue.Where(x => x.Supplier_SlNo == SupplierID).ToList();
        }

        public List<Qry_SupplierDue> GetAllQrySupplierDueBySupplierCode(string SupplierCode)
        {
            return context.Qry_SupplierDue.Where(x => x.Supplier_Code == SupplierCode).ToList();
        }
        public List<Tbl_Supplier> GetAllSupplierByDistrict(int id)
        {
            return context.Tbl_Supplier.Where(x => x.District_SlNo == id).ToList();
        }
        public List<Qry_SupplierPayment> GetAllSupplierPayment()
        {
            return context.Qry_SupplierPayment.OrderBy(x => x.Supplier_Name).ToList();
        }
        public List<Qry_SupplierPayment> GetAllSupplierPaymentByID(int supplierid)
        {
            return context.Qry_SupplierPayment.Where(x => x.Supplier_SlNo == supplierid).ToList();
        }
        public List<Tbl_Supplier> GetAllSupplierByCountry(int id)
        {
            return context.Tbl_Supplier.Where(x => x.Country_SlNo == id).ToList();
        }
        public List<Tbl_Supplier> GetAllSupplier()
        {
            return context.Tbl_Supplier.Where(x => x.Status.Trim() == "A").OrderBy(x => x.Supplier_Name).ToList();
        }
        public Tbl_Supplier GetAllSupplier(int autoId)
        {
            return context.Tbl_Supplier.Where(x =>
                x.Supplier_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Supplier GetAllSupplierCode(string code)
        {
            return context.Tbl_Supplier.Where(x => x.Supplier_Code == code && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Supplier GetAllSupplier(string name)
        {
            return context.Tbl_Supplier.Where(x =>
                x.Supplier_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        
        public Tbl_Supplier GetAllSupplier(int autoId, string code, string name)
        {
            return context.Tbl_Supplier.Where(x =>
                x.Supplier_SlNo != autoId &&
                x.Supplier_Code!=code &&
                x.Supplier_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Supplier aTbl_Supplier)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Supplier.Add(aTbl_Supplier);
            return context.SaveChanges();
        }
        public int Update(Tbl_Supplier aTbl_Supplier)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Supplier.Attach(aTbl_Supplier);
            context.Entry(aTbl_Supplier).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
