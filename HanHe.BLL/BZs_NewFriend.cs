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
	/// 服务Zs_NewFriend
	/// </summary>
	public class BZs_NewFriend : BaseService<Zs_NewFriend>,IZs_NewFriend
	{
		public BZs_NewFriend() : base(RepositoryFactory.DZs_NewFriend) { }
	} 
}