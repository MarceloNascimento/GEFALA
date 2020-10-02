using System;
using System.Web.Routing;

namespace GEFALA
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "MensagensList", // Route name
            "MostrarMuralDeMensagensAdmistrador/Page/{page}", // URL with params
            new { controller = "AdmistradorGeral", action = "Index", page = UrlParameter.Optional } // Param defaults
                );

            routes.MapRoute(
                            "Delete",
                            "delete/{id}",
                            new { controller = "Mensagem", action = "DeletarMensagem" }
                        );

            routes.MapRoute(
                "Responder",
                "menssagens/{id}",
                new { controller = "Mensagem", action = "ResponderMensagemEnviadaAoPeloAdmistrador" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}