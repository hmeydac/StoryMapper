namespace StoryMapper.Core.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StoryMapper.Core.Entities;

    public class StoryRepository : IStoryRepository, IEntityRepository<Story>
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

        public IEnumerable<Story> GetList()
        {
            return this.Stories.OrderBy(story => story.Name);
        }

        public IEnumerable<Story> GetList(System.Func<Story, bool> predicate)
        {
            return this.Stories.Where(predicate);
        }

        public Story Single(System.Func<Story, bool> predicate)
        {
            return this.Stories.SingleOrDefault(predicate);
        }

        public Story Update(Story entity)
        {
            var actual = this.Single(story => story.Name == entity.Name);
            if (actual == null)
            {
                throw new ArgumentException(string.Format("Invalid Update. Entity Story:{0} not found.", entity.Name));
            }

            actual.Name = entity.Name;
            actual.ProjectName = entity.ProjectName;
            return actual;
        }

        public void Delete(Story entity)
        {
            var actual = this.Single(story => story.Name == entity.Name);
            this.stories.Remove(actual);
        }

        public Story Create(Story entity)
        {
            this.stories.Add(entity);
            return entity;
        }
    }
}
