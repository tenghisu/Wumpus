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
            roomNumberWumpus = roomNumberWumpus + movement;
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
        public String isWumpusCloseToPlayer()
        {
            Boolean warning = false;
            if (roomNumberWumpus + 1 == roomNumberPlayer) 
            {
                warning = true;
            }
            return "I smell a Wumpus";
        }
        public String hazards()
        {
            String warning = "";
            if (roomNumberPlayer.nextTo(roomNumberPit1) || roomNumberPlayer.nextTo(roomNumberPit2))
            {
                warning = "I feel a draft.";
            }
            if (roomNumberPlayer.nextTo(roomNumberBat1) || roomNumberPlayer.nextTo(roomNumberBat2))
            {
                warning = "Bats Nearby.";
            } 
            if (roomNumberPlayer.nextTo(roomNumberWumpus))
            {
                warning = "I smell a Wumpus!";
            }
            return warning;
        }
        public void movePlayer()
        {
            if (roomNumberPlayer == roomNumberWumpus)
            {
                Trivia.GetRandomQuestionAndAnswers();
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
            secrets[0] = roomNumberPlayer.ToString();
            secrets[1] = roomNumberWumpus.ToString();
            secrets[2] = roomNumberBat1.ToString();
            secrets[3] = roomNumberPit1.ToString();
            secrets[4] = Trivia.GetAnswer(rand.Next(49));
            secrets[5] = roomNumberBat2.ToString();
            secrets[6] = roomNumberPit2.ToString();
            return secrets[rand.Next(7)];
        }
    }
}
