using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingButton
{
    class DrawTool
    {
        private List<AbstractFigure> _figures;
        private List<FigureRelation> _relations;
        private Bitmap _canvas;
        private AbstractFigure _currentFigure;

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

        }
    }
}
