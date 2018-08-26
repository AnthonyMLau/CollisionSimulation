using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionSimulation
{
    public class PriorityQueue //heap starts @ index of 1
    {
        private Event[] pq = null;
        private int numItems = 0;

        public PriorityQueue(Event[] pq)//creates pq from given array
        {
            numItems = pq.Length;
            this.pq = new Event[pq.Length + 1];

            for (int i = 0; i < numItems; i++)
            {
                this.pq[i + 1] = pq[i];//shifts over array indicies 1 higher; pq starts @ index 1
            }

            for (int i = numItems / 2; i >= 1; i--)//creates heap bottom up
            {
                sink(i);
            }
        }
        public PriorityQueue(int pqSize)//creates empty pq with given initial capacity
        {
            this.pq = new Event[pqSize];
        }
        public PriorityQueue()//creates empty pq of size 100
        {
            this.pq = new Event[100]; 
        }

        public Event PQMin()
        {
            if (numItems == 0)
            {
                throw new IndexOutOfRangeException("Priority queue is empty");
            }
            else
            {
                return pq[1];
            }
        }

        private void resize(int capacity)//resizes array  
        {
            if (capacity > numItems)
            {
                Event[] temp = new Event[capacity];
                for (int i = 0; i <= numItems; i++)
                {
                    temp[i] = pq[i];
                }
                pq = temp;
            }
            else
            {
                throw new Exception("Capacity argument < current number of items; cannot resize");
            }
        }

        public void insertEvent(Event e)
        {
            if (numItems == pq.Length - 1)
            {
                resize((pq.Length) * 2);
            }
            numItems++;
            pq[numItems] = e;    //increments then does operation
            swim(numItems);

        }

        public Event delMin()
        {
            if (numItems == 0)
            {
                throw new IndexOutOfRangeException("Priority queue is empty");
            }
            else
            {
                Event min = pq[1];
                swap(1, numItems--);    //does operation, then decrements
                sink(1);
                pq[numItems + 1] = null;  //derefrences min 

                if (numItems > 0 && (pq.Length - 1) / 4 == numItems)
                {
                    resize(numItems * 2);   //halves array if numItems is 1/4 of array size
                }

                return min;
            }
        }

        private void swim(int index)    //pq value moving up pq
        {

            while (index > 1 && (pq[index].time) < (pq[(index / 2)].time))
            {
                swap(index, index / 2);
                index = index / 2;
            }
        }

        private void sink(int index)    //pq value moving down pq
        {
            while (index * 2 <= numItems)
            {
                int childIndex = index * 2;
                if (childIndex < numItems && pq[childIndex].time > pq[childIndex + 1].time)   //finds which is the smaller child node
                {
                    childIndex++;
                }
                if (pq[index].time < pq[childIndex].time)
                {
                    break;
                }
                swap(index, childIndex);
                index = childIndex;
            }
        }

        public void swap(int a, int b)
        {
            Event temp = pq[a];
            pq[a] = pq[b];
            pq[b] = temp;
        }

        public int getNumItems()
        {
            return numItems;
        }

        public int getArraySize()
        {
            return pq.Length;
        }

        public Event[] getPQCopy()
        {
            Event[] temp = pq;
            return temp;
        }

    }
}
