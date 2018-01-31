using System;

public abstract class AllocatableAction
{
    public int AllocatedDice { get; set; }
    public int DiceScore { get; set; }
    public int TurnScore { get { return DiceScore + BalanceFromPreviousTurn; }  }
    public int BalanceFromPreviousTurn { get; }
    public abstract int BalanceAfterTurn { get; }
    public int TargetScore { get; private set; }
    public bool TargetMet {  get { return TurnScore >= TargetScore; } }

    public AllocatableAction(int previousBalance = 0)
    {
        BalanceFromPreviousTurn = previousBalance;

    }

    public virtual void CalculateScore()
    {
        DiceScore = Dice.Roll(AllocatedDice);
    }
}
