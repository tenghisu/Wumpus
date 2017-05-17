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
        public void spendCoin()
        {
            coins--;
        }
        public void setPlayersPosition(int inSet)
        {
            playersPosition = inSet;
        }
        public int getPlayersPosition()
        {
            return playersPosition;
        }
        public int getArrows()
        {
            return arrows;
        }
        public int buyArrow()
        {
            arrows += 2;
            return arrows;
        }
        public void newTurn()
        {
            coins++;
            turns++;
        }
        public int getHighScore()
        {
            return 100 - turns + coins + (10 * arrows);
        }
        public String buySecret()
        {
            string[] secrets = File.ReadAllLines(@"C:\Users\mingq\Downloads\Wumpus-Dank-Memes\Wumpus-Dank-Memes\Secrets.txt");
            Random rand = new Random();
            return secrets[rand.Next(secrets.Length)];
        }
    }
}
