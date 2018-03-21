﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CadastroPessoas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            


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
