using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;


namespace IMS_Service
{
    public class ResetDataService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();
         
        #region Memory Optimizer
        ~ResetDataService()
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

        public int deleteall()
        {
            var account = context.Tbl_Account;
            foreach (Tbl_Account data in account)
            {
                context.Tbl_Account.Remove(data);
            }

            var CashTransaction = context.Tbl_CashTransaction;
            foreach (Tbl_CashTransaction data in CashTransaction)
            {
                context.Tbl_CashTransaction.Remove(data);
            }

            var CashRegister = context.Tbl_CashRegister;
            foreach (Tbl_CashRegister data in CashRegister)
            {
                context.Tbl_CashRegister.Remove(data);
            }

            //var Company = context.Tbl_Company;
            //foreach (Tbl_Company data in Company)
            //{
            //    context.Tbl_Company.Remove(data);
            //}

            var CurrentInventory = context.Tbl_CurrentInventory;
            foreach (Tbl_CurrentInventory data in CurrentInventory)
            {
                context.Tbl_CurrentInventory.Remove(data);
            }

            var Customer = context.Tbl_Customer.Where(x => x.Customer_Name != "General Customer");
            foreach (Tbl_Customer data in Customer)
            {
                context.Tbl_Customer.Remove(data);
            }

            var Damage = context.Tbl_Damage;
            foreach (Tbl_Damage data in Damage)
            {
                context.Tbl_Damage.Remove(data);
            }

            var DamageDetails = context.Tbl_DamageDetails;
            foreach (Tbl_DamageDetails data in DamageDetails)
            {
                context.Tbl_DamageDetails.Remove(data);
            }

            var department = context.Tbl_Department.Where(x => x.Department_Name != "Sales");
            foreach (Tbl_Department data in department)
            {
                context.Tbl_Department.Remove(data);
            }

            var designation = context.Tbl_Designation.Where(x => x.Designation_Name != "Manager");
            foreach (Tbl_Designation data in designation)
            {
                context.Tbl_Designation.Remove(data);
            }

            var Employee = context.Tbl_Employee;
            foreach (Tbl_Employee data in Employee)
            {
                context.Tbl_Employee.Remove(data);
            }

            var Product = context.Tbl_Product;
            foreach (Tbl_Product data in Product)
            {
                context.Tbl_Product.Remove(data);
            }

            var ProductCategory = context.Tbl_ProductCategory;
            foreach (Tbl_ProductCategory data in ProductCategory)
            {
                context.Tbl_ProductCategory.Remove(data);
            }

            var PurchaseMaster = context.Tbl_PurchaseMaster;
            foreach (Tbl_PurchaseMaster data in PurchaseMaster)
            {
                context.Tbl_PurchaseMaster.Remove(data);
            }

            var PurchaseDetails = context.Tbl_PurchaseDetails;
            foreach (Tbl_PurchaseDetails data in PurchaseDetails)
            {
                context.Tbl_PurchaseDetails.Remove(data);
            }

            var PurchaseInventory = context.Tbl_PurchaseInventory;
            foreach (Tbl_PurchaseInventory data in PurchaseInventory)
            {
                context.Tbl_PurchaseInventory.Remove(data);
            }

            var PurchaseReturn = context.Tbl_PurchaseReturn;
            foreach (Tbl_PurchaseReturn data in PurchaseReturn)
            {
                context.Tbl_PurchaseReturn.Remove(data);
            }

            var PurchaseReturnDetails = context.Tbl_PurchaseReturnDetails;
            foreach (Tbl_PurchaseReturnDetails data in PurchaseReturnDetails)
            {
                context.Tbl_PurchaseReturnDetails.Remove(data);
            }

            var SalesMaster = context.Tbl_SalesMaster;
            foreach (Tbl_SalesMaster data in SalesMaster)
            {
                context.Tbl_SalesMaster.Remove(data);
            }

            var SaleDetails = context.Tbl_SaleDetails;
            foreach (Tbl_SaleDetails data in SaleDetails)
            {
                context.Tbl_SaleDetails.Remove(data);
            }

            var SaleInventory = context.Tbl_SaleInventory;
            foreach (Tbl_SaleInventory data in SaleInventory)
            {
                context.Tbl_SaleInventory.Remove(data);
            }

            var SaleReturn = context.Tbl_SaleReturn;
            foreach (Tbl_SaleReturn data in SaleReturn)
            {
                context.Tbl_SaleReturn.Remove(data);
            }

            var SaleReturnDetails = context.Tbl_SaleReturnDetails;
            foreach (Tbl_SaleReturnDetails data in SaleReturnDetails)
            {
                context.Tbl_SaleReturnDetails.Remove(data);
            }

            var Supplier = context.Tbl_Supplier.Where(x => x.Supplier_Name != "General Supplier");
            foreach (Tbl_Supplier data in Supplier)
            {
                context.Tbl_Supplier.Remove(data);
            }

            var unit = context.Tbl_Unit;
            foreach (Tbl_Unit data in unit)
            {
                context.Tbl_Unit.Remove(data);
            }

            var user = context.Tbl_User.Where(x => x.User_ID != "Admin");
            foreach (Tbl_User data in user)
            {
                context.Tbl_User.Remove(data);
            }

            return context.SaveChanges();
        }
    }
}
