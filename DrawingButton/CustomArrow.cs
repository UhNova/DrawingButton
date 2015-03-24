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
        private int _type;

        public int ArrowType
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

        public void DrawFigure(Bitmap target)
        {

        }

        public void MoveOrResize(Point start, Point end)
        {

        }
    }
}
