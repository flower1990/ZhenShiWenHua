using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    //Zs_FavoritesInfo
    public class Zs_FavoritesInfo
    {

        /// <summary>
        /// FInfoID
        /// </summary>		
        [Key]
        public long FInfoID { get; set; }
        /// <summary>
        /// 所属会员ID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 收藏文件Url，可以是本地文件，也可以是网页
        /// </summary>		
        public string FavoritesUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateDate { get; set; }

    }
}