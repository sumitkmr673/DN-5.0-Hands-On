using Moq;
using NUnit.Framework;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
        }

        // --- REQUIREMENT 1: Test the Exception ---
        // The PDF asked to use [ExpectedException], but that is deprecated in modern NUnit.
        // We are using Assert.Throws instead, which is the industry standard.
        // [ExpectedException(typeof(ArgumentException))] <-- OLD WAY
        [TestCase("ExistingPlayer")]
        public void RegisterNewPlayer_ShouldThrowException_WhenPlayerExists(string playerName)
        {
            // Arrange: Force the mock database to say the player ALREADY exists
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb(playerName)).Returns(true);

            // Act & Assert (NEW WAY): Verify that an ArgumentException is thrown
            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer(playerName, _mockPlayerMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }

        // --- REQUIREMENT 2: Test Success & Assert Attributes ---
        [TestCase("NewPlayer")]
        public void RegisterNewPlayer_ShouldReturnPlayer_WhenPlayerDoesNotExist(string playerName)
        {
            // Arrange: Force the mock database to say the player DOES NOT exist (Returns False)
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb(playerName)).Returns(false);

            // We also need to setup the Add method to just do nothing (since it's a void method)
            _mockPlayerMapper.Setup(m => m.AddNewPlayerIntoDb(playerName));

            // Act: Register the player
            var result = Player.RegisterNewPlayer(playerName, _mockPlayerMapper.Object);

            // Assert: Verify the attributes match the hardcoded values in Player.cs
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(playerName));
            Assert.That(result.Age, Is.EqualTo(23));
            Assert.That(result.Country, Is.EqualTo("India"));
            Assert.That(result.NoOfMatches, Is.EqualTo(30));
        }
    }
}