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
	/// 服务Zs_GanWu
	/// </summary>
	public class BZs_GanWu : BaseService<Zs_GanWu>,IZs_GanWu
	{
		public BZs_GanWu() : base(RepositoryFactory.DZs_GanWu) { }
	} 
}