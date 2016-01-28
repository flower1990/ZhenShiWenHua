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
	/// 服务Zs_GuoXueComment
	/// </summary>
	public class BZs_GuoXueComment : BaseService<Zs_GuoXueComment>,IZs_GuoXueComment
	{
		public BZs_GuoXueComment() : base(RepositoryFactory.DZs_GuoXueComment) { }
	} 
}