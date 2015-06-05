using System.Drawing;

namespace DrawingButton.Classes
{
    class InheritanceArrow : AbstractArrow
    {
        public InheritanceArrow(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Blue, 2);
        }

        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            graph.DrawLine(_pen, _start, _end);
        }

        public override void MoveOrResize(Point start, Point end)
        {

        }
    }
}
