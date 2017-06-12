using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TbsGroup.ViewModels
{
    public class ThongKeLaoDong
    {
        public DateTime Ngay { set; get; }

        public string CapDo { set; get; }

        public string GiaTriCapDo { set; get; }

        public long SoLuongDiLam { set; get; }

        public long SoLuongNghi { set; get; }

        public long TongSoLuong { set; get; }
    }
}