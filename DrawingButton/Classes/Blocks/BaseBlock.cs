using System;
using System.Drawing;

namespace DrawingButton.Classes.Blocks
{
    internal abstract class BaseBlock : FigureInterface
    {
        /// <summary>
        ///     ������� ��� ����������� �����������
        /// </summary>
        /// <param name="start">��������� ���������</param>
        /// <param name="end">�������� ���������</param>
        public delegate void MovingOrResizing(Point start, Point end);

        protected Point _end = new Point(0, 0);
        protected int _height;
        protected Pen _pen;
        protected Point _start = new Point(0, 0);
        protected int _width;

        /// <summary>
        ///     �������� ��������� �����
        /// </summary>
        public Point InitialStart
        {
            get { return _start; }
        }

        /// <summary>
        ///     �������� �������� �����
        /// </summary>
        public Point InitialEnd
        {
            get { return _end; }
        }

        /// <summary>
        ///     ��������� ���������
        /// </summary>
        public Point Start
        {
            get
            {
                return (new Point
                {
                    X = (_start.X < _end.X) ? _start.X : _end.X,
                    Y = (_start.Y < _end.Y) ? _start.Y : _end.Y
                });
            }
            set { _start = value; }
        }

        /// <summary>
        ///     �������� ���������
        /// </summary>
        public Point End
        {
            get
            {
                return (new Point
                {
                    X = (_start.X > _end.X) ? _start.X : _end.X,
                    Y = (_start.Y > _end.Y) ? _start.Y : _end.Y
                });
            }
            set { _end = value; }
        }

        /// <summary>
        ///     ������ �����
        /// </summary>
        public int Width
        {
            get { return (Math.Abs(_start.X - _end.X)); }
            set { _width = value; }
        }

        /// <summary>
        ///     ������ �����
        /// </summary>
        public int Height
        {
            get { return (Math.Abs(_start.Y - _end.Y)); }
            set { _height = value; }
        }

        /// <summary>
        ///     ����������� �����
        /// </summary>
        /// <param name="start">��������� ���������</param>
        /// <param name="end">�������� ���������</param>
        public void MoveStart(Point start, Point end)
        {
            RaiseMoveOrResizeEvent(start, end);
        }

        /// <summary>
        ///     ��������� �����
        /// </summary>
        /// <param name="target">������� ��� ���������</param>
        public void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            var targetRectangle = new Rectangle
            {
                Location = Start,
                Height = Height,
                Width = Width
            };

            graph.DrawRectangle(_pen, targetRectangle);
            graph.FillRectangle(new SolidBrush(Color.White), targetRectangle);
        }

        /// <summary>
        ///     ������� �����������
        /// </summary>
        public event MovingOrResizing OnMoveOrResize;

        /// <summary>
        ///     ����� ������ ������� �����������
        /// </summary>
        /// <param name="start">��������� ���������</param>
        /// <param name="end">�������� ���������</param>
        protected void RaiseMoveOrResizeEvent(Point start, Point end)
        {
            if (OnMoveOrResize != null) OnMoveOrResize(start, end);
        }
    }
}