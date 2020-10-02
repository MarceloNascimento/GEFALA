using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;

namespace GEFALA.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session.Keys["usuario"]; 
            if (usuario != null)
            {
                base.OnActionExecuted(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(new { controller = "Mensagem", action = "ListarMensagens" }));
            }


        }
    }
}