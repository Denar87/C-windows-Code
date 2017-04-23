using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class DamageService
    {
        IMS_Entities context = new IMS_Entities();
         #region Memory Optimizer
        ~DamageService()
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

        public Tbl_Damage GetLastDamageProduct()
        {
            return context.Tbl_Damage.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Damage_SlNo).FirstOrDefault();
        }

        public List<Tbl_Damage> GetAllDamage()
        {
            return context.Tbl_Damage.Where(x => x.Status.Trim() == "A").ToList();

        }
        public List<Get_DamagedProduct> GetDamageProduct()
        {
            return context.Get_DamagedProduct().OrderBy(x=>x.ProductCategory_Name).ToList();
        }
        public Tbl_Damage GetAllDamage(int autoid)
        {
            return context.Tbl_Damage.Where(x => x.Damage_SlNo == autoid && x.Status.Trim() == "A").FirstOrDefault();
        }

        public int InsertDamage(Tbl_Damage aTbl_Damage)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_Damage.Add(aTbl_Damage);
            return context.SaveChanges();
        }
        public int InsertDamageDetail(List<Tbl_DamageDetails> lstTbl_DamageDetails)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            foreach (Tbl_DamageDetails aTbl_DamageDetails in lstTbl_DamageDetails)
            {
                context.Tbl_DamageDetails.Add(aTbl_DamageDetails);
            }
            return context.SaveChanges();
        }
    }
}
