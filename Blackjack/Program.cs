namespace Blackjack {
    internal class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("SINGLE-DECK BLACKJACK\n");
            List<Card> deck = Card.BuildDeck();

            DealerTurn(deck);
        }

        public static int DealerTurn(List<Card> deck) {
            int turnScore = 0;
            int cardsDrawn = 0;

            while (turnScore < 17) {
                Card drawnCard = DrawCard(deck);

                PrintCard(drawnCard);

                if (drawnCard.Title.Contains("Ace") && turnScore <= 10) {
                    drawnCard.Value = 11;
                }
                turnScore += drawnCard.Value;

                if (turnScore < 17) {
                    Console.Write(",");
                }
                cardsDrawn++;
            }
            return turnScore;
        }

        public static Card DrawCard(List<Card> deck) {
            Card drawnCard;
            Random randomCard = new Random();
            
            int cardNum = randomCard.Next(0, deck.Count());
            drawnCard = deck[cardNum];
            deck.Remove(deck[cardNum]);

            return drawnCard;
        }

        public static void PrintCard(Card currentCard) {
            Console.ForegroundColor = currentCard.Color;
            Console.Write(currentCard.Title);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}