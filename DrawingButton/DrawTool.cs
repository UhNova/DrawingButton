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
        public void TryCapture(Point target)
        {

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
            var existFigure = _figures.FirstOrDefault(o => (o.Start.X == start.X) && (o.Start.Y == start.Y) && (o.FigureType == type));
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
                        CustomArrow newArrow = new CustomArrow();
                        newArrow.ArrowType = ArrowType.Inheritance;
                        newArrow.Start = start;
                        newArrow.End = end;
                        newFigure = newArrow;
                        break;
                    case FigureType.Block:
                        CustomBlock newBlock = new CustomBlock();
                        newBlock.BlockType = BlockType.Class;
                        newBlock.Start = start;
                        newBlock.End = end;
                        newFigure = newBlock;
                        break;
                }
                newFigure.FigureType = type;
                _figures.Add(newFigure);
            }
            
        }
    }
}
