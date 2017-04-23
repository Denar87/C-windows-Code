using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class ProductCategoryBusiness
    {
        ProductCategoryService aProductCategoryService = new ProductCategoryService();
        ~ProductCategoryBusiness()
        {
            aProductCategoryService.Dispose();
            aProductCategoryService = null;
        }

        public string validateOnSave(Tbl_ProductCategory aTbl_ProductCategory)
        {
            if (aTbl_ProductCategory.ProductCategory_Name == string.Empty)
            {
                return "Enter Product Category";
            }
            if (GetAllProductCategory(aTbl_ProductCategory.ProductCategory_Name) != null)
            {
                return "Product Category already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_ProductCategory aTbl_ProductCategory)
        {
            if (aTbl_ProductCategory.ProductCategory_Name == string.Empty)
            {
                return "Enter Product Category";
            }
            if (GetAllProductCategory(aTbl_ProductCategory.ProductCategory_SlNo, aTbl_ProductCategory.ProductCategory_Name) != null)
            {
                return "Product Category already exist";
            }
            return string.Empty;
        }
        public List<Tbl_ProductCategory> GetAllProductCategory()
        {
            return aProductCategoryService.GetAllProductCategory();
        }
        public Tbl_ProductCategory GetAllProductCategory(int autoid)
        {
            return aProductCategoryService.GetAllProductCategory(autoid);
        }
        public Tbl_ProductCategory GetAllProductCategory(string name)
        {
            return aProductCategoryService.GetAllProductCategory(name);
        }
        public Tbl_ProductCategory GetAllProductCategory(int autoId, string name)
        {
            return aProductCategoryService.GetAllProductCategory(autoId, name);
        }
        public bool Insert(Tbl_ProductCategory aTbl_ProductCategory)
        {
            return aProductCategoryService.Insert(aTbl_ProductCategory) > 0;
        }
        public bool Update(Tbl_ProductCategory aTbl_ProductCategory)
        {
            return aProductCategoryService.Update(aTbl_ProductCategory) > 0;
        }
    }
}
