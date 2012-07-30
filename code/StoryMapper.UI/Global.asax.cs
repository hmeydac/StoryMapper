namespace StoryMapper.UI
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using StoryMapper.UI.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.InitializeApplication();
        }

        private void InitializeApplication()
        {
            DomainInitializer.Initialize();
            StructuremapMvc.Start();
        }
    }
}