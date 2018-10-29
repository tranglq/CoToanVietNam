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
            int heuristicXanh = 0;
            int heuristicDo = 0;
            int countXanh = 0;
            int countDo = 0;

            // Dem so quan co moi doi trong ban co
            for(int i =0; i < 9; i++)
            {
                for (int j =0; j <11; j++)
                {
                    if (brd.getColor(i, j) == 1) countXanh++;
                    else if (brd.getColor(i, j) == 2) countDo++;
                    else continue;
                }
            }

          
            heuristicDo = 200 * countDo - 200 *countXanh;
            heuristicXanh = 200 * countXanh - 200 * countDo;

            if (color == 1) return heuristicDo;
            else return heuristicXanh;

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
