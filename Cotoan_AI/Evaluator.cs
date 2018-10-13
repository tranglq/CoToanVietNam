using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MChess
{
   class Evaluator
    {
        public Evaluator() { }
        public int BoardControl2(Board brd, state st,int color )
        {
            return 0;

        }
        public int Attack2(Board brd, state st, int color)
        {
            int diemxanh=0;
            int diemdo=0;
            //Tinh diem do 
            diemdo = 1;
            //Tinh diem xanh 
            diemxanh = 1;
            if (color == 1)
                return (diemxanh - diemdo);
            else
                return (diemdo - diemxanh);
        }
    }
}
