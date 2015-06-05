using System.Drawing;

namespace DrawingButton.Classes
{
    internal class PointDistance
    {
        private double _distance;
        private Point _targetPoint;

        public Point TargetPoint
        {
            get { return _targetPoint; }
            set { _targetPoint = value; }
        }
    }
}