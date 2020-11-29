using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class MidHelloWorldHtml : Middleware
    {
        protected override void Execute(AppHttpContext context)
        {
            context.Context.Response.Write("<h1>Hello World</h1>");
            Next(context);
        }
    }
}