using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Service;
using IMS_Entity;

namespace IMS_Business
{
   public class PurchaseBusiness
    {
       PurchaseService aPurchaseService = new PurchaseService();
        ~PurchaseBusiness()
       {
           aPurchaseService.Dispose();
           aPurchaseService = null;
       }

        #region Tbl_PurchaseMaster

        public string ValidateMasterOnSave(Tbl_PurchaseMaster aTbl_PurchaseMaster)
        {
            if (aTbl_PurchaseMaster.Supplier_SlNo == 0)
            {
                return "Enter Supplier";
            }
            if (aTbl_PurchaseMaster.Employee_SlNo == 0)
            {
                return "Enter Employee";
            }
            if (aTbl_PurchaseMaster.PurchaseMaster_InvoiceNo == string.Empty)
            {
                return "Enter Invoice";
            }
            return string.Empty;
        }

        public string GenerateInvoiceNo()
        {
            string prefix = DateTime.UtcNow.AddHours(6).ToString("yyyy-MM-dd");
            int cnt = 0;
            Tbl_PurchaseMaster master = GetLastPurchaseMaster();
            if (master!= null)
            {
                string ff=master.PurchaseMaster_InvoiceNo.Substring(10).ToString();
                string date = master.PurchaseMaster_InvoiceNo.Substring(0, 10).ToString();
                if (date.Equals(prefix))
                {
                    cnt = Convert.ToInt32(ff);
                    cnt++;
                }
                else
                {
                    cnt++;
                }
                return prefix+cnt.ToString("000");
            }
            else
            {
                cnt++;
                return prefix+cnt.ToString("000");
            }
        }

        public List<Tbl_PurchaseMaster> GetAllPurchaseMaster()
        {
            return aPurchaseService.GetAllPurchaseMaster();
        }
        public Tbl_PurchaseMaster GetLastPurchaseMaster()
        {
            return aPurchaseService.GetLastPurchaseMaster();
        }
        public Tbl_PurchaseMaster GetAllPurchaseMaster(string voucherId)
        {
            return aPurchaseService.GetAllPurchaseMaster(voucherId);
        }
        public Tbl_PurchaseMaster GetAllPurchaseMaster(int id)
        {
            return aPurchaseService.GetAllPurchaseMaster(id);
        }

        public Tbl_PurchaseMaster GetPurchaseMaster()
        {
            return aPurchaseService.GetPurchaseMaster();
        }

        public List<Tbl_PurchaseMaster> GetAllPurchaseMasterBySupplier(int supplier)
        {
            return aPurchaseService.GetAllPurchaseMasterBySupplier(supplier);
        }
        public List<Tbl_PurchaseMaster> GetAllEmployeeByPurchase(int employee)
        {
            return aPurchaseService.GetAllEmployeeByPurchase(employee);
        }
        public List<Tbl_PurchaseMaster> GetAllEmployeeByID(int id)
        {
            return aPurchaseService.GetAllPurchaseMasterByID(id);
        }

