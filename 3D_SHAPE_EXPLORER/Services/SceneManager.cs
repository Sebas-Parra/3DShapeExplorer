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
            shape.TranslateX = spacing * Shapes.Count;
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

                selected.TranslateX = 0;
                selected.TranslateY = 0;
                selected.TranslateZ = 0;
            }
        }

    }
}
