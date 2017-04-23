using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class UserService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

        #region Memory Optimizer
        ~UserService()
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

        public Tbl_User GetAllUserByUser(string userid)
        {
            return context.Tbl_User.Where(x => x.User_ID == userid && x.Status.Trim()=="A").FirstOrDefault();
        }
        public List<Tbl_User> GetAllUserByUserId(string userid)
        {
            return context.Tbl_User.Where(x => x.User_ID.StartsWith(userid) && x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_System> GetAllSystem()
        {
            return context.Tbl_System.ToList();
        }
        public List<Tbl_User> GetAllUser()
        {
            return context.Tbl_User.Where(x => x.Status.Trim() == "A").OrderBy(x => x.User_Name).ToList();
        }
        public Tbl_User GetAllUser(string userId, string password)
        {
            return context.Tbl_User.Where(x => x.User_ID == userId && x.User_Password == password && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_User GetAllUser(int autoId)
        {
            return context.Tbl_User.Where(x => x.User_SlNo == autoId && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_User GetAllUser(string name)
        {
            return context.Tbl_User.Where(x => x.User_ID == name && x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_User GetAllUser(int autoId, string name)
        {
            return context.Tbl_User.Where(x => x.User_SlNo != autoId && x.User_ID == name && x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_User aTbl_User)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_User.Add(aTbl_User);
            return context.SaveChanges();
        }
        public int Update(Tbl_User aTbl_User)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_User.Attach(aTbl_User);
            context.Entry(aTbl_User).State = EntityState.Modified;
            return context.SaveChanges();
        }


        public List<Tbl_System> getLicence()
        {
            return context.Tbl_System.ToList();
        }
        public List<Tbl_System> getLicence(string key)
        {
            return context.Tbl_System.Where(x => x.Licence_Key == key).ToList();
        }
        public int InsertLicence(Tbl_System aTbl_System)
        {
            context.Tbl_System.Add(aTbl_System);
            return context.SaveChanges();
        }
        public int UpdateLicence(Tbl_System aTbl_User)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_System.Attach(aTbl_User);
            context.Entry(aTbl_User).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
