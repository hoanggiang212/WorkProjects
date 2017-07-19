using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TbsGroup.Models;
using TbsGroup.ViewModels;
using Newtonsoft.Json;

namespace TbsGroup.Controllers
{
    public class GridViewController : Controller
    {
        public ActionResult Index([Bind(Include = "SelectedCapdo,SelectedGiaTriCapDo,SelectedCongDoan,DateFrom,DateTo")]FilterCoditionModel FilterCodition)
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
                    FilterCodition.MANDT = CurrentUser.MANDT;
                    FilterCodition.SYSID = CurrentUser.SYSID;

                    strResult = cm.GetPhanQuyen(ref FilterCodition, CurrentUser.Username);

                    cm.GetCongDoanDauRa(ref FilterCodition);

                    ViewBag.SelectedCapDo = FilterCodition.ListCapDo;
                    ViewBag.SelectedGiaTriCapDo = FilterCodition.ListGiaTriCapDo;
                    ViewBag.SelectedCongDoan = FilterCodition.ListCongDoan;

                    if (FilterCodition.DateFrom > FilterCodition.DateTo)
                    {
                        ViewBag.MessagePQ = "Ngày bắt đầu không được lớn hơn ngày kết thúc";
                        return View("TestDashboard", FilterCodition);
                    }

                    ViewBag.GiatriCapDo = FilterCodition.SelectedGiaTriCapDo;

                    ArrayList chartSanLuong = new ArrayList();
                    ArrayList StatusChart = new ArrayList();

                    List<TrangThaiChuyen> ListDataStatus = new List<TrangThaiChuyen>();

                    //Chart San Luong
                    List<SanLuongNgay> sln = cm.GetSanLuongNgay(FilterCodition, ref chartSanLuong, ref ListDataStatus);
                    //string strData = JsonConvert.SerializeObject(chartSanLuong, Formatting.None);
                    //ViewBag.DataChartSLNgay = new HtmlString(strData);
                    sln.OrderByDescending(o => o.Ngay);
                    ViewData["SanLuongNgay"] = sln;

                    //Chart Status
                    ArrayList HeaderStatus = new ArrayList();
                    HeaderStatus.Add((object)string.Format("{0}", "Ngay"));
                    HeaderStatus.Add((object)string.Format("{0}", "< 95%"));
                    HeaderStatus.Add((object)string.Format("{0}", "95-100%"));
                    HeaderStatus.Add((object)string.Format("{0}", "> 100%"));
                    //HeaderStatus.Add((object)string.Format("{0}", "Khác"));
                    StatusChart.Add(HeaderStatus);

                    foreach (TrangThaiChuyen statusCH in ListDataStatus)
                    {
                        ArrayList dataChart = new ArrayList();
                        dataChart.Add(statusCH.Ngay.ToShortDateString());
                        dataChart.Add(statusCH.redStatus);
                        dataChart.Add(statusCH.yellowStatus);
                        dataChart.Add(statusCH.greenStatus);
                        //dataChart.Add(statusCH.otherStatus);
                        StatusChart.Add(dataChart);
                    }

                    //strData = string.Empty;
                    //strData = JsonConvert.SerializeObject(StatusChart, Formatting.None);
                    //ViewBag.DataChartStatus = new HtmlString(strData);

                    ViewData["StatusChuyen"] = ListDataStatus;


