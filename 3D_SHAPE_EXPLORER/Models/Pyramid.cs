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

            Faces.AddRange(new List<List<int>>
            {
                new List<int> {0, 1, 2, 3},   
                new List<int> {0, 1, 4},      
                new List<int> {1, 2, 4},     
                new List<int> {2, 3, 4},     
                new List<int> {3, 0, 4}       
            });

            OriginalPoints = Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();

        }

        public override Shape3D Clone()
        {
            var clone = new Pyramid();
            clone.OriginalPoints = this.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();
            clone.Points = clone.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList(); 
            clone.Faces = this.Faces.Select(face => new List<int>(face)).ToList();
            clone.Edges = new List<(int, int)>(this.Edges);
            clone.IsPainted = this.IsPainted;
            this.CopyTransformationsTo(clone);
            return clone;
        }


    }
}