        public Qry_PurchaseMaster GetAllQryPurchaseMaster(int id)
        {
            return aPurchaseService.GetAllQryPurchaseMaster(id);
        }
        public List<Qry_PurchaseInvoice> GetAllQryPurchaseInvoiceByInvoice(string voucherId)
        {
            return aPurchaseService.GetAllQryPurchaseInvoiceByInvoice(voucherId);
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMaster()
        {
            return aPurchaseService.GetAllQryPurchaseMaster();
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMaster(string invoiceNo)
        {
            return aPurchaseService.GetAllQryPurchaseMaster(invoiceNo);
        }
        public List<Qry_PurchaseMaster> GetAllQryPurchaseMasterByid(int id)
        {
            return aPurchaseService.GetAllQryPurchaseMasterByid(id);
        }
        public bool InsertPurchaseMaster(Tbl_PurchaseMaster aTbl_PurchaseMaster)
        {
            return aPurchaseService.InsertPurchaseMaster(aTbl_PurchaseMaster) > 0;
        }
        public bool UpdatePurchaseMaster(Tbl_PurchaseMaster aTbl_PurchaseMaster)
        {
            return aPurchaseService.UpdatePurchaseMaster(aTbl_PurchaseMaster) > 0;
        }

        public bool UpdatePurchaseMaster(List<Tbl_PurchaseMaster> lstTbl_PurchaseMaster)
        {
            return aPurchaseService.UpdatePurchaseMaster(lstTbl_PurchaseMaster) > 0;
        }

        #endregion

        #region Purchase Details

        public string validateDetailsOnSave(Tbl_PurchaseDetails aTbl_PurchaseDetails)
        {
            if (aTbl_PurchaseDetails.Product_SlNo == 0)
            {
                return "Enter Product";
            }
            if (aTbl_PurchaseDetails.PurchaseDetails_TotalQuantity == 0)
            {
                return "Enter Quantity";
            }
            return string.Empty;
        }
        public Tbl_PurchaseDetails GetAllPurchaseDetailsByid(int id)
        {
            return aPurchaseService.GetAllPurchaseDetailsByid(id);
        }
        public Tbl_PurchaseDetails GetAllPurchaseDetailsByProduct(int id)
        {
            return aPurchaseService.GetAllPurchaseDetailsByProduct(id);
        }

        public List<Tbl_PurchaseDetails> GetAllPurchaseDetails(int id)
        {
            return aPurchaseService.GetAllPurchaseDetails(id);
        }
        public List<Tbl_PurchaseDetails> GetAllPurchaseDetails()
        {
            return aPurchaseService.GetAllPurchaseDetails();
        }
        public List<Tbl_PurchaseDetails> GetAllPurchaseByProductid(int id)
        {
            return aPurchaseService.GetAllPurchaseByProductid(id);
        }
        public List<Qry_PurchaseDetails> GetAllQry_PurchaseDetails(int id)
        {
            return aPurchaseService.GetAllQry_PurchaseDetails(id);
        }

        public bool UpdatePurchaseDetail(Tbl_PurchaseDetails aTbl_PurchaseDetails)
        {
            return aPurchaseService.UpdatePurchaseDetail(aTbl_PurchaseDetails) > 0;
        }

        public bool InsertPurchaseDetail(List<Tbl_PurchaseDetails> aTbl_PurchaseDetails)
        {
            return aPurchaseService.InsertPurchaseDetail(aTbl_PurchaseDetails) > 0;
        }
        public bool UpdatePurchaseDetail(List<Tbl_PurchaseDetails> aTbl_PurchaseDetails)
        {
            return aPurchaseService.UpdatePurchaseDetail(aTbl_PurchaseDetails) > 0;
        }
        #endregion

        #region Inventory

        public bool InsertorUpdatePurchaseInventory(List<Tbl_PurchaseInventory> lstInventory)
        {
            return aPurchaseService.InsertorUpdatePurchaseInventory(lstInventory) > 0;
        }
        public Tbl_PurchaseInventory GetAllPurchaseInventory(int productId)
        {
            return aPurchaseService.GetAllPurchaseInventory(productId);
        }
        public List<Qry_PurchaseInventory> GetAllQryPurchaseInventory()
        {
            return aPurchaseService.GetAllQryPurchaseInventory();
        }
        #endregion

        #region Purchase Return

        public List<Tbl_PurchaseReturn> GetAllPurchaseReturn()
        {
            return aPurchaseService.GetAllPurchaseReturn();
        }

        public List<Tbl_PurchaseReturnDetails> GetAllPurchaseReturnByProductID(int id)
        {
            return aPurchaseService.GetAllPurchaseReturnByProductID(id);
        }
        public List<Tbl_PurchaseReturn> GetAllPurchaseReturnbySupplier(int supplier)
        {
            return aPurchaseService.GetAllPurchaseReturnbySupplier(supplier);
        }
        public List<Tbl_PurchaseReturn> GetAllPurchaseReturn(string invoiceNo)
        {
            return aPurchaseService.GetAllPurchaseReturn(invoiceNo);
        }
        public void SavePurchaseReturn(List<Tbl_PurchaseReturn> lstmaster, List<Tbl_PurchaseReturnDetails> lstdetails, List<Tbl_PurchaseInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            aPurchaseService.SavePurchaseReturn(lstmaster, lstdetails, lstinventory, lstcurInventory); 
        }
        public List<Qry_PurchaseReturnMasterDetails> GetAllPurchaseReturnMasterDetails(string invoiceNo)
        {
            return aPurchaseService.GetAllPurchaseReturnMasterDetails(invoiceNo);
        }

        public List<Qry_PurchaseReturnMasterDetails> GetAllPurchaseReturnMasterDetails()
        {
            return aPurchaseService.GetAllPurchaseReturnMasterDetails();
        }

        public bool InsertOrUpdatePurchaseReturn(Tbl_PurchaseReturn aTbl_PurchaseReturn)
        {
            return aPurchaseService.InsertOrUpdatePurchaseReturn(aTbl_PurchaseReturn) > 0;
        }
        public bool InsertOrUpdatePurchaseReturnDetails(List<Tbl_PurchaseReturnDetails> lstTbl_PurchaseReturnDetails)
        {
            return aPurchaseService.InsertOrUpdatePurchaseReturnDetails(lstTbl_PurchaseReturnDetails) > 0;
        }

        #endregion

        #region Qry_PurchaseMasterDetails

        public List<Qry_PurchaseMasterDetails> GetAllQryPurchaseMasterDetails()
        {
            return aPurchaseService.GetAllQryPurchaseMasterDetails();
        }

        public List<Qry_PurchaseMasterDetails> GetAllPurchaseMasterDetails(string invoiceNo)
        {
            return aPurchaseService.GetAllPurchaseMasterDetails(invoiceNo);
        }
        public List<Qry_PurchaseMasterDetails> GetAllPurchaseMasterDetailsByProduct(string productid)
        {
            return aPurchaseService.GetAllPurchaseMasterDetailsByProduct(productid);
        }

        #endregion

        #region SavePurchase

        public void SavePurchase(List<Tbl_PurchaseMaster> lstmaster, List<Tbl_PurchaseDetails> lstdetails, List<Tbl_PurchaseInventory> lstinventory, List<Tbl_CurrentInventory> lstcurInventory)
        {
            aPurchaseService.SavePurchase(lstmaster, lstdetails,lstinventory,lstcurInventory);
        
        }

        #endregion

    }
}
