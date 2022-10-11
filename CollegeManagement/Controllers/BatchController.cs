using CollegeManagement.DataAccessLayer;
using CollegeManagement.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagement.Controllers
{
    public class BatchController : Controller
    {
        Batchdal aDal = new Batchdal();
        // GET: Batch
        public ActionResult Listview()
        {
            return View();
        }

        public ActionResult AddNewInfo(int? MasterId)
        {
            return View();
        }

        public JsonResult Save_Info(BatchDataObject aDao)
        {
            string Mes = "";
            try
            {
                aDal.AddNewInfoDAL(aDao);
                Mes = "Operation Successfull!!!";
            }
            catch (Exception ex)
            {
                Mes = "Operation Failed";
            }
            return Json(Mes,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update_Info(BatchDataObject aDao)
        {
            string Mes = "";
            try
            {
                aDal.UpdateInfoDAL(aDao);
                Mes = "Operation Successfull!!!";
            }
            catch (Exception ex)
            {
                Mes = "Operation Failed";
            }
            return Json(Mes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Load_Data()
        {
            DataSet ds = aDal.LoadAllDataDAL();
            List<BatchDataObject> lists = new List<BatchDataObject>();
            foreach (DataRow dr  in ds.Tables[0].Rows)
            {
                lists.Add(new BatchDataObject
                {
                    Batch_Id = Convert.ToInt32(dr["Batch_Id"]),
                    SL = (dr["SL"].ToString()),
                    BName = (dr["BName"].ToString()),
                });
            }
            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMasterDataById(int MasterId)
        {
            DataSet ds = aDal.LoadDataByMasterIdDAL(MasterId);
            List<BatchDataObject> lists = new List<BatchDataObject>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lists.Add(new BatchDataObject
                {
                    Batch_Id = Convert.ToInt32(dr["Batch_Id"]),
                    BName = (dr["BName"].ToString()),
                });
            }
            return Json(lists, JsonRequestBehavior.AllowGet);
        }
    }
}