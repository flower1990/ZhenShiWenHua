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
	/// 服务Zs_SetNotice
	/// </summary>
	public class BZs_SetNotice : BaseService<Zs_SetNotice>,IZs_SetNotice
	{
		public BZs_SetNotice() : base(RepositoryFactory.DZs_SetNotice) { }
	} 
}