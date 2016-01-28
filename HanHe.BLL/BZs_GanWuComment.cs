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
	/// 服务Zs_GanWuComment
	/// </summary>
	public class BZs_GanWuComment : BaseService<Zs_GanWuComment>,IZs_GanWuComment
	{
		public BZs_GanWuComment() : base(RepositoryFactory.DZs_GanWuComment) { }
	} 
}