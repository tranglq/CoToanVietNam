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
            int i;
            int giatri1 = 75;
            int giatri2 = 30;
            int giatri3 = 5;
            int diemxanh = 0;
            int diemdo = 0;
            int dem3 = 0;
            #region Tinh diem xanh
            foreach (state.chess c in st.QuanXanh)
            {
                if ((c.value  == 0)||(c.value ==-1)) continue;
                //quan phia tren 
                if(c.y-1>0) 
                if ((brd.square[c.x, c.y - 1] > -1) && (brd.square[c.x, c.y - 1] < 10)) // quan xanh
                    for (i = 2; c.y - i >= 0; i++)
                    {
                        if ((brd.square[c.x, c.y - i] > -1) && (brd.square[c.x, c.y - i] < 10)) break;
                        if (brd.square[c.x, c.y - i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                                diemxanh = diemxanh + giatri1;
                            break;
                        }
                        if (brd.square[c.x, c.y - i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan tren phai
                if((c.x+1<8)&&(c.y-1>0))
                if ((brd.square[c.x + 1, c.y - 1] > -1) && (brd.square[c.x + 1, c.y - 1] < 10)) // quan xanh                
                    for (i = 2; (c.y - i >= 0) && (c.x + i < 9); i++)
                    {
                        if ((brd.square[c.x + i, c.y - i] > -1) && (brd.square[c.x + i, c.y - i] < 10)) break;
                        if (brd.square[c.x + i, c.y - i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                                diemxanh = diemxanh + giatri1;
                            break;
                        }
                        if (brd.square[c.x + i, c.y - i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan ben phai
                if(c.x+1<8)
                if ((brd.square[c.x + 1, c.y] > -1) && (brd.square[c.x + 1, c.y] < 10)) // quan xanh                
                    for (i = 2; c.x + i < 9; i++)
                    {
                        if ((brd.square[c.x + i, c.y] > -1) && (brd.square[c.x + i, c.y] < 10)) break;
                        if (brd.square[c.x + i, c.y] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                            {
                                diemxanh = diemxanh + giatri1;
                                if (i <= 3) diemxanh = diemxanh + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                            
                        }
                        if (brd.square[c.x + i, c.y] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan duoi phai
                if((c.x+1<8&&c.y+1<10))
                if ((brd.square[c.x + 1, c.y + 1] > -1) && (brd.square[c.x + 1, c.y + 1] < 10)) // quan xanh                
                    for (i = 2; (c.y + i <= 10) && (c.x + i < 9); i++)
                    {
                        if ((brd.square[c.x + i, c.y + i] > -1) && (brd.square[c.x + i, c.y + i] < 10)) break;
                        if (brd.square[c.x + i, c.y + i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                            {
                                diemxanh = diemxanh + giatri1;
                                if (i <= 3) diemxanh = diemxanh + (1 + 2 * (3 - i)) * 40;
                            }
                             break;                            
                        }
                        if (brd.square[c.x + i, c.y + i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan duoi 
                if(c.y+1<10)
                if ((brd.square[c.x, c.y + 1] > -1) && (brd.square[c.x, c.y + 1] < 10)) // quan xanh                
                    for (i = 2; c.y + i <= 10; i++)
                    {
                        if ((brd.square[c.x, c.y + i] > -1) && (brd.square[c.x, c.y + i] < 10)) break;
                        if (brd.square[c.x, c.y + i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                            {
                                diemxanh = diemxanh + giatri1;
                                if (i <= 3) diemxanh = diemxanh + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                            
                        }
                        if (brd.square[c.x, c.y + i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan duoi trai
                if((c.x-1)>0&&(c.y+1<10))
                if ((brd.square[c.x - 1, c.y + 1] > -1) && (brd.square[c.x - 1, c.y + 1] < 10)) // quan xanh                
                    for (i = 2; (c.y + i <= 10) && (c.x - i >= 0); i++)
                    {
                        if ((brd.square[c.x - i, c.y + i] > -1) && (brd.square[c.x - i, c.y + i] < 10)) break;
                        if (brd.square[c.x - i, c.y + i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                            {
                                diemxanh = diemxanh + giatri1;
                                if (i <= 3) diemxanh = diemxanh + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                            
                        }
                        if (brd.square[c.x - i, c.y + i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan ben trai
                if(c.x-1>0)
                if ((brd.square[c.x - 1, c.y] > -1) && (brd.square[c.x - 1, c.y] < 10)) // quan xanh                
                    for (i = 2; c.x - i >= 0; i++)
                    {
                        if ((brd.square[c.x - i, c.y] > -1) && (brd.square[c.x - i, c.y] < 10)) break;
                        if (brd.square[c.x - i, c.y] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                            {
                                diemxanh = diemxanh + giatri1;
                                if (i <= 3) diemxanh = diemxanh + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                            
                        }
                        if (brd.square[c.x - i, c.y] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                            diemxanh = diemxanh + giatri3;
                    }

                //quan tren trai
                if((c.x-1>0)&&(c.y-1>0))
                if ((brd.square[c.x - 1, c.y - 1] > -1) && (brd.square[c.x - 1, c.y - 1] < 10)) // quan xanh                
                    for (i = 2; (c.y - i >= 0) && (c.x - i >= 0); i++)
                    {
                        if ((brd.square[c.x - i, c.y - i] > -1) && (brd.square[c.x - i, c.y - i] < 10)) break;
                        if (brd.square[c.x - i, c.y - i] == 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                                diemxanh = diemxanh + giatri1;
                            break;
                        }
                        if (brd.square[c.x - i, c.y - i] > 10)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                                diemxanh = diemxanh + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                            diemxanh = diemxanh + giatri3;
                    }
            }
            #endregion 
            
            #region Tinh diem do
            foreach (state.chess c in st.QuanDo)
            {
                if ((c.value  == 10)||(c.value==-1)) continue;
                //quan phia tren 
                if(c.y-1>0)
                if ((brd.square[c.x, c.y - 1] > 9) ) // quan do
                    for (i = 2; c.y - i >= 0; i++)
                    {
                        if ((brd.square[c.x, c.y - i] > 9)) break;
                        if (brd.square[c.x, c.y - i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                            {
                                diemdo = diemdo + giatri1;
                                if (i <= 3) diemdo = diemdo + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                        }
                        if (brd.square[c.x, c.y - i] >0)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x, c.y - 1], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan tren phai
                if((c.x+1<8)&&(c.y-1>0))
                if ((brd.square[c.x + 1, c.y - 1] > 9) ) // quan do                
                    for (i = 2; (c.y - i >= 0) && (c.x + i < 9); i++)
                    {
                        if ((brd.square[c.x + i, c.y - i] > 9)) break;
                        if (brd.square[c.x + i, c.y - i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                            {
                                diemdo = diemdo + giatri1;
                                if (i <= 3) diemdo = diemdo + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                        }
                        if (brd.square[c.x + i, c.y - i] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y - 1], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan ben phai
                if(c.x+1<8)
                if ((brd.square[c.x + 1, c.y] > 9) ) // quan do                
                    for (i = 2; c.x + i < 9; i++)
                    {
                        if ((brd.square[c.x + i, c.y] > 9)) break;
                        if (brd.square[c.x + i, c.y] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                            {
                                diemdo = diemdo + giatri1;
                                if (i <= 3) diemdo = diemdo + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                        }
                        if (brd.square[c.x + i, c.y] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan duoi phai
                if((c.x+1<8)&&(c.y+1<10))
                if ((brd.square[c.x + 1, c.y + 1] > 9) ) // quan do                
                    for (i = 2; (c.y + i <= 10) && (c.x + i < 9); i++)
                    {
                        if ((brd.square[c.x + i, c.y + i] > 9)) break;
                        if (brd.square[c.x + i, c.y + i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                                diemdo = diemdo + giatri1;
                            break;
                        }
                        if (brd.square[c.x + i, c.y + i] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x + 1, c.y + 1], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan duoi 
                if(c.y+1<10)
                if ((brd.square[c.x, c.y + 1] > 9)) // quan do                
                    for (i = 2; c.y + i <= 10; i++)
                    {
                        if ((brd.square[c.x, c.y + i] > 9)) break;
                        if (brd.square[c.x, c.y + i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                                diemdo = diemdo + giatri1;
                            break;
                        }
                        if (brd.square[c.x, c.y + i] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x, c.y + 1], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan duoi trai
                if((c.x-1>0)&&(c.y+1<10))
                if ((brd.square[c.x - 1, c.y + 1] > 9)) // quan do                
                    for (i = 2; (c.y + i <= 10) && (c.x - i >= 0); i++)
                    {
                        if ((brd.square[c.x - i, c.y + i] > 9)) break;
                        if (brd.square[c.x - i, c.y + i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                                diemdo = diemdo + giatri1;
                            break;
                        }
                        if (brd.square[c.x - i, c.y + i] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y + 1], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan ben trai
                if(c.x-1>0)
                if ((brd.square[c.x - 1, c.y] > 9)) // quan do                
                    for (i = 2; c.x - i >= 0; i++)
                    {
                        if ((brd.square[c.x - i, c.y] > 9)) break;
                        if (brd.square[c.x - i, c.y] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                            {
                                diemdo = diemdo + giatri1;
                                if (i <= 3) diemdo = diemdo + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                        }
                        if (brd.square[c.x - i, c.y] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y], i))
                            diemdo = diemdo + giatri3;
                    }

                //quan tren trai
                if((c.x-1>0)&&(c.y-1>0))
                if ((brd.square[c.x - 1, c.y - 1] >9)) // quan do                
                    for (i = 2; (c.y - i >= 0) && (c.x - i >= 0); i++)
                    {
                        if ((brd.square[c.x - i, c.y - i] > 9)) break;
                        if (brd.square[c.x - i, c.y - i] == 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                            {
                                diemdo = diemdo + giatri1;
                                if (i <= 3) diemdo = diemdo + (1 + 2 * (3 - i)) * 40;
                            }
                            break;
                        }
                        if (brd.square[c.x - i, c.y - i] > 0)
                        {
                            if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                                diemdo = diemdo + giatri2;
                            break;
                        }
                        if (st.math2(c.value, brd.square[c.x - 1, c.y - 1], i))
                            diemdo = diemdo + giatri3;
                    }
            }
            #endregion
            if (color == 1)
                return (diemxanh - diemdo);
            else 
                return (diemdo -diemxanh);

        }
        public int Attack2(Board brd, state st, int color)
        {
            int value=20;
            int i;
            int diemxanh=0;
            int diemdo=0;
            //Tinh diem do 
            for (i = 1; i <= 4; i++)
            {
                if ((brd.square[4 - i, 1] < 10) && (brd.square[4 - i, 1] > -1))
                    break;
                if (brd.square[4 - i, 1] > 10) 
                {
                    if ((i < 3)&&(brd.square[4-i,1]<18) ) diemdo = diemdo +  (3 - i) * value;
                    else diemdo = diemdo + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if ((brd.square[4 + i, 1] < 10) && (brd.square[4 + i, 1] > -1))
                    break;
                if (brd.square[4 + i, 1] > 10)
                {
                    if ((i < 3) && (brd.square[4 + i, 1] < 17)) diemdo = diemdo +  (3 - i) * value;
                    else diemdo = diemdo + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if ((brd.square[4 - i, 1+i] < 10) && (brd.square[4 - i, 1+i] > -1))
                    break;
                if (brd.square[4 - i, 1+i] > 10)
                {
                    if ((i < 3) && (brd.square[4 - i, 1+i] < 17)) diemdo = diemdo + 2 * (3 - i) * value;
                    else diemdo = diemdo + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if ((brd.square[4 + i, 1+i] < 10) && (brd.square[4 + i, 1+i] > -1))
                    break;
                if (brd.square[4 + i, 1+i] > 10)
                {
                    if ((i < 3) && (brd.square[4 + i, 1+i] < 17)) diemdo = diemdo + 2 * (3 - i) * value;
                    else diemdo = diemdo + value;
                }
            }
            for (i = 1; i <= 9; i++)
            {
                if ((brd.square[4 , 1+i] < 10) && (brd.square[4 , 1+i] > -1))
                    break;
                if (brd.square[4 , 1+i] > 10)
                {
                    if ((i < 3) && (brd.square[4 , 1+i] < 17)) diemdo = diemdo + 2 * (3 - i) * value;
                    else diemdo = diemdo + value;
                }
            }
            //Tinh diem xanh 
            for (i = 1; i <= 4; i++)
            {
                if (brd.square[4 - i, 9] > 10) 
                    break;
                if ((brd.square[4-i,9]>0)&&(brd.square[4 - i, 9] < 10))
                {
                    if ((i < 3)&&(brd.square[4-i,9]<7))  diemxanh = diemxanh +  (3 - i) * value;
                    else diemxanh = diemxanh + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if (brd.square[4 + i, 9] > 10)
                    break;
                if ((brd.square[4 + i, 9] > 0) && (brd.square[4 + i, 9] < 10))
                {
                    if ((i < 3)&&(brd.square[4+i,9]<7))  diemxanh = diemxanh +  (3 - i) * value;
                    else diemxanh = diemxanh + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if (brd.square[4 - i, 9-i] > 10)
                    break;
                if ((brd.square[4 - i, 9-i] > 0) && (brd.square[4 - i, 9-i] < 10))
                {
                    if ((i < 3) && (brd.square[4 - i, 9-i] < 7)) diemxanh = diemxanh + 2 * (3 - i) * value;
                    else diemxanh = diemxanh + value;
                }
            }
            for (i = 1; i <= 4; i++)
            {
                if (brd.square[4 + i, 9 - i] > 10)
                    break;
                if ((brd.square[4 + i, 9 - i] > 0) && (brd.square[4 + i, 9 - i] < 10))
                {
                    if ((i < 3) && (brd.square[4 + i, 9-i] < 7)) diemxanh = diemxanh + 2 * (3 - i) * value;
                    else diemxanh = diemxanh + value;
                }
            }
            for (i = 1; i <= 9; i++)
            {
                if (brd.square[4 , 9 - i] > 10)
                    break;
                if ((brd.square[4 , 9 - i] > 0) && (brd.square[4 , 9 - i] < 10))
                {
                    if ((i < 3) && (brd.square[4 , 9-i] < 7)) diemxanh = diemxanh + 2 * (3 - i) * value;
                    else diemxanh = diemxanh + value;
                }
            }
            if (color == 1)
                return (diemxanh - diemdo);
            else
                return (diemdo - diemxanh);
        }



        public int Attack(Board brd, int color)
        {
            int result = 0;

            if (color == 1)
            {
                for (int i = 2; i <= 8; i++)
                    if (brd.getColor(4, i) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(4, i), 4, i);
                        if (i == 8 || quan_minh.move(brd, 4, 8))
                            result += 10;
                    }
                for (int i = 0; i <= 3; i++)
                {
                    if (brd.getColor(i, i + 5) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, i + 5), i, i + 5);
                        if (i == 3 || quan_minh.move(brd, 3, 8))
                            result += 8;
                    }
                    if (brd.getColor(i, 9) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 9), i, 9);
                        if (i == 3 || quan_minh.move(brd, 3, 9))
                            result += 8;
                    }
                }
                for (int i = 5; i <= 8; i++)
                {
                    if (brd.getColor(i, 13 - i) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 13 - i), i, 13 - i);
                        if (i == 5 || quan_minh.move(brd, 5, 8))
                            result += 8;
                    }
                    if (brd.getColor(i, 9) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 9), i, 9);
                        if (i == 5 || quan_minh.move(brd, 5, 9))
                            result += 8;
                    }
                }
            }
            else
            {
                for (int i = 2; i <= 8; i++)
                    if (brd.getColor(4, i) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(4, i), 4, i);
                        if (i == 2 || quan_minh.move(brd, 4, 2))
                            result += 10;
                    }
                for (int i = 0; i <= 3; i++)
                {
                    if (brd.getColor(i, 5 - i) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 5 - i), i, 5 - i);
                        if (i == 3 || quan_minh.move(brd, 3, 2))
                            result += 8;
                    }
                    if (brd.getColor(i, 1) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 1), i, 1);
                        if (i == 3 || quan_minh.move(brd, 3, 1))
                            result += 8;
                    }
                }
                for (int i = 5; i <= 8; i++)
                {
                    if (brd.getColor(i, i - 3) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, i - 3), i, i - 3);
                        if (i == 5 || quan_minh.move(brd, 5, 2))
                            result += 8;
                    }
                    if (brd.getColor(i, 1) == color)
                    {
                        quan19 quan_minh = new quan19(color, brd.getInfo(i, 1), i, 1);
                        if (i == 5 || quan_minh.move(brd ,5, 1))
                            result += 8;
                    }
                }
            }
            return result;
        }

        //Ham luong gia tuyen tinh tong hop
        public int Evaluate(Board brd, int color)
        {
            //return (100*MaterialBalance(brd, color) + Ready(brd,color) + BoardControl(brd,color) + Attack(brd, color));
            return 0;
            
        }

        public int QuickEvaluate(Board brd, int color)
        {
            return 0;
        }
    }
}
