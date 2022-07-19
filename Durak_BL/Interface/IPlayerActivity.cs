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
        bool BeatCard(Card CoveringCard, Card CoveredCard, Dictionary<Card, Card> table);
        void TransferCard(Dictionary<Card, Card> table, Card transferingCard, Player nextPlayer);
        void ThrowCard(Dictionary<Card, Card> table, Card card);
        void Step(Dictionary<Card, Card> table, Card card);
    }
}
