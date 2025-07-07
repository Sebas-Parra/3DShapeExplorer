using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class SceneManager
    {
        public List<Shape3D> Shapes { get; private set; } = new List<Shape3D>();

        public int? SelectedVertexIndex = null;                    
        public Tuple<int, int> SelectedEdge = null;                
        public List<int> SelectedFace = null;                      


        public void Initialize()
        {
            var cube = new Cube();
            cube.GenerateShape();
            Shapes.Add(cube);
        }

        public void AddShape(Shape3D shape)
        {
            float spacing = 120f;
            shape.GenerateShape();

            float centerX = shape.Points.Average(p => p.X);
            float centerY = shape.Points.Average(p => p.Y);
            float centerZ = shape.Points.Average(p => p.Z);

            shape.Traslate(-centerX, -centerY, -centerZ);

            shape.OriginalPoints = shape.Points.Select(p => new Point3D(p.X, p.Y, p.Z)).ToList();

            shape.TraslateX = spacing * Shapes.Count;

            shape.ApplyTransformations();

            Shapes.Add(shape);
        }





        public void ResetSelectedShape()
        {
            var selected = Shapes.FirstOrDefault(s => s.IsSelected);
            if (selected != null)
            {
                selected.RotationX = 0;
                selected.RotationY = 0;
                selected.RotationZ = 0;

                selected.ScaleFactor = 1f;

                selected.TraslateX = 0;
                selected.TraslateY = 0;
                selected.TraslateZ = 0;
            }
        }

    }
}
