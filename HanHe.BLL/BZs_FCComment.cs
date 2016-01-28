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
	/// 服务Zs_FCComment
	/// </summary>
	public class BZs_FCComment : BaseService<Zs_FCComment>,IZs_FCComment
	{
		public BZs_FCComment() : base(RepositoryFactory.DZs_FCComment) { }
	} 
}