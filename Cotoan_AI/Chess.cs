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
            public sbyte x;
            public sbyte y;
            public sbyte value;
            public chess()
            {
                x = y = value = -1;
            }
        }
        public chess[] QuanXanh = new chess[10];
        public chess[] QuanDo = new chess[10];
        public sbyte [, ,] fire = new sbyte [10, 10, 5];
        public state()
        {

            for (sbyte  j = 1; j <= 9; j++)
                for (sbyte  k = 0; k <= 9; k++)
                {
                    if (j == k) continue;
                    fire[j, k, 0] = (sbyte)((j + k) % 10); // cong
                    fire[j, k, 2] = (sbyte)((j * k) % 10); // nhan
                    if (j > k)
                    {
                        fire[j, k, 1] = (sbyte)(j - k); // tru
                        if (k != 0) fire[j, k, 3] = (sbyte)( j / k);     // thuong
                        else fire[j, k, 3] = 0;
                        if (k != 0) fire[j, k, 4] = (sbyte)( j % k);     // du
                        else fire[j, k, 4] = 0;

                    }
                    else fire[j, k, 1] = fire[j, k, 3] = fire[j, k, 4] = 0;
                }
            for (int i = 0; i < 10; i++)
            {
                QuanDo[i] = new chess();
                QuanXanh[i] = new chess();
                QuanDo[i].value = QuanDo[i].x = QuanDo[i].y = -1;
                QuanXanh[i].value = QuanXanh[i].x = QuanXanh[i].y = -1;
            }
        }
        public void set(ref chess c, int x, int y, int value)
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
        public bool math(chess a, sbyte  value, sbyte  x, sbyte y)
        {
            value = (sbyte)(value % 10);
            int t = 12;
            if (a.x == x) t = (a.y > y) ? (a.y - y) : (y - a.y);              //Cung hang
            if (a.y == y) t = (a.x > x) ? (a.x - x) : (x - a.x);            //Cung cot
            if ((a.x - a.y) == (x - y)) t = (a.x > x) ? (a.x - x) : (x - a.x); //Cung duong cheo chinh
            if ((a.x + a.y) == (x + y)) t = (a.x > x) ? (a.x - x) : (x - a.x); //Cung duong cheo phu
            if (t == 12) return false;
            for (int i = 0; i <= 4; i++)
                if (fire[a.value, value, i] == t - 1) return true;
            return false;
        }
        public bool math2(int x, int y, int z)
        {
            sbyte t = (sbyte)z;
            int a = x % 10;
            int b = y % 10;
            for (int i = 0; i <= 4; i++)
                if (fire[a, b, i] == z - 1) return true;
            return false;
        }
        public bool teammate(Board b,chess c, int x2, int y2)
        {
            if (b.getInfo(x2, y2) == -1) return false;
            if (((b.getInfo(c.x,c.y) < 10) && (b.getInfo(x2, y2) < 10)) || ((b.getInfo(c.x,c.y)>9) && (b.getInfo(x2, y2) > 9)))
                return true;
            return false;
        }
        public bool move(Board b,chess c, int x, int y)
        {
            sbyte x2, y2;
            x2 = (sbyte)x;
            y2 = (sbyte)y;
            Point X = new Point(c.x, c.y);
            if (X.distance(x2, y2) <= 0)
                return false;

            if (X.distance(x2, y2) > c.value)
                return false;

            //neu o x2, y2 khong trong
            if (b.getInfo(x2, y2) != -1)
                return false;

            //cung hang, cung cot hoac cung duong cheo va trong tam kiem soat

            //cung cot
            if (c.x == x2)//sua
            {
                if (c.y < y2)
                {
                    for (sbyte  i = 1; i <= (y2 - c.y); i++)
                        if (b.getInfo(c.x, c.y + i) > -1)
                            return false;
                }
                else
                {
                    for (sbyte  i = 1; i <= (c.y - y2); i++)
                        if (b.getInfo(c.x, c.y - i) > -1)
                            return false;
                }
            }
            //cung hang
            if (c.y == y2)//sua
            {
                if (c.x < x2)
                {
                    for (sbyte  i = 1; i <= (x2 - c.x); i++)
                        if (b.getInfo(c.x + i, c.y) > -1)
                            return false;
                }
                else
                {
                    for (sbyte  i = 1; i <= (c.x - x2); i++)
                        if (b.getInfo(c.x - i, c.y) > -1)
                            return false;
                }
            }

            //cung duong cheo
            if ((c.x + c.y) == (x2 + y2))
            {
                if (c.x < x2)
                {
                    for (sbyte  i = 1; i <= (x2 - c.x); i++)
                        if (b.getInfo(c.x + i, c.y - i) > -1)
                            return false;
                }
                else
                {
                    for (sbyte i = 1; i <= (c.x - x2); i++)
                        if (b.getInfo(c.x - i, c.y + i) > -1)
                            return false;
                }
            }
            if ((x2 - y2) == (c.x - c.y))
            {
                if (c.x < x2)
                {
                    for (sbyte  i = 1; i <= (x2 - c.x); i++)
                        if (b.getInfo(c.x + i, c.y + i) > -1)
                            return false;
                }
                else
                {
                    for (sbyte  i = 1; i <= (c.x - x2); i++)
                        if (b.getInfo(c.x - i, c.y - i) > -1)
                            return false;
                }
            }
            return true;

        }
        public bool capture(Board b,chess c ,int x1, int y1)
        {
            sbyte x2 ,y2;
            x2 = (sbyte)x1;
            y2 = (sbyte)y1;
            //kiem tra xem co quan co nao o vi tri x2, y2 khong
            //neu o o x2,y2 trong
            if ((b.getInfo(x2, y2) == -1))
                return false;

            //neu o o x2,y2 la quan co cung mau
            if (((b.getInfo(c.x,c.y) <10) && (b.getInfo(x2, y2) < 10)) || ((b.getInfo(c.x,c.y)>9) && (b.getInfo(x2, y2) > 9)))
                return false;

            //neu o o x2,y2 la quan co doi phuong
            //khi nao an duoc?

            //neu khong cung hang hoac cung cot hoac cung duong cheo
            if ((c.x != x2) && (c.y != y2) && ((c.x + c.y) != (x2 + y2)) && ((c.x - c.y) != (x2 - y2)))
                return false;

            //cung hang
            if (c.y == y2)
            {
                if (c.x < x2)
                {
                    //kiem tra vi tri (x+1, y) co quan minh khong?
                    if (!this.teammate(b, c ,c.x + 1, c.y))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    for (int j = c.x + 2; j < x2; j++)
                    {
                        if (b.getInfo(j, c.y) != -1)
                            return false;
                    }

                    if (math(c, b.getInfo(c.x+1,c.y), x2,y2))
                    {
                        //op = pheptoan;
                        return true;
                    }

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y) co quan minh khong
                    if (!this.teammate(b,c, c.x - 1, c.y))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    for (int j = c.x - 2; j > x2; j--)
                        if (b.getInfo(j, c.y) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c, b.getInfo(c.x-1,c.y), x2 ,y2))
                        return true;
                }
            }
            //cung cot
            if (c.x == x2)
            {
                if (c.y < y2)
                {
                    //kiem tra vi tri (x, y+1) co quan minh khong?
                    if (!this.teammate(b,c, c.x, c.y + 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    for (int j = c.y + 2; j < y2; j++)
                    {
                        if (b.getInfo(c.x, j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c,b.getInfo(c.x,c.y+1), x2,y2))
                        return true;

                }
                //y>y2
                else
                {
                    //kiem tra vi tri (x,y-1) co quan minh khong
                    if (!this.teammate(b,c, c.x, c.y - 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    for (int j = c.y - 2; j > y2; j--)
                        if (b.getInfo(c.x, j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c,b.getInfo(c.x,c.y-1), x2,y2))
                        return true;
                }
            }
            //cung duong cheo chinh
            if (c.x - c.y == x2 - y2)
            {
                if (c.x < x2)
                {
                    //kiem tra vi tri (x+1, y+1) co quan minh khong?
                    if (!this.teammate(b,c, c.x + 1, c.y + 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    for (int j = 2; j < x2 - c.x; j++)
                    {
                        if (b.getInfo(c.x + j, c.y + j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c, b.getInfo(c.x+1,c.y+1), x2 ,y2))
                        return true;

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y-1) co quan minh khong
                    if (!this.teammate(b,c, c.x - 1, c.y - 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    for (int j = c.x - x2 - 1; j >= 2; j--)
                        if (b.getInfo(c.x - j, c.y - j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c, b.getInfo(c.x - 1, c.y - 1), x2, y2))
                        return true;
                }
            }
            //cung duong cheo phu
            if (c.x + c.y == x2 + y2)
            {
                if (c.x < x2)
                {
                    //kiem tra vi tri (x+1, y-1) co quan minh khong?
                    if (!this.teammate(b,c, c.x + 1, c.y - 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    for (int j = 2; j < x2 - c.x; j++)
                    {
                        if (b.getInfo(c.x + j, c.y - j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c, b.getInfo(c.x + 1, c.y - 1), x2, y2))
                        return true;

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y+1) co quan minh khong
                    if (!this.teammate(b,c, c.x - 1, c.y + 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    for (int j = c.x - x2 - 1; j >= 2; j--)
                        if (b.getInfo(c.x - j, c.y + j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (math(c, b.getInfo(c.x - 1, c.y + 1), x2, y2))
                        return true;
                }
            }
            return false;

        }
        

    }
}

