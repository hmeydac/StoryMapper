namespace StoryMapper.Core.Repository
{
    using System.Linq;
    using StoryMapper.Core.Entities;

    public interface IStoryRepository : IEntityRepository<Story>
    {
        IQueryable<Story> Stories { get; }
    }
}