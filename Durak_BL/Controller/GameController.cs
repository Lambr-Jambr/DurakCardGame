using Durak_BL.Enums;
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
        public int _stakeResult { get; private set; }
        public int CurrentPlayerIndex { get; private set; }

        public GameController(ref List<PlayerController> players)
        {
            Table = new Dictionary<Card, Card>();
            Players = players;
            PackController = new PackController(Players);
            CurrentPlayerIndex = PackController.FirstStepIndex;
            _stakeResult = 0;
        }

        private void StakeUpdate()
        {
            switch (_stakeResult)
            {
                case (int)StakeResult.Beat:
                    stake = new Stake(CurrentPlayerIndex + 1, Players.Count);
                    break;

                case (int)StakeResult.Hand:
                    stake = new Stake(CurrentPlayerIndex + 2, Players.Count);
                    break;

                case (int)StakeResult.Transfer:
                    stake = new Stake(CurrentPlayerIndex + 1, Players.Count);
                    break;
            }
            CurrentPlayerIndex = stake.DefendingPlayerIndex;
            _stakeResult = 0;
        }

        public void HandTableCards()
        {
            Players[CurrentPlayerIndex].HandCards(Table);
            Table.Clear();
            PackController.DealCards(Players, stake);
            _stakeResult = (int)StakeResult.Hand;
            StakeUpdate();
        }

        public void Beat()
        {
            Table.Clear();
            PackController.DealCards(Players, stake);
            _stakeResult = (int)StakeResult.Beat;
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
            _stakeResult = (int)StakeResult.Transfer;
            StakeUpdate();
        }

    }
}
