using System.Drawing;

namespace DrawingButton.Classes.Blocks
{
    class ClassBlock : AbstractBlock
    {
        public ClassBlock(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Red, 2);
        }

        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            var targetRectangle = new Rectangle
            {
                Location = Start,
                Height = Height,
                Width = Width
            };
            graph.DrawRectangle(_pen, targetRectangle);
        }

        public override void MoveStart(Point start, Point end)
        {
            RaiseMoveOrResizeEvent(start, end);
        }
    }
}
