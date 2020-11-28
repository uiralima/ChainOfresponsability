using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class MidSetContentType : Middleware
    {

        public override void Execute(AppHttpContext context)
        {
            context.Context.Response.ContentType = "text/html";
            Next(context);
        }
    }
}