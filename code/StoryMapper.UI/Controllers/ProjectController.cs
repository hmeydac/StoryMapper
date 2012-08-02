namespace StoryMapper.UI.Controllers
{
    using System.Collections.Generic;
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
                var storyViewModel = Mapper.Map<StoryViewModel>(story);
                storyViewModel.Stories = Mapper.Map<List<StoryViewModel>>(story.Stories);
                projectStoriesViewModel.Stories.Add(storyViewModel);
            }

            return this.View(projectStoriesViewModel);
        }
    }
}