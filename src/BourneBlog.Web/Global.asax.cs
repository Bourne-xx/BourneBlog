using System.Web.Mvc;
using System.Web.Routing;
using BourneBlog.App.Controllers;
using BourneBlog.App.Controllers.Cfg;
using BourneFramework.Mvc;
using FluentNHibernate.Cfg.Db;
using StructureMap;

namespace BourneBlog.Web
{
    public class MvcApplication : BourneHttpApplication
    {
        public MvcApplication()
        {
            ConfigureFramework()
                .WithRepository(
                    repository =>
                    {
                        repository.Mappings(
                            mappings => mappings.FluentMappings.AddFromAssemblyOf<PostController>());
                        repository.Database(MsSqlConfiguration.MsSql2008
                            .ConnectionString( dsn => dsn.FromConnectionStringWithKey("dsn"))
                            .AdoNetBatchSize(100)
                            .UseOuterJoin()
                            .UseReflectionOptimizer()
                        );
                    });
        
            ObjectFactory.Configure(config => config.AddRegistry(new ControllerRegistry()));
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Post", action = "Latest", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            ControllerBuilder.Current.DefaultNamespaces.Add("BourneBlog.App.Controllers");
            RegisterRoutes(RouteTable.Routes);
        }
    }
}