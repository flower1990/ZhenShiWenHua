using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_GuoXue
    public class Zs_GuoXue
    {

        /// <summary>
        /// GxID
        /// </summary>		
        [Key]
        public long GxID { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>		
        public string Keywords { get; set; }
        /// <summary>
        /// 标题
        /// </summary>		
        public string GxTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>		
        public string GxTitleShort { get; set; }
        /// <summary>
        /// 内容
        /// </summary>		
        public string GxInfo { get; set; }
        /// <summary>
        /// 类别一
        /// </summary>		
        public int Category01 { get; set; }
        /// <summary>
        /// 类别二
        /// </summary>		
        public int Category02 { get; set; }
        /// <summary>
        /// 类别三
        /// </summary>		
        public int Category03 { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 状态：0、未发布；1、已发布；
        /// </summary>		
        public int GxStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string GxStatusName { get; set; }
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