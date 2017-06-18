using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class minimax
    {
        /*Từ trạng thái ban đầu (trạng thái mà đến lượt MAX đi) ta tìm các trạng thái tiếp theo 
          sau đó từ những trạng thái tiếp theo của MAX ta tính giá trị minimax cho chúng, và
          trả về trạng thái có giá trị  minimax lớn nhất chính là trạng thái mà MAX sẽ chọn để
          đi tiếp   */
        public node findNextStatus(int[,] s, int depth, int anpha, int beta, int player)
        {
            Status st = new Status();
            int value;
            int max = -9999;
            node n = st.createNode(s);
            node next = new node();
            
            st.getNextStatusPC(ref n.nextStatus, n.parentS); //Tìm trạng thái tiếp theo cho MAX

            //Duyệt tất cả trạng thái tiếp theo chọn ra trạng thái có giá trị minimax lớn nhất để đi tiếp
            foreach (node i in n.nextStatus)
            {
                value = AI(i, depth, anpha, beta, player); //tính minimax cho trạng thái con
                if (max < value)
                {
                    max = value;
                    next = i;
                }

            }
            return next; //trả về trạng thái mà MAX sẽ chọn để đi tiếp
        }


        //tính minimax ps: giá trị mọi thứ đang là random chờ code của Danh để bổ sung :))
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

        //tìm max giữa 2 số a, b
        public int max(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        //tìm min giữa 2 số a, b
        public int min(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        //đổi người chơi
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
