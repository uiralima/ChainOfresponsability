using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    /// <summary>
    /// Classe com o contexto da aplicação, permite a passagem de paramentros entre os passos do Processo
    /// </summary>
    public class AppHttpContext
    {
        private HttpContext _context;
        private Dictionary<string, object> _data = new Dictionary<string, object>();
        private Queue<Middleware> _middleware;

        public AppHttpContext(HttpContext context, IEnumerable<Middleware> middlewares)
        {
            this._context = context;
            this._middleware = new Queue<Middleware>(middlewares);
        }

        public HttpContext Context
        {
            get
            {
                return _context;
            }
        }

        public object this[string key]
        {
            get
            {
                return _data[key];
            }
            set
            {
                if (_data.ContainsKey(key))
                {
                    _data[key] = value;
                }
                else
                {
                    _data.Add(key, value);
                }
            }
        }

        public Middleware Next()
        {
            if (this._middleware.Count > 0)
            {
                return this._middleware.Dequeue();
            }
            else
            {
                return null;
            }
        }

    }
}