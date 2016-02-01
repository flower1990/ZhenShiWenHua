using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Util;
using HanHe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 国学
    /// </summary>
    [RoutePrefix("api/ChuanJia")]
    public class GuoXueController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_GuoXue bGuoXue = new BZs_GuoXue();
        IZs_GuoXueAtt bGuoXueAtt = new BZs_GuoXueAtt();
        IZs_Dic bDic = new BZs_Dic();

        /// <summary>
        /// 获取附件图片
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        private string GetAttUrl(ICollection<Zs_GuoXueAtt> att)
        {
            if (att.Count == 0) return "";
            return att.Where(f => f.AttType == 1).FirstOrDefault().AttUrl;
        }
        /// <summary>
        /// 根据字典编码获取知识库列表
        /// </summary>
        /// <param name="code">字典编码</param>
        /// <returns>知识库列表</returns>
        [HttpGet, Route("GetByCode")]
        public IHttpActionResult GetGuoXueByCode([FromUri]string code)
        {
            var guoxue = bDic
                .Find(f => f.DicCode == code)
                .GuoXue.Select(f => new
                {
                    GxID = f.GxID,
                    GxTitleShort = f.GxTitleShort,
                    Url = GetAttUrl(f.GuoXueAtt),
                });

            return Ok(guoxue);
        }
        /// <summary>
        /// 阴阳历转换
        /// </summary>
        /// <param name="datetime">日期</param>
        /// <returns>农历日期</returns>
        [HttpGet, Route("GetLunarHolDay")]
        public IHttpActionResult GetLunarHolDay([FromUri]string datetime)
        {
            DateTime dt;
            var dic = new Dictionary<string, string>();
            var result = DateTime.TryParse(datetime, out dt);

            if (!result)
            {
                dic.Add("result", string.Format("日期 {0} 无效", datetime));
                return Ok(dic);
            }

            CNDate cdnDate = new CNDate(dt);
            dic.Add("result", cdnDate.GetLunarHolDay());

            return Ok(dic);
        }
    }
}
