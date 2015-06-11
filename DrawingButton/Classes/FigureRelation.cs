using DrawingButton.Classes.Arrows;
using DrawingButton.Classes.Blocks;

namespace DrawingButton.Classes
{
    public class FigureRelation
    {
        private BaseArrow _arrow;
        private BaseBlock _endBlock;
        private BaseBlock _startBlock;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="startBlock">Начальный блок</param>
        /// <param name="arrow">Стрелка</param>
        /// <param name="endBlock">Конечный блок</param>
        public FigureRelation(BaseBlock startBlock, BaseArrow arrow, BaseBlock endBlock)
        {
            _startBlock = startBlock;
            _arrow = arrow;
            _endBlock = endBlock;
        }

        /// <summary>
        ///     Начальный блок
        /// </summary>
        public BaseBlock StartBlock
        {
            get { return _startBlock; }
            set { _startBlock = value; }
        }

        /// <summary>
        ///     Стрелка
        /// </summary>
        public BaseArrow Arrow
        {
            get { return _arrow; }
            set { _arrow = value; }
        }

        /// <summary>
        ///     Конечный блок
        /// </summary>
        public BaseBlock EndBlock
        {
            get { return _endBlock; }
            set { _endBlock = value; }
        }

        /// <summary>
        /// Проверка совпадения связей
        /// </summary>
        /// <returns></returns>
        public bool CheckExist(BaseBlock startBlock, BaseBlock endBlock, BaseArrow arrow)
        {
            return ((((_startBlock == startBlock) && (_endBlock == endBlock)) || ((_endBlock == startBlock) && (_startBlock == endBlock))) && (_arrow.ArrowType == arrow.ArrowType));
        }
    }
}