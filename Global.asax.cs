using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ChainOfresponsability
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Startup.ConfigureApp();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Startup.ProcessRequest();
        }
    }

    public class InitApp 
    {
        public InitApp()
        {

        }
        
    }
}