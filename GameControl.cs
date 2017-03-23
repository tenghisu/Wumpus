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
        
        //player
        int playerPosition;
        char playerOption;

        //wumpus
        int wumpusPosition;
        String wumpusState;
        String wumpusMovingWarning;

        //trivia
        char playerAnswer;

        public static void main(String[] args)
        {
        }
        public GameControl()
        {
            playerPosition = 0;
        }
        public void startGame(Map map, UserInterface UI) //user starts game
        {
            String playerName = UI.playerName();
            char wantNewGame = UI.wantNewGame();
            char gameType = UI.typeOfGame();
            int difficulty = UI.difficultyLevel();
            map.newGame(map);
            
        }
        public int getPlayerPosition(UserInterface UI) //player moves
        {
            playerPosition = UI.playerMoves();
            return playerPosition;
        }
        public char getPlayerOption(UserInterface UI) //player option
        {
            return UI.userOptions();
        }
        public String getWumpusState(Wumpus wumpus, int playerPosition)
        {
            wumpus.setWumpusState(playerPosition);
            String wumpusState = wumpus.getWumpusState();
            return wumpusState;
        }
        public String getWumpusMovingWarning(Wumpus wumpus, int playerPosition)
        {
            return wumpus.wumpusMoving(playerPosition);
        }
        public int getWumpusPosition(Wumpus wumpus)
        {
            wumpus.setWumpusPosition();
            int wumpusPosition = wumpus.getWumpusPosition();
            return wumpusPosition;
        }

    }
}
