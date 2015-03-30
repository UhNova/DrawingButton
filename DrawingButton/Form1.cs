using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DrawingButton.Properties;

namespace DrawingButton
{
    public partial class DrawingButton : Form
    {
        private Bitmap _mbit;
        private DrawTool _drawTool;
        private int start_x, start_y;
        private readonly List<BlockType> _blockTypes = new List<BlockType> { BlockType.Interface, BlockType.Class };
        private readonly List<ArrowType> _arrowTypes = new List<ArrowType> { ArrowType.Inheritance, ArrowType.Dependency };

        private FigureType _checkedFigureType
        {
            get
            {
                return ((rbBlock.Checked) ? FigureType.Block : FigureType.Relation);
            }
        }

        public DrawingButton()
        {
            InitializeComponent();
            pb_drawing.Visible = false;
            pb_drawing.Enabled = false;
            pb_drawing.Width = (Width * 9 / 10);
            pb_drawing.Height = (Height * 5 / 8);
            pb_drawing.Location = new Point(Width / 20, Height / 4);
            cmbType.DataSource = _blockTypes.ToArray();
        }

        public Point getEnd(MouseEventArgs e)
        {
            var Result = new Point();
            int end_x, end_y;

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
                btn_start.Text = Resources.DrawingButton_btn_start_Click_Draw;
            }
            else
            {
                _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
                pb_drawing.Image = _mbit;
                pb_drawing.Visible = true;
                pb_drawing.Enabled = true;
                btn_start.Text = Resources.DrawingButton_btn_start_Click_EndDraw;
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
            if (e.Button != MouseButtons.Left) return;
            pb_drawing.Refresh();
                
            var end_x = getEnd(e).X;
            var end_y = getEnd(e).Y;

            _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
            _drawTool.Canvas = _mbit;
            _drawTool.InsertOrUpdate(new Point { X = start_x, Y = start_y }, new Point { X = end_x, Y = end_y }, _checkedFigureType);
            _drawTool.DrawAll();
            pb_drawing.Image = _mbit;
        }

        private void pb_drawing_MouseUp(object sender, MouseEventArgs e)
        {
            pb_drawing.Refresh();

            var end_x = getEnd(e).X;
            var end_y = getEnd(e).Y;

            _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
            _drawTool.Canvas = _mbit;
            _drawTool.InsertOrUpdate(new Point { X = start_x, Y = start_y }, new Point { X = end_x, Y = end_y }, _checkedFigureType);
            _drawTool.DrawAll();
            _drawTool.FreeCapture();
            pb_drawing.Image = _mbit;
        }

        private void rbArrow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                cmbType.DataSource = _arrowTypes;
            }
            else
            {
                cmbType.DataSource = _blockTypes;
            }
        }
    }
}
