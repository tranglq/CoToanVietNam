using System;
using System.Collections;
namespace MChess
{
    /// <summary>
    /// Summary description for Stone.
    /// </summary>

    #region IPiece interface
    public interface IPiece
    {
        bool move(Board b, int x2, int y2);
        bool capture(Board b, int x2, int y2);
    }
    #endregion

    #region Piece class
    public class Piece : System.Object  // quan co
    {
        public Piece()
        {
            color = 1;
            x = 1;
            y = 1;
            value = -1;
        }
        public int color;           //1 quan xanh, 2 quan do
        //public bool live;           // quan co song hay chet
        public int value;           //gia tri quan co, 0-9
        public int x;               //0-8
        public int y;               //0-10
    }
    #endregion
    public class quan0 : Piece, IPiece
    {
        public quan0(int color)
        {
            this.color = color;
            value = 0;
        }
        public bool move(Board b, int x2, int y2)
        {
            return false;
        }
        public bool capture(Board b, int x2, int y2)
        {
            //op = null;
            return false;
        }
        public bool isChecked(Board b, out int x1, out int y1)
        {
            //cai dat kiem tra quan 0 co dang bi chieu hay khong
            //kiem tra cac quan doi phuong co the an duoc hay khong
            //quan 0 xanh o toa do (4,1) tren Board b
            if (color == 1)
            {
                //kiem tra cot 4, x=4, y=0->10, y!=1, y!=2, y!=0
                for(int i=3; i<11; i++)
                {
                    if (b.getInfo(4, i) > 9 && b.getInfo(4, i) != 10)
                    {
                        quan19 quan_doi_phuong = new quan19(2, b.getInfo(4, i) % 10, 4, i);
                        if (quan_doi_phuong.capture(b, 4, 1))
                        {
                            x1 = 4;
                            y1 = i;
                            return true;
                        }
                    }
                }
                //kiem tra hang 1, y=1, x=0->8, x!=4, x!=3, x!=5
                for (int i = 0; i < 9; i++)
                {
                    
                    if (i!=3 && i!=4 && i!=5 && b.getInfo(i, 1) > 9)
                    {
                        quan19 quan_doi_phuong = new quan19(2, b.getInfo(i, 1) % 10, i, 1);
                        if (quan_doi_phuong.capture(b, 4, 1))
                        {
                            x1 = i;
                            y1 = 1;
                            return true;
                        }
                    }
                }
                //kiem tra duong cheo chinh va phu, tu o (6,3) den o (8,5), tu o (2,3) den o (0,5)
                for (int i = 3; i <= 5; i++)
                {
                    if (b.getInfo(3 + i, i) > 9)
                    {
                        quan19 quan_doi_phuong = new quan19(2, b.getInfo(3 + i, i) % 10, 3 + i, i);
                        if (quan_doi_phuong.capture(b, 4, 1))
                        {
                            x1 = 3 + i;
                            y1 = i;
                            return true;
                        }
                    }
                    if (b.getInfo(5 - i, i) > 9)
                    {
                        quan19 quan_doi_phuong = new quan19(2, b.getInfo(5 - i, i) % 10, 5 - i, i);
                        if (quan_doi_phuong.capture(b, 4, 1))
                        {
                            x1 = 5 - i;
                            y1 = i;
                            return true;
                        }
                    }
                }
            }

            //quan 0 do o vi tri (4,9)
            if (color == 2)
            {
                //kiem tra cot 4, x=4, y=0->10, y!=8, y!=9, y!=10
                for (int i = 0; i <=7; i++)
                {
                    if (b.getInfo(4, i) < 10 && b.getInfo(4, i) != -1 && b.getInfo(4,i) != 0)
                    {
                        quan19 quan_doi_phuong = new quan19(1, b.getInfo(4, i), 4, i);
                        if (quan_doi_phuong.capture(b, 4, 9))
                        {
                            x1 = 4;
                            y1 = i;
                            return true;
                        }
                    }
                }
                //kiem tra hang 9, y=1, x=0->8, x!=3, x!=4, x!=5
                for (int i = 0; i < 9; i++)
                {
                    if (i!=3 && i!=4 && i!=5 && b.getInfo(i, 9) < 10 && b.getInfo(i,9) != -1)
                    {
                        quan19 quan_doi_phuong = new quan19(1, b.getInfo(i, 9), i, 9);
                        if (quan_doi_phuong.capture(b, 4, 9))
                        {
                            x1 = i;
                            y1 = 9;
                            return true;
                        }
                    }
                }
                //kiem tra duong cheo chinh va phu, tu o (0,5) den o (2,7), tu o (6,7) den o (8,5)
                for (int i = 0; i <= 2; i++)
                {
                    if (b.getInfo(i, i+5) < 10 && b.getInfo(i,i+5) != -1)
                    {
                        quan19 quan_doi_phuong = new quan19(1, b.getInfo(i, i+5), i, i+5);
                        if (quan_doi_phuong.capture(b, 4, 9))
                        {
                            x1 = i;
                            y1 = i + 5;
                            return true;
                        }
                    }
                    if (b.getInfo(6+i, 7-i) < 10 && b.getInfo(6+i, 7-i) != -1)
                    {
                        quan19 quan_doi_phuong = new quan19(1, b.getInfo(6+i, 7-i), 6+i, 7-i);
                        if (quan_doi_phuong.capture(b, 4, 9))
                        {
                            x1 = 6 + i;
                            y1 = 7 - i;
                            return true;
                        }
                    }
                }
            }
            x1 = -1;
            y1 = -1;
            return false;
        }
    }

