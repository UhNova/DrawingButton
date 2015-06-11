using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DrawingButton.Classes;
using DrawingButton.Classes.Enums;

namespace DrawingButton
{
    public partial class DrawingButton : Form
    {
        private readonly List<ArrowType> _arrowTypes = new List<ArrowType> {ArrowType.Inheritance, ArrowType.Dependency};
        private readonly List<BlockType> _blockTypes = new List<BlockType> {BlockType.Interface, BlockType.Class};
        private DrawTool _drawTool;
        private Bitmap _mbit;
        private int _startX, _startY;

        public DrawingButton()
        {
            InitializeComponent();
            pb_drawing.Width = (Width*9/10);
            pb_drawing.Height = (Height*5/8);
            pb_drawing.Location = new Point(Width/20, Height/4);
            cmbType.DataSource = _blockTypes.ToArray();
            CanvasInit();
        }

        private void CanvasInit()
        {
            _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
            pb_drawing.Image = _mbit;
            _drawTool = new DrawTool(_mbit);
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

        private void pb_drawing_MouseDown(object sender, MouseEventArgs e)
        {
            _startX = e.X;
            _startY = e.Y;
        }

        private void pb_drawing_MouseMove(object sender, MouseEventArgs e)
        {
            var possibleCapture = _drawTool.CheckCapture(e.Location);

            switch (possibleCapture)
            {
                case CaptureType.None:
                    Cursor = Cursors.Default;
                    break;
                case CaptureType.Drag:
                    Cursor = Cursors.Cross;
                    break;
                case CaptureType.ResizeHorizontal:
                    Cursor = Cursors.SizeWE;
                    break;
                case CaptureType.ResizeVertical:
                    Cursor = Cursors.SizeNS;
                    break;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            pb_drawing.Refresh();

            var end_x = getEnd(e).X;
            var end_y = getEnd(e).Y;

            _mbit = new Bitmap(pb_drawing.Width, pb_drawing.Height);
            _drawTool.Canvas = _mbit;
            _drawTool.InsertOrUpdate(new Point {X = _startX, Y = _startY}, new Point {X = end_x, Y = end_y},
                rbBlock.Checked, 
                // int надо преобразовать в enum
                (int) cmbType.SelectedItem);
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
            _drawTool.InsertOrUpdate(new Point {X = _startX, Y = _startY}, new Point {X = end_x, Y = end_y},
                rbBlock.Checked, (int) cmbType.SelectedItem);
            _drawTool.DrawAll();
            _drawTool.FreeCapture();
            pb_drawing.Image = _mbit;
        }

        private void rbArrow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                cmbType.DataSource = _arrowTypes;
            }
            else
            {
                cmbType.DataSource = _blockTypes;
            }
        }

        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            CanvasInit();
        }
    }
}