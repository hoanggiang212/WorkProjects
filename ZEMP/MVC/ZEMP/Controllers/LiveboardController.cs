using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZEMP.Models;
using ZEMP.DAO;
using ZEMP.DTO;
using ZEMP.Header;

namespace ZEMP.Controllers
{
    public class LiveboardController : Controller
    {
        // GET: Liveboard
        public ActionResult Index()
        {
            //get current account logged
            ZEMP_USER account = Session[CommonHeader.ssAccount] as ZEMP_USER;

            if (account == null)
            {
                return RedirectToAction(CommonHeader.mtdAccountIndex, CommonHeader.ctlAccount);
            }
            CommonDTO cm = new CommonDTO();

            //Get codition from current account logged
            FilterCondition filter = new FilterCondition();
            filter.SystemId = account.SystemId;

            //get data of current date
            filter.DateFrom = DateTime.Now;
            filter.DateTo = DateTime.Now;

            string strResult = cm.GetPhanQuyen(ref filter, account);
            if (strResult != CommonHeader.ResultOK)
            {
                ViewBag.Result = strResult;
                return View("Index", filter);
            }


            ViewBag.Result = strResult;
            return View("Index", filter);
        }
    }
}