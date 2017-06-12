using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TbsGroup.ViewModels
{
    public class TrangThaiChuyen
    {
        public DateTime Ngay { set; get; }

        public string maChuyen { set; get; }

        public string tenChuyen { set; get; }

        public Int32 TongSoChuyen { set; get; }

        public Int32 redStatus { set; get; }
        public Int32 yellowStatus { set; get; }
        public Int32 greenStatus { set; get; }

        public Int32 otherStatus { set; get; }
    }
}