    public class quan19 : Piece, IPiece
    {
        public quan19(int color, int value, int x, int y)
        {
            this.color = color;
            this.value = value;         //gia tri thuc ghi tren quan co, khong phai gia tri tren board (= gia tri tren board modulo 10)
            this.x = x;
            this.y = y;
        }

        //kiem tra quan o vi tri x2,y2 co phai la dong doi khong (co xet quan 0)
        public bool teammate(Board b, int x2, int y2)
        {
            if (b.getInfo(x2, y2) == -1) return false;
            if (((color == 1) && (b.getInfo(x2, y2) < 10)) || ((color == 2) && (b.getInfo(x2, y2) > 9)))
                return true;
            return false;
        }

        //kiem tra kq co nhan duoc tu cac phep toan so hoc voi x va y hay khong
        public static bool phep_toan(int x, int y, int kq)
        {

            if (((x + y - kq) % 10) == 0)
            {
                //phep = "cong";
                return true;
            }
            if ((x - y) == kq)
            {
                //phep = "tru";
                return true;
            }
            if (((x * y) == kq) || (((x * y) % 10) == kq))
            {
                //phep = "nhan";
                return true;
            }

            if ((y != 0) && (((x / y) == kq) || (((x % y) == kq)&&(x>y))))
            {
                //phep = "chia";
                return true;
            }
            //phep = null;
            return false;

        }

        //kha nang di chuyen den o x2,y2 tren ban co b
        public bool move(Board b, int x2, int y2)
        {
            Point X = new Point(x, y);
            if (X.distance(x2, y2) <= 0)
                return false;

            if (X.distance(x2, y2) > value)
                return false;

            //neu o x2, y2 khong trong
            if (b.getInfo(x2, y2) != -1)
                return false;

            //cung hang, cung cot hoac cung duong cheo va trong tam kiem soat

            //cung cot
            if (x == x2)//sua
            {
                if (y < y2)
                {
                    for (int i = 1; i <= (y2 - y); i++)
                        if (b.getInfo(x, y + i) > -1)
                            return false;
                }
                else
                {
                    for (int i = 1; i <= (y - y2); i++)
                        if (b.getInfo(x, y - i) > -1)
                            return false;
                }
            }
            //cung hang
            if (y == y2)//sua
            {
                if (x < x2)
                {
                    for (int i = 1; i <= (x2 - x); i++)
                        if (b.getInfo(x + i, y) > -1)
                            return false;
                }
                else
                {
                    for (int i = 1; i <= (x - x2); i++)
                        if (b.getInfo(x - i, y) > -1)
                            return false;
                }
            }

            //cung duong cheo
            if ((x + y) == (x2 + y2))
            {
                if (x < x2)
                {
                    for (int i = 1; i <= (x2 - x); i++)
                        if (b.getInfo(x + i, y - i) > -1)
                            return false;
                }
                else
                {
                    for (int i = 1; i <= (x - x2); i++)
                        if (b.getInfo(x - i, y + i) > -1)
                            return false;
                }
            }
            if ((x2 - y2) == (x - y))
            {
                if (x < x2)
                {
                    for (int i = 1; i <= (x2 - x); i++)
                        if (b.getInfo(x + i, y + i) > -1)
                            return false;
                }
                else
                {
                    for (int i = 1; i <= (x - x2); i++)
                        if (b.getInfo(x - i, y - i) > -1)
                            return false;
                }
            }
            return true;

        }

