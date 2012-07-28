namespace StoryMapper.UI.App_Start
{
    using System.Web;
    using StoryMapper.Core;

    public class DomainInitializer
    {
        public static void Initialize()
        {
            Domain.Current.Initialize(HttpContext.Current.Server.MapPath("~/App_Data"));
        }
    }
}