namespace StoryMapper.Core.Entities
{
    using System;

    public class Story
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProjectName { get; set; }
    }
}