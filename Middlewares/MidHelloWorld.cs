using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class MidHelloWorld : Middleware
    {
        public override void Execute(AppHttpContext context)
        {
            context.Context.Response.Write("Hello World");
        }
    }
}