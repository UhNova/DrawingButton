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

        public Point Middle
        {
            get
            {
                return new Point(
                    (Start.Y + End.Y) / 2,
                    (Start.X + End.X) / 2
                    );
            }
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
        private static double FindDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        /// <summary>
        ///     ����� ��������� ����� ��������������
        /// </summary>
        /// <param name="targetPoint">������� �����</param>
        /// <returns></returns>
        public Point FindClosestPoint(Point targetPoint)
        {
            //������� ����������� ���� �������� � ������� ������������� ���������� � �������� ������
            // ��� �������������� ������� ����� �������: ����� �������� ������ ����� ���. 
            // ���� ���������� ����� � �������� ������ ������� - ����� ���� �� ���.
            Point middleLeft = new Point(Start.X, Middle.Y);
            Point middleTop = new Point(Middle.X, Start.Y);
            Point middleRight = new Point(End.X, Middle.Y);
            Point middleBottom = new Point(Middle.X, End.Y);

            Point[] points = {
                middleLeft,
                middleRight,
                middleTop,
                middleBottom
            };

            var distances = new[]
            {
                FindDistance(middleLeft, targetPoint),
                FindDistance(middleRight, targetPoint),
                FindDistance(middleTop, targetPoint),
                FindDistance(middleBottom, targetPoint)
            };

            var neededDistance = distances.Min();

            int pointIndex = distances.ToList().IndexOf(neededDistance);

            return points[pointIndex];
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