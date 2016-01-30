using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.GanWu
{
    public class GanWuEdit
    {
        /// <summary>
        /// GwID
        /// </summary>		
        public long GwID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        [Display(Name = "会员编号")]
        [Required(ErrorMessage = "请输入会员编号")]
        public long MID { get; set; }
        /// <summary>
        /// 感悟标题
        /// </summary>		
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "长度为4-200个字符")]
        public string GwTitle { get; set; }
        /// <summary>
        /// 感悟短标题
        /// </summary>	
        [Display(Name = "短标题")]
        [Required(ErrorMessage = "请输入短标题")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "长度为4-20个字符")]
        public string GwTitleShort { get; set; }
        /// <summary>
        /// 感悟内容
        /// </summary>		
        [Display(Name = "内容")]
        public string GwInfo { get; set; }
        /// <summary>
        /// 感悟类别：1、感悟；2、梦想心愿；3、大事；4、未来的信；5、杂谈；
        /// </summary>		
        [Display(Name = "感悟类别")]
        public int GwType { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>		
        [Display(Name = "公开状态")]
        public int OpenStatus { get; set; }
        /// <summary>
        /// 未来日期：未来的信寄达日期，梦想心愿的实现日期
        /// </summary>		
        [Display(Name = "未来日期")]
        [Required(ErrorMessage = "请输入未来日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime GotoDate { get; set; }
        /// <summary>
        /// 寄送日期
        /// </summary>		
        [Display(Name = "寄送日期")]
        [Required(ErrorMessage = "请输入寄送日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 状态：0、初始；1、提交；2、送达；
        /// </summary>		
        [Display(Name = "状态")]
        public int GwStatus { get; set; }
        /// <summary>
        /// 短信提醒状态：0、不发短信；1、发送短信，缺省值；
        /// </summary>		
        [Display(Name = "短信提醒状态")]
        public int SmsStatus { get; set; }
        /// <summary>
        /// 排序字段：倒序排列
        /// </summary>
        [Display(Name = "排序")]
        public int SortID { get; set; }
        /// <summary>
        /// 浏览统计
        /// </summary>		
        [Display(Name = "浏览统计")]
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞统计
        /// </summary>	
        [Display(Name = "点赞统计")]
        public int GoodCount { get; set; }
    }
}