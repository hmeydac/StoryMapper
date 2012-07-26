namespace StoryMapper.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Story
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProjectName { get; set; }
    }
}
