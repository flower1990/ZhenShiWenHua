using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Util;
using HanHe.Web.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 传家有道
    /// </summary>
    [RoutePrefix("api/ChuanJia")]
    public class ChuanJiaController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();
        IZs_ChuanJiaAtt bChuanJiaAtt = new BZs_ChuanJiaAtt();

        /// <summary>
        /// 获取附件地址
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public string GetAttUrl(long cjID)
        {
            var attList = bChuanJiaAtt.Find(s => s.AttType == 1 && s.CJID == cjID);
            if (attList == null) return "";
            
            return attList.AttUrl;
        }
        /// <summary>
        /// 更新附件列表
        /// </summary>
        /// <param name="chuanjia">传家信息</param>
        private ChuanJiaViewModel UpdateAttList(Zs_ChuanJia chuanjia)
        {
            var result = new ChuanJiaViewModel();

            //实体列表
            var chuanJiaAttList = bChuanJiaAtt.Entities.Where(f => f.CreateDate < chuanjia.UpdateDate && f.CJID == 0);
            //遍历删除本地资源
            foreach (var item in chuanJiaAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (chuanJiaAttList.Count() > 0) bChuanJiaAtt.Delete(chuanJiaAttList);
            //批量更新
            bChuanJiaAtt.Update(f => f.MID == chuanjia.MID, f => new Zs_ChuanJiaAtt { CJID = chuanjia.CJID });
            //实体列表
            chuanJiaAttList = bChuanJiaAtt.Entities.Where(f => f.MID == chuanjia.MID);

            result.ChuanJia = chuanjia;
            result.ChuanJiaAtt = chuanJiaAttList.ToList();
            return result;
        }
        /// <summary>
        /// 添加传家有道
        /// </summary>
        /// <param name="model">传家有道信息</param>
        /// <returns>传家有道信息和附件列表</returns>
        [HttpPost, Route("Add")]
        public IHttpActionResult AddChuanJia(AddChuanJiaModel model)
        {
            var chuanJia = new Zs_ChuanJia();
            var result = new ChuanJiaViewModel();

            //初始化实体
            chuanJia = sysFun.InitialEntity<AddChuanJiaModel, Zs_ChuanJia>(model, chuanJia);
            //添加传家有道
            chuanJia = bChuanJia.Add(chuanJia);
            //更新附件列表
            result = UpdateAttList(chuanJia);

            if (chuanJia.CJID > 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("添加失败");
            }
        }
        /// <summary>
        /// 修改传家有道
        /// </summary>
        /// <param name="model">传家有道信息</param>
        /// <returns>传家有道信息和附件列表</returns>
        [HttpPost, Route("Update")]
        public IHttpActionResult UpdateChuanJia(UpdateChuanJiaModel model)
        {
            var chuanJia = new Zs_ChuanJia();
            var result = new ChuanJiaViewModel();

            //初始化实体
            chuanJia = bChuanJia.Find(model.CJID);
            chuanJia = sysFun.InitialEntity<UpdateChuanJiaModel, Zs_ChuanJia>(model, chuanJia);
            //更新传家有道
            chuanJia = bChuanJia.UpdateEntity(chuanJia);
            //更新附件列表
            result = UpdateAttList(chuanJia);

            return Ok(result);
        }
        /// <summary>
        /// 删除传家有道
        /// </summary>
        /// <param name="id">传家编号</param>
        /// <returns>删除结果0：失败，1：成功</returns>
        [HttpGet, Route("Delete")]
        public IHttpActionResult DeleteChuanJia([FromUri]long id)
        {
            var result = false;
            var chuanJia = new Zs_ChuanJia();
            var dic = new Dictionary<string, string>();

            chuanJia = bChuanJia.Find(id);
            if (chuanJia == null) return NotFound();

            //删除传家
            result = bChuanJia.Delete(chuanJia);
            //实体列表
            var ganWuAttList = bChuanJiaAtt.Entities.Where(f => f.CJID == chuanJia.CJID);
            //遍历删除本地资源
            foreach (var item in ganWuAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (ganWuAttList.Count() > 0) bChuanJiaAtt.Delete(ganWuAttList);

            if (result)
            {
                dic.Add("result", "1");
                return Ok(dic);
            }
            else
            {
                dic.Add("result", "0");
                return Ok(dic);
            }
        }
        /// <summary>
        /// 获取传家有道列表
        /// </summary>
        /// <param name="mid">会员编号</param>
        /// <returns>传家有道信息和附件列表</returns>
        [HttpGet, Route("GetByMID")]
        public IHttpActionResult GetChuanJiaAll([FromUri]long mid)
        {
            var muzhiList = new List<GetChuanJiaAllModel>();
            var jiaxunList = new List<GetChuanJiaAllModel>();
            var yixunList = new List<GetChuanJiaAllModel>();
            var wenhuaList = new List<GetChuanJiaAllModel>();
            
            var chuanJiaList = bChuanJia.Entities.Where(f => f.MID == mid);
            //墓志铭
            var muzhi = chuanJiaList
                .Where(f => f.TypeID == 1)
                .Select(f => new { CJID = f.CJID, CJTitleShort = f.CJTitleShort })
                .ToList();
            foreach (var item in muzhi)
            {
                var entity = new GetChuanJiaAllModel
                {
                    CJID = item.CJID,
                    CJTitleShort = item.CJTitleShort,
                    AttUrl = GetAttUrl(item.CJID)
                };
                muzhiList.Add(entity);
            }
            //遗训
            var yixun = chuanJiaList
                .Where(f => f.TypeID == 2)
                .Select(f => new { CJID = f.CJID, CJTitleShort = f.CJTitleShort })
                .ToList();
            foreach (var item in yixun)
            {
                var entity = new GetChuanJiaAllModel
                {
                    CJID = item.CJID,
                    CJTitleShort = item.CJTitleShort,
                    AttUrl = GetAttUrl(item.CJID)
                };
                yixunList.Add(entity);
            }
            //感悟
            var wenhua = chuanJiaList
                .Where(f => f.TypeID == 3)
                .Select(f => new { CJID = f.CJID, CJTitleShort = f.CJTitleShort })
                .ToList();
            foreach (var item in wenhua)
            {
                var entity = new GetChuanJiaAllModel
                {
                    CJID = item.CJID,
                    CJTitleShort = item.CJTitleShort,
                    AttUrl = GetAttUrl(item.CJID)
                };
                wenhuaList.Add(entity);
            }
            //感悟
            var jaixun = chuanJiaList
                .Where(f => f.TypeID == 4)
                .Select(f => new { CJID = f.CJID, CJTitleShort = f.CJTitleShort })
                .ToList();
            foreach (var item in jaixun)
            {
                var entity = new GetChuanJiaAllModel
                {
                    CJID = item.CJID,
                    CJTitleShort = item.CJTitleShort,
                    AttUrl = GetAttUrl(item.CJID)
                };
                muzhiList.Add(entity);
            }

            var jsonData = new { muzhiList, jiaxunList, yixunList, wenhuaList };

            return Ok(jsonData);
        }
        /// <summary>
        /// 根据传家ID查找
        /// </summary>
        /// <param name="id">传家有道编号</param>
        /// <returns>传家有道信息和附件列表</returns>
        [HttpGet, Route("GetById")]
        public IHttpActionResult GetChuanJiaById([FromUri]long id)
        {
            var chuanJia = new Zs_ChuanJia();
            var chuanJiaAtt = new List<Zs_ChuanJiaAtt>();
            var result = new List<ChuanJiaViewModel>();

            chuanJia = bChuanJia.Find(id);
            chuanJiaAtt = bChuanJiaAtt.Entities.Where(f => f.CJID == chuanJia.CJID).ToList();
            result.Add(new ChuanJiaViewModel() { ChuanJia = chuanJia, ChuanJiaAtt = chuanJiaAtt });

            return Ok(result);
        }
    }
}
