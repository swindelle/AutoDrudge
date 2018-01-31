using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public List<Turn> Turns { get; private set; }

        public int MaxTurns { get; private set; }

        public Game(int playerCount, int turnCount)
        {
            Players = new List<Player>();
            Turns = new List<Turn>();
            MaxTurns = turnCount;

            for (int i = 0; i < playerCount; i++)
            {
                Players.Add(new Player(i));
            }
        }

        public void RunGame()
        {
            for (int i = 0; i < MaxTurns; i++)
            {
                var turn = new Turn();
                foreach (var player in Players)
                {
                    var playerTurn = new PlayerTurn(player.previousTurn);
                    player.AddTurn(playerTurn);
                    turn.AddTurn(playerTurn);
                }
                foreach (var player in Players)
                {
                    player.Play();
                }
            }
        }
    }
}
