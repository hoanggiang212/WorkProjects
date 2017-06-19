using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZEMP.DAO;

namespace ZEMP.DTO
{
    public class AccountDTO
    {
        public List<SelectListItem> GetListCapDoByUsername(ZEMP_USER account)
        {
            bool isSelect = false;
            List<SelectListItem> selectList = new List<SelectListItem>();

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    var listRaw = dc.GetListCapDo(account.SystemId,account.Username).ToList<SelectListReturn>();

                    for (int i = 0; i < listRaw.Count; i++)
                    {
                        if (account.LastCapDo != "")
                        {
                            if (listRaw[i].value == account.LastCapDo) {isSelect = true; }
                            else {isSelect = false; }
                        }
                        else
                        {
                            if (i == 0) {isSelect = true; }
                            else {isSelect = false;}
                        }
                        selectList.Add(new SelectListItem() { Text = listRaw[i].text, Value = listRaw[i].value, Selected = isSelect });
                    }
                }
                catch (Exception ex)
                {
                    ZEMP_LOG zlog = new ZEMP_LOG()
                    {
                        Ngay = DateTime.Now,
                        LogKey = "GetListCapDoByUsername",
                        LogDescription = string.Format("Exeption Msg: {0} , Username: {1} , LastCapDo: {2}", 
                                                        ex.Message, account.Username, account.LastCapDo)
                    };
                    dc.ZEMP_LOG.Add(zlog);
                    dc.SaveChanges();
                }
            }
            return selectList;
        }

        public List<SelectListItem> GetListGiaTriCapDo(ZEMP_USER account, string sCapDo)
        {
            bool isSelect = false;
            List<SelectListItem> selectList = new List<SelectListItem>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    var listRaw = dc.GetListGiaTriCapDo(account.SystemId, account.Username, sCapDo).ToList<SelectListReturn>();
                    for (int i = 0; i < listRaw.Count; i++)
                    {
                        if (account.LastGiaTriCapDo != "")
                        {
                            if (listRaw[i].value == account.LastGiaTriCapDo) { isSelect = true; }
                            else { isSelect = false; }
                        }
                        else
                        {
                            if (i == 0) { isSelect = true; }
                            else { isSelect = false; }
                        }
                        selectList.Add(new SelectListItem() { Text = listRaw[i].text, Value = listRaw[i].value, Selected = isSelect });
                    }
                }
                catch (Exception ex)
                {
                    ZEMP_LOG zlog = new ZEMP_LOG()
                    {
                        Ngay = DateTime.Now,
                        LogKey = "GetListGiaTriCapDo",
                        LogDescription = string.Format("Exeption Msg: {0} , Username: {1} , LastCapDo: {2}",
                                                       ex.Message, account.Username,sCapDo)
                    };
                    dc.ZEMP_LOG.Add(zlog);
                    dc.SaveChanges();
                }
            }
            return selectList;
        }


    }
}