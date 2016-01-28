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
	/// 服务Zs_GuoXueAtt
	/// </summary>
	public class BZs_GuoXueAtt : BaseService<Zs_GuoXueAtt>,IZs_GuoXueAtt
	{
		public BZs_GuoXueAtt() : base(RepositoryFactory.DZs_GuoXueAtt) { }
	} 
}