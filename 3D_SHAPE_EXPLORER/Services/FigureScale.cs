using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class FigureScale
    {
        public static void Scale(List<Point3D> points, float factor)
        {
            foreach(var p in points)
            {
                p.X *= factor;
                p.Y *= factor;
                p.Z *= factor;
            }
        }
    }
}
