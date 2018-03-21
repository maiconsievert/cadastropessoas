using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CadastroPessoasWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var politicas = new EnableCorsAttribute(
                origins: "*",
                methods: "*",
                headers: "*"
            );
            config.EnableCors(politicas);

            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "WebService",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


        }
    }
}
