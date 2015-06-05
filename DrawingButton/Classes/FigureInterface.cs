using System.Drawing;

namespace DrawingButton.Classes
{
    interface FigureInterface
    {
        void DrawFigure(Bitmap target);
        void MoveOrResize(Point start, Point end);
    }
}
