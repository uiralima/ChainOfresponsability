using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfresponsability
{
    public abstract class Middleware
    {
        protected abstract void Execute(AppHttpContext context);

        public void Act(AppHttpContext context)
        {
            Execute(context);
        }

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
