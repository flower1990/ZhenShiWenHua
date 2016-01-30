using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Project
{
    public class ProjectEdit
    {
        /// <summary>
        /// ProjectID
        /// </summary>		
        public long ProjectID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>	
        [Display(Name = "会员编号")]
        [Required(ErrorMessage = "请输入会员编号")]
        public long MID { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>		
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "长度为4-200个字符")]
        public string ProTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>
        [Display(Name = "短标题")]
        [Required(ErrorMessage = "请输入短标题")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "长度为4-20个字符")]
        public string ProTitleShort { get; set; }
        /// <summary>
        /// 项目文本内容
        /// </summary>
        [Display(Name = "行事历内容")]
        public string ProInfo { get; set; }
        /// <summary>
        /// 重要程度：0、普通，缺省值；1、重要；
        /// </summary>		
        [Display(Name = "重要程度")]
        public int ImpropantWeight { get; set; }
        /// <summary>
        /// 紧急程度：0、普通，缺省值；1、紧急；
        /// </summary>	
        [Display(Name = "紧急程度")]
        public int UrgentWeight { get; set; }
        /// <summary>
        /// 排序字段，倒序
        /// </summary>		
        [Display(Name = "排序字段")]
        [Required(ErrorMessage = "请输入进度排序字段")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能输入数字")]
        public int SortID { get; set; }
        /// <summary>
        /// 启动日期，默认创建日期为启动日期；预设启动日期，到期后，自动将事务状态设置为“进行中”
        /// </summary>		
        [Display(Name = "启动日期")]
        [Required(ErrorMessage = "请输入启动日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 计划完成日期
        /// </summary>		
        [Display(Name = "计划完成日期")]
        [Required(ErrorMessage = "请输入计划完成日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ExpectDate { get; set; }
        /// <summary>
        /// 项目状态：0、初始状态，缺省值；1、完成；2、进行中；-1、放弃；
        /// </summary>		
        [Display(Name = "项目状态")]
        public int ProStatus { get; set; }
        /// <summary>
        /// 进度，输入0-100的整数，以百分比显示
        /// </summary>		
        [Display(Name = "进度")]
        [Required(ErrorMessage = "请输入进度")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能输入数字")]
        public int ProgressNum { get; set; }
        /// <summary>
        /// 开放状态：0、隐私；1、开放；2、好友可见
        /// </summary>		
        [Display(Name = "开放状态")]
        public int OpenStatus { get; set; }
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