        //kiem tra kha nang an quan o vi tri (x2, y2) tu vi tri hien tai
        public bool capture(Board b, int x2, int y2)
        {
            int quan_canh;
            int khoang_cach;
            //kiem tra xem co quan co nao o vi tri x2, y2 khong
            //neu o o x2,y2 trong
            if (b.getInfo(x2, y2) == -1)
                return false;

            //neu o o x2,y2 la quan co cung mau
            if (((color == 1) && (b.getInfo(x2, y2) < 10)) || ((color == 2) && (b.getInfo(x2, y2) > 9)))
                return false;

            //neu o o x2,y2 la quan co doi phuong
            //khi nao an duoc?

            //neu khong cung hang hoac cung cot hoac cung duong cheo
            if ((x != x2) && (y != y2) && ((x + y) != (x2 + y2)) && ((x - y) != (x2 - y2)))
                return false;

            //cung hang
            if (y == y2)
            {
                if (x < x2)
                {
                    //kiem tra vi tri (x+1, y) co quan minh khong?
                    if (!this.teammate(b, x + 1, y))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x + 1, y) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int j = x + 2; j < x2; j++)
                    {
                        if (b.getInfo(j, y) != -1)
                            return false;
                    }

                    if (phep_toan(value, quan_canh, khoang_cach))
                    {
                        //op = pheptoan;
                        return true;
                    }

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y) co quan minh khong
                    if (!this.teammate(b, x - 1, y))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x - 1, y) % 10;
                    khoang_cach = x - x2 - 1;
                    for (int j = x - 2; j > x2; j--)
                        if (b.getInfo(j, y) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;
                }
            }
            //cung cot
            if (x == x2)
            {
                if (y < y2)
                {
                    //kiem tra vi tri (x, y+1) co quan minh khong?
                    if (!this.teammate(b, x, y + 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x, y + 1) % 10;
                    khoang_cach = y2 - y - 1;
                    for (int j = y + 2; j < y2; j++)
                    {
                        if (b.getInfo(x, j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;

                }
                //y>y2
                else
                {
                    //kiem tra vi tri (x,y-1) co quan minh khong
                    if (!this.teammate(b, x, y - 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x, y - 1) % 10;
                    khoang_cach = y - y2 - 1;
                    for (int j = y - 2; j > y2; j--)
                        if (b.getInfo(x, j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;
                }
            }
            //cung duong cheo chinh
            if (x - y == x2 - y2)
            {
                if (x < x2)
                {
                    //kiem tra vi tri (x+1, y+1) co quan minh khong?
                    if (!this.teammate(b, x + 1, y + 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x + 1, y + 1) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int j = 2; j < x2 - x; j++)
                    {
                        if (b.getInfo(x + j, y + j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y-1) co quan minh khong
                    if (!this.teammate(b, x - 1, y - 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x - 1, y - 1) % 10;
                    khoang_cach = x - x2 - 1;
                    for (int j = x - x2 - 1; j >= 2; j--)
                        if (b.getInfo(x - j, y - j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;
                }
            }
            //cung duong cheo phu
            if (x + y == x2 + y2)
            {
                if (x < x2)
                {
                    //kiem tra vi tri (x+1, y-1) co quan minh khong?
                    if (!this.teammate(b, x + 1, y - 1))
                        return false;
                    //neu co quan minh dung canh, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x + 1, y - 1) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int j = 2; j < x2 - x; j++)
                    {
                        if (b.getInfo(x + j, y - j) != -1)
                            return false;
                    }
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == (value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;

                }
                //x>x2
                else
                {
                    //kiem tra vi tri (x-1,y+1) co quan minh khong
                    if (!this.teammate(b, x - 1, y + 1))
                        return false;
                    //neu co, kiem tra xem co an duoc khong
                    quan_canh = b.getInfo(x - 1, y + 1) % 10;
                    khoang_cach = x - x2 - 1;
                    for (int j = x - x2 - 1; j >= 2; j--)
                        if (b.getInfo(x - j, y + j) != -1)
                            return false;
                    //if ((khoang_cach == (value + quan_canh) % 10) || (khoang_cach == Math.Abs(value - quan_canh)) || (khoang_cach == (value * quan_canh) % 10) || (khoang_cach == (value / quan_canh)) || (khoang_cach == (quan_canh / value)) || (khoang_cach == (value % quan_canh)) || (khoang_cach == (quan_canh % value)))
                    if (phep_toan(value, quan_canh, khoang_cach))
                        return true;
                }
            }
            return false;

        }

        //kiem tra quan co co kiem soat o x2,y2 khong
        public bool control(Board b, int x2, int y2)
        {
            //neu o x2, y2 khac rong
            if (b.getInfo(x2, y2) != -1)
                return false;

            int quan_canh, khoang_cach;
            //cung cot
            if (x == x2)
            {
                if (y > y2)
                {
                    //kiem tra co quan minh o (x, y-1) khong
                    if (b.getColor(x, y - 1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x, y - 1)%10;
                    khoang_cach = y - y2 - 1;
                    for (int i = y - 2; i > y2; i--)
                        if (b.getInfo(x, i) != -1)
                            return false;
                    return phep_toan(this.value,quan_canh,khoang_cach);
                }
                else
                {
                    //kiem tra co quan minh o (x, y+1) khong
                    if(b.getColor(x, y+1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x, y+1) % 10;
                    khoang_cach = y2 - y - 1;
                    for(int i = y + 2; i < y2; i++)
                        if(b.getInfo(x, i) != -1)
                            return false;
                    return phep_toan(this.value,quan_canh,khoang_cach);
                    
                }
            }
            //cung hang
            if (y == y2)
            {
                if (x > x2)
                {
                    //kiem tra co quan minh o (x-1, y) khong
                    if (b.getColor(x-1, y) != this.color)
                        return false;
                    quan_canh = b.getInfo(x-1, y)%10;
                    khoang_cach = x - x2 - 1;
                    for (int i = x - 2; i > x2; i--)
                        if (b.getInfo(i, y) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
                if (x < x2)
                {
                    //kiem tra co quan minh o (x+1, y) khong
                    if(b.getColor(x+1, y) != this.color)
                        return false;
                    quan_canh = b.getInfo(x+1, y) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int i = x + 2; i < x2; i++)
                        if (b.getInfo(i, y) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
            }
            //cung duong cheo chinh
            if (x-y == x2-y2)
            {
                if (x < x2)
                {
                    //kiem tra co quan minh o (x+1, y+1) khong
                    if(b.getColor(x+1, y+1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x+1, y+1) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int i = 2; i < x2 - x; i++)
                        if (b.getInfo(x + i, y + i) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
                if (x > x2)
                {
                    //kiem tra xem co quan minh o (x-1, y-1) khong
                    if(b.getColor(x-1, y-1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x-1, y-1) % 10;
                    khoang_cach = x - x2 - 1;
                    for (int i = x - x2 - 1; i >= 2; i--)
                        if (b.getInfo(x - i, y - i) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
            }
            //cung duong cheo phu
            if (x+y == x2+y2)
            {
                if(x > x2)
                {
                    //kiem tra co quan minh o (x-1, y+1) khong
                    if(b.getColor(x-1, y+1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x-1, y+1) % 10;
                    khoang_cach = x - x2 - 1;
                    for (int i = x - x2 - 1; i >= 2; i--)
                        if (b.getInfo(x - i, y + i) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
                if(x < x2)
                {
                    //kiem tra co quan minh o(x+1, y-1) khong
                    if(b.getColor(x+1, y-1) != this.color)
                        return false;
                    quan_canh = b.getInfo(x+1, y-1) % 10;
                    khoang_cach = x2 - x - 1;
                    for (int i = 2; i < x2 - x; i++)
                        if (b.getInfo(x + i, y - i) != -1)
                            return false;
                    return phep_toan(this.value, quan_canh, khoang_cach);
                }
            }
            return false;
        }
    }
}