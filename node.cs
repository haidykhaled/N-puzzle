using System;
using System.Collections.Generic;
using System.Text;

namespace Npuzzle
{
    class node
    {
        public int[,] borad;
        public List<node> adj;
        public int index0i;
        public int index0j;
        public node parent;

        public int Level;
        public int F;
        public int H;
        public int N;

        public node(int[,] tmp, int N, int ii, int jj, int H, int Level)
        {
            borad = tmp;
            parent = null;
            this.N = N;
            this.H = H;
            this.Level = Level;
            this.index0i = ii;
            this.index0j = jj;

            adj = new List<node>();
        }
        public node(int[,] tmp, int N, int ii, int jj, int H, int indexPi, int indexPj, int Level, node parent)
        {
            borad = tmp;
            this.parent = parent;
            this.N = N;
            this.index0i = ii;
            this.index0j = jj;
            this.Level = Level;
            this.H = H;
            adj = new List<node>();
        }
        int ham(node tmp, int n, int iOfLastCell, int jOfLastCell)
        {
            int h = tmp.H;
            if (((tmp.index0i * tmp.N + tmp.index0j) + 1) == n)
            {
                h--;
            }
            if (((iOfLastCell * tmp.N + jOfLastCell) + 1) == n)
            {
                h++;
            }
            return h;
        }
        void swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }
        public bool issame(node tmp, int i, int j)
        {

            if (tmp.parent != null && i == tmp.parent.index0i && j == tmp.parent.index0j)
            {
                return true;
            }
            return false;
        }
        public void getadj()
        {
            // node tt;
            node mynode = this;

            if (index0i > 0)
            {//swap
                int[,] temp = new int[N, N];
                Array.Copy(borad, temp, borad.Length);
                int nn = temp[index0i - 1, index0j];
                int hh = ham(mynode, nn, index0i - 1, index0j);

                swap(ref temp[index0i, index0j], ref temp[index0i - 1, index0j]);
                node t1 = new node(temp, N, index0i - 1, index0j, hh, index0i, index0j, mynode.Level + 1, mynode);
                if (!issame(mynode, index0i - 1, index0j))
                {
                    adj.Add(t1);
                }
            }

            if (index0i + 1 < N)
            {
                int[,] temp = new int[N, N];
                Array.Copy(borad, temp, borad.Length);
                int nn = temp[index0i + 1, index0j];
                int hh = ham(mynode, nn, index0i + 1, index0j);
                swap(ref temp[index0i + 1, index0j], ref temp[index0i, index0j]);

                node t2 = new node(temp, N, index0i + 1, index0j, hh, index0i, index0j, mynode.Level + 1, mynode);

                if (!issame(mynode, index0i + 1, index0j))
                {
                    adj.Add(t2);
                }

            }

            if (index0j > 0)
            {
                int[,] temp = new int[N, N];
                Array.Copy(borad, temp, borad.Length);
                int nn = temp[index0i, index0j - 1];
                int hh = ham(mynode, nn, index0i, index0j - 1);
                swap(ref temp[index0i, index0j], ref temp[index0i, index0j - 1]);

                node t3 = new node(temp, N, index0i, index0j - 1, hh, index0i, index0j, mynode.Level + 1, mynode);

                if (!issame(mynode, index0i, index0j - 1))
                {
                    adj.Add(t3);
                }
            }
            if (index0j + 1 < N)
            {
                int[,] temp = new int[N, N];
                Array.Copy(borad, temp, borad.Length);
                int nn = temp[index0i, index0j + 1];
                int hh = ham(mynode, nn, index0i, index0j + 1);
                swap(ref temp[index0i, index0j], ref temp[index0i, index0j + 1]);

                node t4 = new node(temp, N, index0i, index0j + 1, hh, index0i, index0j, mynode.Level + 1, mynode);
                if (!issame(mynode, index0i, index0j + 1))
                {
                    adj.Add(t4);
                }

            }
        }

    }


}
