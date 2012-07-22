namespace StoryMapper.Core.Repository
{
    using System.Linq;
    using StoryMapper.Core.Entities;

    public interface IStoryRepository
    {
        IQueryable<Story> Stories { get; }
    }
}
