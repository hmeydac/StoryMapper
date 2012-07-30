namespace StoryMapper.Core.Services
{
    using System.Collections.Generic;
    using StoryMapper.Core.Entities;

    public interface IStoryService
    {
        IEnumerable<Story> GetStoriesByProject(string projectName);
    }
}