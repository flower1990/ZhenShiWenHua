using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models
{
    public class MemberViewModel
    {
    }
    /// <summary>
    /// 登陆
    /// </summary>
    public class LoginViewModel
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
        /// <summary>
        /// 记住我
        /// </summary>
        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}