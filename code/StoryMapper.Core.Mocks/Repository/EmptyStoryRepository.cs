namespace StoryMapper.Core.Mocks.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Repository;

    public class EmptyStoryRepository : IStoryRepository
    {
        private List<Story> stories;

        public EmptyStoryRepository()
        {
            this.stories = new List<Story>();
        }

        public IQueryable<Entities.Story> Stories
        {
            get
            {
                return this.stories.AsQueryable();
            }
        }

        public IEnumerable<Story> GetList()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Story> GetList(System.Func<Story, bool> predicate)
        {
            throw new System.NotImplementedException();
        }

        public Story Single(System.Func<Story, bool> predicate)
        {
            throw new System.NotImplementedException();
        }

        public Story Update(Story entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Story entity)
        {
            throw new System.NotImplementedException();
        }

        public Story Create(Story entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
