using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DrawingButton.Classes.Arrows;
using DrawingButton.Classes.Blocks;
using DrawingButton.Classes.Enums;

namespace DrawingButton.Classes
{
    internal class DrawTool
    {
        private List<BaseArrow> _arrows;
        private List<BaseBlock> _blocks;
        private bool _busyCreating;
        private bool _busyMoving;
        private Bitmap _canvas;
        private BaseBlock _currentBlock;
        private Point _initialStart, _initialEnd;
        private List<FigureRelation> _relations;

        /// <summary>
        ///     Конструктор средства для рисования
        /// </summary>
        /// <param name="canvas">Полотно для рисования</param>
        public DrawTool(Bitmap canvas)
        {
            _canvas = canvas;
            _blocks = new List<BaseBlock>();
            _arrows = new List<BaseArrow>();
            _relations = new List<FigureRelation>();
            _busyCreating = false;
            _busyMoving = false;
        }

        /// <summary>
        ///     Список блоков
        /// </summary>
        public List<BaseBlock> Blocks
        {
            get { return _blocks; }
            set { _blocks = value; }
        }

        /// <summary>
        ///     Список связей
        /// </summary>
        public List<FigureRelation> Relations
        {
            get { return _relations; }
            set { _relations = value; }
        }

        /// <summary>
        ///     Полотно для рисования
        /// </summary>
        public Bitmap Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

        /// <summary>
        ///     Список стрелок
        /// </summary>
        public List<BaseArrow> Arrows
        {
            get { return _arrows; }
            set { _arrows = value; }
        }

        /// <summary>
        ///     Поиск дистанции между двумя точками
        /// </summary>
        /// <param name="x">Начальное X</param>
        /// <param name="y">Начальное Y</param>
        /// <param name="b">Конечная точка</param>
        /// <returns></returns>
        private double FindDistance(double x, double y, Point b)
        {
            return Math.Sqrt(Math.Pow(x - b.X, 2) + Math.Pow(y - b.Y, 2));
        }

        /// <summary>
        ///     Найти ближайшую точку прямоугольника. 
        /// Вообще этот метод надо вынести в класс прямоугольника. Т.к. это чисто его ответственность знать ближайшую точку
        /// </summary>
        /// <param name="targetPoint">Целевая точка</param>
        /// <param name="targetBlock">Целевой блок</param>
        /// <returns></returns>
        private Point FindClosestPoint(Point targetPoint, BaseBlock targetBlock)
        {
            var Distances = new[]
            {
                FindDistance(targetBlock.Start.X, ((double) targetBlock.Start.Y + targetBlock.End.Y)/2, targetPoint),
                FindDistance(((double) targetBlock.Start.X + targetBlock.End.X)/2, targetBlock.Start.Y, targetPoint),
                FindDistance(targetBlock.End.X, ((double) targetBlock.Start.Y + targetBlock.End.Y)/2, targetPoint),
                FindDistance(((double) targetBlock.Start.X + targetBlock.End.X)/2, targetBlock.End.Y, targetPoint)
            };

            var neededDistance = Distances.Min();

            // Переписать этот кусок. Цикл + switch? Это вообще нормально?
            
            for (var i = 0; i < 4; i++)
            {
                // Если уже есть минимальная дистанция зачем еще раз делать проверку?
                if ((!(Math.Abs(Distances[i] - neededDistance) < 0.05))) continue;
                switch (i)
                {
                    case 0:
                        return new Point(targetBlock.Start.X, (targetBlock.Start.Y + targetBlock.End.Y)/2);
                    case 1:
                        return new Point((targetBlock.Start.X + targetBlock.End.X)/2, targetBlock.Start.Y);
                    case 2:
                        return new Point(targetBlock.End.X, (targetBlock.Start.Y + targetBlock.End.Y)/2);
                    case 3:
                        return new Point((targetBlock.Start.X + targetBlock.End.X)/2, targetBlock.End.Y);
                }
            }

            return new Point(-1, -1);
        }

