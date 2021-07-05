using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Npuzzle
{
    class priorityqueue
    {

        node[] Arr;
        int length = 0;

        public void enqueue(node x)
        {
            insert_value(x);
        }
        public node dequeue()
        {
            return extract_min();
        }

        public bool empty()
        {
            return (length == 0);
        }

        public priorityqueue()
        {
            Arr = new node[10000];
        }
        public int count() { return length; }

        void insert_value(node val)
        {
            length = length + 1;
            Arr[length] = null;  //assuming all the numbers greater than 0 are to be inserted in queue.
            increase_value(length, val);
        }

        public void increase_value(int i, node val)
        {
            Arr[i] = val;
            while (i > 1 && Arr[i / 2].F >= Arr[i].F)  
            {
                swap(ref Arr[i / 2], ref Arr[i]);
                i = i / 2;//1
            }
        }
        void min_heapify(int i, int N)
        {
            // to get index of left child of node at index i 
            int left = 2 * i;
            // to get index of right child of node at index i
            int right = 2 * i + 1; 
            int smallest;

            if (left <= N && Arr[left].F < Arr[i].F)
                smallest = left;
            else
                smallest = i;
            if (right <= N && Arr[right].F < Arr[smallest].F)//1
                smallest = right;
            if (smallest != i)//1
            {
                swap(ref Arr[i], ref Arr[smallest]);//1
                min_heapify(smallest, N);
            }
        }


        void build_minheap(int N)
        {
            for (int i = N / 2; i >= 1; i--)
                min_heapify(i, N);
        }
        void swap(ref node x, ref node y)//1
        {
            node t = x;
            x = y;
            y = t;
        }
        node extract_min()
        {
            if (length == 0)
            {
                throw new InvalidOperationException("Can’t remove element as queue is empty");
            }
            node min = Arr[1];
            Arr[1] = Arr[length];//1
            length = length - 1;//
            min_heapify(1, length);
            return min;
        }
    }
}

    

