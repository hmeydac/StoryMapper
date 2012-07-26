namespace StoryMapper.Core.Services
{
    using System.Collections.Generic;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Repository;

    public class StoryService : StoryMapper.Core.Services.IStoryService
    {
        private StoryRepository storyRepository;

        public StoryService() : this(new List<Story>())
        {             
        }

        public StoryService(IList<Story> stories) : this(new StoryRepository(stories))
        {             
        }

        public StoryService(StoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        public IEnumerable<Story> GetStoriesByProject(string projectName)
        {
            return this.storyRepository.GetList(story => story.ProjectName == projectName);
        }
    }
}
