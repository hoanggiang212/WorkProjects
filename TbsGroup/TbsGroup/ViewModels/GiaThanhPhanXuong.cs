using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TbsGroup.ViewModels
{
    public class GiaThanhPhanXuong
    {
        public DateTime Ngay { set; get; }

        public string CapDo { get; set; }

        public string GiaTriCapDo { get; set; }

        public string CongDoan { get; set; }


        public double gtVatTuKeHoach { get; set; }
        public double gtVatTuThucHien { get; set; }

        public double gtNhanCongKeHoach { get; set; }
        public double gtNhanCongThucHien { get; set; }

        public double gtTaiSanKeHoach { get; set; }
        public double gtTaiSanThucHien { get; set; }


        public double ptVatTuKeHoach { get; set; }
        public double ptVatTuThucHien { get; set; }

        public double ptNhanCongKeHoach { get; set; }
        public double ptNhanCongThucHien { get; set; }

        public double ptTaiSanKeHoach { get; set; }
        public double ptTaiSanThucHien{ get; set; }
    }
}