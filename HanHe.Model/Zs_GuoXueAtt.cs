using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_GuoXueAtt
    public class Zs_GuoXueAtt
    {

        /// <summary>
        /// AttID
        /// </summary>		
        [Key]
        public long AttID { get; set; }
        /// <summary>
        /// 国学信息ID
        /// </summary>		
        public long GXID { get; set; }
        /// <summary>
        /// 国学信息
        /// </summary>
        public virtual Zs_GuoXue GuoXue { get; set; }
        /// <summary>
        /// 附件类别：1、图片；2、视频；3、音频；4、文档；5、Flash
        /// </summary>		
        public int AttType { get; set; }
        /// <summary>
        /// 附件类别名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string AttTypeName { get; set; }
        /// <summary>
        /// 附件标题
        /// </summary>		
        public string AttTitle { get; set; }
        /// <summary>
        /// 附件Url
        /// </summary>		
        public string AttUrl { get; set; }
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