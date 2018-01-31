using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Player
    {
        public int SelfEsteem { get; set; }
        public int WarningStrikes { get; set; }
        public int Money { get; set; }
        public int AssetValue { get; set; }

        public List<PlayerTurn> Turns { get; set; }

        public PlayerTurn previousTurn { get; private set; }

        public PlayerTurn currentTurn { get; private set; }

        private int playerID;

        public Player(int playerID)
        {
            previousTurn = null;
            Turns = new List<PlayerTurn>();
            this.playerID = playerID;
        }

        public void AddTurn(PlayerTurn turn)
        {
            Turns.Add(turn);
            currentTurn = turn;
        }

        public void Play()
        {
            currentTurn.AllocateDice();
            currentTurn.ExecuteTurn();
            Money += currentTurn.Result.MoneyEarned;
            SelfEsteem += currentTurn.Result.SelfEsteemChange;
            WarningStrikes += currentTurn.Result.WarningStrikesEarned;
            previousTurn = currentTurn;
            Console.WriteLine("PLayer {0} Turn{1} Money {2} SelfEsteem {3} WarningStrikes {4}", playerID, Turns.Count, Money, SelfEsteem, WarningStrikes);
        }
    }
}
