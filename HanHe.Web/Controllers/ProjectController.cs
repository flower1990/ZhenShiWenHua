using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Web;
using HanHe.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 行事历
    /// </summary>
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_Project bProject = new BZs_Project();
        IZs_ProjectAtt bProjectAtt = new BZs_ProjectAtt();

        /// <summary>
        /// 获取附件地址
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        private string GetAttUrl(long projectID)
        {
            var attList = bProjectAtt.Find(s => s.AttType == 1 && s.ProjectID == projectID);
            if (attList == null) return "";

            return attList.AttUrl;
        }
        /// <summary>
        /// 获取附件图片
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        private string GetAttUrl(ICollection<Zs_ProjectAtt> att)
        {
            if (att.Count == 0) return "";
            return att.Where(f => f.AttType == 1).FirstOrDefault().AttUrl;
        }
        /// <summary>
        /// 更新附件列表
        /// </summary>
        /// <param name="project">事例信息</param>
        private ProjectViewModel UpdateAttList(Zs_Project project)
        {
            var result = new ProjectViewModel();

            //实体列表
            var projectAttList = bProjectAtt.Entities.Where(f => f.CreateDate < project.UpdateDate && f.ProjectID == 0);
            //遍历删除本地资源
            foreach (var item in projectAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (projectAttList.Count() > 0) bProjectAtt.Delete(projectAttList);
            //批量更新
            bProjectAtt.Update(f => f.MID == project.MID, f => new Zs_ProjectAtt { ProjectID = project.ProjectID });
            //实体列表
            projectAttList = bProjectAtt.Entities.Where(f => f.MID == project.MID);

            result.Project = project;
            result.ProjectAtt = projectAttList.ToList();

            return result;
        }
        /// <summary>
        /// 添加事历
        /// <param name="model">事历信息</param>
        /// </summary>
        /// <returns>事历信息和附件列表</returns>
        [HttpPost, Route("Add")]
        public IHttpActionResult AddProject(AddProjectModel model)
        {
            var project = new Zs_Project();
            var result = new ProjectViewModel();

            //初始化实体
            project = sysFun.InitialEntity<AddProjectModel, Zs_Project>(model, project);
            //添加事历
            project = bProject.Add(project);
            //更新附件列表
            result = UpdateAttList(project);

            if (project.ProjectID > 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("添加失败");
            }
        }
        /// <summary>
        /// 修改事历
        /// </summary>
        /// <param name="model">事历信息</param>
        /// <returns>事历信息和附件列表</returns>
        [HttpPost, Route("Update")]
        public IHttpActionResult UpdateProject(UpdateProjectModel model)
        {
            var project = new Zs_Project();
            var result = new ProjectViewModel();

            //初始化实体
            project = bProject.Find(model.ProjectID);
            project = sysFun.InitialEntity<UpdateProjectModel, Zs_Project>(model, project);
            //更新事历
            project = bProject.UpdateEntity(project);
            //更新附件列表
            result = UpdateAttList(project);

            return Ok(result);
        }
        /// <summary>
        /// 删除事历
        /// </summary>
        /// <param name="id">事历编号</param>
        /// <returns>删除结果0：失败，1：成功</returns>
        [HttpGet, Route("Delete")]
        public IHttpActionResult DeleteProject([FromUri]long id)
        {
            var result = false;
            var dic = new Dictionary<string, string>();
            var project = new Zs_Project();

            project = bProject.Find(id);
            if (project == null) return NotFound();

            //删除事历
            result = bProject.Delete(project);
            //实体列表
            var ganWuAttList = bProjectAtt.Entities.Where(f => f.ProjectID == project.ProjectID);
            //遍历删除本地资源
            foreach (var item in ganWuAttList) sysFun.DeleteFile(item.AttType, item.AttUrl);
            //批量删除
            if (ganWuAttList.Count() > 0) bProjectAtt.Delete(ganWuAttList);
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
        /// 获取事历列表
        /// </summary>
        /// <param name="mid">会员编号</param>
        /// <returns>事历信息和附件列表</returns>
        [HttpGet, Route("GetByMID")]
        public IHttpActionResult GetProjectAll([FromUri]long mid)
        {
            //事历列表
            var projectList = bProject.Entities.Where(f => f.MID == mid).ToList();

            #region//轻缓
            var qinghuan = projectList
                .Where(f => f.ImpropantWeight == 0 && f.UrgentWeight == 0)
                .Select(f => new 
                { 
                    ProjectID = f.ProjectID, 
                    ProTitleShort = f.ProTitleShort,
                    AttUrl = GetAttUrl(f.ProjectAtt) 
                }).ToList();
            #endregion

            #region//重缓
            var zhonghuan = projectList
                .Where(f => f.ImpropantWeight == 1 && f.UrgentWeight == 0)
                .Select(f => new 
                { 
                    ProjectID = f.ProjectID, 
                    ProTitleShort = f.ProTitleShort,
                    AttUrl = GetAttUrl(f.ProjectAtt) 
                }).ToList();
            #endregion

            #region//轻急
            var qingji = projectList
                .Where(f => f.ImpropantWeight == 0 && f.UrgentWeight == 1)
                .Select(f => new 
                { 
                    ProjectID = f.ProjectID, 
                    ProTitleShort = f.ProTitleShort,
                    AttUrl = GetAttUrl(f.ProjectAtt) 
                }).ToList();
            #endregion

            #region//重急
            var zhongji = projectList
                .Where(f => f.ImpropantWeight == 1 && f.UrgentWeight == 1)
                .Select(f => new 
                { 
                    ProjectID = f.ProjectID, 
                    ProTitleShort = f.ProTitleShort,
                    AttUrl = GetAttUrl(f.ProjectAtt) 
                }).ToList();
            #endregion

            var jsonData = new { qinghuan, zhonghuan, qingji, zhongji };

            return Ok(jsonData);
        }
        /// <summary>
        /// 获取详情信息
        /// </summary>
        /// <param name="id">事历编号</param>
        /// <returns>事历信息和附件列表</returns>
        [HttpGet, Route("GetById")]
        public IHttpActionResult GetProjectById([FromUri]long id)
        {
            var project = new Zs_Project();
            var projectAtt = new List<Zs_ProjectAtt>();
            var result = new ProjectViewModel();

            project = bProject.Find(id);
            projectAtt = bProjectAtt.Entities.Where(f => f.ProjectID == project.ProjectID).ToList();
            result.Project = project;
            result.ProjectAtt = projectAtt;

            return Ok(result);
        }
    }
}
