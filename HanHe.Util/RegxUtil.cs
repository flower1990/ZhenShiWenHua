using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.Util
{
    public static class RegxUtil
    {
        /// <summary>
        /// 汉字
        /// </summary>
        public const string Regx1 = @"^[\u4e00-\u9fa5]{0,}$";
        /// <summary>
        /// 英文和数字
        /// </summary>
        public const string Regx2 = @"^[A-Za-z0-9]+$";
        /// <summary>
        /// 中文、英文、数字但不包括下划线等符号
        /// </summary>
        public const string Regx3 = @"^[\u4E00-\u9FA5A-Za-z0-9]+$";
        /// <summary>
        /// 中文、英文、数字包括下划线
        /// </summary>
        public const string Regx4 = @"^[\u4E00-\u9FA5A-Za-z0-9_]+$";
        /// <summary>
        /// 数字
        /// </summary>
        public const string Regx5 = @"^[0-9]*$";
        /// <summary>
        /// 邮箱
        /// </summary>
        public const string Regx6 = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        /// <summary>
        /// 电话
        /// </summary>
        public const string Regx7 = @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";
        public const string Regx8 = @"";
        public const string Regx9 = @"";
        public const string Regx10 = @"";
        public const string Regx11 = @"";
        public const string Regx12 = @"";
        public const string Regx13 = @"";
        public const string Regx14 = @"";
        public const string Regx15 = @"";
        public const string Regx16 = @"";

    }
}
