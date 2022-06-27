using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Durak_BL.Enums;

namespace Durak_BL.Model
{
    public class Pack
    {
        private static readonly Random rnd = new Random();
        public List<Card> Cards { get; }
        public int TrumpSuit { get; }

        public Pack(List<Card> cards)
        {
            if(cards.Count != 36 || cards == null)
            {
                throw new ArgumentException("Колода некорректна.", nameof(cards));
            }
            Cards = cards;
            TrumpSuit = rnd.Next((int)CardSuit.Diamonds, (int)CardSuit.Spades + 1);
            Card.SpecifyTrump(Cards, TrumpSuit);
        }

        public override string ToString()
        {
            string cards = "";
            foreach (var card in Cards)
            {
                cards += card.ToString() + "\n";
}
            return "Trump: " + (CardSuit)TrumpSuit + "\nCards count: " + Cards.Count + "\n" + cards;
        }
    }
}
