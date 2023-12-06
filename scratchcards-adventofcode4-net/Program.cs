namespace scratchcards_adventofcode4_net
{
    internal class Program
    {
        private const string _filePath = "input.txt";

        static void Main(string[] args)
        {
            var input = File.ReadAllText(_filePath);
            var cards = ScratchcardHelper.ParseCardsString(input);
            var matchesPerCard = ScratchcardHelper.CountMatches(cards);
            // Part 1
            var totalPoints = ScratchcardHelper.CalculateTotalPoints(matchesPerCard); 
            Console.WriteLine($"Total number of points: {totalPoints}");
            // Part 2
            var totalTickets = ScratchcardHelper.CalculateTotalTickets(matchesPerCard);
            Console.WriteLine($"Total number of tickets: {totalTickets}");
        }
    }
}