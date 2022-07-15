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
        public int StakeResult { get; private set; }
        public int CurrentPlayerIndex { get; private set; }

        /*
        0 - default
        1 - current player covered cards
        2 - current player handed cards
        3 - current player transfered card
        */

        public GameController(ref List<PlayerController> players)
        {
            Table = new Dictionary<Card, Card>();
            Players = players;
            PackController = new PackController(Players);
            CurrentPlayerIndex = PackController.FirstStepIndex;
            StakeResult = 0;
        }

        private void StakeUpdate()
        {
            switch (StakeResult)
            {
                case 1:
                    stake = new Stake(CurrentPlayerIndex + 1, Players.Count);
                    break;

                case 2:
                    stake = new Stake(CurrentPlayerIndex + 2, Players.Count);
                    break;

                case 3:
                    stake = new Stake(CurrentPlayerIndex + 1, Players.Count);
                    break;
            }
            CurrentPlayerIndex = stake.DefendingPlayerIndex;
            StakeResult = 0;
        }

        public void HandTableCards()
        {
            Players[CurrentPlayerIndex].HandCards(Table);
            Table.Clear();
            StakeResult = 2;
            StakeUpdate();
        }

        public void Beat()
        {
            Table.Clear();
            StakeResult = 1;
            StakeUpdate();
        }

        public void TransferCard()
        {
            int nextPlayer;
            if(CurrentPlayerIndex == Players.Count - 1)
                nextPlayer = 0;
            else
                nextPlayer = CurrentPlayerIndex + 1;

            Players[CurrentPlayerIndex].TransferCard(Table, Table.Keys.ToList()[0], Players[nextPlayer].Player);
            StakeResult = 3;
            StakeUpdate();
        }

    }
}
