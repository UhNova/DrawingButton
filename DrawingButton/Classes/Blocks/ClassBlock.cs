using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingButton.Classes.Blocks
{
    internal class ClassBlock : BaseBlock
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        public ClassBlock(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Red, 2) {DashStyle = DashStyle.Dash};
        }
    }
}