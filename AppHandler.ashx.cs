using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    /// <summary>
    /// Descrição resumida de AppHandler
    /// </summary>
    public class AppHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            AppHttpContext appContext = App.Instance.CreateContext(context);
            var midleware = appContext.Next();
            if (null != midleware)
            {
                midleware.Execute(appContext);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}