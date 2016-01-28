using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.GuoXue
{
    public class GuoXueEdit
    {
        /// <summary>
        /// GxID
        /// </summary>		
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
        /// 修改日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 状态：0、未发布；1、已发布；
        /// </summary>		
        public int GxStatus { get; set; }
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