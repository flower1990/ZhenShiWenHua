using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Web.Models
{
    public class GetGanWuAllModel
    {
        public long GwID { get; set; }
        public string GwTitle { get; set; }
        public string GwTitleShort { get; set; }
        public string AttUrl { get; set; }
    }
    /// <summary>
    /// 感悟未来
    /// </summary>
    public class GanWuViewModel
    {
        public Zs_GanWu GanWu { get; set; }
        public List<Zs_GanWuAtt> GanWuAtt { get; set; }
    }
    /// <summary>
    /// 添加感悟未来
    /// </summary>
    public class AddGanWuModel
    {
        /// <summary>
        /// 会员编号
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 感悟标题
        /// </summary>
        public string GwTitle { get; set; }
        /// <summary>
        /// 感悟短标题
        /// </summary>
        public string GwTitleShort { get; set; }
        /// <summary>
        /// 感悟内容
        /// </summary>
        public string GwInfo { get; set; }
        /// <summary>
        /// 感悟类别：1、感悟；2、梦想心愿；3、大事；4、未来的信；5、杂谈；
        /// </summary>
        public int GwType { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>
        public int OpenStatus { get; set; }
        /// <summary>
        /// 未来日期：未来的信寄达日期，梦想心愿的实现日期
        /// </summary>
        public DateTime GotoDate { get; set; }
        /// <summary>
        /// 寄送日期
        /// </summary>
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 状态：0、初始；1、提交；2、送达；
        /// </summary>
        public int GwStatus { get; set; }
        /// <summary>
        /// 短信提醒状态：0、不发短信；1、发送短信，缺省值；
        /// </summary>
        public int SmsStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
    }
    /// <summary>
    /// 更新感悟未来
    /// </summary>
    public class UpdateGanWuModel
    {
        /// <summary>
        /// 感悟编号
        /// </summary>
        public int GwID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 感悟标题
        /// </summary>
        public string GwTitle { get; set; }
        /// <summary>
        /// 感悟短标题
        /// </summary>
        public string GwTitleShort { get; set; }
        /// <summary>
        /// 感悟内容
        /// </summary>
        public string GwInfo { get; set; }
        /// <summary>
        /// 感悟类别：1、感悟；2、梦想心愿；3、大事；4、未来的信；5、杂谈；
        /// </summary>
        public int GwType { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>
        public int OpenStatus { get; set; }
        /// <summary>
        /// 未来日期：未来的信寄达日期，梦想心愿的实现日期
        /// </summary>
        public DateTime GotoDate { get; set; }
        /// <summary>
        /// 寄送日期
        /// </summary>
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 状态：0、初始；1、提交；2、送达；
        /// </summary>
        public int GwStatus { get; set; }
        /// <summary>
        /// 短信提醒状态：0、不发短信；1、发送短信，缺省值；
        /// </summary>
        public int SmsStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
    }
}