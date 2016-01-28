using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Web.Models
{
    /// <summary>
    /// 添加事历附件
    /// </summary>
    public class ProjectAttModel
    {
        /// <summary>
        /// 附件编号（更新附件必填）
        /// </summary>
        public int AttID { get; set; }
        /// <summary>
        /// 会员编号（添加附件必填）
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 事历编号
        /// </summary>
        public int ProjectID { get; set; }
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
        /// 附件类型
        /// </summary>
        public int AttType { get; set; }
    }
}