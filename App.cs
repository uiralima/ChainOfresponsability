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
        private List<Middleware> _middeware = new List<Middleware>();

        public static App Instance
        {
            get
            {
                return _instance;
            }
        }

        public App Use(Middleware middleware)
        {
            this._middeware.Add(middleware);
            return this;
        }

        public AppHttpContext CreateContext(HttpContext context)
        {
            return new AppHttpContext(context, this._middeware);
        }

        
    }
}