namespace Blackjack {
    internal class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("BLACKJACK\n");
            List<Card> deck = Card.BuildDeck();
        }
    }
}