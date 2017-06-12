using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TbsGroup.ViewModels
{
    public class NangSuatLaoDong
    {
        public DateTime Ngay { set; get; }

        public string CapDo { get; set; }

        public string GiaTriCapDo { get; set; }

        public string CongDoan { get; set; }

        public string cntcd { get; set; }
        public double NangSuat { get; set; }

        public double SoLuongLaoDong { get; set; }

    }
}