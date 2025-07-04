using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _3D_SHAPE_EXPLORER.Models
{
    public class DodecagonalPrism : Shape3D
    {
        public override void GenerateShape()
        {
            int segments = 12;
            float radius = 40;
            float height = 100;

            Points.Clear();
            Edges.Clear();
            Faces.Clear();

            for (int i = 0; i < segments; i++)
            {
                float angle = (float)(2 * Math.PI * i / segments);
                float x = radius * (float)Math.Cos(angle);
                float z = radius * (float)Math.Sin(angle);

                Points.Add(new Point3D(x, height / 2, z));  // superior
                Points.Add(new Point3D(x, -height / 2, z)); // inferior
            }

            for (int i = 0; i < segments; i++)
            {
                int top1 = i * 2;
                int bot1 = top1 + 1;
                int top2 = (top1 + 2) % (segments * 2);
                int bot2 = (bot1 + 2) % (segments * 2);

                Edges.Add((top1, top2));   
                Edges.Add((bot1, bot2));   
                Edges.Add((top1, bot1));   

                Faces.Add(new List<int> { top1, top2, bot2, bot1 });
            }

            List<int> topFace = new List<int>();
            for (int i = 0; i < segments; i++)
                topFace.Add(i * 2);
            Faces.Add(topFace);

            List<int> bottomFace = new List<int>();
            for (int i = segments - 1; i >= 0; i--)
                bottomFace.Add(i * 2 + 1);
            Faces.Add(bottomFace);

            OriginalPoints = Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();

        }


        public override Shape3D Clone()
        {
            var clone = new DodecagonalPrism();
            clone.OriginalPoints = this.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();
            clone.Points = clone.OriginalPoints.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList(); 
            clone.Faces = this.Faces.Select(face => new List<int>(face)).ToList();
            clone.Edges = new List<(int, int)>(this.Edges);

            this.CopyTransformationsTo(clone);
            return clone;
        }


    }
}
