using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.GuoXue
{
    public class GuoXueEdit
    {
        /// <summary>
        /// GxID
        /// </summary>		
        public long GxID { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>		
        [Display(Name = "关键词")]
        [Required(ErrorMessage = "请输入关键字")]
        public string Keywords { get; set; }
        /// <summary>
        /// 标题
        /// </summary>		
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "长度为4-200个字符")]
        public string GxTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>		
        [Display(Name = "短标题")]
        [Required(ErrorMessage = "请输入短标题")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "长度为4-20个字符")]
        public string GxTitleShort { get; set; }
        /// <summary>
        /// 内容
        /// </summary>		
        [Display(Name = "内容")]
        public string GxInfo { get; set; }
        /// <summary>
        /// 类别一
        /// </summary>		
        [Display(Name = "类别一")]
        public int Category01 { get; set; }
        /// <summary>
        /// 类别二
        /// </summary>		
        [Display(Name = "类别二")]
        public int Category02 { get; set; }
        /// <summary>
        /// 类别三
        /// </summary>		
        [Display(Name = "类别三")]
        public int Category03 { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 状态：0、未发布；1、已发布；
        /// </summary>		
        [Display(Name = "状态")]
        public int GxStatus { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>		
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 浏览统计
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞统计
        /// </summary>		
        public int GoodCount { get; set; }
    }
}