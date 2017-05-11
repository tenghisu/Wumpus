using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    class Wumpus
    {
        private String state;
        private int position;

        public Wumpus()
        {
            //constructor
            state = "awake";
            //randomly generate position
            position = new Random().Next(1, 31);

        }
        public Wumpus(String state, int position)
        {
            this.state = state;
            this.position = position;
        }
        public void setWumpusState(int playerPosition, int turns)
        {
            //set state of wumpus
            if (turns >= 2)
            {
                state = "asleep";
            } else if(turns < 2){
                int state = new Random().Next(1, 4);
                if (state == 1)
                {
                    this.state = "awake";
                }
                else if (state == 2)
                {
                    this.state = "asleep";
                }
                else if (state == 3)
                {
                    this.state = "moving";
                    wumpusMoving(playerPosition);
                }
            }

        }
        public void wumpusMoving(int playerPosition)
        {
            //get wumpus position and caves around it
            //random generate which ones is around
            
        }
        public String wumpusAsleep()
        {
            state = "asleep";
            return state;
        }
        public void wumpusDefeat()
        {
            //gets new position of wumpus
            //runs 3 rooms away 
        }
        public void setWumpusPosition()
        {
            //finds wumpus position
            

        }
        public String getWumpusState()
        {
            return state;
        }
        public String getWumpusMoving(int playerPosition)
        {
            return "Wumpus is moving";
        }
        public int getWumpusPosition()
        {
            //needs maps help i think
            return 0;
        }
        public void wumpusWakesUp(int playerPosition, Boolean shootsArrow)
        {
            if (state == "asleep" || shootsArrow == true)
            {
                state = "awake";
            }
            //set new position of Wumpus
            //map.wumpusLocation(state);
            position = new Random().Next(1, 31);
        }
    }
}
