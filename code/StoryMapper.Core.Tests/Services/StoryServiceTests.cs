namespace StoryMapper.Core.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Services;

    [TestClass]
    public class StoryServiceTests
    {
        [TestMethod]
        public void IntantiateStoryServiceShouldWork()
        { 
            // Arrange
            StoryService service;
            var mockData = this.GetMockDataList();
            // Act
            service = new StoryService(mockData);
            // Assert
            Assert.IsNotNull(service);            
        }

        [TestMethod]
        public void GetStoriesByProjectShouldReturnAListOfStories()
        {
            // Arrange
            var service = new StoryService(this.GetMockDataList());
            var projectName = "StoryMapper";
            
            // Act
            var actual = service.GetStoriesByProject(projectName);
            
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Story>));
            Assert.IsTrue(actual.Count() > 0);
            foreach (var story in actual)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
                Assert.AreEqual(projectName, story.ProjectName);
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
