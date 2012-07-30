namespace StoryMapper.Core.Mocks.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Repository;

    public class SingleProjectStoryRepository : IStoryRepository
    {
        private List<Story> stories;

        public SingleProjectStoryRepository()
        {
            this.stories = new List<Story>
            {
                new Story { Name = "Test Story 1", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 2", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 3", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 4", ProjectName = "StoryMapper" }
            };
        }

        public IQueryable<Entities.Story> Stories
        {
            get { return this.stories.AsQueryable(); }
        }

        public Entities.Story Create(Entities.Story entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.Story entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Story> GetList()
        {
            return this.stories;
        }

        public IEnumerable<Entities.Story> GetList(Func<Entities.Story, bool> predicate)
        {
            return this.stories.Where(predicate);
        }

        public Entities.Story Single(Func<Entities.Story, bool> predicate)
        {
            return this.stories.Single(predicate);
        }

        public Entities.Story Update(Entities.Story entity)
        {
            throw new NotImplementedException();
        }
    }
}