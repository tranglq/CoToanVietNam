using System;
//using System.Linq;
using System.Text;

namespace MChess
{
    //class the hien mot nuoc di, luu y value o day la gia tri tren Board (tu 0->19)
    public class Move
    {
        public sbyte x1;          //x1,y1 la toa do diem di
        public sbyte y1;
        public sbyte x2;          //x2,y2 la toa do diem den
        public sbyte y2;
        public bool capture;    //co an quan khong
        public sbyte value;       //neu an thi an quan co gia tri bao nhieu (0->19)

        public Move()
        {
            x1 = y1 = x2 = y2 = -1;
            value = -1;
            capture = false;
        }
        public Move(int x1, int y1, int  x2, int y2, bool capture, int  value)
        {
            this.x1 = (sbyte)x1;
            this.y1 = (sbyte)y1;
            this.x2 = (sbyte)x2;
            this.y2 = (sbyte)y2;
            this.capture = capture;
            this.value =(sbyte)value;
        }

        public void set(int x1,int y1,int x2,int y2, bool capture,int value)
        {
            this.x1 = (sbyte)x1;
            this.y1 = (sbyte)y1;
            this.x2 = (sbyte)x2;
            this.y2 = (sbyte)y2;
            this.capture = capture;
            this.value = (sbyte)value;
        }
    }
}
