using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_NewFriend
    public class Zs_NewFriend
    {

        /// <summary>
        /// NFID
        /// </summary>		
        [Key]
        public long NFID { get; set; }
        /// <summary>
        /// 接受会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 请求会员ID
        /// </summary>		
        public long FMID { get; set; }
        /// <summary>
        /// 好友来源，预留字段
        /// </summary>		
        public int SourceID { get; set; }
        /// <summary>
        /// 状态：0、未接受，缺省值；1、已接受；-1、拒绝；
        /// </summary>		
        public int NFStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>		
        public string NFStatusName { get; set; }
        /// <summary>
        /// 拒绝原因
        /// </summary>		
        public string RefuseReason { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}