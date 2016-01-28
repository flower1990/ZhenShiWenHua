using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanHe.IBLL;
using HanHe.DAL;
using HanHe.Model;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace HanHe.BLL
{
    public class BZs_User : BaseService<Zs_User>, IZs_User
    {
        public BZs_User() : base(RepositoryFactory.DZs_User) { }

        public Zs_User Login(string loginName)
        {
            var user = new Zs_User();

            user = CurrentRepository.Find(f => f.LoginName == loginName);

            return user;
        }
        /// <summary>
        /// 创建基于声明的标识
        /// </summary>
        /// <param name="user">会员</param>
        /// <param name="authenticationType">身份验证类型</param>
        /// <returns>基于声明的标识</returns>
        public ClaimsIdentity CreateIdentity(Zs_User user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.LoginName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ZsUserID.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.UserNameCn));
            return _identity;
        }
    }
}
