using ChainOfresponsability.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public enum ContextType
    {
        HTML,
        JSON,
        TEXT
    }
    public class MidSetContentType : Middleware
    {
        private ContextType _contentType;
        public MidSetContentType(ContextType contentType)
        {
            this._contentType = contentType;
        }
        protected override void Execute(AppHttpContext context)
        {
            if (this._contentType == ContextType.JSON)
            {
                context.Context.Response.ContentType = "application/json";
            }
            else if (this._contentType == ContextType.HTML)
            {
                context.Context.Response.ContentType = "text/html";
            }
            else
            {
                context.Context.Response.ContentType = "text/text";
            }
            Next(context);
        }
    }
}