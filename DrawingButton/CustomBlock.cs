using System;
using System.Drawing;

namespace DrawingButton
{
    class CustomBlock : AbstractFigure
    {
        private BlockType _type;
        private Pen _pen;

        public BlockType BlockType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public Point RealStart
        {
            get
            {
                return (new Point
                {
                    X = (_start.X < _end.X) ? _start.X : _end.X,
                    Y = (_start.Y < _end.Y) ? _start.Y : _end.Y
                });
            }
        }

        public Point RealEnd
        {
            get
            {
                return (new Point
                {
                    X = (_start.X > _end.X) ? _start.X : _end.X,
                    Y = (_start.Y > _end.Y) ? _start.Y : _end.Y
                });
            }
        }

        public int Height
        {
            get { return (Math.Abs(_start.Y - _end.Y)); }
        }

        public int Width
        {
            get { return (Math.Abs(_start.X - _end.X)); }
        }

        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            var targetRectangle = new Rectangle();

            switch (_type)
            {
                case BlockType.Class:
                    _pen = new Pen(Color.Red, 1);

                    targetRectangle.Location = RealStart;
                    targetRectangle.Height = Height;
                    targetRectangle.Width = Width;
                    break;
            }
            graph.DrawRectangle(_pen, targetRectangle);
        }

        public override void MoveOrResize(Point start, Point end)
        {

        }
    }
}
