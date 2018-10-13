using System;
namespace MChess
{
    /// <summary>
    /// Summary description for Board.
    /// </summary>
    public class Board : System.Object
    {
        public int[,] square;

        //hai mang sinh ngau nhien dung de sinh gia tri hash cho ban co
        //gia tri hash se duoc dung de tim the co trong Transposition Table
        //thanh phan [v,i,j] tuong ung voi tinh chat "quan co v o vi tri i,j"
        public static int[,,] HashKeyComponents;
        public static int[,,] HashLockComponents;


        //constructor ban co, chua cac quan co o trang thai ban dau
        public Board()
        {
            int i, j;
            square = new int[9, 11];
            for (i = 0; i < 9; i++)
                for (j = 0; j < 11; j++)
                    square[i, j] = -1;//Empty
            //quan xanh
            square[4, 1] = 0;//quan 0 xanh
            square[0, 0] = 9;//quan 9 xanh
            square[1, 0] = 8;//quan 8 xanh
            square[2, 0] = 7;//quan 7 xanh
            square[3, 0] = 6;//quan 6 xanh
            square[4, 0] = 5;//quan 5 xanh
            square[5, 0] = 4;//quan 4 xanh
            square[6, 0] = 3;//quan 3 xanh
            square[7, 0] = 2;//quan 2 xanh
            square[8, 0] = 1;//quan 1 xanh
            //quan do
            square[4, 9] = 10;//quan 0 do
            square[0, 10] = 11;//quan 1 do
            square[1, 10] = 12;//quan 2 do
            square[2, 10] = 13;//quan 3 do
            square[3, 10] = 14;//quan 4 do
            square[4, 10] = 15;//quan 5 do
            square[5, 10] = 16;//quan 6 do
            square[6, 10] = 17;//quan 7 do
            square[7, 10] = 18;//quan 8 do
            square[8, 10] = 19;//quan 9 do

        }

        //khoi tao cac gia tri tinh
        static Board()
        {
            Random rnd = new Random(457);
            HashKeyComponents = new int[20,9,11];
            HashLockComponents = new int[20,9,11];
            for(int v=0;v<20;v++)
                for(int i=0;i<9;i++)
                    for (int j = 0; j < 11; j++)
                    {
                        HashKeyComponents[v, i, j] = rnd.Next();
                        HashLockComponents[v, i, j] = rnd.Next();
                    }
        }
        

        //tra lai thong tin tai o (i,j)
        public sbyte getInfo(int  i, int j)
        {
            return (sbyte)square[i, j];
        }
        //tra lai mau quan co o vi tri i,j, neu khong co quan co o do, tra lai 0, 1-xanh, 2-do
        public int getColor(int i, int j)
        {
            if (square[i, j] == -1)
                return 0;
            if (square[i, j] < 10) return 1;
            else return 2;
        }

        //dat gia tri value cho o co (i,j)
        public void setSquare(int value, int i, int j)
        {
            square[i, j] = (sbyte)value;
        }

        public int tinh_diem()
        {
            int diem_xanh, diem_do;
            diem_xanh = 0;
            diem_do = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (square[i, j] != -1)
                    {
                        if (square[i, j] < 10)
                        {
                            diem_xanh += square[i, j];
                        }
                        if (square[i, j] > 9)
                        {
                            diem_do += square[i, j] % 10;
                        }
                    }
                }
            if (diem_xanh > diem_do)
                return 1;
            if (diem_xanh < diem_do)
                return 2;
            else
                return 0;
        }

