using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Dic
{
    public class DicTreeList
    {
        /// <summary>
        /// DicID
        /// </summary>		
        public int DicID { get; set; }
        /// <summary>
        /// 字典项标识
        /// </summary>		
        public string DicCode { get; set; }
        /// <summary>
        /// 字典项名称
        /// </summary>		
        public string DicName { get; set; }
        /// <summary>
        /// 字典项英文名
        /// </summary>		
        public string DicNameEn { get; set; }
        /// <summary>
        /// 字典属性：0、数据属性；1、栏目；
        /// </summary>		
        public int DicProperty { get; set; }
        /// <summary>
        /// 上级字典ID
        /// </summary>		
        public int ParentID { get; set; }
        /// <summary>
        /// 排序字段，升序排序
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 说明
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 加载
        /// </summary>
        public bool loaded { get; set; }
        /// <summary>
        /// 父
        /// </summary>
        public int parent { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 叶
        /// </summary>
        public bool isLeaf { get; set; }
        /// <summary>
        /// 展开
        /// </summary>
        public bool expanded { get; set; }
    }
}