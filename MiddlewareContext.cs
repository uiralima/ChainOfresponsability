using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    public class MiddlewareContext
    {
        private string _context;
        private string _httpMethod;
        private string _route;
        private Middleware _middleware;

        public MiddlewareContext(Middleware middleware, string context, string httpMethod, string route)
        {
            this._middleware = middleware;
            this._context = context;
            this._httpMethod = httpMethod;
            this._route = route;
        }

        public Middleware GetMiddleware()
        {
            return this._middleware;
        }

        public bool Match(string context, string httpMethod, string route)
        {
            return (CompareMask(_context, context) && CompareMask(_httpMethod, httpMethod) && CompareMask(_route, route));
        }

        private bool CompareMask(string pattern, string value)
        {
            return (("*" == pattern) || (pattern.Equals(value)));
        }
    }
}