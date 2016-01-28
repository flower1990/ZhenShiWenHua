using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Member
{
    /// <summary>
    /// 会员添加
    /// </summary>
    public class MemberCreate
    {
        /// <summary>
        /// 姓名
        /// </summary>		
        public string MName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>		
        public string NickName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>	
        [Required(ErrorMessage = "必填")]
        public string Pwd { get; set; }
        /// <summary>
        /// 性别：1、先生；0、女士
        /// </summary>		
        public int Sex { get; set; }
        /// <summary>
        /// 证件类别，来源于数据字典
        /// </summary>		
        public int IDType { get; set; }
        /// <summary>
        /// 证件编号
        /// </summary>		
        public string IDCode { get; set; }
        /// <summary>
        /// 阴历生日
        /// </summary>		
        public DateTime? BirthdayCn { get; set; }
        /// <summary>
        /// 阳历生日，计算生命倒计时用
        /// </summary>		
        public DateTime? BirthdayEn { get; set; }
        /// <summary>
        /// 生日类别：1、阴历；2、阳历；
        /// </summary>		
        public int CalendarType { get; set; }
        /// <summary>
        /// 预期寿命，默认值100
        /// </summary>		
        public int MyLife { get; set; }
        /// <summary>
        /// 手机
        /// </summary>		
        public string Mobile { get; set; }
        /// <summary>
        /// Email
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// QQ
        /// </summary>		
        public string QQ { get; set; }
        /// <summary>
        /// 微信
        /// </summary>		
        public string WeiXin { get; set; }
        /// <summary>
        /// 新浪
        /// </summary>
        public string Sina { get; set; }
        /// <summary>
        /// 地址
        /// </summary>		
        public string Address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>		
        public string PostCode { get; set; }
        /// <summary>
        /// 国家ID，来源于数据字典
        /// </summary>		
        public int CountryID { get; set; }
        /// <summary>
        /// 省份ID，来源于数据字典
        /// </summary>		
        public int ProvinceID { get; set; }
        /// <summary>
        /// 城市ID，来源于数据字典
        /// </summary>		
        public int CityID { get; set; }
        /// <summary>
        /// 区/县ID，来源于数据字典
        /// </summary>		
        public int AreaID { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>		
        public string IconUrl { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>		
        public string MySign { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 状态：0、未激活；1、激活；-1、无效，会员不能登录系统；
        /// </summary>		
        public int MStatus { get; set; }
    }
}