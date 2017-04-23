using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Service;
using IMS_Entity;

namespace IMS_Business
{
    public class CashAccountBusiness
    {
        CashAccountService aCashAccountService = new CashAccountService();
        ~CashAccountBusiness()
        {
            aCashAccountService.Dispose();
            aCashAccountService = null;
        }

        #region Tbl_CashRegister

        public bool InsertCashRegister(Tbl_CashRegister aTbl_CashRegister)
        {
            return aCashAccountService.InsertCashRegister(aTbl_CashRegister) > 0;
        }

        public bool UpdateCashRegister(Tbl_CashRegister aTbl_CashRegister)
        {
            return aCashAccountService.UpdateCashRegister(aTbl_CashRegister) > 0;
        }

        public Tbl_CashRegister GetAllCashRegister(string identityNo)
        {
            return aCashAccountService.GetAllCashRegister(identityNo);

        }
        #endregion


        public string validateOnSave(Tbl_CashTransaction aTbl_CashTransaction)
        {
            if (aTbl_CashTransaction.Tr_Type == string.Empty)
            {
                return "Select a Transaction Type !";
            }
            return string.Empty;
        }

        public List<Tbl_CashTransaction>  GetAllAccountByTransaction(int id)
        {
            return aCashAccountService.GetAllAccountByTransaction(id);
        }
        public List<Func_Get_BankStatement> GetBankStatement()
        {
            return aCashAccountService.GetBankStatement();
        }
        public bool Insert(Tbl_CashTransaction aTbl_CashTransaction)
        {
            return aCashAccountService.Insert(aTbl_CashTransaction) > 0;
        }
        public List<Get_Expense_Statement> GetAllExpense(int id)
        {
            return aCashAccountService.GetExpenseStatement(id);
        }
        public List<Get_Expense_Statement> GetAllExpense(string id)
        {
            return aCashAccountService.GetExpenseStatement(id);
        }
        public List<Get_Cash_TransactionByCode> Get_Cash_TransactionByCode(string id)
        {
            return aCashAccountService.Get_Cash_TransactionByCode(id);
        }
        public List<Get_Expense_Statement> GetAllExpense()
        {
            return aCashAccountService.GetExpenseStatement();
        }

        public List<Get_Financial_Statement> Get_FinancialStatement()
        {
            return aCashAccountService.Get_FinancialStatement();
        }

        public List<Get_Financial_Statement_All> Get_FinancialStatement_All()
        {
            return aCashAccountService.Get_FinancialStatement_All();
        }

        public List<Get_Financial_Statement_CustomerWise> Get_FinancialStatement_CustomerWise(int customerId)
        {
            return aCashAccountService.Get_FinancialStatement_CustomerWise(customerId);
        }

        public List<Tbl_CashTransaction> GetAllCashTransaction()
        {
            return aCashAccountService.GetAllCashTransaction();
        }
        public List<Tbl_CashTransaction> GetAllCashTransactionByDate(DateTime date)
        {
            return aCashAccountService.GetAllCashTransactionByDate(date);
        }
        public List<Qry_CashTransaction> GetAllQryCashTransactionByDate(DateTime date)
        {
            return aCashAccountService.GetAllQryCashTransactionByDate(date);
        }
        public List<Qry_CashTransaction> GetAllQryCashTransactionById(string id)
        {
            return aCashAccountService.GetAllQryCashTransactionById(id);
        }
        public Tbl_CashTransaction GetAllCashTransaction(int autoid)
        {
            return aCashAccountService.GetAllCashTransaction(autoid);
        }
        public Tbl_CashTransaction GetLastCashTransaction()
        {
            return aCashAccountService.GetLastCashTransaction();
        }

        public List<Tbl_CashTransaction> GetAllCashAccountBySupplier(int supplier)
        {
            return aCashAccountService.GetAllCashAccountBySupplier(supplier);
        }
        public List<Tbl_CashTransaction> GetAllCashAccountByCustomer(int customer)
        {
            return aCashAccountService.GetAllCashAccountByCustomer(customer);
        }

        public List<Qry_CustomerPayment> GetAllCashAccountByCustomerID(string id)
        {
            return aCashAccountService.GetAllCashAccountByCustomerID(id);
        }

        public string GenerateTrCode()
        {
            Tbl_CashTransaction CashAccount = GetLastCashTransaction();
            string prefix = "T";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (CashAccount != null)
            {
                subprefix = CashAccount.Tr_Id;
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
