using System.Drawing;

namespace DrawingButton.Classes.Blocks
{
    internal class InterfaceBlock : BaseBlock
    {
        public InterfaceBlock(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.SlateBlue, 2);
        }
    }
}