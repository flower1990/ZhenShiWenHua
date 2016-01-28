using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_FCircle
    public class Zs_FCircle
    {

        /// <summary>
        /// FCID
        /// </summary>		
        [Key]
        public long FCID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>		
        public string FCTitle { get; set; }
        /// <summary>
        /// 分享原创文本内容
        /// </summary>		
        public string FCInfo { get; set; }
        /// <summary>
        /// 分享的链接
        /// </summary>		
        public string FCUrl { get; set; }
        /// <summary>
        /// 浏览量统计
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞统计
        /// </summary>		
        public int GoodCount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}