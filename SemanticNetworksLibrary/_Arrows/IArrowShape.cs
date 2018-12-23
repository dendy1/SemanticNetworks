using System.Drawing;

namespace SemanticNetworksLibrary
{
    public interface IArrowShape
    {
        void Draw(Graphics g, Pen pen, PointF start, PointF end, SizeF arrowSize);
    }
}
