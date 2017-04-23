using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class UnitOfMeasurementService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~UnitOfMeasurementService()
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


        public List<Tbl_Unit> GetAllUnit()
        {
            return context.Tbl_Unit.Where(x => x.Status.Trim() == "A").OrderBy(x=> x.Unit_Name).ToList();
        }
        public Tbl_Unit GetAllUnit(int autoId)
        {
            return context.Tbl_Unit.Where(x =>
                x.Unit_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Unit GetAllUnit(string name)
        {
            return context.Tbl_Unit.Where(x =>
                x.Unit_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Unit GetAllUnit(int autoId, string name)
        {
            return context.Tbl_Unit.Where(x =>
                x.Unit_SlNo!= autoId &&
                x.Unit_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Unit aTbl_Unit)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Unit.Add(aTbl_Unit);
            return context.SaveChanges();
        }
        public int Update(Tbl_Unit aTbl_Unit)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Unit.Attach(aTbl_Unit);
            context.Entry(aTbl_Unit).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
