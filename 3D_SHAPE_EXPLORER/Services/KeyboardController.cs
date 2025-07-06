using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D_SHAPE_EXPLORER.Models;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class KeyboardController
    {
        private readonly Timer timer = new Timer();
        private readonly HashSet<Keys> keys = new HashSet<Keys>();
        private readonly Control targetCanvas;
        private readonly SceneManager sceneManager;

        private const float RotationStep = 2f;
        private const float ScaleStep = 0.05f;
        private const float TranslationStep = 2f;


        public KeyboardController(Form form, Control canvas, SceneManager manager)
        {
            sceneManager = manager;
            targetCanvas = canvas;

            form.KeyPreview = true;
            form.KeyDown += (s, e) => keys.Add(e.KeyCode);
            form.KeyDown += HandleDeleteKey;
            form.KeyUp += (s, e) => keys.Remove(e.KeyCode);


            timer.Interval = 20;
            timer.Tick += (s, e) => UpdateTransformations();
            timer.Start();
        }

        private void UpdateTransformations()
        {
            Shape3D selectedShape = sceneManager.Shapes.Find(s => s.IsSelected);
            if (selectedShape == null)
                return;

            bool somethingTransformed = false;




            if (sceneManager.SelectedVertexIndex.HasValue)
            {
                int index = sceneManager.SelectedVertexIndex.Value;
                ApplyTransformationToPoint(selectedShape.OriginalPoints[index]);
                somethingTransformed = true;
            }

            else if (sceneManager.SelectedEdge != null)
            {
                var (i1, i2) = sceneManager.SelectedEdge;
                ApplyTransformationToPoint(selectedShape.OriginalPoints[i1]);
                ApplyTransformationToPoint(selectedShape.OriginalPoints[i2]);
                somethingTransformed = true;
            }

            else if (sceneManager.SelectedFace != null)
            {
                foreach (var index in sceneManager.SelectedFace)
                {
                    ApplyTransformationToPoint(selectedShape.OriginalPoints[index]);

                }

                somethingTransformed = true;
            }

            if (!somethingTransformed)
            {
                // Rotation
                if (keys.Contains(Keys.NumPad4)) selectedShape.RotationX -= RotationStep;
                if (keys.Contains(Keys.NumPad6)) selectedShape.RotationX += RotationStep;
                if (keys.Contains(Keys.NumPad8)) selectedShape.RotationY -= RotationStep;
                if (keys.Contains(Keys.NumPad2)) selectedShape.RotationY += RotationStep;
                if (keys.Contains(Keys.A)) selectedShape.RotationZ -= RotationStep;
                if (keys.Contains(Keys.D)) selectedShape.RotationZ += RotationStep;

                // Scale
                if (keys.Contains(Keys.W)) selectedShape.ScaleFactor += ScaleStep;
                if (keys.Contains(Keys.S)) selectedShape.ScaleFactor = Math.Max(0.1f, selectedShape.ScaleFactor - ScaleStep);

                // Traslate
                if (keys.Contains(Keys.J)) selectedShape.TraslateX -= TranslationStep;
                if (keys.Contains(Keys.L)) selectedShape.TraslateX += TranslationStep;
                if (keys.Contains(Keys.I)) selectedShape.TraslateY += TranslationStep;
                if (keys.Contains(Keys.K)) selectedShape.TraslateY -= TranslationStep;
                if (keys.Contains(Keys.U)) selectedShape.TraslateZ -= TranslationStep;
                if (keys.Contains(Keys.O)) selectedShape.TraslateZ += TranslationStep;
            }

            targetCanvas.Invalidate();
        }

        private void ApplyTransformationToPoint(Point3D point)
        {
            if (keys.Contains(Keys.J)) point.X -= TranslationStep;
            if (keys.Contains(Keys.L)) point.X += TranslationStep;
            if (keys.Contains(Keys.I)) point.Y += TranslationStep;
            if (keys.Contains(Keys.K)) point.Y -= TranslationStep;
            if (keys.Contains(Keys.U)) point.Z -= TranslationStep;
            if (keys.Contains(Keys.O)) point.Z += TranslationStep;

            if (keys.Contains(Keys.W))
            {
                point.X *= 1 + ScaleStep;
                point.Y *= 1 + ScaleStep;
                point.Z *= 1 + ScaleStep;
            }
            if (keys.Contains(Keys.S))
            {
                point.X *= 1 - ScaleStep;
                point.Y *= 1 - ScaleStep;
                point.Z *= 1 - ScaleStep;
            }
        }



        private void HandleDeleteKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Shape3D selectedShape = sceneManager.Shapes.Find(s => s.IsSelected);
                if (selectedShape != null)
                {
                    var result = MessageBox.Show(
                        "¿Deseas eliminar la figura seleccionada?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        sceneManager.Shapes.Remove(selectedShape);
                        targetCanvas.Invalidate(); 
                    }
                }
            }
        }

        


    }
}
