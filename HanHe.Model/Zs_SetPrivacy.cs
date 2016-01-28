using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_SetPrivacy
    public class Zs_SetPrivacy
    {
        /// <summary>
        /// PrivacyID
        /// </summary>		
        [Key]
        public long PrivacyID { get; set; }
        /// <summary>
        /// 会员MID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 加好友验证：0、关闭，无需验证，能直接加我为好友；1、开启，需要验证消息决定是否让对方加好友
        /// </summary>		
        public int JoinCheck { get; set; }
        /// <summary>
        /// 想我推荐QQ通讯录上的朋友
        /// </summary>		
        public int RecommendQQ { get; set; }
        /// <summary>
        /// 通过QQ号搜索到我：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int SearchByQQ { get; set; }
        /// <summary>
        /// 通过手机号码搜索到我：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int SearchByMobile { get; set; }
        /// <summary>
        /// 向我推荐通讯录好友：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int RecommendMobile { get; set; }
        /// <summary>
        /// 通过珍视会员号找到我：0、关闭；1、开启，缺省值；
        /// </summary>		
        public int SearchByZsCode { get; set; }
        /// <summary>
        /// 允许陌生人开十张照片：0、关闭，不让陌生人看照片；1、开启，缺省值，让陌生人看最后发布的十张
        /// </summary>		
        public int AllowPic { get; set; }

    }
}