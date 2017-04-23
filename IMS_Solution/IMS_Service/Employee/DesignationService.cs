using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
  public class DesignationService:IDisposable
    {
      IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~DesignationService()
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

        public List<Tbl_Designation> GetAllDesignation()
        {
          return  context.Tbl_Designation.Where(x => x.Status.Trim() == "A").OrderBy(x => x.Designation_Name).ToList();
        }
        public Tbl_Designation GetAllDesignation(int autoId)
        {
            return context.Tbl_Designation.Where(x =>
                x.Designation_SlNo==autoId && 
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Designation GetAllDesignation(string name)
        {
            return context.Tbl_Designation.Where(x =>
                x.Designation_Name==name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Designation GetAllDesignation(int autoId, string name)
        {
            return context.Tbl_Designation.Where(x =>
                x.Designation_SlNo != autoId && 
                x.Designation_Name==name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Designation aTbl_Designation)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Designation.Add(aTbl_Designation);
            return context.SaveChanges();
        }
        public int Update(Tbl_Designation aTbl_Designation)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Designation.Attach(aTbl_Designation);
            context.Entry(aTbl_Designation).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
