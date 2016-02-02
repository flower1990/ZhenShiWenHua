using HanHe.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Web.Models
{
    /// <summary>
    /// 完善资料
    /// </summary>
    public class UpdateMemberModel
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public long MID { get; set; }
        /// <summary>
        /// 真实姓名，2-50位中英文字符，不含特殊字符
        /// </summary>
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{2}-{1}位字符")]
        [RegularExpression(RegxUtil.Regx3, ErrorMessage = "请输入中英文字符，不含特殊字符")]
        public string MName { get; set; }
        /// <summary>
        /// 昵称，2-18位中英文、数字、下划线
        /// </summary>
        [StringLength(18, MinimumLength = 2, ErrorMessage = "{2}-{1}位字符")]
        [RegularExpression(RegxUtil.Regx4, ErrorMessage = "请输入中英文、数字、下划线的字符")]
        public string NickName { get; set; }
        /// <summary>
        /// 性别：1、先生；0、女士
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 隐私是否公开，例0-仅限自己，1-公开
        /// </summary>
        public int Privacy { get; set; }
        /// <summary>
        /// 职业，例0-雇员，1-自由职业，2-企业主，3-投资人
        /// </summary>
        public int Career { get; set; }
        /// <summary>
        /// 城市，国别-省份-城市-县区
        /// </summary>
        public int City { get; set; }
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
        [RegularExpression(RegxUtil.Regx6, ErrorMessage = "邮箱格式不正确")]
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
        /// 地址
        /// </summary>		
        [StringLength(50, ErrorMessage = "不能超过{0}个字符")]
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
    }
    /// <summary>
    /// 登陆
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}长度{2}-{1}个字符")]
        [Display(Name = "账号")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0}长度{2}-{1}个字符")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    /// <summary>
    /// 手机注册
    /// </summary>
    public class RegisterMobileModel
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{1}位用户手机号")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "手机号")]
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{2}-{1}位数字或英文字符")]
        [Display(Name = "密码")]
        public string Pwd { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Compare("Pwd", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "确认密码")]
        public string PwdRepeat { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(18, MinimumLength = 2, ErrorMessage = "{2}-{1}位中英文，数字，下划线")]
        [Display(Name = "昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "{1}位数字")]
        [Display(Name = "验证码")]
        public string TestNumber { get; set; }
    }
    /// <summary>
    /// 邮箱注册
    /// </summary>
    public class RegisterEmailModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email格式不正确")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{2}-{1}位数字或英文字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "确认密码")]
        public string PasswordRepeat { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(18, MinimumLength = 2, ErrorMessage = "{2}-{1}位中英文，数字，下划线")]
        [Display(Name = "昵称")]
        public string UserName { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "{1}位数字")]
        [Display(Name = "验证码")]
        public string TestNumber { get; set; }
    }
    /// <summary>
    /// QQ注册
    /// </summary>
    public class LoginByQQModel
    {
        /// <summary>
        /// QQOpenID
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "QQOpenID")]
        public string QQOpenID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>		
        [Display(Name = "昵称")]
        public string NickName { get; set; }
    }
    /// <summary>
    /// 微信登录
    /// </summary>
    public class LoginByWeiXinModel
    {
        /// <summary>
        /// WeiXinOpenID
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "WeiXinOpenID")]
        public string WeiXinOpenID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>		
        [Display(Name = "昵称")]
        public string NickName { get; set; }
    }
    /// <summary>
    /// 新浪登录
    /// </summary>
    public class LoginBySinaModel
    {
        /// <summary>
        /// SinaOpenID
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "SinaOpenID")]
        public string SinaOpenID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>		
        [Display(Name = "昵称")]
        public string NickName { get; set; }
    }
}