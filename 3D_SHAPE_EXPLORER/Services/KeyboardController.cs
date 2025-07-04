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

            // Rotación
            if (keys.Contains(Keys.NumPad4)) selectedShape.RotationX -= RotationStep;
            if (keys.Contains(Keys.NumPad6)) selectedShape.RotationX += RotationStep;
            if (keys.Contains(Keys.NumPad8)) selectedShape.RotationY -= RotationStep;
            if (keys.Contains(Keys.NumPad2)) selectedShape.RotationY += RotationStep;
            if (keys.Contains(Keys.A)) selectedShape.RotationZ -= RotationStep;
            if (keys.Contains(Keys.D)) selectedShape.RotationZ += RotationStep;

            // Escalado
            if (keys.Contains(Keys.W)) selectedShape.ScaleFactor += ScaleStep;
            if (keys.Contains(Keys.S)) selectedShape.ScaleFactor = Math.Max(0.1f, selectedShape.ScaleFactor - ScaleStep);

            // Traslación
            if (keys.Contains(Keys.J)) selectedShape.TranslateX -= TranslationStep;
            if (keys.Contains(Keys.L)) selectedShape.TranslateX += TranslationStep;
            if (keys.Contains(Keys.I)) selectedShape.TranslateY += TranslationStep;
            if (keys.Contains(Keys.K)) selectedShape.TranslateY -= TranslationStep;
            if (keys.Contains(Keys.U)) selectedShape.TranslateZ -= TranslationStep;
            if (keys.Contains(Keys.O)) selectedShape.TranslateZ += TranslationStep;

            targetCanvas.Invalidate(); // Redibuja
        }
    }
}
