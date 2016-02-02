using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HanHe.Model;
using System.ComponentModel.DataAnnotations;

namespace HanHe.Web.Models
{
    /// <summary>
    /// 事例
    /// </summary>
    public class ProjectViewModel
    {
        public Zs_Project Project { get; set; }
        public List<Zs_ProjectAtt> ProjectAtt { get; set; }
    }
    public class GetProjectAllModel
    {
        public long ProjectID { get; set; }
        public string ProTitle { get; set; }
        public string ProTitleShort { get; set; }
        public string AttUrl { get; set; }
    }
    /// <summary>
    /// 添加事历
    /// </summary>
    public class AddProjectModel
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        [Required(ErrorMessage = "必填")]
        public long MID { get; set; }
        /// <summary>
        /// 事历标题
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public string ProTitle { get; set; }
        /// <summary>
        /// 事历短标题
        /// </summary>
        [Required(ErrorMessage = "必填")]
        public string ProTitleShort { get; set; }
        /// <summary>
        /// 项目文本内容
        /// </summary>		
        public string ProInfo { get; set; }
        /// <summary>
        /// 重要程度：0、普通，缺省值；1、重要；
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public int ImpropantWeight { get; set; }
        /// <summary>
        /// 紧急程度：0、普通，缺省值；1、紧急；
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public int UrgentWeight { get; set; }
        /// <summary>
        /// 启动日期，默认创建日期为启动日期；预设启动日期，到期后，自动将事务状态设置为“进行中”
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 计划完成日期
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public DateTime ExpectDate { get; set; }
        /// <summary>
        /// 项目状态：0、初始状态，缺省值；1、完成；2、进行中；-1、放弃；
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public int ProStatus { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        public DateTime FinishedDate { get; set; }
        /// <summary>
        /// 进度，输入0-100的整数，以百分比显示
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public int ProgressNum { get; set; }
        /// <summary>
        /// 开放状态：0、隐私；1、开放；2、好友可见
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public int OpenStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        [Required(ErrorMessage = "必填")]
        public DateTime UpdateDate { get; set; }
    }
    /// <summary>
    /// 更新事历
    /// </summary>
    public class UpdateProjectModel
    {
        /// <summary>
        /// 事历编号
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 事历标题
        /// </summary>		
        public string ProTitle { get; set; }
        /// <summary>
        /// 事历短标题
        /// </summary>
        [Required(ErrorMessage = "必填")]
        public string ProTitleShort { get; set; }
        /// <summary>
        /// 项目文本内容
        /// </summary>		
        public string ProInfo { get; set; }
        /// <summary>
        /// 重要程度：0、普通，缺省值；1、重要；
        /// </summary>		
        public int ImpropantWeight { get; set; }
        /// <summary>
        /// 紧急程度：0、普通，缺省值；1、紧急；
        /// </summary>		
        public int UrgentWeight { get; set; }
        /// <summary>
        /// 启动日期，默认创建日期为启动日期；预设启动日期，到期后，自动将事务状态设置为“进行中”
        /// </summary>		
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 计划完成日期
        /// </summary>		
        public DateTime ExpectDate { get; set; }
        /// <summary>
        /// 项目状态：0、初始状态，缺省值；1、完成；2、进行中；-1、放弃；
        /// </summary>		
        public int ProStatus { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        public DateTime FinishedDate { get; set; }
        /// <summary>
        /// 进度，输入0-100的整数，以百分比显示
        /// </summary>		
        public int ProgressNum { get; set; }
        /// <summary>
        /// 开放状态：0、隐私；1、开放；2、好友可见
        /// </summary>		
        public int OpenStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
    }
}