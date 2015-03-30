using System.Drawing;

namespace DrawingButton
{
    class CustomArrow : AbstractFigure
    {
        private ArrowType _type;
        private Pen _pen;

        public ArrowType ArrowType
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

        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            switch (_type)
            {
                case ArrowType.Inheritance:
                    _pen = new Pen(Color.Blue, 1);
                    break;
            }
            graph.DrawLine(_pen, _start, _end);
        }

        public override void MoveOrResize(Point start, Point end)
        {

        }
    }
}
