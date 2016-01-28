using HanHe.Manage.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanHe.Manage.Models.Repositories
{
    public class RolePropertyRepository
    {
        public List<RoleProperty> RoleProperties()
        {
            return new List<RoleProperty>()
            {
                new RoleProperty{ ID = 0, Name = "普通" },
                new RoleProperty{ ID = 1, Name = "管理员" },
                new RoleProperty{ ID = 2, Name = "信息管理" },
                new RoleProperty{ ID = 3, Name = "财务管理" },
            };
        }
    }
}