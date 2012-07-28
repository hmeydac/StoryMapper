namespace StoryMapper.UI.Models
{
    using System.Collections.Generic;

    public class ProjectStoriesViewModel
    {
        public ProjectStoriesViewModel()
        {
            this.Stories = new List<StoryViewModel>();
        }

        public string ProjectName { get; set; }

        public IList<StoryViewModel> Stories { get; set; }
    }
}