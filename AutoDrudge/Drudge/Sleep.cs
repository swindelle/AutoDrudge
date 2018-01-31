using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Sleep : AllocatableAction
    {
        private static readonly int Target = 6;
        public Sleep(int previousBalance = 0) : base(Target, previousBalance)
        {
            
        }

        public override int BalanceAfterTurn
        {
            get { return DiceScore - TargetScore + BalanceFromPreviousTurn; }
        }
    }
}
