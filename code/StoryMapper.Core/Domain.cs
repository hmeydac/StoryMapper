namespace StoryMapper.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Helpers;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Repository;

    public class Domain
    {
        private static Domain instance;
        private IStoryRepository storyRepository;

        public Domain()
        {
        }

        public static Domain Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new Domain();
                }

                return instance;
            }
        }

        public IStoryRepository StoryRepository
        {
            get
            {
                return this.storyRepository;
            }
        }

        public static void InitializeFromFolder(string path)
        {
            Current.LoadStories(path);
        }

        public void Initialize(string path)
        {
            this.LoadStories(path);
        }

        private void LoadStories(string path)
        {
            var stories = this.GetStories(path);

            this.storyRepository = new StoryRepository(stories);
        }

        private List<Story> GetStories(string path)
        {
            string filename = Path.Combine(path, "Stories.json");
            string text = File.ReadAllText(filename);
            dynamic list = Json.Decode(text);

            var stories = new List<Story>();

            foreach (var item in list)
            {
                var story = new Story
                {
                    Name = item.Name,
                    ProjectName = item.ProjectName
                };

                this.LoadChildStories(story, item.Stories);
                stories.Add(story);
            }

            return stories;
        }

        private void LoadChildStories(Story parent, dynamic childs)
        {
            foreach (var item in childs)
            {
                var story = new Story
                {
                    Name = item.Name,
                    ProjectName = item.ProjectName
                };

                parent.Stories.Add(story);
            }
        }
    }
}