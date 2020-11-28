using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    public class Startup
    {
        public static void ConfigureApp()
        {
            App.Instance
                .Global(new Middlewares.MidSetContentType())
                .Post(new Middlewares.AutenticarUsuario())
                .Global(new Middlewares.CerragarRoles())
                .Global(new Middlewares.IdentificarDispositivo())
                .Global(new Middlewares.MidHelloWorld());
        }

        public static void ProcessRequest()
        {
            AppHttpContext appContext = App.Instance.CreateContext(HttpContext.Current);
            var midleware = appContext.Next();
            if (null != midleware)
            {
                midleware.Execute(appContext);
            }
            HttpContext.Current.Response.End();
        }
    }
}