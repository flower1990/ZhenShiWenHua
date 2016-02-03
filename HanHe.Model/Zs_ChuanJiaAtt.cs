using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_ChuanJiaAtt
    public class Zs_ChuanJiaAtt
    {
        /// <summary>
        /// AttID
        /// </summary>		
        [Key]
        public long AttID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 传家ID
        /// </summary>
        public long CJID { get; set; }
        /// <summary>
        /// 传家信息
        /// </summary>
        public virtual Zs_ChuanJia ChuanJia { get; set; }
        /// <summary>
        /// 附件标题
        /// </summary>		
        public string AttTitle { get; set; }
        /// <summary>
        /// 附件说明
        /// </summary>		
        public string AttInfo { get; set; }
        /// <summary>
        /// 附件Url
        /// </summary>		
        public string AttUrl { get; set; }
        /// <summary>
        /// 附件类别1.图片2.视频3.音频4.文档
        /// </summary>		
        public int AttType { get; set; }
        /// <summary>
        /// 附件类别名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AttTypeName { get; set; }
        /// <summary>
        /// 排序字段，升序
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
}