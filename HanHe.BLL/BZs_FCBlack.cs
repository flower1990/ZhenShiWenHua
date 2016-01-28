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
	/// 服务Zs_FCBlack
	/// </summary>
	public class BZs_FCBlack : BaseService<Zs_FCBlack>,IZs_FCBlack
	{
		public BZs_FCBlack() : base(RepositoryFactory.DZs_FCBlack) { }
	} 
}