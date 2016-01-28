using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Member
    public class Zs_Member
    {

        /// <summary>
        /// 会员ID
        /// </summary>		
        [Key]
        public long MID { get; set; }
        /// <summary>
        /// 特征码，可用于该会员加密字段用做密钥
        /// </summary>		
        public Guid MChar { get; set; }
        /// <summary>
        /// 会员标识（编号），可用于登录
        /// </summary>		
        public string MCode { get; set; }
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
        public string Pwd { get; set; }
        /// <summary>
        /// 性别：1、先生；0、女士
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Sex { get; set; }
        /// <summary>
        /// 性别名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string SexName { get; set; }
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
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int CalendarType { get; set; }
        /// <summary>
        /// 生日类别名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CalendarTypeNmae { get; set; }
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
        /// QQOpenID
        /// </summary>
        public string QQOpenID { get; set; }
        /// <summary>
        /// 微信
        /// </summary>		
        public string WeiXin { get; set; }
        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string WeiXinOpenID { get; set; }
        /// <summary>
        /// 新浪
        /// </summary>
        public string Sina { get; set; }
        /// <summary>
        /// 新浪OpenID
        /// </summary>
        public string SinaOpenID { get; set; }
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
        /// 创建时间
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>		
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 状态：0、未激活；1、激活；-1、无效，会员不能登录系统；
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int MStatus { get; set; }
        /// <summary>
        /// 会员状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string MStatusName { get; set; }
        /// <summary>
        /// 激活日期
        /// </summary>		
        public DateTime? ActDate { get; set; }
        /// <summary>
        /// 删除状态：1、有效的，0、已删除
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool DelStatus { get; set; }
        /// <summary>
        /// 删除状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DelStatusName { get; set; }
        /// <summary>
        /// 逻辑删除日期
        /// </summary>		
        public DateTime? DelDate { get; set; }

    }
}