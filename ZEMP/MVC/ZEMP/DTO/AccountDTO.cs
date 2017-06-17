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
                var result =  dc.GetListCapDo(sUsername).ToList<ListCapDo>();

                for (int i = 0; i< result.Count; i++)
                {
                    if (result[i].CapDo == sLastCapDo)
                    {
                        isSelect = true;
                    }
                    else
                    {
                        isSelect = false;
                    }
                    selectList.Add(new SelectListItem(){ Text = result[i].DienGiai, Value = result[i].CapDo,  Selected = isSelect });
                }
            }
            return selectList;
        }


    }
}