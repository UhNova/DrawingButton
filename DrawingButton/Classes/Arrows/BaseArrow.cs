using System.Drawing;

namespace DrawingButton.Classes.Arrows
{
    class BaseArrow : FigureInterface
    {
        protected Point _start = new Point(0, 0);
        protected Point _end = new Point(0, 0);
        protected Pen _pen;

        public Point Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public Point End
        {
            get { return _end; }
            set { _end = value; }
        }

        public void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            graph.DrawLine(_pen, _start, _end);
        }

        public void MoveStart(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _start.X += xOffset;
            _start.Y += yOffset;
        }

        public void MoveEnd(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _end.X += xOffset;
            _end.Y += yOffset;
        }
    }
}
