using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;
namespace IMS_Business
{
   public class ProductBusiness
    {
       ProductService aProductService = new ProductService();
       ~ProductBusiness()
       {
           aProductService.Dispose();
           aProductService = null;
       }
       public List<Tbl_Product> GetAllProductByCode(string productCode)
       {
           return aProductService.GetAllProductByCode(productCode);
       }
       public List<Qry_Product> GetAllQryProductByCode(string productCode)
       {
           return aProductService.GetAllQryProductByCode(productCode);
       }
       public List<Qry_Product> GetAllQryProductByName(string productName)
       {
           return aProductService.GetAllQryProductByName(productName);
       }
       public List<Qry_Product> GetAllQryProductByProductType(string productCode, bool product)
       {
           return aProductService.GetAllQryProductByProductType(productCode, product);
       }
       public List<Qry_Product> GetAllQryProductService(string productCode, bool service)
       {
           return aProductService.GetAllQryProductService(productCode, service);
       }

       public string validateOnSave(Tbl_Product aTbl_Product)
       {
           if (aTbl_Product.Product_Name == "")
           {
               return "Enter Product Name";
           }

           if (GetAllProduct(aTbl_Product.Product_Name) != null)
           {
               return "Product name already exist";
           }
           if (GetAllProductById(aTbl_Product.Product_Code) != null)
           {
               return "Product Id already exist";
           }
           return string.Empty;
       }

       public string validateOnUpdate(Tbl_Product aTbl_Product)
       {
           if (aTbl_Product.Product_Name == "")
           {
               return "Enter Product Name";
           }

           if (GetAllProduct(aTbl_Product.Product_SlNo, aTbl_Product.Product_Code, aTbl_Product.Product_Name) != null)
           {
               return "Product name already exist";
           }
           return string.Empty;
       }

       public List<Tbl_Product> GetAllProductByCategoryID(int id)
       {
           return aProductService.GetProductByCategoryID(id);
       }
       public List<Tbl_Product> GetAllProductByUnit(int id)
       {
           return aProductService.GetProductByUnit(id);
       }
       public List<Tbl_Product> GetAllProduct()
       {
           return aProductService.GetAllProduct();
       }

       public List<Qry_Product> GetAllProductByCategory()
       {
           return aProductService.GetAllProductByCategory();
       }
       public Tbl_Product GetAllProduct(int autoid)
       {
           return aProductService.GetAllProduct(autoid);
       }
       public Tbl_Product GetAllProduct(string name)
       {
           return aProductService.GetAllProduct(name);
       }
       public Tbl_Product GetAllProductById(string productId)
       {
           return aProductService.GetAllProductById(productId);
       }
       public Tbl_Product GetAllProductCode(string productCode)
       {
           return aProductService.GetAllProductCode(productCode);
       }
       public Tbl_Product GetAllProduct(int autoId, string productCode, string name)
       {
           return aProductService.GetAllProduct(autoId, productCode, name);
       }
       public bool Insert(Tbl_Product aTbl_Product)
       {
           return aProductService.Insert(aTbl_Product) > 0;
       }
       public bool Update(Tbl_Product aTbl_Product)
       {
           return aProductService.Update(aTbl_Product) > 0;
       }
      
       public Tbl_Product GetLastProduct()
       {
           return aProductService.GetLastProduct();
       }
       public string GenerateProductCode()
       {
           Tbl_Product Product = GetLastProduct();
           string prefix = "P";
           string subprefix = string.Empty;
           int cnt = 0;
           string code = string.Empty;
           if (Product != null)
           {
               subprefix = Product.Product_Code;
               subprefix = subprefix.Substring(1).ToString();
               cnt = Convert.ToInt32(subprefix);
               cnt++;
               code = prefix + cnt.ToString("0000");
           }
           else
           {
               cnt++;

               code = prefix + cnt.ToString("0000");
           }
           return code;
       }

       public List<Qry_Product> GetAllQryProduct()
       {
          return aProductService.GetAllQryProduct();
       }

       public List<Func_TotalStock> GetAllFunc_TotalStock()
       {
          return aProductService.GetAllFunc_TotalStock();
       }

       public List<Func_TotalStockwithValue> GetAllStockwithValue()
       {
           return aProductService.GetAllStockwithValue();
       }
       public List<func_GetReorderProduct> GetAllReOrderProduct()
       {
           return aProductService.GetAllReOrderProduct();
       }
    }
}
