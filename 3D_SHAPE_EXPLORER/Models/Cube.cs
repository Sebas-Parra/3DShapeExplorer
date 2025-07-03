using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_SHAPE_EXPLORER.Models
{
    public class Cube : Shape3D
    {
        public override void GenerateShape()
        {
            float s = 50;
            Points.Clear();
            Edges.Clear();

            Points.AddRange(new[] {
                new Point3D(-s, -s, -s), new Point3D(s, -s, -s),
                new Point3D(s, s, -s), new Point3D(-s, s, -s),
                new Point3D(-s, -s, s), new Point3D(s, -s, s),
                new Point3D(s, s, s), new Point3D(-s, s, s)
            });

            Edges.AddRange(new[] {
                (0,1),(1,2),(2,3),(3,0),
                (4,5),(5,6),(6,7),(7,4),
                (0,4),(1,5),(2,6),(3,7)
            });
        }
    }
}
