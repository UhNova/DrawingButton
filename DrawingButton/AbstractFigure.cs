using System.Drawing;

namespace DrawingButton
{
    abstract class AbstractFigure
    {
        protected Point _start = new Point(0, 0);
        protected Point _end = new Point(0, 0);
        protected FigureType _figureType;

        public Point Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        public Point End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        public FigureType FigureType
        {
            get
            {
                return _figureType;
            }
            set
            {
                _figureType = value;
            }
        }

        public abstract void DrawFigure(Bitmap target);
        public abstract void MoveOrResize(Point start, Point end);
    }
}
