using MagicFilesLib;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;

        // Hardcoded file names
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            // Initialize the mock object
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
        }

        [TestCase("C:\\SomeFakePath")]
        public void GetFiles_ShouldReturnHardCodedFiles(string testPath)
        {
            // Arrange: Create a fake list and configure the mock to return it
            var fakeFiles = new List<string> { _file1, _file2 };
            _mockDirectoryExplorer.Setup(m => m.GetFiles(It.IsAny<string>())).Returns(fakeFiles);

            // Act: Execute the method on the mocked object
            var result = _mockDirectoryExplorer.Object.GetFiles(testPath);

            // Assert: Verify the collection meets all 3 criteria
            Assert.That(result, Is.Not.Null, "The collection should not be null.");
            Assert.That(result.Count, Is.EqualTo(2), "The collection count should be exactly 2.");
            Assert.That(result, Does.Contain(_file1), $"The collection should contain {_file1}.");
        }
    }
}