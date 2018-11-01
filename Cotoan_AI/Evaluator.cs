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


            // CÀI ĐẶT HEURISTIC TRẠNG THÁI
            int trangthaiXanh = 0;
            int trangthaiDo = 0;
            int countXanh = 0;
            int countDo = 0;

            // Dem so quan co moi doi trong ban co
            // Tinh diem heuristic dua tren do manh yeu, tam quan trong cua tung quan co
            // Quan 0 co tam quan trong cao nhat
            // Cac quan con lai co do manh giam dan sang 2 ben
            int domanhXanh = 0;
            int domanhDo = 0;
            for(int i =0; i < 9; i++)
            {
                for (int j =0; j <11; j++)
                {
                    if (brd.getColor(i, j) == 1)
                    {
                        // neu la quan 0 thi diem = 100
                        // neu la quan tu 5 tro len diem = 10 x (10 - gia tri quan co)
                        // neu la quan nho hon 5 diem = 5 x gia tri quan co
                        if (brd.getInfo(i, j) == 0) domanhXanh += 100;
                        else if (brd.getInfo(i, j) >= 5) domanhXanh += 10 * (10 - brd.getInfo(i, j));
                        else domanhXanh += 5 * brd.getInfo(i, j);
                        countXanh++;
                    }
                    else if (brd.getColor(i, j) == 2)
                    {
                        // tuong tu cach tinh voi quan xanh
                        if (brd.getInfo(i, j) == 0) domanhDo += 100;
                        else if (brd.getInfo(i, j) >= 5) domanhDo += 10 * (10 - brd.getInfo(i, j));
                        else domanhDo += 5 * brd.getInfo(i, j);
                        countDo++;
                    }
                    else continue;
                }
            }
            int domanh = domanhDo - domanhXanh;

            //Tính điểm heuristic trạng thái dựa trên điểm đã đạt được của mỗi đội
            int diem = 5 * brd.diem(1) - 5 * brd.diem(2);

            //Tính điểm heuristic trạng thái dựa trên khả năng chiếu
            int diemChieuXanh = 0;
            int diemChieuDo = 0;
            if (brd.isChecked(1)) diemChieuDo = 200;
            if (brd.isChecked(2)) diemChieuXanh = 200;
            int diemChieu = diemChieuDo - diemChieuXanh;

            //Tính điểm heuristic trạng thái dựa trên khả năng phòng ngự và hết cờ
            int defendXanh = 0;
            int defendDo = 0;
            if (brd.canDefend(1))
            {
                defendXanh = 10;
            }
            else defendXanh = -1000;

            if (brd.canDefend(2)){
                defendDo = 10;
            }
            else
            {
                defendDo = -1000;
            }

            int defend = defendDo - diemChieuXanh;

            heuristicDo = domanh + 5 *diem + diemChieu + defend;
            heuristicXanh = - heuristicDo;

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
