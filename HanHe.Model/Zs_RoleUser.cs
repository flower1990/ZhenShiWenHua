using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_RoleUser
    public class Zs_RoleUser
    {
        /// <summary>
        /// RUserID
        /// </summary>		
        [Key]
        public int RUserID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>		
        public int RoleID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int ZsUserID { get; set; }

    }
}