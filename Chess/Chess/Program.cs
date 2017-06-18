using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        //di chuyển quân cờ
        public void change(ref int a, ref int b)
        {
            b = a;
            a = 0;
        }

        //hàm main ^^
        static void Main(string[] args)
        {

            int[,] S0 = new int[8, 8];

            int depth = 2; //do từ trạng thái ban đầu ta tìm các tt con, sau đó ta mới dùng minimax để tìm các trạng thái tiếp theo
            int anpha = -99999;     // depth = 2 tức là từ các tt con của tt ban đầu ta tìm sâu xuống 2 lớp nữa
            int beta = 99999;       // còn độ sâu của bài toán sẽ là 3
            int player = 0; //player = 0 vì từ tt cha (MAX) ta tìm các tt con (MIN), sau đó ta áp dụng minimax để tìm giá trị cho từng con
                            // nên player = 0 <=> đang ở lớp MIN
            Status s = new Status();
            minimax mini = new minimax();
            node n = new node();

            s.initS0(S0); //khởi tạo giá trị 
            n = mini.findNextStatus(S0, depth, anpha, beta, player); //tìm trạng thái tiếp theo để đi tiếp
        }

    }
}
