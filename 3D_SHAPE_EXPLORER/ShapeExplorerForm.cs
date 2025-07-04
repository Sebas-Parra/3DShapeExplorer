using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Services;
using _3D_SHAPE_EXPLORER.Utils;

namespace _3D_SHAPE_EXPLORER
{
    public partial class ShapeExplorerForm : Form
    {
        private SceneManager sceneManager = new SceneManager();
        private ShapeRenderer renderer = new ShapeRenderer();
        private KeyboardController inputController;
        private string lastSelected = "";
        public ShapeExplorerForm()
        {
            InitializeComponent();
            sceneManager.Initialize();
            inputController = new KeyboardController(this, picCanvas, sceneManager);
            cmbFigures.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFigures.SelectedIndexChanged += cmbFigures_SelectedIndexChanged;
            picCanvas.Paint += PanelCanvas_Paint;
            picCanvas.MouseClick += picCanvas_MouseClick;

        }



        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {

            renderer.Draw(e.Graphics, sceneManager.Shapes, picCanvas.Size);


        }

        private void ShapeExplorerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbFigures.SelectedItem.ToString();
            if (selected == lastSelected) return;

            lastSelected = selected;
            var shape = ShapeFactory.Create(selected);
            if (shape != null)
            {
                sceneManager.AddShape(shape);
                picCanvas.Invalidate();
            }
        }


        private void picCanvas_Click(object sender, EventArgs e)
        {

        }


        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.Location;
            Size panelSize = picCanvas.Size;

            foreach (var shape in sceneManager.Shapes)
            {
                var copy = shape.Clone();
                copy.ApplyTransformations();

                var projectedPoints = copy.Points
                    .Select(p => Projection3D.Project(p, panelSize))
                    .ToList();

                foreach (var face in copy.Faces)
                {
                    var polygon = face.Select(index => projectedPoints[index]).ToArray();

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        path.AddPolygon(polygon);
                        using (var region = new Region(path))
                        {
                            if (region.IsVisible(mouseLocation))
                            {
                                sceneManager.Shapes.ForEach(s => s.IsSelected = false);
                                shape.IsSelected = true;
                                picCanvas.Invalidate();
                                return;
                            }
                        }
                    }
                }
            }

            sceneManager.Shapes.ForEach(s => s.IsSelected = false);
            picCanvas.Invalidate();
        }
    }
}
