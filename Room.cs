﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{

    

    public class Room
    {
        private int m_ID;
        public Boolean hasWumpus = false;
        //private Wumpus m_wumpus = new Wumpus(); 


        public Room(int id)
        {
            m_ID = id;
        }

        public int ID()
        {
            //get
            //{
                return m_ID;
            //}
        }

        public override string ToString()
        {
            return "ID:" + ID().ToString();
        }
    }
}

