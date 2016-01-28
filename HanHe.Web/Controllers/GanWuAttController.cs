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
    /// 感悟未来附件
    /// </summary>
    [RoutePrefix("api/GanWuAtt")]
    public class GanWuAttController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_GanWu bGanWu = new BZs_GanWu();
        IZs_GanWuAtt bGanWuAtt = new BZs_GanWuAtt();

        /// <summary>
        /// 添加或更新附件（添加传MID，更新传AttID）
        /// </summary>
        /// <returns>附件信息</returns>
        [HttpPost, Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdateGanWuAtt()
        {
            var ganWuAtt = new Zs_GanWuAtt();
            var hashTable = new Hashtable();
            var fileData = new List<FileDataInfo>();
            var formData = new Dictionary<string, string>();

            //获取表单数据
            hashTable = await sysFun.GetFormData(Request);
            formData = hashTable["FormData"] as Dictionary<string, string>;
            fileData = hashTable["FileData"] as List<FileDataInfo>;

            foreach (var item in fileData)
            {
                ganWuAtt = new Zs_GanWuAtt();
                if (formData.ContainsKey("AttID"))
                {
                    //查找当前附件
                    ganWuAtt = bGanWuAtt.Find(long.Parse(formData["AttID"]));
                    //检测是否存在
                    if (ganWuAtt == null) return NotFound();
                    //删除本地附件
                    sysFun.DeleteFile(ganWuAtt.AttType, ganWuAtt.AttUrl);
                    ganWuAtt.AttTitle = item.AttTitle;
                    ganWuAtt.AttType = item.AttType;
                    ganWuAtt.AttUrl = item.AttUrl;
                    ganWuAtt.AttInfo = item.AttInfo;
                    ganWuAtt = bGanWuAtt.UpdateEntity(ganWuAtt);
                }
                else if (formData.ContainsKey("MID"))
                {
                    ganWuAtt.MID = long.Parse(formData["MID"]);
                    ganWuAtt.GWID = 0;
                    ganWuAtt.AttTitle = item.AttTitle;
                    ganWuAtt.AttType = item.AttType;
                    ganWuAtt.AttUrl = item.AttUrl;
                    ganWuAtt.AttInfo = item.AttInfo;
                    ganWuAtt = bGanWuAtt.Add(ganWuAtt);
                }
            }

            return Ok(ganWuAtt);
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="id">附件编号</param>
        /// <returns>删除结果0：失败，1：成功</returns>
        [HttpGet, Route("Delete")]
        public IHttpActionResult DeleteProjectAtt([FromUri] string id)
        {
            long AttID = 0;
            var deleteResult = false;
            var ganWuAtt = new Zs_GanWuAtt();
            var hashTable = new Hashtable();
            var fileData = new List<FileDataInfo>();
            var dic = new Dictionary<string, string>();

            //附件编号
            if (!long.TryParse(id, out AttID)) return BadRequest("附件编号格式不正确");
            //查找当前附件
            ganWuAtt = bGanWuAtt.Find(AttID);
            //检测是否存在
            if (ganWuAtt == null) return NotFound();
            //删除本地附件
            sysFun.DeleteFile(ganWuAtt.AttType, ganWuAtt.AttUrl);
            //删除数据库附件
            deleteResult = bGanWuAtt.Delete(ganWuAtt);

            if (deleteResult)
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
    }
}
