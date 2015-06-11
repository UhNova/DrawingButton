using System.Drawing;
using System.Drawing.Drawing2D;
using DrawingButton.Classes.Enums;

namespace DrawingButton.Classes.Arrows
{
    public class DependencyArrow : BaseArrow
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="start">Начало</param>
        /// <param name="end">Конец</param>
        public DependencyArrow(Point start, Point end)
        {
            _arrowType = ArrowType.Dependency;
            _start = start;
            _end = end;
            _pen = new Pen(Color.Green, 2) {DashStyle = DashStyle.Dash};
        }
    }
}