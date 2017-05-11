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
        //private String state;
        private int position;
        private int turnsSinceWumpus;

        enum WumpusState
        {
            Asleep = 1,
            Awake = 2,
            Moving = 3,
        }
        private WumpusState state;

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
     
        public void wumpusMoving(int playerPosition) //randomly moves - 30% chance for everything?
        {


            //get wumpus position and caves around it
            //random generate which ones is around
            
        }


        public void moveWumpus(int rooms, Cave c1)
        {

            if (rooms == 0)
            {
                return;
            }
            else
            {
                int newPosition = c1.getNodeRoom(position).getRandomNeighbor().Value.ID();

                position = newPosition;

                moveWumpus(rooms - 1, c1);
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
        public void wumpusDefeat(Boolean defeat)
        {
            if (defeat == true)
            {
                Node<Room> current = new Node<Room>(new Room(position));
                //Pull room from the list m_roomList in Cave object with the index of 'position'

                

                //call cave to make it run 3 rooms away
                Random r = new Random();
                int number = r.Next(3) + 1;

                //moveWumpus(number, c1);
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
        public void playerEnters(int playerPosition, Boolean pit, Boolean bats) //situations awakening Wumpus; when player enters the same room
        {
            state = WumpusState.Asleep;
            if (playerPosition == position && pit == false && bats == false)
            {
                state = WumpusState.Awake;
                //go to trivia
                turnsSinceWumpus = 0;

            }
            else if (playerPosition == position && pit == true && bats == false)
            {
                state = WumpusState.Awake;
                //position moves - calls cave
                turnsSinceWumpus = 0;
            }
            else if (playerPosition == position && pit == false && bats == true)
            {
                state = WumpusState.Awake;
                //position moves - calls cave
                turnsSinceWumpus = 0;
            }
            else
            {
                turnsSinceWumpus++;
            }
            
        }
        public void shootsArrows(Boolean shootsArrow) //if player shoots arrow at Wumpus
        {
            if (state == WumpusState.Asleep && shootsArrow == true)
            {
                state = WumpusState.Awake;
                int runNumber = new Random().Next(1, 4); //makes it run up to 3 rooms
                turnsSinceWumpus = 0;
                if (runNumber == 1)
                {
                    //runs 1 room away-calls map to do?
                    int number = new Random().Next(1,31); // number of rooms
                    //if(boolean cave something == true){
                    //make it run 1 room away
                    //}
                    state = WumpusState.Moving;
                }
                else if (runNumber == 2)
                {
                    //runs 2 rooms away
                    state = WumpusState.Moving;
                }
                else if (runNumber == 3)
                {
                    //runs 3 rooms away
                    state = WumpusState.Moving;
                }

            }
            else
            {
                turnsSinceWumpus++;
            }
        }
    }
}