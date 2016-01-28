using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 系统主界面
    /// </summary>
    [RoutePrefix("api/MainUI")]
    public class MainController : ApiController
    {
        IZs_Project bProject = new BZs_Project();
        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();
        IZs_GanWu bGanWu = new BZs_GanWu();

        /// <summary>
        /// 主界面接口
        /// </summary>
        /// <param name="mid">会员编号</param>
        /// <returns></returns>
        [HttpGet, Route("index")]
        public IHttpActionResult Index(long mid)
        {   
            var projectList = bProject.Entities.Where(f => f.MID == mid);
            //轻缓
            var qinghuan = projectList
                .Where(f => f.ImpropantWeight == 0 && f.UrgentWeight == 0)
                .Select(f => new { ProjectID = f.ProjectID, ProTitleShort = f.ProTitleShort })
                .ToList();
            //重缓
            var zhonghuan = projectList
                .Where(f => f.ImpropantWeight == 1 && f.UrgentWeight == 0)
                .Select(f => new { ProjectID = f.ProjectID, ProTitleShort = f.ProTitleShort })
                .ToList();
            //轻急
            var qingji = projectList
                .Where(f => f.ImpropantWeight == 0 && f.UrgentWeight == 1)
                .Select(f => new { ProjectID = f.ProjectID, ProTitleShort = f.ProTitleShort })
                .ToList();
            //重急
            var zhongji = projectList
                .Where(f => f.ImpropantWeight == 1 && f.UrgentWeight == 1)
                .Select(f => new { ProjectID = f.ProjectID, ProTitleShort = f.ProTitleShort })
                .ToList();

            var jsonData = new { qinghuan, zhonghuan, qingji, zhongji };

            return Ok(jsonData);
        }
    }
}
