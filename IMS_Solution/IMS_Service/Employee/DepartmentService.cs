using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class DepartmentService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~DepartmentService()
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

        public List<Tbl_Department> GetAllDepartment()
        {
            return context.Tbl_Department.Where(x => x.Status.Trim() == "A").OrderBy(x => x.Department_Name).ToList();
        }
        public Tbl_Department GetAllDepartment(int autoId)
        {
            return context.Tbl_Department.Where(x =>
                x.Department_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Department GetAllDepartment(string name)
        {
            return context.Tbl_Department.Where(x =>
                x.Department_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Department GetAllDepartment(int autoId, string name)
        {
            return context.Tbl_Department.Where(x =>
                x.Department_SlNo != autoId &&
                x.Department_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Department aTbl_Department)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Department.Add(aTbl_Department);
            return context.SaveChanges();
        }
        public int Update(Tbl_Department aTbl_Department)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Department.Attach(aTbl_Department);
            context.Entry(aTbl_Department).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
