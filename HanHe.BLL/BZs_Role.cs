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
	/// 服务Zs_Role
	/// </summary>
	public class BZs_Role : BaseService<Zs_Role>,IZs_Role
	{
		public BZs_Role() : base(RepositoryFactory.DZs_Role) { }
	} 
}