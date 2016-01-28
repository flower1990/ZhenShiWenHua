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
	/// 服务Zs_FCAtt
	/// </summary>
	public class BZs_FCAtt : BaseService<Zs_FCAtt>,IZs_FCAtt
	{
		public BZs_FCAtt() : base(RepositoryFactory.DZs_FCAtt) { }
	} 
}