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
	/// 服务Zs_GuoXue
	/// </summary>
	public class BZs_GuoXue : BaseService<Zs_GuoXue>,IZs_GuoXue
	{
		public BZs_GuoXue() : base(RepositoryFactory.DZs_GuoXue) { }
	} 
}