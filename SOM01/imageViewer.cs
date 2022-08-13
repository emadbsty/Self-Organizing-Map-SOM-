using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM01
{
    public partial class imageViewer : UserControl
    {
        public imageViewer()
        {
            InitializeComponent();
        }
        Graphics g;
        System.Drawing.SolidBrush b1 = new SolidBrush(Color.White);
        System.Drawing.SolidBrush b2 = new SolidBrush(Color.Black);

        struct Matrix
        {
            public int w, h;
            public Rectangle[] recf;
            public void generate(int H,int W,int bw,int bh)
            {
                this.w = W;
                this.h = H;
                this.recf = new Rectangle[this.w * this.h];
                int k = 0;
                for (int i = 0; i < this.w; i++)
                {
                    for (int j = 0; j < this.h; j++)
                    {
                        this.recf[k] = new Rectangle();
                        this.recf[k].Location = new System.Drawing.Point
                            (i * bw + 3, j * bh + 3);
                        this.recf[k].Size = new System.Drawing.Size(bw, bh);
                        k++;
                    }
                }
            }
        }
        Matrix m;
        private Panel panel1;
        int[,] image;
        public void inti(int[,] Image,int H, int W,int bw,int bh)
        {
            m.generate(H, W, bw, bh);
            image = Image;
            g = panel1.CreateGraphics(); this.DoubleBuffered = true;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    b1 = new SolidBrush(Color.FromArgb(image[i, j], image[i, j], image[i, j]));
                    g.FillRectangle(b1, m.recf[i + m.h * j]);
                    g.DrawRectangle(new Pen(b2.Color, 0.1f), m.recf[i + m.h * j]);
                }
            }
            this.Paint += new PaintEventHandler(UserControl1_Paint);
        }

        private void imageViewer_Load(object sender, EventArgs e)
        {
           
        }
        private void UserControl1_Paint(object o, PaintEventArgs e)
        {
            //panel1.Width = m.w * 10 + 10;
            //panel1.Height = m.h * 10 + 10;
            //this.Width = m.w * 10 + 10;
            //this.Height = m.w * 10 + 10;
            for (int i = 0; i < m.h; i++)
            {
                for (int j = 0; j < m.w; j++)
                {
                        b1 = new SolidBrush(Color.FromArgb(image[i,j],image[i,j],image[i,j]));
                        g.FillRectangle(b1, m.recf[i + m.h * j]);
                        g.DrawRectangle(new Pen(b2.Color, 0.1f), m.recf[i + m.h * j]);                   
                }
            }         
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 375);
            this.panel1.TabIndex = 0;
            // 
            // imageViewer
            // 
            this.Controls.Add(this.panel1);
            this.Name = "imageViewer";
            this.Size = new System.Drawing.Size(380, 380);
            this.Load += new System.EventHandler(this.imageViewer_Load_1);
            this.ResumeLayout(false);

        }

        private void imageViewer_Load_1(object sender, EventArgs e)
        {

        }
    }
}
