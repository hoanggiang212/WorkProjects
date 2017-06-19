using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZEMP.DAO;
using ZEMP.Header;
using ZEMP.Models;

namespace ZEMP.DTO
{
    public class LiveboardDTO
    {

        public List<SelectListItem> GetListCongDoan(string sSystemId, string sLastCongDoan)
        {
            List<SelectListItem> listCongDoan = new List<SelectListItem>();

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    var listRaw = dc.GetCongDoanLiveboard(sSystemId).ToList<SelectListReturn>();
                    bool isSelect = false;

                    if (sLastCongDoan == null)
                    {
                        listCongDoan.Add(new SelectListItem() { Text = CommonHeader.CongDoanAllText, Value = CommonHeader.CongDoanAllValue, Selected = true });
                    }
                    else
                    {
                        listCongDoan.Add(new SelectListItem() { Text = CommonHeader.CongDoanAllText, Value = CommonHeader.CongDoanAllValue, Selected = false });
                    }

                    for (int i = 0; i < listRaw.Count; i++)
                    {
                        if (listRaw[i].value == sLastCongDoan) isSelect = true; else isSelect = false;

                        listCongDoan.Add(new SelectListItem() { Text = listRaw[i].text, Value = listRaw[i].value, Selected = isSelect });
                    }
                }
                catch(Exception ex)
                {
                    ZEMP_LOG zlog = new ZEMP_LOG()
                    {
                        Ngay = DateTime.Now,
                        LogKey = "GetCongDoanLiveboard",
                        LogDescription = string.Format("Exeption Msg: {0} ,SystemId: {1}", ex.Message, sSystemId)
                    };
                    dc.ZEMP_LOG.Add(zlog);
                    dc.SaveChanges();
                }

            }
            return listCongDoan;
        }

        public List<SelectListItem> GetModeView (ZEMP_USER account)
        {
            List<SelectListItem> listMode = new List<SelectListItem>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    var listRaw = dc.GetModeView(account.SystemId).ToList<SelectListReturn>();
                    bool isSelect = false;
                    for (int i = 0; i< listRaw.Count; i++)
                    {
                        isSelect = false;
                        if (account.LastMode == null)
                        {
                            if (i == 0) isSelect = true; else isSelect = false;
                        }
                        else
                        {
                            if (account.LastMode == listRaw[i].value) isSelect = true; else isSelect = false;
                        }

                        listMode.Add(new SelectListItem() { Value = listRaw[i].value, Text = listRaw[i].text, Selected = isSelect });
                    }
                }
                catch(Exception ex)
                {
                    ZEMP_LOG zlog = new ZEMP_LOG()
                    {
                        Ngay = DateTime.Now,
                        LogKey = "GetModeView",
                        LogDescription = string.Format("Exeption Msg: {0} ,SystemId: {1}", ex.Message, account.SystemId)
                    };
                    dc.ZEMP_LOG.Add(zlog);
                    dc.SaveChanges();
                }
            }
            return listMode;
        }

        public List<SanLuongOnline> GetSanLuongOnline(string sModeView, string sCapDo, string sGiaTriCapDo, string sCongDoan, string sNgay)
        {
            var ListSanLuong = new List<SanLuongOnline>( );

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                List<SanLuongOnlineReturn> listRaw = dc.GetSanLuongOnline(CommonHeader.defaultSystemId, sModeView, sCapDo, sGiaTriCapDo, sCongDoan, sNgay).ToList<SanLuongOnlineReturn>();
                foreach( var item in listRaw)
                {
                    var itemSanLuong = new SanLuongOnline()
                    {
                        BoPhan      = item.BoPhan,
                        CongDoan    = item.TenCongDoan,
                        SoLuongLaoDong = int.Parse(item.SoLuongLD.ToString()),
                        NangSuat    = double.Parse(item.NangSuat.ToString()),
                        GioLamViec  = double.Parse(item.GioLamViec.ToString()),
                        KeHoachGio  = int.Parse(item.KeHoachGio.ToString()),
                        KeHoachNgay = int.Parse(item.KeHoachNgay.ToString()),
                        ThucHien    = int.Parse(item.ThucHienNgay.ToString()),
                        ChenhLech   = int.Parse(item.ChenhLech.ToString()),
                        DatSanLuong = double.Parse(item.DatKeHoach.ToString()),
                        Truoc8h     = int.Parse(item.Truoc8h.ToString()),
                        Gio08       = int.Parse(item.Gio08.ToString()),
                        Gio09       = int.Parse(item.Gio09.ToString()),
                        Gio10       = int.Parse(item.Gio10.ToString()),
                        Gio11       = int.Parse(item.Gio11.ToString()),
                        Gio12       = int.Parse(item.Gio12.ToString()),
                        Gio13       = int.Parse(item.Gio13.ToString()),
                        Gio14       = int.Parse(item.Gio14.ToString()),
                        Gio15       = int.Parse(item.Gio15.ToString()),
                        Gio16       = int.Parse(item.Gio16.ToString()),
                        Gio17       = int.Parse(item.Gio17.ToString()),
                        Gio18       = int.Parse(item.Gio18.ToString()),
                        Sau18       = int.Parse(item.Sau18h.ToString())
                    };

                    if (item.IsNoColor.Trim() == "X"){itemSanLuong.isColor = false;}else{itemSanLuong.isColor = true;}

                    //Set color for text
                    if (itemSanLuong.isColor) // Co to mau
                    {
                        if(itemSanLuong.DatSanLuong < 95)
                        {
                            itemSanLuong.sColorText = CommonHeader.CSS_TEXT_RED;
                        }
                        else if ((itemSanLuong.DatSanLuong >= 95)&&(itemSanLuong.DatSanLuong < 100))
                        {
                            itemSanLuong.sColorText = CommonHeader.CSS_TEXT_YELLOW;
                        }
                        else
                        {
                            itemSanLuong.sColorText = CommonHeader.CSS_TEXT_GREEN;
                        }
                    }
                    else // Khong to mau
                    {
                        itemSanLuong.sColorText = "";
                    }
                    ListSanLuong.Add(itemSanLuong);
                }
            }
            return ListSanLuong;
        }

    }
}