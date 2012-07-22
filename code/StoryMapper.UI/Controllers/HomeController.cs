namespace StoryMapper.UI.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
