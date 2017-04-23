using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class AccountService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();
        #region Memory Optimizer
        ~AccountService()
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
        public List<Tbl_Account> GetAllAccountbyCode(string code)
        {
            return context.Tbl_Account.Where(x => x.Status.Trim() == "A" && x.Acc_Code.StartsWith(code) || x.Acc_Name.StartsWith(code)).ToList();
        }
        public Tbl_Account GetLastAccount()
        {
            return context.Tbl_Account.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Acc_SlNo).FirstOrDefault();
        }
        public List<Tbl_Account> GetAllAccount()
        {
            return context.Tbl_Account.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_Account> GetAllAccountByCustomer()
        {
            return context.Tbl_Account.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_Account> GetAllAccountByType()
        {
            return context.Tbl_Account.Where(x => x.Acc_Type=="Official" && x.Status.Trim() == "A" ).OrderBy(x=>x.Acc_Name).ToList();
        }
        public Tbl_Account GetAllAccount(int autoId)
        {
            return context.Tbl_Account.Where(x => x.Acc_SlNo == autoId && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Account GetAllAccountCode(string code)
        {
            return context.Tbl_Account.Where(x => x.Acc_Code == code && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Account GetAllAccount(string name)
        {
            return context.Tbl_Account.Where(x => x.Acc_Name == name && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Account GetAllAccount(int autoId, string code, string name)
        {
            return context.Tbl_Account.Where(x => x.Acc_SlNo != autoId && x.Acc_Code==code &&x.Acc_Name == name && x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Account aTbl_Account)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Account.Add(aTbl_Account);
            return context.SaveChanges();
        }
        public int Update(Tbl_Account aTbl_Account)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Account.Attach(aTbl_Account);
            context.Entry(aTbl_Account).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
