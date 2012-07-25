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

        [TestMethod]
        public void GetListShouldReturnAllStories()
        {
            // Arrange
            var dataList = this.GetMockDataList();
            StoryRepository repository;

            // Act
            repository = new StoryRepository(dataList);
            var actual = repository.GetList();

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

        [TestMethod]
        public void GetListByProjectShouldReturnAllStoriesFromProject()
        {
            // Arrange
            var dataList = this.GetMockDataMultiProjectList();
            var projectName = "StoryMapper"; // First Project
            StoryRepository repository;

            // Act
            repository = new StoryRepository(dataList);
            var actual = repository.GetList(story => story.ProjectName == projectName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Story>));
            Assert.IsTrue(actual.Count() == 2);
            foreach (var story in actual)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
                Assert.AreEqual(projectName, story.ProjectName);
            }

            // Arrange
            dataList = this.GetMockDataMultiProjectList();
            projectName = "TestProject1"; // Second Project            

            // Act
            repository = new StoryRepository(dataList);
            actual = repository.GetList(story => story.ProjectName == projectName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Story>));
            Assert.IsTrue(actual.Count() == 1);
            foreach (var story in actual)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
                Assert.AreEqual(projectName, story.ProjectName);
            }

            // Arrange
            dataList = this.GetMockDataMultiProjectList();
            projectName = "TestProject2"; // Third Project      
        
            // Act
            repository = new StoryRepository(dataList);
            actual = repository.GetList(story => story.ProjectName == projectName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Story>));
            Assert.IsTrue(actual.Count() == 1);
            foreach (var story in actual)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
                Assert.AreEqual(projectName, story.ProjectName);
            }
        }

        [TestMethod]
        public void GetSingleShouldReturnSingleStory()
        {
            // Arrange
            var dataList = this.GetMockDataMultiProjectList();            
            var expectedStoryName = "Test Story 1";
            StoryRepository repository;

            // Act
            repository = new StoryRepository(dataList);
            var actual = repository.Single(story => story.Name == expectedStoryName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedStoryName, actual.Name);
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

        private IList<Story> GetMockDataMultiProjectList()
        {
            return new List<Story> 
            { 
                new Story { Name = "Test Story 1", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 2", ProjectName = "StoryMapper" },
                new Story { Name = "Test Story 3", ProjectName = "TestProject1" },
                new Story { Name = "Test Story 4", ProjectName = "TestProject2" }
            };
        }
    }
}
