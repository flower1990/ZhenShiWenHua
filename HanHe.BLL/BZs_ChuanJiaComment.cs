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
	/// 服务Zs_ChuanJiaComment
	/// </summary>
	public class BZs_ChuanJiaComment : BaseService<Zs_ChuanJiaComment>,IZs_ChuanJiaComment
	{
		public BZs_ChuanJiaComment() : base(RepositoryFactory.DZs_ChuanJiaComment) { }
	} 
}