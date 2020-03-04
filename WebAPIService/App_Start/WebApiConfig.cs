using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIService
{
    /// <summary>
    /// WebApiConfig
    /// Registers and sets the configuration for the Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register
        /// Sets the configuration settings for the Web API 
        /// </summary>
        /// <param name="config">ht htpp configuration object</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                //routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Adds a custom message handler for authentication
            // Highest priority and first to process in the pipeline
            // Authentication should be done as earliest as possible in the pipeline
            config.MessageHandlers.Add(new AuthenticationHandler());

        } // end of method
    } // end of class
} // end of namespace
