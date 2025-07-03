using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class FigureTranslation
    {
        public static void Translation(List<Point3D> points, float dx, float dy, float dz)
        {
            foreach (var p in points)
            {
                p.X += dx;
                p.Y += dy;
                p.Z += dz;
            }
        }
    }
}
