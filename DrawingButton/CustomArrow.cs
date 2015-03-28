using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Graphics graph = Graphics.FromImage(target);
            switch (_type)
            {
                case ArrowType.Black:
                    _pen = new Pen(Color.Black, 1);
                    break;
            }
            graph.DrawLine(_pen, _start, _end);
        }

        public override void MoveOrResize(Point start, Point end)
        {

        }
    }
}
