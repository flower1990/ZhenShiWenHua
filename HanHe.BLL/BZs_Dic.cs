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
	/// 服务Zs_Dic
	/// </summary>
	public class BZs_Dic : BaseService<Zs_Dic>,IZs_Dic
	{
		public BZs_Dic() : base(RepositoryFactory.DZs_Dic) { }
	} 
}