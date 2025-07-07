using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _3D_SHAPE_EXPLORER.Services
{
    public static class ShapePainter
    {
        public static void DrawFace(Graphics g, List<PointF> projectedPoints, List<int> face, bool isPainted, Color paintColor)
        {
            var polygon = face.Select(i => projectedPoints[i]).ToArray();
            Brush fill = isPainted ? new SolidBrush(paintColor) : Brushes.Gray;
            g.FillPolygon(fill, polygon);
        }

        public static void DrawEdges(Graphics g, List<PointF> projectedPoints, List<int> face, Pen pen)
        {
            for (int i = 0; i < face.Count; i++)
            {
                int idx1 = face[i];
                int idx2 = face[(i + 1) % face.Count];
                g.DrawLine(pen, projectedPoints[idx1], projectedPoints[idx2]);
            }
        }

        public static void HighlightVertex(Graphics g, PointF pt)
        {
            g.FillEllipse(Brushes.Blue, pt.X - 5, pt.Y - 5, 10, 10);
        }

        public static void HighlightEdge(Graphics g, PointF a, PointF b)
        {
            using (Pen redPen = new Pen(Color.Red, 2))
                g.DrawLine(redPen, a, b);
        }

        public static void HighlightFace(Graphics g, List<PointF> facePoints)
        {
            using (Pen purplePen = new Pen(Color.Purple, 2))
                g.DrawPolygon(purplePen, facePoints.ToArray());
        }
    }
}
