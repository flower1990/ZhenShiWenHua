using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.Model;

namespace HanHe.DAL
{
    /// <summary>
    /// 数据上下文
    /// <remarks>
    /// 创建：2016.01.08
    /// 修改：2016.01.08
    /// </remarks>
    /// </summary>
    public class HanHeDbContext : DbContext
    {
        public HanHeDbContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Zs_ChuanJia> Zs_ChuanJia { get; set; }
        public DbSet<Zs_ChuanJiaAtt> Zs_ChuanJiaAtt { get; set; }
        public DbSet<Zs_ChuanJiaComment> Zs_ChuanJiaComment { get; set; }
        public DbSet<Zs_Department> Zs_Department { get; set; }
        public DbSet<Zs_Dic> Zs_Dic { get; set; }
        public DbSet<Zs_FavoritesInfo> Zs_FavoritesInfo { get; set; }
        public DbSet<Zs_FCAtt> Zs_FCAtt { get; set; }
        public DbSet<Zs_FCBlack> Zs_FCBlack { get; set; }
        public DbSet<Zs_FCComment> Zs_FCComment { get; set; }
        public DbSet<Zs_FCircle> Zs_FCircle { get; set; }
        public DbSet<Zs_FGroup> Zs_FGroup { get; set; }
        public DbSet<Zs_Friend> Zs_Friend { get; set; }
        public DbSet<Zs_GanWu> Zs_GanWu { get; set; }
        public DbSet<Zs_GanWuAtt> Zs_GanWuAtt { get; set; }
        public DbSet<Zs_GanWuComment> Zs_GanWuComment { get; set; }
        public DbSet<Zs_GuoXue> Zs_GuoXue { get; set; }
        public DbSet<Zs_GuoXueAtt> Zs_GuoXueAtt { get; set; }
        public DbSet<Zs_GuoXueComment> Zs_GuoXueComment { get; set; }
        public DbSet<Zs_Keywords> Zs_Keywords { get; set; }
        public DbSet<Zs_Member> Zs_Member { get; set; }
        public DbSet<Zs_MemorialDay> Zs_MemorialDay { get; set; }
        public DbSet<Zs_NewFriend> Zs_NewFriend { get; set; }
        public DbSet<Zs_Product> Zs_Product { get; set; }
        public DbSet<Zs_ProductAtt> Zs_ProductAtt { get; set; }
        public DbSet<Zs_Project> Zs_Project { get; set; }
        public DbSet<Zs_ProjectAtt> Zs_ProjectAtt { get; set; }
        public DbSet<Zs_ProjectClock> Zs_ProjectClock { get; set; }
        public DbSet<Zs_ProjectComment> Zs_ProjectComment { get; set; }
        public DbSet<Zs_Right> Zs_Right { get; set; }
        public DbSet<Zs_Role> Zs_Role { get; set; }
        public DbSet<Zs_RoleUser> Zs_RoleUser { get; set; }
        public DbSet<Zs_SetNotice> Zs_SetNotice { get; set; }
        public DbSet<Zs_SetPrivacy> Zs_SetPrivacy { get; set; }
        public DbSet<Zs_User> Zs_User { get; set; }
    }
}
