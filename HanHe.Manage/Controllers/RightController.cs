using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Manage.Models.Grid;
using HanHe.Manage.Models.Helpers;
using HanHe.Manage.Models.Repositories;
using HanHe.Manage.Models.Right;
using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Controllers
{
    public class TreeNode
    {
        public int RightID { get; set; }
        public string RightName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int ParentID { get; set; }
        public int SortID { get; set; }
        public int RightProperty { get; set; }
        public string Remark { get; set; }
        public int level { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public int? parent { get; set; }
    }

    public class RightController : Controller
    {
        SysFun sysFun = new SysFun();
        IZs_User bUser = new BZs_User();
        IZs_Role bRole = new BZs_Role();
        IZs_Right bRight = new BZs_Right();

        #region 注释
        //public JsonResult GetSPTreeJSON(string nodeid, string n_level, string currentUser)
        //{
        //    List<TreeNode> list = GetTreeNodeList(nodeid, n_level);

        //    var jsonData = new
        //    {
        //        page = 1,
        //        total = 1,
        //        records = 1,
        //        rows = (
        //            from TreeNode u in list
        //            select new
        //            {
        //                cell = new object[] { u.Id.ToString(), u.name, u.level, u.ParentId, u.isLeaf, false }
        //            }).ToList()
        //    };

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}

        //public List<TreeNode> GetTreeNodeList(string nodeid, string n_level)
        //{
        //    List<Tree> root = null;

        //    Guid? currentNode;
        //    if (nodeid == null)
        //        currentNode = null;
        //    else
        //        currentNode = new Guid(nodeid);

        //    //if (nodeid == null)
        //    //    root = ssdsContext.Trees.Where(x => x.ParentId == null).ToList();
        //    //else
        //    //    root = ssdsContext.Trees.Where(x => x.ParentId == currentNode).ToList();

        //    List<TreeNode> list = new List<TreeNode>();

        //    int newLevel = n_level == null ? 0 : Convert.ToInt32(n_level) + 1;

        //    foreach (Tree t in root)
        //    {
        //        TreeNode n = new TreeNode
        //        {
        //            expanded = false,
        //            Id = t.UserId,
        //            isLeaf = t.IsUser,
        //            name = t.Name,
        //            ParentId = t.ParentId,
        //            level = newLevel
        //        };
        //        list.Add(n);
        //    }
        //    return list;
        //}
        #endregion

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RightList()
        {
            return View();
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public JsonResult GetData(GridSettings grid, string nodeid, string n_level)
        {
            //var query = bRight.Entities;
            //var rightID = nodeid != null ? int.Parse(nodeid) : 0;
            //int level = n_level != null ? int.Parse(n_level) + 1 : 0;
            //var subRight = query.Where(f => f.ParentID == rightID).ToList();
            int currentNode;
            int? parent;
            List<TreeNode> list = new List<TreeNode>();
            int newLevel = n_level == null ? 0 : Convert.ToInt32(n_level) + 1;
            if (nodeid == null) parent = null; else parent = int.Parse(nodeid);
            if (nodeid == null) currentNode = 0; else currentNode = int.Parse(nodeid);
            var query = bRight.Entities.Where(f => f.ParentID == currentNode);

            foreach (Zs_Right t in query)
            {
                TreeNode n = new TreeNode
                {
                    RightID = t.RightID,
                    RightName = t.RightName,
                    ControllerName = t.ControllerName,
                    ActionName = t.ActionName,
                    ParentID = t.ParentID,
                    SortID = t.SortID,
                    RightProperty = t.RightProperty,
                    Remark = t.Remark,

                    isLeaf = bRight.Exist(f => f.ParentID == t.RightID),
                    level = newLevel,
                    parent = parent,
                    expanded = false,
                };
                list.Add(n);
            }

            //converting in grid format
            var result = new
            {
                total = 1,
                page = 1,
                records = 1,
                rows = (from item in list
                        select new
                        {
                            cell = new object[]
                            { 
                                item.RightID.ToString(), 
                                //item.RightCode,
                                item.RightName, 
                                item.ControllerName, 
                                item.ActionName, 
                                item.ParentID,
                                item.SortID, 
                                item.RightProperty, 
                                item.Remark,

                                item.level,
                                item.isLeaf,
                                item.parent,
                                "false"
                            }
                        }).ToArray()
            };

            //convert to JSON and return to client
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Create(RightCreate model)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_Right item = new Zs_Right();
                    item = sysFun.InitialEntity<RightCreate, Zs_Right>(model, item);

                    bRight.Add(item);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(RightEdit model)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Zs_Right item = bRight.Find(model.RightID);

                    item = sysFun.InitialEntity<RightEdit, Zs_Right>(model, item);
                    bRight.Update(item);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            Zs_Right item = bRight.Find(id);
            bRight.Delete(item);
            return "Deleted successfully";
        }
    }
}