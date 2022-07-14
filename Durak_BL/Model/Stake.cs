using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_BL.Model
{
    public class Stake
    {
        public int AttackingPlayerIndex { get; }
        public int DefendingPlayerIndex { get; }
        public List<int> AllowThrow { get; }

        public Stake(int defendingPlayerIndex, int PlayersCount)
        {
            AllowThrow = new List<int>();
            DefendingPlayerIndex = defendingPlayerIndex;
            if (defendingPlayerIndex == 0)
            {
                AllowThrow.Add(AttackingPlayerIndex = PlayersCount - 1);
                AllowThrow.Add(DefendingPlayerIndex + 1);
            }
            else if(defendingPlayerIndex == PlayersCount - 1)
            {
                AllowThrow.Add(AttackingPlayerIndex = defendingPlayerIndex - 1);
                AllowThrow.Add(0);
            } 
            else
            {
                AllowThrow.Add(AttackingPlayerIndex = defendingPlayerIndex - 1);
                AllowThrow.Add(DefendingPlayerIndex + 1);
            }
                
        }
    }
}
