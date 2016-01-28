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
	/// 服务Zs_Product
	/// </summary>
	public class BZs_Product : BaseService<Zs_Product>,IZs_Product
	{
		public BZs_Product() : base(RepositoryFactory.DZs_Product) { }
	} 
}