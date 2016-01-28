using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_ProductAtt
    public class Zs_ProductAtt
    {

        /// <summary>
        /// AttID
        /// </summary>		
        [Key]
        public long AttID { get; set; }
        /// <summary>
        /// 朋友圈信息ID
        /// </summary>		
        public long ProID { get; set; }
        /// <summary>
        /// 附件类别：1、图片；2、视频；3、音频；4、文档；5、Flash
        /// </summary>		
        public int AttType { get; set; }
        /// <summary>
        /// 附件类别名称
        /// </summary>		
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
        public DateTime CreateDate { get; set; }

    }
}