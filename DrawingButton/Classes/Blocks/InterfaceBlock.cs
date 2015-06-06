using System.Drawing;

namespace DrawingButton.Classes.Blocks
{
    internal class InterfaceBlock : BaseBlock
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        public InterfaceBlock(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.SlateBlue, 2);
        }
    }
}