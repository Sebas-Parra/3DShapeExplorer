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
            cmbFigures.PreviewKeyDown += (s, e) => e.IsInputKey = true;
            cmbFigures.KeyDown += (s, e) => e.SuppressKeyPress = true;
            cmbFigures.KeyPress += (s, e) => e.Handled = true;

            cmbFigures.SelectedIndexChanged += cmbFigures_SelectedIndexChanged;
            picCanvas.Paint += PanelCanvas_Paint;
            picCanvas.MouseClick += picCanvas_MouseClick;
            cmbMode.SelectedIndexChanged += ComboMode_SelectedIndexChanged;
            this.Load += ShapeExplorerForm_Load;




        }



        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {

            bool isInEditMode = rbtnVertexes.Checked || rbtnEdges.Checked || rbtnFaces.Checked;
            renderer.Draw(e.Graphics, sceneManager.Shapes, picCanvas.Size, sceneManager, isInEditMode);


        }

        private void ShapeExplorerForm_Load(object sender, EventArgs e)
        {
            rbtnVertexes.Visible = false;
            rbtnEdges.Visible = false;
            rbtnFaces.Visible = false;
            cmbMode.SelectedIndex = 0; 

        }

        private void cmbFigures_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selected = cmbFigures.SelectedItem.ToString();
            if (selected == lastSelected) return;

            lastSelected = selected;
            var shape = ShapeFactory.Create(selected);
            if (shape != null)
            {
                ShapeFactory.CentrarYGuardarOriginales(shape);  
                sceneManager.AddShape(shape);                   
                picCanvas.Invalidate();
            }



        }


        private void picCanvas_Click(object sender, EventArgs e)
        {

        }


        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            sceneManager.SelectedVertexIndex = null;
            sceneManager.SelectedEdge = null;
            sceneManager.SelectedFace = null;

            Point mouseLocation = e.Location;
            Size panelSize = picCanvas.Size;
            bool isInEditMode = rbtnVertexes.Checked || rbtnEdges.Checked || rbtnFaces.Checked;
            sceneManager.Shapes.ForEach(s => s.IsSelected = false);


            if (rbtnVertexes.Checked)
            {
                foreach (var shape in sceneManager.Shapes)
                {

                    Shape3D workingShape = shape.Clone();
                    workingShape.ApplyTransformations();
                    var projected = workingShape.Points
                        .Select(p => Projection3D.Project(p, panelSize))
                        .ToList();



                    for (int i = 0; i < projected.Count; i++)
                    {
                        float dx = projected[i].X - mouseLocation.X;
                        float dy = projected[i].Y - mouseLocation.Y;
                        if (dx * dx + dy * dy < 100) 
                        {
                            shape.IsSelected = true;


                            sceneManager.SelectedVertexIndex = i;
                            sceneManager.SelectedEdge = null;
                            sceneManager.SelectedFace = null;
                            picCanvas.Invalidate();
                            return;
                        }
                    }
                }
            }
            else if (rbtnEdges.Checked)
            {
                foreach (var shape in sceneManager.Shapes)
                {

                    Shape3D workingShape = shape.Clone();
                    workingShape.ApplyTransformations();
                    var projected = workingShape.Points
                        .Select(p => Projection3D.Project(p, panelSize))
                        .ToList();



                    foreach (var face in workingShape.Faces)
                    {
                        for (int i = 0; i < face.Count; i++)
                        {
                            int a = face[i];
                            int b = face[(i + 1) % face.Count];
                            PointF p1 = projected[a];
                            PointF p2 = projected[b];

                            float dist = DistanceToSegment(mouseLocation, p1, p2);
                            if (dist < 6)
                            {
                                shape.IsSelected = true;

                                sceneManager.SelectedEdge = Tuple.Create(a, b);
                                sceneManager.SelectedVertexIndex = null;
                                sceneManager.SelectedFace = null;
                                picCanvas.Invalidate();
                                return;
                            }
                        }
                    }
                }
            }
            else if (rbtnFaces.Checked)
            {
                foreach (var shape in sceneManager.Shapes)
                {

                    Shape3D workingShape = shape.Clone();
                    workingShape.ApplyTransformations();
                    var projected = workingShape.Points
                        .Select(p => Projection3D.Project(p, panelSize))
                        .ToList();



                    foreach (var face in workingShape.Faces)
                    {
                        var poly = face.Select(index => projected[index]).ToArray();
                        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            path.AddPolygon(poly);
                            using (var region = new Region(path))
                            {
                                if (region.IsVisible(mouseLocation))
                                {
                                    shape.IsSelected = true;


                                    sceneManager.SelectedFace = face;
                                    sceneManager.SelectedEdge = null;
                                    sceneManager.SelectedVertexIndex = null;
                                    picCanvas.Invalidate();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Modo Object: selecciona figura
                foreach (var shape in sceneManager.Shapes)
                {

                    Shape3D workingShape = shape.Clone();
                    workingShape.ApplyTransformations();
                    var projected = workingShape.Points.Select(p => Projection3D.Project(p, panelSize)).ToList();




                    foreach (var face in workingShape.Faces)
                    {
                        if (!workingShape.IsFaceVisible(projected, face)) continue;

                        var poly = face.Select(index => projected[index]).ToArray();
                        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            path.AddPolygon(poly);
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

        private float DistanceToSegment(PointF p, PointF a, PointF b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            if (dx == 0 && dy == 0) return Distance(p, a);

            float t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));
            return Distance(p, new PointF(a.X + t * dx, a.Y + t * dy));
        }

        private float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }



        private void chkFaces_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedItem?.ToString() == "Edition Mode")
            {
                rbtnVertexes.Visible = true;
                rbtnEdges.Visible = true;
                rbtnFaces.Visible = true;

            }
            else
            {
                rbtnVertexes.Visible = false;
                rbtnEdges.Visible = false;
                rbtnFaces.Visible = false;

                rbtnVertexes.Checked = false;
                rbtnEdges.Checked = false;
                rbtnFaces.Checked = false;

                sceneManager.SelectedVertexIndex = null;
                sceneManager.SelectedEdge = null;
                sceneManager.SelectedFace = null;

            }
        }


    }
}
