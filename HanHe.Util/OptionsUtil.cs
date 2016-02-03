using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Util
{
    public static class OptionsUtil
    {
        public const string VirtualDir = "http://img.hanhekeji.net/upload/";
        /// <summary>
        /// 图片虚拟目录
        /// </summary>
        public static readonly string VirtualImageDir = string.Format("{0}image/", VirtualDir);
        /// <summary>
        /// 视频虚拟目录
        /// </summary>
        public static readonly string VirtualVideoDir = string.Format("{0}video/", VirtualDir);
        /// <summary>
        /// 音频虚拟目录
        /// </summary>
        public static readonly string VirtualAudioDir = string.Format("{0}audio/", VirtualDir);
        /// <summary>
        /// 文档虚拟目录
        /// </summary>
        public static readonly string VirtualFileDir = string.Format("{0}file/", VirtualDir);
        /// <summary>
        /// Flash虚拟目录
        /// </summary>
        public static readonly string VirtualFlashDir = string.Format("{0}flash/", VirtualDir);
        /// <summary>
        /// Flash虚拟目录
        /// </summary>
        public static readonly string VirtualDefaultDir = string.Format("{0}default/", VirtualDir);
        /// <summary>
        /// 根目录
        /// </summary>
        public const string DestDir = @"F:\ZhenShi\resource\upload\";
        /// <summary>
        /// 图片存放目录
        /// </summary>
        public static readonly string DestImageDir = string.Format(@"{0}image\", DestDir);
        /// <summary>
        /// 视频存放目录
        /// </summary>
        public static readonly string DestVideoDir = string.Format(@"{0}video\", DestDir);
        /// <summary>
        /// 音频存放目录
        /// </summary>
        public static readonly string DestAudioDir = string.Format(@"{0}audio\", DestDir);
        /// <summary>
        /// Flash存放目录
        /// </summary>
        public static readonly string DestFlashDir = string.Format(@"{0}flash\", DestDir);
        /// <summary>
        /// 文档存放目录
        /// </summary>
        public static readonly string DestFileDir = string.Format(@"{0}file\", DestDir);
        /// <summary>
        /// 文档存放目录
        /// </summary>
        public static readonly string DestDefaultDir = string.Format(@"{0}default\", DestDir);
    }
}
