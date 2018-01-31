using System;

public abstract class AllocatableAction
{
    public uint AllocatedDice { get; set; }
    public int DiceScore { get; set; }
    public virtual int TurnScore { get { return DiceScore + BalanceFromPreviousTurn; }  }
    public int BalanceFromPreviousTurn { get; }
    public abstract int BalanceAfterTurn { get; }
    public int TargetScore { get; private set; }
    public bool TargetMet {  get { return TurnScore >= TargetScore; } }

    public AllocatableAction(int target, int previousBalance = 0)
    {
        TargetScore = target;
        BalanceFromPreviousTurn = previousBalance;
    }

    public virtual void CalculateScore()
    {
        DiceScore = Dice.Roll(AllocatedDice);
    }
}
