using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class Zs_RoleRight
    {
        /// <summary>
        /// 角色权限编号
        /// </summary>
        [Key]
        public int RRightID { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 权限编号
        /// </summary>
        public int RightID { get; set; }
    }
}
