using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;

namespace HanHe.Util
{
    public class ComFunUtil
    {
        public static T FillEntity<T>(T t, NameValueCollection request) where T : class,new()
        {
            Type type = t.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var item in props)
            {
                string ItemAttr = request[item.Name];
                if (!IsBaseType(item.PropertyType))
                {
                    continue;
                }
                if (ItemAttr == null)
                {
                    continue;
                }
                if (item.CanWrite)
                {

                    item.SetValue(t, GetValue(ItemAttr, item.PropertyType), null);
                }
            }
            return t;
        }
        public static object GetValue(string value, Type type)
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
        public static bool IsBaseType(Type type)
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
    }
}
