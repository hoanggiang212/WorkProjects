using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZEMP.Models;
using ZEMP.DAO;
namespace ZEMP.DTO
{
    public class CommonDTO
    {

        public string GetPhanQuyen(ref FilterCondition filter, ZEMP_USER account)
        {
            string strResult = "OK";
            FilterCondition lv_filter = filter;
            //lay cap do dau tien
            string sCapDoID = string.Empty; ;
            string sCapDoName = string.Empty;

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {

                string FirstGiaTriCapDoID = string.Empty;
                try
                {
                    AccountDTO accDto = new AccountDTO();
                    filter.ListCapDo = accDto.GetListCapDoByUsername(account.Username, account.LastCapDo);
                }
                catch (Exception ex)
                {

                    string errMsg = string.Format("ERROR MSG: {0} ; CONDITION [ username: {1} , LASTCAPDO: {2} ]",
                                            ex.Message, account.Username ,account.LastCapDo);

                    ZEMP_LOG zLog = new ZEMP_LOG()
                    {
                        SystemId = account.SystemId,
                        LogKey = "GetPhanQuyen",
                        LogDescription = errMsg,
                        Ngay = DateTime.Now
                    };
                    dc.ZEMP_LOG.Add(zLog);
                    dc.SaveChanges();
                    strResult = "Có lỗi xảy ra, vui lòng liên hệ Admin.";
                    return strResult;
                }

                if ( filter.ListCapDo.Count() == 0 )
                {
                    strResult = "Chưa được phân quyền";
                }

                return strResult;
            }
        }

    }
}