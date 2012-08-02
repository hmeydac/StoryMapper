namespace StoryMapper.UI.Models
{
    using System;
using System.Collections.Generic;

    public class StoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<StoryViewModel> Stories { get; set; }
    }
}