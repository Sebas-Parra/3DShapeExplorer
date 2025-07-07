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

            Faces.AddRange(new[]
            {
                new List<int> { 0, 1, 2, 3 }, 
                new List<int> { 4, 5, 6, 7 }, 
                new List<int> { 0, 1, 5, 4 }, 
                new List<int> { 2, 3, 7, 6 }, 
                new List<int> { 1, 2, 6, 5 }, 
                new List<int> { 0, 3, 7, 4 }  
            });

            OriginalPoints = Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();


        }

        public override Shape3D Clone()
        {
            var clone = new Cube();
            clone.OriginalPoints = this.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();
            clone.Points = this.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();
            clone.Faces = this.Faces.Select(face => new List<int>(face)).ToList();
            clone.Edges = new List<(int, int)>(this.Edges);
            clone.IsPainted = this.IsPainted;
            this.CopyTransformationsTo(clone);
            return clone;
        }


    }
}
