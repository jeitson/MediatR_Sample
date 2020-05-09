using LibraryMediatR;
using Project.Infrastructure;
using System.Web.Http;
using Unity;

namespace APIMediatR
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            UnityConfiguration.Container.AddNewExtension<NoteExtension>();

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
