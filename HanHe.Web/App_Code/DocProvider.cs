using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace HanHe.Web.App_Code
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiDocAttribute : Attribute
    {
        public string Documentation { get; set; }

        public ApiDocAttribute(string doc)
        {
            Documentation = doc;
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiParameterDocAttribute : Attribute
    {
        public string Parameter { get; set; }
        public string Documentation { get; set; }

        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }
    }
    public class DocProvider : IDocumentationProvider
    {
        public string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            string doc = "";
            var attr = parameterDescriptor.ActionDescriptor
                        .GetCustomAttributes<ApiParameterDocAttribute>()
                        .Where(p => p.Parameter == parameterDescriptor.ParameterName)
                        .FirstOrDefault();
            if (attr != null)
            {
                doc = attr.Documentation;
            }
            return doc;
        }

        public string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            string doc = "";
            var attr = actionDescriptor.GetCustomAttributes<ApiDocAttribute>().FirstOrDefault();
            if (attr != null)
            {
                doc = attr.Documentation;
            }
            return doc;
        }
        public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
        {
            return "";
        }

        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            return "";
        }
    }
}