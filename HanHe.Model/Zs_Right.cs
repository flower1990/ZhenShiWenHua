using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Right
    public class Zs_Right
    {

        /// <summary>
        /// RightID
        /// </summary>		
        [Key]
        public int RightID { get; set; }
        /// <summary>
        /// 权限标识
        /// </summary>		
        public string RightCode { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>		
        public string RightName { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 上级权限ID
        /// </summary>		
        public int ParentID { get; set; }
        /// <summary>
        /// 排序字段，升序
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 权限属性：0、模块权限；1、页权限；2、按钮权限；3、数据权限；
        /// </summary>		
        public int RightProperty { get; set; }
        /// <summary>
        /// RightPropertyName
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string RightPropertyName { get; set; }
        /// <summary>
        /// 权限用途说明
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
}