using scratchcards_adventofcode4_net;

namespace scratchcards_adventofcode4_tests
{
    [TestFixture]
    public class TestScratchcardHelper
    {
        [Test]
        public void ParseCardsString_CorrectInput_ParsesSuccessfully()
        {
            // Arrange
            string input = "Card 1: 41 48 83 86 17 | 83 86 6 31 17 9 48 53\n" +
                           "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";

            // Act
            var result = ScratchcardHelper.ParseCardsString(input).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result[0].GuessNumbers, Is.EqualTo(new int[] { 41, 48, 83, 86, 17 }));
                Assert.That(result[0].WinningNumbers, Is.EqualTo(new int[] { 83, 86, 6, 31, 17, 9, 48, 53 }));
                Assert.That(result[1].GuessNumbers, Is.EqualTo(new int[] { 13, 32, 20, 16, 61 }));
                Assert.That(result[1].WinningNumbers, Is.EqualTo(new int[] { 61, 30, 68, 82, 17, 32, 24, 19 }));
            });
        }

        [Test]
        public void CountMatches_WithMatchingNumbers_ReturnsCorrectCounts()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 6 }), 
                new Card(new[] { 10, 11, 12, 13, 14 }, new[] { 15, 16, 10 }),
            };

            // Act
            var result = ScratchcardHelper.CountMatches(cards);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Length, Is.EqualTo(2));
                Assert.That(result[0], Is.EqualTo(2));
                Assert.That(result[1], Is.EqualTo(1));
            });
        }

        [Test]
        public void CountMatches_NoMatches_ReturnsZeroes()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8 }),
                new Card(new[] { 10, 11, 12, 13, 14 }, new[] { 15, 16, 17 }),
            };

            // Act
            var result = ScratchcardHelper.CountMatches(cards);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Length.EqualTo(2));
                Assert.That(result[0], Is.EqualTo(0));
                Assert.That(result[1], Is.EqualTo(0));
            });
        }

        [Test]
        public void CalculateTotalPoints_SingleWinning_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 3 };

            // Act
            var result = ScratchcardHelper.CalculateTotalPoints(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void CalculateTotalPoints_MultipleWinnings_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 1, 2, 3 }; 

            // Act
            var result = ScratchcardHelper.CalculateTotalPoints(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void CalculateTotalPoints_NoWinnings_ReturnsZero()
        {
            // Arrange
            int[] winnings = { };

            // Act
            var result = ScratchcardHelper.CalculateTotalPoints(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalPoints_ZeroWinning_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 0 };

            // Act
            var result = ScratchcardHelper.CalculateTotalPoints(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalTickets_SingleWinning_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 1 };

            // Act
            var result = ScratchcardHelper.CalculateTotalTickets(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CalculateTotalTickets_MultipleWinnings_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 2, 1 }; 

            // Act
            var result = ScratchcardHelper.CalculateTotalTickets(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void CalculateTotalTickets_NoWinnings_ReturnsCorrectCount()
        {
            // Arrange
            int[] winnings = new int[0];

            // Act
            var result = ScratchcardHelper.CalculateTotalTickets(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalTickets_LargeWinnings_CalculatesCorrectly()
        {
            // Arrange
            int[] winnings = { 3, 2, 1 };

            // Act
            var result = ScratchcardHelper.CalculateTotalTickets(winnings);

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }
    }
}