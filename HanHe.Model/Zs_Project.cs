using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    /// <summary>
    /// 行事历
    /// </summary>
    public class Zs_Project
    {
        /// <summary>
        /// ProjectID
        /// </summary>		
        [Key]
        public long ProjectID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>		
        public string ProTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>
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
        /// 排序字段，倒序
        /// </summary>		
        public int SortID { get; set; }
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
        /// 项目状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ProStatusName { get; set; }
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
        /// OpenStatusName
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        /// </summary>		
        public string OpenStatusName { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// ViewCount
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// GoodCount
        /// </summary>		
        public int GoodCount { get; set; }

    }
}