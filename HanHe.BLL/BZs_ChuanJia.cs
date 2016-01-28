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
	/// 服务Zs_ChuanJia
	/// </summary>
	public class BZs_ChuanJia : BaseService<Zs_ChuanJia>,IZs_ChuanJia
	{
		public BZs_ChuanJia() : base(RepositoryFactory.DZs_ChuanJia) { }
	} 
}