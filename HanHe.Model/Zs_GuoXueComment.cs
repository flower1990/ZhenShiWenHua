﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_GuoXueComment
    public class Zs_GuoXueComment
    {

        /// <summary>
        /// CommentID
        /// </summary>		
        [Key]
        public long CommentID { get; set; }
        /// <summary>
        /// 国学信息ID
        /// </summary>		
        public long GXID { get; set; }
        /// <summary>
        /// 评论会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 回复对象会员ID
        /// </summary>		
        public long RMID { get; set; }
        /// <summary>
        /// 评论类别：1、点赞；2、评论；
        /// </summary>		
        public int CType { get; set; }
        /// <summary>
        /// CTypeName
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CTypeName { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>		
        public string CInfo { get; set; }
        /// <summary>
        /// 评论日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
}