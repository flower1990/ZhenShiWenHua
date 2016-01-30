using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.ChuanJia
{
    public class ChuanJiaEdit
    {
        /// <summary>
        /// CJID
        /// </summary>		
        public long CJID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>		
        [Display(Name = "会员编号")]
        [Required(ErrorMessage = "请输入会员编号")]
        public long MID { get; set; }
        /// <summary>
        /// 传家类别：1.墓志铭2.家训3.遗训4.文化传承；
        /// </summary>		
        [Display(Name = "传家类别")]
        public int TypeID { get; set; }
        /// <summary>
        /// 传家标题
        /// </summary>		
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "长度为4-200个字符")]
        public string CJTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>		
        [Display(Name = "短标题")]
        [Required(ErrorMessage = "请输入短标题")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "长度为4-20个字符")]
        public string CJTitleShort { get; set; }
        /// <summary>
        /// 传家内容
        /// </summary>		
        [Display(Name = "传家内容")]
        public string CJInfo { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>		
        [Display(Name = "公开状态")]
        public int OpenStatus { get; set; }
        /// <summary>
        /// 排序字段：倒序排列
        /// </summary>		
        [Display(Name = "排序")]
        public int SortID { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>	
        [Display(Name = "更新日期")]
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 浏览计数
        /// </summary>	
        [Display(Name = "浏览计数")]
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞计数
        /// </summary>	
        [Display(Name = "点赞计数")]
        public int GoodCount { get; set; }
    }
}