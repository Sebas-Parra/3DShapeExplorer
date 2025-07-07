using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Utils;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class ShapeRenderer
    {
        public void Draw(Graphics g, List<Shape3D> shapes, Size panelSize, SceneManager sceneManager, bool isInEditMode, Color paintColor)
        {
            bool hasSelectedElement = sceneManager.SelectedVertexIndex.HasValue
            || sceneManager.SelectedEdge != null
            || sceneManager.SelectedFace != null;
    

            foreach (var shape in shapes)
            {
                /*var workingCopy = shape.Clone();
                workingCopy.ApplyTransformations();
                var projectedPoints = workingCopy.Points
                    .Select(p => Projection3D.Project(p, panelSize))
                    .ToList();*/
                shape.ApplyTransformations(); // ¡aplica transformaciones al objeto real!
                var projectedPoints = shape.Points
                    .Select(p => Projection3D.Project(p, panelSize))
                    .ToList();


                float avgX = projectedPoints.Average(p => p.X);
                float avgY = projectedPoints.Average(p => p.Y);
                g.FillEllipse(Brushes.Red, avgX - 3, avgY - 3, 6, 6);



                

                // Segundo: pintar caras visibles
                for (int i = 0; i < shape.Faces.Count; i++)
                {
                    var face = shape.Faces[i];

                    var polygon = face.Select(index => projectedPoints[index]).ToArray();
                    Brush fill = shape.IsPainted ? new SolidBrush(shape.PaintColor) : Brushes.Gray;




                    g.FillPolygon(fill, polygon);

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

                if (sceneManager.SelectedFace != null && IsValidFace(sceneManager.SelectedFace, projectedPoints.Count))
                {
                    var facePoints = sceneManager.SelectedFace
                        .Select(i => projectedPoints[i])
                        .ToArray();

                    using (Pen purplePen = new Pen(Color.Purple, 2))
                        g.DrawPolygon(purplePen, facePoints);
                }

            }

           

        }

        bool IsValidFace(List<int> face, int pointCount)
        {
            return face.Count >= 3 && face.All(i => i >= 0 && i < pointCount);
        }



    }
}
