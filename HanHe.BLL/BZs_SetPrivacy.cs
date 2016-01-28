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
	/// 服务Zs_SetPrivacy
	/// </summary>
	public class BZs_SetPrivacy : BaseService<Zs_SetPrivacy>,IZs_SetPrivacy
	{
		public BZs_SetPrivacy() : base(RepositoryFactory.DZs_SetPrivacy) { }
	} 
}