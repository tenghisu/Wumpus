﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.IO;

namespace WumpusProject
{
    class Cave
    {
        const int MAX_CONNECTIONS = 6;
        const int ROOM_COUNT = 30;
        public List<Node<Room>> m_roomList = new List<Node<Room>>();
        private static readonly object syncLock = new object();

        public void initialize()
        {
            m_roomList.Clear();
            for (int i = 0; i < ROOM_COUNT; i++)
            {
                m_roomList.Add(new Node<Room>(new Room(i)));
            }
            
            
        }

        /*
        public void createEasy()
        {
            String JsonString = File.ReadAllText("EasyCaveConfig.json");
            CaveConfig c = JsonConvert.DeserializeObject<CaveConfig>(JsonString);

            for (int i = 0; i < ROOM_COUNT; i++)
            {
                for (int j = 0; j < c.RoomList.ElementAt(i).ConnectedTo.Length; j++)
                {
                    connect(m_roomList.ElementAt(i), m_roomList.ElementAt(c.RoomList.ElementAt(i).ConnectedTo.ElementAt(j)));
                }

            }

        }

        public void createMedium()
        {
            String JsonString = File.ReadAllText("MediumCaveConfig.json");
            CaveConfig c = JsonConvert.DeserializeObject<CaveConfig>(JsonString);

            for (int i = 0; i < ROOM_COUNT; i++)
            {
                for (int j = 0; j < c.RoomList.ElementAt(i).ConnectedTo.Length; j++)
                {
                    connect(m_roomList.ElementAt(i), m_roomList.ElementAt(c.RoomList.ElementAt(i).ConnectedTo.ElementAt(j)));
                }

            }

        }

        public void createHard()
        {
            String JsonString = File.ReadAllText("HardCaveConfig.json");
            CaveConfig c = JsonConvert.DeserializeObject<CaveConfig>(JsonString);

            for(int i = 0; i < ROOM_COUNT; i++)
            {
                for (int j = 0; j < c.RoomList.ElementAt(i).ConnectedTo.Length; j++)
                {
                    connect(m_roomList.ElementAt(i), m_roomList.ElementAt(c.RoomList.ElementAt(i).ConnectedTo.ElementAt(j)));
                }
                    
            }
            
        }
         * */

        public Node<Room> getNodeRoom(int ID)
        {
            if(ID >= 0 && ID < ROOM_COUNT)
                return m_roomList[ID];

            return null;
        }

        public string structure()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Node<Room> r in m_roomList)
            {
                sb.AppendLine(r.printStructure());
            }

            return sb.ToString();
        }

        void connect(Node<Room> room_a, Node<Room> room_b)
        {

            room_a.connect(room_b);
            room_b.connect(room_a);
        }

        private List<Node<Room>> getCandidates(Node<Room> from_node)
        {
            List<Node<Room>> ret = new List<Node<Room>>();
            foreach (Node<Room> r in m_roomList)
            {
                if (r == from_node)
                {
                    continue;
                }
                else if (r.neighborCount == MAX_CONNECTIONS)
                {
                    continue;
                }
                else if (r.isConnected(from_node))
                {
                    continue;
                }

                ret.Add(r);
            }

            return ret;
        }

        public void createMaze()
        {
            for (int i = 0; i < ROOM_COUNT; i++)
            {
                Node<Room> current = m_roomList[i];

                if (current.neighborCount == MAX_CONNECTIONS)
                    continue;

                var CandidateList = getCandidates(current);

                while (current.neighborCount < 6 && CandidateList.Count > 0)
                {
                    int j = GetRandomNumber(0, CandidateList.Count);
                    connect(current, CandidateList[j]);
                    CandidateList.RemoveAt(j);
                }

            }
        }

        public static int GetRandomNumber(int min, int max)
        {
            Random getrandom = new Random();

            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

    }
}


