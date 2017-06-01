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
        Map map;
        static Trivia trivia;
        Cave cave;
        Player player;


        Boolean alive;

        int questionNumbers;

        int questionsCorrect;
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
            questionsCorrect = 0;
           
        }
        public void takeTurn()
        {
            player.newTurn();
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
        public bool getCorrectness(String userAnswer)//userAnswer from UI
        {
            int coins = player.getCoins();
            coins--;
            player.setCoins(coins);
            bool correct = Trivia.CheckAnswer(userAnswer, questionNumbers);
            if (correct)
            {
                questionsCorrect++;
            }
            return correct;
        }
        public int getQuestionsCorrect()
        {
            return questionsCorrect;
        }
        public bool winTriviaRound(int correctNeeded, int chances)//wumpus is 3/5, pit is 2/3, buy 2 arrows 2/3, buy 1 secret 2/3
        {
            bool win = true;
            if (questionsCorrect >= correctNeeded)
            {
                win = true;
            }
            else
            {
                win = false;
            }
         //   questionsCorrect = 0;
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

        public void buyArrows()
        {
            player.buyArrow();
        }
        public int getArrows()
        {
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
            stats[1] = player.getTurns();
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


        public int getPosPit1()
        {
            return map.getRoomNumberPit1();
        }
        public int getPosPit2()
        {
            return map.getRoomNumberPit2();
        }
        public int getPosBat1()
        {
            return map.getRoomNumberBat1();
        }
        public int getPosBat2()
        {
            return map.getRoomNumberBat2();
        }
        public bool pitEncounter()
        {
            bool pit = map.getRoomNumberPlayer() == getPosPit1() || map.getRoomNumberPlayer() == getPosPit2();
            return pit;
        }
        public bool batEncounter()
        {
            bool bat = map.getRoomNumberPlayer() == getPosBat1() || map.getRoomNumberPlayer() == getPosBat2();
            return bat;
        }


        public void wumpusEncounter()//will set wumpus state
        {
            wumpus.playerEnters(pitEncounter(), batEncounter(), cave);
        }
        public bool thereIsWumpus()
        {
            if(map.getRoomNumberWumpus() == map.getRoomNumberPlayer())
            {
                return true;
            }
            return false;
        }
        public String getWumpusState()
        {
            return wumpus.getWumpusState().ToString().ToLower();
        }
        
        public String getWarning()
        {
            return map.hazards(cave);
        }
        public void setQuestionNumber(int number)//for testing
        {
            questionNumbers = number;
        }
        public int getQuestionNumber()
        {
            return questionNumbers;
        }
        
        public bool checkIfAlive()//alive
        {
            if (player.getTurns() > 0)
            {
                if (player.getCoins() <= 0 || player.getArrows() <= 0)
                {
                    alive = false;
                }
            }
            return alive;
        }


    }
}
