using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Player
    {
        private int arrows;
        private int coins;
        private int turns;
        private int playersPosition;
        public int highScore;

        Map map;

        public Player()
        {
            arrows = 3;
            coins = 0;
            turns = 0;
            playersPosition = 0;
            highScore = 0;
        }

        public int getCoins()
        {
            return coins;
        }
        public void setPlayersPosition(int inSet)
        {
            playersPosition = inSet;
        }
        public int getArrows()
        {
            return arrows;
        }
        public void buyArrow()
        {
            coins--;
            // calls trivia
            arrows += 2;
        }
        public void newTurn()
        {
            if (coins <= 100)
            {
                coins++;
            }
            turns++;
        }
        public int getHighScore()
        {
            return 100 - turns + coins + (10 * arrows);
        }
        public String buySecret()
        {
            return "";
        }
        public void shotArrow()
        {
            arrows = map.shootArrow();
        }
    }
}
