using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingButton.Classes.Blocks
{
    class ClassBlock : BaseBlock
    {
        public ClassBlock(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Red, 2) {DashStyle = DashStyle.Dash};
        }
    }
}
