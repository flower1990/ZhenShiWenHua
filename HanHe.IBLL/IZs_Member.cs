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
	/// 接口层Zs_Member
	/// </summary>
	public interface IZs_Member : IBaseService<Zs_Member>
	{
        Zs_Member MemberLogin(string loginName);
        /// <summary>
        /// 创建基于声明的标识
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="authenticationType">身份验证类型</param>
        /// <returns>基于声明的标识</returns>
        ClaimsIdentity CreateIdentity(Zs_Member member, string authenticationType);
	} 
}