        /// <summary>
        ///     Освободить захват фигуры
        /// </summary>
        public void FreeCapture()
        {
            _busyMoving = false;
            _busyCreating = false;
        }

        /// <summary>
        ///     Отрисовка всех фигур
        /// </summary>
        public void DrawAll()
        {
            foreach (var block in _blocks)
            {
                block.DrawFigure(_canvas);
            }

            foreach (var arrow in _arrows)
            {
                arrow.DrawFigure(_canvas);
            }
        }

        /// <summary>
        ///     Попытка привязки стрелок
        /// </summary>
        /// <param name="targetArrow">Целевая стрелка</param>
        private void _tryBinding(BaseArrow targetArrow)
        {
            var startBlock = _blocks.FirstOrDefault(
                o =>
                    (
                    // Все логическое выражение вынести в отдельную функцию. Слишком большое нагромождение. 
                    // Переменные startBlock и остальные просто теряются в этой мешанине
                        ((targetArrow.Start.X >= o.Start.X) && (targetArrow.Start.X <= o.End.X)) &&
                        ((targetArrow.Start.Y >= o.Start.Y) && (targetArrow.Start.Y <= o.End.Y))
                    )
                    );

            var endBlock = _blocks.FirstOrDefault(
                o =>
                    // Все логическое выражение вынести в отдельную функцию. Слишком большое нагромождение. 
                    // Переменные startBlock и остальные просто теряются в этой мешанине
                    (((targetArrow.End.X >= o.Start.X) && (targetArrow.End.X <= o.End.X)) &&
                     ((targetArrow.End.Y >= o.Start.Y) && (targetArrow.End.Y <= o.End.Y))));

            var existArrow =
                _arrows.FirstOrDefault(
                    o =>
                        // Все логическое выражение вынести в отдельную функцию. Слишком большое нагромождение. 
                        // Переменные startBlock и остальные просто теряются в этой мешанине
                        (o.Start.X == targetArrow.Start.X) && (o.Start.Y == targetArrow.Start.Y) &&
                        (o.End.X == targetArrow.End.X) && (o.End.Y == targetArrow.End.Y));

            var existRelation = _relations.FirstOrDefault(o => (o.StartBlock == startBlock) && (o.EndBlock == endBlock));

            if ((startBlock != null) && (endBlock != null) && (startBlock != endBlock) && (existArrow == null) &&
                (existRelation == null))
            {
                targetArrow.Start = FindClosestPoint(targetArrow.Start, startBlock);
                targetArrow.End = FindClosestPoint(targetArrow.End, endBlock);

                _arrows.Add(targetArrow);
                _relations.Add(new FigureRelation(startBlock, targetArrow, endBlock));
                startBlock.OnMoveOrResize += targetArrow.MoveStart;
                endBlock.OnMoveOrResize += targetArrow.MoveEnd;
            }
        }

        /// <summary>
        ///     Проверка захвата фигуры
        /// </summary>
        /// <param name="target">Целевая точка</param>
        /// <returns></returns>
        public CaptureType CheckCapture(Point target)
        {
            // Замечания аналогично методу _tryBinding
            var outerBlock = _blocks.FirstOrDefault(
                o =>
                    // "2" вынести в константы. Т.к. имеет одинаковый смысл (точность попадания) и может измениться 
                    // (например если требуется работа на экранах с большим расширением)
                    ((o.Start.X + 2) < target.X) && ((o.Start.Y + 2) < target.Y) &&
                    ((o.End.X - 2) > target.X) && ((o.End.Y - 2) > target.Y));

            if (outerBlock != null) return CaptureType.Drag;

            var horizontalEdgeBlock = _blocks.FirstOrDefault(
                o =>
                    ((((target.X >= o.Start.X) && (target.X <= (o.Start.X + 2))) ||
                      ((target.X <= o.End.X) && (target.X >= (o.End.X - 2)))) &&
                     ((target.Y >= o.Start.Y) && (target.Y <= o.End.Y))));

            if (horizontalEdgeBlock != null) return CaptureType.ResizeHorizontal;

            var verticalEdgeBlock = _blocks.FirstOrDefault(
                o =>
                    // "2" вынести в константы. Т.к. имеет одинаковый смысл (точность попадания) и может измениться 
                    // (например если требуется работа на экранах с большим расширением)
                    ((((target.Y >= o.Start.Y) && (target.Y <= (o.Start.Y + 2))) ||
                      ((target.Y <= o.End.Y) && (target.Y >= (o.End.Y - 2)))) &&
                     ((target.X >= o.Start.X) && (target.X <= o.End.X))));

            if (verticalEdgeBlock != null) return CaptureType.ResizeVertical;

            return CaptureType.None;
        }

