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
	/// 服务Zs_ProductAtt
	/// </summary>
	public class BZs_ProductAtt : BaseService<Zs_ProductAtt>,IZs_ProductAtt
	{
		public BZs_ProductAtt() : base(RepositoryFactory.DZs_ProductAtt) { }
	} 
}