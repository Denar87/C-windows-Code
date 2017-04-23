using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IMS_Entity;

namespace IMS_Service
{
    public class DistrictService:IDisposable
    {
         IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
         ~DistrictService()
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

        public List<Tbl_District> GetAllDistrict()
        {
            return context.Tbl_District.Where(x => x.Status.Trim() == "A").OrderBy(x => x.District_Name).ToList();
        }
        public Tbl_District GetAllDistrict(int autoId)
        {
            return context.Tbl_District.Where(x =>
                x.District_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_District GetAllDistrict(string name)
        {
            return context.Tbl_District.Where(x =>
                x.District_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_District GetAllDistrict(int autoId, string name)
        {
            return context.Tbl_District.Where(x =>
                x.District_SlNo != autoId &&
                x.District_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_District aTbl_District)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_District.Add(aTbl_District);
            return context.SaveChanges();
        }
        public int Update(Tbl_District aTbl_District)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_District.Attach(aTbl_District);
            context.Entry(aTbl_District).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
