using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Map
    {
        public int roomNumberPlayer;
        public int roomNumberWumpus;
        public int roomNumberPit1;
        public int roomNumberPit2;
        public int roomNumberBat1;
        public int roomNumberBat2;

        List<int> ROOMS;
        Trivia trivia;
        Random rand;
        Wumpus wumpus;
        Player player;
        UserInterface UI;

        public void newGame()
        {   
            for(int i = 0; i < 30; i++){
                ROOMS.Add(i);
            }
            Cave newCave = new Cave();
            int roomNumberPlayer = 0;
            int roomNumberPit1 = ROOMS[rand.Next(30)];
            ROOMS.Remove(roomNumberPit1);
            int roomNumberPit2 = ROOMS[rand.Next(29)];
            ROOMS.Remove(roomNumberPit2);
            int roomNumberBat1 = ROOMS[rand.Next(28)];
            ROOMS.Remove(roomNumberBat1);
            int roomNumberBat2 = ROOMS[rand.Next(27)];
            ROOMS.Remove(roomNumberBat2);
        }
        public int wumpusLocation()
        {
            int roomNumberWumpus = 0;
            int wumpusPosition = wumpus.getWumpusPosition();
            String state = wumpus.getWumpusState().ToString();
            int movement = 0;
            if (state == "asleep")
            {
                movement = 0;
            }
            else
            {
                movement = 1;
            }
            if (movement == 1)
            {

            }
            return roomNumberWumpus;
            // given the wumpus state I can make the wumpus move to a whole new room number
        }
        public int getRoomNumberPlayer()
        {
            return roomNumberPlayer;
        }
        public int getRoomNumberWumpus()
        {
            return roomNumberWumpus;
        }
        public int getRoomNumberPit1()
        {
            return roomNumberPit1;
        }
        public int getRoomNumberPit2()
        {
            return roomNumberPit2;
        }
        public int getRoomNumberBat1()
        {
            return roomNumberBat1;
        }
        public int getRoomNumberBat2()
        {
            return roomNumberBat2; 
        }
        public String hazards(Cave c)
        {
            String warning = "";
            if (c.getNodeRoom(roomNumberPlayer).neighborList().Contains(roomNumberPit1) || c.getNodeRoom(roomNumberPlayer).neighborList().Contains(roomNumberPit2))
            {
                warning += "I feel a draft. ";
            }
            if (c.getNodeRoom(roomNumberPlayer).neighborList().Contains(roomNumberBat1) || c.getNodeRoom(roomNumberPlayer).neighborList().Contains(roomNumberBat2))
            {
                warning += "Bats Nearby. ";
            } 
            if (c.getNodeRoom(roomNumberPlayer).neighborList().Contains(roomNumberWumpus))
            {
                warning += "I smell a Wumpus!";
            }
            return warning;
        }
        public void movePlayer(Cave c)
        {
            int click = 0;
            // click == UI.playerMoves();
            List<int> rooms = new List<int>();
            rooms = c.getNodeRoom(roomNumberPlayer).neighborList();
            if (click == 0)
            {
                roomNumberPlayer = rooms[0];
            }
            else if (click == 1)
            {
                roomNumberPlayer = rooms[1];
            }
            else if (click == 2)
            {
                roomNumberPlayer = rooms[2];
            }
            else if (click == 3)
            {
                roomNumberPlayer = rooms[3];
            }
            else if (click == 4)
            {
                roomNumberPlayer = rooms[4];
            }
            else if (click == 5)
            {
                roomNumberPlayer = rooms[5];
            }
            if (roomNumberPlayer == roomNumberWumpus)
            {
                Trivia.GetRandomQuestionAndAnswers();
                player.coins--;
            }
            if (roomNumberPlayer == roomNumberBat1)
            {
                roomNumberPlayer = rand.Next(30);
                ROOMS.Remove(roomNumberPlayer);
                roomNumberBat1 = ROOMS[rand.Next(26)];
                ROOMS.Remove(roomNumberBat1);
            }
            if (roomNumberPlayer == roomNumberBat2)
            {
                roomNumberPlayer = rand.Next(30);
                ROOMS.Remove(roomNumberPlayer);
                roomNumberBat2 = ROOMS[rand.Next(26)];
                ROOMS.Remove(roomNumberBat2);
            }
            if (roomNumberPlayer == roomNumberPit1 || roomNumberPlayer == roomNumberPit2)
            {
                Trivia.GetRandomQuestionAndAnswers();
                player.coins--;
            }
        }
        public int shootArrow()
        {
            int arrows = player.getArrows();
            arrows--;
            return arrows;
        }
        public String buySecret()
        {
            Random rand = new Random();
            String[] secrets = new String [7];
            secrets[0] = "You are in room " + roomNumberPlayer + ".";
            secrets[1] = "The wumpus is in room " + roomNumberWumpus + ".";
            secrets[2] = "A bat is in " + roomNumberBat1 + ".";
            secrets[3] = "A pit is in " + roomNumberPit1 + ".";
            secrets[4] = "A question to a trivia question is " + Trivia.GetAnswer(rand.Next(49));
            secrets[5] = "A bat is in " + roomNumberBat2 + ".";
            secrets[6] = "A pit is in " + roomNumberPit2 + ".";
            return secrets[rand.Next(0, 7)];
        }
    }
}
