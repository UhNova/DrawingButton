using System.Drawing;

namespace DrawingButton.Classes.Arrows
{
    internal class InheritanceArrow : BaseArrow
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="start">Начало</param>
        /// <param name="end">Конец</param>
        public InheritanceArrow(Point start, Point end)
        {
            _start = start;
            _end = end;
            _pen = new Pen(Color.Blue, 2);
        }
    }
}