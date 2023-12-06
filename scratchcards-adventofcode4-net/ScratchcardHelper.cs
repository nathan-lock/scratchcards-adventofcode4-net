namespace scratchcards_adventofcode4_net
{
    public static class ScratchcardHelper
    {
        public static IEnumerable<Card> ParseCardsString(string ticketsString) =>
            ticketsString.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                         .Select(line =>
                         {
                             var parts = line.Split(':', 2)[1]
                                             .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(part => part.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                                 .Select(int.Parse)
                                                                 .ToArray())
                                             .ToArray();

                             return new Card(parts[0], parts[1]);
                         });

        public static int[] CountMatches(IEnumerable<Card> cards) =>
            cards.Select(card =>
                card.WinningNumbers.Count(winningNumber => card.GuessNumbers.Contains(winningNumber)))
                .ToArray();

        public static int CalculateTotalPoints(int[] winningsPerTicket) =>
            winningsPerTicket.Sum(ticketWinning => (int)Math.Pow(2, ticketWinning - 1));

        public static int CalculateTotalTickets(int[] winningsPerTicket)
        {
            // Initialise array with the same length as cards with value of 1
            var ticketCounts = Enumerable.Repeat(1, winningsPerTicket.Length).ToArray();

            for (int i = 0; i < winningsPerTicket.Length; i++)
            {
                int winnings = winningsPerTicket[i];

                // For each ticket, distribute its count to the next 'winnings' number of tickets.
                // This is done by adding the count of the current ticket to the subsequent 'winnings' tickets.
                for (int j = 0; j < winnings; j++)
                {
                    if (i + j + 1 < ticketCounts.Length)
                    {
                        ticketCounts[i + j + 1] += ticketCounts[i];
                    }
                }
            }
            return ticketCounts.Sum();
        }
    }
}
