using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Right
{
    public class RightCreateChildNode
    {
        /// <summary>
        /// 权限标识
        /// </summary>		
        [Display(Name = "权限标识")]
        [Required(ErrorMessage = "请输入权限标识")]
        public string RightCode { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>		
        [Display(Name = "权限名称")]
        [Required(ErrorMessage = "请输入权限名称")]
        public string RightName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        [Display(Name = "控制器名称")]
        [Required(ErrorMessage = "请输入控制器名称")]
        public string ControllerName { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        [Display(Name = "动作名称")]
        [Required(ErrorMessage = "请输入动作名称")]
        public string ActionName { get; set; }
        /// <summary>
        /// 上级权限ID
        /// </summary>		
        [Display(Name = "上级权限")]
        public int ParentID { get; set; }
        /// <summary>
        /// 排序字段，升序
        /// </summary>		
        [Display(Name = "排序")]
        public int SortID { get; set; }
        /// <summary>
        /// 权限属性：0、模块权限；1、页权限；2、按钮权限；3、数据权限；
        /// </summary>		
        [Display(Name = "权限属性")]
        public int RightProperty { get; set; }
        /// <summary>
        /// 权限用途说明
        /// </summary>	
        [Display(Name = "权限用途说明")]
        public string Remark { get; set; }
    }
}