using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            Player Nat = new Player("Nat");
            Console.WriteLine(deck.cards.Count);

            Nat.Draw(deck);
            Console.WriteLine(Nat.hand.Count);
            Nat.Draw(deck);
            Nat.Draw(deck);
            Nat.Draw(deck);
            Console.WriteLine(Nat.hand.Count);
            Nat.Discard(4);
            Console.WriteLine(Nat.hand.Count);
            
        }
    }
}
