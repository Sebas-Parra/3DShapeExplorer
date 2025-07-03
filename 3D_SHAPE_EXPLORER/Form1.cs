using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Services;
using _3D_SHAPE_EXPLORER.Utils;

namespace _3D_SHAPE_EXPLORER
{
    public partial class Form1 : Form
    {
        private Shape3D currentShape;
        private float rotX = 0, rotY = 0, rotZ = 0;
        private KeyboardController inputController;
        public Form1()
        {
            InitializeComponent();
            InitializeScene();

            inputController = new KeyboardController(this, picCanvas);
        }

        private void InitializeScene()
        {
            currentShape = new Cube();
            currentShape.GenerateShape();
            picCanvas.Paint += PanelCanvas_Paint;
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (currentShape == null) return;

            inputController.GetTransformations(out rotX, out rotY, out rotZ,
                                   out float scale, out float dx, out float dy, out float dz);



            var shapeCopy = new Cube();
            //var shapeCopy = new Pyramid();
            shapeCopy.GenerateShape();
            shapeCopy.Scale(inputController.ScaleFactor);
            shapeCopy.Rotate(rotX, rotY, rotZ);
            shapeCopy.Translate(dx, dy, dz);


            foreach (var edge in shapeCopy.Edges)
            {
                var p1 = Projection3D.Project(shapeCopy.Points[edge.Item1], picCanvas.Size);
                var p2 = Projection3D.Project(shapeCopy.Points[edge.Item2], picCanvas.Size);
                e.Graphics.DrawLine(Pens.Black, p1, p2);
            }

        }

        private void trackRotY_Scroll(object sender, EventArgs e)
        {
            rotY = trackRotY.Value;
            picCanvas.Invalidate();
        }

        private void trackRotZ_Scroll(object sender, EventArgs e)
        {
            rotZ = trackRotZ.Value;
            picCanvas.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picCanvas_Click(object sender, EventArgs e)
        {

        }

        private void trackRotX_Scroll(object sender, EventArgs e)
        {
            rotX = trackRotX.Value;
            picCanvas.Invalidate();
        }

       

    }
}
