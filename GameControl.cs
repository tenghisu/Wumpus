using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class GameControl
    {
        //initialize
        Wumpus wumpus;
        UserInterface UI;
        Map map;
        static Trivia trivia;
        Cave cave;
        
        //player
        int playerPosition;
        char playerOption;

        //wumpus
        int wumpusPosition;
        String wumpusState;

        //trivia
        int questionNum;
        String question;
        String answer;
        Boolean correct;

        public GameControl()
        {
            //player
            playerPosition = 0;
            
            //wumpus
            wumpus = new Wumpus();
            this.wumpusPosition = wumpus.getWumpusPosition();
            this.wumpusState = wumpus.getWumpusState();
            
            //trivia
            questionNum = 15;
            question = "";
            answer = "";
            correct = true;

            //cave
            cave = new Cave();
            cave.initialize();
        }
        
        public void startGame() //user starts game
        {
            String playerName = UI.playerName();
            char wantNewGame = UI.wantNewGame();
            char gameType = UI.typeOfGame();
            int difficulty = UI.difficultyLevel();
            map.newGame(map);
            
        }
        public int getPlayerPosition() //player moves
        {
            playerPosition = UI.playerMoves();
            return playerPosition;
        }

        public char getPlayerOption() //player option
        {
            return UI.userOptions();
        }

        public void encounter()
        {
            playerPosition = getPlayerPosition();
            wumpusPosition = wumpus.getWumpusPosition();
            if (playerPosition == wumpusPosition)
            {
                //fight? idek
            }
        }

        public void goToTrivia() //trivia?
        {
            question = Trivia.GetQuestion(questionNum);
            answer = Trivia.GetAnswer(questionNum);
            correct = Trivia.CheckAnswer(answer, questionNum);
        }
    }
}
