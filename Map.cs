﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Map
    {
        private int roomNumberPlayer;
        private int roomNumberWumpus;
        private int roomNumberPit1;
        private int roomNumberPit2;
        private int highScore;


        public Map()
        {
            roomNumberPit1 = 0;
            roomNumberPit2 = 0;
            roomNumberPlayer = 0;
            roomNumberWumpus = 0;
        }

        public Map newGame(Map newMap)
        {
            Cave newCave = new Cave();
            return newMap;
            // in new game this can return a map filled with 
            // the player and hazards
        }
        public int wumpusLocation()
        {
            Wumpus wumpus = new Wumpus();
            int wumpusPosition = wumpus.getWumpusPosition();
            WumpusState state = wumpus.getWumpusState();
            int movement = 0;
            if (state == "asleep")
            {
                movement = 0;
            }
            else
            {
                movement = 1;
            }
            return roomNumberWumpus + movement;
            // given the wumpus state I can make the wumpus move to a whole new room number
        }
        
        public void callTrivia()
        {
            // calls trivia that we need trivia after hitting hazard
        }
        
        //public void trivia(Trivia correctness)
        //{
            // calls trivia to see correct or incorrect to factor into player's inventory
        //}
        
        public int highScore()
        {
            if()
            return highScore;
            // returns player's inventory to high score so that they can add up high score
        }
        public Boolean isWumpusCloseToPlayer()
        {
            Wumpus wumpus = new Wumpus();
            Player player = new Player();
            Boolean warning;
            int roomNumberWumpus = wumpus.getWumpusPosition();
            int roomNumberPlayer = player.getPlayerPosition();
            if (roomNumberWumpus + 2 == roomNumberPlayer)
            {
                warning = true;
            }
            return warning;
        }
        public Boolean hazards()
        {
            return false;
        }
    }
}

