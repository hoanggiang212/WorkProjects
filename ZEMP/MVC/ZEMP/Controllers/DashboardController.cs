using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZEMP.Models;
using ZEMP.DAO;
using ZEMP.DTO;
using ZEMP.Header;
using System.Collections;

namespace ZEMP.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
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
            filter.DateFrom = DateTime.Now.AddDays(-7);
            filter.DateTo = DateTime.Now;

            string strResult = cm.GetPhanQuyen(ref filter, account);
            if (strResult != CommonHeader.ResultOK)
            {
                ViewBag.Result = strResult;
                return View("Index", filter);
            }

            ViewBag.SelectedCapDo                   = filter.ListCapDo;
            IEnumerable<SelectListItem> initList    = new List<SelectListItem>();
            ViewBag.SelectedGiaTriCapDo             = initList;
            ViewBag.SelectedCongDoan                = filter.ListCongDoan;

            ViewBag.Result = strResult;
            return View("Index", filter);
        }


        public ActionResult GetSub(string CapDoID)
        {
            var account = Session[CommonHeader.ssAccount] as ZEMP_USER;

            List<SelectListItem> items = new List<SelectListItem>();

            if (CapDoID != "")
            {
                AccountDTO accDO = new AccountDTO();

                items = accDO.GetListGiaTriCapDo(account, CapDoID);
            }

            // you may replace the above code with data reading from database based on the id

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public void LoadDataCharts(string sCapDo, string sGiaTriCapDo, string sCongDoan,
                                           string sDateFrom, string sDateTo)
        {
            //DELCARATION
            var listKhTh = new List<KHTHReturn>();
            var listCountStatus = new List<CountStatus>();
            var listChiPhi = new List<ChiPhiSanXuat>();

            FilterCondition f = new FilterCondition() {
                SystemId            = CommonHeader.defaultSystemId,
                SelectedCapDo       = sCapDo,
                SelectedGiaTriCapDo = sGiaTriCapDo,
                SelectedCongDoan    = sCongDoan,
                DateFrom            = DateTime.Parse(sDateFrom),
                DateTo              = DateTime.Parse(sDateTo)};
            f.ConvertDate2Sql();

            DashboardDTO dashDto = new DashboardDTO();
           
            //get data ke hoach / thuc hien
            listKhTh = dashDto.GetKeHoachThucHien(f);

            //get so luong chuyen theo status / ngay
            listCountStatus = dashDto.CountStatusChuyen(f);

            listChiPhi = dashDto.GetChiPhiSanXuat(f);

        }
    }
}