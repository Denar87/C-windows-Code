using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class UserBusiness
    {
        UserService aUserService = new UserService();

        ~UserBusiness()
        {
            aUserService.Dispose();
            aUserService = null;

        }

        public List<Tbl_User> GetAllUser()
        {
            return aUserService.GetAllUser();
        }
        public List<Tbl_System> GetAllSystem()
        {
            return aUserService.GetAllSystem();
        }
        public List<Tbl_User> GetAllUserByUserId(string userId)
        {
            return aUserService.GetAllUserByUserId(userId);
        }
        public Tbl_User GetAllUserByUser(string userid)
        {
            return aUserService.GetAllUserByUser(userid);
        }
        public Tbl_User GetAllUser(int autoid)
        {
            return aUserService.GetAllUser(autoid);
        }
        public Tbl_User GetAllUser(string name)
        {
            return aUserService.GetAllUser(name);
        }
        public Tbl_User GetAllUser(int autoId, string name)
        {
            return aUserService.GetAllUser(autoId, name);
        }
        public bool Insert(Tbl_User aTbl_User)
        {
            return aUserService.Insert(aTbl_User) > 0;
        }
        public bool Update(Tbl_User aTbl_User)
        {
            return aUserService.Update(aTbl_User) > 0;
        }
        public Tbl_User GetAllUser(string userId, string password)
        {
            return aUserService.GetAllUser(userId, password);
        }
        public string ValidateLogIn(string userId, string password)
        {
            if (userId == string.Empty)
            {
                return "Enter User ID";
            }
            if (password == string.Empty)
            {
                return "Enter Password";
            }
            if (GetAllUser(userId, password) == null)
            {
                return "Enter UserId/Password";
            }
            return string.Empty;
        }

        public string ValidateLockIn(string userId, string password)
        {
            if (password == string.Empty)
            {
                return "Enter Password";
            }
            if (GetAllUser(userId, password) == null)
            {
                return "Please enter UserId/password";
            }
            return string.Empty;
        }

        public string validateOnSave(Tbl_User aTbl_User)
        {
            if (aTbl_User.User_ID == string.Empty)
            {
                return "Enter UserID";
            }
            if (GetAllUser(aTbl_User.User_ID) != null)
            {
                return "UserID already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_User aTbl_User)
        {
            if (aTbl_User.User_ID == string.Empty)
            {
                return "Enter UserID";
            }
            if (GetAllUser(aTbl_User.User_SlNo, aTbl_User.User_ID) != null)
            {
                return "UserID already exist";
            }
            return string.Empty;
        }
        public List<Tbl_System> getLicence()
        {
            return aUserService.getLicence();
        }
        public List<Tbl_System> getLicence(string key)
        {
            return aUserService.getLicence( key);
        }
        public bool InsertLicence(Tbl_System aTbl_System)
        {

            return aUserService.InsertLicence(aTbl_System) > 0;
        }
        public bool UpdateLicence(Tbl_System aTbl_System)
        {
            return aUserService.UpdateLicence(aTbl_System) > 0;
        }
    }
}
