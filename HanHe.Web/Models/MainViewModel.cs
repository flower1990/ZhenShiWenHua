using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HanHe.Model;

namespace HanHe.Web.Models
{
    public class MainViewModel
    {
        public List<Zs_Project> Projects { get; set; }
        public List<Zs_ChuanJia> ChuanJias { get; set; }
        public List<Zs_GanWu> GanWus { get; set; }
    }
}