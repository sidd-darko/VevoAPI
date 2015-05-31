using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VevoAPI.Repository;
using Microsoft.Practices.Unity;

namespace VevoAPI
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      
      RegisterResolver();
      RouteTable.Routes.MapHttpRoute(name: "DefaultRoute", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
      RouteTable.Routes.MapHttpRoute(name: "VideosRoute", routeTemplate: "api/artists/{id}/videos", defaults: new { controller = "videos", action = "Get" });

      GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
      GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    }

    private void RegisterResolver()
    {
      IUnityContainer container = new UnityContainer();
      container.RegisterType<IVevoRepository, VevoRepository>(new Microsoft.Practices.Unity.HierarchicalLifetimeManager());
      GlobalConfiguration.Configuration.DependencyResolver = new VevoAPI.Resolver.UnityResolver(container);
    }

  }
}