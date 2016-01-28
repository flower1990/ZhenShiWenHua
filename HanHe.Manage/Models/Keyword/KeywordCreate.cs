using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Keyword
{
    public class KeywordCreate
    {
        /// <summary>
        /// 关键词
        /// </summary>		
        public string ZsKeyWords { get; set; }
        /// <summary>
        /// 权重：预留字段
        /// </summary>		
        public int WeightNum { get; set; }
        /// <summary>
        /// 状态：0、失效，不再过滤该关键词；1、有效，互动信息上要求过滤
        /// </summary>		
        public int KwStatus { get; set; }
    }
}