using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_SHAPE_EXPLORER.Services
{
    public class KeyboardController
    {
        private readonly Timer timer = new Timer();
        private readonly HashSet<Keys> keys = new HashSet<Keys>();
        private readonly Control targetCanvas;

        public float RotX { get; private set; }
        public float RotY { get; private set; }
        public float RotZ { get; private set; }

        public float ScaleFactor { get; private set; } = 1f;
        private const float scaleStep = 0.05f;

        public float TranslateX { get; private set; }
        public float TranslateY { get; private set; }
        public float TranslateZ { get; private set; }

        private const float transStep = 2f;

        public KeyboardController(Form form, Control canvas)
        {
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
            int step = 2;
            //Rotation
            if (keys.Contains(Keys.Up)) RotX -= step;
            if (keys.Contains(Keys.Down)) RotX += step;
            if (keys.Contains(Keys.Left)) RotY -= step;
            if (keys.Contains(Keys.Right)) RotY += step;
            if (keys.Contains(Keys.A)) RotZ -= step;
            if (keys.Contains(Keys.D)) RotZ += step;

            //Scale
            if (keys.Contains(Keys.W)) ScaleFactor += scaleStep;
            if (keys.Contains(Keys.S)) ScaleFactor = Math.Max(0.1f, ScaleFactor - scaleStep); // evita que sea negativo

            //Traslation
            if (keys.Contains(Keys.J)) TranslateX -= transStep;
            if (keys.Contains(Keys.L)) TranslateX += transStep;
            if (keys.Contains(Keys.I)) TranslateY += transStep;
            if (keys.Contains(Keys.K)) TranslateY -= transStep;
            if (keys.Contains(Keys.U)) TranslateZ -= transStep;
            if (keys.Contains(Keys.O)) TranslateZ += transStep;

            targetCanvas.Invalidate(); // Redibuja
        }

        public void GetTransformations(out float rotX, out float rotY, out float rotZ,
                                       out float scale, out float dx, out float dy, out float dz)
        {
            rotX = RotX;
            rotY = RotY;
            rotZ = RotZ;
            scale = ScaleFactor;
            dx = TranslateX;
            dy = TranslateY;
            dz = TranslateZ;
        }
    }
}
