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
	/// 服务Zs_Project
	/// </summary>
	public class BZs_Project : BaseService<Zs_Project>,IZs_Project
	{
		public BZs_Project() : base(RepositoryFactory.DZs_Project) { }
	} 
}