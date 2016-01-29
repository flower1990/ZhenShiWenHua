using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.FCircle
{
    public class FCircleCreate
    {
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        [Display(Name = "所属会员ID")]
        public long MID { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>		
        [Display(Name = "分享标题")]
        public string FCTitle { get; set; }
        /// <summary>
        /// 分享原创文本内容
        /// </summary>		
        [Display(Name = "分享原创文本内容")]
        public string FCInfo { get; set; }
        /// <summary>
        /// 分享的链接
        /// </summary>		
        [Display(Name = "分享的链接")]
        public string FCUrl { get; set; }
    }
}