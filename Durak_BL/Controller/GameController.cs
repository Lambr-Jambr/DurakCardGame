using Durak_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_BL.Controller
{
    public class GameController
    {
        public Stake stake { get; private set; }
        public Dictionary<Card, Card> Table { get; }
        public PackController PackController { get; private set; }
        public List<PlayerController> Players { get; } 
        public int CurrentPlayerIndex { get; private set; }

        public GameController(ref List<PlayerController> players)
        {
            Table = new Dictionary<Card, Card>();
            Players = players;
            PackController = new PackController(Players);
        }

        public void StakeUpdate()
        {
            stake = new Stake(CurrentPlayerIndex, Players.Count);
        }

        public void HandTableCards()
        {
            Players[CurrentPlayerIndex].HandCards(Table);
        }
    }
}
