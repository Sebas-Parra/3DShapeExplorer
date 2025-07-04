using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Utils
{
    public class ShapeFactory
    {
        public static Shape3D Create(string name)
        {
            switch (name)
            {
                case "Cube": return new Cube();
                case "Pyramid": return new Pyramid();
                case "Octahedron": return new Octahedron();
                case "Cylinder": return new Cylinder();
                case "DodecagonalPrism": return new DodecagonalPrism();
                default: return null;
            }
        }

    }
}
