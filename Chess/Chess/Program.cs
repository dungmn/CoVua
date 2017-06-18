using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        public void change(ref int a, ref int b)
        {
            b = a;
            a = 0;
        }
        static void Main(string[] args)
        {

            int[,] S0 = new int[8, 8];
            int depth = 2;
            int anpha = -99999;
            int beta = 99999;
            int player = 1;
            int a;
            Status s = new Status();
            s.initS0(S0);
            node n = s.createNode(S0);
            minimax mini = new minimax();
            a = mini.AI(n, depth, anpha, beta, player);
        }

    }
}
