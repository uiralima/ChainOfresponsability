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
            return (CompareMask(_context, context) && CompareMask(_httpMethod, httpMethod) && CompareRoute(_route, route));
        }

        private bool CompareMask(string pattern, string value)
        {
            return (("*" == pattern) || (pattern.Equals(value)));
        }

        private string ClearPath(string path)
        {
            var parts = path.Split('/').ToList();
            for(int i = parts.Count-1; i>=0; i--)
            {
                if(String.IsNullOrWhiteSpace(parts[i]))
                {
                    parts.RemoveAt(i);
                }
            }
            return String.Join("/", parts);
        }

        private bool CompareRoute(string pattern, string value)
        {
            if (pattern.Equals("*"))
            {
                return true;
            }
            else
            {
                string[] routeParts = ClearPath(value).Split('/');
                string[] myRoutParts = ClearPath(pattern).Split('/');
                if (routeParts.Length != myRoutParts.Length)
                {
                    return false;
                }
                else
                {
                    for(int i=0; i<myRoutParts.Length; i++)
                    {
                        if (!myRoutParts[i].StartsWith(":"))
                        {
                            if(!CompareMask(myRoutParts[i], routeParts[i]))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
        }
    }
}