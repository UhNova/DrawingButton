﻿using System;
using System.Drawing;

namespace DrawingButton.Classes
{
    abstract class AbstractBlock : FigureInterface
    {
        protected Point _start = new Point(0, 0);
        protected Point _end = new Point(0, 0);
        protected int _width;
        protected int _height;
        protected Pen _pen;

        public delegate void MovingOrResizing(Point start, Point end);
        public event MovingOrResizing OnMoveOrResize;

        protected void RaiseMoveOrResizeEvent(Point start, Point end)
        {
            if (OnMoveOrResize != null) OnMoveOrResize(start, end);
        }

        public Point InitialStart
        {
            get { return _start; }
        }

        public Point InitialEnd
        {
            get { return _end; }
        }

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

        public int Width
        {
            get { return (Math.Abs(_start.X - _end.X)); }
            set { _width = value; }
        }

        public int Height
        {
            get { return (Math.Abs(_start.Y - _end.Y)); }
            set { _height = value; }
        }

        public abstract void DrawFigure(Bitmap target);
        public abstract void MoveOrResize(Point start, Point end);
    }
}
