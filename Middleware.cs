using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresponsability
{
    public abstract class Middleware
    {
        public abstract void Execute(AppHttpContext context);

        protected void Next(AppHttpContext context)
        {
            Middleware next = context.Next();
            if (null != next)
            {
                next.Execute(context);
            }
            else
            {
                return;
            }
        }
    }
}
