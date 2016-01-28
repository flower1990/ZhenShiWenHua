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
	/// 服务Zs_ProjectAtt
	/// </summary>
	public class BZs_ProjectAtt : BaseService<Zs_ProjectAtt>,IZs_ProjectAtt
	{
		public BZs_ProjectAtt() : base(RepositoryFactory.DZs_ProjectAtt) { }
	} 
}