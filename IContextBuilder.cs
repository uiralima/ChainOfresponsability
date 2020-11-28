using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChainOfresponsability
{
    public interface IContextBuilder
    {
        string Build(HttpContext context);
    }
}
