using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_SHAPE_EXPLORER.Models
{
    public class Cylinder : Shape3D
    {
        public override void GenerateShape()
        {
            int segments = 20;
            float radius = 50;
            float height = 100;

            Points.Clear();
            Edges.Clear();

            for (int i = 0; i < segments; i++)
            {
                float angle = (float)(2 * Math.PI * i / segments);
                float x = radius * (float)Math.Cos(angle);
                float z = radius * (float)Math.Sin(angle);

                Points.Add(new Point3D(x, height / 2, z));  
                Points.Add(new Point3D(x, -height / 2, z)); 
            }

            for (int i = 0; i < segments; i++)
            {
                int top1 = i * 2;
                int bottom1 = top1 + 1;
                int top2 = (top1 + 2) % (segments * 2);
                int bottom2 = (bottom1 + 2) % (segments * 2);

                Edges.Add((top1, top2));
                Edges.Add((bottom1, bottom2));
            }

            for (int i = 0; i < segments; i += segments / 4)
            {
                int top = i * 2;
                int bottom = top + 1;
                Edges.Add((top, bottom));
            }

            for (int i = 0; i < segments; i++)
            {
                int next = (i + 1) % segments;

                int top1 = i * 2;
                int top2 = next * 2;
                int bottom1 = top1 + 1;
                int bottom2 = top2 + 1;

                Faces.Add(new List<int> { top1, top2, bottom2, bottom1 });
            }

            List<int> topFace = new List<int>();
            for (int i = 0; i < segments; i++)
                topFace.Add(i * 2);
            topFace.Reverse(); 
            Faces.Add(topFace);

            List<int> bottomFace = new List<int>();
            for (int i = 0; i < segments; i++)
                bottomFace.Add(i * 2 + 1);
            Faces.Add(bottomFace);


            OriginalPoints = Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();

        }

        public override Shape3D Clone()
        {
            var clone = new Cylinder();
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
