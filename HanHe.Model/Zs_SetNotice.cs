using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_SetNotice
    public class Zs_SetNotice
    {

        /// <summary>
        /// NMNoticeID
        /// </summary>		
        [Key]
        public long NMNoticeID { get; set; }
        /// <summary>
        /// MID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 通知消息详情：1、开启，缺省值；0、关闭，关闭后，当受到消息时，通知提示将不显示发信人和内容摘要
        /// </summary>		
        public int MsgDetail { get; set; }
        /// <summary>
        /// MsgDetailName
        /// </summary>		
        public string MsgDetailName { get; set; }
        /// <summary>
        /// 免打搅：0、关闭，系统接收信息将以铃音，震动方式提醒；1、开启，系统接收信息后不做提示；2、夜间开启，缺省值，在22：00后，早上8点前不提醒
        /// </summary>		
        public int DisturbStatus { get; set; }
        /// <summary>
        /// DisturbStatusName
        /// </summary>		
        public string DisturbStatusName { get; set; }
        /// <summary>
        /// 声音提示状态i：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int VoiceStatus { get; set; }
        /// <summary>
        /// VoiceStatusName
        /// </summary>		
        public string VoiceStatusName { get; set; }
        /// <summary>
        /// 震动开启状态：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int ShakeStatus { get; set; }
        /// <summary>
        /// ShakeStatusName
        /// </summary>		
        public string ShakeStatusName { get; set; }
        /// <summary>
        /// 朋友圈更新状态：0、关闭，当朋友圈有更新时，不在朋友圈上显示红点；1、开启，缺省值；
        /// </summary>		
        public int FCNewStatus { get; set; }
        /// <summary>
        /// FCNewStatusName
        /// </summary>		
        public string FCNewStatusName { get; set; }

    }
}