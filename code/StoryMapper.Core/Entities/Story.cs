namespace StoryMapper.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class Story
    {
        public Story()
        {
            this.Stories = new List<Story>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProjectName { get; set; }

        public List<Story> Stories { get; set; }
    }
}