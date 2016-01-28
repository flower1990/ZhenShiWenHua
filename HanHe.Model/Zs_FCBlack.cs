using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_FCBlack
    public class Zs_FCBlack
    {

        /// <summary>
        /// FCBlackID
        /// </summary>		
        [Key]
        public long FCBlackID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 黑名单会员ID
        /// </summary>		
        public long BMID { get; set; }
        /// <summary>
        /// 黑名单属性
        /// </summary>		
        public int BlackProperty { get; set; }
        /// <summary>
        /// BlackPropertyName
        /// </summary>		
        public string BlackPropertyName { get; set; }

    }
}