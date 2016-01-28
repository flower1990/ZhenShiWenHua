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
	/// 服务Zs_FCircle
	/// </summary>
	public class BZs_FCircle : BaseService<Zs_FCircle>,IZs_FCircle
	{
		public BZs_FCircle() : base(RepositoryFactory.DZs_FCircle) { }
	} 
}