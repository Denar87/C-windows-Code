using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
   public class SupplierBusiness
    {
       SupplierService aSupplierService = new SupplierService();
       ~SupplierBusiness()
       {
           aSupplierService.Dispose();
           aSupplierService = null;
       }

       public string validateOnSave(Tbl_Supplier aTbl_Supplier)
       {
           if (aTbl_Supplier.Supplier_Name == string.Empty)
           {
               return "Enter Supplier Name";
           }
           
           if (GetAllSupplier(aTbl_Supplier.Supplier_Name) != null)
           {
               return "Supplier name already exist";
           }
           return string.Empty;
       }

       public string validateOnUpdate(Tbl_Supplier aTbl_Supplier)
       {
           if (aTbl_Supplier.Supplier_Name == string.Empty)
           {
               return "Enter Supplier Name";
           }
           
           if (GetAllSupplier(aTbl_Supplier.Supplier_SlNo, aTbl_Supplier.Supplier_Code, aTbl_Supplier.Supplier_Name) != null)
           {
               return "Supplier name already exist";
           }
           return string.Empty;
       }
       public List<Qry_Supplier> GetAllQrySupplier()
       {
           return aSupplierService.GetAllQrySupplier();
       }
       public List<Qry_SupplierPayment> GetAllSupplierPayment()
       {
           return aSupplierService.GetAllSupplierPayment();
       }
       public List<Qry_SupplierPayment> GetAllSupplierPaymentByID(int supplierid)
       {
           return aSupplierService.GetAllSupplierPaymentByID(supplierid);
       }
       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyID(string id)
       {
           return aSupplierService.GetAllSupplierbyID(id);
       }

       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyName(string name)
       {
           return aSupplierService.GetAllSupplierbyName(name);
       }

       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyMobile(string mobile)
       {
           return aSupplierService.GetAllSupplierbyMobile(mobile);
       }

       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyDistrict(string district)
       {
           return aSupplierService.GetAllSupplierbyDistrict(district);
       }

       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierbyCountry(string country)
       {
           return aSupplierService.GetAllSupplierbyCountry(country);
       }

       public List<Qry_SupplierTotalPurchaseList> GetAllSupplierTotalPurchase()
       {
           return aSupplierService.GetAllSupplierTotalPurchase();
       }
       public List<Qry_SupplierDue> GetAllQrySupplierDue()
       {
           return aSupplierService.GetAllQrySupplierDue();
       }
       public List<Qry_SupplierDue> GetAllQrySupplierDueBySupplier(int SupplierID)
       {
           return aSupplierService.GetAllQrySupplierDueBySupplier(SupplierID);
       }

       public List<Qry_SupplierDue> GetAllQrySupplierDueBySupplierCode(string SupplierCode)
       {
           return aSupplierService.GetAllQrySupplierDueBySupplierCode(SupplierCode);
       }

       public List<Tbl_Supplier> GetAllSupplier()
       {
           return aSupplierService.GetAllSupplier();
       }
       public List<Tbl_Supplier> GetAllSupplierByDistrict(int id)
       {
           return aSupplierService.GetAllSupplierByDistrict(id);
       }
       public List<Tbl_Supplier> GetAllSupplierByCountry(int id)
       {
           return aSupplierService.GetAllSupplierByCountry(id);
       }
       public Tbl_Supplier GetAllSupplier(int autoid)
       {
           return aSupplierService.GetAllSupplier(autoid);
       }
       public Tbl_Supplier GetAllSupplier(string name)
       {
           return aSupplierService.GetAllSupplier(name);
       }
       public Tbl_Supplier GetAllSupplierCode(string code)
       {
           return aSupplierService.GetAllSupplierCode(code);
       }
       
       public Tbl_Supplier GetAllSupplier(int autoId, string code, string name)
       {
           return aSupplierService.GetAllSupplier(autoId, code, name);
       }
       public bool Insert(Tbl_Supplier aTbl_Supplier)
       {
           return aSupplierService.Insert(aTbl_Supplier) > 0;
       }
       public bool Update(Tbl_Supplier aTbl_Supplier)
       {
           return aSupplierService.Update(aTbl_Supplier) > 0;
       }

       public List<Qry_Supplier> GetAllSupplierbyType(string code, string type)
       {
           return aSupplierService.GetAllSupplierbyType(code, type);
       }

       public List<Qry_Supplier> GetAllSupplierbyCode(string code)
        {
            return aSupplierService.GetAllSupplierbyCode(code);
        }
       public List<Qry_Supplier> GetSupplierbyCode(string code)
       {
           return aSupplierService.GetSupplierbyCode(code);
       }
        public Tbl_Supplier GetLastSupplier()
        {
            return aSupplierService.GetLastSupplier();
        }
        public string GenerateSupplierCode()
        {
            Tbl_Supplier supplier = GetLastSupplier();
            string prefix = "S";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (supplier != null)
            {
                subprefix = supplier.Supplier_Code;
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

    }
}
