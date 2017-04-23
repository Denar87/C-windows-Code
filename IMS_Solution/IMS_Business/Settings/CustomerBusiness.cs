using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class CustomerBusiness
    {
        CustomerService aCustomerService = new CustomerService();

        ~CustomerBusiness()
       {
           aCustomerService.Dispose();
           aCustomerService = null;
       }

       public string validateOnSave(Tbl_Customer aTbl_Customer)
       {
           if (aTbl_Customer.Customer_Name == string.Empty)
           {
               return "Enter Customer Name";
           }
           if (GetAllCustomer(aTbl_Customer.Customer_Name) != null)
           {
               return "Customer name already exist";
           }
           return string.Empty;
       }

       public string validateOnUpdate(Tbl_Customer aTbl_Customer)
       {
           if (aTbl_Customer.Customer_Name == string.Empty)
           {
               return "Enter Customer Name";
           }
           if (GetAllCustomer(aTbl_Customer.Customer_SlNo, aTbl_Customer.Customer_Code, aTbl_Customer.Customer_Name) != null)
           {
               return "Customer name already exist";
           }
           return string.Empty;
       }

       public List<Tbl_Customer> GetAllCustomerByCountry(int id)
       {
           return aCustomerService.GetAllCustomerByCountry(id);
       }

       public List<Qry_Customer> GetAllQryCustomer()
       {
           return aCustomerService.GetAllQryCustomer();
       }
       public List<Qry_Customer> GetAllCustomerByCountry(string country)
       {
           return aCustomerService.GetAllCustomerByCountry(country);
       }
       public List<Qry_CustomerDue> GetAllQryCustomerDue()
       {
           return aCustomerService.GetAllQryCustomerDue();
       }
       public List<Qry_CustomerPayment> GetAllCustomerPayment()
       {
           return aCustomerService.GetAllCustomerPayment();
       }
       public List<Qry_CustomerDue> GetAllQryCustomerDueByCustomer(int CustomerID)
       {
           return aCustomerService.GetAllQryCustomerDueByCustomer(CustomerID);
       }
       public List<Qry_CustomerPayment> GetAllQryCustomerPayByCustomer(int CustomerID)
       {
           return aCustomerService.GetAllQryCustomerPayByCustomer(CustomerID);
       }
       public List<Qry_CustomerDue> GetAllQryCustomerDueByCustomerCode(string CustomerCode)
       {
           return aCustomerService.GetAllQryCustomerDueByCustomerCode(CustomerCode);
       }

       public List<Tbl_Customer> GetAllCustomer()
       {
           return aCustomerService.GetAllCustomer();
       }
       public List<Tbl_Customer> GetAllCustomerByID(string id)
       {
           return aCustomerService.GetAllCustomerByID(id);
       }
       public Tbl_Customer GetAllCustomer(int autoid)
       {
           return aCustomerService.GetAllCustomer(autoid);
       }
       public Tbl_Customer GetAllCustomer(string name)
       {
           return aCustomerService.GetAllCustomer(name);
       }
       public Tbl_Customer GetAllCustomerByCode(string code)
       {
           return aCustomerService.GetAllCustomerByCode(code);
       }
       public Tbl_Customer GetAllCustomer(int autoId, string code, string name)
       {
           return aCustomerService.GetAllCustomer(autoId, code, name);
       }
       public bool Insert(Tbl_Customer aTbl_Customer)
       {
           return aCustomerService.Insert(aTbl_Customer) > 0;
       }
       public bool Update(Tbl_Customer aTbl_Customer)
       {
           return aCustomerService.Update(aTbl_Customer) > 0;
       }


       public List<Qry_Customer> GetAllCustomerbyType(string code, string type)
       {
           return aCustomerService.GetAllCustomerbyType(code, type);
       }
       public List<Qry_Customer> GetAllCustomerbyCode(string code)
       {
           return aCustomerService.GetAllCustomerbyCode(code);
       }
       public List<Qry_Customer> GetCustomerbyCode(string code)
       {
           return aCustomerService.GetCustomerbyCode(code);
       }
       public List<Qry_Customer> GetAllCustomerbyID(string id)
       {
           return aCustomerService.GetAllCustomerbyID(id);
       }
       public List<Qry_Customer> GetAllCustomerbyName(string name)
       {
           return aCustomerService.GetAllCustomerbyName(name);
       }
       public List<Qry_Customer> GetAllCustomerbyMobile(string mobile)
       {
           return aCustomerService.GetAllCustomerbyMobile(mobile);
       }

       public Tbl_Customer GetLastCustomer()
       {
           return aCustomerService.GetLastCustomer();
       }

        public string GenerateCustomerCode()
        {
            Tbl_Customer Customer = GetLastCustomer();
            string prefix = "C";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (Customer != null)
            {
                subprefix = Customer.Customer_Code;
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
