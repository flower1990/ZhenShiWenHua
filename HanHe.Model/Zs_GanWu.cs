using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_GanWu
    public class Zs_GanWu
    {

        /// <summary>
        /// GwID
        /// </summary>		
        [Key]
        public long GwID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 感悟标题
        /// </summary>		
        public string GwTitle { get; set; }
        /// <summary>
        /// 感悟短标题
        /// </summary>		
        public string GwTitleShort { get; set; }
        /// <summary>
        /// 感悟内容
        /// </summary>		
        public string GwInfo { get; set; }
        /// <summary>
        /// 感悟类别：1、感悟；2、梦想心愿；3、大事；4、未来的信；5、杂谈；
        /// </summary>		
        public int GwType { get; set; }
        /// <summary>
        /// 感悟类别名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string GwTypeName { get; set; }
        /// <summary>
        /// 公开状态：0、私隐；1、公开；2、好友可见
        /// </summary>		
        public int OpenStatus { get; set; }
        /// <summary>
        /// 公开状态名称
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string OpenStatusName { get; set; }
        /// <summary>
        /// 未来日期：未来的信寄达日期，梦想心愿的实现日期
        /// </summary>		
        public DateTime GotoDate { get; set; }
        /// <summary>
        /// 寄送日期
        /// </summary>		
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 状态：0、初始；1、提交；2、送达；
        /// </summary>		
        public int GwStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string GwStatusName { get; set; }
        /// <summary>
        /// 短信提醒状态：0、不发短信；1、发送短信，缺省值；
        /// </summary>		
        public int SmsStatus { get; set; }
        /// <summary>
        /// 短信提醒状态名称
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string SmsStatusName { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// ViewCount
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// GoodCount
        /// </summary>		
        public int GoodCount { get; set; }

    }
}