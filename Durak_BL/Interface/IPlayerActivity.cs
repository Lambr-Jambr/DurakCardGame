using Durak_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_BL.Interface
{
    public interface IPlayerActivity
    {
        void HandCards(Dictionary<Card, Card> table);
        bool BeatCard(Card CoveringCard, Card CoveredCard, ref Dictionary<Card, Card> table);
        void TransferCard(ref Dictionary<Card, Card> table, Card transferingCard, Player nextPlayer);
        void ThrowCard(ref Dictionary<Card, Card> table, Card card);
        void Step(ref Dictionary<Card, Card> table, Card card);
    }
}
