using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Eat : AllocatableAction
    {
        private static readonly int Target = 7;
        public Eat(int previousBalance = 0) : base(Target, previousBalance)
        {

        }

        public override int BalanceAfterTurn
        {
            get { return DiceScore - TargetScore + BalanceFromPreviousTurn; }
        }

        public int LostSelfEsteem
        {
            get { return (BalanceAfterTurn >= 6) ? 2 : 0; }
        }

    }
}
