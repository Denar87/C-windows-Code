using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class ProductService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
       ~ProductService()
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

        public List<Tbl_Product> GetAllProduct()
        {
            return context.Tbl_Product.Where(x => x.Status.Trim() == "A").OrderBy(x => x.Product_Name).ToList();
        }

        public List<Qry_Product> GetAllProductByCategory()
        {
            return context.Qry_Product.OrderBy(x => x.ProductCategory_Name).ToList();
        }

        public List<Tbl_Product> GetAllProductByCode(string productCode)
        {
            return context.Tbl_Product.Where(x => x.Status.Trim() == "A" && x.Product_Code.StartsWith(productCode)).ToList();
        }

        public List<Qry_Product> GetAllQryProductByCode(string productCode)
        {
            return context.Qry_Product.Where(x => x.Product_Code.StartsWith(productCode) || x.Product_Name.StartsWith(productCode)).ToList();
        }

        public List<Qry_Product> GetAllQryProductByName(string productName)
        {
            return context.Qry_Product.Where(x => x.Product_Code.StartsWith(productName) || x.Product_Name.StartsWith(productName)).ToList();
        }
        public List<Qry_Product> GetAllQryProductByProductType(string productCode, bool product)
        {
            return context.Qry_Product.Where(x => x.Product_IsFinishedGoods == product && (x.Product_Code.StartsWith(productCode) || x.Product_Name.StartsWith(productCode))).ToList();
        }

        public List<Qry_Product> GetAllQryProductService(string productCode, bool service)
        {
            return context.Qry_Product.Where(x => x.Product_IsRawMaterial == service && (x.Product_Code.StartsWith(productCode) || x.Product_Name.StartsWith(productCode))).ToList();
        }

        public List<Qry_Product> GetAllQryProduct()
        {
            return context.Qry_Product.ToList();
        }

        public List<Func_TotalStock> GetAllFunc_TotalStock()
        {
          return context.Func_TotalStock().OrderBy(x => x.ProductCategory_Name).ToList();
        }

        public List<Func_TotalStockwithValue> GetAllStockwithValue()
        {
            return context.Func_TotalStockwithValue().OrderBy(x => x.ProductCategory_Name).ToList();
        }

        public List<func_GetReorderProduct> GetAllReOrderProduct()
        {
            return context.func_GetReorderProduct().OrderBy(x => x.ProductCategory_Name).ToList();
        }

        public Tbl_Product GetLastProduct()
        {
            return context.Tbl_Product.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Product_SlNo).FirstOrDefault();
        }

        public List<Tbl_Product> GetProductByCategoryID(int id)
        {
            return context.Tbl_Product.Where(x => x.ProductCategory_SlNo == id && x.Status.Trim()=="A").ToList();
        }

        public List<Tbl_Product> GetProductByUnit(int id)
        {
            return context.Tbl_Product.Where(x => x.Unit_SlNo == id && x.Status.Trim() == "A").ToList();
        }

        public Tbl_Product GetAllProduct(int autoId)
        {
            return context.Tbl_Product.Where(x => x.Product_SlNo == autoId && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Product GetAllProductCode(string productCode)
        {
            return context.Tbl_Product.Where(x => x.Product_Code == productCode && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Product GetAllProduct(string name)
        {
            return context.Tbl_Product.Where(x => x.Product_Name == name && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Product GetAllProductById(string productId)
        {
            return context.Tbl_Product.Where(x => x.Product_Code == productId && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Product GetAllProduct(int autoId, string productCode, string name)
        {
            return context.Tbl_Product.Where(x => x.Product_SlNo != autoId && x.Product_Code != productCode && x.Product_Name == name && x.Status.Trim() == "A").FirstOrDefault();
        }

        public int Insert(Tbl_Product aTbl_Product)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Product.Add(aTbl_Product);
            return context.SaveChanges();
        }

        public int Update(Tbl_Product aTbl_Product)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Product.Attach(aTbl_Product);
            context.Entry(aTbl_Product).State = EntityState.Modified;
            return context.SaveChanges();
        }

    }
}
