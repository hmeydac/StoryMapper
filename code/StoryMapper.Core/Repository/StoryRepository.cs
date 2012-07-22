namespace StoryMapper.Core.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using StoryMapper.Core.Entities;

    public class StoryRepository : IStoryRepository
    {
        private readonly IList<Story> stories;

        public StoryRepository() : this(new List<Story>())
        {
        }

        public StoryRepository(IList<Story> stories)
        {
            this.stories = stories;
        }

        public IQueryable<Story> Stories
        {
            get { return this.stories.AsQueryable(); }
        }
    }
}
