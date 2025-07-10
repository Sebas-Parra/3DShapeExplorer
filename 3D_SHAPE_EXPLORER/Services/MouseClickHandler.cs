using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Utils;
using Guna.UI2.WinForms;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class MouseClickHandler
    {
        private readonly SceneManager sceneManager;
        private readonly PictureBox canvas;
        private readonly Guna2RadioButton rbtnVertexes, rbtnEdges, rbtnFaces, rbtnPaintFace; private Color currentPaintColor;

        public MouseClickHandler(SceneManager sceneManager, PictureBox canvas,
            Guna2RadioButton rbtnVertexes, Guna2RadioButton rbtnEdges, Guna2RadioButton rbtnFaces, Guna2RadioButton rbtnPaintFace,
            Color paintColor)
        {
            this.sceneManager = sceneManager;
            this.canvas = canvas;
            this.rbtnVertexes = rbtnVertexes;
            this.rbtnEdges = rbtnEdges;
            this.rbtnFaces = rbtnFaces;
            this.rbtnPaintFace = rbtnPaintFace;

            this.currentPaintColor = paintColor;
        }

        public void HandleMouseClick(Point mouseLocation)
        {
            sceneManager.SelectedVertexIndex = null;
            sceneManager.SelectedEdge = null;
            sceneManager.SelectedFace = null;
            sceneManager.Shapes.ForEach(s => s.IsSelected = false);

            if (rbtnVertexes.Checked)
                HandleVertexClick(mouseLocation);
            else if (rbtnEdges.Checked)
                HandleEdgeClick(mouseLocation);
            else if (rbtnFaces.Checked)
                HandleFaceClick(mouseLocation);
            else if (rbtnPaintFace.Checked)
                HandlePaintClick(mouseLocation);
            else
                HandleObjectClick(mouseLocation);
        }

        private void HandleVertexClick(Point mouseLocation)
        {
            for (int shapeIndex = 0; shapeIndex < sceneManager.Shapes.Count; shapeIndex++)
            {
                var shape = sceneManager.Shapes[shapeIndex];
                Shape3D workingShape = shape.Clone();
                workingShape.ApplyTransformations();
                var projected = workingShape.Points.Select(p => Projection3D.Project(p, canvas.Size)).ToList();

                for (int i = 0; i < projected.Count; i++)
                {
                    float dx = projected[i].X - mouseLocation.X;
                    float dy = projected[i].Y - mouseLocation.Y;
                    if (dx * dx + dy * dy < 100)
                    {
                        shape.IsSelected = true;
                        sceneManager.SelectedShapeIndex = sceneManager.Shapes.IndexOf(shape);
                        sceneManager.SelectedVertexIndex = i;
                        canvas.Invalidate();
                        return;
                    }
                }
            }
        }


        private void HandleEdgeClick(Point mouseLocation)
        {
            foreach (var shape in sceneManager.Shapes)
            {
                Shape3D workingShape = shape.Clone();
                workingShape.ApplyTransformations();
                var projected = workingShape.Points.Select(p => Projection3D.Project(p, canvas.Size)).ToList();

                foreach (var face in workingShape.Faces)
                {
                    for (int i = 0; i < face.Count; i++)
                    {
                        int a = face[i];
                        int b = face[(i + 1) % face.Count];
                        PointF p1 = projected[a];
                        PointF p2 = projected[b];

                        float dist = DistanceToSegment(mouseLocation, p1, p2);
                        if (dist < 6)
                        {
                            shape.IsSelected = true;
                            sceneManager.SelectedEdge = Tuple.Create(a, b);
                            sceneManager.SelectedShapeIndex = sceneManager.Shapes.IndexOf(shape);
                            canvas.Invalidate();
                            return;
                        }
                    }
                }
            }
        }

        private void HandleFaceClick(Point mouseLocation)
        {
            foreach (var shape in sceneManager.Shapes)
            {
                Shape3D workingShape = shape.Clone();
                workingShape.ApplyTransformations();
                var projected = workingShape.Points.Select(p => Projection3D.Project(p, canvas.Size)).ToList();

                foreach (var face in workingShape.Faces)
                {
                    var poly = face.Select(index => projected[index]).ToArray();
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddPolygon(poly);
                        using (var region = new Region(path))
                        {
                            if (region.IsVisible(mouseLocation))
                            {
                                shape.IsSelected = true;
                                sceneManager.SelectedFace = face;
                                sceneManager.SelectedShapeIndex = sceneManager.Shapes.IndexOf(shape);

                                canvas.Invalidate();
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void HandlePaintClick(Point mouseLocation)
        {
            foreach (var shape in sceneManager.Shapes)
            {
                Shape3D workingShape = shape.Clone();
                workingShape.ApplyTransformations();
                var projected = workingShape.Points.Select(p => Projection3D.Project(p, canvas.Size)).ToList();

                foreach (var face in shape.Faces)
                {
                    var poly = face.Select(index => projected[index]).ToArray();
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddPolygon(poly);
                        using (var region = new Region(path))
                        {
                            if (region.IsVisible(mouseLocation))
                            {
                                shape.IsSelected = true;
                                shape.IsPainted = true;
                                sceneManager.SelectedFace = face;
                                sceneManager.SelectedShapeIndex = sceneManager.Shapes.IndexOf(shape);

                                shape.PaintColor = currentPaintColor;
                                canvas.Invalidate();
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void HandleObjectClick(Point mouseLocation)
        {
            foreach (var shape in sceneManager.Shapes)
            {
                Shape3D workingShape = shape.Clone();
                workingShape.ApplyTransformations();
                var projected = workingShape.Points.Select(p => Projection3D.Project(p, canvas.Size)).ToList();

                foreach (var face in workingShape.Faces)
                {
                    var poly = face.Select(index => projected[index]).ToArray();
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddPolygon(poly);
                        using (var region = new Region(path))
                        {
                            if (region.IsVisible(mouseLocation))
                            {
                                sceneManager.Shapes.ForEach(s => s.IsSelected = false);
                                shape.IsSelected = true;
                                canvas.Invalidate();
                                return;
                            }
                        }
                    }
                }
            }
        }

        private float DistanceToSegment(PointF p, PointF a, PointF b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            if (dx == 0 && dy == 0) return Distance(p, a);

            float t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));
            return Distance(p, new PointF(a.X + t * dx, a.Y + t * dy));
        }

        private float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public void UpdatePaintColor(Color color)
        {
            this.currentPaintColor = color;
        }

    }
}
