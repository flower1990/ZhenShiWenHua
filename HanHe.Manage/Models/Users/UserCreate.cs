using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Users
{
    public class UserCreate
    {
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
        /// 用户状态：0、无效，不能登录系统；1、有效；
        /// </summary>		
        public int UserStatus { get; set; }
    }
}