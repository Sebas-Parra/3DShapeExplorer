using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_SHAPE_EXPLORER.Models
{
    public abstract class Shape3D
    {
        public List<Point3D> Points { get; protected set;  } = new List<Point3D>();
        public List<(int, int)> Edges { get; protected set; } = new List<(int, int)> { };

        public abstract void GenerateShape();

        public virtual void Translate(float dx, float dy, float dz)
                => Services.FigureTranslation.Translation(Points, dx, dy, dz);

        public virtual void Scale(float factor)
                => Services.FigureScale.Scale(Points, factor);

        public virtual void Rotate(float angleX, float angleY, float angleZ)
                => Services.FigureRotation.Rotate(Points, angleX, angleY, angleZ);
    }
}
