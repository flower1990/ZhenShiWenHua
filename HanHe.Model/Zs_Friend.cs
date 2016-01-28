using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_Friend
    public class Zs_Friend
    {

        /// <summary>
        /// FriendID
        /// </summary>		
        [Key]
        public long FriendID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 会员分组ID
        /// </summary>		
        public long FGroupID { get; set; }
        /// <summary>
        /// 好友会员编号
        /// </summary>		
        public long FMID { get; set; }
        /// <summary>
        /// 备注名
        /// </summary>		
        public string RmarkName { get; set; }
        /// <summary>
        /// 亲密度
        /// </summary>		
        public int QmWeight { get; set; }
        /// <summary>
        /// 成为好友的日期
        /// </summary>		
        public DateTime JoinDate { get; set; }
        /// <summary>
        /// 好友状态：1、有效；0、初始状态；-1、黑名单，加入黑名单后，双方互不接收信息；
        /// </summary>		
        public int FStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>		
        public string FStatusName { get; set; }

    }
}