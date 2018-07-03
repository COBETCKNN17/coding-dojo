using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string type, string suitType, int value)
        {
            stringVal = type;
            suit = suitType;
            val = value;
        }
    }
}