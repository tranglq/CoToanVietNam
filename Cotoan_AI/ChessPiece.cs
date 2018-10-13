using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MChess
{
    public class state
    {
        public class chess
        {
            public sbyte  x;
            public sbyte  y;
            public sbyte  value;
            public chess()
            {
                x = y = value = -1;
            }
        }
        public  chess[] QuanXanh = new chess[10];
        public  chess[] QuanDo = new chess [10];
        public  int[, ,] fire = new int[10, 10, 5];
        public state ()
        {

            for (int j = 1; j <= 9; j++)
                for (int  k = 0; k <= 9; k++)
                {
                    if (j == k) continue;
                    fire [j,k,0] = (j + k) % 10; // cong
                    fire[j,k,2] = (j * k) % 10; // nhan
                    if (j > k)
                    {
                        fire[j,k,1] = (j - k) % 10; // tru
                        if (k != 0) fire[j, k, 3] = j / k;     // thuong
                        else fire[j, k, 3] = 0;
                        if (k != 0) fire[j, k, 4] = j % k;     // du
                        else fire[j, k, 4] = j;
                    
                    }
                    else fire[j,k,1] = fire[j,k,3] = fire[j,k,4] = -1;
                }
            for (int i = 0; i < 10; i++)
            {
                QuanDo[i] = new chess();
                QuanXanh[i] = new chess();
                QuanDo[i].value = QuanDo[i].x = QuanDo[i].y = -1;
                QuanXanh[i].value = QuanXanh[i].x = QuanXanh[i].y = -1;
            }
        }
        public void set(ref chess c, int x, int y, int value )
        {
            c.x = (sbyte)x;
            c.y = (sbyte)y;
            c.value = (sbyte)value;
        }
        public void set(ref chess c, int x, int y)
        {
            c.x = (sbyte)x;
            c.y = (sbyte)y;
        }
        public void set(ref chess c, int value)
        {
            c.value = (sbyte)value;
        }
        public bool math(chess a, int value, int x, int y)
        {
            int t = 12;
            if (a.x == x) t = (a.y > y) ? (a.y - y) : (y - a.y);              //Cung hang
            if (a.y == y) t = (a.x > x) ? (a.x - x) : (x - a.x);            //Cung cot
            if ((a.x - a.y) == (x - y)) t = (a.x > x) ? (a.x - x) : (x - a.x); //Cung duong cheo chinh
            if ((a.x + a.y) == (x + y)) t = (a.x > x) ? (a.x - x) : (x - a.x); //Cung duong cheo phu
            if (t == 12) return false;
            for (int i = 0; i <= 4; i++)
                if (fire[a.value,value,i] == t-1) return true;
            return false;
        }

    }
}

