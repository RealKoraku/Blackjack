namespace Blackjack {
    internal class Program {
        static bool dealerTurn = true;
        static bool gameState = true;

        static void Main(string[] args) {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("SINGLE-DECK BLACKJACK");

            List<Card> deck = Card.BuildDeck();

            while (gameState == true) {
                int dealerScore = 0;
                int playerScore = 0;

                dealerScore = DealerTurn(deck);

                if (dealerScore < 21) {
                    playerScore = PlayerTurn(deck);
                }
                bool playerWin = CompareWin(dealerScore, playerScore);
            }
        }

        public static int DealerTurn(List<Card> deck) {
            Console.WriteLine("\nDealer:");
            int turnScore = 0;
            int cardsDrawn = 0;
            List<Card> cardsInPlay = new List<Card>();

            while (turnScore < 17) {
                
                Card drawnCard = DrawCard(deck);
                cardsInPlay.Add(drawnCard);
                PrintCard(drawnCard);

                drawnCard.Value = IsAceValue(drawnCard, turnScore);

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
            Console.WriteLine("\n\nPlayer:");
            int turnScore = 0;
            int cardsDrawn = 0;
            List<Card> cardsInPlay = new List<Card>();

            if (deck.Count() >= 2) {
                for (int i = cardsDrawn; i < 2; i++) {
                    Card drawnCard = DrawCard(deck);
                    cardsInPlay.Add(drawnCard);
                    cardsDrawn++;
                    PrintCard(drawnCard);

                    if (cardsInPlay.Count() == 1) {
                        Console.Write(", ");
                    }

                    drawnCard.Value = IsAceValue(drawnCard, turnScore);
                    turnScore += drawnCard.Value;
                }
            }

            while (!dealerTurn) {

                if (deck.Count() >= 1 && turnScore < 21) {
                    string input = Input("\n\nHit? (y/n): ");

                    if (input.ToLower() == "y" || input.ToLower() == "yes") {

                        Card drawnCard = DrawCard(deck);
                        cardsInPlay.Add(drawnCard);

                        PrintCard(drawnCard);

                        cardsDrawn++;

                        drawnCard.Value = IsAceValue(drawnCard, turnScore);
                        turnScore += drawnCard.Value;

                    } else if (input.ToLower() == "no" || input.ToLower() == "n") {
                        dealerTurn = true;
                    }
                } else if (deck.Count() == 0) {
                    gameState = false;
                } else {
                    dealerTurn = true;
                }
            }
            DeterminePlay(cardsInPlay, turnScore);
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

        public static int IsAceValue(Card drawnCard, int turnScore) {
            if (drawnCard.Title.Contains("Ace") && turnScore <= 10) {
                drawnCard.Value = 11;
            }
            return drawnCard.Value;
        }

        public static bool CompareWin(int dealerScore, int playerScore) {

            if ((dealerScore > playerScore) && (dealerScore < 21) || (dealerScore == 21) || playerScore > 21) {
                Console.WriteLine("\nDealer Win");
                return false;
            } else if ((dealerScore < playerScore) && (playerScore < 21) || (playerScore == 21) || dealerScore > 21) {
                Console.WriteLine("\nPlayer Win");
                return true;
            } else if (dealerScore == playerScore) {
                Console.WriteLine("\nStandoff");
            }
            return false;
        }
                

        public static void PrintCard(Card currentCard) {
            Console.ForegroundColor = currentCard.Color;
            Console.Write(currentCard.Title);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string Input(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}