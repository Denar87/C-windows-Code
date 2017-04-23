using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class CompanyService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
        ~CompanyService()
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

        public List<Tbl_Company> GetAllCompany()
        {
            return context.Tbl_Company.ToList();
        }
        
        public Tbl_Company GetAllCompanyByInvoiceType()
        {
            return context.Tbl_Company.FirstOrDefault();
        }
        public Tbl_Company GetAllCompany(int autoId)
        {
            return context.Tbl_Company.Where(x => x.Company_SlNo == autoId).FirstOrDefault();
        }
        public Tbl_Company GetAllCompany(string name)
        {
            return context.Tbl_Company.Where(x =>x.Company_Name == name).FirstOrDefault();
        }
        public Tbl_Company GetAllCompany(int autoId, string name)
        {
            return context.Tbl_Company.Where(x => x.Company_SlNo != autoId && x.Company_Name == name).FirstOrDefault();
        }
        public int Insert(Tbl_Company aTbl_Company)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
           
                context.Tbl_Company.Add(aTbl_Company);
           
            return context.SaveChanges();
        }
        public int InsertorUpdate(Tbl_Company aTbl_Company)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            if (aTbl_Company.Company_SlNo == 0)
            {
                context.Tbl_Company.Add(aTbl_Company);
            }
            else
            {
                context.Tbl_Company.Attach(aTbl_Company);
                context.Entry(aTbl_Company).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }
        public int Update(Tbl_Company aTbl_Company)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Company.Attach(aTbl_Company);
            context.Entry(aTbl_Company).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
