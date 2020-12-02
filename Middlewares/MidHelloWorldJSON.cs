using ChainOfresponsability.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class MidHelloWorldJSON : Middleware
    {
        protected override void Execute(AppHttpContext context)
        {
            context.Context.Response.Write("{ \"message\": \"Hello World\", \"devcice\": \"" + context["Device"] + "\" }");
            Next(context);
        }
    }
}