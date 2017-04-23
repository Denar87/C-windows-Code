using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;
namespace IMS_Business
{
   public class CurrentInventoryBusiness
    {
       CurrentInventoryService aCurrentInventoryService = new CurrentInventoryService();
       ~CurrentInventoryBusiness()
       {
           aCurrentInventoryService.Dispose();
           aCurrentInventoryService = null;
       }
       public Tbl_CurrentInventory GetInventoryByProductId(int productId)
       {
           return aCurrentInventoryService.GetInventoryByProductId(productId);
       }
       public List<Tbl_CurrentInventory> GetInventoryByProductId1(int productId)
       {
           return aCurrentInventoryService.GetInventoryByProductId1(productId);
       }
       public GetItemCurrentStock GetInventoryByProductId2(int productId)
       {
           return aCurrentInventoryService.GetInventoryByProductId2(productId);
       }
       public bool InsertorUpdateCurrentInventory(List<Tbl_CurrentInventory> lstCurrentInventoryList)
       {
           return aCurrentInventoryService.InsertorUpdateCurretnInventory(lstCurrentInventoryList) > 0;
       }
       public List<Qry_CurrentInventory> GetAllQryCurrentInventory()
       {
           return aCurrentInventoryService.GetAllQryCurrentInventory();
       }
      
    }
}
