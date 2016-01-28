using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HanHe.Web.App_Start
{
    public class UploadHelper
    {
        public async Task<Hashtable> UploadImage(int fileType, HttpRequestMessage request)
        {
            // 检查是否是 multipart/form-data 
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //文件保存目录路径
            String dirTempPath = GetDestDir(fileType);
            // 设置上传目录 
            var provider = new MultipartFormDataStreamProvider(dirTempPath);
            await request.Content.ReadAsMultipartAsync(provider);

            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["errmsg"] = "上传出错";
            var file = provider.FileData[0];//provider.FormData 
            string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
            FileInfo fileinfo = new FileInfo(file.LocalFileName);
            //最大文件大小 
            int maxSize = 10000000;
            if (fileinfo.Length <= 0)
            {
                hash["error"] = 1;
                hash["errmsg"] = "请选择上传文件。";
            }
            else if (fileinfo.Length > maxSize)
            {
                hash["error"] = 1;
                hash["errmsg"] = "上传文件大小超过限制。";
            }
            else
            {
                string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));
                //定义允许上传的文件扩展名 
                String fileTypes = "gif,jpg,jpeg,png,bmp";
                if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                {
                    hash["error"] = 1;
                    hash["errmsg"] = "上传文件扩展名是不允许的扩展名。";
                }
                else
                {
                    String ymd = DateTime.Now.ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    String destFileName = Path.Combine(dirTempPath, newFileName + fileExt);
                    fileinfo.CopyTo(destFileName, true);
                    fileinfo.Delete();
                    hash["error"] = 0;
                    hash["errmsg"] = "上传成功";
                    hash["VirtualPath"] = GetVirtualDir(fileType) + newFileName;
                }
            }

            return hash;
        }
        public async Task<Hashtable> UploadFiles<T>(int fileType, HttpRequestMessage request, T t)
        {
            Hashtable hash = new Hashtable();
            // 检查是否是 multipart/form-data 
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //文件保存目录路径
            String dirTempPath = GetDestDir(fileType);
            // 设置上传目录 
            var provider = new MultipartFormDataStreamProvider(dirTempPath);
            await request.Content.ReadAsMultipartAsync(provider);
            var _member = new Zs_Member();

            Type type = t.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var item in props)
            {
                string ItemAttr = provider.FormData[item.Name];
                if (!ComFunUtil.IsBaseType(item.PropertyType))
                {
                    continue;
                }
                if (ItemAttr == null)
                {
                    continue;
                }
                if (item.CanWrite)
                {

                    item.SetValue(t, ComFunUtil.GetValue(ItemAttr, item.PropertyType), null);
                }
            }
            hash["entity"] = t;

            foreach (var file in provider.FileData)
            {
                hash["error"] = 1;
                hash["errmsg"] = "上传出错";
                string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                FileInfo fileinfo = new FileInfo(file.LocalFileName);
                //最大文件大小 
                int maxSize = 10000000;
                if (fileinfo.Length <= 0)
                {
                    hash["error"] = 1;
                    hash["errmsg"] = "请选择上传文件。";
                }
                else if (fileinfo.Length > maxSize)
                {
                    hash["error"] = 1;
                    hash["errmsg"] = "上传文件大小超过限制。";
                }
                else
                {
                    string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));
                    //定义允许上传的文件扩展名 
                    String fileTypes = "gif,jpg,jpeg,png,bmp";
                    if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                    {
                        hash["error"] = 1;
                        hash["errmsg"] = "上传文件扩展名是不允许的扩展名。";
                    }
                    else
                    {
                        String ymd = DateTime.Now.ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        String destFileName = Path.Combine(dirTempPath, newFileName + fileExt);
                        fileinfo.CopyTo(destFileName, true);
                        fileinfo.Delete();
                        hash["error"] = 0;
                        hash["errmsg"] = "上传成功";
                        hash["VirtualPath"] = GetVirtualDir(fileType) + newFileName;
                    }
                }
            }

            return hash;
        }
        /// <summary>
        /// 获取文件存放目录
        /// </summary>
        /// <param name="fileType">1.图片2.视频3.音频4.文档5.flash</param>
        /// <returns></returns>
        public string GetDestDir(int fileType)
        {
            string dirTempPath = string.Empty;

            switch (fileType)
            {
                case 1:
                    dirTempPath = OptionsUtil.DestImageDir;
                    break;
                case 2:
                    dirTempPath = OptionsUtil.DestVideoDir;
                    break;
                case 3:
                    dirTempPath = OptionsUtil.DestAudioDir;
                    break;
                case 4:
                    dirTempPath = OptionsUtil.DestFileDir;
                    break;
                case 5:
                    dirTempPath = OptionsUtil.DestFlashDir;
                    break;
                default:
                    break;
            }

            if (!Directory.Exists(dirTempPath))
                Directory.CreateDirectory(dirTempPath);

            return dirTempPath;
        }
        /// <summary>
        /// 获取文件虚拟目录
        /// </summary>
        /// <param name="fileType">1.图片2.视频3.音频4.文档5.flash</param>
        /// <returns></returns>
        public string GetVirtualDir(int fileType)
        {
            string dirTempPath = string.Empty;

            switch (fileType)
            {
                case 1:
                    dirTempPath = OptionsUtil.VirtualImageDir;
                    break;
                case 2:
                    dirTempPath = OptionsUtil.VirtualVideoDir;
                    break;
                case 3:
                    dirTempPath = OptionsUtil.VirtualAudioDir;
                    break;
                case 4:
                    dirTempPath = OptionsUtil.VirtualFileDir;
                    break;
                case 5:
                    dirTempPath = OptionsUtil.VirtualFlashDir;
                    break;
                default:
                    break;
            }

            return dirTempPath;
        }
    }
}