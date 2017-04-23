using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class CashAccountService : IDisposable
    {
        IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
        ~CashAccountService()
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

        #region Tbl_CashRegister

        public int InsertCashRegister(Tbl_CashRegister aTbl_CashRegister)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Tbl_CashRegister.Add(aTbl_CashRegister);
            return context.SaveChanges();
        }


        public int UpdateCashRegister(Tbl_CashRegister aTbl_CashRegister)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_CashRegister.Attach(aTbl_CashRegister);
            context.Entry(aTbl_CashRegister).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public Tbl_CashRegister GetAllCashRegister(string identityNo)
        {
            return context.Tbl_CashRegister.Where(x => x.IdentityNo == identityNo && x.Status.Trim() == "A").FirstOrDefault();
        }


        #endregion

        public List<Get_Financial_Statement> Get_FinancialStatement()
        {
            return context.Get_Financial_Statement().OrderBy(x => x.Narration).ToList();
        }

        public List<Get_Financial_Statement_All> Get_FinancialStatement_All()
        {
            return context.Get_Financial_Statement_All().ToList();
        }

        public List<Get_Financial_Statement_CustomerWise> Get_FinancialStatement_CustomerWise(int customerId)
        {
            return context.Get_Financial_Statement_CustomerWise(customerId).ToList();
        }

        public List<Get_Cash_TransactionByCode> Get_Cash_TransactionByCode(string id)
        {
            return context.Get_Cash_TransactionByCode().Where(x => x.Tr_Id == id).ToList();
        }

        public List<Tbl_CashTransaction> GetAllCashTransaction()
        {
            return context.Tbl_CashTransaction.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Get_Expense_Statement> GetExpenseStatement()
        {
            return context.Get_Expense_Statement().OrderByDescending(x => x.Tr_date).ToList();
        }
        public List<Get_Expense_Statement> GetExpenseStatement(int id)
        {
            return context.Get_Expense_Statement().Where(x => x.Acc_SlNo == id).OrderByDescending(x => x.Tr_date).ToList();
        }
        public List<Get_Expense_Statement> GetExpenseStatement(string id)
        {
            return context.Get_Expense_Statement().Where(x => x.Tr_Id == id).OrderByDescending(x => x.Tr_date).ToList();
        }
        public List<Func_Get_BankStatement> GetBankStatement()
        {
            return context.Func_Get_BankStatement().ToList();
        }
        public List<Tbl_CashTransaction> GetAllAccountByTransaction(int id)
        {
            return context.Tbl_CashTransaction.Where(x => x.Acc_SlNo == id).ToList();
        }

        public List<Tbl_CashTransaction> GetAllCashTransactionByDate(DateTime date)
        {
            return context.Tbl_CashTransaction.Where(x => x.Status.Trim() == "A" && x.Tr_date == date).ToList();
        }
        public List<Qry_CashTransaction> GetAllQryCashTransactionByDate(DateTime date)
        {
            return context.Qry_CashTransaction.Where(x => x.Tr_date == date).ToList();
        }
        public List<Qry_CashTransaction> GetAllQryCashTransactionById(string id)
        {
            return context.Qry_CashTransaction.Where(x => x.Tr_Id == id).ToList();
        }
        public Tbl_CashTransaction GetAllCashTransaction(int autoId)
        {
            return context.Tbl_CashTransaction.Where(x => x.Tr_SlNo == autoId && x.Status.Trim() == "A").FirstOrDefault();
        }
        public List<Tbl_CashTransaction> GetAllCashAccountByCustomer(int customer)
        {
            return context.Tbl_CashTransaction.Where(x => x.Customer_SlNo == customer && x.Status.Trim() == "A").ToList();
        }

        public List<Qry_CustomerPayment> GetAllCashAccountByCustomerID(string id)
        {
            return context.Qry_CustomerPayment.Where(x => x.Customer_Code == id).ToList();
        }

        public List<Tbl_CashTransaction> GetAllCashAccountBySupplier(int supplier)
        {
            return context.Tbl_CashTransaction.Where(x => x.Supplier_SlNo == supplier && x.Status.Trim() == "A").ToList();
        }
        public Tbl_CashTransaction GetLastCashTransaction()
        {
            return context.Tbl_CashTransaction.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Tr_SlNo).FirstOrDefault();
        }
        public int Insert(Tbl_CashTransaction aTbl_CashTransaction)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_CashTransaction.Add(aTbl_CashTransaction);
            return context.SaveChanges();
        }

    }
}
