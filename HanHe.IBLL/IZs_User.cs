using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.Model;
using System.Security.Claims;

namespace HanHe.IBLL
{
	/// <summary>
	/// 接口层Zs_User
	/// </summary>
	public interface IZs_User : IBaseService<Zs_User>
	{
        Zs_User Login(string loginName);
        ClaimsIdentity CreateIdentity(Zs_User user, string authenticationType);
	} 
}