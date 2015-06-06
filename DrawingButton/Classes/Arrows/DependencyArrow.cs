using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingButton.Classes.Arrows
{
    class DependencyArrow : BaseArrow
    {
        public DependencyArrow(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Green, 2) { DashStyle = DashStyle.Dash };
        }
    }
}