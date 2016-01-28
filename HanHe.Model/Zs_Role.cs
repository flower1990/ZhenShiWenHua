using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Role
    public class Zs_Role
    {

        /// <summary>
        /// RoleID
        /// </summary>		
        [Key]
        public int RoleID { get; set; }
        /// <summary>
        /// 角色标识，和角色唯一标识，方便程序获取角色。
        /// </summary>		
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>		
        public string RoleName { get; set; }
        /// <summary>
        /// 系统显示角色的顺序，升序排列
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 角色属性：0、普通，1、管理员组，2、信息管理组，3、财务管理
        /// </summary>		
        public int RoleProperty { get; set; }
        /// <summary>
        /// RolePropertyName
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string RolePropertyName { get; set; }
        /// <summary>
        /// 角色的备注说明
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}