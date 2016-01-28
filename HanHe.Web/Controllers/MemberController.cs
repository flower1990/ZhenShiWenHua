﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using HanHe.Web.Models;
using HanHe.Web.Providers;
using HanHe.Web.Results;
using HanHe.BLL;
using HanHe.IBLL;
using HanHe.Model;
using HanHe.Util;
using System.Collections;
using System.Web;
using System.IO;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.Text;

namespace HanHe.Web.Controllers
{
    /// <summary>
    /// 会员信息
    /// </summary>
    [RoutePrefix("api/Members")]
    public class MemberController : ApiController
    {
        SysFun sysFun = new SysFun();
        IZs_Member bMember = new BZs_Member();
        private IAuthenticationManager AuthenticationManager { get { return Request.GetOwinContext().Authentication; } }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("Login")]
        public IHttpActionResult Login([FromBody]LoginModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();

            member = bMember.MemberLogin(model.Account);
            if (member == null)
            {
                message = string.Format("账号 {0} 不存在", model.Account);
                return Ok(message);
            }
            else if (!member.DelStatus)
            {
                message = string.Format("账号 {0} 已删除", model.Account);
                return Ok(message);
            }
            else if (member.Pwd != StringUtil.EncodeString(model.Password, StringUtil.GetPwdKey(member.MChar.ToString())))
            {
                message = string.Format("密码输入错误");
                return Ok(message);
            }

            //identity = bMember.CreateIdentity(member, DefaultAuthenticationTypes.ApplicationCookie);
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);

