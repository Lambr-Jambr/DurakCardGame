using Durak_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalVar;
using Durak_BL.Interface;

namespace Durak_BL.Controller
{
    public class PlayerController : IPlayerActivity
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

        #region Interface Realization
        public void HandCards(Dictionary<Card, Card> table)
        {
            Player.Cards.AddRange(table.Keys.ToList());
            Player.Cards.AddRange(table.Values.ToList());
            foreach (var card in Player.Cards)
            {
                if (card == Global.DefaultCard)
                    Player.Cards.Remove(card);
            }
            Player.Cards.Sort();
            table.Clear();
        }

        public bool BeatCard(Card CoveringCard, Card CoveredCard, ref Dictionary<Card, Card> table)
        {
            var allowCovering = false;
            if (table == null || table.Count == 0)
            {
                throw new ArgumentException("", nameof(table));
            }

            if (CoveringCard > CoveredCard)
            {
                table[CoveredCard] = CoveringCard;
                Player.Cards.Remove(CoveringCard);
                allowCovering = true;
            }
            return allowCovering;
        }

        public void TransferCard(ref Dictionary<Card, Card> table, Card transferingCard)
        {
            foreach (var card in table.Values)
            {
                if (card != Global.DefaultCard) return;
            }

            if (table.Count == 0) return;

            if (transferingCard.Rank == table.Keys.ToList()[0].Rank)
            {
                Step(ref table, transferingCard);
            }
        }

        public void ThrowCard(ref Dictionary<Card, Card> table, Card card)
        {
            if (AllowThrowCard(ref table, card))
            {
                Step(ref table, card);
            }
        }

        public void Step(ref Dictionary<Card, Card> table, Card card)
        {
                table.Add(card, Global.DefaultCard);
                Player.Cards.Remove(card);
        }
        #endregion

        private bool AllowThrowCard(ref Dictionary<Card, Card> table, Card card)
        {
            if(table.Count == 0 || table.Count == 6) return false;
            var result = false;
            var tableCards = new List<Card>();
            tableCards.AddRange(table.Values);
            tableCards.AddRange(table.Keys);
            for(int i = 0; i < tableCards.Count; i++)
            {
                if(card.Rank == tableCards[i].Rank)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        
    }
}
