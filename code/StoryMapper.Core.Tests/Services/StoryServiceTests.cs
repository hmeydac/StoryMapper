namespace StoryMapper.Core.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StoryMapper.Core.Entities;
    using StoryMapper.Core.Mocks.Repository;
    using StoryMapper.Core.Repository;
    using StoryMapper.Core.Services;
    using StructureMap;

    [TestClass]
    public class StoryServiceTests
    {
        [TestMethod]
        public void InstantiateStoryServiceShouldNotThrowException()
        {
            // Arrange
            this.RegisterEmptyStoriesMock();
            StoryService service;
            var storyRepository = this.GetMock<IStoryRepository>();

            // Act
            service = new StoryService(storyRepository);

            // Assert
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void InstantiateStoryServiceShouldWork()
        {
            // Arrange
            this.RegisterSingleProjectStoriesMock();
            StoryService service;
            var storyRepository = this.GetMock<IStoryRepository>();

            // Act
            service = new StoryService(storyRepository);

            // Assert
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void GetStoriesByProjectShouldReturnAListOfStories()
        {
            // Arrange
            this.RegisterSingleProjectStoriesMock();
            var service = new StoryService(this.GetMock<IStoryRepository>());
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

        private void RegisterEmptyStoriesMock()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IStoryRepository>().Use<EmptyStoryRepository>();
            });
        }

        private void RegisterSingleProjectStoriesMock()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IStoryRepository>().Use<SingleProjectStoryRepository>();
            });
        }

        private T GetMock<T>()
        {
            return ObjectFactory.Container.TryGetInstance<T>();
        }
    }
}