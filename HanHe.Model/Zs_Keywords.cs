using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Keywords
    public class Zs_Keywords
    {

        /// <summary>
        /// KwID
        /// </summary>		
        [Key]
        public int KwID { get; set; }
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
        /// <summary>
        /// 状态名称
        /// </summary>		
        public string KwStatusName { get; set; }

    }
}