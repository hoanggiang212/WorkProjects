﻿using System;
using System.Collections;
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

        public ArrayList getDataForCharts(FilterCondition f)
        {
            var listTong = new ArrayList();
            //DELCARATION
            var listCd = new List<ListCongDoan>();
            var listKhTh = new List<KHTHReturn>();
            var listCountStatus = new List<CountStatus>();
            var listChiPhi = new List<ChiPhiSanXuat>();
            var listLaoDong = new List<ThongKeLaoDong>();

            
            //get data ke hoach / thuc hien
            listKhTh = GetKeHoachThucHien(f);

            //get so luong chuyen theo status / ngay
            listCountStatus = CountStatusChuyen(f);

            listChiPhi = GetChiPhiSanXuat(f);

            listLaoDong = GetThongKeLaoDong(f);


            //Add header rows for array list
            ArrayList lineHeader = new ArrayList();
            lineHeader.Add("Ngay");

            listCd = getCongDoanKeHoachThucHien(f);
            for(int i = 0; i < listCd.Count; i++)
            {
                lineHeader.Add(string.Format("KeHoach-{0}", listCd[i].ToString()));
                lineHeader.Add(string.Format("ThucHien-{0}", listCd[i].ToString()));
            }
            

            //add body data
            for (int i = 0; i < f.listDate.Count; i++)
            {
                //add day
                ArrayList arrLine = new ArrayList();
                lineHeader.CopyTo( arrLine );
                arrLine.Add(f.listDate[i].ToShortDateString());

                //add san luong ke hoach / thuc hien
                for (int irSl = 0; irSl < listKhTh.Count; irSl++)
                {
                    if (f.listDate[i] != listKhTh[irSl].NGAY)
                    {
                        continue;
                    }
                    arrLine.Add
                }

            }

            return listTong;
        }

        private List<ListCongDoan> getCongDoanKeHoachThucHien(FilterCondition f)
        {
            List<ListCongDoan> listCd = new List<ListCongDoan>();
            using(TKTDSXEntities dc = new TKTDSXEntities() )
            {
                listCd = dc.GetCongDoanKhTh(f.SystemId, f.SelectedCapDo, f.SelectedGiaTriCapDo,
                                f.SelectedCongDoan, f.sDateFrom, f.sDateTo).ToList<ListCongDoan>();
            }
            return listCd;
        }

        private List<KHTHReturn> GetKeHoachThucHien(FilterCondition filter)
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

        private List<CountStatus> CountStatusChuyen(FilterCondition f)
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

        private List<ChiPhiSanXuat> GetChiPhiSanXuat(FilterCondition f)
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

        private List<ThongKeLaoDong> GetThongKeLaoDong(FilterCondition f)
        {
            var listLaoDong = new List<ThongKeLaoDong>();
            using (TKTDSXEntities dc = new TKTDSXEntities())
            {
                try
                {
                    listLaoDong = dc.GetThongKeLaoDong(f.SystemId, f.SelectedCapDo,
                                f.SelectedGiaTriCapDo, f.SelectedCongDoan, f.sDateFrom, f.sDateTo).ToList<ThongKeLaoDong>();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                return listLaoDong;
            }
        } //end function - GetThongKeLaoDong
    } //end class
} // end namspace