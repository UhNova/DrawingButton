using System.Drawing;

namespace DrawingButton.Classes.Arrows
{
    internal class ImplementationArrow : BaseArrow
    {
        public ImplementationArrow(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Green, 2);
        }
    }
}