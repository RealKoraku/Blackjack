class Card {
    string _title;
    string _type;
    int _value;
    ConsoleColor _color;

    public string Title {
        get { return _title; }
        set { _title = value; }
    }

    public string Type {
        get { return _type; }
        set { _type = value; }
    }

    public int Value {
        get { return _value; }
        set { _value = value; }
    }

    public ConsoleColor Color {
        get { return _color; }
        set { _color = value; }
    }

    public static List<Card> BuildDeck() {

        List<Card> deck = new List<Card>();

        for (int cardType = 0; cardType < 4; cardType++) {
            string type = "";
            if (cardType == 0) {
                type = "♠";
            } else if (cardType == 1) {
                type = "♥";
            } else if (cardType == 2) {
                type = "♣";
            } else if (cardType == 3) {
                type = "♦";
            }

            int cardValue = 1;

            for (int cardNum = 1; cardNum < 14; cardNum++) {

                List<string> titles = new List<string>();

                Card currentCard = new Card();
                currentCard.Type = type;
                currentCard.Value = cardValue;
                currentCard.Title = NameCard(type, cardNum);

                deck.Add(currentCard);
                
                if (cardType % 2 == 0) {
                    currentCard.Color= ConsoleColor.Black;
                } else {
                    currentCard.Color = ConsoleColor.DarkRed;
                }

                if (cardNum >= 10) {
                    cardValue = 10;
                } else {
                    cardValue++;
                }
            }
        }
        return deck;
    }

    public static string NameCard(string type, int cardNum) {
        string cardName = "";

        if (cardNum == 1) {
            cardName = $"Ace{type}";
        } else if (cardNum > 1 && cardNum < 11) {
            cardName = $"{cardNum}{type}";
        } else if (cardNum == 11) {
            cardName = $"Jack{type}";
        } else if (cardNum == 12) {
            cardName = $"Queen{type}";
        } else if (cardNum == 13) {
            cardName = $"King{type}";
        }
        return cardName;
    }

    public static void PrintBlackLn(string text) {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"{text}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PrintRedLn(string text) {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{text}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}