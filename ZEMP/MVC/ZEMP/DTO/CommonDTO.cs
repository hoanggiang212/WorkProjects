using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZEMP.Models;
using ZEMP.DAO;
using ZEMP.Header;
namespace ZEMP.DTO
{
    public class CommonDTO
    {

        public string GetPhanQuyen(ref FilterCondition filter, ZEMP_USER account)
        {
            string strResult = CommonHeader.ResultOK;
            AccountDTO accDto = new AccountDTO();

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {

                filter.ListCapDo = accDto.GetListCapDoByUsername(account.Username, account.LastCapDo);

                for(int i = 0; i < filter.ListCapDo.Count; i++)
                {
                    if (filter.ListCapDo[i].Selected)
                    {
                        filter.SelectedCapDo = filter.ListCapDo[i].Value;
                        break;
                    }
                }
                if ( filter.ListCapDo.Count() == 0 )
                {
                    strResult = "Chưa được phân quyền";
                }

                //Get list gia tri cap do theo selected cap do
                filter.ListGiaTriCapDo = accDto.GetListGiaTriCapDo(account.Username, 
                                                filter.SelectedCapDo, account.LastGiaTriCapDo);
                for (int i = 0; i < filter.ListGiaTriCapDo.Count; i++)
                {
                    if (filter.ListGiaTriCapDo[i].Selected)
                    {
                        filter.SelectedGiaTriCapDo = filter.ListGiaTriCapDo[i].Value;
                        break;
                    }
                }
                return strResult;
            }
        }

    }
}