namespace DrawingButton.Classes
{
    class FigureRelation
    {
        private AbstractBlock _startBlock;
        private AbstractArrow _arrow;
        private AbstractBlock _endBlock;

        public AbstractBlock StartBlock
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

        public AbstractArrow Arrow
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

        public AbstractBlock EndBlock
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

        public FigureRelation(AbstractBlock startBlock, AbstractArrow arrow, AbstractBlock endBlock)
        {
            _startBlock = startBlock;
            _arrow = arrow;
            _endBlock = endBlock;
        }
    }
}
