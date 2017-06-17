﻿using System;
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
        public List<SelectListItem> ListModeView { get; set; }
        public string SelectedMode { get; set; }

        public List<SelectListItem> ListCongDoan { get; set; }
        public string SelectedCongDoan { get; set; }

        public List<SelectListItem> ListCapDo { get; set; }

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

    }
}