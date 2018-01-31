using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class PlayerTurn
    {

        public uint DiceCount { get; private set; }

        public Sleep SleepAction { get; private set; }

        public Eat EatAction { get; private set; }

        public Work WorkAction { get; private set; }

        public FreeTime FreeAction { get; private set; }

        public PlayerTurnResult Result { get; private set; }

        public PlayerTurn(PlayerTurn previous)
        {
            if (previous is null)
            {
                DiceCount = 6;
                SleepAction = new Sleep();
                EatAction = new Eat();
                WorkAction = new Work(EatAction, SleepAction);
                FreeAction = new FreeTime();
            }
            else
            {
                DiceCount = previous.DiceCount;
                SleepAction = new Sleep(previous.SleepAction.BalanceAfterTurn);
                EatAction = new Eat(previous.EatAction.BalanceAfterTurn);
                WorkAction = new Work(EatAction, SleepAction);
                FreeAction = new FreeTime();
            }
        }

        public void AllocateDice()
        {
            SleepAction.AllocatedDice = 2;
            EatAction.AllocatedDice = 2;
            WorkAction.AllocatedDice = 2;
            FreeAction.AllocatedDice = 0;
        }

        public void ExecuteTurn()
        {
            SleepAction.CalculateScore();
            EatAction.CalculateScore();
            WorkAction.CalculateScore();
            FreeAction.CalculateScore();

            Result = new PlayerTurnResult();

            Result.MoneyEarned = WorkAction.MoneyEarned;
            if (!WorkAction.TargetMet)
            {
                Result.WarningStrikesEarned++;
            }
            Result.SelfEsteemChange -= SleepAction.LostSelfEsteem;
            Result.SelfEsteemChange -= EatAction.LostSelfEsteem;
        }

    }
}
