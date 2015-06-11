using System.Drawing;
using DrawingButton.Classes.Enums;

namespace DrawingButton.Classes.Arrows
{
    public class InheritanceArrow : BaseArrow
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="start">Начало</param>
        /// <param name="end">Конец</param>
        public InheritanceArrow(Point start, Point end)
        {
            _arrowType = ArrowType.Inheritance;;
            _start = start;
            _end = end;
            _pen = new Pen(Color.Blue, 2);
        }
    }
}