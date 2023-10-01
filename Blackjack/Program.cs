using System.Security.Cryptography.X509Certificates;

namespace Blackjack {
    internal class Program {
        static bool dealerTurn = true;
        static bool gameState = true;

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("SINGLE-DECK BLACKJACK\n");
            List<Card> deck = Card.BuildDeck();

            DealerTurn(deck);
            PlayerTurn(deck);
        }

        public static int DealerTurn(List<Card> deck) {
            int turnScore = 0;
            int cardsDrawn = 0;
            List<Card> cardsInPlay = new List<Card>();

            while (turnScore < 17) {
                
                Card drawnCard = DrawCard(deck);
                cardsInPlay.Add(drawnCard);

                PrintCard(drawnCard);

                if (drawnCard.Title.Contains("Ace") && turnScore <= 10) {
                    drawnCard.Value = 11;
                }
                turnScore += drawnCard.Value;

                if (turnScore < 17) {
                    Console.Write(", ");
                }
                cardsDrawn++;
            }
            DeterminePlay(cardsInPlay, turnScore);
            dealerTurn = false;

            return turnScore;
        }

        public static int PlayerTurn(List<Card> deck) {
            int turnScore = 0;
            int cardsDrawn = 0;
            List<Card> cardsInPlay = new List<Card>();

            for (int i = 0; i < 2; i++) {
                Card drawnCard = DrawCard(deck);
                cardsInPlay.Add(drawnCard);

                PrintCard(drawnCard);

                if (drawnCard.Title.Contains("Ace") && turnScore <= 10) {
                    drawnCard.Value = 11;
                }
                turnScore += drawnCard.Value;
            }
            dealerTurn = true;
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

        public static void DeterminePlay(List<Card> cardsInPlay, int turnScore) {
            if (turnScore == 21 && cardsInPlay.Count == 2) {
                Console.WriteLine("\nNatural Blackjack");
            } else if (turnScore == 21) {
                Console.WriteLine("\nBlackjack");
            } else if (turnScore > 21) {
                Console.WriteLine("\nBust");
            }
        }

        public static void PrintCard(Card currentCard) {
            Console.ForegroundColor = currentCard.Color;
            Console.Write(currentCard.Title);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}