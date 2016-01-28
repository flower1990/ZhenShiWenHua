using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 行事历附件
    /// </summary>
    [RoutePrefix("api/ProjectAtt")]
    public class ProjectAttController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_Project bProject = new BZs_Project();
        IZs_ProjectAtt bProjectAtt = new BZs_ProjectAtt();

        /// <summary>
        /// 添加或更新附件（添加传MID，更新传AttID）
        /// </summary>
        /// <returns>附件信息</returns>
        [HttpPost, Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdateProjectAtt()
        {
            var projectAtt = new Zs_ProjectAtt();
            var hashTable = new Hashtable();
            var fileData = new List<FileDataInfo>();
            var formData = new Dictionary<string, string>();

            //获取表单数据
            hashTable = await sysFun.GetFormData(Request);
            formData = hashTable["FormData"] as Dictionary<string, string>;
            fileData = hashTable["FileData"] as List<FileDataInfo>;

            foreach (var item in fileData)
            {
                projectAtt = new Zs_ProjectAtt();
                if (formData.ContainsKey("AttID"))
                {
                    //查找当前附件
                    projectAtt = bProjectAtt.Find(long.Parse(formData["AttID"]));
                    //检测是否存在
                    if (projectAtt == null) return NotFound();
                    //删除本地附件
                    sysFun.DeleteFile(projectAtt.AttType, projectAtt.AttUrl);
                    projectAtt.AttTitle = item.AttTitle;
                    projectAtt.AttType = item.AttType;
                    projectAtt.AttUrl = item.AttUrl;
                    projectAtt.AttInfo = item.AttInfo;
                    projectAtt = bProjectAtt.UpdateEntity(projectAtt);
                }
                else if (formData.ContainsKey("MID"))
                {
                    projectAtt.MID = long.Parse(formData["MID"]);
                    projectAtt.ProjectID = 0;
                    projectAtt.AttTitle = item.AttTitle;
                    projectAtt.AttType = item.AttType;
                    projectAtt.AttUrl = item.AttUrl;
                    projectAtt.AttInfo = item.AttInfo;
                    projectAtt = bProjectAtt.Add(projectAtt);
                }
            }

            return Ok(projectAtt);
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="id">附件编号</param>
        /// <returns></returns>
        [HttpGet, Route("DeleteAtt")]
        public IHttpActionResult DeleteProjectAtt([FromUri] string id)
        {
            long AttID = 0;
            var result = false;
            var projectAtt = new Zs_ProjectAtt();
            var hashTable = new Hashtable();
            var fileData = new List<FileDataInfo>();
            var dic = new Dictionary<string, string>();

            //附件编号
            if (!long.TryParse(id, out AttID)) return BadRequest("附件编号格式不正确");
            //查找当前附件
            projectAtt = bProjectAtt.Find(AttID);
            //检测是否存在
            if (projectAtt == null) return NotFound();
            //删除本地附件
            sysFun.DeleteFile(projectAtt.AttType, projectAtt.AttUrl);
            //删除数据库附件
            result = bProjectAtt.Delete(projectAtt);

            if (result)
            {
                dic.Add("result", "1");
                return Ok(dic);
            }
            else
            {
                dic.Add("result", "1");
                return Ok(dic);
            }
        }
    }
}
