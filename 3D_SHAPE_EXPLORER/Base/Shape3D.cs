using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_SHAPE_EXPLORER.Models
{
    public abstract class Shape3D
    {
        public List<Point3D> Points { get; set; } = new List<Point3D>();
        public List<(int, int)> Edges { get; set; } = new List<(int, int)>();
        public List<List<int>> Faces { get; set; } = new List<List<int>>();

        public bool IsSelected { get; set; }


        public float RotationX { get; set; } = 0;
        public float RotationY { get; set; } = 0;
        public float RotationZ { get; set; } = 0;

        public float ScaleFactor { get; set; } = 1f;

        public float TranslateX { get; set; } = 0;
        public float TranslateY { get; set; } = 0;
        public float TranslateZ { get; set; } = 0;

        public abstract void GenerateShape();

        public abstract Shape3D Clone();

        public List<Point3D> OriginalPoints { get; set; } = new List<Point3D>();


        protected void CopyTransformationsTo(Shape3D other)
        {
            other.RotationX = this.RotationX;
            other.RotationY = this.RotationY;
            other.RotationZ = this.RotationZ;
            other.ScaleFactor = this.ScaleFactor;
            other.TranslateX = this.TranslateX;
            other.TranslateY = this.TranslateY;
            other.TranslateZ = this.TranslateZ;
            other.IsSelected = this.IsSelected;
        }

        public void ApplyTransformations()
        {
            ApplyScale(ScaleFactor);
            Rotate(RotationX, RotationY, RotationZ);
            Translate(TranslateX, TranslateY, TranslateZ);
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

        public void Translate(float dx, float dy, float dz)
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
                float y1 = p.Y * (float)System.Math.Cos(radX) - p.Z * (float)System.Math.Sin(radX);
                float z1 = p.Y * (float)System.Math.Sin(radX) + p.Z * (float)System.Math.Cos(radX);
                p.Y = y1;
                p.Z = z1;

                // Rotación en Y
                float x2 = p.X * (float)System.Math.Cos(radY) + p.Z * (float)System.Math.Sin(radY);
                float z2 = -p.X * (float)System.Math.Sin(radY) + p.Z * (float)System.Math.Cos(radY);
                p.X = x2;
                p.Z = z2;

                // Rotación en Z
                float x3 = p.X * (float)System.Math.Cos(radZ) - p.Y * (float)System.Math.Sin(radZ);
                float y3 = p.X * (float)System.Math.Sin(radZ) + p.Y * (float)System.Math.Cos(radZ);
                p.X = x3;
                p.Y = y3;
            }
        }

        private float DegreesToRadians(float degrees)
        {
            return (float)(System.Math.PI / 180) * degrees;
        }
    }
}
