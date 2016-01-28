using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Model
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Zs_Product
    {
        /// <summary>
        /// ProID
        /// </summary>		
        [Key]
        public long ProID { get; set; }
        /// <summary>
        /// MID
        /// </summary>		
        public long MID { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>		
        public string Keywords { get; set; }
        /// <summary>
        /// 商品编号：条码
        /// </summary>		
        public string ProCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>		
        public string ProName { get; set; }
        /// <summary>
        /// 商品类别：0、虚拟礼品；1、商品；
        /// </summary>		
        public int ProProperty { get; set; }
        /// <summary>
        /// 商品属性名称
        /// </summary>		
        public string ProPropertyName { get; set; }
        /// <summary>
        /// 分类一
        /// </summary>		
        public int Category01 { get; set; }
        /// <summary>
        /// 分类二
        /// </summary>		
        public int Category02 { get; set; }
        /// <summary>
        /// 分类三
        /// </summary>		
        public int Category03 { get; set; }
        /// <summary>
        /// 单位：来源于数据字典
        /// </summary>		
        public int UnitID { get; set; }
        /// <summary>
        /// 商品状态：0、未发布；1、已发布；-1、无效
        /// </summary>		
        public int ProStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>		
        public string ProStatusName { get; set; }
        /// <summary>
        /// 商品说明
        /// </summary>		
        public string ProDesc { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 浏览统计
        /// </summary>		
        public int ViewCount { get; set; }
        /// <summary>
        /// 收藏统计
        /// </summary>		
        public int FavoriteCount { get; set; }
        /// <summary>
        /// 销售统计
        /// </summary>		
        public int SalesCount { get; set; }
        /// <summary>
        /// 退货统计
        /// </summary>		
        public int CancelCount { get; set; }

    }
}