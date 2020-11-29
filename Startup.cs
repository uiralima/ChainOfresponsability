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
                .SetContextBuilder(new BuildContext())
                .Global(new Middlewares.IdentificarDispositivo());

            App.Instance
                .Context("api", new Middlewares.MidSetContentType(Middlewares.ContextType.JSON))
                .ContextGet("api", "/customers", new Middlewares.CustomersJsonMid())
                .Context("api", "/", new Middlewares.MidHelloWorldJSON());


            App.Instance
                .Context("site", new Middlewares.MidSetContentType(Middlewares.ContextType.HTML))
                .Context("site", new Middlewares.MidHelloWorldHtml());

        }

        public static void ProcessRequest()
        {
            AppHttpContext appContext = App.Instance.CreateContext(HttpContext.Current);
            var midleware = appContext.Next();
            if (null != midleware)
            {
                try
                {
                    midleware.Act(appContext);
                }
                catch(Exception ex)
                {
                    HttpContext.Current.Response.StatusCode = 500;
                }
            }
            else
            {
                HttpContext.Current.Response.StatusCode = 404;
            }
            HttpContext.Current.Response.End();
        }
    }
}