using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_User
    public class Zs_User
    {
        /// <summary>
        /// ZsUserID
        /// </summary>		
        [Key]
        public int ZsUserID { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>		
        public string UserNameCn { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>		
        public string UserNameEn { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>		
        public string LoginName { get; set; }
        /// <summary>
        /// 密码：加密的字符串
        /// </summary>		
        public string Pwd { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>		
        public int RoleID { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>		
        public string Mobile { get; set; }
        /// <summary>
        /// 电子邮箱
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
        /// 用户特征码，用于加密密码的密钥
        /// </summary>		
        public Guid UserChar { get; set; }
        /// <summary>
        /// 用户状态：0、无效，不能登录系统；1、有效；
        /// </summary>		
        public int UserStatus { get; set; }
        /// <summary>
        /// UserStatusName
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string UserStatusName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
}