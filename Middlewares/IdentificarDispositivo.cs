using ChainOfresponsability.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class IdentificarDispositivo : Middleware
    {
        protected override void Execute(AppHttpContext context)
        {
            context["Device"] = context.Context.Request.Headers["app-device"] ?? String.Empty;
            Next(context);
        }
    }
}