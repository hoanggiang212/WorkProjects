using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TbsGroup.Models;
using TbsGroup.ViewModels;

namespace TbsGroup.Controllers
{
    public class LiveboardController : Controller
    {
        // GET: Liveboard
        public ActionResult Index([Bind(Include = "SelectedMode,SelectedCapdo,SelectedGiaTriCapDo,SelectedCongDoan")]FilterCoditionModel FilterCodition)
        {
            var CurrentUser = Session["Username"] as BI_USER;

            if (CurrentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string strResult = String.Empty;

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                CommonModel cm = new CommonModel();

                try
                {
                    //get user login
                    FilterCodition.MANDT = CurrentUser.MANDT;
                    FilterCodition.SYSID = CurrentUser.SYSID;

                    //add mode view


                    //get data of current date
                    FilterCodition.DateFrom = DateTime.Now;
                    FilterCodition.DateTo = DateTime.Now;

                    strResult = cm.GetPhanQuyen(ref FilterCodition, CurrentUser.Username);
                    ViewBag.SelectedCapDo = FilterCodition.ListCapDo;
                    ViewBag.SelectedGiaTriCapDo = FilterCodition.ListGiaTriCapDo;
                    ViewBag.GiatriCapDo = FilterCodition.SelectedGiaTriCapDo;

                    //lay danh sach cong doan
                    cm.GetCongDoanAll(ref FilterCodition);

                    ViewBag.SelectedCongDoan = FilterCodition.ListCongDoan;

                    cm.getModeView(ref FilterCodition);
                    ViewBag.SelectedMode = FilterCodition.ListModeView;                    

                    return View("Index", FilterCodition);
                }
                catch (Exception ex)
                {
                    ViewBag.MessagePQ = "Chưa được cấp quyền" + ex.Message;
                    return View();
                }
            }
        }

        public ActionResult GetListData(string level, string capdo, string giaTriCapdo, string congDoan, string sStyle)
        {
            FilterCoditionModel filter = new FilterCoditionModel()
            {
                MANDT = "900",
                SYSID = "P01",
                SelectedMode = level,
                SelectedCapDo = capdo,
                SelectedGiaTriCapDo = giaTriCapdo,
                SelectedCongDoan = congDoan
            };

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                var CurrentUser = Session["Username"] as BI_USER;
                CommonModel cm = new CommonModel();
                //Mode xem
                if (filter.SelectedMode == null)
                {
                    filter.SelectedMode = "CHUYEN";
                }
                List<SanLuongOnline> slOnline = cm.GetSanLuongOnline(filter, CurrentUser.Username);
                ViewData["SL_Online"] = slOnline;
            }

            //asign style for table
            switch (sStyle)
            {
                case "Default":
                    ViewBag.ClassName = "tablesorter-default";
                    break;
                case "Blue":
                    ViewBag.ClassName = "tablesorter-blue";
                    break;
                case "Dark":
                    ViewBag.ClassName = "tablesorter-dark";
                    break;
            }

            return PartialView(filter);
        }

        public ActionResult GetSub(string CapDoID)
        {
            TKTDSXEntities dc = new TKTDSXEntities();
            var CurrentUser = Session["Username"] as BI_USER;

            List<BI_PHAN_QUYEN> listPQ = dc.BI_PHAN_QUYEN.Where(p => p.MANDT == CurrentUser.MANDT &&
                            p.SYSID == CurrentUser.SYSID
                            &&p.CapDo == CapDoID && p.Username == CurrentUser.Username).ToList();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (BI_PHAN_QUYEN item in listPQ)
            {
                items.Add(new SelectListItem() { Text = item.DGGiaTri, Value = item.GiaTri });
            }

            // you may replace the above code with data reading from database based on the id

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RefreshCD(string GiaTriCapDoID)
        {
            string strMandt = "900";
            string strSysid = "P01";
            TKTDSXEntities dc = new TKTDSXEntities();
            var CurrentUser = Session["Username"] as BI_USER;
            List<SelectListItem> items = new List<SelectListItem>();

            BI_PHAN_QUYEN dataPQ = dc.BI_PHAN_QUYEN.Where(p => p.GiaTri == GiaTriCapDoID && p.Username == CurrentUser.Username).FirstOrDefault();
            IQueryable<string> listCD;
            string strTenCD = string.Empty;

            items.Add(new SelectListItem() { Text = "Tất Cả", Value = "ALL" });
            switch(dataPQ.CapDo)
            {
                case "NGANH":
                    listCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.NGANH == dataPQ.GiaTri).Select(s => s.CDOAN).Distinct();
                    foreach( string strCD in listCD)
                    {
                        strTenCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.NGANH == dataPQ.GiaTri).Select(s => s.TENCD).FirstOrDefault();
                        items.Add(new SelectListItem() { Text = strTenCD, Value = strCD });
                    }
                    break;
                case "KHVUC":
                    listCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.KHVUC == dataPQ.GiaTri).Select(s => s.CDOAN).Distinct();
                    foreach (string strCD in listCD)
                    {
                        strTenCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.KHVUC == dataPQ.GiaTri).Select(s => s.TENCD).FirstOrDefault();
                        items.Add(new SelectListItem() { Text = strTenCD, Value = strCD });
                    }
                    break;
                case "WRKCT":
                    listCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.WRKCT == dataPQ.GiaTri).Select(s => s.CDOAN).Distinct();
                    foreach (string strCD in listCD)
                    {
                        strTenCD = dc.BI_ZQLSX.Where(w => w.MANDT == strMandt && w.SYSID == strSysid &&
                            w.WRKCT == dataPQ.GiaTri).Select(s => s.TENCD).FirstOrDefault();
                        items.Add(new SelectListItem() { Text = strTenCD, Value = strCD });
                    }
                    break;
            }

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}