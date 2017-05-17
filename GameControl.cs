using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class GameControl
    {
        Wumpus wumpus;
        UserInterface UI;
        Map map;
        static Trivia trivia;
        Cave cave;
        Player player;

        Boolean alive;
        Boolean winTrivia;
        int questionNumber;
        int beginningPosition;
        public GameControl()
        {
            wumpus = new Wumpus();//int position, int turnsSinceWumpus, enum WumpusState state
            UI = new UserInterface(); //????
            map = new Map();//roomNumberPlayer, roomNumberWumpus, roomNumberPit1, roomNumberPit2
            trivia = new Trivia();//TriviaList, A-D, AnswerList
            cave = new Cave();
            player = new Player();//arrows, coins, turns, playersPosition, highScore (all int)

            alive = true;
            questionNumber = 15;
            winTrivia = true;
            beginningPosition = 0;//get from cave the actual number?
        }

        
        public String getNextQuestion(int questionNumber)
        {
            Random r = new Random();
            questionNumber = r.Next(1, questionNumber + 1);
            return Trivia.GetQuestion(questionNumber);
        }
        public Boolean getCorrectness(String userAnswer)//userAnswer from UI
        {
            return Trivia.CheckAnswer(userAnswer, questionNumber);
        }
        public Boolean checkIfAlive()
        {
            return alive;
        }
        public void triviaRound(int correctNeeded, int chances)//wumpus is 3/5, pit is 2/3, buy 2 arrows 2/3, buy 1 secret 2/3
        {
            int tries = 0;
            int numberCorrect = 0;
            while(tries <= chances-1 && correctNeeded-numberCorrect <= chances-1-tries && player.getCoins() !=0)
            {
                Boolean correct = getCorrectness("B");//get real userAnswer from UI after she does it
                player.spendCoin();
                if (correct)
                {
                    numberCorrect++;
                }
                questionNumber--;
                tries++;
            }
            if(numberCorrect == correctNeeded)
            {
                winTrivia = true;
            }
            else
            {
                winTrivia = false;
            }
        }
        public Boolean getWinTrivia()
        {
            return winTrivia;
        }
        public void encounterPit()
        {
            if(player.getPlayersPosition()==map.getRoomNumberPit1() || player.getPlayersPosition() == map. getRoomNumberPit2())
            winTrivia = false;
            triviaRound(2, 3);
            if (!getWinTrivia())
            {
                player.setPlayersPosition(beginningPosition);
            }
        }

        
        //buy things$$
        public String secret()
        {
            winTrivia = false;
            triviaRound(2, 3);
            if (getWinTrivia())
            {
                return player.buySecret();
            }
            return "Failed to purchase a secret :(";
        }
        public void arrow()
        {
            winTrivia = false;
            triviaRound(2, 3);
            if (getWinTrivia())
            {
                player.buyArrow();
            }
        }

        public void takeTurn()
        {
            if(player.getArrows()==0 || player.getCoins()==0) 
            {
            alive = false; //(rip)
            }
            player.newTurn();
            //find new playerposition, add after map/cave is done?

            //UI asks if they want to buy stuff
            if (player.getPlayersPosition() == wumpus.getWumpusPosition())//encounter
            {
                encounterWithWumpus();
            }
        }

        public void encounterWithWumpus()
        {
            Boolean pit = player.getPlayersPosition() == map.getRoomNumberPit1() || player.getPlayersPosition() == map.getRoomNumberPit1();
            Boolean bat = player.getPlayersPosition() == map.getRoomNumberBat1() || player.getPlayersPosition() == map.getRoomNumberBat2();

            wumpus.playerEnters(pit, bat, cave);
            if (wumpus.getWumpusState().ToString().ToLower() == "awake" && bat == false && pit == false)
            {
                winTrivia = false;
                triviaRound(3, 5);
                if (!getWinTrivia())
                {
                    alive = false; // rip
                }
            }
            else if (bat == true)
            {
                //add when cave/map is done
            }
            else if(pit == true)
            {
                encounterPit();
            }
        }
        public String getWarning()
        {
            String warn = "";
            if (Math.Abs(player.getPlayersPosition()-wumpus.getWumpusPosition())==1)
            {
                warn += "I smell a Wumpus! ";
            }
            if (Math.Abs(player.getPlayersPosition() - map.getRoomNumberBat1()) == 1 || Math.Abs(player.getPlayersPosition() - map.getRoomNumberBat2()) == 1)
            {
                warn+= "Bats Nearby ";
            }
            if(Math.Abs(player.getPlayersPosition() - map.getRoomNumberPit1()) == 1|| Math.Abs(player.getPlayersPosition() - map.getRoomNumberPit2()) == 1)
            {
                warn+= "I feel a draft";
            }
            return warn;
        }
        
        
    }
}
