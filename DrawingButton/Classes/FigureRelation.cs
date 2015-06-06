using DrawingButton.Classes.Arrows;
using DrawingButton.Classes.Blocks;

namespace DrawingButton.Classes
{
    class FigureRelation
    {
        private BaseBlock _startBlock;
        private BaseArrow _arrow;
        private BaseBlock _endBlock;

        public BaseBlock StartBlock
        {
            get
            {
                return _startBlock;
            }
            set
            {
                _startBlock = value;
            }
        }

        public BaseArrow Arrow
        {
            get
            {
                return _arrow;
            }
            set
            {
                _arrow = value;
            }
        }

        public BaseBlock EndBlock
        {
            get
            {
                return _endBlock;
            }
            set
            {
                _endBlock = value;
            }
        }

        public FigureRelation(BaseBlock startBlock, BaseArrow arrow, BaseBlock endBlock)
        {
            _startBlock = startBlock;
            _arrow = arrow;
            _endBlock = endBlock;
        }
    }
}
