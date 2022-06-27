using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_BL.Model
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Cards { get; set; }
        public bool IsPlaying { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
            IsPlaying = false;
        }

        public Player(string name, ref Card[] cards)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Недопустимое имя.", nameof(name));
            }

            if(cards.Length != 6)
            {
                throw new ArgumentException("Некорректный набор карт.", nameof(cards));
            }

            Name = name;
            Cards = Cards.ToList();
            IsPlaying = false;
        }

        public override string ToString()
        {
            string cards = "";
            foreach(var card in Cards)
            {
                cards += card.ToString() + "\n";
            }
            return Name + "\n" + cards;
        }
    }
}
