using System.Drawing;

namespace DrawingButton.Classes.Arrows
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

        public override void MoveStart(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _start.X += xOffset;
            _start.Y += yOffset;
        }

        public override void MoveEnd(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _end.X += xOffset;
            _end.Y += yOffset;
        }
    }
}
