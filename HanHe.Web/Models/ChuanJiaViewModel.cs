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
    public class ChuanJiaViewModel1
    {
        public ChuanJia ChuanJia { get; set; }
        public List<ChuanJiaAtt> ChuanJiaAtt { get; set; }
    }
    public class GetChuanJiaAllModel
    {
        public long CJID { get; set; }
        public string CJTitle { get; set; }
        public string CJTitleShort { get; set; }
        public string AttUrl { get; set; }
    }
    public class ChuanJia
    {
        /// <summary>
        /// CJID
        /// </summary>		
        public long CJID { get; set; }
        /// <summary>
        /// 会员ID
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
        /// 公开状态名称
        /// </summary>		
        public string OpenStatusName { get; set; }
        /// <summary>
        /// 排序字段：倒序排列
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 浏览计数
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞计数
        /// </summary>		
        public int GoodCount { get; set; }
    }
    public class ChuanJiaAtt
    {
        /// <summary>
        /// AttID
        /// </summary>		
        public long AttID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 传家ID
        /// </summary>
        public long CJID { get; set; }
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
        /// 附件类别1.图片2.视频3.音频4.文档
        /// </summary>		
        public int AttType { get; set; }
        /// <summary>
        /// 附件类别名称
        /// </summary>		
        public string AttTypeName { get; set; }
        /// <summary>
        /// 排序字段，升序
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }
    }
}