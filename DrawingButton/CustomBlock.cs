using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Graphics graph = Graphics.FromImage(target);
            Rectangle targetRectangle = new Rectangle();

            switch (_type)
            {
                case BlockType.RedSolid:
                    _pen = new Pen(Color.Red, 1);

                    Point realStart = new Point();
                    realStart.X = (_start.X < _end.X) ? _start.X : _end.X;
                    realStart.Y = (_start.Y < _end.Y) ? _start.Y : _end.Y;

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
