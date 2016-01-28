using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_ProjectComment
    public class Zs_ProjectComment
    {

        /// <summary>
        /// CommentID
        /// </summary>		
        [Key]
        public long CommentID { get; set; }
        /// <summary>
        /// 事项ID
        /// </summary>		
        public long ProjectID { get; set; }
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
        public DateTime CreateDate { get; set; }

    }
}