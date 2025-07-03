using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class FigureRotation
    {
        public static void Rotate(List<Point3D> points, float angleX, float angleY, float angleZ)
        {
            float radX = angleX * (float)Math.PI / 180;
            float radY = angleY * (float)Math.PI / 180;
            float radZ = angleZ * (float)Math.PI / 180;

            foreach (var p in points)
            {
                //Rotation around X
                float y1 = p.Y * (float)Math.Cos(radX) - p.Z * (float)Math.Sin(radX);
                float z1 = p.Y * (float)Math.Sin(radX) + p.Z * (float)Math.Cos(radX);
                p.Y = y1; p.Z = z1;
                //Rotation around Y
                float x2 = p.X * (float)Math.Cos(radY) + p.Z * (float)Math.Sin(radY);
                float z2 = -p.X * (float)Math.Sin(radY) + p.Z * (float)Math.Cos(radY);
                p.X = x2; p.Z = z2;
                //Rotation around Z
                float x3 = p.X * (float)Math.Cos(radZ) - p.Y * (float)Math.Sin(radZ);
                float y3 = p.X * (float)Math.Sin(radZ) + p.Y * (float)Math.Cos(radZ);
                p.X = x3; p.Y = y3;
            }
        }
    }
}