                    // Lay thong di di lam / nghi phep
                    List<ThongKeLaoDong> listTKLD = new List<ThongKeLaoDong>();
                    listTKLD = cm.GetThongKeLaoDong(FilterCodition);
                    //create array list so luong lao dong --> chart
                    ArrayList TkldChart = new ArrayList();
                    ArrayList tkldHeader = new ArrayList();
                    tkldHeader.Add((object)string.Format("{0}", "Ngày"));
                    tkldHeader.Add((object)string.Format("{0}", "Tổng LĐ"));
                    tkldHeader.Add((object)string.Format("{0}", "% Vắng"));
                    TkldChart.Add(tkldHeader);
                    foreach (ThongKeLaoDong tkItem in listTKLD)
                    {
                        //DayOfWeek dayOfWeek = tkItem.Ngay.DayOfWeek;
                        //if (dayOfWeek == DayOfWeek.Sunday)
                        //{
                        //    continue;
                        //}
                        ArrayList item = new ArrayList();
                        item.Add(tkItem.Ngay.ToShortDateString());

                        double ptVang = Math.Round((double)tkItem.SoLuongNghi / (double)tkItem.TongSoLuong * 100, 1);

                        item.Add(tkItem.TongSoLuong);
                        item.Add(ptVang);
                        TkldChart.Add(item);
                    }
                    ViewData["ThongKeLD"] = listTKLD;
                    //strData = JsonConvert.SerializeObject(TkldChart, Formatting.None);
                    //ViewBag.DataTkld = new HtmlString(strData);


                    //********************Get Nang Suat lao Dong **************************
                    ArrayList chartNangSuat = new ArrayList();
                    List<NangSuatLaoDong> listNangSuatTheoSL = cm.GetNangSuatSanLuong(FilterCodition, ref chartNangSuat);
                    ViewData["NSLD"] = listNangSuatTheoSL;
                    //strData = JsonConvert.SerializeObject(chartNangSuat, Formatting.None);
                    //ViewBag.DataNsld = new HtmlString(strData);
                    //********************Get Nang Suat lao Dong **************************



                    //*********TINH TOAN GIA THANH PHAN XUONG********************
                    ArrayList chartGiaThanhPhanXuong = new ArrayList();
                    List<GiaThanhPhanXuong> listGtpx = cm.GetGiaThanhPhanXuong(FilterCodition);


                    //Data for Chart Gia Thanh Phan Xuong
                    ArrayList headerGTPX = new ArrayList();
                    headerGTPX.Add("Công Đoạn");
                    headerGTPX.Add("Vật Tư");
                    headerGTPX.Add("Tài Sản");
                    headerGTPX.Add("Nhân Công");
                    chartGiaThanhPhanXuong.Add(headerGTPX);

                    //data for chart nang suat lao dong tong the
                    List<NangSuatTongThe> listNSTT = new List<NangSuatTongThe>();

