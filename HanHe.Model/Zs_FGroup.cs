using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_FGroup
    public class Zs_FGroup
    {

        /// <summary>
        /// FGroupID
        /// </summary>		
        [Key]
        public long FGroupID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>		
        public string GroupName { get; set; }
        /// <summary>
        /// 排序，升序排列
        /// </summary>		
        public int SortID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}