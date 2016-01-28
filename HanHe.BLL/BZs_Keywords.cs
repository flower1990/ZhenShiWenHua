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
	/// 服务Zs_Keywords
	/// </summary>
	public class BZs_Keywords : BaseService<Zs_Keywords>,IZs_Keywords
	{
		public BZs_Keywords() : base(RepositoryFactory.DZs_Keywords) { }
	} 
}