using System.Drawing;

namespace DrawingButton.Classes
{
    abstract class AbstractArrow : FigureInterface
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

        public abstract void DrawFigure(Bitmap target);
        public abstract void MoveOrResize(Point start, Point end);
    }
}
