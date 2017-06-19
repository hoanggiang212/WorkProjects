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

                filter.ListCapDo = accDto.GetListCapDoByUsername(account);

                foreach(var item in  filter.ListCapDo)
                {
                    if (item.Selected)
                    {
                        filter.SelectedCapDo = item.Value;
                        break;
                    }
                }
                if ( filter.ListCapDo.Count() == 0 )
                {
                    strResult = "Chưa được phân quyền";
                }

                //Get list gia tri cap do theo selected cap do
                filter.ListGiaTriCapDo = accDto.GetListGiaTriCapDo(account, filter.SelectedCapDo);
                foreach (var item in  filter.ListGiaTriCapDo)
                {
                    if (item.Selected)
                    {
                        filter.SelectedGiaTriCapDo = item.Value;
                        break;
                    }
                }

                LiveboardDTO liveboard = new LiveboardDTO();
                //Get list cong doan
                filter.ListCongDoan = liveboard.GetListCongDoan(account.SystemId, account.LastCongDoan);
                foreach(var item in filter.ListCongDoan)
                {
                    if (item.Selected)
                    {
                        filter.SelectedCongDoan = item.Value;
                    }
                }
                filter.ListModeView = liveboard.GetModeView(account);
                foreach (var item in filter.ListModeView)
                {
                    if (item.Selected)
                    {
                        filter.SelectedMode = item.Value;
                    }
                }
                return strResult;
            }
        }

        
    }
}