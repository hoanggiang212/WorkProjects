using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TbsGroup.Models;
using TbsGroup.ViewModels;

namespace TbsGroup.ViewModels
{
    public class CommonModel
    {
        TKTDSXEntities dc;

        public CommonModel()
        {
            dc = new TKTDSXEntities();
        }

        public bool TrackChange(VW_SL_ONLINE slOnline)
        {
            dc.Dispose();
            var isChange = false;
            BI_SANLUONG_ONLINE_TEMP slTemp;
            using (var getDbContext = new TKTDSXEntities())
            {
                slTemp = getDbContext.BI_SANLUONG_ONLINE_TEMP
                                .Where(w => w.MANDT == slOnline.MANDT && w.SYSID == slOnline.SYSID
                                    && w.ZZCNT == slOnline.ZZCNT && w.CNTCD == slOnline.CNTCD).FirstOrDefault();
            }

            if (slTemp == null)
            {
                isChange = true;
                slTemp = new BI_SANLUONG_ONLINE_TEMP();
                slTemp.MANDT = slOnline.MANDT;
                slTemp.SYSID = slOnline.SYSID;
                slTemp.ZZCNT = slOnline.ZZCNT;
                slTemp.NGAY = slOnline.NGAY;
                slTemp.CNTCD = slOnline.CNTCD;
                slTemp.THNGAY = slOnline.THNGAY;
                slTemp.SLLD = slOnline.SLLD;
                slTemp.NSUAT = slOnline.NSUAT;
                using (var dbContext = new TKTDSXEntities())
                {
                    dbContext.BI_SANLUONG_ONLINE_TEMP.Add(slTemp);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                if (slOnline.THNGAY != slTemp.THNGAY)
                {
                    isChange = true;
                    slTemp.THNGAY = slOnline.THNGAY;
                    using (var dbContext = new TKTDSXEntities())
                    {
                        dbContext.Entry(slTemp).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }

            return isChange;

        }

        public void CongDon(ref SanLuongOnline slOnline, VW_SL_ONLINE item)
        {
            slOnline.GioLamViec += double.Parse(item.GIOLV.ToString());
            slOnline.SanLuongKH += Int64.Parse(item.KHNGAY.ToString());
            slOnline.SanLuongTH += Int64.Parse(item.THNGAY.ToString());
            slOnline.KeHoachGio += double.Parse(item.KHGIO.ToString());
            slOnline.NangSuat += double.Parse(item.NSUAT.ToString());

            if ((item.gio_dalam > 0) && (item.KHGIO > 0))
            {
                slOnline.TienDoGio += (double)item.THNGAY / ((double)item.gio_dalam * (double)item.KHGIO);
            }

            slOnline.Gio01 += Int64.Parse(item.GIO01.ToString());
            slOnline.Gio02 += Int64.Parse(item.GIO02.ToString());
            slOnline.Gio03 += Int64.Parse(item.GIO03.ToString());
            slOnline.Gio04 += Int64.Parse(item.GIO04.ToString());
            slOnline.Gio05 += Int64.Parse(item.GIO05.ToString());
            slOnline.Gio06 += Int64.Parse(item.GIO06.ToString());
            slOnline.Gio07 += Int64.Parse(item.GIO07.ToString());
            slOnline.Gio08 += Int64.Parse(item.GIO08.ToString());
            slOnline.Gio09 += Int64.Parse(item.GIO09.ToString());
            slOnline.Gio10 += Int64.Parse(item.GIO10.ToString());
            slOnline.Gio11 += Int64.Parse(item.GIO11.ToString());
            slOnline.Gio12 += Int64.Parse(item.GIO12.ToString());
            slOnline.Gio13 += Int64.Parse(item.GIO13.ToString());
            slOnline.Gio14 += Int64.Parse(item.GIO14.ToString());
            slOnline.Gio15 += Int64.Parse(item.GIO15.ToString());
            slOnline.Gio16 += Int64.Parse(item.GIO16.ToString());
            slOnline.Gio17 += Int64.Parse(item.GIO17.ToString());
            slOnline.Gio18 += Int64.Parse(item.GIO18.ToString());
            slOnline.Gio19 += Int64.Parse(item.GIO19.ToString());
            slOnline.Gio20 += Int64.Parse(item.GIO20.ToString());
            slOnline.Gio21 += Int64.Parse(item.GIO21.ToString());
            slOnline.Gio22 += Int64.Parse(item.GIO22.ToString());
            slOnline.Gio23 += Int64.Parse(item.GIO23.ToString());
            slOnline.Gio24 += Int64.Parse(item.GIO24.ToString());
        }

        public void Summary(ref SanLuongOnline slOnline, Int64 lv_count)
        {

            slOnline.Gio07 = slOnline.Gio07 + slOnline.Gio06 + slOnline.Gio05 + slOnline.Gio04 + slOnline.Gio03 + slOnline.Gio02 + slOnline.Gio01;
            slOnline.Gio20 = slOnline.Gio20 + slOnline.Gio21 + slOnline.Gio22 + slOnline.Gio23 + slOnline.Gio24;
            //tinh binh quan
            slOnline.GioLamViec = (double)slOnline.GioLamViec / (double)lv_count;
            slOnline.ChenhLech = slOnline.SanLuongTH - slOnline.SanLuongKH;

            //tien do trung binh
            slOnline.TienDoGio = slOnline.TienDoGio / (double)lv_count * 100;
            if (slOnline.isColor != "X")
            {

                if (slOnline.SanLuongKH > 0)
                {
                    slOnline.DatKeHoach = Double.Parse(slOnline.SanLuongTH.ToString()) /
                                        double.Parse(slOnline.SanLuongKH.ToString()) * 100;
                }
                if (slOnline.TienDoGio < 95)
                {
                    slOnline.Status = "ten-bo-phan-red";
                }
                else if ((slOnline.TienDoGio >= 95) && (slOnline.TienDoGio < 100))
                {
                    slOnline.Status = "ten-bo-phan-yellow";
                }
                else if (slOnline.TienDoGio >= 100)
                {
                    slOnline.Status = "ten-bo-phan-green";
                }
                else
                {
                    slOnline.Status = "ten-bo-phan-normal";
                }
            }
        }
        public List<SanLuongOnline> GetSanLuongOnline(FilterCoditionModel filter)
        {
            bool isChange = false;
            var RawList = new List<VW_SL_ONLINE>();
            var FinalList = new List<SanLuongOnline>();
            List<string> listCDoan = new List<string>();
            switch (filter.SelectedCapDo)
            {
                case "NGANH":
                    RawList = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                w.SYSID == filter.SYSID && w.NGANH == filter.SelectedGiaTriCapDo).ToList();
                    break;
                case "KHVUC":
                    RawList = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                w.SYSID == filter.SYSID && w.KHVUC == filter.SelectedGiaTriCapDo).ToList();
                    break;
                case "WRKCT":
                    RawList = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                w.SYSID == filter.SYSID && w.WRKCT == filter.SelectedGiaTriCapDo).ToList();
                    break;
            }

            listCDoan = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                        w.SYSID == filter.SYSID).Select(s => s.CDOAN).Distinct().ToList();

