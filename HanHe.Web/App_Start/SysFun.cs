using HanHe.Model;
using HanHe.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HanHe.Web
{
    public class PropertyMapper
    {
        public PropertyInfo SourceProperty { get; set; }
        public PropertyInfo TargetProperty { get; set; }
    }
    public class FileDataInfo
    {
        public int AttType { get; set; }
        public string AttTitle { get; set; }
        public string AttUrl { get; set; }
        public string AttInfo { get; set; }
    }
    public class SysFun
    {
        private static SysFun _instance;
        public static SysFun Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SysFun();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Hashtable> GetFormData(HttpRequestMessage request)
        {
            Hashtable hash = new Hashtable();
            Dictionary<string, string> dicFormData = new Dictionary<string, string>();
            List<FileDataInfo> fileList = new List<FileDataInfo>();

            // 检查是否是 multipart/form-data
            if (!request.Content.IsMimeMultipartContent()) throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            // 提供程序
            var provider = new MultipartFormDataMemoryStreamProvider();
            //读取MIME消息
            await request.Content.ReadAsMultipartAsync(provider);
            //遍历文件内容
            foreach (var fileContent in provider.FileContents)
            {
                //原始文件名
                string orfilename = fileContent.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                if (string.IsNullOrEmpty(orfilename)) continue;
                //文件名称
                string fileName = Path.GetFileNameWithoutExtension(orfilename);
                //文件扩展名
                string fileExt = Path.GetExtension(orfilename);
                //文件类型1.图片2.视频3.音频4.文档5.flash
                string fileType = GetFileType(orfilename);
                //文件标题
                string fileTitle = GetFileTitle(fileName);
                //文件保存目录路径
                string dirTempPath = GetDestDir(fileType);
                //文件url路径
                string urlTempPath = GetVirtualDir(fileType);
                //新文件名
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                //保存文件路径
                string destFileName = Path.Combine(dirTempPath, newFileName + fileExt);
                //文件url
                string urlFileName = urlTempPath + newFileName + fileExt;
                //内容写入流
                var stream = await fileContent.ReadAsStreamAsync();
                //保存到指定路径
                using (StreamWriter sw = new StreamWriter(destFileName)) { stream.CopyTo(sw.BaseStream); sw.Flush(); }
                //添加到文件集合
                fileList.Add(new FileDataInfo() 
                { 
                    AttType = int.Parse(fileType), 
                    AttTitle = fileTitle, 
                    AttUrl = urlFileName, 
                    AttInfo = "" 
                });
            }
            //遍历表单数据
            foreach (var key in provider.FormData.AllKeys)
            {
                foreach (var val in provider.FormData.GetValues(key))
                {
                    dicFormData.Add(key, val);
                }
            }

            hash["FormData"] = dicFormData;
            hash["FileData"] = fileList;
            return hash;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Hashtable> UploadImage(int fileType, HttpRequestMessage request)
        {
            // 检查是否是 multipart/form-data 
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //文件保存目录路径
            String dirTempPath = GetDestDir("");
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
                    hash["url"] = GetVirtualDir("") + newFileName;
                }
            }

            return hash;
        }
        /// <summary>
        /// 初始化实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public T InitialEntity<T>(T t, Dictionary<string, string> dic)
        {
            Type type = t.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var item in props)
            {
                if (!IsBaseType(item.PropertyType)) continue;
                if (!dic.ContainsKey(item.Name)) continue;

                string ItemAttr = dic[item.Name];
                if (string.IsNullOrEmpty(ItemAttr)) continue;

                if (item.CanWrite)
                {
                    item.SetValue(t, GetValue(ItemAttr, item.PropertyType), null);
                }
            }
            return t;
        }
        /// <summary>
        /// 初始化实体类
        /// </summary>
        /// <typeparam name="S">源类型</typeparam>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="s">源实体</param>
        /// <param name="t">目标实体</param>
        /// <returns></returns>
        public T InitialEntity<S, T>(S s, T t)
        {
            IList<PropertyMapper> mapperProperties = GetMapperProperties(s.GetType(), t.GetType());

            foreach (var item in mapperProperties)
            {
                var sourceValue = item.SourceProperty.GetValue(s);
                item.TargetProperty.SetValue(t, sourceValue);
            }

            return t;
        }
        /// <summary>
        /// 获取映射器属性
        /// </summary>
        /// <param name="sourceType">源类型</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>属性列表</returns>
        public IList<PropertyMapper> GetMapperProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            return (from s in sourceProperties
                    from t in targetProperties
                    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                    select new PropertyMapper { SourceProperty = s, TargetProperty = t }).ToList();
        }
        /// <summary>
        /// 获取文件存放目录
        /// </summary>
        /// <param name="fileType">1.图片2.视频3.音频4.文档5.flash</param>
        /// <returns></returns>
        public string GetDestDir(string fileType)
        {
            string dirTempPath = string.Empty;

            switch (fileType.ToLower())
            {
                case "1":
                    dirTempPath = OptionsUtil.DestImageDir;
                    break;
                case "2":
                    dirTempPath = OptionsUtil.DestVideoDir;
                    break;
                case "3":
                    dirTempPath = OptionsUtil.DestAudioDir;
                    break;
                case "4":
                    dirTempPath = OptionsUtil.DestFileDir;
                    break;
                case "5":
                    dirTempPath = OptionsUtil.DestFlashDir;
                    break;
                default:
                    dirTempPath = OptionsUtil.DestDefaultDir;
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
        public string GetVirtualDir(string fileType)
        {
            string dirTempPath = string.Empty;

            switch (fileType)
            {
                case "1":
                    dirTempPath = OptionsUtil.VirtualImageDir;
                    break;
                case "2":
                    dirTempPath = OptionsUtil.VirtualVideoDir;
                    break;
                case "3":
                    dirTempPath = OptionsUtil.VirtualAudioDir;
                    break;
                case "4":
                    dirTempPath = OptionsUtil.VirtualFileDir;
                    break;
                case "5":
                    dirTempPath = OptionsUtil.VirtualFlashDir;
                    break;
                default:
                    dirTempPath = OptionsUtil.VirtualDefaultDir;
                    break;
            }

            return dirTempPath;
        }
        /// <summary>
        /// 初始化值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object GetValue(string value, Type type)
        {
            object result = null;
            if (type == typeof(Int32))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToInt32(value);
            }
            if (type == typeof(String))
            {
                result = value;
            }
            if (type == typeof(Boolean))
            {
                result = Convert.ToBoolean(value);
            }
            if (type.Equals(typeof(int)))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToInt32(value);
            }
            if (type.Equals(typeof(Int64)))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToInt64(value);
            }
            if (type.Equals(typeof(string)))
            {
                result = value;
            }
            if (type.Equals(typeof(String)))
            {
                result = value;
            }
            if (type.Equals(typeof(bool)))
            {
                result = Convert.ToBoolean(value);
            }
            if (type.Equals(typeof(DateTime)))
            {
                result = Convert.ToDateTime(value);
            }
            if (type.Equals(typeof(double)))
            {
                result = Convert.ToDouble(value);
            }
            if (type.Equals(typeof(float)))
            {
                result = Convert.ToDouble(value);
            }
            if (type.Equals(typeof(decimal)))
            {
                result = Convert.ToDecimal(value);
            }
            if (type.Equals(typeof(Decimal)))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToDecimal(value);
            }
            if (type.Equals(typeof(double)))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToDouble(value);
            }
            if (type.Equals(typeof(Double)))
            {
                if (value == "")
                {
                    value = "0";
                }
                result = Convert.ToDouble(value);
            }
            if (type.Equals(typeof(char)))
            {
                result = Convert.ToChar(value);
            }
            if (type.Equals(typeof(Char)))
            {
                result = Convert.ToChar(value);
            }
            if (type.Equals(typeof(Guid)))
            {
                result = value;
            }
            return result;
        }
        /// <summary>
        /// 判断是否基本数据类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsBaseType(Type type)
        {
            bool rebool = false;
            if (type.Equals(typeof(int)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Int32)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Int64)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(string)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(String)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(bool)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Boolean)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(DateTime)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(float)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(decimal)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Decimal)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(char)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Char)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Guid)))
            {
                rebool = true;
            }
            return rebool;
        }
        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="orfilename"></param>
        /// <returns></returns>
        private string GetFileType(string orfilename)
        {
            string fileType = string.Empty;
            string[] typeList = orfilename.Split('_');
            if (typeList.Length == 1) return fileType = "0";
            fileType = typeList[0];
            return fileType;
        }
        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="orfilename"></param>
        /// <returns></returns>
        private string GetFileTitle(string orfilename)
        {
            string fileTitle = string.Empty;
            string[] typeList = orfilename.Split('_');
            if (typeList.Length < 2) return fileTitle;
            fileTitle = typeList[1];
            return fileTitle;
        }
        /// <summary>
        /// 删除本地附件
        /// </summary>
        /// <param name="attType">附件类型</param>
        /// <param name="attUrl">附件地址</param>
        public void DeleteFile(int attType, string attUrl)
        {
            var filePath = GetDestDir(attType.ToString()) + Path.GetFileName(attUrl);
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}