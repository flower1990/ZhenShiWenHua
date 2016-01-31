using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Web.Models
{
    public class FCircleViewModel
    {
        public Zs_FCircle FCircle { get; set; }
        public List<Zs_FCAtt> FCAtt { get; set; }
    }
    public class FCircleCreate
    {
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>		
        public string FCTitle { get; set; }
        /// <summary>
        /// 分享原创文本内容
        /// </summary>		
        public string FCInfo { get; set; }
        /// <summary>
        /// 分享的链接
        /// </summary>		
        public string FCUrl { get; set; }
        /// <summary>
        /// 浏览量统计
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞统计
        /// </summary>		
        public int GoodCount { get; set; }
    }
}