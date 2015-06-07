using System.Drawing;

namespace DrawingButton.Classes
{
    internal abstract class AbstractFigure
    {
        protected Point _end = new Point(0, 0);
        protected Pen _pen;
        protected Point _start = new Point(0, 0);

        /// <summary>
        ///     Метод для отрисовки фигуры
        /// </summary>
        /// <param name="target">Целевая фигура</param>
        public abstract void DrawFigure(Bitmap target);

        /// <summary>
        ///     Метод перемещения начальной точки фигуры
        /// </summary>
        /// <param name="start">Точка начала перемещения</param>
        /// <param name="end">Точка окончания перемещения</param>
        public abstract void MoveStart(Point start, Point end);
    }
}