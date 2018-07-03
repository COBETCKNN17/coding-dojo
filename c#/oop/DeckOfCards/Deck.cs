using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            Reset();
            Shuffle();
        }

        public Deck Reset()
        {
            cards = new List<Card>();
            string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8" ,"9", "10", "Jack", "Queen", "King" };
            string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };

            foreach(string suit in suits)
            {
                for(int i = 0; i < stringVals.Length; i++)
                {
                    Card card = new Card(stringVals[i], suit, i+1);
                    cards.Add(card);
                }
            }
            return this;
        }

        public Deck Shuffle()
        {
            Random random = new Random();
            for(int val = cards.Count-1; val > 0; val--)
            {
                int randomCard = random.Next(val);
                Card tempCard = cards[randomCard];
                cards[randomCard] = cards[val];
                cards[val] = tempCard;
            }
            return this;
        }

        public Card Deal()
        {
            if(cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            } 
            else 
            {
                Reset();
                return Deal();
            }
        }
    }
}