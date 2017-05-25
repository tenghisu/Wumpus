﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusProject
{
    public class Node<T>
    {
        //Private member-variables
        private Room m_data;
        protected NodeList<T> m_neighbors = null;


        public Node() { }

        public Node(Room data)
        {
            m_data = data;
            m_neighbors = new NodeList<T>();
        }

        public NodeList<T> getNeighbors()
        {
            return m_neighbors;
        }

        public Node<T> getRandomNeighbor()
        {
            Random r = new Random();

            int index = r.Next(m_neighbors.Count);

            return m_neighbors[index];
        }

        public Room Value
        {
            get
            {
                return m_data;
            }
            set
            {
                m_data = value;
            }
        }

        protected NodeList<T> neighbors
        {
            get
            {
                return m_neighbors;
            }
        }

        public void connect(Node<T> target)
        {
            if (m_neighbors.Contains(target) == false)
                m_neighbors.Add(target);
        }

        public void disconnect(Node<T> target)
        {
            if (m_neighbors.Contains(target))
                m_neighbors.Remove(target);
        }

        public int neighborCount
        {
            get
            {
                return m_neighbors.Count();
            }
        }

        public List<int> neighborList()
        {
            List<int> i = new List<int>();

            foreach(Node<T> node in m_neighbors)
            {
                i.Add(node.Value.ID());
            }

            return i;
        }


        public Boolean isConnected(Node<T> target)
        {
            return m_neighbors.Contains(target);
        }

        public String printMyID()
        {
            return m_data.ToString();
        }

        public String printStructure()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("My ID " + m_data.ToString());
            sb.Append("Connection: ");

            foreach (Node<T> n in m_neighbors)
            {
                sb.Append(n.printMyID());
                sb.Append(" ");
            }

            return sb.ToString();

        }
    }
}

