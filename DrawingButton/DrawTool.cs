using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrawingButton
{
    class DrawTool
    {
        private List<AbstractFigure> _figures;
        private List<FigureRelation> _relations;
        private Bitmap _canvas;
        private AbstractFigure _currentFigure;
        private CaptureType _captureType;
        private Point _initialStart, _initialEnd;

        private bool _busyCreating;
        private bool _busyMoving;

        /// <summary>
        /// Список фигур
        /// </summary>
        public List<AbstractFigure> Figures
        {
            get
            {
                return _figures;
            }
            set
            {
                _figures = value;
            }
        }

        /// <summary>
        /// Список связей
        /// </summary>
        public List<FigureRelation> Relations
        {
            get
            {
                return _relations;
            }
            set
            {
                _relations = value;
            }
        }

        /// <summary>
        /// Полотно для рисования
        /// </summary>
        public Bitmap Canvas
        {
            get
            {
                return _canvas;
            }
            set
            {
                _canvas = value;
            }
        }

        /// <summary>
        /// Конструктор средства для рисования
        /// </summary>
        /// <param name="canvas">Полотно для рисования</param>
        public DrawTool(Bitmap canvas)
        {
            _canvas = canvas;
            _figures = new List<AbstractFigure>();
            _relations = new List<FigureRelation>();
            _busyCreating = false;
            _busyMoving = false;
        }

        /// <summary>
        /// Освободить захват фигуры
        /// </summary>
        public void FreeCapture()
        {
            _busyMoving = false;
            _busyCreating = false;
        }
        
        /// <summary>
        /// Отрисовка всех фигур
        /// </summary>
        public void DrawAll()
        {
            foreach (var figure in _figures)
            {
                figure.DrawFigure(_canvas);
            }
        }

        private bool _checkBinding(Point start, Point end)
        {
            //Дописать

            return true;
        }

        /// <summary>
        /// Попытка захвата фигуры
        /// </summary>
        /// <param name="target">Точка захвата</param>
        public bool TryCapture(Point target)
        {
            if (_busyMoving) return (_currentFigure != null);

            _currentFigure =
                _figures.FirstOrDefault(
                    o =>
                        (((CustomBlock)o).RealStart.X <= target.X) && (((CustomBlock)o).RealStart.Y <= target.Y) &&
                        (((CustomBlock)o).RealEnd.X >= target.X) && (((CustomBlock)o).RealEnd.Y >= target.Y));

            if (_currentFigure == null) return (_currentFigure != null);

            _initialStart = new Point
            {
                X = _currentFigure.Start.X,
                Y = _currentFigure.Start.Y
            };
            _initialEnd = new Point
            {
                X = _currentFigure.End.X,
                Y = _currentFigure.End.Y
            };

            return (_currentFigure != null);
        }

        private AbstractFigure _isDragging()
        {
            //Дописать
            return null;
        }

        private AbstractFigure _isResizing()
        {
            //Дописать
            return null;
        }
        
        /// <summary>
        /// Добавить или изменить
        /// </summary>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        /// <param name="type">Тип фигуры</param>
        public void InsertOrUpdate(Point start, Point end, FigureType type)
        {
            if (TryCapture(start) && (!_busyCreating))
            {
                _captureType = CaptureType.Drag;

                var offsetX = end.X - start.X;
                var offsetY = end.Y - start.Y;

                _currentFigure.Start = new Point
                {
                    X = _initialStart.X + offsetX,
                    Y = _initialStart.Y + offsetY
                };
                _currentFigure.End = new Point
                {
                    X = _initialEnd.X + offsetX,
                    Y = _initialEnd.Y + offsetY
                };
                _busyMoving = true;
            }
            else
            {
                var existFigure =
                    _figures.FirstOrDefault(
                        o => (o.Start.X == start.X) && (o.Start.Y == start.Y) && (o.FigureType == type));
                if (existFigure != null)
                {
                    existFigure.End = end;
                }
                else
                {
                    AbstractFigure newFigure = null;
                    switch (type)
                    {
                        case FigureType.Relation:
                            var newArrow = new CustomArrow { ArrowType = ArrowType.Inheritance, Start = start, End = end };
                            newFigure = newArrow;
                            break;
                        case FigureType.Block:
                            var newBlock = new CustomBlock { BlockType = BlockType.Class, Start = start, End = end };
                            newFigure = newBlock;
                            break;
                    }
                    newFigure.FigureType = type;
                    _figures.Add(newFigure);   
                }
                _busyCreating = true;
            }
            
        }
    }
}
