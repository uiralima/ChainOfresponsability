using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability
{
    public class Start
    {
        public static void StartApp()
        {
            App.Instance
                .Use(new Middlewares.MidSetContentType())
                .Use(new Middlewares.MidHelloWorld());
        }
    }
}