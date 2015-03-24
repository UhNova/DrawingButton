using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingButton
{
    public partial class DrawingButton : Form
    {
        private Bitmap mbit, mbit_temp;
        private Graphics graph;
        private int start_x = 0, start_y = 0;
        Pen pen;
        Rectangle rect;

        public DrawingButton()
        {
            InitializeComponent();
            pb_drawing.Visible = false;
            pb_drawing.Enabled = false;
            pb_drawing.Width = (this.Width * 9 / 10);
            pb_drawing.Height = (this.Height * 5 / 8);
            pb_drawing.Location = new Point(this.Width / 20, this.Height / 4);
        }

        public Point getEnd(MouseEventArgs e)
        {
            Point Result = new Point();
            int end_x;
            int end_y;

            if ((e.X >= 0) && (e.X <= pb_drawing.Size.Width - 3))
            {
                end_x = e.X;
            }
            else
            {
                end_x = (e.X < 0) ? 0 : pb_drawing.Size.Width - 3;
            }

            if ((e.Y >= 0) && (e.Y <= pb_drawing.Size.Height - 3))
            {
                end_y = e.Y;
            }
            else
            {
                end_y = (e.Y < 0) ? 0 : pb_drawing.Size.Height - 3;
            }

            Result.X = end_x;
            Result.Y = end_y;
            return Result;
        }

        public bool mouseIn(MouseEventArgs e)
        {
            return (!((e.X < 0) || (e.Y < 0) || (e.X > pb_drawing.Size.Width - 3) || (e.Y > pb_drawing.Size.Height - 3)));
        }

        public void drawSome(int start_x, int start_y, int width, int height, int border, Bitmap canvas)
        {
            graph = Graphics.FromImage(canvas);
            pen = new Pen(Color.Blue, border);
            graph.DrawRectangle(pen, start_x, start_y, width, height);
            pb_drawing.Image = canvas;
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            if (pb_drawing.Enabled)
            {
                pb_drawing.Visible = false;
                pb_drawing.Enabled = false;
                btn_start.Text = "Рисовать!";
            }
            else
            {
                mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
                pb_drawing.Image = mbit;
                pb_drawing.Visible = true;
                pb_drawing.Enabled = true;
                btn_start.Text = "Закончить!";
            }
        }

        private void pb_drawing_MouseDown(object sender, MouseEventArgs e)
        {
            start_x = e.X;
            start_y = e.Y;
        }

        private void pb_drawing_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int real_x, real_y;
                real_x = (start_x <= e.X) ? start_x : e.X;
                real_y = (start_y <= e.Y) ? start_y : e.Y;
                mbit_temp = new Bitmap(mbit);
                if (mouseIn(e))
                {
                    int gWidth = Math.Abs(e.X - start_x);
                    int gHeight = Math.Abs(e.Y - start_y);

                    if (gWidth == 0) { gWidth = 1; }
                    if (gHeight == 0) { gHeight = 1; }

                    int border = 3;

                    if ((gWidth < 3))
                    {
                        border = 2;
                    }
                    if ((gWidth < 2))
                    {
                        border = 1;
                    }

                    drawSome(real_x, real_y, gWidth, gHeight, border, mbit_temp);
                }
                else
                {
                    int end_x = getEnd(e).X;
                    int end_y = getEnd(e).Y;

                    real_x = (start_x <= end_x) ? start_x : end_x;
                    real_y = (start_y <= end_y) ? start_y : end_y;

                    int gWidth = Math.Abs(end_x - start_x);
                    int gHeight = Math.Abs(end_y - start_y);

                    if (gWidth == 0) { gWidth = 1; }
                    if (gHeight == 0) { gHeight = 1; }

                    int border = 3;

                    if ((gWidth < 3))
                    {
                        border = 2;
                    }
                    if ((gWidth < 2))
                    {
                        border = 1;
                    }

                    drawSome(real_x, real_y, gWidth, gHeight, border, mbit_temp);
                }
            }
        }

        private void pb_drawing_MouseUp(object sender, MouseEventArgs e)
        {
            int real_x, real_y;
            real_x = (start_x <= e.X) ? start_x : e.X;
            real_y = (start_y <= e.Y) ? start_y : e.Y;
            if (mouseIn(e))
            {
                int gWidth = Math.Abs(e.X - start_x);
                int gHeight = Math.Abs(e.Y - start_y);

                if (gWidth == 0) { gWidth = 1; }
                if (gHeight == 0) { gHeight = 1; }

                int border = 3;

                if ((gWidth < 3))
                {
                    border = 2;
                }
                if ((gWidth < 2))
                {
                    border = 1;
                }

                drawSome(real_x, real_y, gWidth, gHeight, border, mbit);
            }
            else
            {
                int end_x = getEnd(e).X;
                int end_y = getEnd(e).Y;

                real_x = (start_x <= end_x) ? start_x : end_x;
                real_y = (start_y <= end_y) ? start_y : end_y;

                int gWidth = Math.Abs(end_x - start_x);
                int gHeight = Math.Abs(end_y - start_y);

                if (gWidth == 0) { gWidth = 1; }
                if (gHeight == 0) { gHeight = 1; }

                int border = 3;

                if ((gWidth < 3))
                {
                    border = 2;
                }
                if ((gWidth < 2))
                {
                    border = 1;
                }

                drawSome(real_x, real_y, gWidth, gHeight, border, mbit);
            }
        }
    }
}