        /// <summary>
        ///     Попытка захвата фигуры
        /// </summary>
        /// <param name="target">Точка захвата</param>
        public bool TryCaptureForMove(Point target)
        {
            if (_busyMoving) return (_currentBlock != null);

            _currentBlock =
                _blocks.FirstOrDefault(
                    o =>
                        // "2" вынести в константы. Т.к. имеет одинаковый смысл (точность попадания) и может измениться 
                        // (например если требуется работа на экранах с большим расширением)
                        ((o.Start.X + 2) <= target.X) && ((o.Start.Y + 2) <= target.Y) &&
                        ((o.End.X - 2) >= target.X) && ((o.End.Y - 2) >= target.Y));

            if (_currentBlock == null) return false;

            _initialStart = new Point
            {
                X = _currentBlock.Start.X,
                Y = _currentBlock.Start.Y
            };
            _initialEnd = new Point
            {
                X = _currentBlock.End.X,
                Y = _currentBlock.End.Y
            };

            return true;
        }

        /// <summary>
        ///     Добавить или изменить
        /// </summary>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        /// <param name="isBlock">Блок или стрелка</param>
        /// <param name="figureType">Тип фигуры. Тип фигруы должен быть enum.</param>
        public void InsertOrUpdate(Point start, Point end, bool isBlock, int figureType)
        {
            if (TryCaptureForMove(start) && (!_busyCreating) && (isBlock))
            {
                var offsetX = end.X - start.X;
                var offsetY = end.Y - start.Y;

                var previousStart = new Point(_currentBlock.Start.X, _currentBlock.Start.Y);

                _currentBlock.Start = new Point
                {
                    X = _initialStart.X + offsetX,
                    Y = _initialStart.Y + offsetY
                };
                _currentBlock.End = new Point
                {
                    X = _initialEnd.X + offsetX,
                    Y = _initialEnd.Y + offsetY
                };

                _currentBlock.MoveStart(previousStart, _currentBlock.Start);

                _busyMoving = true;
            }
            // Выделить методы. Большое количество вложенных if не читабельно
            else
            {
                if (isBlock)
                {
                    var existFigure =
                        _blocks.FirstOrDefault(
                            o => (o.InitialStart.X == start.X) && (o.InitialStart.Y == start.Y));

                    if (existFigure != null)
                    {
                        existFigure.End = end;
                    }
                    else
                    {
                        BaseBlock newFigure;
                        if (figureType == 1)
                        {
                            newFigure = new ClassBlock(start, end);
                        }
                        else
                        {
                            newFigure = new InterfaceBlock(start, end);
                        }
                        _blocks.Add(newFigure);
                    }
                    _busyCreating = true;
                }
                else
                {
                    BaseArrow newFigure;
                    if (figureType == 1)
                    {
                        newFigure = new InheritanceArrow(start, end);
                    }
                    else
                    {
                        newFigure = new DependencyArrow(start, end);
                    }
                    _tryBinding(newFigure);

                    _busyCreating = true;
                }
            }
        }
    }
}