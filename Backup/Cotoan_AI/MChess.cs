using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MChess
{
    public partial class MChess : Form
    {
        #region Variables
        //mang cac o cua ban co va nhan

        private PictureBox[,] pb;
        //private Label[] row_label;
        //private Label[] col_label;

        //chuoi luu nuoc di vua thuc hien
        private string lbstr = "";

        int NGUOI_CHOI;
        int MAY;
        int loaded_order = 2;
        //so nuoc da di
        public static int dem = 0;

        private int cl;
        private int order;
        private sbyte x1;
        private sbyte y1;
        //doi tuong ban co
        private Board brd;

        Move may_di;
        Move nguoi_di;
        bool undo = false;

        public static int MAX_PLY;
        public static int Q_MAX_PLY;
        public static bool Quickeval;  //Neu quickeval = true thi dung ham quick eval ; 
        public static bool attack; // Co su dung ham tan cong khong ;
        public static int diem_thoa_thuan = 1000;

        DateTime start, stop;
        public Searching COM;
        private Random Rnd;
        private Label[] lb = new Label[4];
        private Image[] img = new Image[20];

        #endregion

        public MChess()
        {
            InitializeComponent();
            NGUOI_CHOI = 2;
            MAY = 1;
            MAX_PLY = 4;
            Quickeval = false;
            attack = true;

        }



        //khoi tao ban co
        public void pointshow()
        {
           // lb[1] = new Label();
            if (diem_thoa_thuan <= 45)
            {
                lb[1] = new Label(); 
                lb[1].Location = new System.Drawing.Point(0, 300);
                lb[1].Size = new System.Drawing.Size(70, 50);
                lb[1].Font = new System.Drawing.Font("Microsoft Sans Serif", 30, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
                lb[1].Name = "cot";
                lb[1].Text = diem_thoa_thuan.ToString();
                lb[1].ForeColor = System.Drawing.Color.Black  ;
                this.Controls.AddRange(new System.Windows.Forms.Control[] { lb[1] });
                
            }
            lb[2] = new Label(); 
            lb[2].Location = new System.Drawing.Point(0, 155);
            lb[2].Size = new System.Drawing.Size(70, 50);
            lb[2].Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            lb[2].Name = "cot";
            lb[2].Text = brd.diem(1).ToString();
            
            lb[2].ForeColor = System.Drawing.Color.Blue;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lb[2] });
            lb[3] = new Label(); 
            lb[3].Location = new System.Drawing.Point(0, 455);
            lb[3].Size = new System.Drawing.Size(70, 50);
            lb[3].Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
            lb[3].Name = "cot";
            lb[3].Text = brd.diem(2).ToString();
           
            lb[3].ForeColor = System.Drawing.Color.Red;
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lb[3] });

            lb[2].Refresh();
            lb[3].Refresh();
           // System.Console.Write("{0}",brd.diem(1));
           // System.Console.Write("{0}", brd.diem(2));

        }



        public void init()
        {
            pb = new PictureBox[9, 11]; //tao mang doi tuong picturebox moi, kich thuoc 9x11
            brd = new Board();        //tao doi tuong ban co moi
            //col_label = new Label[9];
            //row_label = new Label[11];
            may_di = new Move();
            nguoi_di = new Move();

            //Thiet lap thuoc tinh va dat cac o ban co len ban co
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                {
                    pb[i, j] = new PictureBox();   //moi thanh phan cua mang pb la mot picturebox moi
                    if ((i + j) % 2 == 0) this.pb[i, j].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen2;
                    else this.pb[i, j].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen2;
                    this.pb[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    //vi tri va kich thuoc cac o ban co
                    this.pb[i, j].Location = new System.Drawing.Point(70 + i * 50, 50 + j * 50);
                    this.pb[i, j].Name = "pb1";
                    this.pb[i, j].Size = new System.Drawing.Size(50, 50);
                    this.pb[i, j].TabIndex = i;
                    this.pb[i, j].TabStop = false;
                    this.pb[i, j].Cursor = Cursors.Hand;
                    this.Controls.AddRange(new System.Windows.Forms.Control[] { this.pb[i, j] });
                }
            this.pb[4, 1].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen3;
            this.pb[4, 9].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen3;
            
            /*for (char c = 'a'; c <= 'i'; c++)
            {
                int t = (int)(c - 'a');
                this.col_label[t] = new Label();
                this.col_label[t].Location = new System.Drawing.Point(60 + t * 50, 600);
                this.col_label[t].Size = new System.Drawing.Size(40, 40);
                this.col_label[t].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
                this.col_label[t].Name = "cot";
                this.col_label[t].Text = c.ToString();
                this.col_label[t].ForeColor = System.Drawing.Color.Black;
                this.Controls.AddRange(new System.Windows.Forms.Control[] { this.col_label[t] });
            }
            for (int t = 0; t <= 10; t++)
            {
                this.row_label[t] = new Label();
                this.row_label[t].Location = new System.Drawing.Point(0, 550 - t * 50);
                this.row_label[t].Size = new System.Drawing.Size(50, 40);
                this.row_label[t].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
                this.row_label[t].Name = "hang";
                this.row_label[t].Text = (t + 1).ToString();
                this.row_label[t].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                this.Controls.AddRange(new System.Windows.Forms.Control[] { this.row_label[t] });
            }*/

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 780);



            //mac dinh danh voi che do khong gioi han diem
            //this.cboDiem.SelectedIndex = 0;

            #region su kien click len o ban co
            //xu ly cac su kien click len mot o ban co

            this.pb[0, 0].Click += new System.EventHandler(pb_Click1);
            this.pb[1, 0].Click += new System.EventHandler(pb_Click2);
            this.pb[2, 0].Click += new System.EventHandler(pb_Click3);
            this.pb[3, 0].Click += new System.EventHandler(pb_Click4);
            this.pb[4, 0].Click += new System.EventHandler(pb_Click5);
            this.pb[5, 0].Click += new System.EventHandler(pb_Click6);
            this.pb[6, 0].Click += new System.EventHandler(pb_Click7);
            this.pb[7, 0].Click += new System.EventHandler(pb_Click8);
            this.pb[8, 0].Click += new System.EventHandler(pb_Click9);

            this.pb[0, 1].Click += new System.EventHandler(pb_Click10);
            this.pb[1, 1].Click += new System.EventHandler(pb_Click11);
            this.pb[2, 1].Click += new System.EventHandler(pb_Click12);
            this.pb[3, 1].Click += new System.EventHandler(pb_Click13);
            this.pb[4, 1].Click += new System.EventHandler(pb_Click14);
            this.pb[5, 1].Click += new System.EventHandler(pb_Click15);
            this.pb[6, 1].Click += new System.EventHandler(pb_Click16);
            this.pb[7, 1].Click += new System.EventHandler(pb_Click17);
            this.pb[8, 1].Click += new System.EventHandler(pb_Click18);

            this.pb[0, 2].Click += new System.EventHandler(pb_Click19);
            this.pb[1, 2].Click += new System.EventHandler(pb_Click20);
            this.pb[2, 2].Click += new System.EventHandler(pb_Click21);
            this.pb[3, 2].Click += new System.EventHandler(pb_Click22);
            this.pb[4, 2].Click += new System.EventHandler(pb_Click23);
            this.pb[5, 2].Click += new System.EventHandler(pb_Click24);
            this.pb[6, 2].Click += new System.EventHandler(pb_Click25);
            this.pb[7, 2].Click += new System.EventHandler(pb_Click26);
            this.pb[8, 2].Click += new System.EventHandler(pb_Click27);

            this.pb[0, 3].Click += new System.EventHandler(pb_Click28);
            this.pb[1, 3].Click += new System.EventHandler(pb_Click29);
            this.pb[2, 3].Click += new System.EventHandler(pb_Click30);
            this.pb[3, 3].Click += new System.EventHandler(pb_Click31);
            this.pb[4, 3].Click += new System.EventHandler(pb_Click32);
            this.pb[5, 3].Click += new System.EventHandler(pb_Click33);
            this.pb[6, 3].Click += new System.EventHandler(pb_Click34);
            this.pb[7, 3].Click += new System.EventHandler(pb_Click35);
            this.pb[8, 3].Click += new System.EventHandler(pb_Click36);

            this.pb[0, 4].Click += new System.EventHandler(pb_Click37);
            this.pb[1, 4].Click += new System.EventHandler(pb_Click38);
            this.pb[2, 4].Click += new System.EventHandler(pb_Click39);
            this.pb[3, 4].Click += new System.EventHandler(pb_Click40);
            this.pb[4, 4].Click += new System.EventHandler(pb_Click41);
            this.pb[5, 4].Click += new System.EventHandler(pb_Click42);
            this.pb[6, 4].Click += new System.EventHandler(pb_Click43);
            this.pb[7, 4].Click += new System.EventHandler(pb_Click44);
            this.pb[8, 4].Click += new System.EventHandler(pb_Click45);

            this.pb[0, 5].Click += new System.EventHandler(pb_Click46);
            this.pb[1, 5].Click += new System.EventHandler(pb_Click47);
            this.pb[2, 5].Click += new System.EventHandler(pb_Click48);
            this.pb[3, 5].Click += new System.EventHandler(pb_Click49);
            this.pb[4, 5].Click += new System.EventHandler(pb_Click50);
            this.pb[5, 5].Click += new System.EventHandler(pb_Click51);
            this.pb[6, 5].Click += new System.EventHandler(pb_Click52);
            this.pb[7, 5].Click += new System.EventHandler(pb_Click53);
            this.pb[8, 5].Click += new System.EventHandler(pb_Click54);

            this.pb[0, 6].Click += new System.EventHandler(pb_Click55);
            this.pb[1, 6].Click += new System.EventHandler(pb_Click56);
            this.pb[2, 6].Click += new System.EventHandler(pb_Click57);
            this.pb[3, 6].Click += new System.EventHandler(pb_Click58);
            this.pb[4, 6].Click += new System.EventHandler(pb_Click59);
            this.pb[5, 6].Click += new System.EventHandler(pb_Click60);
            this.pb[6, 6].Click += new System.EventHandler(pb_Click61);
            this.pb[7, 6].Click += new System.EventHandler(pb_Click62);
            this.pb[8, 6].Click += new System.EventHandler(pb_Click63);

            this.pb[0, 7].Click += new System.EventHandler(pb_Click64);
            this.pb[1, 7].Click += new System.EventHandler(pb_Click65);
            this.pb[2, 7].Click += new System.EventHandler(pb_Click66);
            this.pb[3, 7].Click += new System.EventHandler(pb_Click67);
            this.pb[4, 7].Click += new System.EventHandler(pb_Click68);
            this.pb[5, 7].Click += new System.EventHandler(pb_Click69);
            this.pb[6, 7].Click += new System.EventHandler(pb_Click70);
            this.pb[7, 7].Click += new System.EventHandler(pb_Click71);
            this.pb[8, 7].Click += new System.EventHandler(pb_Click72);

            this.pb[0, 8].Click += new System.EventHandler(pb_Click73);
            this.pb[1, 8].Click += new System.EventHandler(pb_Click74);
            this.pb[2, 8].Click += new System.EventHandler(pb_Click75);
            this.pb[3, 8].Click += new System.EventHandler(pb_Click76);
            this.pb[4, 8].Click += new System.EventHandler(pb_Click77);
            this.pb[5, 8].Click += new System.EventHandler(pb_Click78);
            this.pb[6, 8].Click += new System.EventHandler(pb_Click79);
            this.pb[7, 8].Click += new System.EventHandler(pb_Click80);
            this.pb[8, 8].Click += new System.EventHandler(pb_Click81);

            this.pb[0, 9].Click += new System.EventHandler(pb_Click82);
            this.pb[1, 9].Click += new System.EventHandler(pb_Click83);
            this.pb[2, 9].Click += new System.EventHandler(pb_Click84);
            this.pb[3, 9].Click += new System.EventHandler(pb_Click85);
            this.pb[4, 9].Click += new System.EventHandler(pb_Click86);
            this.pb[5, 9].Click += new System.EventHandler(pb_Click87);
            this.pb[6, 9].Click += new System.EventHandler(pb_Click88);
            this.pb[7, 9].Click += new System.EventHandler(pb_Click89);
            this.pb[8, 9].Click += new System.EventHandler(pb_Click90);

            this.pb[0, 10].Click += new System.EventHandler(pb_Click91);
            this.pb[1, 10].Click += new System.EventHandler(pb_Click92);
            this.pb[2, 10].Click += new System.EventHandler(pb_Click93);
            this.pb[3, 10].Click += new System.EventHandler(pb_Click94);
            this.pb[4, 10].Click += new System.EventHandler(pb_Click95);
            this.pb[5, 10].Click += new System.EventHandler(pb_Click96);
            this.pb[6, 10].Click += new System.EventHandler(pb_Click97);
            this.pb[7, 10].Click += new System.EventHandler(pb_Click98);
            this.pb[8, 10].Click += new System.EventHandler(pb_Click99);
            #endregion

            #region su kien hover chuot qua o ban co
            this.pb[0, 0].MouseHover += new System.EventHandler(pb_MouseHover1);
            this.pb[1, 0].MouseHover += new System.EventHandler(pb_MouseHover2);
            this.pb[2, 0].MouseHover += new System.EventHandler(pb_MouseHover3);
            this.pb[3, 0].MouseHover += new System.EventHandler(pb_MouseHover4);
            this.pb[4, 0].MouseHover += new System.EventHandler(pb_MouseHover5);
            this.pb[5, 0].MouseHover += new System.EventHandler(pb_MouseHover6);
            this.pb[6, 0].MouseHover += new System.EventHandler(pb_MouseHover7);
            this.pb[7, 0].MouseHover += new System.EventHandler(pb_MouseHover8);
            this.pb[8, 0].MouseHover += new System.EventHandler(pb_MouseHover9);

            this.pb[0, 1].MouseHover += new System.EventHandler(pb_MouseHover10);
            this.pb[1, 1].MouseHover += new System.EventHandler(pb_MouseHover11);
            this.pb[2, 1].MouseHover += new System.EventHandler(pb_MouseHover12);
            this.pb[3, 1].MouseHover += new System.EventHandler(pb_MouseHover13);
            this.pb[4, 1].MouseHover += new System.EventHandler(pb_MouseHover14);
            this.pb[5, 1].MouseHover += new System.EventHandler(pb_MouseHover15);
            this.pb[6, 1].MouseHover += new System.EventHandler(pb_MouseHover16);
            this.pb[7, 1].MouseHover += new System.EventHandler(pb_MouseHover17);
            this.pb[8, 1].MouseHover += new System.EventHandler(pb_MouseHover18);

            this.pb[0, 2].MouseHover += new System.EventHandler(pb_MouseHover19);
            this.pb[1, 2].MouseHover += new System.EventHandler(pb_MouseHover20);
            this.pb[2, 2].MouseHover += new System.EventHandler(pb_MouseHover21);
            this.pb[3, 2].MouseHover += new System.EventHandler(pb_MouseHover22);
            this.pb[4, 2].MouseHover += new System.EventHandler(pb_MouseHover23);
            this.pb[5, 2].MouseHover += new System.EventHandler(pb_MouseHover24);
            this.pb[6, 2].MouseHover += new System.EventHandler(pb_MouseHover25);
            this.pb[7, 2].MouseHover += new System.EventHandler(pb_MouseHover26);
            this.pb[8, 2].MouseHover += new System.EventHandler(pb_MouseHover27);

            this.pb[0, 3].MouseHover += new System.EventHandler(pb_MouseHover28);
            this.pb[1, 3].MouseHover += new System.EventHandler(pb_MouseHover29);
            this.pb[2, 3].MouseHover += new System.EventHandler(pb_MouseHover30);
            this.pb[3, 3].MouseHover += new System.EventHandler(pb_MouseHover31);
            this.pb[4, 3].MouseHover += new System.EventHandler(pb_MouseHover32);
            this.pb[5, 3].MouseHover += new System.EventHandler(pb_MouseHover33);
            this.pb[6, 3].MouseHover += new System.EventHandler(pb_MouseHover34);
            this.pb[7, 3].MouseHover += new System.EventHandler(pb_MouseHover35);
            this.pb[8, 3].MouseHover += new System.EventHandler(pb_MouseHover36);

            this.pb[0, 4].MouseHover += new System.EventHandler(pb_MouseHover37);
            this.pb[1, 4].MouseHover += new System.EventHandler(pb_MouseHover38);
            this.pb[2, 4].MouseHover += new System.EventHandler(pb_MouseHover39);
            this.pb[3, 4].MouseHover += new System.EventHandler(pb_MouseHover40);
            this.pb[4, 4].MouseHover += new System.EventHandler(pb_MouseHover41);
            this.pb[5, 4].MouseHover += new System.EventHandler(pb_MouseHover42);
            this.pb[6, 4].MouseHover += new System.EventHandler(pb_MouseHover43);
            this.pb[7, 4].MouseHover += new System.EventHandler(pb_MouseHover44);
            this.pb[8, 4].MouseHover += new System.EventHandler(pb_MouseHover45);

            this.pb[0, 5].MouseHover += new System.EventHandler(pb_MouseHover46);
            this.pb[1, 5].MouseHover += new System.EventHandler(pb_MouseHover47);
            this.pb[2, 5].MouseHover += new System.EventHandler(pb_MouseHover48);
            this.pb[3, 5].MouseHover += new System.EventHandler(pb_MouseHover49);
            this.pb[4, 5].MouseHover += new System.EventHandler(pb_MouseHover50);
            this.pb[5, 5].MouseHover += new System.EventHandler(pb_MouseHover51);
            this.pb[6, 5].MouseHover += new System.EventHandler(pb_MouseHover52);
            this.pb[7, 5].MouseHover += new System.EventHandler(pb_MouseHover53);
            this.pb[8, 5].MouseHover += new System.EventHandler(pb_MouseHover54);

            this.pb[0, 6].MouseHover += new System.EventHandler(pb_MouseHover55);
            this.pb[1, 6].MouseHover += new System.EventHandler(pb_MouseHover56);
            this.pb[2, 6].MouseHover += new System.EventHandler(pb_MouseHover57);
            this.pb[3, 6].MouseHover += new System.EventHandler(pb_MouseHover58);
            this.pb[4, 6].MouseHover += new System.EventHandler(pb_MouseHover59);
            this.pb[5, 6].MouseHover += new System.EventHandler(pb_MouseHover60);
            this.pb[6, 6].MouseHover += new System.EventHandler(pb_MouseHover61);
            this.pb[7, 6].MouseHover += new System.EventHandler(pb_MouseHover62);
            this.pb[8, 6].MouseHover += new System.EventHandler(pb_MouseHover63);

            this.pb[0, 7].MouseHover += new System.EventHandler(pb_MouseHover64);
            this.pb[1, 7].MouseHover += new System.EventHandler(pb_MouseHover65);
            this.pb[2, 7].MouseHover += new System.EventHandler(pb_MouseHover66);
            this.pb[3, 7].MouseHover += new System.EventHandler(pb_MouseHover67);
            this.pb[4, 7].MouseHover += new System.EventHandler(pb_MouseHover68);
            this.pb[5, 7].MouseHover += new System.EventHandler(pb_MouseHover69);
            this.pb[6, 7].MouseHover += new System.EventHandler(pb_MouseHover70);
            this.pb[7, 7].MouseHover += new System.EventHandler(pb_MouseHover71);
            this.pb[8, 7].MouseHover += new System.EventHandler(pb_MouseHover72);

            this.pb[0, 8].MouseHover += new System.EventHandler(pb_MouseHover73);
            this.pb[1, 8].MouseHover += new System.EventHandler(pb_MouseHover74);
            this.pb[2, 8].MouseHover += new System.EventHandler(pb_MouseHover75);
            this.pb[3, 8].MouseHover += new System.EventHandler(pb_MouseHover76);
            this.pb[4, 8].MouseHover += new System.EventHandler(pb_MouseHover77);
            this.pb[5, 8].MouseHover += new System.EventHandler(pb_MouseHover78);
            this.pb[6, 8].MouseHover += new System.EventHandler(pb_MouseHover79);
            this.pb[7, 8].MouseHover += new System.EventHandler(pb_MouseHover80);
            this.pb[8, 8].MouseHover += new System.EventHandler(pb_MouseHover81);

            this.pb[0, 9].MouseHover += new System.EventHandler(pb_MouseHover82);
            this.pb[1, 9].MouseHover += new System.EventHandler(pb_MouseHover83);
            this.pb[2, 9].MouseHover += new System.EventHandler(pb_MouseHover84);
            this.pb[3, 9].MouseHover += new System.EventHandler(pb_MouseHover85);
            this.pb[4, 9].MouseHover += new System.EventHandler(pb_MouseHover86);
            this.pb[5, 9].MouseHover += new System.EventHandler(pb_MouseHover87);
            this.pb[6, 9].MouseHover += new System.EventHandler(pb_MouseHover88);
            this.pb[7, 9].MouseHover += new System.EventHandler(pb_MouseHover89);
            this.pb[8, 9].MouseHover += new System.EventHandler(pb_MouseHover90);

            this.pb[0, 10].MouseHover += new System.EventHandler(pb_MouseHover91);
            this.pb[1, 10].MouseHover += new System.EventHandler(pb_MouseHover92);
            this.pb[2, 10].MouseHover += new System.EventHandler(pb_MouseHover93);
            this.pb[3, 10].MouseHover += new System.EventHandler(pb_MouseHover94);
            this.pb[4, 10].MouseHover += new System.EventHandler(pb_MouseHover95);
            this.pb[5, 10].MouseHover += new System.EventHandler(pb_MouseHover96);
            this.pb[6, 10].MouseHover += new System.EventHandler(pb_MouseHover97);
            this.pb[7, 10].MouseHover += new System.EventHandler(pb_MouseHover98);
            this.pb[8, 10].MouseHover += new System.EventHandler(pb_MouseHover99);
            #endregion
        }

        private void init2()
        {
            cl = 0;
            order = -1;  //cho nguoi choi chon quan
            x1 = 1;
            y1 = 1;

            //load cac file anh vao cac doi tuong img[]
            Image_Load(2);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MChess());
        }



        /******************************************************************************
         *                      XU LY TRONG VAN CHOI
         *           NGUOI CHOI DI QUAN, MAY NGHI VA DI QUAN
         * ***************************************************************************/
        //khi nguoi choi click vao o i,j
        public int play(sbyte i, sbyte j)
        {
            int y, z;
            int played = 0;               //xac dinh quan co duoc click mau nao
            int k = brd.getInfo(i, j);     //gia tri tai o (i,j): quan co nao, mau nao, hay o rong


            if (order == 0)
            {
                MessageBox.Show("Ván cờ đã kết thúc, Click Ván mới để chơi lại", "Thông báo");
                ;
                return 0;
            }

            if (order == MAY)
            {
                return 0;
            }
            //xac dinh o co da dc click
            if (k > 9)
            {
                played = 2;             //quan do
            }
            else if (k < 10 && k != -1)
            {
                played = 1;             //quan xanh
            }

            //neu truoc do chua click, vua click vao o co va vao quan co cua minh
            if (cl == 0 && k != -1 && played == order)
            {
                x1 = i;
                y1 = j;
                this.pb[i, j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                //highlight cac o co the di duoc tu o (x1,y1) voi nguoi choi (order=2)
                if (k % 10 != 0)
                {
                    quan19 quan_co = new quan19((k / 10) + 1, k % 10, x1, y1);
                    for (y = 0; y < 9; y++)
                        for (z = 0; z < 11; z++)
                        {
                            if (quan_co.move(brd, y, z))
                                pb[y, z].BackgroundImage = global::Cotoan_AI.Properties.Resources.hl1;
                            if (quan_co.capture(brd, y, z))
                            {
                                pb[y, z].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                                pb[y, z].BackgroundImage = global::Cotoan_AI.Properties.Resources.hl2;
                            }
                        }
                }
                cl = 1;
                return 0;
            }

            if (cl == 1)
            {
                clear_highlight();

                for (int t = 0; t < 9; t++)
                    for (int l = 0; l < 11; l++)
                        pb[t, l].Refresh();

                if ((x1 == i) && (y1 == j))
                {
                    cl = 0;
                    this.pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    return 0;
                }

                int m = brd.getInfo(x1, y1);        //xac dinh quan co o vi tri x1,y1
                int c = (m / 10) + 1;                   //mau cua quan o vi tri x1,y1, 1 xanh, 2 do
                Board b = new Board();
                //copy ban co cu sang ban moi b
                for (y = 0; y < 9; y++)
                    for (z = 0; z < 11; z++)
                        b.setSquare(brd.getInfo(y, z), y, z);

                //neu click vao quan 0 o vi tri (x1,y1)
                if ((m == 0) || (m == 10))
                {
                    this.pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    cl = 0;
                    return 0;
                }

                //neu la cac quan tu 1 den 9 o vi tri (x1, y1), muon nhay den (i,j)
                //kiem tra kha nang di chuyen den (i,j) khi o (i,j) la rong
                if (b.getInfo(i, j) == -1)
                {
                    quan19 quan_co = new quan19(c, m % 10, x1, y1);
                    if (quan_co.move(brd, i, j))
                    {

                        pb[i, j].Image = pb[x1, y1].Image;
                        pb[x1, y1].Image = null;
                        brd.setSquare(-1, x1, y1);
                        brd.setSquare(m, i, j);
                        nguoi_di.set(x1, y1, i, j, false, -1);
                        dem++;
                        lbstr = "[" + dem.ToString() + "]  " + (m % 10).ToString() + (c == 1 ? " xanh" : " đỏ") + "\t(" + ((char)('a' + x1)).ToString() + ", " + (11 - y1).ToString() + ")  ----->  (" + ((char)('a' + i)).ToString() + ", " + (11 - j).ToString() + ")";
                    }
                    else
                    {
                        cl = 0;
                        pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        return 0;
                    }
                }
                //neu o vi tri (i,j) khong rong, tuc la co mot quan da o do, kiem tra kha nang an quan
                else
                {
                    //neu o do la quan cung mau
                    if (((c == 1) && (b.getInfo(i, j) < 10)) || ((c == 2) && (b.getInfo(i, j) > 9)))
                    {
                        cl = 0;
                        pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        play(i, j);
                        return 0;
                    }
                    //o (i,j) la quan khac mau, kiem tra co an duoc khong
                    quan19 quan_co = new quan19(c, m % 10, x1, y1);
                    if (quan_co.capture(brd, i, j))
                    {
                        int temp = brd.getInfo(i, j);
                        pb[i, j].Image = pb[x1, y1].Image;
                        pb[x1, y1].Image = null;
                        brd.setSquare(-1, x1, y1);
                        brd.setSquare(m, i, j);
                        nguoi_di.set(x1, y1, i, j, true, temp);
                        dem++;
                        lbstr = "[" + dem.ToString() + "]  " + (m % 10).ToString() + (c == 1 ? " xanh" : " đỏ") + "   (" + ((char)('a' + x1)).ToString() + ", " + (11 - y1).ToString() + ") bắt " + temp % 10 + ((3 - c) == 1 ? " xanh " : " đỏ ") + "   (" + ((char)('a' + i)).ToString() + ", " + (11 - j).ToString() + ")";
                        if (temp % 10 == 0)
                        {
                            MessageBox.Show("Bạn đã thắng tuyệt đối!");
                            order = 0;
                            return 1;
                        }
                    }
                    else
                    {
                        cl = 0;
                        pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        clear_highlight();
                        return 0;
                    }
                }

                //sau khi thuc hien nuoc di chuyen hay an quan thanh cong
                this.pb[x1, y1].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cl = 0;
                order = 3 - order;

                for (int t = 0; t < 9; t++)
                    for (int l = 0; l < 11; l++)
                        pb[t, l].Refresh();

                quaylaitoolStripMenuItem.Enabled = undo = doSauTimKiemToolStripMenuItem.Enabled = quanCoToolStripMenuItem.Enabled = false;

                //cap nhat danh sach nuoc di
                //lbNuocdi.Items.Add(lbstr);
                //lbNuocdi.Refresh();
                //lbNuocdi.SetSelected(dem - 1, true);

                //txtDiem.Text = "Điểm:       Đỏ   " + brd.diem(2) + "   -   " + brd.diem(1) + "   Xanh";
                //txtDiem.Refresh();
             //   pointshow();
                if (lb[1] != null)
                    lb[1].Text = diem_thoa_thuan.ToString();
                lb[2].Text = brd.diem(1).ToString();
                lb[3].Text = brd.diem(2).ToString();
                //kiem tra diem người chơi
                if (brd.diem(NGUOI_CHOI) >= diem_thoa_thuan)
                {
                    MessageBox.Show("Bạn đã thắng điểm!", "Thông báo");
                    order = 0;
                    Set_Controls("Ended");
                    return 1;
                }

                //Kich hoat may thuc hien nuoc di
                COM_THINK();
                //thay doi noi dung listbox
                return 1;
            }
            return 0;
        }
        public void COM_THINK()
        {
            COM.so_nuoc_di = 0;

            //update brd cho COM
            COM.UpdateBoard(brd);
            //Xoa lich su?
            if (Rnd.Next() % 5 == 2)
            {
                COM.HisTable.Forget();
            }

            start = DateTime.Now;
            //this.Cursor = Cursors.WaitCursor;

            COM.alpha_beta(MAY, Int32.MinValue + 1, Int32.MaxValue, MAX_PLY);
            //if (fire[7, 8, 0] != 0) Console.WriteLine ("") ;
            stop = DateTime.Now;

            if (COM.so_nuoc_di == 0)
            {
                MessageBox.Show("Tớ không đi được nữa, thua rồi!", "Thông báo");
                order = 0;
                Set_Controls("Ended");
                return;
            }

            //cap nhat nuoc di cua may
            brd.setSquare(brd.getInfo(COM.next_move.x1, COM.next_move.y1), COM.next_move.x2, COM.next_move.y2);
            brd.setSquare(-1, COM.next_move.x1, COM.next_move.y1);
            pb[COM.next_move.x2, COM.next_move.y2].Image = pb[COM.next_move.x1, COM.next_move.y1].Image;
            pb[COM.next_move.x1, COM.next_move.y1].Image = null;
            pb[COM.next_move.x1, COM.next_move.y1].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pb[COM.next_move.x2, COM.next_move.y2].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //cap nhat thong tin
            //txtTime.Text = (stop - start).ToString();
            dem++;
            //txtTB.Text = ((double)((double)COM.tong_so_nuoc_di / (double)(dem % 2 == 0 ? dem / 2 : (MAY == 2 ? ((dem + 1) / 2) : ((dem - 1) / 2))))).ToString();

            //txtQDepth.Text = COM.QuiescenceNode.ToString();

            may_di = COM.next_move;

            if (!COM.next_move.capture)
                lbstr = "[" + dem.ToString() + "]\t" + brd.getInfo(COM.next_move.x2, COM.next_move.y2) % 10 + (MAY == 1 ? " xanh" : " đỏ") + "  (" + ((char)('a' + COM.next_move.x1)).ToString() + ", " + (11 - COM.next_move.y1).ToString() + ")  ----->  (" + ((char)('a' + COM.next_move.x2)).ToString() + ", " + (11 - COM.next_move.y2).ToString() + ")";
            else
                lbstr = "[" + dem.ToString() + "]\t" + brd.getInfo(COM.next_move.x2, COM.next_move.y2) % 10 + (MAY == 1 ? " xanh" : " đỏ") + "  (" + ((char)('a' + COM.next_move.x1)).ToString() + ", " + (11 - COM.next_move.y1).ToString() + ") bắt " + COM.next_move.value % 10 + (NGUOI_CHOI == 1 ? " xanh" : " đỏ") + "  (" + ((char)('a' + COM.next_move.x2)).ToString() + ", " + (11 - COM.next_move.y2).ToString() + ")";

            //cap nhat list box
            //lbNuocdi.Items.Add(lbstr);
            //lbNuocdi.Refresh();
            //lbNuocdi.SetSelected(dem - 1, true);

            //txtDiem.Text = "Điểm:       Đỏ   " + brd.diem(2) + "   -   " + brd.diem(1) + "   Xanh";
            //txtDiem.Refresh();
            //pointshow();
            if (lb[1] != null)
            lb[1].Text = diem_thoa_thuan.ToString();
            lb[2].Text = brd.diem(1).ToString();
            lb[3].Text = brd.diem(2).ToString();
            
            //Neu may vua bat duoc quan 0 cua nguoi choi
            if (COM.next_move.capture && (COM.next_move.value % 10 == 0))
            {
                MessageBox.Show("Bạn thua tuyệt đối rồi!", "Kết thúc");
                order = 0;
                quaylaitoolStripMenuItem.Enabled = false;
            }
            else
            {
                //kiem tra diem cua may
                if (brd.diem(MAY) >= diem_thoa_thuan)
                {
                    MessageBox.Show("Bạn đã thua tính điểm!", "Thông báo");
                    Set_Controls("Ended");
                    order = 0;
                }
            }

            //Neu nguoi choi khong con quan nao co the di duoc


            quaylaitoolStripMenuItem.Enabled = undo = true;
            order = 3 - order;
        }



        /******************************************************************************
         *              XY LY VOI CAC PICTURE BOX VA CONTROL
         *****************************************************************************/
        //xoa highlight tren ban co
        public void clear_highlight()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                {
                    if ((i + j) % 2 == 0) pb[i, j].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen2;
                    else pb[i, j].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen2;
                    pb[4, 1].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen3;
                    pb[4, 9].BackgroundImage = global::Cotoan_AI.Properties.Resources.nen3;
                    pb[i, j].BorderStyle = BorderStyle.FixedSingle;

                }
        }

        //Cap nhat hinh anh ban co dua tren thong tin tu brd va img
        public void Update_Image()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (brd.getInfo(i, j) == -1)
                        pb[i, j].Image = null;
                    else
                        pb[i, j].Image = img[brd.getInfo(i, j)];
                    pb[i, j].Refresh();
                }
        }

        //tuy chon bo quan co, dung so hoac dung cham
        public void Image_Load(int version)
        {
            switch (version)
            {
                case 1:
                    //load cac file anh vao cac doi tuong img[]
                    img[0] = global::Cotoan_AI.Properties.Resources.x0_v1;
                    img[1] = global::Cotoan_AI.Properties.Resources.x1_v1;
                    img[2] = global::Cotoan_AI.Properties.Resources.x2_v1;
                    img[3] = global::Cotoan_AI.Properties.Resources.x3_v1;
                    img[4] = global::Cotoan_AI.Properties.Resources.x4_v1;
                    img[5] = global::Cotoan_AI.Properties.Resources.x5_v1;
                    img[6] = global::Cotoan_AI.Properties.Resources.x6_v1;
                    img[7] = global::Cotoan_AI.Properties.Resources.x7_v1;
                    img[8] = global::Cotoan_AI.Properties.Resources.x8_v1;
                    img[9] = global::Cotoan_AI.Properties.Resources.x9_v1;

                    img[10] = global::Cotoan_AI.Properties.Resources.d0_v1;
                    img[11] = global::Cotoan_AI.Properties.Resources.d1_v1;
                    img[12] = global::Cotoan_AI.Properties.Resources.d2_v1;
                    img[13] = global::Cotoan_AI.Properties.Resources.d3_v1;
                    img[14] = global::Cotoan_AI.Properties.Resources.d4_v1;
                    img[15] = global::Cotoan_AI.Properties.Resources.d5_v1;
                    img[16] = global::Cotoan_AI.Properties.Resources.d6_v1;
                    img[17] = global::Cotoan_AI.Properties.Resources.d7_v1;
                    img[18] = global::Cotoan_AI.Properties.Resources.d8_v1;
                    img[19] = global::Cotoan_AI.Properties.Resources.d9_v1;
                    break;
                case 2:
                    img[0] = global::Cotoan_AI.Properties.Resources.x0_v2;
                    img[1] = global::Cotoan_AI.Properties.Resources.x1_v2;
                    img[2] = global::Cotoan_AI.Properties.Resources.x2_v2;
                    img[3] = global::Cotoan_AI.Properties.Resources.x3_v2;
                    img[4] = global::Cotoan_AI.Properties.Resources.x4_v2;
                    img[5] = global::Cotoan_AI.Properties.Resources.x5_v2;
                    img[6] = global::Cotoan_AI.Properties.Resources.x6_v2;
                    img[7] = global::Cotoan_AI.Properties.Resources.x7_v2;
                    img[8] = global::Cotoan_AI.Properties.Resources.x8_v2;
                    img[9] = global::Cotoan_AI.Properties.Resources.x9_v2;

                    img[10] = global::Cotoan_AI.Properties.Resources.d0_v2;
                    img[11] = global::Cotoan_AI.Properties.Resources.d1_v2;
                    img[12] = global::Cotoan_AI.Properties.Resources.d2_v2;
                    img[13] = global::Cotoan_AI.Properties.Resources.d3_v2;
                    img[14] = global::Cotoan_AI.Properties.Resources.d4_v2;
                    img[15] = global::Cotoan_AI.Properties.Resources.d5_v2;
                    img[16] = global::Cotoan_AI.Properties.Resources.d6_v2;
                    img[17] = global::Cotoan_AI.Properties.Resources.d7_v2;
                    img[18] = global::Cotoan_AI.Properties.Resources.d8_v2;
                    img[19] = global::Cotoan_AI.Properties.Resources.d9_v2;
                    break;

            }
            Update_Image();
        }

        //thiet lap trang thai cac nut dieu khien va thanh trang thai 
        private void Set_Controls(string status)
        {
            switch (status)
            {
                case "Waiting":
                    quaylaitoolStripMenuItem.Enabled = vanMoiToolStripMenuItem.Enabled = ngungchoiToolStripMenuItem.Enabled = dauhangtoolStripMenuItem.Enabled = false;
                    batDauToolStripMenuItem.Enabled = true;
                    //radio1.Enabled = radio2.Enabled = true;
                    lblstatus.Text = "Chọn quân đỏ hoặc quân xanh rồi click Bắt đầu";
                    break;
                case "Playing":
                    quaylaitoolStripMenuItem.Enabled = vanMoiToolStripMenuItem.Enabled = ngungchoiToolStripMenuItem.Enabled = dauhangtoolStripMenuItem.Enabled = true;
                    batDauToolStripMenuItem.Enabled = false;
                    //radio1.Enabled = radio2.Enabled = false;
                    lblstatus.Text = "";
                    //cboDiem.Enabled = false;
                    break;
                case "Ended":
                    quaylaitoolStripMenuItem.Enabled = ngungchoiToolStripMenuItem.Enabled = batDauToolStripMenuItem.Enabled = dauhangtoolStripMenuItem.Enabled = false;
                    vanMoiToolStripMenuItem.Enabled = true;
                    //radio1.Enabled = radio2.Enabled = false;
                    lblstatus.Text = "Ván đấu đã kết thúc, chọn Ván mới để chơi lại";
                    break;
                case "Resigned":
                    quaylaitoolStripMenuItem.Enabled = ngungchoiToolStripMenuItem.Enabled = batDauToolStripMenuItem.Enabled = dauhangtoolStripMenuItem.Enabled = false;
                    vanMoiToolStripMenuItem.Enabled = true;
                    //radio1.Enabled = radio2.Enabled = false;
                    lblstatus.Text = "Ván đấu đã kết thúc, bạn đã đầu hàng!";
                    break;
            }
        }



        /*******************************************************************************
         *                      CAC PHUONG THUC XU LY SU KIEN
         ******************************************************************************/

        #region XU LY SU KIEN

        #region Xu ly su kien click vao o ban co

        private void pb_Click1(object sender, System.EventArgs e)
        {
            play(0, 0);
        }

        private void pb_Click2(object sender, System.EventArgs e)
        {
            play(1, 0);
        }

        private void pb_Click3(object sender, System.EventArgs e)
        {
            play(2, 0);
        }

        private void pb_Click4(object sender, System.EventArgs e)
        {
            play(3, 0);
        }

        private void pb_Click5(object sender, System.EventArgs e)
        {
            play(4, 0);
        }

        private void pb_Click6(object sender, System.EventArgs e)
        {
            play(5, 0);
        }

        private void pb_Click7(object sender, System.EventArgs e)
        {
            play(6, 0);
        }

        private void pb_Click8(object sender, System.EventArgs e)
        {
            play(7, 0);
        }

        private void pb_Click9(object sender, System.EventArgs e)
        {
            play(8, 0);
        }

        private void pb_Click10(object sender, System.EventArgs e)
        {
            play(0, 1);
        }

        private void pb_Click11(object sender, System.EventArgs e)
        {
            play(1, 1);
        }

        private void pb_Click12(object sender, System.EventArgs e)
        {
            play(2, 1);
        }

        private void pb_Click13(object sender, System.EventArgs e)
        {
            play(3, 1);
        }

        private void pb_Click14(object sender, System.EventArgs e)
        {
            play(4, 1);
        }

        private void pb_Click15(object sender, System.EventArgs e)
        {
            play(5, 1);
        }

        private void pb_Click16(object sender, System.EventArgs e)
        {
            play(6, 1);
        }

        private void pb_Click17(object sender, System.EventArgs e)
        {
            play(7, 1);
        }

        private void pb_Click18(object sender, System.EventArgs e)
        {
            play(8, 1);
        }

        private void pb_Click19(object sender, System.EventArgs e)
        {
            play(0, 2);
        }

        private void pb_Click20(object sender, System.EventArgs e)
        {
            play(1, 2);
        }

        private void pb_Click21(object sender, System.EventArgs e)
        {
            play(2, 2);
        }


        private void pb_Click22(object sender, System.EventArgs e)
        {
            play(3, 2);
        }

        private void pb_Click23(object sender, System.EventArgs e)
        {
            play(4, 2);
        }

        private void pb_Click24(object sender, System.EventArgs e)
        {
            play(5, 2);
        }

        private void pb_Click25(object sender, System.EventArgs e)
        {
            play(6, 2);
        }

        private void pb_Click26(object sender, System.EventArgs e)
        {
            play(7, 2);
        }

        private void pb_Click27(object sender, System.EventArgs e)
        {
            play(8, 2);
        }

        private void pb_Click28(object sender, System.EventArgs e)
        {
            play(0, 3);
        }

        private void pb_Click29(object sender, System.EventArgs e)
        {
            play(1, 3);
        }


        private void pb_Click30(object sender, System.EventArgs e)
        {
            play(2, 3);
        }

        private void pb_Click31(object sender, System.EventArgs e)
        {
            play(3, 3);
        }

        private void pb_Click32(object sender, System.EventArgs e)
        {
            play(4, 3);
        }

        private void pb_Click33(object sender, System.EventArgs e)
        {
            play(5, 3);
        }

        private void pb_Click34(object sender, System.EventArgs e)
        {
            play(6, 3);
        }

        private void pb_Click35(object sender, System.EventArgs e)
        {
            play(7, 3);
        }

        private void pb_Click36(object sender, System.EventArgs e)
        {
            play(8, 3);
        }

        private void pb_Click37(object sender, System.EventArgs e)
        {
            play(0, 4);
        }


        private void pb_Click38(object sender, System.EventArgs e)
        {
            play(1, 4);
        }

        private void pb_Click39(object sender, System.EventArgs e)
        {
            play(2, 4);
        }

        private void pb_Click40(object sender, System.EventArgs e)
        {
            play(3, 4);
        }

        private void pb_Click41(object sender, System.EventArgs e)
        {
            play(4, 4);
        }

        private void pb_Click42(object sender, System.EventArgs e)
        {
            play(5, 4);
        }

        private void pb_Click43(object sender, System.EventArgs e)
        {
            play(6, 4);
        }

        private void pb_Click44(object sender, System.EventArgs e)
        {
            play(7, 4);
        }

        private void pb_Click45(object sender, System.EventArgs e)
        {
            play(8, 4);
        }


        private void pb_Click46(object sender, System.EventArgs e)
        {
            play(0, 5);
        }

        private void pb_Click47(object sender, System.EventArgs e)
        {
            play(1, 5);
        }

        private void pb_Click48(object sender, System.EventArgs e)
        {
            play(2, 5);
        }

        private void pb_Click49(object sender, System.EventArgs e)
        {
            play(3, 5);
        }

        private void pb_Click50(object sender, System.EventArgs e)
        {
            play(4, 5);
        }

        private void pb_Click51(object sender, System.EventArgs e)
        {
            play(5, 5);
        }

        private void pb_Click52(object sender, System.EventArgs e)
        {
            play(6, 5);
        }

        private void pb_Click53(object sender, System.EventArgs e)
        {
            play(7, 5);
        }


        private void pb_Click54(object sender, System.EventArgs e)
        {
            play(8, 5);
        }

        private void pb_Click55(object sender, System.EventArgs e)
        {
            play(0, 6);
        }

        private void pb_Click56(object sender, System.EventArgs e)
        {
            play(1, 6);
        }

        private void pb_Click57(object sender, System.EventArgs e)
        {
            play(2, 6);
        }

        private void pb_Click58(object sender, System.EventArgs e)
        {
            play(3, 6);
        }

        private void pb_Click59(object sender, System.EventArgs e)
        {
            play(4, 6);
        }

        private void pb_Click60(object sender, System.EventArgs e)
        {
            play(5, 6);
        }

        private void pb_Click61(object sender, System.EventArgs e)
        {
            play(6, 6);
        }

        private void pb_Click62(object sender, System.EventArgs e)
        {
            play(7, 6);
        }

        private void pb_Click63(object sender, System.EventArgs e)
        {
            play(8, 6);
        }

        private void pb_Click64(object sender, System.EventArgs e)
        {
            play(0, 7);
        }
        private void pb_Click65(object sender, System.EventArgs e)
        {
            play(1, 7);
        }
        private void pb_Click66(object sender, System.EventArgs e)
        {
            play(2, 7);
        }
        private void pb_Click67(object sender, System.EventArgs e)
        {
            play(3, 7);
        }
        private void pb_Click68(object sender, System.EventArgs e)
        {
            play(4, 7);
        }
        private void pb_Click69(object sender, System.EventArgs e)
        {
            play(5, 7);
        }

        private void pb_Click70(object sender, System.EventArgs e)
        {
            play(6, 7);
        }
        private void pb_Click71(object sender, System.EventArgs e)
        {
            play(7, 7);
        }
        private void pb_Click72(object sender, System.EventArgs e)
        {
            play(8, 7);
        }
        private void pb_Click73(object sender, System.EventArgs e)
        {
            play(0, 8);
        }
        private void pb_Click74(object sender, System.EventArgs e)
        {
            play(1, 8);
        }
        private void pb_Click75(object sender, System.EventArgs e)
        {
            play(2, 8);
        }
        private void pb_Click76(object sender, System.EventArgs e)
        {
            play(3, 8);
        }
        private void pb_Click77(object sender, System.EventArgs e)
        {
            play(4, 8);
        }
        private void pb_Click78(object sender, System.EventArgs e)
        {
            play(5, 8);
        }
        private void pb_Click79(object sender, System.EventArgs e)
        {
            play(6, 8);
        }
        private void pb_Click80(object sender, System.EventArgs e)
        {
            play(7, 8);
        }
        private void pb_Click81(object sender, System.EventArgs e)
        {
            play(8, 8);
        }

        private void pb_Click82(object sender, System.EventArgs e)
        {
            play(0, 9);
        }
        private void pb_Click83(object sender, System.EventArgs e)
        {
            play(1, 9);
        }
        private void pb_Click84(object sender, System.EventArgs e)
        {
            play(2, 9);
        }
        private void pb_Click85(object sender, System.EventArgs e)
        {
            play(3, 9);
        }
        private void pb_Click86(object sender, System.EventArgs e)
        {
            play(4, 9);
        }
        private void pb_Click87(object sender, System.EventArgs e)
        {
            play(5, 9);
        }
        private void pb_Click88(object sender, System.EventArgs e)
        {
            play(6, 9);
        }
        private void pb_Click89(object sender, System.EventArgs e)
        {
            play(7, 9);
        }
        private void pb_Click90(object sender, System.EventArgs e)
        {
            play(8, 9);
        }
        private void pb_Click91(object sender, System.EventArgs e)
        {
            play(0, 10);
        }
        private void pb_Click92(object sender, System.EventArgs e)
        {
            play(1, 10);
        }
        private void pb_Click93(object sender, System.EventArgs e)
        {
            play(2, 10);
        }
        private void pb_Click94(object sender, System.EventArgs e)
        {
            play(3, 10);
        }
        private void pb_Click95(object sender, System.EventArgs e)
        {
            play(4, 10);
        }
        private void pb_Click96(object sender, System.EventArgs e)
        {
            play(5, 10);
        }
        private void pb_Click97(object sender, System.EventArgs e)
        {
            play(6, 10);
        }
        private void pb_Click98(object sender, System.EventArgs e)
        {
            play(7, 10);
        }
        private void pb_Click99(object sender, System.EventArgs e)
        {
            play(8, 10);
        }
        #endregion

        #region Xu ly su kien hover choot qua o ban co
        private void pb_MouseHover1(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 0], "");
        }

        private void pb_MouseHover2(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 0], "");
        }

        private void pb_MouseHover3(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 0], "");
        }

        private void pb_MouseHover4(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 0], "");
        }

        private void pb_MouseHover5(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 0], "");
        }

        private void pb_MouseHover6(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 0], "");
        }

        private void pb_MouseHover7(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 0], "");
        }

        private void pb_MouseHover8(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 0], "");
        }

        private void pb_MouseHover9(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 0);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 0], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 0], "");
        }

        private void pb_MouseHover10(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 1], "");
        }

        private void pb_MouseHover11(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 1], "");
        }

        private void pb_MouseHover12(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 1], "");
        }

        private void pb_MouseHover13(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 1], "");
        }

        private void pb_MouseHover14(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 1], "");
        }


        private void pb_MouseHover15(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 1], "");
        }

        private void pb_MouseHover16(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 1], "");
        }

        private void pb_MouseHover17(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 1], "");
        }

        private void pb_MouseHover18(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 1);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 1], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 1], "");
        }

        private void pb_MouseHover19(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 2], "");
        }

        private void pb_MouseHover20(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 2], "");
        }

        private void pb_MouseHover21(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 2], "");
        }


        private void pb_MouseHover22(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 2], "");
        }

        private void pb_MouseHover23(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 2], "");
        }

        private void pb_MouseHover24(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 2], "");
        }

        private void pb_MouseHover25(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 2], "");
        }

        private void pb_MouseHover26(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 2], "");
        }

        private void pb_MouseHover27(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 2);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 2], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 2], "");
        }

        private void pb_MouseHover28(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 3], "");
        }

        private void pb_MouseHover29(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 3], "");
        }


        private void pb_MouseHover30(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 3], "");
        }

        private void pb_MouseHover31(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 3], "");
        }

        private void pb_MouseHover32(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 3], "");
        }

        private void pb_MouseHover33(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 3], "");
        }

        private void pb_MouseHover34(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 3], "");
        }

        private void pb_MouseHover35(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 3], "");
        }

        private void pb_MouseHover36(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 3);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 3], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 3], "");
        }

        private void pb_MouseHover37(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 4], "");
        }


        private void pb_MouseHover38(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 4], "");
        }

        private void pb_MouseHover39(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 4], "");
        }

        private void pb_MouseHover40(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 4], "");
        }

        private void pb_MouseHover41(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 4], "");
        }

        private void pb_MouseHover42(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 4], "");
        }

        private void pb_MouseHover43(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 4], "");
        }

        private void pb_MouseHover44(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 4], "");
        }

        private void pb_MouseHover45(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 4);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 4], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 4], "");
        }


        private void pb_MouseHover46(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 5], "");
        }

        private void pb_MouseHover47(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 5], "");
        }

        private void pb_MouseHover48(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 5], "");
        }

        private void pb_MouseHover49(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 5], "");
        }

        private void pb_MouseHover50(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 5], "");
        }

        private void pb_MouseHover51(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 5], "");
        }

        private void pb_MouseHover52(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 5], "");
        }

        private void pb_MouseHover53(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 5], "");
        }


        private void pb_MouseHover54(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 5);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 5], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 5], "");
        }

        private void pb_MouseHover55(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 6], "");
        }

        private void pb_MouseHover56(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 6], "");
        }

        private void pb_MouseHover57(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 6], "");
        }

        private void pb_MouseHover58(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 6], "");
        }

        private void pb_MouseHover59(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 6], "");
        }

        private void pb_MouseHover60(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 6], "");
        }

        private void pb_MouseHover61(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 6], "");
        }

        private void pb_MouseHover62(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 6], "");
        }

        private void pb_MouseHover63(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 6);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 6], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 6], "");
        }

        private void pb_MouseHover64(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 7], "");
        }
        private void pb_MouseHover65(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 7], "");
        }
        private void pb_MouseHover66(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 7], "");
        }
        private void pb_MouseHover67(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 7], "");
        }
        private void pb_MouseHover68(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 7], "");
        }
        private void pb_MouseHover69(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 7], "");
        }

        private void pb_MouseHover70(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 7], "");
        }
        private void pb_MouseHover71(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 7], "");
        }
        private void pb_MouseHover72(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 7);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 7], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 7], "");
        }
        private void pb_MouseHover73(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 8], "");
        }
        private void pb_MouseHover74(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 8], "");
        }
        private void pb_MouseHover75(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 8], "");
        }
        private void pb_MouseHover76(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 8], "");
        }
        private void pb_MouseHover77(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 8], "");
        }
        private void pb_MouseHover78(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 8], "");
        }
        private void pb_MouseHover79(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 8], "");
        }
        private void pb_MouseHover80(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 8], "");
        }
        private void pb_MouseHover81(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 8);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 8], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 8], "");
        }

        private void pb_MouseHover82(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 9], "");
        }
        private void pb_MouseHover83(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 9], "");
        }
        private void pb_MouseHover84(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 9], "");
        }
        private void pb_MouseHover85(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 9], "");
        }
        private void pb_MouseHover86(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 9], "");
        }
        private void pb_MouseHover87(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 9], "");
        }
        private void pb_MouseHover88(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 9], "");
        }
        private void pb_MouseHover89(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 9], "");
        }
        private void pb_MouseHover90(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 9);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 9], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 9], "");
        }
        private void pb_MouseHover91(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(0, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[0, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[0, 10], "");
        }
        private void pb_MouseHover92(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(1, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[1, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[1, 10], "");
        }
        private void pb_MouseHover93(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(2, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[2, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[2, 10], "");
        }
        private void pb_MouseHover94(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(3, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[3, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[3, 10], "");
        }
        private void pb_MouseHover95(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(4, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[4, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[4, 10], "");
        }
        private void pb_MouseHover96(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(5, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[5, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[5, 10], "");
        }
        private void pb_MouseHover97(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(6, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[6, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[6, 10], "");
        }
        private void pb_MouseHover98(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(7, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[7, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[7, 10], "");
        }
        private void pb_MouseHover99(object sender, System.EventArgs e)
        {
            int temp = brd.getInfo(8, 10);
            if (temp != -1)
                this.toolTip.SetToolTip(this.pb[8, 10], (temp % 10).ToString());
            else
                this.toolTip.SetToolTip(this.pb[8, 10], "");
        }
        #endregion



        //Form load
        private void MChess_Load(object sender, EventArgs e)
        {
            init();
            init2();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 11; j++)
                    pb[i, j].Refresh();
            Set_Controls("Waiting");
        }




        #endregion


        private void vanMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chơi lại ván mới?", "Thông báo", System.Windows.Forms.MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Restart();

        }
        // bắt đầu
        private void batDauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            quanCoToolStripMenuItem.Enabled = false;
            doSauTimKiemToolStripMenuItem.Enabled = false;
            chonMauToolStripMenuItem.Enabled = false;
            vanMoiToolStripMenuItem.Enabled = true;
            ngungchoiToolStripMenuItem.Enabled = true;
            batDauToolStripMenuItem.Enabled = false;
            dauhangtoolStripMenuItem.Enabled = true;
            diemthoathuantoolStripMenuItem.Enabled = false;
            pointshow();
            if (lb[1] != null)
            lb[1].Text = diem_thoa_thuan.ToString();
            lb[2].Text = brd.diem(1).ToString();
            lb[3].Text = brd.diem(2).ToString();


            //quan do di truoc
            order = loaded_order;
            COM = new Searching(brd);
            Rnd = new Random();

            if (order == MAY)
                COM_THINK();
            Set_Controls("Playing");
            quaylaitoolStripMenuItem.Enabled = false;

        }
        // Ngừng chơi
        private void ngungchoiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Thoát
        private void thoatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Quay lại nước đi trước
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dem == 1) return;
            if (!undo)
                return;
            //lay ra nuoc di, tu (x1,y1) -> (x2,y2), capture = true neu co an quan, value chua gia tri quan an
            //thu hoi lai nuoc may di
            //cap nhat cho ban co Board
            brd.setSquare(brd.getInfo(may_di.x2, may_di.y2), may_di.x1, may_di.y1);
            if (may_di.capture)
                brd.setSquare(may_di.value, may_di.x2, may_di.y2);
            else
                brd.setSquare(-1, may_di.x2, may_di.y2);

            brd.setSquare(brd.getInfo(nguoi_di.x2, nguoi_di.y2), nguoi_di.x1, nguoi_di.y1);
            if (nguoi_di.capture)
                brd.setSquare(nguoi_di.value, nguoi_di.x2, nguoi_di.y2);
            else
                brd.setSquare(-1, nguoi_di.x2, nguoi_di.y2);

            Update_Image();
            //ORDER THUOC VE NGUOI CHOI
            order = NGUOI_CHOI;

            dem -= 2;
            //cap nhat bang danh sach nuoc di va diem
            //lbNuocdi.Items.RemoveAt(dem + 1);
            //lbNuocdi.Items.RemoveAt(dem);
            //lbNuocdi.Refresh();
            //if (dem > 0)
                //lbNuocdi.SetSelected(dem - 1, true);
            //xtDiem.Text = "Điểm:       Đỏ   " + brd.diem(2) + "   -   " + brd.diem(1) + "   Xanh";
            Set_Controls("Playing");
          //  pointshow();
            if (lb[1] != null)
            lb[1].Text = diem_thoa_thuan.ToString();
            lb[2].Text = brd.diem(1).ToString();
            lb[3].Text = brd.diem(2).ToString();
            quaylaitoolStripMenuItem.Enabled = undo = false;

        }
        // Chọn loại quân cờ
        private void chamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chuSoToolStripMenuItem.Checked = false;
            chamToolStripMenuItem.Checked = true;
            Image_Load(2);
        }

        private void chuSoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chamToolStripMenuItem.Checked = false;
            chuSoToolStripMenuItem.Checked = true;
            Image_Load(1);
        }
        // Chọn màu         
        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NGUOI_CHOI = 2;         //nguoi choi chon quan do, di truoc
            MAY = 1;
            doToolStripMenuItem.Checked = true;
            xanhToolStripMenuItem.Checked = false;
        }

        private void xanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NGUOI_CHOI = 1;
            MAY = 2;
            doToolStripMenuItem.Checked = false;
            xanhToolStripMenuItem.Checked = true;

        }

        private void Dokho1_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = true;
            Dokho2.Checked = false;
            Dokho3.Checked = false;
            Dokho4.Checked = false;
            Dokho5.Checked = false;
            Dokho6.Checked = false;
            MAX_PLY = 4;
            Quickeval = true;
            attack = true;
        }

        private void Dokho2_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = false;
            Dokho2.Checked = true;
            Dokho3.Checked = false;
            Dokho4.Checked = false;
            Dokho5.Checked = false;
            Dokho6.Checked = false;
            MAX_PLY = 3;
            Quickeval = false;
            attack = true;
        }

        private void Dokho3_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = false;
            Dokho2.Checked = false;
            Dokho3.Checked = true;
            Dokho4.Checked = false;
            Dokho5.Checked = false;
            Dokho6.Checked = false;
            MAX_PLY = 5;
            Quickeval = true;
            attack = true;
        }

        private void Dokho4_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = false;
            Dokho2.Checked = false;
            Dokho3.Checked = false;
            Dokho4.Checked = true;
            Dokho5.Checked = false;
            Dokho6.Checked = false;
            MAX_PLY = 4;
            Quickeval = false;
            attack = true;
        }

        private void Dokho5_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = false;
            Dokho2.Checked = false;
            Dokho3.Checked = false;
            Dokho4.Checked = false;
            Dokho5.Checked = true;
            Dokho6.Checked = false;
            MAX_PLY = 5;
            Quickeval = false;
            attack = false;
        }

        private void Dokho6_Click(object sender, EventArgs e)
        {
            Dokho1.Checked = false;
            Dokho2.Checked = false;
            Dokho3.Checked = false;
            Dokho4.Checked = false;
            Dokho5.Checked = false;
            Dokho6.Checked = true;
            MAX_PLY = 5;
            Quickeval = false;
            attack = true;
        }
        //dau hang!

        private void dauhangtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = 0;
            MessageBox.Show("Bạn đã đầu hàng!", "Thông báo");
            Set_Controls("Resigned");
        }

        private void khongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 1000;
            khongToolStripMenuItem.Checked = true;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;

        }

        private void muoitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 10;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = true;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void muoinamtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 15;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = true;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void haimuoitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 20;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = true;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void hainhamtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 25;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = true;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void bamuoitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 30;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = true;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void banhamtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 35;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = true;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void bonmuoitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 40;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = true;
            bonnhamtoolStripMenuItem.Checked = false;
        }

        private void bonnhamtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            diem_thoa_thuan = 45;
            khongToolStripMenuItem.Checked = false;
            muoitoolStripMenuItem.Checked = false;
            muoinamtoolStripMenuItem.Checked = false;
            haimuoitoolStripMenuItem.Checked = false;
            hainhamtoolStripMenuItem.Checked = false;
            bamuoitoolStripMenuItem.Checked = false;
            banhamtoolStripMenuItem.Checked = false;
            bonmuoitoolStripMenuItem.Checked = false;
            bonnhamtoolStripMenuItem.Checked = true;
        }

        private void ngungchoiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Ngừng chơi và tính điểm hai bên
            order = 0;
            Set_Controls("Ended");
            //tao label moi in ket qua

            //thong bao
            switch (brd.tinh_diem())
            {
                case 0:
                    MessageBox.Show("Hai bên hòa cờ", "Thông báo");
                    return;
                case 1:
                    if (NGUOI_CHOI == 1)
                        MessageBox.Show("Bạn(quân xanh) là người chiến thắng!", "Thông báo");
                    else
                        MessageBox.Show("Bạn(quân đỏ) thua rồi!", "Thông báo");
                    return;
                case 2:
                    if (NGUOI_CHOI == 2)
                        MessageBox.Show("Bạn(quân đỏ) là người chiến thắng!", "Thông báo");
                    else
                        MessageBox.Show("Bạn(quân xanh) thua rồi!", "Thông báo");
                    return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




















    }
}



