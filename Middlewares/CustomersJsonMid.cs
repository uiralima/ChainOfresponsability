using ChainOfresponsability.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class CustomersJsonMid : Middleware
    {
        protected override void Execute(AppHttpContext context)
        {
            context.Context.Response.Write("[{\"id\": 1, \"nome\": \"Nome do cliente 01\"}, {\"id\": 2, \"nome\": \"Nome do cliente 02\"}]");
            Next(context);
        }
    }
}