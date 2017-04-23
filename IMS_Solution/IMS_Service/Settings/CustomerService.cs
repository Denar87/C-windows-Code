using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class CustomerService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

         #region Memory Optimizer
        ~CustomerService()
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

        public List<Qry_Customer> GetAllCustomerbyCode(string code)
        {
            return context.Qry_Customer.Where(x => x.Customer_Code.StartsWith(code) || x.Customer_Name.StartsWith(code) || x.Customer_Mobile.StartsWith(code)).ToList();
        }
        public List<Qry_Customer> GetCustomerbyCode(string code)
        {
            return context.Qry_Customer.Where(x => x.Customer_Code!="C0001" && (x.Customer_Code.StartsWith(code) || x.Customer_Name.StartsWith(code) || x.Customer_Mobile.StartsWith(code))).ToList();
        }
        public List<Qry_Customer> GetAllCustomerbyID(string id)
        {
            return context.Qry_Customer.Where(x => x.Customer_Code == id).ToList();
        }
        public List<Qry_Customer> GetAllCustomerbyName(string name)
        {
            return context.Qry_Customer.Where(x => x.Customer_Name == name).ToList();
        }

        public List<Qry_Customer> GetAllCustomerbyMobile(string mobile)
        {
            return context.Qry_Customer.Where(x => x.Customer_Mobile == mobile).ToList();
        }

        public List<Tbl_Customer> GetAllCustomerByCountry(int id)
        {
            return context.Tbl_Customer.Where(x => x.Country_SlNo == id).ToList();
        }
        public List<Qry_Customer> GetAllCustomerbyType(string code, string type)
        {
            return context.Qry_Customer.Where(x => x.Customer_Type == type && (x.Customer_Code.StartsWith(code) || x.Customer_Name.StartsWith(code) || x.Customer_Mobile.StartsWith(code))).ToList();
        }
        public Tbl_Customer GetLastCustomer()
        {
            return context.Tbl_Customer.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Customer_SlNo).FirstOrDefault();
        }
        public List<Qry_CustomerDue> GetAllQryCustomerDue()
        {
            return context.Qry_CustomerDue.OrderBy(x => x.Customer_Name).ToList();
        }

        public List<Qry_CustomerPayment> GetAllCustomerPayment()
        {
            return context.Qry_CustomerPayment.OrderBy(x => x.Customer_Name).ToList();
        }

        public List<Qry_CustomerDue> GetAllQryCustomerDueByCustomer(int CustomerID)
        {
            return context.Qry_CustomerDue.Where(x => x.Customer_SlNo == CustomerID).ToList();
        }
        public List<Qry_CustomerPayment> GetAllQryCustomerPayByCustomer(int CustomerID)
        {
            return context.Qry_CustomerPayment.Where(x => x.Customer_SlNo == CustomerID).ToList();
        }
        public List<Qry_CustomerDue> GetAllQryCustomerDueByCustomerCode(string CustomerCode)
        {
            return context.Qry_CustomerDue.Where(x => x.Customer_Code == CustomerCode).ToList();
        }

        public List<Qry_Customer> GetAllQryCustomer()
        {
            return context.Qry_Customer.OrderBy(x=>x.Customer_Name).ToList();
        }

        public List<Qry_Customer> GetAllCustomerByCountry(string country)
        {
            return context.Qry_Customer.Where(x => x.CountryName == country).OrderBy(x => x.Customer_Name).ToList();
        }
       
        public List<Tbl_Customer> GetAllCustomer()
        {
            return context.Tbl_Customer.Where(x => x.Status.Trim() == "A").OrderBy(x=>x.Customer_Name).ToList();
        }
        public List<Tbl_Customer> GetAllCustomerByID(string id)
        {
            return context.Tbl_Customer.Where(x => x.Customer_Code==id).ToList();
        }
        public Tbl_Customer GetAllCustomer(int autoid)
        {
            return context.Tbl_Customer.Where(x =>
                x.Customer_SlNo == autoid &&
                x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Customer GetAllCustomer(string name)
        {
            return context.Tbl_Customer.Where(x => x.Customer_Name == name && x.Status.Trim() == "A").FirstOrDefault();
        }

        public Tbl_Customer GetAllCustomerByCode(string code)
        {
            return context.Tbl_Customer.Where(x => x.Customer_Code == code && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Customer GetAllCustomer(int autoId, string code, string name)
        {
            return context.Tbl_Customer.Where(x =>
                x.Customer_SlNo != autoId &&
                x.Customer_Code != code &&
                x.Customer_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Customer aTbl_Customer)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Customer.Add(aTbl_Customer);
            return context.SaveChanges();
        }
        public int Update(Tbl_Customer aTbl_Customer)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Customer.Attach(aTbl_Customer);
            context.Entry(aTbl_Customer).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
