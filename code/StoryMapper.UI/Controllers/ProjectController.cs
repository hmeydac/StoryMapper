namespace StoryMapper.UI.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Services;
    using StoryMapper.UI.Models;

    public class ProjectController : Controller
    {
        private IStoryService storyService;

        public ProjectController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        public ActionResult Index()
        {
            var stories = this.storyService.GetStoriesByProject("StoryMapper");

            var map = Mapper.CreateMap<Story, StoryViewModel>();

            var projectStoriesViewModel = new ProjectStoriesViewModel { ProjectName = "StoryMapper" };
            foreach (var story in stories)
            {
                projectStoriesViewModel.Stories.Add(Mapper.Map<StoryViewModel>(story));
            }

            return this.View(projectStoriesViewModel);
        }
    }
}
