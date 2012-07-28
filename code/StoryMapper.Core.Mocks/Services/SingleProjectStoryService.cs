namespace StoryMapper.Core.Mocks.Services
{
    using System.Collections.Generic;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Services;

    public class SingleProjectStoryService : IStoryService
    {
        public IEnumerable<Entities.Story> GetStoriesByProject(string projectName)
        {
            return new List<Story> 
            { 
                new Story { Name = "Test Story 1", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 2", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 3", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 4", ProjectName = "StoryMapper" }
            };
        }
    }
}
