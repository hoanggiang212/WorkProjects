using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZEMP.DAO;
using ZEMP.Header;
using ZEMP.Models;

namespace ZEMP.DTO
{
    public class DashboardDTO
    {
        public List<KHTHReturn> GetKeHoachThucHien(FilterCondition filter)
        {
            List<KHTHReturn> listKHTH = new List<KHTHReturn>();

            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                listKHTH = dc.GetKeHoachThucHien(filter.SystemId,
                                            filter.SelectedCapDo,
                                            filter.SelectedGiaTriCapDo,
                                            filter.SelectedCongDoan,
                                            filter.sDateFrom,
                                            filter.sDateTo).ToList<KHTHReturn>();
            }

            return listKHTH;
        }

        public List<CountStatus> CountStatusChuyen(FilterCondition f)
        {
            var listCountStatus = new List<CountStatus>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    listCountStatus = dc.CountTrangThaiChuyen(f.SystemId, f.SelectedCapDo,
                        f.SelectedGiaTriCapDo, f.SelectedCongDoan, f.sDateFrom, f.sDateTo).ToList<CountStatus>();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
            return listCountStatus;
        }

        public List<ChiPhiSanXuat> GetChiPhiSanXuat(FilterCondition f)
        {
            var listChiPhi = new List<ChiPhiSanXuat>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    listChiPhi = dc.GETCHIPHISANXUAT(f.SystemId,
                        f.SelectedCapDo, f.SelectedGiaTriCapDo, f.SelectedCongDoan,
                        f.sDateFrom, f.sDateTo).ToList<ChiPhiSanXuat>();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
                return listChiPhi;
        }



    }
}