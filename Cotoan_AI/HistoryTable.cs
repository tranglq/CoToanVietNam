using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
namespace MChess
{
    public class HistoryTable
    {
        int[][ , , ,] History;
        static int[, , ,] CurrentHistory;

        private static HistoryTable Instance;
        
        private MoveComparator Comparator1 ;
        private MoveComparator2  Comparator2;


        //Luu y: Lop History Table cai dat theo mau Singleton - chi co duy nhat mot the hien
        //va lay the hien do thong qua phuong thuc getInstance()
        //private constructor
        private HistoryTable()
        {
            History = new int[3][, , ,];
            History[1] = new int[9, 11, 9, 11];
            History[2] = new int[9, 11, 9, 11];
            Comparator1 = new MoveComparator();
            Comparator2 = new MoveComparator2();
        
        }

        static HistoryTable()
        {
            Instance = new HistoryTable();
        }

        //tra lai the hien (reference)
        public static HistoryTable GetInstance()
        {
            return Instance;
        }

        //lop nested thi hanh giao dien IComparer, dung de so sanh 2 nuoc di
        public class MoveComparator : IComparer
        {
            public int Compare(object o1, object o2)
            {
                Move move1 = (Move)o1;
                Move move2 = (Move)o2;
                if (CurrentHistory[move1.x1, move1.y1, move1.x2, move1.y2] >
                    CurrentHistory[move2.x1, move2.y1, move2.x2, move2.y2])
                   // if (move1.value > move2.value)
                        return -1;
                   // else return 0;
                else
                    return 0;
            }
        }
        public class MoveComparator2 : IComparer
        {
            public int Compare(object o1, object o2)
            {
                Move move1 = (Move)o1;
                Move move2 = (Move)o2;
                if (move1.value <= move2.value )

                    return 0;
                else
                    return -1;
            }
        }
        //Sap xep danh sach nuoc di cua nguoi choi color
        public bool SortMoveList(int color, Move[] moveList, int moveListSize)
        {
            //int ass=0 ;
            //int test = 0;
            CurrentHistory = History[color];
            Array.Sort(moveList, 1, moveListSize, Comparator1);
            /*foreach (Move f in moveList)
            {
                if (!(f == null))
                if (History[color][f.x1, f.y1, f.x
                2, f.y2]> 0) ass++;
                if (ass > 5) test = 1;
            }*/
            return true;
        }
        public bool SortMoveList2(int color, Move[] moveList, int moveListSize)
        {
            //int ass=0 ;
            //int test = 0;
            CurrentHistory = History[color];
            Array.Sort(moveList, 1, moveListSize, Comparator2);
            /*foreach (Move f in moveList)
            {
                if (!(f == null))
                if (History[color][f.x1, f.y1, f.x2, f.y2]> 0) ass++;
                if (ass > 5) test = 1;
            }*/
            return true;
        }
        //tang diem cho mot nuoc di
        public bool AddCount(int color, Move move)
        {
            History[color][move.x1, move.y1, move.x2, move.y2]++;
            /*int ass=0 ;
            int test = 0;
            foreach (int ta in History[color])
            {
                if (ta > 0)
                    ass = ass + 1;
                if (ass > 5) test = 1;
            }*/
            return true;
        }

        //xoa bang, khong dung nhung thong tin cu nua
        public bool Forget()
        {
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 9; j++)
                    for (int k = 0; k < 11; k++)
                        for (int l = 0; l < 9; l++)
                            for (int m = 0; m < 11; m++)
                                History[i][j, k, l, m] = 0;
            return true;
        }
    }
}
