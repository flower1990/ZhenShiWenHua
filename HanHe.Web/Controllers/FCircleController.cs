using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
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
    /// 朋友圈
    /// </summary>
    [RoutePrefix("api/FCircle")]
    public class FCircleController : ApiController
    {
        IZs_FCircle bFCircle = new BZs_FCircle();
        IZs_FCAtt bFCAtt = new BZs_FCAtt();

        /// <summary>
        /// 更新附件列表
        /// </summary>
        /// <param name="fcircle">传家信息</param>
        private object UpdateAttList(Zs_FCircle fcircle)
        {
            var result = new FCircleViewModel();

            //实体列表
            var fcAttList = bFCAtt.Entities.Where(f => f.CreateDate < fcircle.UpdateDate && f.FCID == 0);
            //遍历删除本地资源
            foreach (var item in fcAttList) SysFun.Instance.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (fcAttList.Count() > 0) bFCAtt.Delete(fcAttList);
            //批量更新
            bFCAtt.Update(f => f.MID == fcircle.MID, f => new Zs_FCAtt { FCID = fcircle.FCID });
            //实体列表
            fcAttList = bFCAtt.Entities.Where(f => f.MID == fcircle.MID);

            result.FCircle = fcircle;
            result.FCAtt = fcAttList.ToList();

            return result;
        }
        /// <summary>
        /// 添加朋友圈
        /// </summary>
        /// <param name="model">朋友圈信息</param>
        /// <returns>朋友圈信息和附件列表</returns>
        [HttpPost, Route("Add")]
        public IHttpActionResult FCircleCreate(FCircleCreate model)
        {
            var fcircle = new Zs_FCircle();

            //初始化实体
            fcircle = SysFun.Instance.InitialEntity<FCircleCreate, Zs_FCircle>(model, fcircle);
            //添加传家有道
            fcircle = bFCircle.Add(fcircle);
            //更新附件列表
            var result = UpdateAttList(fcircle);

            if (fcircle.FCID > 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("添加失败");
            }
        }
        /// <summary>
        /// 获取传家有道列表
        /// </summary>
        /// <param name="mid">会员编号</param>
        /// <returns>传家有道信息和附件列表</returns>
        [HttpGet, Route("GetByMID")]
        public IHttpActionResult GetFCircleAll([FromUri]long mid, int pageIndex, int pageSize)
        {
            var fcircle = bFCircle.Entities
                .Where(f => f.MID == mid)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return Ok(fcircle);
        }
    }
}
