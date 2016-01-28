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
	/// 服务Zs_Friend
	/// </summary>
	public class BZs_Friend : BaseService<Zs_Friend>,IZs_Friend
	{
		public BZs_Friend() : base(RepositoryFactory.DZs_Friend) { }
	} 
}