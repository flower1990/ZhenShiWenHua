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
    /// 传家有道附件
    /// </summary>
    [RoutePrefix("api/ChuanJiaAtt")]
    public class ChuanJiaAttController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();
        IZs_ChuanJiaAtt bChuanJiaAtt = new BZs_ChuanJiaAtt();

        /// <summary>
        /// 添加或更新附件（添加传MID，更新传AttID）
        /// </summary>
        /// <returns>附件信息</returns>
        [HttpPost, Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdateChuanJiaAtt()
        {
            var chuanJiaAtt = new Zs_ChuanJiaAtt();
            var hashTable = new Hashtable();
            var fileData = new List<FileDataInfo>();
            var formData = new Dictionary<string, string>();

            //获取表单数据
            hashTable = await sysFun.GetFormData(Request);
            formData = hashTable["FormData"] as Dictionary<string, string>;
            fileData = hashTable["FileData"] as List<FileDataInfo>;

            foreach (var item in fileData)
            {
                chuanJiaAtt = new Zs_ChuanJiaAtt();
                if (formData.ContainsKey("AttID"))
                {
                    //查找当前附件
                    chuanJiaAtt = bChuanJiaAtt.Find(long.Parse(formData["AttID"]));
                    //检测是否存在
                    if (chuanJiaAtt == null) return NotFound();
                    //删除本地附件
                    sysFun.DeleteFile(chuanJiaAtt.AttType, chuanJiaAtt.AttUrl);
                    chuanJiaAtt.AttTitle = item.AttTitle;
                    chuanJiaAtt.AttType = item.AttType;
                    chuanJiaAtt.AttUrl = item.AttUrl;
                    chuanJiaAtt.AttInfo = item.AttInfo;
                    chuanJiaAtt = bChuanJiaAtt.UpdateEntity(chuanJiaAtt);
                }
                else if (formData.ContainsKey("MID"))
                {
                    chuanJiaAtt.MID = long.Parse(formData["MID"]);
                    chuanJiaAtt.CJID = 0;
                    chuanJiaAtt.AttTitle = item.AttTitle;
                    chuanJiaAtt.AttType = item.AttType;
                    chuanJiaAtt.AttUrl = item.AttUrl;
                    chuanJiaAtt.AttInfo = item.AttInfo;
                    chuanJiaAtt = bChuanJiaAtt.Add(chuanJiaAtt);
                }
            }

            return Ok(chuanJiaAtt);
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
            var result = false;
            var chuanJiaAtt = new Zs_ChuanJiaAtt();
            var hashTable = new Hashtable();
            var dic = new Dictionary<string, string>();

            //附件编号
            if (!long.TryParse(id, out AttID)) return Ok("附件编号格式不正确");
            //查找当前附件
            chuanJiaAtt = bChuanJiaAtt.Find(AttID);
            //检测是否存在
            if (chuanJiaAtt == null) return NotFound();
            //删除本地附件
            sysFun.DeleteFile(chuanJiaAtt.AttType, chuanJiaAtt.AttUrl);
            //删除数据库附件
            result = bChuanJiaAtt.Delete(chuanJiaAtt);

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
    }
}