                    if (FilterCodition.SelectedCongDoan != "ALL")
                    {
                        // Tính tổng giá trị
                        GiaThanhPhanXuong tongGTPX = new GiaThanhPhanXuong();
                        for (int i = 0; i < listGtpx.Count; i++)
                        {
                            tongGTPX.gtNhanCongKeHoach += listGtpx[i].gtNhanCongKeHoach;
                            tongGTPX.gtVatTuKeHoach += listGtpx[i].gtVatTuKeHoach;
                            tongGTPX.gtTaiSanKeHoach += listGtpx[i].gtTaiSanKeHoach;
                            tongGTPX.gtNhanCongThucHien += listGtpx[i].gtNhanCongThucHien;
                            tongGTPX.gtVatTuThucHien += listGtpx[i].gtVatTuThucHien;
                            tongGTPX.gtTaiSanThucHien += listGtpx[i].gtTaiSanThucHien;
                        }


                        tongGTPX.ptNhanCongKeHoach = Math.Round(tongGTPX.gtNhanCongKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                        tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                        tongGTPX.ptVatTuKeHoach = Math.Round(tongGTPX.gtVatTuKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                    tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                        tongGTPX.ptTaiSanKeHoach = Math.Round(tongGTPX.gtTaiSanKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                    tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                        tongGTPX.ptNhanCongThucHien = Math.Round(tongGTPX.gtNhanCongThucHien / (tongGTPX.gtNhanCongThucHien +
                                                    tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);
                        tongGTPX.ptVatTuThucHien = Math.Round(tongGTPX.gtVatTuThucHien / (tongGTPX.gtNhanCongThucHien +
                                                    tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);
                        tongGTPX.ptTaiSanThucHien = Math.Round(tongGTPX.gtTaiSanThucHien / (tongGTPX.gtNhanCongThucHien +
                                                    tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);


                        //add row ke hoach
                        ArrayList lineKeHoach = new ArrayList();
                        lineKeHoach.Add(string.Format("KH-{0}", FilterCodition.SelectedCongDoan));
                        lineKeHoach.Add(tongGTPX.ptVatTuKeHoach);
                        lineKeHoach.Add(tongGTPX.ptTaiSanKeHoach);
                        lineKeHoach.Add(tongGTPX.ptNhanCongKeHoach);
                        //add line to list
                        chartGiaThanhPhanXuong.Add(lineKeHoach);

                        //add line thuc hien
                        ArrayList lineThucHien = new ArrayList();
                        lineThucHien.Add(string.Format("TH-{0}", FilterCodition.SelectedCongDoan));
                        lineThucHien.Add(tongGTPX.ptVatTuThucHien);
                        lineThucHien.Add(tongGTPX.ptTaiSanThucHien);
                        lineThucHien.Add(tongGTPX.ptNhanCongThucHien);
                        //add line to list
                        chartGiaThanhPhanXuong.Add(lineThucHien);

                        //tinh nhan cong binh quan
                        int iCountLD = 0;
                        double iLDBQ = 0;
                        double dNSTT = 0;
                        double dTongNS = 0;
                        foreach (NangSuatLaoDong nsld in listNangSuatTheoSL)
                        {
                            if (nsld.CongDoan != FilterCodition.SelectedCongDoan) continue;
                            iLDBQ += nsld.SoLuongLaoDong;
                            dTongNS += nsld.NangSuat;
                            iCountLD++;
                        }

                        if (iCountLD > 0)
                        {
                            iLDBQ = iLDBQ / (double)iCountLD;
                            dTongNS = dTongNS / (double)iCountLD;
                            dNSTT = Math.Round((Double)((tongGTPX.gtNhanCongThucHien + tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) / iLDBQ), 2);
                        }


                        NangSuatTongThe lineNSTT = new NangSuatTongThe();
                        lineNSTT.CongDoan = FilterCodition.SelectedCongDoan;
                        lineNSTT.SoLuongLaoDong = Math.Round(iLDBQ, 0);
                        lineNSTT.ptChiPhiNc = Math.Round(tongGTPX.ptNhanCongThucHien, 2);
                        lineNSTT.ptChiPhiVt = Math.Round(tongGTPX.ptVatTuThucHien, 2);
                        lineNSTT.ptChiPhiTs = Math.Round(tongGTPX.ptTaiSanThucHien, 2);
                        lineNSTT.NangSuatTT = Math.Round(dNSTT, 2);
                        lineNSTT.NangSuatSL = Math.Round(dTongNS, 2);
                        listNSTT.Add(lineNSTT);
                    }
                    else
                    {
                        foreach (SelectListItem cdoan in FilterCodition.ListCongDoan)
                        {
                            if (cdoan.Value == "ALL") continue;
                            long iCount = 0;
                            GiaThanhPhanXuong tongGTPX = new GiaThanhPhanXuong();
                            for (int i = 0; i < listGtpx.Count; i++)
                            {
                                if (cdoan.Value != listGtpx[i].CongDoan) continue;
                                tongGTPX.gtNhanCongKeHoach += listGtpx[i].gtNhanCongKeHoach;
                                tongGTPX.gtVatTuKeHoach += listGtpx[i].gtVatTuKeHoach;
                                tongGTPX.gtTaiSanKeHoach += listGtpx[i].gtTaiSanKeHoach;
                                tongGTPX.gtNhanCongThucHien += listGtpx[i].gtNhanCongThucHien;
                                tongGTPX.gtVatTuThucHien += listGtpx[i].gtVatTuThucHien;
                                tongGTPX.gtTaiSanThucHien += listGtpx[i].gtTaiSanThucHien;

                                iCount++;
                            }


                            tongGTPX.ptNhanCongKeHoach = Math.Round(tongGTPX.gtNhanCongKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                        tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                            tongGTPX.ptVatTuKeHoach = Math.Round(tongGTPX.gtVatTuKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                        tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                            tongGTPX.ptTaiSanKeHoach = Math.Round(tongGTPX.gtTaiSanKeHoach / (tongGTPX.gtNhanCongKeHoach +
                                                        tongGTPX.gtVatTuKeHoach + tongGTPX.gtTaiSanKeHoach) * 100, 2);

                            tongGTPX.ptNhanCongThucHien = Math.Round(tongGTPX.gtNhanCongThucHien / (tongGTPX.gtNhanCongThucHien +
                                                        tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);
                            tongGTPX.ptVatTuThucHien = Math.Round(tongGTPX.gtVatTuThucHien / (tongGTPX.gtNhanCongThucHien +
                                                        tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);
                            tongGTPX.ptTaiSanThucHien = Math.Round(tongGTPX.gtTaiSanThucHien / (tongGTPX.gtNhanCongThucHien +
                                                        tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) * 100, 2);

                            //add row ke hoach
                            ArrayList lineKeHoach = new ArrayList();
                            lineKeHoach.Add(string.Format("KH-{0}", cdoan.Value));
                            lineKeHoach.Add(tongGTPX.ptVatTuKeHoach);
                            lineKeHoach.Add(tongGTPX.ptTaiSanKeHoach);
                            lineKeHoach.Add(tongGTPX.ptNhanCongKeHoach);
                            //add line to list
                            chartGiaThanhPhanXuong.Add(lineKeHoach);

                            //add line thuc hien
                            ArrayList lineThucHien = new ArrayList();
                            lineThucHien.Add(string.Format("TH-{0}", cdoan.Value));
                            lineThucHien.Add(tongGTPX.ptVatTuThucHien);
                            lineThucHien.Add(tongGTPX.ptTaiSanThucHien);
                            lineThucHien.Add(tongGTPX.ptNhanCongThucHien);
                            //add line to list
                            chartGiaThanhPhanXuong.Add(lineThucHien);



                            //tinh nhan cong binh quan
                            int iCountLD = 0;
                            double iLDBQ = 0;
                            double dNSTT = 0;
                            double dTongNS = 0;
                            foreach (NangSuatLaoDong nsld in listNangSuatTheoSL)
                            {
                                if (nsld.CongDoan != cdoan.Value) continue;
                                iLDBQ += nsld.SoLuongLaoDong;
                                dTongNS += nsld.NangSuat;
                                iCountLD++;
                            }

                            if (iCountLD > 0)
                            {
                                iLDBQ = iLDBQ / (double)iCountLD;
                                dTongNS = dTongNS / (double)iCountLD;
                                dNSTT = Math.Round((Double)((tongGTPX.gtNhanCongThucHien + tongGTPX.gtVatTuThucHien + tongGTPX.gtTaiSanThucHien) / iLDBQ), 2);
                            }


                            NangSuatTongThe lineNSTT = new NangSuatTongThe();
                            lineNSTT.CongDoan = cdoan.Value;
                            lineNSTT.SoLuongLaoDong = Math.Round(iLDBQ, 0);
                            lineNSTT.ptChiPhiNc = Math.Round(tongGTPX.ptNhanCongThucHien, 2);
                            lineNSTT.ptChiPhiVt = Math.Round(tongGTPX.ptVatTuThucHien, 2);
                            lineNSTT.ptChiPhiTs = Math.Round(tongGTPX.ptTaiSanThucHien, 2);
                            lineNSTT.NangSuatTT = Math.Round(dNSTT, 2);
                            lineNSTT.NangSuatSL = Math.Round(dTongNS, 2);
                            listNSTT.Add(lineNSTT);

                        }
                    }

                    ViewData["NSTT"] = listNSTT;

                    string strData = JsonConvert.SerializeObject(chartGiaThanhPhanXuong, Formatting.None);
                    ViewBag.DataGtpx = new HtmlString(strData);

                    ArrayList CommomArray = new ArrayList();
                    bool iFound = false;
                    for (int i = 0; i < chartSanLuong.Count; i++)
                    {
                        ArrayList lineCommon = new ArrayList();
                        if (i == 0) //Header
                        {
                            lineCommon.Add((object)string.Format("{0}", "Ngày"));

                            ArrayList headerSanLuong = (ArrayList)chartSanLuong[0];

                            //add header san luong
                            for (int s = 1; s < headerSanLuong.Count; s++)
                            {
                                lineCommon.Add((object)string.Format("SL-{0}", headerSanLuong[s]));
                            }

                            //add header thong ke chuyen
                            ArrayList headerStatus = (ArrayList)StatusChart[0];
                            for (int s = 1; s < headerStatus.Count; s++)
                            {
                                lineCommon.Add((object)string.Format("ST-{0}", headerStatus[s]));
                            }

                            //add header nang suat lao dong
                            ArrayList headerNS = (ArrayList)chartNangSuat[0];
                            for (int n = 1; n < headerNS.Count; n++)
                            {
                                lineCommon.Add((object)string.Format("NS-{0}", headerNS[n]));
                            }

                            //add header thong ke lao dong
                            ArrayList headerTkld = (ArrayList)TkldChart[0];
                            for (int l = 1; l < headerTkld.Count; l++)
                            {
                                lineCommon.Add((object)string.Format("LD-{0}", headerTkld[l]));
                            }

                        }
                        else //line item
                        {

                            ArrayList lineSanLuong = (ArrayList)chartSanLuong[i];

                            //add line san luong
                            for (int s = 0; s < lineSanLuong.Count; s++)
                            {
                                lineCommon.Add((lineSanLuong[s]));
                            }

                            iFound = false;
                            //add line thong ke chuyen
                            for (int y = 1; y < StatusChart.Count; y++)
                            {
                                ArrayList lineStatus = (ArrayList)StatusChart[y];
                                if (lineCommon[0].ToString() != lineStatus[0].ToString()) { continue; }
                                iFound = true;
                                for (int s = 1; s < lineStatus.Count; s++)
                                {
                                    lineCommon.Add(lineStatus[s]);
                                }
                                break;
                            }

                            if (!iFound)
                            {
                                ArrayList lineStatus = (ArrayList)StatusChart[0];
                                for (int s = 1; s < lineStatus.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }

                            iFound = false;
                            //add line nang suat
                            for (int y = 1; y < chartNangSuat.Count; y++)
                            {
                                ArrayList line = (ArrayList)chartNangSuat[y];
                                if (lineCommon[0].ToString() != line[0].ToString()) { continue; }
                                iFound = true;
                                for (int n = 1; n < line.Count; n++)
                                {
                                    lineCommon.Add(line[n]);
                                }
                                break;
                            }

                            if (!iFound)
                            {
                                ArrayList line = (ArrayList)chartNangSuat[0];
                                for (int s = 1; s < line.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }

                            //add line thong ke lao dong
                            iFound = false;
                            for (int y = 1; y < TkldChart.Count; y++)
                            {
                                ArrayList line = (ArrayList)TkldChart[y];
                                if (lineCommon[0].ToString() != line[0].ToString()) { continue; }
                                iFound = true;
                                for (int l = 1; l < line.Count; l++)
                                {
                                    lineCommon.Add(line[l]);
                                }
                                break;
                            }
                            if (!iFound)
                            {
                                ArrayList line = (ArrayList)TkldChart[0];
                                for (int s = 1; s < line.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }
                        }
                        CommomArray.Add(lineCommon);
                    }

                    strData = JsonConvert.SerializeObject(CommomArray, Formatting.None);
                    ViewBag.DataCommon = new HtmlString(strData);

                    //*********TINH TOAN GIA THANH PHAN XUONG********************


                    if (FilterCodition.SelectedCapDo == "NGANH")
                    {

                        ViewBag.CapDo = "NGÀNH";
                    }
                    else if (FilterCodition.SelectedCapDo == "KHVUC")
                    {
                        ViewBag.CapDo = "KHU VỰC";
                    }
                    else if (FilterCodition.SelectedCapDo == "WRKCT")
                    {
                        ViewBag.CapDo = "WORK CENTER";
                    }
                    return View("Index", FilterCodition);
                }
                catch (Exception ex)
                {
                    ViewData["SanLuongNgay"] = null;
                    ViewBag.MessagePQ = "Chưa được cấp quyền" + ex.Message;
                    return View("Index");
                }
            }

        }


        public ActionResult Details(string mandt, string sysid,
                                    string CapDo, string GiaTriCapDo,
                                    string CongDoan, DateTime Date)
        {
            List<SanLuongNgay> SL_Details = new List<SanLuongNgay>();
            CommonModel cm = new CommonModel();

            ViewBag.CapDoCha = GiaTriCapDo;
            ViewBag.Ngay = Date.ToShortDateString();
            if (CapDo == "NGANH")
            {
                ViewBag.CapDoCon = "Khu Vực";
                SL_Details = cm.GetDetailNganh(mandt, sysid, GiaTriCapDo, Date, CongDoan);
            }
            else if (CapDo == "KHVUC")
            {
                ViewBag.CapDoCon = "Work Center";
                SL_Details = cm.GetDetailKhuVuc(mandt, sysid, GiaTriCapDo, Date, CongDoan);
            }
            else
            {
                ViewBag.CapDoCon = "Chuyền";
                SL_Details = cm.GetDetailWrkct(mandt, sysid, GiaTriCapDo, Date, CongDoan);
            }
            ViewData["SLDetails"] = SL_Details;
            return View("Details");
        }
        public ActionResult GetSub(string CapDoID)
        {
            TKTDSXEntities dc = new TKTDSXEntities();
            var CurrentUser = Session["Username"] as BI_USER;

            List<BI_PHAN_QUYEN> listPQ = dc.BI_PHAN_QUYEN.Where(p => p.CapDo == CapDoID && p.Username == CurrentUser.Username).ToList();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (BI_PHAN_QUYEN item in listPQ)
            {
                items.Add(new SelectListItem() { Text = item.DGGiaTri, Value = item.GiaTri });
            }

            // you may replace the above code with data reading from database based on the id

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestDashboard([Bind(Include = "SelectedCapdo,SelectedGiaTriCapDo,SelectedCongDoan,DateFrom,DateTo")]FilterCoditionModel FilterCodition)
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
                    FilterCodition.MANDT = CurrentUser.MANDT;
                    FilterCodition.SYSID = CurrentUser.SYSID;

                    strResult = cm.GetPhanQuyen(ref FilterCodition, CurrentUser.Username);

                    cm.GetCongDoanDauRa(ref FilterCodition);

                    ViewBag.SelectedCapDo = FilterCodition.ListCapDo;
                    ViewBag.SelectedGiaTriCapDo = FilterCodition.ListGiaTriCapDo;
                    ViewBag.SelectedCongDoan = FilterCodition.ListCongDoan;

                    if (FilterCodition.DateFrom > FilterCodition.DateTo)
                    {
                        ViewBag.MessagePQ = "Ngày bắt đầu không được lớn hơn ngày kết thúc";
                        return View("TestDashboard", FilterCodition);
                    }

                    ViewBag.GiatriCapDo = FilterCodition.SelectedGiaTriCapDo;

                    ArrayList chartSanLuong = new ArrayList();
                    ArrayList StatusChart = new ArrayList();

                    List<TrangThaiChuyen> ListDataStatus = new List<TrangThaiChuyen>();

                    //Chart San Luong
                    List<SanLuongNgay> sln = cm.GetSanLuongNgay(FilterCodition, ref chartSanLuong, ref ListDataStatus);
                    string strData = JsonConvert.SerializeObject(chartSanLuong, Formatting.None);
                    ViewBag.DataChartSLNgay = new HtmlString(strData);
                    sln.OrderByDescending(o => o.Ngay);
                    ViewData["SanLuongNgay"] = sln;

                    //Chart Status
                    ArrayList HeaderStatus = new ArrayList();
                    HeaderStatus.Add((object)string.Format("{0}", "Ngay"));
                    HeaderStatus.Add((object)string.Format("{0}", "< 95%"));
                    HeaderStatus.Add((object)string.Format("{0}", "95-100%"));
                    HeaderStatus.Add((object)string.Format("{0}", "> 100%"));
                    //HeaderStatus.Add((object)string.Format("{0}", "Khác"));
                    StatusChart.Add(HeaderStatus);

                    foreach (TrangThaiChuyen statusCH in ListDataStatus)
                    {
                        ArrayList dataChart = new ArrayList();
                        dataChart.Add(statusCH.Ngay.ToShortDateString());
                        dataChart.Add(statusCH.redStatus);
                        dataChart.Add(statusCH.yellowStatus);
                        dataChart.Add(statusCH.greenStatus);
                        //dataChart.Add(statusCH.otherStatus);
                        StatusChart.Add(dataChart);
                    }

                    strData = string.Empty;
                    strData = JsonConvert.SerializeObject(StatusChart, Formatting.None);
                    ViewBag.DataChartStatus = new HtmlString(strData);

                    ViewData["StatusChuyen"] = ListDataStatus;


                    // Lay thong di di lam / nghi phep
                    List<ThongKeLaoDong> listTKLD = new List<ThongKeLaoDong>();
                    listTKLD = cm.GetThongKeLaoDong(FilterCodition);
                    //create array list so luong lao dong --> chart
                    ArrayList TkldChart = new ArrayList();
                    ArrayList tkldHeader = new ArrayList();
                    tkldHeader.Add((object)string.Format("{0}", "Ngày"));
                    tkldHeader.Add((object)string.Format("{0}", "Tổng LĐ"));
                    tkldHeader.Add((object)string.Format("{0}", "% Vắng"));

                    TkldChart.Add(tkldHeader);
                    foreach (ThongKeLaoDong tkItem in listTKLD)
                    {
                     
                        ArrayList item = new ArrayList();
                        item.Add(tkItem.Ngay.ToShortDateString());

                        double ptVang = Math.Round((double)tkItem.SoLuongNghi / (double)tkItem.TongSoLuong * 100, 1);

                        item.Add(tkItem.TongSoLuong);
                        item.Add(ptVang);
                        TkldChart.Add(item);
                    }
                    strData = JsonConvert.SerializeObject(TkldChart, Formatting.None);
                    ViewData["ThongKeLD"] = listTKLD;
                    ViewBag.DataTkld = new HtmlString(strData);


                    //********************Get Nang Suat lao Dong **************************
                    ArrayList chartNangSuat = new ArrayList();
                    List<NangSuatLaoDong> listNangSuatTheoSL = cm.GetNangSuatSanLuong(FilterCodition, ref chartNangSuat);
                    ViewData["NSLD"] = listNangSuatTheoSL;
                    strData = JsonConvert.SerializeObject(chartNangSuat, Formatting.None);
                    ViewBag.DataNsld = new HtmlString(strData);
                    //********************Get Nang Suat lao Dong **************************



                    //*********TINH TOAN GIA THANH PHAN XUONG********************
                    ArrayList chartGiaThanhPhanXuong = new ArrayList();
                    List<GiaThanhPhanXuong> listGtpx = cm.GetGiaThanhPhanXuong(FilterCodition);
                    ViewData["GTPX"] = listGtpx;
                    strData = JsonConvert.SerializeObject(chartGiaThanhPhanXuong, Formatting.None);
                    ViewBag.DataGtpx = new HtmlString(strData);

                    ArrayList CommomArray = new ArrayList();
                    bool iFound = false;
                    for (int i = 0; i < chartSanLuong.Count; i++)
                    {
                        ArrayList lineCommon = new ArrayList();
                        if (i == 0) //Header
                        {
                            lineCommon.Add((object)string.Format("{0}", "Ngày"));

                            ArrayList headerSanLuong = (ArrayList)chartSanLuong[0];

                            //add header san luong
                            for (int s = 1; s < headerSanLuong.Count; s++)
                            {
                                lineCommon.Add((object)string.Format("SL-{0}", headerSanLuong[s]));
                            }

                            //add header thong ke chuyen
                            ArrayList headerStatus = (ArrayList)StatusChart[0];
                            for (int s = 1; s < headerStatus.Count; s++)
                            {
                                lineCommon.Add((object)string.Format("ST-{0}", headerStatus[s]));
                            }

                            //add header nang suat lao dong
                            ArrayList headerNS = (ArrayList)chartNangSuat[0];
                            for (int n = 1; n < headerNS.Count; n++)
                            {
                                lineCommon.Add((object)string.Format("NS-{0}", headerNS[n]));
                            }

                            //add header thong ke lao dong
                            ArrayList headerTkld = (ArrayList)TkldChart[0];
                            for (int l = 1; l < headerTkld.Count; l++)
                            {
                                lineCommon.Add((object)string.Format("LD-{0}", headerTkld[l]));
                            }

                        }
                        else //line item
                        {

                            ArrayList lineSanLuong = (ArrayList)chartSanLuong[i];

                            //add line san luong
                            for (int s = 0; s < lineSanLuong.Count; s++)
                            {
                                lineCommon.Add((lineSanLuong[s]));
                            }

                            iFound = false;
                            //add line thong ke chuyen
                            for (int y = 1; y < StatusChart.Count; y++)
                            {
                                ArrayList lineStatus = (ArrayList)StatusChart[y];
                                if (lineCommon[0].ToString() != lineStatus[0].ToString()) { continue; }
                                iFound = true;
                                for (int s = 1; s < lineStatus.Count; s++)
                                {
                                    lineCommon.Add(lineStatus[s]);
                                }
                                break;
                            }

                            if (!iFound)
                            {
                                ArrayList lineStatus = (ArrayList)StatusChart[0];
                                for (int s = 1; s < lineStatus.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }

                            iFound = false;
                            //add line nang suat
                            for (int y = 1; y < chartNangSuat.Count; y++)
                            {
                                ArrayList line = (ArrayList)chartNangSuat[y];
                                if (lineCommon[0].ToString() != line[0].ToString()) { continue; }
                                iFound = true;
                                for (int n = 1; n < line.Count; n++)
                                {
                                    lineCommon.Add(line[n]);
                                }
                                break;
                            }

                            if (!iFound)
                            {
                                ArrayList line = (ArrayList)chartNangSuat[0];
                                for (int s = 1; s < line.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }

                            //add line thong ke lao dong
                            iFound = false;
                            for (int y = 1; y < TkldChart.Count; y++)
                            {
                                ArrayList line = (ArrayList)TkldChart[y];
                                if (lineCommon[0].ToString() != line[0].ToString()) { continue; }
                                iFound = true;
                                for (int l = 1; l < line.Count; l++)
                                {
                                    lineCommon.Add(line[l]);
                                }
                                break;
                            }
                            if (!iFound)
                            {
                                ArrayList line = (ArrayList)TkldChart[0];
                                for (int s = 1; s < line.Count; s++)
                                {
                                    lineCommon.Add(0);
                                }
                            }
                        }
                        CommomArray.Add(lineCommon);
                    }

                    strData = JsonConvert.SerializeObject(CommomArray, Formatting.None);
                    ViewBag.DataCommon = new HtmlString(strData);

                    //*********TINH TOAN GIA THANH PHAN XUONG********************


                    if (FilterCodition.SelectedCapDo == "NGANH")
                    {

                        ViewBag.CapDo = "Ngành";
                    }
                    else if (FilterCodition.SelectedCapDo == "KHVUC")
                    {
                        ViewBag.CapDo = "Khu Vực";
                    }
                    else if (FilterCodition.SelectedCapDo == "WRKCT")
                    {
                        ViewBag.CapDo = "Work Center";
                    }
                    return View("TestDashboard", FilterCodition);
                }
                catch (Exception ex)
                {
                    ViewData["SLCH"] = null;
                    ViewBag.MessagePQ = "Chưa được cấp quyền" + ex.Message;
                    return View("TestDashboard");
                }
            }

        }
    }
}