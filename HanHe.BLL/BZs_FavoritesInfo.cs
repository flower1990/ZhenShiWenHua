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
	/// 服务Zs_FavoritesInfo
	/// </summary>
	public class BZs_FavoritesInfo : BaseService<Zs_FavoritesInfo>,IZs_FavoritesInfo
	{
		public BZs_FavoritesInfo() : base(RepositoryFactory.DZs_FavoritesInfo) { }
	} 
}