namespace MChess
{
    public class Point
    {
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(int i, int j)
        {
            x = (sbyte)i;
            y = (sbyte)j;
        }
        //khoang cach tu o hien tai toi o x2,y2, chi > 0 neu nhu cung hang hoac cung cot hoac cung duong cheo
        public sbyte distance(int x2, int y2)
        {
            if ((x == x2) || ((x2 + y2) == (x + y)) || ((x2 - y2) == (x - y)))
                return (sbyte)((y - y2) > 0 ? (y - y2) : (y2 - y));
            if (y == y2)
                return (sbyte)((x - x2) > 0 ? (x - x2) : (x2 - x));
            return -1;
        }
        public void move(int x, int y)
        {
            this.x = (sbyte)x;
            this.y = (sbyte)y;
        }
        public sbyte x;
        public sbyte y;
    }
}