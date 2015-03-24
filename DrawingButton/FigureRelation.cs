using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingButton
{
    class FigureRelation
    {
        private AbstractFigure _startBlock;
        private AbstractFigure _arrow;
        private AbstractFigure _endBlock;

        public AbstractFigure StartBlock
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

        public AbstractFigure Arrow
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

        public AbstractFigure EndBlock
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

        public FigureRelation(AbstractFigure startBlock, AbstractFigure arrow, AbstractFigure endBlock)
        {
            _startBlock = startBlock;
            _arrow = arrow;
            _endBlock = endBlock;
        }
    }
}
