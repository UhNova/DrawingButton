using System;
using System.Drawing;

namespace DrawingButton
{
    class CustomBlock : AbstractFigure
    {
        private BlockType _type;
        private Pen _pen;

        public BlockType BlockType
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
            var targetRectangle = new Rectangle();

            switch (_type)
            {
                case BlockType.Class:
                    _pen = new Pen(Color.Red, 1);

                    var realStart = new Point
                    {
                        X = (_start.X < _end.X) ? _start.X : _end.X,
                        Y = (_start.Y < _end.Y) ? _start.Y : _end.Y
                    };

                    targetRectangle.Location = realStart;
                    targetRectangle.Height = Math.Abs(_start.Y - _end.Y);
                    targetRectangle.Width = Math.Abs(_start.X - _end.X);
                    break;
            }
            graph.DrawRectangle(_pen, targetRectangle);
        }

        public override void MoveOrResize(Point start, Point end)
        {

        }
    }
}
