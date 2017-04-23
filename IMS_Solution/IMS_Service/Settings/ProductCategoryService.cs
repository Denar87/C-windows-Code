using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class ProductCategoryService : IDisposable
    {
        IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
        ~ProductCategoryService()
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

        public List<Tbl_ProductCategory> GetAllProductCategory()
        {
            return context.Tbl_ProductCategory.Where(x => x.Status.Trim() == "A").OrderBy(x=>x.ProductCategory_Name).ToList();
        }
        public Tbl_ProductCategory GetAllProductCategory(int autoId)
        {
            return context.Tbl_ProductCategory.Where(x =>x.ProductCategory_SlNo == autoId && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_ProductCategory GetAllProductCategory(string name)
        {
            return context.Tbl_ProductCategory.Where(x =>
                x.ProductCategory_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_ProductCategory GetAllProductCategory(int autoId, string name)
        {
            return context.Tbl_ProductCategory.Where(x =>
                x.ProductCategory_SlNo != autoId &&
                x.ProductCategory_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_ProductCategory aTbl_ProductCategory)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_ProductCategory.Add(aTbl_ProductCategory);
            return context.SaveChanges();
        }
        public int Update(Tbl_ProductCategory aTbl_ProductCategory)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_ProductCategory.Attach(aTbl_ProductCategory);
            context.Entry(aTbl_ProductCategory).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
