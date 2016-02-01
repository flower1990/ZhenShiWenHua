using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.IDAL;

namespace HanHe.DAL
{
    /// <summary>
    /// 简单工厂
    /// <remarks>创建：2016.01.08</remarks>
    /// </summary>
    public static class RepositoryFactory
    {
        public static IZs_ChuanJia DZs_ChuanJia { get { return new DZs_ChuanJia(); } }
        public static IZs_ChuanJiaAtt DZs_ChuanJiaAtt { get { return new DZs_ChuanJiaAtt(); } }
        public static IZs_ChuanJiaComment DZs_ChuanJiaComment { get { return new DZs_ChuanJiaComment(); } }
        public static IZs_Department DZs_Department { get { return new DZs_Department(); } }
        public static IZs_Dic DZs_Dic { get { return new DZs_Dic(); } }
        public static IZs_FavoritesInfo DZs_FavoritesInfo { get { return new DZs_FavoritesInfo(); } }
        public static IZs_FCAtt DZs_FCAtt { get { return new DZs_FCAtt(); } }
        public static IZs_FCBlack DZs_FCBlack { get { return new DZs_FCBlack(); } }
        public static IZs_FCComment DZs_FCComment { get { return new DZs_FCComment(); } }
        public static IZs_FCircle DZs_FCircle { get { return new DZs_FCircle(); } }
        public static IZs_FGroup DZs_FGroup { get { return new DZs_FGroup(); } }
        public static IZs_Friend DZs_Friend { get { return new DZs_Friend(); } }
        public static IZs_GanWu DZs_GanWu { get { return new DZs_GanWu(); } }
        public static IZs_GanWuAtt DZs_GanWuAtt { get { return new DZs_GanWuAtt(); } }
        public static IZs_GanWuComment DZs_GanWuComment { get { return new DZs_GanWuComment(); } }
        public static IZs_GuoXue DZs_GuoXue { get { return new DZs_GuoXue(); } }
        public static IZs_GuoXueAtt DZs_GuoXueAtt { get { return new DZs_GuoXueAtt(); } }
        public static IZs_GuoXueComment DZs_GuoXueComment { get { return new DZs_GuoXueComment(); } }
        public static IZs_Keywords DZs_Keywords { get { return new DZs_Keywords(); } }
        public static IZs_Member DZs_Member { get { return new DZs_Member(); } }
        public static IZs_MemorialDay DZs_MemorialDay { get { return new DZs_MemorialDay(); } }
        public static IZs_NewFriend DZs_NewFriend { get { return new DZs_NewFriend(); } }
        public static IZs_Product DZs_Product { get { return new DZs_Product(); } }
        public static IZs_ProductAtt DZs_ProductAtt { get { return new DZs_ProductAtt(); } }
        public static IZs_Project DZs_Project { get { return new DZs_Project(); } }
        public static IZs_ProjectAtt DZs_ProjectAtt { get { return new DZs_ProjectAtt(); } }
        public static IZs_ProjectClock DZs_ProjectClock { get { return new DZs_ProjectClock(); } }
        public static IZs_ProjectComment DZs_ProjectComment { get { return new DZs_ProjectComment(); } }
        public static IZs_Right DZs_Right { get { return new DZs_Right(); } }
        public static IZs_Role DZs_Role { get { return new DZs_Role(); } }
        public static IZs_RoleRight DZs_RoleRight { get { return new DZs_RoleRight(); } }
        public static IZs_RoleUser DZs_RoleUser { get { return new DZs_RoleUser(); } }
        public static IZs_SetNotice DZs_SetNotice { get { return new DZs_SetNotice(); } }
        public static IZs_SetPrivacy DZs_SetPrivacy { get { return new DZs_SetPrivacy(); } }
        public static IZs_User DZs_User { get { return new DZs_User(); } }
    }
}
