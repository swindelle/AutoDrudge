using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Turn
    {
        public List<PlayerTurn> PlayerTurns { get; private set; }

        public Turn()
        {
            PlayerTurns = new List<PlayerTurn>();
        }

        public void AddTurn(PlayerTurn turn)
        {
            PlayerTurns.Add(turn);
        }
    }
}
