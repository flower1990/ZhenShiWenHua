using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Dic
{
    public class DicCreateChildNode
    {
        /// <summary>
        /// 字典项标识
        /// </summary>		
        [Display(Name = "字典标识")]
        [Required(ErrorMessage = "请输入字典标识")]
        public string DicCode { get; set; }
        /// <summary>
        /// 字典项名称
        /// </summary>		
        [Display(Name = "字典名称")]
        [Required(ErrorMessage = "请输入字典名称")]
        public string DicName { get; set; }
        /// <summary>
        /// 字典项英文名
        /// </summary>		
        [Display(Name = "字典英文")]
        public string DicNameEn { get; set; }
        /// <summary>
        /// 字典属性：0、数据属性；1、栏目；
        /// </summary>		
        [Display(Name = "字典属性")]
        public int DicProperty { get; set; }
        /// <summary>
        /// 上级字典ID
        /// </summary>		
        [Display(Name = "上级字典")]
        public int ParentID { get; set; }
        /// <summary>
        /// 排序字段，升序排序
        /// </summary>		
        [Display(Name = "排序编号")]
        public int SortID { get; set; }
        /// <summary>
        /// 说明
        /// </summary>		
        [Display(Name = "字典说明")]
        public string Remark { get; set; }
    }
}