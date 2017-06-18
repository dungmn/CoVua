using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chess
{
    struct node
    {
        public int[,] parentS;
        public int f;
        public ArrayList nextStatus;
    };

    class Status
    {
        public void initS0(int[,] s)
        {
            int[] arr = { 50, 30, 30, 90, 900, 30, 30, 50 };
            for (int i = 0; i < 8; i++)
            {
                s[7, i] = arr[i]*(-1);
                s[0, i] = arr[i];
                s[1, i] = 10;
                s[6, i] = -10;
            }
        }

        public void copy(ref int[,] d, int[,] s)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    d[i, j] = s[i, j];
                }
            }
        }

        public node createNode(int[,] s)
        {
            node n = new node();
            n.parentS = new int[8, 8];
            copy(ref n.parentS, s);
           
            n.f = -1 ;
            n.nextStatus = new ArrayList();
            return n;
        }

        public void output(int[,] s)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(s[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int getHeuristic(int[,] s)
        {
            int f = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    f += s[i, j];
                }
            }
            return f;
        }

        public void getNextStatusPC(ref ArrayList list, int[,] s)
        {
            Program p = new Program();
            node n;
            n = createNode(s);
            p.change(ref n.parentS[1, 3], ref n.parentS[2, 3]);
            list.Add(n);

            n = createNode(s);
            p.change(ref n.parentS[1, 7], ref n.parentS[3, 7]);
            list.Add(n);

            n = createNode(s);
            p.change(ref n.parentS[0, 1], ref n.parentS[2, 2]);
            list.Add(n);

        }

        public void getNextStatusPS(ref ArrayList list, int[,] s)
        {
            Program p = new Program();
            node n;
            n = createNode(s);
            p.change(ref n.parentS[6, 3], ref n.parentS[5, 3]);
            list.Add(n);

            n = createNode(s);
            p.change(ref n.parentS[6, 7], ref n.parentS[4, 7]);
            list.Add(n);

            n = createNode(s);
            p.change(ref n.parentS[7, 1], ref n.parentS[5, 2]);
            list.Add(n);

            n = createNode(s);
            p.change(ref n.parentS[7, 6], ref n.parentS[7, 7]);
            list.Add(n);
        }

        public void getRandomF(ref ArrayList list, int[,] s)
        {
            Program p = new Program();
            Random r = new Random();
            node n;
            n = createNode(s);
            n.f = r.Next(22, 44);
            p.change(ref n.parentS[6, 3], ref n.parentS[5, 3]);
            list.Add(n);

            n = createNode(s);
            n.f = r.Next(1,20);
            p.change(ref n.parentS[7, 1], ref n.parentS[5, 2]);
            list.Add(n);
        }
    }
}
