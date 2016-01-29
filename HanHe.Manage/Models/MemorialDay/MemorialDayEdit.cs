using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.MemorialDay
{
    public class MemorialDayEdit
    {
        /// <summary>
        /// MDayID
        /// </summary>		
        public long MDayID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 纪念对象的会员ID
        /// </summary>		
        public long FMID { get; set; }
        /// <summary>
        /// 纪念对象姓名
        [Display(Name = "纪念对象姓名")]
        /// </summary>		
        public string FName { get; set; }
        /// <summary>
        /// 纪念日标题
        /// </summary>		
        [Display(Name = "纪念日标题")]
        public string MDayTitle { get; set; }
        /// <summary>
        /// 纪念日
        /// </summary>		
        [Display(Name = "纪念日")]
        public DateTime MDate { get; set; }
        /// <summary>
        /// 日历类别：1、阴历；2、阳历
        /// </summary>		
        [Display(Name = "日历类别")]
        public int CalendarType { get; set; }
        /// <summary>
        /// 阳历纪念日：纪念日是阴历，服务端转换成阳历；纪念日是阳历，则MDate=MDateEn
        /// </summary>		
        [Display(Name = "阳历纪念日")]
        public DateTime MDateEn { get; set; }
        /// <summary>
        /// 提前几天提醒我自己
        /// </summary>		
        [Display(Name = "提前几天提醒我自己")]
        public int AdvanceDay { get; set; }
        /// <summary>
        /// 提前提醒日期
        /// </summary>		
        [Display(Name = "提前提醒日期")]
        public DateTime RouseDate { get; set; }
        /// <summary>
        /// 是否短信提醒：1、短信提醒，服务端通过短信接口向会员基本信息上的手机发送一条短信，短信内容为纪念日标题和日期；0、非短信提醒；
        /// </summary>		
        [Display(Name = "是否短信提醒")]
        public int RouseSms { get; set; }
        /// <summary>
        /// 播放音乐：如果在用户手机上没有找到媒体文件，则播放手机系统默认提示铃音
        /// </summary>		
        [Display(Name = "播放音乐")]
        public string RouseMusic { get; set; }
        /// <summary>
        /// 祝福语
        /// </summary>		
        [Display(Name = "祝福语")]
        public string MDayMsg { get; set; }
    }
}