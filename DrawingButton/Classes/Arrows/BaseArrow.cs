using System.Drawing;
using DrawingButton.Classes.Enums;

namespace DrawingButton.Classes.Arrows
{
    public class BaseArrow : AbstractFigure
    {
        protected ArrowType _arrowType;

        public ArrowType ArrowType
        {
            get { return _arrowType; }
        }

        /// <summary>
        ///     Начальная точка
        /// </summary>
        public Point Start
        {
            get { return _start; }
            set { _start = value; }
        }

        /// <summary>
        ///     Конечная точка
        /// </summary>
        public Point End
        {
            get { return _end; }
            set { _end = value; }
        }

        /// <summary>
        ///     Нарисовать фигуру
        /// </summary>
        /// <param name="target">Целевое полотно</param>
        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            graph.DrawLine(_pen, _start, _end);
        }

        /// <summary>
        ///     Перемещение начала стрелки
        /// </summary>
        /// <param name="start">Начальное положение</param>
        /// <param name="end">Конечное положение</param>
        public override void MoveStart(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _start.X += xOffset;
            _start.Y += yOffset;
        }

        /// <summary>
        ///     Перемещение конца стрелки
        /// </summary>
        /// <param name="start">Начальное положение</param>
        /// <param name="end">Конечное положение</param>
        public void MoveEnd(Point start, Point end)
        {
            var xOffset = end.X - start.X;
            var yOffset = end.Y - start.Y;

            _end.X += xOffset;
            _end.Y += yOffset;
        }

        /// <summary>
        /// Проверить совпадение стрелок
        /// </summary>
        /// <param name="target">Стрелка для проверки</param>
        /// <returns></returns>
        public bool CheckEqual(BaseArrow target)
        {
            return (_start.X == target.Start.X) && (_start.Y == target.Start.Y) &&
                   (_end.X == target.End.X) && (_end.Y == target.End.Y);
        }
    }
}