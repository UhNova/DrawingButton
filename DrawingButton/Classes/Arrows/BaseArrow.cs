﻿using System.Drawing;

namespace DrawingButton.Classes.Arrows
{
    internal class BaseArrow : AbstractFigure
    {

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
    }
}