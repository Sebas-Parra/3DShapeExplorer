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
        public void Draw(Graphics g, List<Shape3D> shapes, Size panelSize, SceneManager sceneManager, bool isInEditMode)
        {
            bool hasSelectedElement = sceneManager.SelectedVertexIndex.HasValue
            || sceneManager.SelectedEdge != null
            || sceneManager.SelectedFace != null;
    

            foreach (var shape in shapes)
            {
                var workingCopy = shape.Clone();
                workingCopy.ApplyTransformations();
                var projectedPoints = workingCopy.Points
                    .Select(p => Projection3D.Project(p, panelSize))
                    .ToList();

                float avgX = projectedPoints.Average(p => p.X);
                float avgY = projectedPoints.Average(p => p.Y);
                g.FillEllipse(Brushes.Red, avgX - 3, avgY - 3, 6, 6);


                
                foreach (var face in shape.Faces)
                {
                    var polygon = face.Select(i => projectedPoints[i]).ToArray();
                    g.FillPolygon(Brushes.Gray, polygon);
                }

                using (Pen edgePen = shape.IsSelected
                    ? new Pen(Color.Orange, 2)
                    : new Pen(Color.Black, 1))
                {
                    foreach (var face in shape.Faces)
                    {
                        for (int i = 0; i < face.Count; i++)
                        {
                            int idx1 = face[i];
                            int idx2 = face[(i + 1) % face.Count];
                            g.DrawLine(edgePen, projectedPoints[idx1], projectedPoints[idx2]);
                        }
                    }
                }

                if (sceneManager.SelectedVertexIndex.HasValue)
                {
                    int index = sceneManager.SelectedVertexIndex.Value;
                    if (index >= 0 && index < projectedPoints.Count)
                    {
                        PointF pt = projectedPoints[index];
                        g.FillEllipse(Brushes.Blue, pt.X - 5, pt.Y - 5, 10, 10);
                    }
                }

                if (sceneManager.SelectedEdge != null)
                {
                    var (a, b) = sceneManager.SelectedEdge;
                    if (a < projectedPoints.Count && b < projectedPoints.Count)
                    {
                        using (Pen redPen = new Pen(Color.Red, 2))
                            g.DrawLine(redPen, projectedPoints[a], projectedPoints[b]);
                    }
                }

                if (sceneManager.SelectedFace != null)
                {
                    var facePoints = sceneManager.SelectedFace
                        .Where(i => i < projectedPoints.Count)
                        .Select(i => projectedPoints[i])
                        .ToArray();

                    using (Pen purplePen = new Pen(Color.Purple, 2))
                        g.DrawPolygon(purplePen, facePoints);
                }
            }
        }


    }
}
