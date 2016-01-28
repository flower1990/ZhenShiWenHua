using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HanHe.Model;

namespace HanHe.Web.Models
{
    /// <summary>
    /// 传家有道
    /// </summary>
    public class AddChuanJiaModel
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 传家类别：1.墓志铭2.家训3.遗训4.文化传承；
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 传家标题
        /// </summary>
        public string CJTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>
        public string CJTitleShort { get; set; }
        /// <summary>
        /// 传家内容
        /// </summary>
        public string CJInfo { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>
        public int OpenStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
    }
    /// <summary>
    /// 传家有道
    /// </summary>
    public class UpdateChuanJiaModel
    {
        /// <summary>
        /// 传家有道编号
        /// </summary>
        public long CJID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 传家类别：1.墓志铭2.家训3.遗训4.文化传承；
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 传家标题
        /// </summary>
        public string CJTitle { get; set; }
        /// <summary>
        /// 短标题
        /// </summary>
        public string CJTitleShort { get; set; }
        /// <summary>
        /// 传家内容
        /// </summary>
        public string CJInfo { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>
        public int OpenStatus { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
    }
    public class ChuanJiaViewModel
    {
        public Zs_ChuanJia ChuanJia { get; set; }
        public List<Zs_ChuanJiaAtt> ChuanJiaAtt { get; set; }
    }
    public class GetChuanJiaAllModel
    {
        public long CJID { get; set; }
        public string CJTitle { get; set; }
        public string CJTitleShort { get; set; }
        public string AttUrl { get; set; }
    }
}