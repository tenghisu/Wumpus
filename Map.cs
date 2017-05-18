﻿using System;
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

        public void newGame()
        {
            Random rand = new Random();
            List<int> ROOMS = new List<int>();
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
            int roomNumberBat2 = ROOMS[rand.Next(30)];
            ROOMS.Remove(roomNumberBat2);
        }
        public int wumpusLocation()
        {
            int roomNumberWumpus = 0;
            Wumpus wumpus = new Wumpus();
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
        //public void callTrivia()
        //{
        //    // calls trivia that we need trivia after hitting hazard
        //}
        //public void trivia(Trivia correctness)
        //{
        //    // calls trivia to see correct or incorrect to factor into player's inventory
        //}
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
            } if (roomNumberPlayer.nextTo(roomNumberWumpus))
            {
                warning = "I smell a Wumpus!";
            }
            return warning;
        }
    }
}