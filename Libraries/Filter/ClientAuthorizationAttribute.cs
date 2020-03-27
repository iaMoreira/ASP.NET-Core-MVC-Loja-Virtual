using System.Threading;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Libraries.Auth;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Filter
{
    /*
     *Tipos de Filtros:
     * - Autorização
     * - Recurso
     * - Ação
     * - Exceção
     */
    public class ClientAuthorizationAttribute : Attribute, IAuthorizationFilter 
    {
        Auth.Auth _auth;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _auth = (Auth.Auth) context.HttpContext.RequestServices.GetService(typeof(Auth.Auth));
            Client client = _auth.User();
            if(client == null){
                context.Result =  new ContentResult() {Content = "Acesso negado."};
            }

        }   
        
    }
}