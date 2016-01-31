using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HanHe.Util
{
    public class DicUtil
    {
        private static DicUtil _instance;
        public static DicUtil Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DicUtil();
                }
                return _instance;
            }
        }


        public string ChuanJia { get { return "ChuanJia"; } }

        /// <summary>
        /// 获取重要程度
        /// </summary>
        /// <returns></returns>
        public SelectList DicImpropantWeight(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "普通"},
                new SelectListItem(){ Value = "1", Text = "重要"},                
            };
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取紧急程度
        /// </summary>
        /// <returns></returns>
        public SelectList DicUrgentWeight(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "普通"},
                new SelectListItem(){ Value = "1", Text = "紧急"},                
            };
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取开放状态
        /// </summary>
        /// <returns></returns>
        public SelectList DicOpenStatus(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "隐私"},
                new SelectListItem(){ Value = "1", Text = "开放"},                
                new SelectListItem(){ Value = "2", Text = "好友可见"}, 
            };
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取事历状态
        /// </summary>
        /// <returns></returns>
        public SelectList DicProStatus(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "初始状态"},
                new SelectListItem(){ Value = "1", Text = "完成"},                
                new SelectListItem(){ Value = "2", Text = "进行中"}, 
                new SelectListItem(){ Value = "-1", Text = "放弃"}, 
            };

            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取传家类型
        /// </summary>
        /// <returns></returns>
        public SelectList DicCJType(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "1", Text = "墓志铭"},
                new SelectListItem(){ Value = "2", Text = "家训"},                
                new SelectListItem(){ Value = "3", Text = "遗训"}, 
                new SelectListItem(){ Value = "4", Text = "文化传承"}, 
            };

            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取感悟类型
        /// </summary>
        /// <returns></returns>
        public SelectList DicGwType(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "1", Text = "感悟"},
                new SelectListItem(){ Value = "2", Text = "梦想心愿"},                
                new SelectListItem(){ Value = "3", Text = "大事"}, 
                new SelectListItem(){ Value = "4", Text = "未来的信"}, 
                new SelectListItem(){ Value = "4", Text = "杂谈"}, 
            };
            
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取感悟状态
        /// </summary>
        /// <returns></returns>
        public SelectList DicGwStatus(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "初始"},
                new SelectListItem(){ Value = "1", Text = "提交"},                
                new SelectListItem(){ Value = "2", Text = "送达"}, 
            };
            
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取发送状态
        /// </summary>
        /// <returns></returns>
        public SelectList DicSmsStatus(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "不发短信"},
                new SelectListItem(){ Value = "1", Text = "发送短信"},                 
            };
            
            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        public SelectList DicGxStatus(int selectedValue)
        {
            List<SelectListItem> listItem = new List<SelectListItem>() 
            {
                new SelectListItem(){ Value = "0", Text = "未发布"},
                new SelectListItem(){ Value = "1", Text = "已发布"},                 
            };

            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
        
    }
}
