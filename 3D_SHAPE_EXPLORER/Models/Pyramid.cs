using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _3D_SHAPE_EXPLORER.Models
{
    public class Pyramid : Shape3D
    {
        public override void GenerateShape()
        {
            float s = 50;
            Points.Clear();
            Edges.Clear();

            Points.AddRange(new[] {
                new Point3D(-s, -s, -s), 
                new Point3D(s, -s, -s),
                new Point3D(s, -s, s), 
                new Point3D(-s, -s, s),
                new Point3D(0, s, 0)
            });

            Edges.AddRange(new[]
            {
                (0,1),(1,2),(2,3),(3, 0),
                (0,4),(1,4),(2,4),(3,4)
            });
        }
    }
}
