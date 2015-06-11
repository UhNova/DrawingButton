using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DrawingButton.Classes.Arrows;
using DrawingButton.Classes.Blocks;
using DrawingButton.Classes.Enums;

namespace DrawingButton.Classes
{
    public class DrawTool
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
                    (o.CheckInnerPoint(targetArrow.Start)));

            var endBlock = _blocks.FirstOrDefault(
                o =>
                    (o.CheckInnerPoint(targetArrow.End)));

            var existArrow =
                _arrows.FirstOrDefault(
                    o =>
                        (o.CheckEqual(targetArrow)));

            var existRelation =
                _relations.FirstOrDefault(
                    o =>
                        o.CheckExist(startBlock, endBlock, targetArrow));

            if ((startBlock != null) && (endBlock != null) && (startBlock != endBlock) && (existArrow == null) &&
                (existRelation == null))
            {
                targetArrow.Start = startBlock.FindClosestPoint(targetArrow.Start);
                targetArrow.End = endBlock.FindClosestPoint(targetArrow.End);
                _arrows.Add(targetArrow);

                CreateRelation(startBlock, endBlock, targetArrow);
            }
        }

        /// <summary>
        ///     Проверка захвата фигуры
        /// </summary>
        /// <param name="target">Целевая точка</param>
        /// <returns></returns>
        public CaptureType CheckCapture(Point target)
        {
            var outerBlock = _blocks.FirstOrDefault(
                o =>
                    o.CheckInnerPoint(target));

            if (outerBlock != null) return CaptureType.Drag;

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
                        o.CheckInnerPoint(target));

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
        /// <param name="figureType">Тип фигуры</param>
        public void InsertOrUpdate(Point start, Point end, bool isBlock, Enum figureType)
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
                        CreateBlock(start, end, figureType);
                    }
                    _busyCreating = true;
                }
                else
                {
                    CreateArrow(start, end, figureType);
                    _busyCreating = true;
                }
            }
        }

        private void CreateBlock(Point start, Point end, Enum figureType)
        {
            BaseBlock newFigure;
            if ((BlockType) figureType == BlockType.Class)
            {
                newFigure = new ClassBlock(start, end);
            }
            else
            {
                newFigure = new InterfaceBlock(start, end);
            }
            _blocks.Add(newFigure);
        }

        private void CreateArrow(Point start, Point end, Enum figureType)
        {
            BaseArrow newFigure;
            if ((ArrowType) figureType == ArrowType.Inheritance)
            {
                newFigure = new InheritanceArrow(start, end);
            }
            else
            {
                newFigure = new DependencyArrow(start, end);
            }
            _tryBinding(newFigure);
        }

        private void CreateRelation(BaseBlock startBlock, BaseBlock endBlock, BaseArrow targetArrow)
        {
            _relations.Add(new FigureRelation(startBlock, targetArrow, endBlock));
            startBlock.OnMoveOrResize += targetArrow.MoveStart;
            endBlock.OnMoveOrResize += targetArrow.MoveEnd;
        }
    }
}