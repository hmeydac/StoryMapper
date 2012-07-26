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
            var expectedProjectName = "StoryMapper";
            StoryRepository repository;

            // Act
            repository = new StoryRepository(dataList);
            var actual = repository.Single(story => story.Name == expectedStoryName && story.ProjectName == expectedProjectName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedStoryName, actual.Name);
            Assert.AreEqual(expectedProjectName, actual.ProjectName);
        }

        [TestMethod]
        public void CreateStoryShouldAddNewStory()
        {
            // Arrange
            var repository = new StoryRepository();
            var expected = new Story
            {
                Name = "Story Test",
                ProjectName = "StoryMapper"
            };

            // Act
            var createdActual = repository.Create(expected);
            var obtainedActual = repository.Single(story => story.Name == expected.Name && story.ProjectName == expected.ProjectName);
            
            // Assert
            Assert.IsNotNull(createdActual);
            Assert.IsNotNull(obtainedActual);
            Assert.AreEqual(expected.Name, createdActual.Name);
            Assert.AreEqual(expected.Name, obtainedActual.Name);
            Assert.AreEqual(expected.ProjectName, createdActual.ProjectName);
            Assert.AreEqual(expected.ProjectName, obtainedActual.ProjectName);
        }

        [TestMethod]
        public void DeleteStoryShouldRemoveIt()
        {
            // Arrange            
            var dataList = this.GetMockDataList();
            var repository = new StoryRepository(dataList);
            var expectedCount = dataList.Count() - 1;
            var notExpected = dataList[0];

            // Act
            repository.Delete(notExpected);
            var actual = repository.GetList();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actual.Count());
            foreach (var story in actual)
            {
                if (notExpected.ProjectName == story.ProjectName)
                {
                    Assert.AreNotEqual(notExpected.Name, story.Name);
                }
            }
        }

        [TestMethod]
        public void UpdateStoryShouldModifyValues()
        {
            // Arrange
            var dataList = this.GetMockDataList();
            var repository = new StoryRepository(dataList);
            var expected = dataList[0];
            expected.Name = "Updated Name";
            expected.ProjectName = "Updated Project";

            // Act
            var updatedActual = repository.Update(expected);
            var obtainedActual = repository.Single(story => story.Name == expected.Name && story.ProjectName == expected.ProjectName);

            // Assert
            Assert.IsNotNull(updatedActual);
            Assert.IsNotNull(obtainedActual);
            Assert.AreEqual(expected.Name, updatedActual.Name);
            Assert.AreEqual(expected.Name, obtainedActual.Name);
            Assert.AreEqual(expected.ProjectName, updatedActual.ProjectName);
            Assert.AreEqual(expected.ProjectName, obtainedActual.ProjectName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateNonExistentStoryShouldThrowException()
        {
            // Arrange
            var dataList = this.GetMockDataList();
            var repository = new StoryRepository(dataList);
            var notExpected = new Story
            {
                Name = "Updated Name",
                ProjectName = "Updated Project"
            };

            // Act
            repository.Update(notExpected);
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
