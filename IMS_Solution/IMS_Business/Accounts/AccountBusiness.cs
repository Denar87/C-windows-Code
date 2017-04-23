using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class AccountBusiness
    {
        AccountService aAccountService = new AccountService();
        ~AccountBusiness()
        {
            aAccountService.Dispose();
            aAccountService = null;
        }

        public List<Tbl_Account> GetAllAccountbyCode(string code)
        {
            return aAccountService.GetAllAccountbyCode(code);
        }
        public Tbl_Account GetLastAccount()
        {
            return aAccountService.GetLastAccount();
        }


        public string GenerateCustomerCode()
        {
            Tbl_Account Account = GetLastAccount();
            string prefix = "A";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (Account != null)
            {
                subprefix = Account.Acc_Code;
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
        public string validateOnSave(Tbl_Account aTbl_Account)
        {
            if (aTbl_Account.Acc_Name == string.Empty)
            {
                return "Enter Account Name";
            }
            if (GetAllAccount(aTbl_Account.Acc_Name) != null)
            {
                return "Account name already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_Account aTbl_Account)
        {
            if (aTbl_Account.Acc_Name == string.Empty)
            {
                return "Enter Account Name";
            }
            if (GetAllAccount(aTbl_Account.Acc_SlNo, aTbl_Account.Acc_Code, aTbl_Account.Acc_Name) != null)
            {
                return "Account name already exist";
            }
            return string.Empty;
        }
        public List<Tbl_Account> GetAllAccount()
        {
            return aAccountService.GetAllAccount();
        }
        public List<Tbl_Account> GetAllAccountByType()
        {
            return aAccountService.GetAllAccountByType();
        }
        public Tbl_Account GetAllAccount(int autoid)
        {
            return aAccountService.GetAllAccount(autoid);
        }
        public Tbl_Account GetAllAccountcode(string code)
        {
            return aAccountService.GetAllAccount(code);
        }
        public Tbl_Account GetAllAccount(string name)
        {
            return aAccountService.GetAllAccount(name);
        }
        public Tbl_Account GetAllAccount(int autoId,string code,string name)
        {
            return aAccountService.GetAllAccount(autoId,code, name);
        }
        public bool Insert(Tbl_Account aTbl_Account)
        {
            return aAccountService.Insert(aTbl_Account) > 0;
        }
        public bool Update(Tbl_Account aTbl_Account)
        {
            return aAccountService.Update(aTbl_Account) > 0;
        }
    }
}
