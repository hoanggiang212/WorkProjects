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
                List<SanLuongOnlineReturn> listRaw = dc.GetSanLuongOnline(CommonHeader.defaultSystemId, sModeView, sCapDo, sGiaTriCapDo, sCongDoan, sNgay);
            }

                return ListSanLuong;
        }

    }
}