using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Dic
    public class Zs_Dic
    {

        /// <summary>
        /// DicID
        /// </summary>		
        [Key]
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
        /// 字典属性名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DicPropertyName { get; set; }
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
        /// 创建日期
        /// </summary>	
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 左节点
        /// </summary>
        public int lft { get; set; }
        /// <summary>
        /// 右节点
        /// </summary>
        public int rgt { get; set; }
        /// <summary>
        /// 国学集合
        /// </summary>
        public virtual ICollection<Zs_GuoXue> GuoXue { get; set; }

    }
}