/*******************************************************************************/
////////////*************           NOTES             ****************//////////
/*******************************************************************************/
/* GHI CHÚ
 *
 * Board: Lơp luu tru ban co, cu the la gia tri cac o co, trong mot mang 2
 * chieu o cac o cua mang, gia tri 0 - 9 tuong ung voi cac qưan co 0-9 mau xanh
 * gia tri 10-19 tuong ung voi cac quan co 0-9 mau do
 * gia tri -1 cho cac vi tri trong
 * Phuong thuc GetInfo(i,j) tra lai gia tri phan tu [i,j]
 * Phuong thuc SetSquare(value,i,j) thiet lap gia tri value cho o [i,j]
 * Phuong thuc GetColor(i,j) tra lai mau cua quan o o [i,j] (neu co)
 * 1 neu la quan xanh, 2 cho quan do, 0 neu khong co quan nao
 * 
 * IPiece: giao dien cai dat cho cac doi tuong quan co, thi hanh 2 phuong thuc 
 * moveable(brd,i,j) va capture(brd,i,j) tra lai gia tri boolean the hien kha nang 
 * di chuyen den o i,j hoac an quan doi phuong o o i,j tren ban co brd
 * 
 * *Piece: lop cha cho cac quan co, cac bien thanh phan:
 *      color: mau quan co  (1-xanh, 2-do)
 *      value: gia tri quan co (0-9)
 *      x,y: toa do quan co (x:0-8, y:0-10)
 *      
 * *quan0: class (inherits Piece, implements IPiece) dai dien cho quan so 0
 *      moveable() = capture() = false;
 *      value = 0 ;
 *      
 * *quan19: class dai dien cho cac quan co 1-9
 *  
 * Point: Lop diem, 2 bien thanh phan x,y chi toa do, ho tro mot so thao tac voi 
 * cac diem(o) tren ban co
 * 
 * Searching: Lop quan trong nhat, thuc hien tim kiem nuoc di cho may
 * Bien thanh phan brd chi ban co hien tai, next_move (kieu struct Move) se luu 
 * nuoc di tiep theo
 * Cac phuong thuc:
 *      Evaluate(color): Danh gia the co tu phia quan co mau color
 *      MakeMove(): thuc hien mot nuoc di thu, lam bien doi brd
 *      UnMakeMove(): bo thuc hien nuoc di thu, khoi phuc brd
 *      alpha_beta(): tim kiem nuoc di, luu vao next_move
 *      negascout(): tim kiem nuoc di, luu vao next_move
 *      MTDF(): tim kiem nuoc di, luu vao next_move
 * 
 * 
 * ___________________________________________________________________________________________
 * 
 * _________10-04-09
 *  
 * 1. Thiet ke lai OOP: Tach cac class rieng re, Searching la mot Composition class
 * Neu can viet lai Searching thanh mot abstract class; AlphaBeta, NegaScout, MTDF se la dan xuat
 * Mot instance Searching se gom cac doi tuong thanh phan:
 *      Board brd                           //ban co hien tai, duoc update o MChess (COM.updateboard(brd))
 *      Evaluator Eval                      //object dung de danh gia the co
 *      TranspositionTable TransTable       //bang Hash
 *      HistoryTable   HisTable             //Bang lich su danh gia diem nuoc di, de sap xep ds nuoc di
 *      Move    next_move                   //nuoc di tiep theo tim duoc
 *      int counter                         //dem so lan gap nut la
 *      int TTHitsCount                     //so lan tim thay brd trong Transposition Table
 *      int QuiescenceNodes                 //so nut xet them khi Quiescence (ke ca nut la)
 *    
 * Thiet ke lop Player(nguoi choi), lop Game(van dau), cho phep danh HUMAN vs.HUMAN, COM vs.COM va tao 
 * van dau moi khong can restart application
 *      
 *       
 * 2. KEYS:
 *      
 *      Ham luong gia (Evaluation) tot:
 *                          Material Balance    (tuong quan luc luong)
 *                          Mobility            (tinh linh dong)
 *                          Space               (khong gian, Board control)
 *                          0 Safety            (do an toan cua quan 0)
 *                          Threats             (de doa)  
 *                          Development         (kha nang phat trien)
 *                          ... (?)
 *                          ...
 *                      AND RIGHT WEIGHTS  (trong so cho cac yeu to -> ham luong gia tuyen tinh)
 *                      Luu y: Thuc hien danh gia cho ca 2 ben, lay tong ben minh - tong ben doi phuong
 *                      
 *      Giai thuat tim kiem nuoc di va dac biet quan trong, SAP XEP DANH SACH NUOC DI (Ordering Moves),
 *          , Increasing, Decrescent, Selective Generation
 *          , Evaluate, Transposition, Killer Heuristic, History Heuristic
 *          
 *      Khu horizon effect voi Quiescence, Secondary search
 *      
 *      Thuc hien Iterative Deepening, thiet ke Transposition Table ho tro AlphaBeta.
 *      
 *      Do sau tim kiem 
 *          (co toan: do re nhanh ~ 90, MAX_PLY kho co the the vuot qua 5, muc 4 co 90^4 ~ 65 trieu nut la)
 *          (chap nhan duoc neu so nut phai Evaluate() khong qua 10.000.000 trong hau het truong hop) 
 *          (Test: voi 5.712.475 nut la phai luong gia o do sau 4 - thoi gian tim kiem la 28 giay)
 *          
 *          
 *      Thu vien nuoc di (khai cuoc, tan cuoc, mot so nuoc di dac biet), tim trong thu vien truoc
 *      
 * 
 * ____________________________________________________________________________________________________
 * 
 *      Updated: 12-04-09   (10:00 PM)
 *      
 *          - Cai dat Transposition Table   (alphabeta2, negascout2)
 *              + Su dung PP Zobrist de tinh Hash Key va Hash Lock
 *              + Cat nhanh duoc nhieu (thong so Transposition Table Hits)
 *              + Van de: Tinh toan qua cham ---> cham hon phien ban khong dung TT
 *              
 *          - Cai dat History Table     (updated alphabeta, negascout)
 *              + Luu lai cac nuoc di da gay cat nhanh, moi lan nhu vay tang diem cho nuoc di
 *              + Cai thien dang ke toc do tinh toan, dac biet trong cac truong hop bi tan cong
 *              + CO THE NANG DO SAU LEN 5, 6  
 * 
 *      Next: 
 *           - Cai dat Quiescence (tim kiem do sau tinh), nang cap ham Heuristic Evaluate, 
 *           - Xem lai cai dat Transposition Table (chay qua cham du TT Hits rat nhieu lan)
 *              (co the vi tinh toan HashKey va HashLock)
 *           - Bo sung tinh nang, giao dien
 *           - Kiem tra lai code: 
 *                  + Nhung phuong thuc can duyet Board thi nen tich hop tinh nang do
 *                    vao class Board, giam so lan phai goi getInfo, getColor tu ngoai class Board
 *                  
 *                  + Cac phuong thuc duyet nuoc di, nuoc an, MakeMove, UnMakeMove
 *                  
 *              
 *      Updated: 13-04-09   (12:11 PM)
 *      
 *          - Cai dat Quiescence Searching
 *              + Khong gioi han do sau!
 *              + Chi xet nhanh an quan (capture)---> ngung de quy khi den mot vi tri khong co nhanh an quan 
 *              + Khong su dung Transposition Table
 *              + Khong can sap xep nuoc di(vi it), nhung van tang diem cho nuoc di vao History Table
 *              + Chua co Null Move Pruning
 *              + Gan Quiescence vao alphabeta va negascout (da co His. Table)
 *              + BUGS: NHỚ LẬT BIẾN ALPHA, BETA tại mỗi lời gọi đệ quy
 *         
 *          - Dat lai default MAX_PLY = 5
 *              + Moi nuoc di mat khoang 5-7 giay (gan 1.000.000 nut la) - hoi cham
 *              + Nuoc di lau hon mat khoang 20-30 giay (Negascout with History Table, no TT)
 *              
 *      Next: EVALUATING POSITION
 *              + Quan trong nhat: Material Balance
 *      
 *      
 * 
 *      BUGS:
 *              + Loi Material Balance (đa sua)
 *              + Loi Quiescene        (da sua)
 *              + Loi Negascout        (chua sua)
 *              
 *      Hien tai:
 *              + Alpha_Beta voi History Table, Quiescene
 *              + Alpha_Beta2 voi History Table, Transposition Table, Quiescene2         
 * 
 *      Updated: 15-04
 *          
 *          - Thu nghiem Evaluate:
 *                  + Board Control
 *                  + Ready
 *                  + Attack
 *                  + 0 - Safety
 *              Danh thang phien ban cu o cung do sau 4        
 *          
 * 
 *                                                               ____________________________________DHK
 */
