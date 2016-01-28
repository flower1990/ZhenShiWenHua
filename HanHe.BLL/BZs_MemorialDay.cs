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
	/// 服务Zs_MemorialDay
	/// </summary>
	public class BZs_MemorialDay : BaseService<Zs_MemorialDay>,IZs_MemorialDay
	{
		public BZs_MemorialDay() : base(RepositoryFactory.DZs_MemorialDay) { }
	} 
}