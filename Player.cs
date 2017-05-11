using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Player
    {
        private int arrows;
        private int money;
        private int turns;
        private int playersPosition;

        
        public Player()
        {
            arrows = 0;
            money = 0;
            turns = 0;
            playersPosition = 0;
        }

        public int getMoney()
        {
            money++;
            return money;
        }

        public int getRoom()
        {
            int playersPosition = Player.getPlayersPosition();
            return playersPosition;
        }
        public int buyArrow()
        {
            arrows++;
            return arrows;
        }
        public int newTurn()
        {
            return 
        }
    }
}
