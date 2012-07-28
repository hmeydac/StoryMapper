namespace StoryMapper.UI.App_Start
{
    using System.Web.Mvc;
    using StructureMap;

    public static class StructuremapMvc
    {
        public static void Start()
        {
            var container = (IContainer)IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}