            if (filter.SelectedMode != "CHUYN")
            {
                if (filter.SelectedMode == "NGANH")
                {
                    List<string> listNganh = new List<string>();
                    listNganh = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                     w.SYSID == filter.SYSID).Select(s => s.NGANH).Distinct().ToList();

                    foreach (string strNganh in listNganh)
                    {
                        foreach (string strCdoan in listCDoan)
                        {
                            if (filter.SelectedCongDoan != "ALL")
                            {
                                if (strCdoan != filter.SelectedCongDoan)
                                {
                                    continue;
                                }
                            }
                            var slOnline = new SanLuongOnline();
                            Int64 lv_count = 0;
                            foreach (VW_SL_ONLINE item in RawList)
                            {
                                if ((item.NGANH != strNganh) || (item.CDOAN != strCdoan))
                                {
                                    continue;
                                }

                                if (item.KHNGAY <= 0)
                                {
                                    continue;
                                }

                                lv_count++;
                                if (slOnline.Nganh == null)
                                {
                                    slOnline.Nganh = item.NGANH;
                                    slOnline.TenNganh = item.TNNG;
                                    slOnline.CongDoan = item.CDOAN;
                                    slOnline.TenCongDoan = item.TENCD;
                                }

                                CongDon(ref slOnline, item);
                            }

                            if (lv_count == 0)
                            {
                                continue;
                            }
                            slOnline.isColor = "";
                            Summary(ref slOnline, lv_count);

                            DateTime dtNow = DateTime.Parse(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

                            //lay so luong lao dong
                            BI_SLLDNS objSLLD = dc.BI_SLLDNS.Where(w => w.MANDT == filter.MANDT &&
                                                        w.SYSID == filter.SYSID && w.PDATUM == dtNow &&
                                                        w.CAPDO == "NGANH" && w.BOPHAN == slOnline.Nganh &&
                                                        w.CDOAN == slOnline.CongDoan).FirstOrDefault();
                            if (objSLLD != null)
                            {
                                slOnline.SoLuongLD = Int64.Parse(objSLLD.SLLD.ToString());
                                if (slOnline.SoLuongLD > 0)
                                {
                                    slOnline.NangSuat = (double)slOnline.SanLuongTH / (double)slOnline.SoLuongLD;
                                }
                                else
                                {
                                    slOnline.NangSuat = 0;
                                }
                            }
                            FinalList.Add(slOnline);
                        }
                    }

                }
                else if (filter.SelectedMode == "KHVUC")
                {
                    List<string> listKhuvuc = new List<string>();
                    listKhuvuc = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                     w.SYSID == filter.SYSID).Select(s => s.KHVUC).Distinct().ToList();

                    foreach (string strKhuvuc in listKhuvuc)
                    {
                        foreach (string strCdoan in listCDoan)
                        {
                            if (filter.SelectedCongDoan != "ALL")
                            {
                                if (strCdoan != filter.SelectedCongDoan)
                                {
                                    continue;
                                }
                            }
                            var slOnline = new SanLuongOnline();
                            Int64 lv_count = 0;
                            foreach (VW_SL_ONLINE item in RawList)
                            {
                                if ((item.KHVUC != strKhuvuc) || (item.CDOAN != strCdoan))
                                {
                                    continue;
                                }

                                if (item.KHNGAY <= 0)
                                {
                                    continue;
                                }

                                lv_count++;
                                if (slOnline.KhuVuc == null)
                                {
                                    slOnline.KhuVuc = item.KHVUC;
                                    slOnline.TenKhuVuc = item.TNKV;
                                    slOnline.CongDoan = item.CDOAN;
                                    slOnline.TenCongDoan = item.TENCD;
                                }
                                CongDon(ref slOnline, item);
                            }

                            if (lv_count == 0)
                            {
                                continue;
                            }
                            slOnline.isColor = "";
                            //tinh summary
                            Summary(ref slOnline, lv_count);

                            DateTime dtNow = DateTime.Parse(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

                            //lay so luong lao dong
                            BI_SLLDNS objSLLD = dc.BI_SLLDNS.Where(w => w.MANDT == filter.MANDT &&
                                                        w.SYSID == filter.SYSID && w.PDATUM == dtNow &&
                                                        w.CAPDO == "KHVUC" && w.BOPHAN == slOnline.KhuVuc &&
                                                        w.CDOAN == slOnline.CongDoan).FirstOrDefault();
                            if (objSLLD != null)
                            {
                                slOnline.SoLuongLD = Int64.Parse(objSLLD.SLLD.ToString());
                                if (slOnline.SoLuongLD > 0)
                                {
                                    slOnline.NangSuat = (double)slOnline.SanLuongTH / (double)slOnline.SoLuongLD;
                                }
                                else
                                {
                                    slOnline.NangSuat = 0;
                                }
                            }

                            FinalList.Add(slOnline);
                        }
                    }
                }
                else if (filter.SelectedMode == "WRKCT")
                {
                    List<string> listWrkct = new List<string>();
                    listWrkct = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                     w.SYSID == filter.SYSID).Select(s => s.WRKCT).Distinct().ToList();

                    foreach (string strWrkct in listWrkct)
                    {
                        foreach (string strCdoan in listCDoan)
                        {
                            if (filter.SelectedCongDoan != "ALL")
                            {
                                if (strCdoan != filter.SelectedCongDoan)
                                {
                                    continue;
                                }
                            }
                            var slOnline = new SanLuongOnline();
                            Int64 lv_count = 0;
                            foreach (VW_SL_ONLINE item in RawList)
                            {
                                if ((item.WRKCT != strWrkct) || (item.CDOAN != strCdoan))
                                {
                                    continue;
                                }
                                lv_count++;
                                if (slOnline.WorkCenter == null)
                                {
                                    slOnline.WorkCenter = item.WRKCT;
                                    slOnline.TenWorkCenter = item.TNWC;
                                    slOnline.CongDoan = item.CDOAN;
                                    slOnline.TenCongDoan = item.TENCD;
                                }
                                CongDon(ref slOnline, item);
                            }

                            if (lv_count == 0)
                            {
                                continue;
                            }
                            slOnline.isColor = "";
                            //tinh summary
                            Summary(ref slOnline, lv_count);

                            DateTime dtNow = DateTime.Parse(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

                            //lay so luong lao dong
                            BI_SLLDNS objSLLD = dc.BI_SLLDNS.Where(w => w.MANDT == filter.MANDT &&
                                                        w.SYSID == filter.SYSID && w.PDATUM == dtNow &&
                                                        w.CAPDO == "WRKCT" && w.BOPHAN == slOnline.WorkCenter &&
                                                        w.CDOAN == slOnline.CongDoan).FirstOrDefault();
                            if (objSLLD != null)
                            {
                                slOnline.SoLuongLD = Int64.Parse(objSLLD.SLLD.ToString());
                                if (slOnline.SoLuongLD > 0)
                                {
                                    slOnline.NangSuat = (double)slOnline.SanLuongTH / (double)slOnline.SoLuongLD;
                                }
                                else
                                {
                                    slOnline.NangSuat = 0;
                                }
                            }

                            FinalList.Add(slOnline);
                        }
                    }

                }
            }
            else //Mode: Chuyen
            {
                List<string> listZzcnt = new List<string>();
                switch(filter.SelectedCapDo)
                {
                    case "NGANH":
                        listZzcnt = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                 w.SYSID == filter.SYSID && w.NGANH == filter.SelectedGiaTriCapDo).Select(s => s.ZZCNT).Distinct().ToList();
                        break;
                    case "KHVUC":
                        listZzcnt = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                 w.SYSID == filter.SYSID && w.KHVUC == filter.SelectedGiaTriCapDo).Select(s => s.ZZCNT).Distinct().ToList();
                        break;
                    case "WRKCT":
                        listZzcnt = dc.VW_SL_ONLINE.Where(w => w.MANDT == filter.MANDT &&
                                 w.SYSID == filter.SYSID && w.WRKCT == filter.SelectedGiaTriCapDo).Select(s => s.ZZCNT).Distinct().ToList();
                        break;
                }                

