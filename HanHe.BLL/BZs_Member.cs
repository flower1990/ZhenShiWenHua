using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.Model;
using HanHe.IBLL;
using HanHe.DAL;
using System.Text.RegularExpressions;
using HanHe.Util;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace HanHe.BLL
{
    /// <summary>
    /// 服务Zs_Member
    /// </summary>
    public class BZs_Member : BaseService<Zs_Member>, IZs_Member
    {
        public BZs_Member() : base(RepositoryFactory.DZs_Member) { }

        public Zs_Member MemberLogin(string loginName)
        {
            Regex regexMobile = new Regex(RegxUtil.Regx7);
            Regex regexEmail = new Regex(RegxUtil.Regx6);
            var member = new Zs_Member();

            if (regexMobile.IsMatch(loginName))
            {
                member = CurrentRepository.Find(f => f.Mobile == loginName);
            }
            else if (regexEmail.IsMatch(loginName))
            {
                member = CurrentRepository.Find(f => f.Email == loginName);
            }

            return member;
        }
        /// <summary>
        /// 创建基于声明的标识
        /// </summary>
        /// <param name="member">会员</param>
        /// <param name="authenticationType">身份验证类型</param>
        /// <returns>基于声明的标识</returns>
        public ClaimsIdentity CreateIdentity(Zs_Member member, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, member.Mobile));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, member.MID.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", member.NickName));
            return _identity;
        }
    }
}