using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2016.01.08
    /// 修改：2016.01.08
    /// </remarks>
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static HanHeDbContext GetCurrentContext()
        {
            HanHeDbContext _nContext = CallContext.GetData("HanHeDbContext") as HanHeDbContext;
            if (_nContext == null)
            {
                _nContext = new HanHeDbContext();
                CallContext.SetData("HanHeDbContext", _nContext);
            }
            return _nContext;
        }
    }
}
