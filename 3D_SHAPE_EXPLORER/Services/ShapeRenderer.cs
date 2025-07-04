using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Utils;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class ShapeRenderer
    {
        public void Draw(Graphics g, List<Shape3D> shapes, Size panelSize)
        {
            foreach (var shape in shapes)
            {
                var copy = shape.Clone();

                copy.ApplyTransformations();

                var projectedPoints = new List<PointF>();
                foreach (var pt in copy.Points)
                    projectedPoints.Add(Projection3D.Project(pt, panelSize));

                foreach (var face in copy.Faces)
                {
                    var polygon = new List<PointF>();
                    foreach (var index in face)
                        polygon.Add(projectedPoints[index]);

                    g.FillPolygon(Brushes.Gray, polygon.ToArray());
                }

                using (Pen edgePen = shape.IsSelected
                    ? new Pen(Color.Orange, 2)
                    : new Pen(Color.Black, 1))
                {
                    foreach (var face in copy.Faces)
                    {
                        for (int i = 0; i < face.Count; i++)
                        {
                            int idx1 = face[i];
                            int idx2 = face[(i + 1) % face.Count];
                            var p1 = projectedPoints[idx1];
                            var p2 = projectedPoints[idx2];
                            g.DrawLine(edgePen, p1, p2);
                        }
                    }
                }
            }
        }
    }
}
