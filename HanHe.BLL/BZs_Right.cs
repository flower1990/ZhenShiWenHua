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
	/// 服务Zs_Right
	/// </summary>
	public class BZs_Right : BaseService<Zs_Right>,IZs_Right
	{
		public BZs_Right() : base(RepositoryFactory.DZs_Right) { }
	} 
}