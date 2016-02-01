using HanHe.DAL;
using HanHe.IBLL;
using HanHe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.BLL
{
    /// <summary>
    /// 服务BZs_RoleRight
    /// </summary>
    public class BZs_RoleRight : BaseService<Zs_RoleRight>, IZs_RoleRight
    {
        public BZs_RoleRight() : base(RepositoryFactory.DZs_RoleRight) { }
    } 
}
