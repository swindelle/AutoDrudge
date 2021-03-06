﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Work : AllocatableAction
    {
        private static readonly int Target = 8;

        private readonly AllocatableAction EatAction;
        private readonly AllocatableAction SleepAction;
        private bool hasRerolled = false;

        public Work(AllocatableAction eat, AllocatableAction sleep) : base(Target)
        {
            EatAction = eat;
            SleepAction = sleep;
        }

        public override int BalanceAfterTurn
        {
            get { return 0; }
        }

        public override int TurnScore { get { return DiceScore + BalanceFromPreviousTurn +
                    (SleepAction.TargetMet?0:SleepAction.TurnScore-SleepAction.TargetScore); } }


        public bool CanReRoll
        {
            get
            {
                return EatAction.BalanceAfterTurn >= 0 && !hasRerolled;
            }
        }

        public void ReRoll()
        {
            if (CanReRoll)
            {
                hasRerolled = true;
                CalculateScore();
            }
        }

        public int MoneyEarned
        {
            get
            {
                int money = 0;
                if (TurnScore > 15)
                {
                    money = (int)AllocatedDice + 3;
                }
                else if (TurnScore > 12)
                {
                    money = (int)AllocatedDice + 2;
                }
                else if (TurnScore > 9)
                {
                    money = (int)AllocatedDice + 1;
                }
                else if (TurnScore >= TargetScore)
                {
                    money = (int)AllocatedDice;
                }
                return money;
            }
        }

    }
}
