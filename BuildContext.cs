using ChainOfresponsability.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    public class BuildContext : IContextBuilder
    {
        public string Build(HttpContext context)
        {
            if (null != context.Request.Headers["app-context"])
            {
                return context.Request.Headers["app-context"];
            }
            else
            {
                return "site";
            }
        }
    }
}