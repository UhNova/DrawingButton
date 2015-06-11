using System;
using System.Drawing;
using System.Linq;

namespace DrawingButton.Classes.Blocks
{
    public class BaseBlock : AbstractFigure
    {
        /// <summary>
        ///     Делегат для подписчиков перемещения
        /// </summary>
        /// <param name="start">Начальное положение</param>
        /// <param name="end">Конечное положение</param>
        public delegate void MovingOrResizing(Point start, Point end);

        protected int _height;
        protected int _width;

        /// <summary>
        ///     Исходная стартовая точка
        /// </summary>
        public Point InitialStart
        {
            get { return _start; }
        }

        /// <summary>
        ///     Исходная конечная точка
        /// </summary>
        public Point InitialEnd
        {
            get { return _end; }
        }

        /// <summary>
        ///     Начальное положение
        /// </summary>
        public Point Start
        {
            get
            {
                return (new Point
                {
                    X = (_start.X < _end.X) ? _start.X : _end.X,
                    Y = (_start.Y < _end.Y) ? _start.Y : _end.Y
                });
            }
            set { _start = value; }
        }

        /// <summary>
        ///     Конечное положение
        /// </summary>
        public Point End
        {
            get
            {
                return (new Point
                {
                    X = (_start.X > _end.X) ? _start.X : _end.X,
                    Y = (_start.Y > _end.Y) ? _start.Y : _end.Y
                });
            }
            set { _end = value; }
        }

        public Point Middle
        {
            get
            {
                return new Point(
                    (Start.Y + End.Y) / 2,
                    (Start.X + End.X) / 2
                    );
            }
        }

        /// <summary>
        ///     Ширина блока
        /// </summary>
        public int Width
        {
            get { return (Math.Abs(_start.X - _end.X)); }
            set { _width = value; }
        }

        /// <summary>
        ///     Высота блока
        /// </summary>
        public int Height
        {
            get { return (Math.Abs(_start.Y - _end.Y)); }
            set { _height = value; }
        }

        /// <summary>
        ///     Перемещение блока
        /// </summary>
        /// <param name="start">Начальное положение</param>
        /// <param name="end">Конечное положение</param>
        public override void MoveStart(Point start, Point end)
        {
            RaiseMoveOrResizeEvent(start, end);
        }

        /// <summary>
        ///     Отрисовка блока
        /// </summary>
        /// <param name="target">Полотно для рисования</param>
        public override void DrawFigure(Bitmap target)
        {
            var graph = Graphics.FromImage(target);
            var targetRectangle = new Rectangle
            {
                Location = Start,
                Height = Height,
                Width = Width
            };

            graph.DrawRectangle(_pen, targetRectangle);
            graph.FillRectangle(new SolidBrush(Color.White), targetRectangle);
        }

        /// <summary>
        ///     Событие перемещение
        /// </summary>
        public event MovingOrResizing OnMoveOrResize;

        /// <summary>
        ///     Метод вызова события перемещения
        /// </summary>
        /// <param name="start">Начальное положение</param>
        /// <param name="end">Конечное положение</param>
        protected void RaiseMoveOrResizeEvent(Point start, Point end)
        {
            if (OnMoveOrResize != null) OnMoveOrResize(start, end);
        }

        /// <summary>
        ///     Поиск дистанции между двумя точками
        /// </summary>
        /// <param name="x">Начальное X</param>
        /// <param name="y">Начальное Y</param>
        /// <param name="b">Конечная точка</param>
        /// <returns></returns>
        private static double FindDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        /// <summary>
        ///     Найти ближайшую точку прямоугольника
        /// </summary>
        /// <param name="targetPoint">Целевая точка</param>
        /// <returns></returns>
        public Point FindClosestPoint(Point targetPoint)
        {
            //сложные конструкции надо упрощать с помощью промежуточных переменных с понятным именем
            // Как дополнительное правило можно сказать: любая сущность должна иметь имя. 
            // Если используем точку в середине правой стороны - лучша дать ей имя.
            Point middleLeft = new Point(Start.X, Middle.Y);
            Point middleTop = new Point(Middle.X, Start.Y);
            Point middleRight = new Point(End.X, Middle.Y);
            Point middleBottom = new Point(Middle.X, End.Y);

            Point[] points = {
                middleLeft,
                middleRight,
                middleTop,
                middleBottom
            };

            var distances = new[]
            {
                FindDistance(middleLeft, targetPoint),
                FindDistance(middleRight, targetPoint),
                FindDistance(middleTop, targetPoint),
                FindDistance(middleBottom, targetPoint)
            };

            var neededDistance = distances.Min();

            int pointIndex = distances.ToList().IndexOf(neededDistance);

            return points[pointIndex];
        }

        /// <summary>
        /// Проверка нахождения точки в блоке
        /// </summary>
        /// <param name="target">Целевая точка</param>
        /// <returns></returns>
        public bool CheckInnerPoint(Point target)
        {
            return ((target.X >= _start.X) && (target.X <= _end.X)) &&
                   ((target.Y >= _start.Y) && (target.Y <= _end.Y));
        }
    }
}