using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
   public class CurrentInventoryService:IDisposable
    {
         IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
         ~CurrentInventoryService()
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
        public Tbl_CurrentInventory GetInventoryByProductId(int productId)
        {
            return context.Tbl_CurrentInventory.Where(x => x.Product_SlNo == productId).FirstOrDefault();
        }

        public GetItemCurrentStock GetInventoryByProductId2(int productId)
        {
            return context.GetItemCurrentStock().Where(x => x.Product_SlNo == productId).FirstOrDefault();
        }

        public List<Tbl_CurrentInventory> GetInventoryByProductId1(int productId)
        {
            return context.Tbl_CurrentInventory.Where(x => x.Product_SlNo == productId).ToList();
        }
        public List<Qry_CurrentInventory> GetAllQryCurrentInventory()
        {
            return context.Qry_CurrentInventory.OrderBy(x => x.ProductCategory_Name).ToList();
        }
        
        public int InsertorUpdateCurretnInventory(List<Tbl_CurrentInventory> lstCurrentInventoryList)
        {
            foreach (Tbl_CurrentInventory inv in lstCurrentInventoryList)
            {
                if (inv.CurrentInventory_SlNo == 0)
                {
                    context.Tbl_CurrentInventory.Add(inv);
                }
                else
                {
                    context.Tbl_CurrentInventory.Attach(inv);
                    context.Entry(inv).State = EntityState.Modified;
                }
            }
            return context.SaveChanges();
        }
    }
}
