using Durak_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalVar;

namespace Durak_BL.Controller
{
    public class PlayerController
    {
        public Player Player { get; }
        public Account Account { get; }

        public PlayerController(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("", nameof(account));
            }
            Player = new Player(account.Name);
        }

        public void HandCards(Dictionary<Card, Card> table)
        {
            Player.Cards.AddRange(table.Keys.ToList());
            Player.Cards.AddRange(table.Values.ToList());
            foreach(var card in Player.Cards)
            {
                if(card == Global.DefaultCard)
                    Player.Cards.Remove(card);
            }
            Player.Cards.Sort();
            table.Clear();
        }

        public bool BeatCard(Card CoveringCard, Card CoveredCard, ref Dictionary<Card, Card> table)
        {
            var allowCovering = false;
            if(table == null || table.Count == 0)
            {
                throw new ArgumentException("", nameof(table));
            }

            if(CoveringCard > CoveredCard)
            {
                table[CoveredCard] = CoveringCard;
                Player.Cards.Remove(CoveringCard);
                allowCovering = true;
            }
            return allowCovering;
        }

    }
}
