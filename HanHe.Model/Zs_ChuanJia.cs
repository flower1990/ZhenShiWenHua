using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_ChuanJia
    public class Zs_ChuanJia
    {
        /// <summary>
        /// CJID
        /// </summary>		
        [Key]
        public long CJID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 传家类别：1.墓志铭2.家训3.遗训4.文化传承；
        /// </summary>		
        public int TypeID { get; set; }
        /// <summary>
        /// 传家标题
        /// </summary>		
        public string CJTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>		
        public string CJTitleShort { get; set; }
        /// <summary>
        /// 传家内容
        /// </summary>		
        public string CJInfo { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>		
        public int OpenStatus { get; set; }
        /// <summary>
        /// 公开状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string OpenStatusName { get; set; }
        /// <summary>
        /// 排序字段：倒序排列
        /// </summary>		
        public int SortID { get; set; }
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
        /// 浏览计数
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞计数
        /// </summary>		
        public int GoodCount { get; set; }
    }
}