            return Ok(member);
        }
        /// <summary>
        /// QQ登录
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("LoginByQQ")]
        public IHttpActionResult LoginByQQ([FromBody]LoginByQQModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();

            if (bMember.Exist(f => f.QQOpenID == model.QQOpenID))
            {
                member = bMember.Find(f => f.QQOpenID == model.QQOpenID);
                return Ok(member);
            }

            member.MChar = StringUtil.GetGUID();
            member.QQOpenID = model.QQOpenID;
            member.NickName = model.NickName;
            member.MStatus = 1;
            member = bMember.Add(member);

            if (member.MID > 0)
            {
                return Ok(member);
            }
            else
            {
                message = "注册失败";
                return Ok(message);
            }
        }
        /// <summary>
        /// 微信登录
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("LoginByWeiXin")]
        public IHttpActionResult LoginByWeiXin([FromBody]LoginByWeiXinModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();

            if (bMember.Exist(f => f.WeiXinOpenID == model.WeiXinOpenID))
            {
                member = bMember.Find(f => f.WeiXinOpenID == model.WeiXinOpenID);
                return Ok(member);
            }

            member.MChar = StringUtil.GetGUID();
            member.WeiXinOpenID = model.WeiXinOpenID;
            member.NickName = model.NickName;
            member.MStatus = 1;
            member = bMember.Add(member);

            if (member.MID > 0)
            {
                return Ok(member);
            }
            else
            {
                message = "注册失败";
                return Ok(message);
            }
        }
        /// <summary>
        /// 新浪登录
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("LoginBySina")]
        public IHttpActionResult LoginBySina([FromBody]LoginBySinaModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();

            if (bMember.Exist(f => f.SinaOpenID == model.SinaOpenID))
            {
                member = bMember.Find(f => f.SinaOpenID == model.SinaOpenID);
                return Ok(member);
            }

            member.MChar = StringUtil.GetGUID();
            member.SinaOpenID = model.SinaOpenID;
            member.NickName = model.NickName;
            member.MStatus = 1;
            member = bMember.Add(member);

            if (member.MID > 0)
            {
                return Ok(member);
            }
            else
            {
                message = "注册失败";
                return Ok(message);
            }
        }
        /// <summary>
        /// 手机注册
        /// </summary>
        /// <param name="model">注册信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("RegisterByMobile")]
        public IHttpActionResult RegisterByMobile([FromBody]RegisterMobileModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();
            var dicMessage = new Dictionary<string, string>();

            if (bMember.Exist(f => f.Mobile == model.Mobile))
            {
                message = string.Format("手机号 {0} 已注册", model.Mobile);
                dicMessage.Add(model.Mobile, message);
                return Ok(dicMessage);
            }

            member.MChar = StringUtil.GetGUID();
            member.MCode = model.Mobile;
            member.NickName = model.NickName;
            member.Pwd = StringUtil.EncodeString(model.Pwd, StringUtil.GetPwdKey(member.MChar.ToString()));
            member.Mobile = model.Mobile;
            member = bMember.Add(member);

            if (member.MID > 0)
            {
                //identity = bMember.CreateIdentity(member, DefaultAuthenticationTypes.ApplicationCookie);
                //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                //AuthenticationManager.SignIn(identity);
                return Ok(member);
            }
            else
            {
                return Ok("注册失败");
            }

        }
        /// <summary>
        /// 邮箱注册
        /// </summary>
        /// <param name="model">注册信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("RegisterByEmail")]
        public IHttpActionResult RegisterByEmail([FromBody]RegisterEmailModel model)
        {
            var message = string.Empty;
            var member = new Zs_Member();
            var identity = new ClaimsIdentity();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (bMember.Exist(f => f.Mobile == model.Email))
            {
                message = string.Format("邮箱 {0} 已注册", model.Email);
                return BadRequest(message);
            }

            member.Mobile = model.Email;
            member.Pwd = model.Password;
            member.NickName = model.UserName;
            member.MStatus = 1;
            member.CreateDate = DateTime.Now;

            member = bMember.Add(member);
            if (member.MID > 0)
            {
                identity = bMember.CreateIdentity(member, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(identity);
            }
            else
            {
                message = "注册失败";
                return BadRequest(message);
            }

            return Ok(member);
        }
        /// <summary>
        /// 完善会员资料
        /// </summary>
        /// <param name="model">会员信息</param>
        /// <returns>会员信息</returns>
        [HttpPost, Route("UpdateMember")]
        public async Task<IHttpActionResult> UpdateMember([FromBody]UpdateMemberModel model)
        {
            long id = 0;
            var updateResult = false;
            var member = new Zs_Member();
            var hashTable = new Hashtable();
            var formData = new Dictionary<string, string>();
            var fileData = new List<FileDataInfo>();

            //获取表单数据
            hashTable = await sysFun.GetFormData(Request);
            formData = hashTable["FormData"] as Dictionary<string, string>;
            fileData = hashTable["FileData"] as List<FileDataInfo>;
            //初始化实体
            if (formData.ContainsKey("MID")) id = long.Parse(formData["MID"]);
            member = bMember.Find(id);
            member = sysFun.InitialEntity<Zs_Member>(member, formData);
            member.UpdateDate = DateTime.Now;
            if (fileData.Count != 0)
            {
                member.IconUrl = fileData[0].AttUrl;
                sysFun.DeleteFile(fileData[0].AttType, fileData[0].AttUrl);
            }
            updateResult = bMember.Update(member);
            //更新会员信息
            if (!updateResult) return Ok("更新失败");

            return Ok(member);
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>手机号和验证码</returns>
        [HttpGet, Route("GetVerificationCode")]
        public HttpResponseMessage GetVerificationCode(string mobile)
        {
            if (bMember.Exist(f => f.Mobile == mobile))
            {
                var message = string.Format("手机号 {0} 已注册", mobile);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
            }

            var code = SecurityUtil.CreateVerificationText(6);
            var resp = new HttpResponseMessage();
            var nv = new NameValueCollection();
            nv["Code"] = code;
            nv["Mobile"] = mobile;

            var cookie = new CookieHeaderValue("session", nv);
            cookie.Expires = DateTimeOffset.Now.AddMinutes(10);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        [HttpGet, Route("ValVerificationCode")]
        public IHttpActionResult ValVerificationCode(string mobile, string code)
        {
            var valcode = string.Empty;
            var phonenum = string.Empty;

            CookieHeaderValue cookie = Request.Headers.GetCookies("session").FirstOrDefault();
            if (cookie != null)
            {
                CookieState cookieState = cookie["session"];
                code = cookieState["Code"];
                phonenum = cookieState["Mobile"];
            }

            if (phonenum != mobile || valcode != code) return BadRequest("验证码输入错误");

            return Ok();
        }
    }
}
