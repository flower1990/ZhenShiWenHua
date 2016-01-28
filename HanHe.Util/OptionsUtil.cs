using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Util
{
    public static class OptionsUtil
    {
        public const string VirtualDir = "http://192.168.0.197/resource/Uploads/";
        /// <summary>
        /// 图片虚拟目录
        /// </summary>
        public static readonly string VirtualImageDir = string.Format("{0}Images/", VirtualDir);
        /// <summary>
        /// 视频虚拟目录
        /// </summary>
        public static readonly string VirtualVideoDir = string.Format("{0}Videos/", VirtualDir);
        /// <summary>
        /// 音频虚拟目录
        /// </summary>
        public static readonly string VirtualAudioDir = string.Format("{0}Audios/", VirtualDir);
        /// <summary>
        /// 文档虚拟目录
        /// </summary>
        public static readonly string VirtualFileDir = string.Format("{0}Files/", VirtualDir);
        /// <summary>
        /// Flash虚拟目录
        /// </summary>
        public static readonly string VirtualFlashDir = string.Format("{0}Flashs/", VirtualDir);
        /// <summary>
        /// Flash虚拟目录
        /// </summary>
        public static readonly string VirtualDefaultDir = string.Format("{0}Default/", VirtualDir);
        /// <summary>
        /// 根目录
        /// </summary>
        public const string DestDir = @"E:\站点发布\行事历手机应用软件\resource\Uploads\";
        /// <summary>
        /// 图片存放目录
        /// </summary>
        public static readonly string DestImageDir = string.Format(@"{0}Images\", DestDir);
        /// <summary>
        /// 视频存放目录
        /// </summary>
        public static readonly string DestVideoDir = string.Format(@"{0}Videos\", DestDir);
        /// <summary>
        /// 音频存放目录
        /// </summary>
        public static readonly string DestAudioDir = string.Format(@"{0}Audios\", DestDir);
        /// <summary>
        /// Flash存放目录
        /// </summary>
        public static readonly string DestFlashDir = string.Format(@"{0}Flashs\", DestDir);
        /// <summary>
        /// 文档存放目录
        /// </summary>
        public static readonly string DestFileDir = string.Format(@"{0}Files\", DestDir);
        /// <summary>
        /// 文档存放目录
        /// </summary>
        public static readonly string DestDefaultDir = string.Format(@"{0}Default\", DestDir);
    }
}
