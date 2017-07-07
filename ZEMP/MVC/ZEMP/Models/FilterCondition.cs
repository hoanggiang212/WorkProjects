using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZEMP.Models
{
    public class FilterCondition
    {        
        public string SystemId { get; set; }

        //Mode view: Nganh / Khu vuc / Work Center / Chuyen
        public IEnumerable<SelectListItem> ListModeView { get; set; }
        public string SelectedMode { get; set; }

        public IEnumerable<SelectListItem> ListCongDoan { get; set; }
        public string SelectedCongDoan { get; set; }

        public IEnumerable<SelectListItem> ListCapDo { get; set; }
        public string SelectedCapDo { set; get; }

        public IEnumerable<SelectListItem> ListGiaTriCapDo { set; get; }
        public string SelectedGiaTriCapDo { set; get; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date From")]
        public DateTime DateFrom { set; get; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date To")]
        public DateTime DateTo { set; get; }

        public List<DateTime> listDate { set; get; }


        public string sDateFrom;
        public string sDateTo;

        public void ConvertDate2Sql()
        {
            sDateFrom = string.Format("{0}-{1}-{2}", DateFrom.Year, DateFrom.Month, DateFrom.Day);
            sDateTo = string.Format("{0}-{1}-{2}", DateTo.Year, DateTo.Month, DateTo.Day);
        }

    }
}