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
	/// 服务Zs_ProjectComment
	/// </summary>
	public class BZs_ProjectComment : BaseService<Zs_ProjectComment>,IZs_ProjectComment
	{
		public BZs_ProjectComment() : base(RepositoryFactory.DZs_ProjectComment) { }
	} 
}