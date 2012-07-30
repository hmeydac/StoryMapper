namespace StoryMapper.Core.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StoryMapper.Core.Repository;

    [TestClass]
    public class DomainTests
    {
        [TestMethod]
        [DeploymentItem("TestData", "TestData")]
        public void InitializingFromFolderShouldReadStoriesJson()
        {
            // Arrange
            var domain = new Domain();
            var testFolderName = "TestData";

            // Act
            domain.Initialize(testFolderName);
            var actual = domain.StoryRepository;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IStoryRepository));
            Assert.IsNotNull(actual.Stories);
            Assert.IsTrue(actual.Stories.Count() > 0);
            foreach (var story in actual.Stories)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
            }
        }

        [TestMethod]
        public void GetCurrentDomainShouldReturnInstance()
        {
            // Act
            var domain = Domain.Current;

            // Assert
            Assert.IsNotNull(domain);
        }

        [TestMethod]
        [DeploymentItem("TestData", "TestData")]
        public void StaticInitializeShouldPopulateData()
        {
            // Arrange
            var testFolderName = "TestData";

            // Act
            Domain.InitializeFromFolder(testFolderName);
            var domain = Domain.Current;
            var actual = domain.StoryRepository;

            // Assert
            Assert.IsNotNull(domain);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IStoryRepository));
            Assert.IsNotNull(actual.Stories);
            Assert.IsTrue(actual.Stories.Count() > 0);
            foreach (var story in actual.Stories)
            {
                Assert.IsNotNull(story.Name);
                Assert.IsNotNull(story.ProjectName);
            }
        }
    }
}