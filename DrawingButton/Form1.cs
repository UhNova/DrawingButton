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
        private Bitmap _mbit;
        private DrawTool _drawTool;
        private int start_x = 0, start_y = 0;

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
                _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
                pb_drawing.Image = _mbit;
                pb_drawing.Visible = true;
                pb_drawing.Enabled = true;
                btn_start.Text = "Закончить!";
                _drawTool = new DrawTool(_mbit);
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
                pb_drawing.Refresh();
                
                int end_x = getEnd(e).X;
                int end_y = getEnd(e).Y;

                _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
                _drawTool.Canvas = _mbit;
                _drawTool.InsertOrUpdate(new Point { X = start_x, Y = start_y }, new Point { X = end_x, Y = end_y }, FigureType.Block);
                _drawTool.DrawAll();
                pb_drawing.Image = _mbit;
            }
        }

        private void pb_drawing_MouseUp(object sender, MouseEventArgs e)
        {
            pb_drawing.Refresh();

            int end_x = getEnd(e).X;
            int end_y = getEnd(e).Y;

            _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
            _drawTool.Canvas = _mbit;
            _drawTool.InsertOrUpdate(new Point { X = start_x, Y = start_y }, new Point { X = end_x, Y = end_y }, FigureType.Block);
            _drawTool.DrawAll();
            pb_drawing.Image = _mbit;
        }
    }
}
