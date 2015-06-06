using System.Drawing;

namespace DrawingButton.Classes.Arrows
{
    class InheritanceArrow : BaseArrow
    {
        public InheritanceArrow(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Blue, 2);
        }
    }
}
