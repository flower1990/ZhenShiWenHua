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
	/// 服务Zs_FGroup
	/// </summary>
	public class BZs_FGroup : BaseService<Zs_FGroup>,IZs_FGroup
	{
		public BZs_FGroup() : base(RepositoryFactory.DZs_FGroup) { }
	} 
}