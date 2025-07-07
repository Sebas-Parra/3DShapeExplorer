using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Utils;

namespace _3D_SHAPE_EXPLORER.Models
{
    public abstract class Shape3D
    {
        public List<Point3D> Points { get; set; } = new List<Point3D>();
        public List<(int, int)> Edges { get; set; } = new List<(int, int)>();
        public List<List<int>> Faces { get; set; } = new List<List<int>>();


        //Selected items
        public int? SelectedVertexIndex { get; set; }
        public int? SelectedEdgeIndex { get; set; }
        public int? SelectedFaceIndex { get; set; }

        public bool IsSelected { get; set; }


        public float RotationX { get; set; } = 0;
        public float RotationY { get; set; } = 0;
        public float RotationZ { get; set; } = 0;

        public float ScaleFactor { get; set; } = 1f;

        public float TraslateX { get; set; } = 0;
        public float TraslateY { get; set; } = 0;
        public float TraslateZ { get; set; } = 0;

        public abstract void GenerateShape();

        public abstract Shape3D Clone();

        public List<Point3D> OriginalPoints { get; set; } = new List<Point3D>();

        public bool IsPainted { get; set; } = false;
        public Color PaintColor { get; set; } = Color.Gray;

        protected void CopyTransformationsTo(Shape3D other)
        {
            other.RotationX = this.RotationX;
            other.RotationY = this.RotationY;
            other.RotationZ = this.RotationZ;
            other.ScaleFactor = this.ScaleFactor;
            other.TraslateX = this.TraslateX;
            other.TraslateY = this.TraslateY;
            other.TraslateZ = this.TraslateZ;
            other.IsSelected = this.IsSelected;
        }

        public void ApplyTransformations()
        {
            // 1. Restaurar los puntos originales, ya centrados en el origen
            Points = OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();

            // 2. Aplicar las transformaciones directamente
            Rotate(RotationX, RotationY, RotationZ);
            ApplyScale(ScaleFactor);
            Traslate(TraslateX, TraslateY, TraslateZ);
        }




        public void ApplyScale(float factor)
        {
            foreach (var p in Points)
            {
                p.X *= factor;
                p.Y *= factor;
                p.Z *= factor;
            }
        }

        public void Traslate(float dx, float dy, float dz)
        {
            foreach (var p in Points)
            {
                p.X += dx;
                p.Y += dy;
                p.Z += dz;
            }
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            float radX = DegreesToRadians(angleX);
            float radY = DegreesToRadians(angleY);
            float radZ = DegreesToRadians(angleZ);

            foreach (var p in Points)
            {
                // Rotación en X
                float y1 = p.Y * (float)Math.Cos(radX) - p.Z * (float)Math.Sin(radX);
                float z1 = p.Y * (float)Math.Sin(radX) + p.Z * (float)Math.Cos(radX);
                p.Y = y1;
                p.Z = z1;

                // Rotación en Y
                float x2 = p.X * (float)Math.Cos(radY) + p.Z * (float)Math.Sin(radY);
                float z2 = -p.X * (float)Math.Sin(radY) + p.Z * (float)Math.Cos(radY);
                p.X = x2;
                p.Z = z2;

                // Rotación en Z
                float x3 = p.X * (float)Math.Cos(radZ) - p.Y * (float)Math.Sin(radZ);
                float y3 = p.X * (float)Math.Sin(radZ) + p.Y * (float)Math.Cos(radZ);
                p.X = x3;
                p.Y = y3;
            }
        }



        private float DegreesToRadians(float degrees)
        {
            return (float)(System.Math.PI / 180) * degrees;
        }


        public Point3D TransformPoint(Point3D p)
        {
            Point3D result = new Point3D(p.X, p.Y, p.Z);

            result.X *= ScaleFactor;
            result.Y *= ScaleFactor;
            result.Z *= ScaleFactor;

            float rx = DegreesToRadians(RotationX);
            float ry = DegreesToRadians(RotationY);
            float rz = DegreesToRadians(RotationZ);

            float x1 = result.X * (float)Math.Cos(rz) - result.Y * (float)Math.Sin(rz);
            float y1 = result.X * (float)Math.Sin(rz) + result.Y * (float)Math.Cos(rz);
            result.X = x1;
            result.Y = y1;

            float x2 = result.X * (float)Math.Cos(ry) + result.Z * (float)Math.Sin(ry);
            float z1 = -result.X * (float)Math.Sin(ry) + result.Z * (float)Math.Cos(ry);
            result.X = x2;
            result.Z = z1;

            float y2 = result.Y * (float)Math.Cos(rx) - result.Z * (float)Math.Sin(rx);
            float z2 = result.Y * (float)Math.Sin(rx) + result.Z * (float)Math.Cos(rx);
            result.Y = y2;
            result.Z = z2;

            result.X += TraslateX;
            result.Y += TraslateY;
            result.Z += TraslateZ;

            return result;
        }

        public List<PointF> GetProjectedPoints(Size panelSize, bool applyTransform = false)
        {
            var transformed = applyTransform
                ? Points.Select(p => TransformPoint(p))
                : Points;

            return transformed.Select(p => Projection3D.Project(p, panelSize)).ToList();
        }

        public bool IsFaceVisible(List<PointF> projected, List<int> face)
        {
            if (face.Count < 3) return false;

            var a = projected[face[0]];
            var b = projected[face[1]];
            var c = projected[face[2]];

            float cross = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            return cross < 0; 
        }


    }
}
