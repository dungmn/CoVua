using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class minimax
    {
        public int AI(node n, int depth, int anpha, int beta, int player)
        {
            Status s = new Status();
            if (depth == 0)
                return n.f;
            if (player == 1)
            {
                s.getRandomF(ref n.nextStatus, n.parentS);
                foreach(node i in n.nextStatus)
                {
                    anpha = max(anpha, AI(i, depth - 1, anpha, beta, switchPlayer(player)));
                    if (anpha >= beta)
                        break;
                }
                return anpha;
            }
            else
            {
                s.getRandomF(ref n.nextStatus, n.parentS);
                foreach (node i in n.nextStatus)
                {
                    beta = min(beta, AI(i, depth - 1, anpha, beta, switchPlayer(player)));
                    if (anpha >= beta)
                        break;
                }
                return beta;
            }
        }

        public int max(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        public int min(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        public int switchPlayer(int player)
        {
            if (player == 1)
            {
                player = 0;
            }
            else
            {
                player = 1;
            }
            return player;
        }

    }
}
