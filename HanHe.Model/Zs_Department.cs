using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Department
    public class Zs_Department
    {

        /// <summary>
        /// DepID
        /// </summary>		
        [Key]
        public int DepID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string DepName { get; set; }
        /// <summary>
        /// 上级部门ID
        /// </summary>		
        public int ParentID { get; set; }
        /// <summary>
        /// 部门排序，升序排列
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 部门管理员ID
        /// </summary>		
        public int ManagerID { get; set; }
        /// <summary>
        /// 部门功能描述
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}