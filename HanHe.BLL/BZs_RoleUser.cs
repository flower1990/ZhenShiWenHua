using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.Model;
using HanHe.IBLL;
using HanHe.DAL;

namespace HanHe.BLL
{
	/// <summary>
	/// 服务Zs_RoleUser
	/// </summary>
	public class BZs_RoleUser : BaseService<Zs_RoleUser>,IZs_RoleUser
	{
		public BZs_RoleUser() : base(RepositoryFactory.DZs_RoleUser) { }
	} 
}