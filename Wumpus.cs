using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Wumpus
    {
        //for Lazy Wumpus
        private int position;
        private int turnsSinceWumpus;
        private WumpusState state;

        enum WumpusState

        {
            Asleep = 1,
            Awake = 2,
            Moving = 3,
        }
        

        public Wumpus()
        {
            //constructor
            state = WumpusState.Awake;
            //state = "awake";
            //randomly generate position
            position = new Random().Next(1, 31);


        }
        public Wumpus(WumpusState state, int position)
        {
            this.state = state;
            this.position = position;
        }

        //public void wumpusMoving(int playerPosition) //randomly moves - 30% chance for everything?
        //{


        //    //get wumpus position and caves around it
        //    //random generate which ones is around

        //}


        public void moveWumpus(int rooms, Cave c1)
        {
            //Make it run only 1 room at a time!!!!!! 
            if (rooms == 0)
            {
                return;
            }
            else if(rooms == 1)
            {
                int newPosition = c1.getNodeRoom(position).getRandomNeighbor().Value.ID();

                position = newPosition;

                moveWumpus(rooms - 1, c1);
            }
            else
            {
                //make it run only one room each turn
                int turns = rooms;
                //Player object for turns
                
            }
        }

        public void fallsAsleep()
        {
            if (turnsSinceWumpus > 2)
            {
                state = WumpusState.Asleep;
                //add
            }
        }
        public void wumpusDefeat(Boolean defeat, Cave c1)
        {
            if (defeat == true)
            {
                Node<Room> current = new Node<Room>(new Room(position));

                //call cave to make it run 3 rooms away
                Random r = new Random();
                int number = r.Next(3) + 1;

                moveWumpus(number, c1);
                state = WumpusState.Moving;
            }

        }


        public void setWumpusPosition(int p)
        {
            position = p;
            //Cave will return back 

        }

        public WumpusState getWumpusState()
        {
            return state;
        }

        public String getWumpusMoving(int playerPosition)
        {
            return "Wumpus is moving";
        }

        public int getWumpusPosition()
        {
            return position;
        }

        public void playerEnters(int playerPosition, Boolean pit, Boolean bats, Cave c1) //situations awakening Wumpus; when player enters the same room
        {
            state = WumpusState.Asleep;
            if (playerPosition == position && pit == false && bats == false)
            {
                state = WumpusState.Awake;
                //GC/UI calls trivia
                turnsSinceWumpus = 0;

            }
            else if (playerPosition == position && pit == true && bats == false)
            {
                state = WumpusState.Awake;
                //position moves
                moveWumpus(1, c1);
                turnsSinceWumpus = 0;
            }
            else if (playerPosition == position && pit == false && bats == true)
            {
                state = WumpusState.Awake;
                //position moves
                moveWumpus(1, c1);
                turnsSinceWumpus = 0;
            }
            else
            {
                turnsSinceWumpus++;
            }

        }
        public void shootsArrows(Boolean shootsArrow, Cave c1) //if player shoots arrow at Wumpus
        {
            if (state == WumpusState.Asleep && shootsArrow == true)
            {
                state = WumpusState.Awake;
                int runNumber = new Random().Next(1, 3); //makes it run up to 2 rooms
                turnsSinceWumpus = 0;
                moveWumpus(runNumber, c1);
                state = WumpusState.Moving;

            }
            else
            {
                turnsSinceWumpus++;
            }
        }
    }
}