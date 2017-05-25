using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class GameControl
    {
        Wumpus wumpus;
        //UserInterface UI;
        Map map;
        static Trivia trivia;
        Cave cave;
        Player player;

        Boolean alive;

        int questionNumbers;


        List<bool> questionsRight;
  
        public GameControl()
        {
            wumpus = new Wumpus();//int position, int turnsSinceWumpus, enum WumpusState state
            //UI = new UserInterface(); //????
            map = new Map();//roomNumberPlayer, roomNumberWumpus, roomNumberPit1, roomNumberPit2
            trivia = new Trivia();//TriviaList, A-D, AnswerList
            cave = new Cave();
            player = new Player();//arrows, coins, turns, playersPosition, highScore (all int)

            alive = true;
            questionNumbers = 10; //current number of questions in text file
            questionsRight = new List<bool>();
           
        }

        public String getNextQuestion()//for testing?
        {
            Random r = new Random();
            setQuestionNumber(r.Next(1, getNumberOfQuestions()+1));
            return Trivia.GetQuestion(questionNumbers);
        }
        public int getNumberOfQuestions()
        {
            return Trivia.GetNumberOfQuestions();
        }
        public String[] getAnswers()
        {
            return Trivia.GetAnswers(questionNumbers);
        }
        public String getCorrectness(String userAnswer)//userAnswer from UI
        {
            player.spendCoin();
            String correct = "";
            Boolean isCorrect = Trivia.CheckAnswer(userAnswer, questionNumbers);
            if (isCorrect)
            {
                correct = "Correct";
                questionsRight.Add(true);
            }
            else{
                correct = "Incorrect";
            }
            return correct;
        }
        
        public bool triviaRound(int correctNeeded, int chances)//wumpus is 3/5, pit is 2/3, buy 2 arrows 2/3, buy 1 secret 2/3
        {
            bool win = true;
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

        public void playerPosition(int setAs)
        {
            player.setPlayersPosition(setAs);
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
            player.buyArrow();
            return player.getArrows();
        }
        public int getScore()
        {
            return player.getHighScore();
        }

        //getStats as int[] Score, Turns, Coins, Arrows
        public int[] getStats()
        {
            int[] stats = new int[4];
            stats[0] = player.getHighScore();
            stats[1] = 0; //stub, add turns later
            stats[2] = player.getCoins();
            stats[3] = player.getArrows();
            return stats;
        }
   
        
        public String getSecret()
        {
            return player.buySecret();
        }
        //public bool wantArrows(String userOption)//from UI
        //{
        //    bool buy = false;
        //    if (userOption.ToLower().CompareTo("yes") == 0)
        //    {
        //        buy = true;
        //    }
        //    return buy;
        //}
        //public bool wantSecret()//from UI
        //{
        //    bool buy = true;
        //    return buy;
        //}


        public bool getPit()
        {
            bool pit = player.getPlayersPosition() == map.getRoomNumberPit1() || player.getPlayersPosition() == map.getRoomNumberPit1();
            return pit;
        }
        public bool getBat()
        {
            bool bat = player.getPlayersPosition() == map.getRoomNumberBat1() || player.getPlayersPosition() == map.getRoomNumberBat2();
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
        public void setQuestionNumber(int number)//for testing
        {
            questionNumbers = number;
        }
        public int getQuestionNumber()
        {
            return questionNumbers;
        }
        
        public Boolean checkIfAlive()//alive
        {
            return alive;
        }


    }
}
