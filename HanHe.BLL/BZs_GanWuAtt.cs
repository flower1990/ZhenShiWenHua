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
	/// 服务Zs_GanWuAtt
	/// </summary>
	public class BZs_GanWuAtt : BaseService<Zs_GanWuAtt>,IZs_GanWuAtt
	{
		public BZs_GanWuAtt() : base(RepositoryFactory.DZs_GanWuAtt) { }
	} 
}