using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_ProjectClock
    public class Zs_ProjectClock
    {

        /// <summary>
        /// ClockID
        /// </summary>		
        [Key]
        public long ClockID { get; set; }
        /// <summary>
        /// 事项ID
        /// </summary>		
        public long ProjectID { get; set; }
        /// <summary>
        /// 提醒名称
        /// </summary>		
        public string ClockName { get; set; }
        /// <summary>
        /// 提醒时间
        /// </summary>		
        public DateTime ClockTime { get; set; }
        /// <summary>
        /// 播放音乐Url，若找不到，则启用客户端手机默认提醒方式
        /// </summary>		
        public string MusicUrl { get; set; }
        /// <summary>
        /// 短信状态：0、不发短信，缺省值；1、短信提醒，届时服务器将通过短信接口，向客户注册手机发送短消息，内容为提醒标题
        /// </summary>		
        public int SmsStatus { get; set; }
        /// <summary>
        /// SmsStatusName
        /// </summary>	
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string SmsStatusName { get; set; }

    }
}