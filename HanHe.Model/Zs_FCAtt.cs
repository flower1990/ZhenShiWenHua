﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_FCAtt
    public class Zs_FCAtt
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
        /// 朋友圈信息ID
        /// </summary>		
        public long FCID { get; set; }
        /// <summary>
        /// 朋友圈信息
        /// </summary>
        public virtual Zs_FCircle FCircle { get; set; }
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
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
}