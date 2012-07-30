namespace StoryMapper.UI.Tests.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StoryMapper.Core.Mocks.Services;
    using StoryMapper.Core.Services;
    using StoryMapper.UI.Controllers;
    using StoryMapper.UI.Models;
    using StructureMap;

    [TestClass]
    public class ProjectControllerTests
    {
        [TestMethod]
        public void CallIndexShouldReturnListOfStories()
        {
            // Arrange
            this.RegisterSingleProjectStoriesMock();
            var service = this.GetMock<IStoryService>();
            var controller = new ProjectController(service);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var actual = result.Model as ProjectStoriesViewModel;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.ProjectName);
            Assert.AreEqual(4, actual.Stories.Count());
        }

        private void RegisterSingleProjectStoriesMock()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IStoryService>().Use<SingleProjectStoryService>();
            });
        }

        private T GetMock<T>()
        {
            return ObjectFactory.Container.TryGetInstance<T>();
        }
    }
}