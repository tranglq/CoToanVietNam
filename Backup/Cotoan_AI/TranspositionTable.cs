using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MChess
{
    class TranspositionEntry
    {
        public int type;           //kieu, chinh xac(nut la) hay chi la uoc luong (nut trong)
        public int eval;           //gia tri luong gia duoc luu lai
        public int depth;          //do sau, tai nut goc la do sau 0

        public int theLock;        //khoa cua entry, tinh dua tren HashLock()
        public int time;           //thoi gian entry nay da "song" trong bang

        public static int NULL_ENTRY = -1;

        public TranspositionEntry()
        {
            type = NULL_ENTRY;
        }
    }

    public class TranspositionTable
    {
        //kich thuoc bang
        private static int SIZE = 1048576;

        //mang chua du lieu
        private TranspositionEntry[] Table;

        public TranspositionTable()
        {
            Table = new TranspositionEntry[SIZE];
            for (int i = 0; i < SIZE; i++)
                Table[i] = new TranspositionEntry();
        }

        
        //tim mot trang thai (the co) trong Transposition Table bang cach dung Key tinh tu ham bam
        public bool LookUp(Board brd, out int eval, out int depth, out int type)
        {
            ///*
            //tinh khoa hash cho brd
            int key = Math.Abs(brd.HashKey() % SIZE);
            TranspositionEntry entry = Table[key];

            //kiem tra xem entry nay co rong hay khong
            if (entry.type == -1)
            {
                eval = 0;
                depth = 0;
                type = -1;
                return false;
            }


            //kiem tra luot 2 - tranh dung do
            if (entry.theLock != brd.HashLock())
            {
                eval = 0;
                depth = 0;
                type = -1;
                return false;
            }

            //da tim dung entry tuong ung, copy du lieu tuong ung
            eval = entry.eval;
            depth = entry.depth;
            type = entry.type;
            return true;
            //*/
            
        }
        
        
        //luu mot trang thai vao Transposition Table
        public bool Store(Board brd, int eval, int type, int depth, int time)
        {
            int key = Math.Abs(brd.HashKey() % SIZE);

            //neu o vi tri key da co mot Board khac chat luong hon
            if ((Table[key].type != TranspositionEntry.NULL_ENTRY) &&
                (Table[key].depth > depth) &&
                (Table[key].time >= time))
                return true;

            //luu ban co
            Table[key].theLock = brd.HashLock();
            Table[key].type = type;
            Table[key].eval = eval;
            Table[key].depth = depth;
            Table[key].time = time;
            return true;
        }

    }
}
