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

            ViewBag.SelectedMode        = filter.ListModeView;
            ViewBag.SelectedCapDo       = filter.ListCapDo;
            ViewBag.SelectedGiaTriCapDo = filter.ListGiaTriCapDo;
            ViewBag.SelectedCongDoan    = filter.ListCongDoan;

            ViewBag.Result = strResult;
            return View("Index", filter);
        }


        public ActionResult GetSub(string CapDoID)
        {            
            var account = Session[CommonHeader.ssAccount] as ZEMP_USER;

            List<SelectListItem> items = new List<SelectListItem>();

            AccountDTO accDO = new AccountDTO();

            items = accDO.GetListGiaTriCapDo(account, CapDoID);
            
            // you may replace the above code with data reading from database based on the id

            return Json(items, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetListData(string level, string capdo, string giaTriCapdo, string congDoan)
        {
            FilterCondition filter = new FilterCondition()
            {
                SystemId        = CommonHeader.defaultSystemId,
                SelectedMode    = level,
                SelectedCapDo   = capdo,
                SelectedGiaTriCapDo = giaTriCapdo,
                SelectedCongDoan    = congDoan
            };

            LiveboardDTO lvDto = new LiveboardDTO();

            string sToDay = string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            List<SanLuongOnline> listSanLuong = lvDto.GetSanLuongOnline(level, capdo, giaTriCapdo, congDoan, sToDay);

            ViewData[CommonHeader.VIEWDATA_SL_ONLINE] = listSanLuong;

            return PartialView(filter);
        }
    }
}