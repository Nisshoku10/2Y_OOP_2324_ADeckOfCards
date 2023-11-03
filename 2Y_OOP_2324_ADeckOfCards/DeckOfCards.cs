using System;
using System.Collections.Generic;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class DeckOfCards
    {
        private int suits = 4;
        private int cards = 13;
        private char[] suitChars = { 'D', 'H', 'S', 'C' };
        private string[] cardFaces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        private List<Card> deckOfCards = new List<Card>();

        public DeckOfCards(bool shuffle)
        {
            GenerateDeck();
            if (shuffle)
                shuffleDeck();
        }

        private void GenerateDeck()
        {
            for (int x = 0; x < suits; x++)
            {
                for (int y = 0; y < cards; y++)
                {
                    int value = y + 1;
                    if (value > 10)
                        value = 10;
                    deckOfCards.Add(new Card(value, suitChars[x], cardFaces[y]));
                }
            }
        }

        public void DisplayDeck()
        {
            foreach (Card c in deckOfCards)
            {
                Console.WriteLine($"The Card is the {c.GetCardFace()} of {c.GetCardSuit()} with a value of {c.GetCardValue()}");
            }
        }

        private void shuffleDeck()
        {
            List<Card> temp1 = new List<Card>();
            List<Card> temp2 = new List<Card>();
            int temp3 = 0;
            Random rnd = new Random();
            int shuffleCount = 7;

            temp1 = new List<Card>(deckOfCards);

            while (shuffleCount > 0)
            {
                while (temp1.Count > 0)
                {
                    temp3 = rnd.Next(temp1.Count);
                    temp2.Add(temp1[temp3]);
                    temp1.RemoveAt(temp3);
                }

                temp1 = new List<Card>(temp2);
                temp2 = new List<Card>();

                shuffleCount--;
            }

            deckOfCards = new List<Card>(temp1);
        }

        public Card drawACard()
        {
            Card drawnCard = deckOfCards[0];
            deckOfCards.RemoveAt(0);
            return drawnCard;
        }

        public List<Card> drawACard(int number)
        {
            List<Card> drawnCards = new List<Card>();

            for (int x = 0; x < number; x++)
            {
                drawnCards.Add(drawACard());
            }

            return drawnCards;
        }
    }
}
