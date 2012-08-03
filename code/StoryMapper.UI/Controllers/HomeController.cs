namespace StoryMapper.UI.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Project");            
        }        
    }
}