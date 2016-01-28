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
	/// 服务Zs_ProjectClock
	/// </summary>
	public class BZs_ProjectClock : BaseService<Zs_ProjectClock>,IZs_ProjectClock
	{
		public BZs_ProjectClock() : base(RepositoryFactory.DZs_ProjectClock) { }
	} 
}