namespace StoryMapper.Core.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Repository;
    
    [TestClass]
    public class StoryRepositoryTests
    {
        [TestMethod]
        public void StoriesShouldReturnCollection()
        {
            // Arrange
            var dataList = this.GetMockDataList();
            StoryRepository repository;

            // Act
            repository = new StoryRepository(dataList);
            var actual = repository.Stories;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IQueryable<Story>));
            Assert.IsTrue(actual.Count() == 4);
            foreach (var story in actual)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
            }
        }

        private IList<Story> GetMockDataList()
        {
            return new List<Story> 
            { 
                new Story { Name = "Test Story 1", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 2", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 3", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 4", ProjectName = "StoryMapper" }
            };
        }
    }
}
