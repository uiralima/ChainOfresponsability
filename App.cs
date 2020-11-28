using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    /// <summary>
    /// Classe Singleton responsável pela aplicação
    /// </summary>
    public sealed class App
    {
        private static App _instance = new App();
        private List<MiddlewareContext> _middeware = new List<MiddlewareContext>();
        private IContextBuilder _contextBuilder = null;

        public static App Instance
        {
            get
            {
                return _instance;
            }
        }

        public App SetContextBuilder(IContextBuilder contextBuilder)
        {
            this._contextBuilder = contextBuilder;
            return this;
        }

        #region Facilitadores de criação de middleware
        public App Global(Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "*", "*"));
            return this;
        }

        public App Context(string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "*", "*"));
            return this;
        }

        public App Context(string route, string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "*", route));
            return this;
        }

        public App Set(string context, string httmMethod, string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, httmMethod, route));
            return this;
        }

        public App Get(Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "GET", "*"));
            return this;
        }

        public App Get(string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "GET", route));
            return this;
        }
        public App Post(Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "POST", "*"));
            return this;
        }

        public App Post(string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "POST", route));
            return this;
        }
        
        public App Put(Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "PUT", "*"));
            return this;
        }

        public App Put(string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "PUT", route));
            return this;
        }

        public App Delete(Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "DELETE", "*"));
            return this;
        }

        public App Delete(string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, "*", "DELETE", route));
            return this;
        }

        public App ContextGet(string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "GET", "*"));
            return this;
        }

        public App ContextGet(string context, string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "GET", route));
            return this;
        }
        public App ContextPost(string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "POST", "*"));
            return this;
        }

        public App ContextPost(string context, string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "POST", route));
            return this;
        }

        public App ContextPut(string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "PUT", "*"));
            return this;
        }

        public App ContextPut(string context, string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "PUT", route));
            return this;
        }

        public App ContextDelete(string context, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "DELETE", "*"));
            return this;
        }

        public App ContextDelete(string context, string route, Middleware middleware)
        {
            this._middeware.Add(new MiddlewareContext(middleware, context, "DELETE", route));
            return this;
        }

        #endregion

        public AppHttpContext CreateContext(HttpContext context)
        {
            List<Middleware> middlewares = new List<Middleware>();
            string callContext = "*";
            if (null != this._contextBuilder)
            {
                callContext = this._contextBuilder.Build(context);
            }
            this._middeware.Where(f => f.Match(callContext, context.Request.HttpMethod, context.Request.Path))
                .ToList().ForEach(f => middlewares.Add(f.GetMiddleware()));
            return new AppHttpContext(context, middlewares);
        }

        
    }
}