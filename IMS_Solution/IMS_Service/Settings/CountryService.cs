using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class CountryService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();
        
        #region Memory Optimizer
        ~CountryService()
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

        public List<Tbl_Country> GetAllCountry()
        {
            return context.Tbl_Country.Where(x => x.Status.Trim() == "A").OrderBy(x => x.CountryName).ToList();
        }
        public Tbl_Country GetAllCountry(int autoId)
        {
            return context.Tbl_Country.Where(x =>
                x.Country_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Country GetAllCountry(string name)
        {
            return context.Tbl_Country.Where(x =>
                x.CountryName == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Country GetAllCountry(int autoId, string name)
        {
            return context.Tbl_Country.Where(x =>
                x.Country_SlNo != autoId &&
                x.CountryName == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Country aTbl_Country)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Country.Add(aTbl_Country);
            return context.SaveChanges();
        }
        public int Update(Tbl_Country aTbl_Country)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Country.Attach(aTbl_Country);
            context.Entry(aTbl_Country).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
