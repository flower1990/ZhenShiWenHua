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
	/// 服务Zs_Department
	/// </summary>
	public class BZs_Department : BaseService<Zs_Department>,IZs_Department
	{
		public BZs_Department() : base(RepositoryFactory.DZs_Department) { }
	} 
}