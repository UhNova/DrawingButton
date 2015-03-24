using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingButton
{
    abstract class AbstractFigure
    {
        private Point _start = new Point(0, 0);
        private Point _end = new Point(0, 0);

        public Point Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        public Point End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        public abstract void DrawFigure(Bitmap target);
        public abstract void MoveOrResize(Point start, Point end);
    }
}
