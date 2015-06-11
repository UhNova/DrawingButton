using System;
using System.Drawing;
using System.Linq;

namespace DrawingButton.Classes.Blocks
{
    public class BaseBlock : AbstractFigure
    {
        /// <summary>
        ///     ������� ��� ����������� �����������
        /// </summary>
        /// <param name="start">��������� ���������</param>
        /// <param name="end">�������� ���������</param>
        public delegate void MovingOrResizing(Point start, Point end);

        protected int _height;
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
        public override void MoveStart(Point start, Point end)
        {
            RaiseMoveOrResizeEvent(start, end);
        }

        /// <summary>
        ///     ��������� �����
        /// </summary>
        /// <param name="target">������� ��� ���������</param>
        public override void DrawFigure(Bitmap target)
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

        /// <summary>
        ///     ����� ��������� ����� ����� �������
        /// </summary>
        /// <param name="x">��������� X</param>
        /// <param name="y">��������� Y</param>
        /// <param name="b">�������� �����</param>
        /// <returns></returns>
        protected double FindDistance(double x, double y, Point b)
        {
            return Math.Sqrt(Math.Pow(x - b.X, 2) + Math.Pow(y - b.Y, 2));
        }

        /// <summary>
        ///     ����� ��������� ����� ��������������
        /// </summary>
        /// <param name="targetPoint">������� �����</param>
        /// <returns></returns>
        public Point FindClosestPoint(Point targetPoint)
        {
            var Distances = new[]
            {
                FindDistance(Start.X, ((double) Start.Y + End.Y)/2, targetPoint),
                FindDistance(((double) Start.X + End.X)/2, Start.Y, targetPoint),
                FindDistance(End.X, ((double) Start.Y + End.Y)/2, targetPoint),
                FindDistance(((double) Start.X + End.X)/2, End.Y, targetPoint)
            };

            var neededDistance = Distances.Min();

            int pointType = Distances.ToList().IndexOf(neededDistance);
            switch (pointType)
            {
                case 0:
                    return new Point(Start.X, (Start.Y + End.Y) / 2);
                case 1:
                    return new Point((Start.X + End.X) / 2, Start.Y);
                case 2:
                    return new Point(End.X, (Start.Y + End.Y) / 2);
                case 3:
                    return new Point((Start.X + End.X) / 2, End.Y);
            }
            
            return new Point(-1, -1);
        }

        /// <summary>
        /// �������� ���������� ����� � �����
        /// </summary>
        /// <param name="target">������� �����</param>
        /// <returns></returns>
        public bool CheckInnerPoint(Point target)
        {
            return ((target.X >= _start.X) && (target.X <= _end.X)) &&
                   ((target.Y >= _start.Y) && (target.Y <= _end.Y));
        }
    }
}