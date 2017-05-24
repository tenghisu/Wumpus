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
      
        int questionNumber;
        
        List<Boolean> questionsRight;
  
        public GameControl()
        {
            wumpus = new Wumpus();//int position, int turnsSinceWumpus, enum WumpusState state
            UI = new UserInterface(); //????
            map = new Map();//roomNumberPlayer, roomNumberWumpus, roomNumberPit1, roomNumberPit2
            trivia = new Trivia();//TriviaList, A-D, AnswerList
            cave = new Cave();
            player = new Player();//arrows, coins, turns, playersPosition, highScore (all int)

            alive = true;
            questionNumber = 2;//total number of questions in trivia text doc
            questionsRight = new List<bool>();
           
        }


        public String getNextQuestion()//trivia
        {
            return Trivia.GetQuestion(questionNumber);
        }
        public Boolean getCorrectness(String userAnswer)//userAnswer from UI
        {
            Boolean correct = Trivia.CheckAnswer(userAnswer, questionNumber);
            if (correct)
            {
                questionsRight.Add(true);
            }
            return correct;
        }
        public Boolean triviaRound(int correctNeeded, int chances)//wumpus is 3/5, pit is 2/3, buy 2 arrows 2/3, buy 1 secret 2/3
        {
            Boolean win = true;
            if (correctNeeded >= questionsRight.Count())
            {
                win = true;
            }
            else
            {
                win = false;
            }
            return win;
        }
        public List<Boolean> getQuestionsRight()
        {
            return questionsRight;
        }

        public int getPlayerPosition()
        {
            return map.getRoomNumberPlayer();
        }

        public int getCoins()
        {
            return player.getCoins();
        }
        public int getArrows()
        {
            return player.getArrows();
        }
        public int getScore()
        {
            return player.getHighScore();
        }

        public void setQuestionNumber(int number)//for testing
        {
            questionNumber = number;
        }

        public int getQuestionNumber()
        {
            return questionNumber;
        }
        
        public String getSecret()
        {
            return player.buySecret();
        }
        public Boolean wantArrows(String userOption)//from UI
        {
            Boolean buy = false;
            if (userOption.ToLower().CompareTo("yes") == 0)
            {
                buy = true;
            }
            return buy;
        }
        public Boolean wantSecret(String userOption)//from UI
        {
            Boolean buy = false;
            if (userOption.ToLower().CompareTo("yes") == 0)
            {
                buy = true;
            }
            return buy;
        }


        public Boolean getPit()
        {
            Boolean pit = map.getRoomNumberPlayer() == map.getRoomNumberPit1() || map.getRoomNumberPlayer() == map.getRoomNumberPit1();
            return pit;
        }
        public Boolean getBat()
        {
            Boolean bat = map.getRoomNumberPlayer() == map.getRoomNumberBat1() || map.getRoomNumberPlayer() == map.getRoomNumberBat2();
            return bat;
        }


        public void wumpusEncounter()
        {
            wumpus.playerEnters(getPit(), getBat(), cave);
        }
        public String getWumpusState()
        {
            return wumpus.getWumpusState().ToString().ToLower();
        }
        
        public String getWarning()
        {
            String warn = "";
            if (Math.Abs(map.getRoomNumberPlayer()-wumpus.getWumpusPosition())==1)
            {
                warn += "I smell a Wumpus! ";
            }
            if (Math.Abs(map.getRoomNumberPlayer() - map.getRoomNumberBat1()) == 1 || Math.Abs(map.getRoomNumberPlayer() - map.getRoomNumberBat2()) == 1)
            {
                warn+= "Bats Nearby ";
            }
            if (Math.Abs(map.getRoomNumberPlayer() - map.getRoomNumberPit1()) == 1 || Math.Abs(map.getRoomNumberPlayer() - map.getRoomNumberPit2()) == 1)
            {
                warn+= "I feel a draft";
            }
            return warn;
        }

        public Boolean checkIfAlive()//alive
        {
            return alive;
        }

    }
}
