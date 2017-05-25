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
        public String alive;

        Map map;
        GameControl gameControl;

        public Player()
        {
            arrows = 3;
            coins = 0;
            turns = 0;
            playersPosition = 0;
            highScore = 0;
        }
        public void newTurn()
        {
            if (coins <= 100)
            {
                coins++;
            }
            turns++;
        }
        public int getCoins()
        {
            return coins;
        }
        public void setPlayersPosition()
        {
            playersPosition = map.getRoomNumberPlayer();
        }
        public int getArrows()
        {
            if (arrows == 0)
            {
                death();
            }
            return arrows;
        }
        public void buyArrow()
        {
            coins--;
            gameControl.getNextQuestion();
            arrows += 2;
        }
        public int getHighScore()
        {
            return 100 - turns + coins + (10 * arrows);
        }
        public String buySecret()
        {
            String secret = map.buySecret();
            return secret;
        }
        public void shotArrow()
        {
            arrows = map.shootArrow();
        }
        public void death()
        {
            getHighScore();
            alive = "death";
        }
    }
}
