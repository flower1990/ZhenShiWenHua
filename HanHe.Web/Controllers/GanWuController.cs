using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HanHe.Web.Models;
using HanHe.Model;
using System.Web.Security;
using HanHe.IBLL;
using HanHe.BLL;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 感悟未来
    /// </summary>
    [RoutePrefix("api/GanWu")]
    public class GanWuController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_GanWu bGanWu = new BZs_GanWu();
        IZs_GanWuAtt bGanWuAtt = new BZs_GanWuAtt();

        /// <summary>
        /// 获取附件地址
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public string GetAttUrl(long gwID)
        {
            var attList = bGanWuAtt.Find(s => s.AttType == 1 && s.GWID == gwID);
            if (attList == null) return "";

            return attList.AttUrl;
        }
        /// <summary>
        /// 更新附件列表
        /// </summary>
        /// <param name="ganWu"></param>
        private GanWuViewModel UpdateAttList(Zs_GanWu ganWu)
        {
            var result = new GanWuViewModel();

            //实体列表
            var ganWuAttList = bGanWuAtt.Entities.Where(f => f.CreateDate < ganWu.CreateDate && f.GWID == 0);
            //遍历删除本地资源
            foreach (var item in ganWuAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (ganWuAttList.Count() > 0) bGanWuAtt.Delete(ganWuAttList);
            //批量更新
            bGanWuAtt.Update(f => f.MID == ganWu.MID, f => new Zs_GanWuAtt { GWID = ganWu.GwID });
            //实体列表
            ganWuAttList = bGanWuAtt.Entities.Where(f => f.MID == ganWu.MID);

            result.GanWu = ganWu;
            result.GanWuAtt = ganWuAttList.ToList();

            return result;
        }
        /// <summary>
        /// 添加感悟未来
        /// </summary>
        /// <param name="model">感悟未来信息</param>
        /// <returns>感悟未来和附件信息</returns>
        [HttpPost, Route("Add")]
        public IHttpActionResult AddGanWu(AddGanWuModel model)
        {
            var ganWu = new Zs_GanWu();
            var result = new GanWuViewModel();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            //初始化实体
            ganWu = sysFun.InitialEntity<AddGanWuModel, Zs_GanWu>(model, ganWu);
            //添加事历
            ganWu = bGanWu.Add(ganWu);
            //更新附件列表
            result = UpdateAttList(ganWu);

            if (ganWu.GwID > 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("添加失败");
            }
        }
        /// <summary>
        /// 修改感悟未来
        /// </summary>
        /// <returns>感悟未来和附件信息</returns>
        [HttpPost, Route("Update")]
        public IHttpActionResult UpdateGanWu(UpdateGanWuModel model)
        {
            var ganWu = new Zs_GanWu();
            var result = new GanWuViewModel();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            //初始化实体
            ganWu = bGanWu.Find(model.GwID);
            ganWu = sysFun.InitialEntity<UpdateGanWuModel, Zs_GanWu>(model, ganWu);
            //更新事历
            ganWu = bGanWu.UpdateEntity(ganWu);
            //更新附件列表
            result = UpdateAttList(ganWu);

            return Ok(result);
        }
        /// <summary>
        /// 删除感悟未来
        /// </summary>
        /// <param name="id">感悟未来编号</param>
        /// <returns>删除结果0：失败，1：成功</returns>
        [HttpGet, Route("Delete")]
        public IHttpActionResult DeleteGanWu([FromUri]long id)
        {
            var result = false;
            var ganWu = new Zs_GanWu();
            var dic = new Dictionary<string, string>();

            ganWu = bGanWu.Find(id);
            if (ganWu == null) return NotFound();

            //删除感悟
            result = bGanWu.Delete(ganWu);
            //实体列表
            var ganWuAttList = bGanWuAtt.Entities.Where(f => f.GWID == ganWu.GwID);
            //遍历删除本地资源
            foreach (var item in ganWuAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (ganWuAttList.Count() > 0) bGanWuAtt.Delete(ganWuAttList);

            if (result)
            {
                dic.Add("result", "1");
                return Ok(dic);
            }
            else
            {
                dic.Add("result", "0");
                return Ok();
            }
        }
        /// <summary>
        /// 获取感悟未来列表
        /// </summary>
        /// <param name="mid">会员编号</param>
        /// <returns>感悟未来和附件列表</returns>
        [HttpGet, Route("GetByMID")]
        public IHttpActionResult GetGanWuAll([FromUri]long mid)
        {
            var ganwuList = new List<GetGanWuAllModel>();
            var dreamList = new List<GetGanWuAllModel>();
            var dashiList = new List<GetGanWuAllModel>();
            var weilaiList = new List<GetGanWuAllModel>();
            
            var ganWuList = bGanWu.Entities.Where(f => f.MID == mid);
            //感悟
            var ganwu = ganWuList
                .Where(f => f.GwType == 1)
                .Select(f => new { GwID = f.GwID, GwTitleShort = f.GwTitleShort })
                .ToList();
            foreach (var item in ganwu)
            {
                var entity = new GetGanWuAllModel
                {
                    GwID = item.GwID,
                    GwTitleShort = item.GwTitleShort,
                    AttUrl = GetAttUrl(item.GwID)
                };
                ganwuList.Add(entity);
            }
            //梦想心愿
            var dream = ganWuList
                .Where(f => f.GwType == 2)
                .Select(f => new { GwID = f.GwID, GwTitleShort = f.GwTitleShort })
                .ToList();
            foreach (var item in ganwu)
            {
                var entity = new GetGanWuAllModel
                {
                    GwID = item.GwID,
                    GwTitleShort = item.GwTitleShort,
                    AttUrl = GetAttUrl(item.GwID)
                };
                dreamList.Add(entity);
            }
            //大事
            var dashi = ganWuList
                .Where(f => f.GwType == 3)
                .Select(f => new { GwID = f.GwID, GwTitleShort = f.GwTitleShort })
                .ToList();
            foreach (var item in ganwu)
            {
                var entity = new GetGanWuAllModel
                {
                    GwID = item.GwID,
                    GwTitleShort = item.GwTitleShort,
                    AttUrl = GetAttUrl(item.GwID)
                };
                dashiList.Add(entity);
            }
            //未来的信
            var weilai = ganWuList
                .Where(f => f.GwType == 4)
                .Select(f => new { GwID = f.GwID, GwTitleShort = f.GwTitleShort })
                .ToList();
            foreach (var item in ganwu)
            {
                var entity = new GetGanWuAllModel
                {
                    GwID = item.GwID,
                    GwTitleShort = item.GwTitleShort,
                    AttUrl = GetAttUrl(item.GwID)
                };
                weilaiList.Add(entity);
            }

            var jsonData = new { ganWuList, dreamList, dashiList, weilaiList };

            return Ok(jsonData);
        }
        /// <summary>
        /// 获取感悟未来详情
        /// </summary>
        /// <param name="id">感悟未来编号</param>
        /// <returns>感悟未来和附件信息</returns>
        [HttpGet, Route("GetById")]
        public IHttpActionResult GetGanWuById([FromUri]long id)
        {

            var ganWu = new Zs_GanWu();
            var ganWuAtt = new List<Zs_GanWuAtt>();
            var result = new GanWuViewModel();

            ganWu = bGanWu.Find(id);
            ganWuAtt = bGanWuAtt.Entities.Where(f => f.GWID == ganWu.GwID).ToList();
            result.GanWu = ganWu;
            result.GanWuAtt = ganWuAtt;

            return Ok(result);
        }
    }
}
