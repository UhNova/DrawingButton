using System.Drawing;

namespace DrawingButton.Classes
{
    interface FigureInterface
    {
        void DrawFigure(Bitmap target);
        void MoveStart(Point start, Point end);
    }
}
