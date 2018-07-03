using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        string name;
        public List<Card> hand;

        public Player(string playerName)
        {
            name = playerName;
            hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            hand.Add(card);
            return card;
        }

        public Card Discard(int item)
        {
            if(item < 0 || item > hand.Count)
            {
                System.Console.WriteLine("No cards to discard!");
                return null;
            } 
            else 
            {
                Card removed = hand[item];
                hand.RemoveAt(item);
                return removed;
            }
        }
    }
}