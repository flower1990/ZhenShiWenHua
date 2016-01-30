using HanHe.BLL;
using HanHe.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HanHe.Manage.Models.Helpers
{
    public class PropertyMapper
    {
        public PropertyInfo SourceProperty { get; set; }
        public PropertyInfo TargetProperty { get; set; }
    }
    public class SysFun
    {
        private static SysFun _instance;
        public static SysFun Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SysFun();
                }
                return _instance;
            }
        }

        IZs_ChuanJia bChuanJia = new BZs_ChuanJia();
        IZs_Member bMember = new BZs_Member();

        /// <summary>
        /// 初始化实体类
        /// </summary>
        /// <typeparam name="S">源类型</typeparam>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="s">源实体</param>
        /// <param name="t">目标实体</param>
        /// <returns></returns>
        public T InitialEntity<S, T>(S s, T t)
        {
            IList<PropertyMapper> mapperProperties = GetMapperProperties(s.GetType(), t.GetType());

            foreach (var item in mapperProperties)
            {
                var sourceValue = item.SourceProperty.GetValue(s);
                item.TargetProperty.SetValue(t, sourceValue);
            }

            return t;
        }
        /// <summary>
        /// 获取映射器属性
        /// </summary>
        /// <param name="sourceType">源类型</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>属性列表</returns>
        public IList<PropertyMapper> GetMapperProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            return (from s in sourceProperties
                    from t in targetProperties
                    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                    select new PropertyMapper { SourceProperty = s, TargetProperty = t }).ToList();
        }
        /// <summary>
        /// 获取传家类型
        /// </summary>
        /// <returns></returns>
        public SelectList DicMember(int selectedValue)
        {
            var listItem = new List<SelectListItem>();
            var memberList = bMember.Entities.Select(f => new { MID = f.MID, NickName = f.NickName });
            foreach (var item in memberList)
            {
                var selectItem = new SelectListItem() { Value = item.MID.ToString(), Text = item.NickName };
                listItem.Add(selectItem);
            }

            SelectList selectList = new SelectList(listItem, "Value", "Text", selectedValue);
            return selectList;
        }
    }
}