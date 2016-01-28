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
	/// 服务Zs_ChuanJiaAtt
	/// </summary>
	public class BZs_ChuanJiaAtt : BaseService<Zs_ChuanJiaAtt>,IZs_ChuanJiaAtt
	{
		public BZs_ChuanJiaAtt() : base(RepositoryFactory.DZs_ChuanJiaAtt) { }
	} 
}