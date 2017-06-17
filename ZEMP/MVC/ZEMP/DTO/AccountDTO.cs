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
        public List<SelectListItem> GetListCapDoByUsername(string sUsername, string sLastCapDo)
        {
            bool isSelect = false;
            List<SelectListItem> selectList = new List<SelectListItem>();

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    var listRaw = dc.GetListCapDo(sUsername).ToList<SelectListReturn>();

                    for (int i = 0; i < listRaw.Count; i++)
                    {
                        if (sLastCapDo != "")
                        {
                            if (listRaw[i].Value == sLastCapDo)
                            {
                                isSelect = true;
                            }
                            else
                            {
                                isSelect = false;
                            }
                        }
                        else
                        {
                            if (i == 0)  //select first
                            {
                                isSelect = true;
                            }
                            else
                            {
                                isSelect = false;
                            }
                        }
                        selectList.Add(new SelectListItem() { Text = listRaw[i].Text, Value = listRaw[i].Value, Selected = isSelect });
                    }
                }
                catch (Exception ex)
                {
                    ZEMP_LOG zlog = new ZEMP_LOG()
                    {
                        Ngay = DateTime.Now,
                        LogKey = "GetListCapDoByUsername",
                        LogDescription = string.Format("Exeption Msg: {0} , Username: {1} , LastCapDo: {2}", 
                                                        ex.Message, sUsername, sLastCapDo)
                    };

                }
            }
            return selectList;
        }

        public List<SelectListItem> GetListGiaTriCapDo(string sUserName, string sCapDo, string sLastGiaTriCapDo)
        {
            bool isSelect = false;
            List<SelectListItem> selectList = new List<SelectListItem>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                var listRaw = dc.GetListGiaTriCapDo(sUserName, sCapDo).ToList<SelectListReturn>();
                for (int i= 0; i < listRaw.Count; i++)
                {
                    if (sLastGiaTriCapDo != "")
                    {
                        if (listRaw[i].Value == sLastGiaTriCapDo)
                        {
                            isSelect = true;
                        }
                        else
                        {
                            isSelect = false;
                        }
                    }
                    else
                    {
                        if (i == 0)  //select first
                        {
                            isSelect = true;
                        }
                        else
                        {
                            isSelect = false;
                        }
                    }
                    selectList.Add(new SelectListItem() { Text = listRaw[i].Text, Value = listRaw[i].Value, Selected = isSelect });
                }
            }
            return selectList;
        }


    }
}