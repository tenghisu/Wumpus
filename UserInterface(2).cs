using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class UserInterface
    {
        public UserInterface()
        {

        }

        public char wantNewGame()
        {
            //depending on user input if they want to start a new game
            return 'a'; //returns what the user chose to do - eg. start new game, help, quit, etc.
        }
        public char typeOfGame()
        {
            //asks user to choose what the theme of the game is given options such as "space", "western", etc
            return 'a'; //returns which theme/option chosen to game control
        }
        public int difficultyLevel()
        {
            //user chooses difficulty wanted
            return 0; //returns difficulty level user wants to play at
        }
        public char triviaAnswer()
        {
            //what answer choice was selected by the user for the trivia questions
            return 'a';  //returns which answer choice was selected to game control
        }
        public String playerName()
        {
            //asks user what they would like their name to be at the start of the game
            return "Joe"; //returns inputed name of player to game control
        }
        public int playerMoves()
        {
            //marks which cave the user chose to go into
            //displays answer to a trivia question
            return 0; //returns the number of the cave into which the player chose to move into to map/player object
        }
        public char userOptions()
        {
            //in each new cave display the options the user has depending on the scenario - such as buying a hint, shooting
            //an arrow, answering trivia, etc.
            return 'a'; //returns what option ther user chose to do
        }
        public void hasFailed()
        {
            //displays message of failure and why depending on cause (eg. wrong answer, pit, etc)
        }
        public void byAHazard()
        {
            //receives what hazard there is nearby a player and then displays the 
            //appropriate hint
        }
        public void triviaTime()
        {
            //receives trivia question from Trivia object and displays it
        }
        public void inACave()
        {
            //displays new cave and any hazards located there
            //displays inventory
            //displays adjacent rooms
        }
    }
}
