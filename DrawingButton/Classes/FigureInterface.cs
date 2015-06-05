using System.Drawing;

namespace DrawingButton.Classes
{
    interface FigureInterface
    {
        /// <summary>
        /// Метод для отрисовки фигуры
        /// </summary>
        /// <param name="target">Целевая фигура</param>
        void DrawFigure(Bitmap target);
        /// <summary>
        /// Метод перемещения начальной точки фигуры
        /// </summary>
        /// <param name="start">Точка начала перемещения</param>
        /// <param name="end">Точка окончания перемещения</param>
        void MoveStart(Point start, Point end);
    }
}