                foreach (string strZzcnt in listZzcnt)
                {
                    foreach (string strCdoan in listCDoan)
                    {                        
                        var slOnline = new SanLuongOnline();
                        Int64 lv_count = 0;
                        foreach (VW_SL_ONLINE item in RawList)
                        {                            
                            if ((item.ZZCNT != strZzcnt) || (item.CDOAN != strCdoan))
                            {
                                continue;
                            }
                            slOnline.isColor = item.NCOLOR;
                            //Track change data
                             isChange = TrackChange(item);
                            if (isChange)
                            {
                                slOnline.classTHNgay = "ChangeValue";
                                var currentHour = DateTime.Now.Hour + 1;
                                switch (currentHour)
                                {
                                    case 0: slOnline.class7h = "ChangeValue"; break;
                                    case 1: slOnline.class7h = "ChangeValue"; break;
                                    case 2: slOnline.class7h = "ChangeValue"; break;
                                    case 3: slOnline.class7h = "ChangeValue"; break;
                                    case 4: slOnline.class7h = "ChangeValue"; break;
                                    case 5: slOnline.class7h = "ChangeValue"; break;
                                    case 6: slOnline.class7h = "ChangeValue"; break;
                                    case 7: slOnline.class7h = "ChangeValue"; break;
                                    case 8: slOnline.class8h = "ChangeValue"; break;
                                    case 9: slOnline.class9h = "ChangeValue"; break;
                                    case 10: slOnline.class10h = "ChangeValue"; break;
                                    case 11: slOnline.class11h = "ChangeValue"; break;
                                    case 12: slOnline.class12h = "ChangeValue"; break;
                                    case 13: slOnline.class13h = "ChangeValue"; break;
                                    case 14: slOnline.class14h = "ChangeValue"; break;
                                    case 15: slOnline.class15h = "ChangeValue"; break;
                                    case 16: slOnline.class16h = "ChangeValue"; break;
                                    case 17: slOnline.class17h = "ChangeValue"; break;
                                    case 18: slOnline.class18h = "ChangeValue"; break;
                                    case 19: slOnline.class19h = "ChangeValue"; break;
                                    case 20: slOnline.class20h = "ChangeValue"; break;
                                    case 21: slOnline.class20h = "ChangeValue"; break;
                                    case 22: slOnline.class20h = "ChangeValue"; break;
                                    case 23: slOnline.class20h = "ChangeValue"; break;
                                }
                            }
                            isChange = false;
                            lv_count++;
                            if (slOnline.Chuyen == null)
                            {
                                slOnline.Chuyen = item.CHUYN;
                                slOnline.TenChuyen = item.TNCH;
                                slOnline.CongDoan = item.CDOAN;
                                slOnline.TenCongDoan = item.TENCD;
                            }
                            CongDon(ref slOnline, item);
                            slOnline.SoLuongLD += Int64.Parse(item.SLLD.ToString());
                        }

                        if (lv_count == 0)
                        {
                            continue;
                        }

                        //tinh summary
                        Summary(ref slOnline, lv_count);
                        FinalList.Add(slOnline);
                    }
                }
            }

            return FinalList;
        }

        public void getModeView(ref FilterCoditionModel filter)
        {
            List<SelectListItem> ItemsMode = new List<SelectListItem>();
            ItemsMode.Add(new SelectListItem() { Text = "CHUYỀN", Value = "CHUYN", Selected = true });
            ItemsMode.Add(new SelectListItem() { Text = "WORK CENTER", Value = "WRKCT", Selected = false });
            ItemsMode.Add(new SelectListItem() { Text = "KHU VỰC", Value = "KHVUC", Selected = false });
            ItemsMode.Add(new SelectListItem() { Text = "NGÀNH", Value = "NGANH", Selected = false });

            filter.ListModeView = ItemsMode;

        }

        public void GetCongDoanAll(ref FilterCoditionModel filter)
        {
            string strFirstCD = string.Empty;
            FilterCoditionModel lv_filter = filter;

            //Get list CongDoan
            List<string> listCongDoan = new List<string>();
            List<SelectListItem> ItemsCongDoan = new List<SelectListItem>();

            ItemsCongDoan.Add(new SelectListItem() { Text = "TẤT CẢ", Value = "ALL", Selected = false });

            listCongDoan = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                                    w.SYSID == lv_filter.SYSID).Select(s => s.CDOAN).Distinct().ToList();
            foreach (string strCD in listCongDoan)
            {
                if (strCD == "")
                {
                    continue;
                }

                BI_ZQLSX obj = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                            w.SYSID == lv_filter.SYSID && w.CDOAN == strCD).FirstOrDefault();
                if (obj == null)
                {
                    continue;
                }

                if (obj.TENCD.Trim() == "")
                {
                    ItemsCongDoan.Add(new SelectListItem() { Text = obj.CDOAN, Value = obj.CDOAN, Selected = false });
                }
                else
                {
                    ItemsCongDoan.Add(new SelectListItem() { Text = obj.TENCD, Value = obj.CDOAN, Selected = false });
                }
            }
            filter.ListCongDoan = ItemsCongDoan;
            if (filter.SelectedCongDoan == null)
            {
                filter.SelectedCongDoan = "ALL";
            }

        }

        public void GetCongDoanDauRa(ref FilterCoditionModel filter)
        {
            string strFirstCD = string.Empty;
            FilterCoditionModel lv_filter = filter;

            //Get list CongDoan
            List<string> listCongDoan = new List<string>();
            List<SelectListItem> ItemsCongDoan = new List<SelectListItem>();

            if (filter.SelectedCongDoan == null)
            {
                filter.SelectedCongDoan = "ALL";
            }
            ItemsCongDoan.Add(new SelectListItem() { Text = "TẤT CẢ", Value = "ALL", Selected = false });

            switch (filter.SelectedCapDo)
            {
                case "NGANH":
                    listCongDoan = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                            w.SYSID == lv_filter.SYSID &&
                                            w.NGANH == lv_filter.SelectedGiaTriCapDo &&
                                            w.CDOAN == w.DAURA_KV).Select(s => s.CDOAN).Distinct().ToList();
                    foreach (string strCD in listCongDoan)
                    {
                        if (strCD == "")
                        {
                            continue;
                        }
                        bool slect = false;

                        BI_ZQLSX obj = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                                    w.SYSID == lv_filter.SYSID &&
                                                    w.NGANH == lv_filter.SelectedGiaTriCapDo && w.CDOAN == strCD).FirstOrDefault();
                        if (obj == null)
                        {
                            continue;
                        }
                        ItemsCongDoan.Add(new SelectListItem() { Text = obj.CDOAN, Value = obj.CDOAN, Selected = slect });
                    }
                    break;

                case "KHVUC":
                    listCongDoan = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                            w.SYSID == lv_filter.SYSID &&
                                            w.KHVUC == lv_filter.SelectedGiaTriCapDo &&
                                            (w.CDOAN == w.DAURA_KV) || (w.CDOAN == w.DAURA_WC)).Select(s => s.CDOAN).Distinct().ToList();
                    foreach (string strCD in listCongDoan)
                    {
                        if (strCD == "")
                        {
                            continue;
                        }
                        bool slect = false;

                        BI_ZQLSX obj = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                                    w.SYSID == lv_filter.SYSID &&
                                                    w.KHVUC == lv_filter.SelectedGiaTriCapDo && w.CDOAN == strCD).FirstOrDefault();
                        if (obj == null)
                        {
                            continue;
                        }
                        ItemsCongDoan.Add(new SelectListItem() { Text = obj.CDOAN, Value = obj.CDOAN, Selected = slect });

                    }
                    break;

                case "WRKCT":
                    listCongDoan = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                            w.SYSID == lv_filter.SYSID &&
                                            w.WRKCT == lv_filter.SelectedGiaTriCapDo &&
                                            w.CDOAN == w.DAURA_WC).Select(s => s.CDOAN).Distinct().ToList();
                    foreach (string strCD in listCongDoan)
                    {
                        if (strCD == "")
                        {
                            continue;
                        }
                        bool slect = false;

                        BI_ZQLSX obj = dc.BI_ZQLSX.Where(w => w.MANDT == lv_filter.MANDT &&
                                                    w.SYSID == lv_filter.SYSID &&
                                                    w.WRKCT == lv_filter.SelectedGiaTriCapDo && w.CDOAN == strCD).FirstOrDefault();
                        if (obj == null)
                        {
                            continue;
                        }
                        ItemsCongDoan.Add(new SelectListItem() { Text = obj.CDOAN, Value = obj.CDOAN, Selected = slect });
                    }
                    break;
            }
            filter.ListCongDoan = ItemsCongDoan;

            if (filter.DateTo >= filter.DateFrom)
            {
                if (filter.listDate == null)
                {
                    filter.listDate = new List<DateTime>();
                }
                for (var dt = filter.DateFrom; dt <= filter.DateTo; dt = dt.AddDays(1))
                {
                    filter.listDate.Add(DateTime.Parse(dt.ToShortDateString()));
                }
            }
        }

        public string GetPhanQuyen(ref FilterCoditionModel filter, string strUsername)
        {
            string strResult = "OK";
            FilterCoditionModel lv_filter = filter;
            //lay cap do dau tien
            string FirstCapDoID = string.Empty; ;
            string FisrtCapDoName = string.Empty;

            string FirstGiaTriCapDoID = string.Empty;
            try
            {

                if (filter.SelectedCapDo == null)
                {
                    FirstCapDoID = dc.BI_PHAN_QUYEN.Where(x => x.Username == strUsername && x.MANDT == lv_filter.MANDT
                                                && x.SYSID == lv_filter.SYSID).Select(c => c.CapDo).Distinct().FirstOrDefault().ToString();

                    FisrtCapDoName = dc.BI_PHAN_QUYEN.Where(x => x.Username == strUsername && x.CapDo == FirstCapDoID
                                                && x.MANDT == lv_filter.MANDT && x.SYSID == lv_filter.SYSID).Select(c => c.DGCapDo).FirstOrDefault().ToString();
                }
                else
                {
                    FirstCapDoID = lv_filter.SelectedCapDo;
                }

                filter.SelectedCapDo = FirstCapDoID;


                List<string> listCapDo = dc.BI_PHAN_QUYEN.Where(x => x.Username == strUsername
                                            && x.MANDT == lv_filter.MANDT && x.SYSID == lv_filter.SYSID).
                                            Select(c => c.CapDo).Distinct().ToList();

                List<SelectListItem> itemsCD = new List<SelectListItem>();

                foreach (string strCapDo in listCapDo)
                {
                    string strGTCD = dc.BI_PHAN_QUYEN.Where(x => x.Username == strUsername &&
                                            x.CapDo == strCapDo).Select(c => c.DGCapDo).FirstOrDefault().ToString();
                    if (strCapDo == FirstCapDoID)
                    {
                        itemsCD.Add(new SelectListItem() { Text = strGTCD, Value = strCapDo, Selected = true });
                    }
                    else
                    {
                        itemsCD.Add(new SelectListItem() { Text = strGTCD, Value = strCapDo, Selected = false });
                    }
                }

                filter.ListCapDo = itemsCD;

                if (filter.SelectedGiaTriCapDo == null)
                {
                    FirstGiaTriCapDoID = dc.BI_PHAN_QUYEN.Where(x => x.Username == strUsername && x.CapDo == FirstCapDoID)
                                                .Select(c => c.GiaTri).Distinct().FirstOrDefault().ToString();
                }
                else
                {
                    FirstGiaTriCapDoID = filter.SelectedGiaTriCapDo;
                }


                //lay danh sach gia tri cap do dau tien
                List<BI_PHAN_QUYEN> listPQ = dc.BI_PHAN_QUYEN.Where(p => p.CapDo == FirstCapDoID &&
                                                p.Username == strUsername).ToList();

                List<SelectListItem> itemsGTCD = new List<SelectListItem>();

                foreach (BI_PHAN_QUYEN item in listPQ)
                {
                    if (item.GiaTri == FirstGiaTriCapDoID)
                    {
                        itemsGTCD.Add(new SelectListItem() { Text = item.DGGiaTri, Value = item.GiaTri, Selected = true });
                    }
                    else
                    {
                        itemsGTCD.Add(new SelectListItem() { Text = item.DGGiaTri, Value = item.GiaTri, Selected = false });
                    }
                }


                filter.ListGiaTriCapDo = itemsGTCD;

                //Check date time
                DateTime NullDate = DateTime.Parse("01-01-0001 00:00:00");
                DateTime CurrentDate = DateTime.Now;

                //Lan dau chua nhap, ngay bat dau bang ngay hien tai - 7
                if (filter.DateTo == NullDate)
                {
                    filter.DateFrom = CurrentDate.AddDays(-7);
                }

                // ngay ket thuc la ngay hien tai
                if (filter.DateTo == NullDate)
                {
                    filter.DateTo = CurrentDate;
                }

                if (filter.SelectedGiaTriCapDo == null)
                {
                    filter.SelectedGiaTriCapDo = FirstGiaTriCapDoID;
                }
            }
            catch
            {
                strResult = "Chưa được phân quyền";
                return strResult;
            }

            return strResult;
        }


        /*
            Dem trang thai tung chuyen san xuat
        */
        private List<TrangThaiChuyen> CountStatus(List<BI_SLSX_CHUYEN_NGAY> ListData,
                                                    IQueryable<DateTime> listDate,
                                                    FilterCoditionModel filter)
        {
            var ListStatus = new List<TrangThaiChuyen>();
            var listKehoach = new List<BI_SLKH_CH>();

            DateTime dtFrom = new DateTime(filter.DateFrom.Year, filter.DateFrom.Month, 1);
            DateTime dtTo = new DateTime(filter.DateTo.Year, filter.DateTo.Month, 1);


            switch (filter.SelectedCapDo)
            {
                case "NGANH":
                    listKehoach = dc.BI_SLKH_CH.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                      (w.FIRSTDAY >= dtFrom && w.FIRSTDAY <= dtTo) &&
                                                        w.NGANH == filter.SelectedGiaTriCapDo).ToList();
                    break;

                case "KHVUC":
                    listKehoach = dc.BI_SLKH_CH.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                      (w.FIRSTDAY >= dtFrom && w.FIRSTDAY <= dtTo) &&
                                                        w.KHVUC == filter.SelectedGiaTriCapDo).ToList();
                    break;
                case "WRKCT":
                    listKehoach = dc.BI_SLKH_CH.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                      (w.FIRSTDAY >= dtFrom && w.FIRSTDAY <= dtTo) &&
                                                        w.WRKCT == filter.SelectedGiaTriCapDo).ToList();
                    break;
            }


            foreach (DateTime date in listDate)
            {

                DateTime firstDay = new DateTime(date.Year, date.Month, 1);

                TrangThaiChuyen itemStatus = new TrangThaiChuyen();
                itemStatus.Ngay = date;
                foreach (BI_SLSX_CHUYEN_NGAY sln in ListData)
                {
                    if (sln.PDATUM != date)
                    {
                        continue;
                    }
                    foreach (BI_SLKH_CH slKhCh in listKehoach)
                    {
                        if ((firstDay != slKhCh.FIRSTDAY) || (sln.CHUYN != slKhCh.CHUYN))
                        {
                            continue;
                        }

                        long iSlKeHoach = 0;
                        switch (date.Day)
                        {
                            case 1:
                                iSlKeHoach = (long)slKhCh.NGAY01;
                                break;
                            case 2:
                                iSlKeHoach = (long)slKhCh.NGAY02;
                                break;
                            case 3:
                                iSlKeHoach = (long)slKhCh.NGAY03;
                                break;
                            case 4:
                                iSlKeHoach = (long)slKhCh.NGAY04;
                                break;
                            case 5:
                                iSlKeHoach = (long)slKhCh.NGAY05;
                                break;
                            case 6:
                                iSlKeHoach = (long)slKhCh.NGAY06;
                                break;
                            case 7:
                                iSlKeHoach = (long)slKhCh.NGAY07;
                                break;
                            case 8:
                                iSlKeHoach = (long)slKhCh.NGAY08;
                                break;
                            case 9:
                                iSlKeHoach = (long)slKhCh.NGAY09;
                                break;
                            case 10:
                                iSlKeHoach = (long)slKhCh.NGAY10;
                                break;
                            case 11:
                                iSlKeHoach = (long)slKhCh.NGAY11;
                                break;
                            case 12:
                                iSlKeHoach = (long)slKhCh.NGAY12;
                                break;
                            case 13:
                                iSlKeHoach = (long)slKhCh.NGAY13;
                                break;
                            case 14:
                                iSlKeHoach = (long)slKhCh.NGAY14;
                                break;
                            case 15:
                                iSlKeHoach = (long)slKhCh.NGAY15;
                                break;
                            case 16:
                                iSlKeHoach = (long)slKhCh.NGAY16;
                                break;
                            case 17:
                                iSlKeHoach = (long)slKhCh.NGAY17;
                                break;
                            case 18:
                                iSlKeHoach = (long)slKhCh.NGAY18;
                                break;
                            case 19:
                                iSlKeHoach = (long)slKhCh.NGAY19;
                                break;
                            case 20:
                                iSlKeHoach = (long)slKhCh.NGAY20;
                                break;
                            case 21:
                                iSlKeHoach = (long)slKhCh.NGAY21;
                                break;
                            case 22:
                                iSlKeHoach = (long)slKhCh.NGAY22;
                                break;
                            case 23:
                                iSlKeHoach = (long)slKhCh.NGAY23;
                                break;
                            case 24:
                                iSlKeHoach = (long)slKhCh.NGAY24;
                                break;
                            case 25:
                                iSlKeHoach = (long)slKhCh.NGAY25;
                                break;
                            case 26:
                                iSlKeHoach = (long)slKhCh.NGAY26;
                                break;
                            case 27:
                                iSlKeHoach = (long)slKhCh.NGAY27;
                                break;
                            case 28:
                                iSlKeHoach = (long)slKhCh.NGAY28;
                                break;
                            case 29:
                                iSlKeHoach = (long)slKhCh.NGAY29;
                                break;
                            case 30:
                                iSlKeHoach = (long)slKhCh.NGAY30;
                                break;
                            case 31:
                                iSlKeHoach = (long)slKhCh.NGAY31;
                                break;
                        }

                        if (date != DateTime.Today)
                        {
                            if (iSlKeHoach > 0)
                            {
                                double PhanTram = (double)sln.LK_NGAY / (double)iSlKeHoach * 100;

                                if (PhanTram < 95)
                                {
                                    itemStatus.redStatus++;
                                }
                                else if ((PhanTram >= 95) && (PhanTram < 100))
                                {
                                    itemStatus.yellowStatus++;
                                }
                                else
                                {
                                    itemStatus.greenStatus++;
                                }
                            }
                            else
                            {
                                itemStatus.otherStatus++;
                            }
                        }
                        break;
                    }
                }
                ListStatus.Add(itemStatus);
            }
            return ListStatus;
        }

        public List<ThongKeLaoDong> GetThongKeLaoDong(FilterCoditionModel filter)
        {
            List<ThongKeLaoDong> FinalList = new List<ThongKeLaoDong>();
            List<VW_TKLD> listThongKe = new List<VW_TKLD>();
            List<DateTime> listDate = new List<DateTime>();

            listDate = dc.VW_TKLD.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                            w.PDATUM >= filter.DateFrom && w.PDATUM <= filter.DateTo).Select(s => s.PDATUM).Distinct().ToList();

            BI_ZQLSX objQlsx = new BI_ZQLSX();
            switch (filter.SelectedCapDo)
            {
                case "NGANH":
                    //Lay cong doan dau ra
                    objQlsx = dc.BI_ZQLSX.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                        w.NGANH == filter.SelectedGiaTriCapDo &&
                                                        w.DAURA_KV != "").FirstOrDefault();
                    if (objQlsx != null)
                    {
                        listThongKe = dc.VW_TKLD.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                w.PDATUM >= filter.DateFrom && w.PDATUM <= filter.DateTo &&
                                w.CAPDO == filter.SelectedCapDo && w.BOPHAN == filter.SelectedGiaTriCapDo &&
                                w.CDOAN == objQlsx.DAURA_KV).ToList();
                    }
                    break;
                case "KHVUC":
                    objQlsx = dc.BI_ZQLSX.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                        w.KHVUC == filter.SelectedGiaTriCapDo &&
                                                        w.DAURA_KV != "").FirstOrDefault();
                    if (objQlsx != null)
                    {
                        listThongKe = dc.VW_TKLD.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                            w.PDATUM >= filter.DateFrom && w.PDATUM <= filter.DateTo &&
                            w.CAPDO == filter.SelectedCapDo && w.BOPHAN == filter.SelectedGiaTriCapDo &&
                            w.CDOAN == objQlsx.DAURA_KV).ToList();
                    }
                    break;

                case "WRKCT":
                    objQlsx = dc.BI_ZQLSX.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                                                        w.WRKCT == filter.SelectedGiaTriCapDo &&
                                                        w.DAURA_WC != "").FirstOrDefault();
                    if (objQlsx != null)
                    {
                        listThongKe = dc.VW_TKLD.Where(w => w.MANDT == filter.MANDT && w.SYSID == filter.SYSID &&
                            w.PDATUM >= filter.DateFrom && w.PDATUM <= filter.DateTo &&
                            w.CAPDO == filter.SelectedCapDo && w.BOPHAN == filter.SelectedGiaTriCapDo &&
                            w.CDOAN == objQlsx.DAURA_WC).ToList();
                    }
                    break;
            }
            foreach (DateTime date in listDate)
            {
                foreach (VW_TKLD item in listThongKe)
                {
                    if (item.PDATUM != date) continue;

                    ThongKeLaoDong tkItem = new ThongKeLaoDong();
                    tkItem.CapDo = filter.SelectedCapDo;
                    tkItem.GiaTriCapDo = filter.SelectedGiaTriCapDo;
                    tkItem.Ngay = date;
                    tkItem.SoLuongDiLam = (long)item.SLLD;
                    tkItem.SoLuongNghi = (long)item.TONGLD - (long)item.SLLD;
                    tkItem.TongSoLuong = (long)item.TONGLD;
                    FinalList.Add(tkItem);
                }
            }

            return FinalList;
        }


        public List<GiaThanhPhanXuong> GetGiaThanhPhanXuong(FilterCoditionModel filter)
        {
            var finalList = new List<GiaThanhPhanXuong>();

            var listRawData = new List<BI_CPTH>();
            switch (filter.SelectedCapDo)
            {
                case "NGANH":
                    listRawData = dc.BI_CPTH.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                                    && x.ZNGANH == filter.SelectedGiaTriCapDo
                                                    && x.ZDATE >= filter.DateFrom && x.ZDATE <= filter.DateTo).ToList();
                    break;

                case "KHVUC":
                    listRawData = dc.BI_CPTH.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                                    && x.ZKHVUC == filter.SelectedGiaTriCapDo
                                                    && x.ZDATE >= filter.DateFrom && x.ZDATE <= filter.DateTo).ToList();
                    break;

                case "WRKCT":
                    listRawData = dc.BI_CPTH.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                                    && x.ZWRKCT == filter.SelectedGiaTriCapDo
                                                    && x.ZDATE >= filter.DateFrom && x.ZDATE <= filter.DateTo).ToList();
                    break;
            }

            if (filter.SelectedCongDoan == "ALL")
            {
                foreach (SelectListItem cdoan in filter.ListCongDoan)
                {
                    if (cdoan.Value == "ALL") continue;
                    foreach (DateTime dt in filter.listDate)
                    {
                        GiaThanhPhanXuong gtpx = new GiaThanhPhanXuong();
                        gtpx.Ngay = dt;
                        foreach (BI_CPTH cpth in listRawData)
                        {
                            if ((cpth.ZDATE != dt) || (cpth.ZCDOAN != cdoan.Value)) continue;

                            gtpx.CongDoan = cpth.ZCDOAN;

                            //Ke hoach
                            gtpx.gtNhanCongKeHoach += (double)cpth.ZNCKH;
                            gtpx.gtVatTuKeHoach += (double)cpth.ZVTKH;
                            gtpx.gtTaiSanKeHoach += (double)cpth.ZTSKH;

                            //thuchien
                            gtpx.gtNhanCongThucHien += (double)cpth.ZNCTH;
                            gtpx.gtVatTuThucHien += (double)cpth.ZVTTH;
                            gtpx.gtTaiSanThucHien += (double)cpth.ZTSTH;
                        }
                        if (gtpx.CongDoan == null) continue;

                        double dTongKH = gtpx.gtNhanCongKeHoach + gtpx.gtVatTuKeHoach + gtpx.gtTaiSanKeHoach;
                        double dTongTH = gtpx.gtNhanCongThucHien + gtpx.gtVatTuThucHien + gtpx.gtTaiSanThucHien;

                        if (dTongKH != 0)
                        {
                            //Ke hoach
                            gtpx.ptVatTuKeHoach = Math.Round(gtpx.gtVatTuKeHoach / dTongKH * 100, 2);
                            gtpx.ptTaiSanKeHoach = Math.Round(gtpx.gtTaiSanKeHoach / dTongKH * 100, 2);
                            gtpx.ptNhanCongKeHoach = Math.Round(gtpx.gtNhanCongKeHoach / dTongKH * 100, 2);

                        }

                        if (dTongTH != 0)
                        {
                            //thuchien
                            gtpx.ptVatTuThucHien = Math.Round(gtpx.gtVatTuThucHien / dTongTH * 100, 2);
                            gtpx.ptTaiSanThucHien = Math.Round(gtpx.gtTaiSanThucHien / dTongTH * 100, 2);
                            gtpx.ptNhanCongThucHien = Math.Round(gtpx.gtNhanCongThucHien / dTongTH * 100, 2);
                        }

                        finalList.Add(gtpx);
                    }
                }
            }
            else  // da chon cong doan
            {
                foreach (DateTime dt in filter.listDate)
                {
                    GiaThanhPhanXuong gtpx = new GiaThanhPhanXuong();
                    gtpx.Ngay = dt;
                    foreach (BI_CPTH cpth in listRawData)
                    {
                        if ((cpth.ZDATE != dt) || (cpth.ZCDOAN != filter.SelectedCongDoan)) continue;

                        gtpx.CongDoan = cpth.ZCDOAN;

                        //Ke hoach
                        gtpx.gtNhanCongKeHoach += (double)cpth.ZNCKH;
                        gtpx.gtVatTuKeHoach += (double)cpth.ZVTKH;
                        gtpx.gtTaiSanKeHoach += (double)cpth.ZTSKH;

                        //thuchien
                        gtpx.gtNhanCongKeHoach += (double)cpth.ZNCKH;
                        gtpx.gtVatTuThucHien += (double)cpth.ZVTTH;
                        gtpx.gtTaiSanThucHien += (double)cpth.ZTSTH;
                    }
                    if (gtpx.CongDoan == null) continue;
                    double dTongKH = gtpx.gtNhanCongKeHoach + gtpx.gtVatTuKeHoach + gtpx.gtTaiSanKeHoach;
                    double dTongTH = gtpx.gtNhanCongThucHien + gtpx.gtVatTuThucHien + gtpx.gtTaiSanThucHien;
                    //Ke hoach
                    gtpx.ptNhanCongKeHoach = Math.Round(gtpx.gtNhanCongKeHoach / dTongKH * 100, 2);
                    gtpx.ptVatTuKeHoach = Math.Round(gtpx.gtVatTuKeHoach / dTongKH * 100, 2);
                    gtpx.ptTaiSanKeHoach = Math.Round(gtpx.gtTaiSanKeHoach / dTongKH * 100, 2);

                    //thuchien
                    gtpx.ptNhanCongThucHien = Math.Round(gtpx.gtNhanCongThucHien / dTongTH * 100, 2);
                    gtpx.ptVatTuThucHien = Math.Round(gtpx.gtVatTuThucHien / dTongTH * 100, 2);
                    gtpx.ptTaiSanThucHien = Math.Round(gtpx.gtTaiSanThucHien / dTongTH * 100, 2);

                    finalList.Add(gtpx);
                }

            }
            return finalList;
        }

        public List<NangSuatLaoDong> GetNangSuatSanLuong(FilterCoditionModel filter,
                                                        ref ArrayList ChartNangSuat)
        {
            var finalList = new List<NangSuatLaoDong>();
            List<BI_SLLDNS> ListData = new List<BI_SLLDNS>();

            IQueryable<DateTime> listDate = dc.BI_SLLDNS.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                                    && x.CAPDO == filter.SelectedCapDo
                                                    && x.BOPHAN == filter.SelectedGiaTriCapDo
                                                    && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo).Select(dt => dt.PDATUM).Distinct();
            IQueryable<string> ListCongDoan = null;

            //Lay danh sach ngay
            if (filter.SelectedCongDoan == "ALL")
            {
                switch (filter.SelectedCapDo)
                {
                    case "NGANH":
                        //Lay tat ca cong doan dau ra cua KV ~ NGANH
                        ListCongDoan = dc.BI_ZQLSX.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.NGANH == filter.SelectedGiaTriCapDo
                                            && x.DAURA_KV != "").Select(dt => dt.DAURA_KV).Distinct();
                        break;
                    case "KHVUC":
                        ListCongDoan = dc.BI_ZQLSX.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.KHVUC == filter.SelectedGiaTriCapDo
                                            && x.DAURA_WC != "").Select(dt => dt.DAURA_WC).Distinct();
                        break;

                    case "WRKCT":
                        ListCongDoan = dc.BI_ZQLSX.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.WRKCT == filter.SelectedGiaTriCapDo
                                            && x.DAURA_WC != "").Select(dt => dt.DAURA_WC).Distinct();
                        break;
                }
                //Get data raw
                ListData = dc.BI_SLLDNS.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.CAPDO == filter.SelectedCapDo
                                            && x.BOPHAN == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo).ToList();
            }
            else
            {
                //Lay danh sach cong doan theo dieu kien
                ListCongDoan = dc.BI_SLLDNS.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                    && x.CAPDO == filter.SelectedCapDo
                                    && x.BOPHAN == filter.SelectedGiaTriCapDo
                                    && (x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo)
                                    && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.CDOAN).Distinct();
                //Get data raw
                ListData = dc.BI_SLLDNS.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.CAPDO == filter.SelectedCapDo
                                            && x.BOPHAN == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == filter.SelectedCongDoan).ToList();
            }
            //-->Add header for data chart
            ArrayList headerChart = new ArrayList();
            headerChart.Add((object)string.Format("{0}", "Ngay"));
            foreach (string strCD in ListCongDoan)
            {
                headerChart.Add((object)string.Format("{0}", strCD));
            }
            ChartNangSuat.Add(headerChart);
            //<--Add header for data chart

            foreach (DateTime dt in listDate)
            {
                ArrayList dataChart = new ArrayList();
                dataChart.Add(dt.ToShortDateString());
                foreach (string cd in ListCongDoan)
                {
                    NangSuatLaoDong nsld = new NangSuatLaoDong()
                    {
                        Ngay = dt,
                        CapDo = filter.SelectedCapDo,
                        GiaTriCapDo = filter.SelectedGiaTriCapDo,
                        CongDoan = cd
                    };
                    foreach (BI_SLLDNS slldns in ListData)
                    {
                        if ((nsld.Ngay != slldns.PDATUM) || (nsld.CongDoan != slldns.CDOAN))
                        {
                            continue;
                        }
                        nsld.NangSuat = Math.Round((double)slldns.NANGSUAT, 2);
                        nsld.SoLuongLaoDong = (double)slldns.SLLD;
                        break;
                    }
                    finalList.Add(nsld);
                    dataChart.Add(nsld.NangSuat);
                }
                ChartNangSuat.Add(dataChart);
            }
            finalList.OrderBy(o => o.CongDoan).ThenBy(o => o.Ngay);
            return finalList;
        }
        public List<SanLuongNgay> GetSanLuongNgay(FilterCoditionModel filter,
                                                    ref ArrayList ChartSL,
                                                    ref List<TrangThaiChuyen> ListTrangThai)
        {
            var FinalList = new List<SanLuongNgay>();
            List<BI_SLSX_CHUYEN_NGAY> ListData = new List<BI_SLSX_CHUYEN_NGAY>();

            IQueryable<DateTime> listDate = null;
            IQueryable<string> ListCongDoan;


            switch (filter.SelectedCapDo)
            {
                case "NGANH":

                    if (filter.SelectedCongDoan == "ALL")
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.NGANH == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == x.DAURA_KV).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.NGANH == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == x.DAURA_KV).Select(dt => dt.CDOAN).Distinct();
                    }
                    else
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.NGANH == filter.SelectedGiaTriCapDo
                                            && (x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo)
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.NGANH == filter.SelectedGiaTriCapDo
                                            && (x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo)
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.CDOAN).Distinct();
                    }
                    //Add header for data chart
                    ArrayList headerNganh = new ArrayList();
                    headerNganh.Add((object)string.Format("{0}", "Ngay"));
                    foreach (string strCD in ListCongDoan)
                    {
                        headerNganh.Add((object)string.Format("KH-{0}", strCD));
                        headerNganh.Add((object)string.Format("TH-{0}", strCD));
                    }
                    ChartSL.Add(headerNganh);

                    //Get data raw
                    ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                        && x.NGANH == filter.SelectedGiaTriCapDo
                                        && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                        && x.CDOAN == x.DAURA_KV).ToList();

                    foreach (DateTime dt in listDate)
                    {
                        ArrayList dataChart = new ArrayList();
                        dataChart.Add(dt.ToShortDateString());
                        foreach (string cd in ListCongDoan)
                        {

                            SanLuongNgay sln = new SanLuongNgay()
                            {
                                GiaTriCapDo = filter.SelectedGiaTriCapDo,
                                CapDo = filter.SelectedGiaTriCapDo,
                                CongDoan = cd,
                                Ngay = dt
                            };
                            foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                            {
                                if ((sln.Ngay != bi_sln.PDATUM) || (sln.CongDoan != bi_sln.CDOAN) || (sln.CapDo != bi_sln.NGANH))
                                {
                                    continue;
                                }
                                TinhLuyKe(ref sln, bi_sln); //Tinh Luy Ke
                                sln.cntcd = bi_sln.CNTCD;
                            }
                            GetKeHoachNganh(ref sln, filter.MANDT, filter.SYSID, filter.SelectedGiaTriCapDo);
                            FinalList.Add(sln);
                            dataChart.Add(sln.KeHoach);
                            dataChart.Add(sln.ThucHien);
                        }
                        ChartSL.Add(dataChart);
                    }
                    break;
                case "KHVUC":
                    if (filter.SelectedCongDoan == "ALL")
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                        && x.KHVUC == filter.SelectedGiaTriCapDo
                                        && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                        && (x.CDOAN == x.DAURA_KV || x.CDOAN == x.DAURA_WC)).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.KHVUC == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && (x.CDOAN == x.DAURA_KV || x.CDOAN == x.DAURA_WC)).Select(dt => dt.CDOAN).Distinct();
                    }
                    else
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.KHVUC == filter.SelectedGiaTriCapDo
                                            && (x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo)
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.KHVUC == filter.SelectedGiaTriCapDo
                                            && (x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo)
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.CDOAN).Distinct();
                    }

                    //Add header for data chart
                    ArrayList ChartHeaderKV = new ArrayList();
                    ChartHeaderKV.Add((object)string.Format("{0}", "Ngay"));
                    foreach (string strCD in ListCongDoan)
                    {
                        ChartHeaderKV.Add((object)string.Format("KH-{0}", strCD));
                        ChartHeaderKV.Add((object)string.Format("TH-{0}", strCD));
                    }
                    ChartSL.Add(ChartHeaderKV);

                    //Get data raw (khu vuc)
                    ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                        && x.KHVUC == filter.SelectedGiaTriCapDo
                                        && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                        && (x.CDOAN == x.DAURA_KV || x.CDOAN == x.DAURA_WC)).ToList();

                    foreach (DateTime dt in listDate)
                    {
                        ArrayList dataChart = new ArrayList();
                        dataChart.Add(dt.ToShortDateString());
                        foreach (string cd in ListCongDoan)
                        {
                            SanLuongNgay sln = new SanLuongNgay();
                            sln.GiaTriCapDo = filter.SelectedGiaTriCapDo;

                            sln.CapDo = filter.SelectedGiaTriCapDo;
                            sln.CongDoan = cd;
                            sln.Ngay = dt;
                            foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                            {
                                if ((sln.Ngay != bi_sln.PDATUM) || (sln.CongDoan != bi_sln.CDOAN) || (sln.CapDo != bi_sln.KHVUC))
                                {
                                    continue;
                                }
                                TinhLuyKe(ref sln, bi_sln);
                                sln.cntcd = bi_sln.CNTCD;
                            }
                            GetKeHoachKV(ref sln, filter.MANDT, filter.SYSID, filter.SelectedGiaTriCapDo);
                            //add value to table data
                            FinalList.Add((SanLuongNgay)sln);

                            //add value to data ChartSL
                            dataChart.Add(sln.KeHoach);
                            dataChart.Add(sln.ThucHien);
                        }
                        ChartSL.Add(dataChart);
                    }

                    break;
                case "WRKCT":
                    if (filter.SelectedCongDoan == "ALL")
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                        && x.WRKCT == filter.SelectedGiaTriCapDo
                                        && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                        && x.CDOAN == x.DAURA_WC).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.WRKCT == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == x.DAURA_WC).Select(dt => dt.CDOAN).Distinct();
                    }
                    else
                    {
                        //Lay danh sach ngay
                        listDate = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.WRKCT == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.PDATUM).Distinct();

                        //Lay danh sach cong doan
                        ListCongDoan = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                            && x.WRKCT == filter.SelectedGiaTriCapDo
                                            && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                            && x.CDOAN == filter.SelectedCongDoan).Select(dt => dt.CDOAN).Distinct();
                    }

                    //Add header for data chart
                    ArrayList ChartHeaderWC = new ArrayList();
                    ChartHeaderWC.Add((object)string.Format("{0}", "Ngay"));
                    foreach (string strCD in ListCongDoan)
                    {
                        ChartHeaderWC.Add((object)string.Format("KH-{0}", strCD));
                        ChartHeaderWC.Add((object)string.Format("TH-{0}", strCD));
                    }
                    ChartSL.Add(ChartHeaderWC);

                    //Get data raw (khu vuc)
                    ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == filter.MANDT && x.SYSID == filter.SYSID
                                        && x.WRKCT == filter.SelectedGiaTriCapDo
                                        && x.PDATUM >= filter.DateFrom && x.PDATUM <= filter.DateTo
                                        && x.CDOAN == x.DAURA_WC).ToList();

                    foreach (DateTime dt in listDate)
                    {
                        ArrayList dataChart = new ArrayList();
                        dataChart.Add(dt.ToShortDateString());
                        foreach (string cd in ListCongDoan)
                        {
                            SanLuongNgay sln = new SanLuongNgay();
                            sln.GiaTriCapDo = filter.SelectedGiaTriCapDo;

                            sln.CapDo = filter.SelectedGiaTriCapDo;
                            sln.CongDoan = cd;
                            sln.Ngay = dt;
                            foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                            {
                                if ((sln.Ngay != bi_sln.PDATUM) || (sln.CongDoan != bi_sln.CDOAN) || (sln.CapDo != bi_sln.WRKCT))
                                {
                                    continue;
                                }
                                TinhLuyKe(ref sln, bi_sln);
                                sln.cntcd = bi_sln.CNTCD;
                            }
                            GetKeHoachWrkct(ref sln, filter.MANDT, filter.SYSID, filter.SelectedGiaTriCapDo);
                            FinalList.Add(sln);
                            dataChart.Add(sln.KeHoach);
                            dataChart.Add(sln.ThucHien);
                        }
                        ChartSL.Add(dataChart);
                    }
                    break;
            }
            if (listDate != null)
            {
                //tinh toan trang thai chuyen
                ListTrangThai = CountStatus(ListData, listDate, filter);
            }

            var sortedFinalList = FinalList.OrderBy(x => x.CongDoan).ThenBy(x => x.Ngay).ToList();
            return sortedFinalList;
        }

        public List<SanLuongNgay> GetDetailWrkct(string mandt, string sysid,
                                                  string Wrkct, DateTime ngay,
                                                  string congdoan)
        {
            var FinalList = new List<SanLuongNgay>();

            IQueryable<string> listChuyen;

            List<BI_SLSX_CHUYEN_NGAY> ListData;


            listChuyen = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.WRKCT == Wrkct && x.PDATUM == ngay && x.CDOAN == congdoan).Select(w => w.CHUYN).Distinct();

            //Get data raw (khu vuc)
            ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.WRKCT == Wrkct && x.PDATUM == ngay && x.CDOAN == congdoan).ToList();
            foreach (string strCH in listChuyen)
            {
                SanLuongNgay sln = new SanLuongNgay();
                sln.CapDo = "CHUYN";
                sln.GiaTriCapDo = strCH;
                sln.CongDoan = congdoan;
                sln.Ngay = ngay;
                foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                {
                    if (bi_sln.CHUYN != strCH)
                    {
                        continue;
                    }
                    TinhLuyKe(ref sln, bi_sln);
                    sln.cntcd = bi_sln.CNTCD;
                }
                GetKeHoachChuyen(ref sln, mandt, sysid, sln.GiaTriCapDo);
                FinalList.Add((SanLuongNgay)sln);
            }
            return FinalList;
        }

        public List<SanLuongNgay> GetDetailKhuVuc(string mandt, string sysid,
                                                  string khvuc, DateTime ngay,
                                                  string congdoan)
        {
            var FinalList = new List<SanLuongNgay>();

            IQueryable<string> listWRKCT;

            List<BI_SLSX_CHUYEN_NGAY> ListData;


            listWRKCT = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.KHVUC == khvuc && x.PDATUM == ngay && x.CDOAN == congdoan).Select(w => w.WRKCT).Distinct();

            //Get data raw (khu vuc)
            ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.KHVUC == khvuc && x.PDATUM == ngay && x.CDOAN == congdoan).ToList();
            foreach (string strWrkct in listWRKCT)
            {
                SanLuongNgay sln = new SanLuongNgay();
                sln.CapDo = "WRKCT";
                sln.GiaTriCapDo = strWrkct;
                sln.CongDoan = congdoan;
                sln.Ngay = ngay;
                foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                {
                    if (bi_sln.WRKCT != strWrkct)
                    {
                        continue;
                    }
                    TinhLuyKe(ref sln, bi_sln);
                    sln.cntcd = bi_sln.CNTCD;
                }
                GetKeHoachWrkct(ref sln, mandt, sysid, sln.GiaTriCapDo);
                FinalList.Add((SanLuongNgay)sln);
            }
            return FinalList;
        }


        public List<SanLuongNgay> GetDetailNganh(string mandt, string sysid,
                                          string nganh, DateTime ngay, string congdoan)
        {
            var FinalList = new List<SanLuongNgay>();

            IQueryable<string> listKV;

            List<BI_SLSX_CHUYEN_NGAY> ListData;


            listKV = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.NGANH == nganh && x.PDATUM == ngay && x.CDOAN == congdoan).Select(w => w.KHVUC).Distinct();

            //Get data raw (khu vuc)
            ListData = dc.BI_SLSX_CHUYEN_NGAY.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.NGANH == nganh && x.PDATUM == ngay && x.CDOAN == congdoan).ToList();
            foreach (string strKV in listKV)
            {
                SanLuongNgay sln = new SanLuongNgay();
                sln.CapDo = "KHVUC";
                sln.GiaTriCapDo = strKV;
                sln.CongDoan = congdoan;
                sln.Ngay = ngay;
                foreach (BI_SLSX_CHUYEN_NGAY bi_sln in ListData)
                {
                    if (bi_sln.KHVUC != strKV)
                    {
                        continue;
                    }
                    TinhLuyKe(ref sln, bi_sln);
                    sln.cntcd = bi_sln.CNTCD;
                }
                GetKeHoachKV(ref sln, mandt, sysid, sln.GiaTriCapDo);
                FinalList.Add((SanLuongNgay)sln);
            }
            return FinalList;
        }

        public ArrayList BuildArrayList(List<SanLuongNgay> listSL, FilterCoditionModel filter)
        {
            ArrayList listChartData = new ArrayList();

            return listChartData;
        }

        private void GetKeHoachNganh(ref SanLuongNgay sln, string mandt, string sysid, string GiaTriNganh)
        {
            SanLuongNgay lv_sln = sln;
            DateTime firstDayofMonth = new DateTime(sln.Ngay.Year, sln.Ngay.Month, 1);
            List<BI_SLKH_WC> listSLKH = new List<BI_SLKH_WC>();
            string ngay = sln.Ngay.Day.ToString();
            //lay ke hoach
            listSLKH = dc.BI_SLKH_WC.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.NGANH == GiaTriNganh
                                && x.CNTCD == lv_sln.cntcd
                                && x.FIRSTDAY == firstDayofMonth).ToList();
            foreach (BI_SLKH_WC kh in listSLKH)
            {
                switch (ngay)
                {
                    case "1":
                        sln.KeHoach += Int64.Parse(kh.NGAY01.ToString());
                        break;
                    case "2":
                        sln.KeHoach += Int64.Parse(kh.NGAY02.ToString());
                        break;
                    case "3":
                        sln.KeHoach += Int64.Parse(kh.NGAY03.ToString());
                        break;
                    case "4":
                        sln.KeHoach += Int64.Parse(kh.NGAY04.ToString());
                        break;
                    case "5":
                        sln.KeHoach += Int64.Parse(kh.NGAY05.ToString());
                        break;
                    case "6":
                        sln.KeHoach += Int64.Parse(kh.NGAY06.ToString());
                        break;
                    case "7":
                        sln.KeHoach += Int64.Parse(kh.NGAY07.ToString());
                        break;
                    case "8":
                        sln.KeHoach += Int64.Parse(kh.NGAY08.ToString());
                        break;
                    case "9":
                        sln.KeHoach += Int64.Parse(kh.NGAY09.ToString());
                        break;
                    case "10":
                        sln.KeHoach += Int64.Parse(kh.NGAY10.ToString());
                        break;
                    case "11":
                        sln.KeHoach += Int64.Parse(kh.NGAY11.ToString());
                        break;
                    case "12":
                        sln.KeHoach += Int64.Parse(kh.NGAY12.ToString());
                        break;
                    case "13":
                        sln.KeHoach += Int64.Parse(kh.NGAY13.ToString());
                        break;
                    case "14":
                        sln.KeHoach += Int64.Parse(kh.NGAY14.ToString());
                        break;
                    case "15":
                        sln.KeHoach += Int64.Parse(kh.NGAY15.ToString());
                        break;
                    case "16":
                        sln.KeHoach += Int64.Parse(kh.NGAY16.ToString());
                        break;
                    case "17":
                        sln.KeHoach += Int64.Parse(kh.NGAY17.ToString());
                        break;
                    case "18":
                        sln.KeHoach += Int64.Parse(kh.NGAY18.ToString());
                        break;
                    case "19":
                        sln.KeHoach += Int64.Parse(kh.NGAY19.ToString());
                        break;
                    case "20":
                        sln.KeHoach += Int64.Parse(kh.NGAY20.ToString());
                        break;
                    case "21":
                        sln.KeHoach += Int64.Parse(kh.NGAY21.ToString());
                        break;
                    case "22":
                        sln.KeHoach += Int64.Parse(kh.NGAY22.ToString());
                        break;
                    case "23":
                        sln.KeHoach += Int64.Parse(kh.NGAY23.ToString());
                        break;
                    case "24":
                        sln.KeHoach += Int64.Parse(kh.NGAY24.ToString());
                        break;
                    case "25":
                        sln.KeHoach += Int64.Parse(kh.NGAY25.ToString());
                        break;
                    case "26":
                        sln.KeHoach += Int64.Parse(kh.NGAY26.ToString());
                        break;
                    case "27":
                        sln.KeHoach += Int64.Parse(kh.NGAY27.ToString());
                        break;
                    case "28":
                        sln.KeHoach += Int64.Parse(kh.NGAY28.ToString());
                        break;
                    case "29":
                        sln.KeHoach += Int64.Parse(kh.NGAY29.ToString());
                        break;
                    case "30":
                        sln.KeHoach += Int64.Parse(kh.NGAY30.ToString());
                        break;
                    default:
                        sln.KeHoach += Int64.Parse(kh.NGAY31.ToString());
                        break;
                }
            }
            if (sln.KeHoach > 0)
            {
                sln.Percent = Math.Round(double.Parse(sln.ThucHien.ToString()) / double.Parse(sln.KeHoach.ToString()) * 100, 2);
            }
            else
            {
                sln.Percent = 0;
            }

            if (sln.Percent < 95)
            {
                sln.TrangThai = "danger";
            }
            else if ((sln.Percent >= 95) && (sln.Percent < 100))
            {
                sln.TrangThai = "warning";
            }
            else
            {
                sln.TrangThai = "success";
            }
        }

        private void GetKeHoachKV(ref SanLuongNgay sln, string mandt, string sysid, string giatriKV)
        {
            SanLuongNgay lv_sln = sln;
            DateTime firstDayofMonth = new DateTime(sln.Ngay.Year, sln.Ngay.Month, 1);
            List<BI_SLKH_WC> listSLKH = new List<BI_SLKH_WC>();
            string ngay = sln.Ngay.Day.ToString();
            //lay ke hoach
            listSLKH = dc.BI_SLKH_WC.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.KHVUC == giatriKV
                                && x.CNTCD == lv_sln.cntcd
                                && x.FIRSTDAY == firstDayofMonth).ToList();
            foreach (BI_SLKH_WC kh in listSLKH)
            {
                switch (ngay)
                {
                    case "1":
                        sln.KeHoach += Int64.Parse(kh.NGAY01.ToString());
                        break;
                    case "2":
                        sln.KeHoach += Int64.Parse(kh.NGAY02.ToString());
                        break;
                    case "3":
                        sln.KeHoach += Int64.Parse(kh.NGAY03.ToString());
                        break;
                    case "4":
                        sln.KeHoach += Int64.Parse(kh.NGAY04.ToString());
                        break;
                    case "5":
                        sln.KeHoach += Int64.Parse(kh.NGAY05.ToString());
                        break;
                    case "6":
                        sln.KeHoach += Int64.Parse(kh.NGAY06.ToString());
                        break;
                    case "7":
                        sln.KeHoach += Int64.Parse(kh.NGAY07.ToString());
                        break;
                    case "8":
                        sln.KeHoach += Int64.Parse(kh.NGAY08.ToString());
                        break;
                    case "9":
                        sln.KeHoach += Int64.Parse(kh.NGAY09.ToString());
                        break;
                    case "10":
                        sln.KeHoach += Int64.Parse(kh.NGAY10.ToString());
                        break;
                    case "11":
                        sln.KeHoach += Int64.Parse(kh.NGAY11.ToString());
                        break;
                    case "12":
                        sln.KeHoach += Int64.Parse(kh.NGAY12.ToString());
                        break;
                    case "13":
                        sln.KeHoach += Int64.Parse(kh.NGAY13.ToString());
                        break;
                    case "14":
                        sln.KeHoach += Int64.Parse(kh.NGAY14.ToString());
                        break;
                    case "15":
                        sln.KeHoach += Int64.Parse(kh.NGAY15.ToString());
                        break;
                    case "16":
                        sln.KeHoach += Int64.Parse(kh.NGAY16.ToString());
                        break;
                    case "17":
                        sln.KeHoach += Int64.Parse(kh.NGAY17.ToString());
                        break;
                    case "18":
                        sln.KeHoach += Int64.Parse(kh.NGAY18.ToString());
                        break;
                    case "19":
                        sln.KeHoach += Int64.Parse(kh.NGAY19.ToString());
                        break;
                    case "20":
                        sln.KeHoach += Int64.Parse(kh.NGAY20.ToString());
                        break;
                    case "21":
                        sln.KeHoach += Int64.Parse(kh.NGAY21.ToString());
                        break;
                    case "22":
                        sln.KeHoach += Int64.Parse(kh.NGAY22.ToString());
                        break;
                    case "23":
                        sln.KeHoach += Int64.Parse(kh.NGAY23.ToString());
                        break;
                    case "24":
                        sln.KeHoach += Int64.Parse(kh.NGAY24.ToString());
                        break;
                    case "25":
                        sln.KeHoach += Int64.Parse(kh.NGAY25.ToString());
                        break;
                    case "26":
                        sln.KeHoach += Int64.Parse(kh.NGAY26.ToString());
                        break;
                    case "27":
                        sln.KeHoach += Int64.Parse(kh.NGAY27.ToString());
                        break;
                    case "28":
                        sln.KeHoach += Int64.Parse(kh.NGAY28.ToString());
                        break;
                    case "29":
                        sln.KeHoach += Int64.Parse(kh.NGAY29.ToString());
                        break;
                    case "30":
                        sln.KeHoach += Int64.Parse(kh.NGAY30.ToString());
                        break;
                    default:
                        sln.KeHoach += Int64.Parse(kh.NGAY31.ToString());
                        break;
                }
            }
            if (sln.KeHoach > 0)
            {
                sln.Percent = Math.Round(double.Parse(sln.ThucHien.ToString()) / double.Parse(sln.KeHoach.ToString()) * 100, 2);
            }
            else
            {
                sln.Percent = 0;
            }

            if (sln.Percent < 95)
            {
                sln.TrangThai = "danger";
            }
            else if ((sln.Percent >= 95) && (sln.Percent < 100))
            {
                sln.TrangThai = "warning";
            }
            else
            {
                sln.TrangThai = "success";
            }
        }

        private void GetKeHoachWrkct(ref SanLuongNgay sln, string mandt, string sysid, string giatriWrkct)
        {
            SanLuongNgay lv_sln = sln;
            DateTime firstDayofMonth = new DateTime(sln.Ngay.Year, sln.Ngay.Month, 1);
            List<BI_SLKH_WC> listSLKH = new List<BI_SLKH_WC>();
            string ngay = sln.Ngay.Day.ToString();
            //lay ke hoach
            listSLKH = dc.BI_SLKH_WC.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.WRKCT == giatriWrkct
                                && x.CNTCD == lv_sln.cntcd
                                && x.FIRSTDAY == firstDayofMonth).ToList();
            foreach (BI_SLKH_WC kh in listSLKH)
            {
                switch (ngay)
                {
                    case "1":
                        sln.KeHoach += Int64.Parse(kh.NGAY01.ToString());
                        break;
                    case "2":
                        sln.KeHoach += Int64.Parse(kh.NGAY02.ToString());
                        break;
                    case "3":
                        sln.KeHoach += Int64.Parse(kh.NGAY03.ToString());
                        break;
                    case "4":
                        sln.KeHoach += Int64.Parse(kh.NGAY04.ToString());
                        break;
                    case "5":
                        sln.KeHoach += Int64.Parse(kh.NGAY05.ToString());
                        break;
                    case "6":
                        sln.KeHoach += Int64.Parse(kh.NGAY06.ToString());
                        break;
                    case "7":
                        sln.KeHoach += Int64.Parse(kh.NGAY07.ToString());
                        break;
                    case "8":
                        sln.KeHoach += Int64.Parse(kh.NGAY08.ToString());
                        break;
                    case "9":
                        sln.KeHoach += Int64.Parse(kh.NGAY09.ToString());
                        break;
                    case "10":
                        sln.KeHoach += Int64.Parse(kh.NGAY10.ToString());
                        break;
                    case "11":
                        sln.KeHoach += Int64.Parse(kh.NGAY11.ToString());
                        break;
                    case "12":
                        sln.KeHoach += Int64.Parse(kh.NGAY12.ToString());
                        break;
                    case "13":
                        sln.KeHoach += Int64.Parse(kh.NGAY13.ToString());
                        break;
                    case "14":
                        sln.KeHoach += Int64.Parse(kh.NGAY14.ToString());
                        break;
                    case "15":
                        sln.KeHoach += Int64.Parse(kh.NGAY15.ToString());
                        break;
                    case "16":
                        sln.KeHoach += Int64.Parse(kh.NGAY16.ToString());
                        break;
                    case "17":
                        sln.KeHoach += Int64.Parse(kh.NGAY17.ToString());
                        break;
                    case "18":
                        sln.KeHoach += Int64.Parse(kh.NGAY18.ToString());
                        break;
                    case "19":
                        sln.KeHoach += Int64.Parse(kh.NGAY19.ToString());
                        break;
                    case "20":
                        sln.KeHoach += Int64.Parse(kh.NGAY20.ToString());
                        break;
                    case "21":
                        sln.KeHoach += Int64.Parse(kh.NGAY21.ToString());
                        break;
                    case "22":
                        sln.KeHoach += Int64.Parse(kh.NGAY22.ToString());
                        break;
                    case "23":
                        sln.KeHoach += Int64.Parse(kh.NGAY23.ToString());
                        break;
                    case "24":
                        sln.KeHoach += Int64.Parse(kh.NGAY24.ToString());
                        break;
                    case "25":
                        sln.KeHoach += Int64.Parse(kh.NGAY25.ToString());
                        break;
                    case "26":
                        sln.KeHoach += Int64.Parse(kh.NGAY26.ToString());
                        break;
                    case "27":
                        sln.KeHoach += Int64.Parse(kh.NGAY27.ToString());
                        break;
                    case "28":
                        sln.KeHoach += Int64.Parse(kh.NGAY28.ToString());
                        break;
                    case "29":
                        sln.KeHoach += Int64.Parse(kh.NGAY29.ToString());
                        break;
                    case "30":
                        sln.KeHoach += Int64.Parse(kh.NGAY30.ToString());
                        break;
                    default:
                        sln.KeHoach += Int64.Parse(kh.NGAY31.ToString());
                        break;
                }
            }

            if (sln.KeHoach > 0)
            {
                sln.Percent = Math.Round(double.Parse(sln.ThucHien.ToString()) / double.Parse(sln.KeHoach.ToString()) * 100, 2);
            }
            else
            {
                sln.Percent = 0;
            }

            if (sln.Percent < 95)
            {
                sln.TrangThai = "danger";
            }
            else if ((sln.Percent >= 95) && (sln.Percent < 100))
            {
                sln.TrangThai = "warning";
            }
            else
            {
                sln.TrangThai = "success";
            }
        }


        public void GetKeHoachChuyen(ref SanLuongNgay sln, string mandt, string sysid, string giatriChuyen)
        {
            SanLuongNgay lv_sln = sln;
            DateTime firstDayofMonth = new DateTime(sln.Ngay.Year, sln.Ngay.Month, 1);
            List<BI_SLKH_CH> listSLKH = new List<BI_SLKH_CH>();
            string ngay = sln.Ngay.Day.ToString();
            //lay ke hoach
            listSLKH = dc.BI_SLKH_CH.Where(x => x.MANDT == mandt && x.SYSID == sysid
                                && x.CHUYN == giatriChuyen
                                && x.CNTCD == lv_sln.cntcd
                                && x.FIRSTDAY == firstDayofMonth).ToList();
            foreach (BI_SLKH_CH kh in listSLKH)
            {
                switch (ngay)
                {
                    case "1":
                        sln.KeHoach += Int64.Parse(kh.NGAY01.ToString());
                        break;
                    case "2":
                        sln.KeHoach += Int64.Parse(kh.NGAY02.ToString());
                        break;
                    case "3":
                        sln.KeHoach += Int64.Parse(kh.NGAY03.ToString());
                        break;
                    case "4":
                        sln.KeHoach += Int64.Parse(kh.NGAY04.ToString());
                        break;
                    case "5":
                        sln.KeHoach += Int64.Parse(kh.NGAY05.ToString());
                        break;
                    case "6":
                        sln.KeHoach += Int64.Parse(kh.NGAY06.ToString());
                        break;
                    case "7":
                        sln.KeHoach += Int64.Parse(kh.NGAY07.ToString());
                        break;
                    case "8":
                        sln.KeHoach += Int64.Parse(kh.NGAY08.ToString());
                        break;
                    case "9":
                        sln.KeHoach += Int64.Parse(kh.NGAY09.ToString());
                        break;
                    case "10":
                        sln.KeHoach += Int64.Parse(kh.NGAY10.ToString());
                        break;
                    case "11":
                        sln.KeHoach += Int64.Parse(kh.NGAY11.ToString());
                        break;
                    case "12":
                        sln.KeHoach += Int64.Parse(kh.NGAY12.ToString());
                        break;
                    case "13":
                        sln.KeHoach += Int64.Parse(kh.NGAY13.ToString());
                        break;
                    case "14":
                        sln.KeHoach += Int64.Parse(kh.NGAY14.ToString());
                        break;
                    case "15":
                        sln.KeHoach += Int64.Parse(kh.NGAY15.ToString());
                        break;
                    case "16":
                        sln.KeHoach += Int64.Parse(kh.NGAY16.ToString());
                        break;
                    case "17":
                        sln.KeHoach += Int64.Parse(kh.NGAY17.ToString());
                        break;
                    case "18":
                        sln.KeHoach += Int64.Parse(kh.NGAY18.ToString());
                        break;
                    case "19":
                        sln.KeHoach += Int64.Parse(kh.NGAY19.ToString());
                        break;
                    case "20":
                        sln.KeHoach += Int64.Parse(kh.NGAY20.ToString());
                        break;
                    case "21":
                        sln.KeHoach += Int64.Parse(kh.NGAY21.ToString());
                        break;
                    case "22":
                        sln.KeHoach += Int64.Parse(kh.NGAY22.ToString());
                        break;
                    case "23":
                        sln.KeHoach += Int64.Parse(kh.NGAY23.ToString());
                        break;
                    case "24":
                        sln.KeHoach += Int64.Parse(kh.NGAY24.ToString());
                        break;
                    case "25":
                        sln.KeHoach += Int64.Parse(kh.NGAY25.ToString());
                        break;
                    case "26":
                        sln.KeHoach += Int64.Parse(kh.NGAY26.ToString());
                        break;
                    case "27":
                        sln.KeHoach += Int64.Parse(kh.NGAY27.ToString());
                        break;
                    case "28":
                        sln.KeHoach += Int64.Parse(kh.NGAY28.ToString());
                        break;
                    case "29":
                        sln.KeHoach += Int64.Parse(kh.NGAY29.ToString());
                        break;
                    case "30":
                        sln.KeHoach += Int64.Parse(kh.NGAY30.ToString());
                        break;
                    default:
                        sln.KeHoach += Int64.Parse(kh.NGAY31.ToString());
                        break;
                }
            }

            sln.Percent = Math.Round(double.Parse(sln.ThucHien.ToString()) / double.Parse(sln.KeHoach.ToString()) * 100, 2);

            if (sln.Percent < 95)
            {
                sln.TrangThai = "danger";
            }
            else if ((sln.Percent >= 95) && (sln.Percent < 100))
            {
                sln.TrangThai = "warning";
            }
            else
            {
                sln.TrangThai = "success";
            }
        }

        private void TinhLuyKe(ref SanLuongNgay sln, BI_SLSX_CHUYEN_NGAY bi_sln)
        {
            sln.Gio01 += Int64.Parse(bi_sln.GIO01.ToString());
            sln.Gio02 += Int64.Parse(bi_sln.GIO02.ToString());
            sln.Gio03 += Int64.Parse(bi_sln.GIO03.ToString());
            sln.Gio04 += Int64.Parse(bi_sln.GIO04.ToString());
            sln.Gio05 += Int64.Parse(bi_sln.GIO05.ToString());
            sln.Gio06 += Int64.Parse(bi_sln.GIO06.ToString());
            sln.Gio07 += Int64.Parse(bi_sln.GIO07.ToString());
            sln.Gio07 = sln.Gio07 + sln.Gio06 + sln.Gio05 + sln.Gio04 + sln.Gio04 + sln.Gio03 + sln.Gio02 + sln.Gio01;
            sln.Gio08 += Int64.Parse(bi_sln.GIO08.ToString());
            sln.Gio09 += Int64.Parse(bi_sln.GIO09.ToString());
            sln.Gio10 += Int64.Parse(bi_sln.GIO10.ToString());
            sln.Gio11 += Int64.Parse(bi_sln.GIO11.ToString());
            sln.Gio12 += Int64.Parse(bi_sln.GIO12.ToString());
            sln.Gio13 += Int64.Parse(bi_sln.GIO13.ToString());
            sln.Gio14 += Int64.Parse(bi_sln.GIO14.ToString());
            sln.Gio15 += Int64.Parse(bi_sln.GIO15.ToString());
            sln.Gio16 += Int64.Parse(bi_sln.GIO16.ToString());
            sln.Gio17 += Int64.Parse(bi_sln.GIO17.ToString());
            sln.Gio18 += Int64.Parse(bi_sln.GIO18.ToString());
            sln.Gio19 += Int64.Parse(bi_sln.GIO19.ToString());
            sln.Gio20 += Int64.Parse(bi_sln.GIO20.ToString());
            sln.Gio21 += Int64.Parse(bi_sln.GIO21.ToString());
            sln.Gio22 += Int64.Parse(bi_sln.GIO22.ToString());
            sln.Gio23 += Int64.Parse(bi_sln.GIO23.ToString());
            sln.Gio24 += Int64.Parse(bi_sln.GIO24.ToString());
            sln.Gio20 = sln.Gio20 + sln.Gio21 + sln.Gio22 + sln.Gio23 + sln.Gio24;
            sln.ThucHien += Int64.Parse(bi_sln.LK_NGAY.ToString());
        }
    }
}