        //diem cua ben color, tuc tong diem da an duoc cua ben kia
        public int diem(int color)
        {
            int dem = 0;
            int tong_diem_doi_phuong = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (square[i, j] != -1 && this.getColor(i, j) != color)
                    {
                        dem++;
                        tong_diem_doi_phuong += square[i, j] % 10;
                    }
                    if (dem == 10)
                        break;
                }
                if (dem == 10)
                    break;
            }
            return (45 - tong_diem_doi_phuong);
        }

        //kiem tra xem quan 0 cua ben color co bi chieu khong
        public bool isChecked(int color)
        {
            int x1, y1;
            if (color == 1)
            {
                quan0 xanh0 = new quan0(1);
                return xanh0.isChecked(this, out x1, out y1);
            }
            else
            {
                quan0 do0 = new quan0(2);
                return do0.isChecked(this, out x1, out y1);
            }
        }

        public bool isMated(int color)
        {
            return false;
        }


        //tra lai true neu nhu co the phong ngu duoc, false neu nhu het co
        public bool canDefend(int color)
        {
            if (this.isChecked(3 - color))
                return true;

            int x1, y1;
            quan0 quan_0 = new quan0(color);
            if (!quan_0.isChecked(this, out x1, out y1))
                return true;

            if (color == 1)
            {
                if (x1 == 4)
                {
                    //co the phong ngu duoc neu nhu an duoc quan (4, y1) hoac (4, y1-1)
                    //hoac co the di duoc quan vao o nam giua (4,1) va (4,y1-1)
                    for(int i=0;i<9;i++)
                        for (int j = 0; j < 11; j++)
                        {
                            if (this.getInfo(i, j) != -1 && this.getInfo(i, j) < 10 && this.getInfo(i, j) > 0)
                            {
                                quan19 quan_minh = new quan19(1, this.getInfo(i, j), i, j);
                                if (quan_minh.capture(this, 4, y1) || quan_minh.capture(this, 4, y1 - 1))
                                    return true;
                                for (int t = 2; t <= y1 - 2; t++)
                                    if (quan_minh.move(this, 4, t))
                                        return true;
                            }
                        }
                }
                else
                {
                    if (y1 == 1)
                    {
                        if (x1 < 3)
                        {
                        
                        }
                        if (x1 > 5)
                        {
                        
                        }                    
                    }
                    else
                    {
                        if (y1 - x1 == 3)
                        {
                            //chan duoc neu an duoc quan(x1,y1) hoac (x1-1,y1-1)
                            //hoac co the di duoc vao o nam giua (4,1) va (x1-1,y1-1)
                        }
                        else
                        {
                            if (x1 + y1 == 5)
                            {
                                //chan duoc neu an duoc quan (x1,y1) hoac (x1+1,y1-1)
                                //hoac co the di duoc vao o nam giua (x1+1,y1-1) va (4,1)
                            }
                        }
                    }
                }
            }
            if (color == 2)
            {
                if (x1 == 4)
                {
                    //chan duoc neu an duoc quan (4,y1) hoac (4,y1+1)
                    //hoac co the di duoc vao o nam giua (4,y1+1) va (4,9)
                }
                else
                {
                    if (y1 == 9)
                    {
                        if (x1 < 3)
                        {
                        
                        }
                        if (x1 > 5)
                        {

                        }
                    }
                    else
                    {
                        if (y1 - x1 == 5)
                        {
                            //chan duoc neu co the an duoc quan (x1,y1) hoac (x1+1,y1+1)
                            //hoac co the di duoc vao o nam giua (x1+1,y1+1) va (4,9)

                        }
                        else
                        {
                            if (x1 + y1 == 13)
                            {
                                //chan duoc neu co the an duoc quan (x1,y1) hoac (x1-1,y1+1)
                                //hoac co the di duoc vao o nam giua (4,9) va (x1-1, y1+1)

                            }
                        }
                    }
                }
            }
            return false;
        }

        //giai thuat tinh gia tri hash ban co theo PP cua Zobrist
        //duyet qua cac gia tri co the cua quan co (tu 0-19), voi moi gia tri ta tim vi tri cua 
        //quan co do tren ban co, tuy vi tri quan co do o dau ta se thuc hien phep toan XOR voi
        //gia tri tuong ung trong bang HashKey
        public int HashKey()
        {
            int hash = 0;
            bool done;
            for (int v = 0; v < 20; v++)
            {
                done = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (this.square[i, j] == v)
                        {
                            hash ^= HashKeyComponents[v, i, j];
                            done = true;
                            break;
                        }
                    }
                    if (done) break;
                }
            }
            return hash;
        }

        //tuong tu HashKey, HashLock ket hop voi mang HashLock, dung de kiem tra hash lan 2, tranh
        //dung do sau lan kiem tra HashKey
        public int HashLock()
        {
            int hash = 0;
            bool done;
            for (int v = 0; v < 20; v++)
            {
                done = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (this.square[i, j] == v)
                        {
                            hash ^= HashLockComponents[v, i, j];
                            done = true;
                            break;
                        }
                    }
                    if (done) break;
                }
            }
            return hash;
        }

        //kiem tra quan co mau color thuc hien nuoc di move co the de doa quan 0 ben kia hay khong
        public bool MoveToCheck(int color, Move move)
        {
            int x1, y1, x2, y2;
            x1 = move.x1;
            y1 = move.y1;
            x2 = move.x2;
            y2 = move.y2;

            //gia thiet move la nuoc di hop le
            Board b = new Board();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                    b.setSquare(this.square[i, j], i, j);

            b.setSquare(b.getInfo(x1,y1), x2, y2);
            b.setSquare(-1, x1, y1);

            quan19 quan_co = new quan19(color, b.getInfo(x2, y2), x2, y2);
            if (color == 1)
                return quan_co.capture(b, 4, 9);
            else
                return quan_co.capture(b, 4, 1);
        }
    }
}
