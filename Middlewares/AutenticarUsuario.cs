using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChainOfresponsability.Middlewares
{
    public class AutenticarUsuario : Middleware
    {
        public override void Execute(AppHttpContext context)
        {
            bool usuarioValido = false;
            if (usuarioValido)
            {
                context.Context.Response.Write("Autenticar Usuário<br />");
                Next(context);
            }
            else
            {
                context.Context.Response.Write("Você não está autorizado a realizar esse acesso");
                context.Context.Response.StatusCode = 401;
            }
        }
    }
}