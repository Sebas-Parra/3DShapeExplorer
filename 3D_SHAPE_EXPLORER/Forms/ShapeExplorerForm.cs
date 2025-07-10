using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D_SHAPE_EXPLORER.Models;
using _3D_SHAPE_EXPLORER.Services;
using _3D_SHAPE_EXPLORER.Utils;
using Guna.UI2.WinForms;

namespace _3D_SHAPE_EXPLORER
{
    public partial class ShapeExplorerForm : Form
    {
        private SceneManager sceneManager = new SceneManager();
        private ShapeRenderer renderer = new ShapeRenderer();
        private KeyboardController inputController;
        private string lastSelected = "";
        private Color currentPaintColor = Color.Yellow;
        private ContextMenuStrip colorMenu;
        private MouseClickHandler mouseClickHandler;

        public ShapeExplorerForm()
        {
            InitializeComponent();
            gunacmbFigures.SelectedIndexChanged += GunacmbFigures_SelectedIndexChanged;
            gunacmbMode.SelectedIndexChanged += GunacmbMode_SelectedIndexChanged;

            SetupComboBoxFigures();
            SetupComboBoxMode();

            sceneManager.Initialize();
            inputController = new KeyboardController(this, picCanvas, sceneManager);

            picCanvas.Paint += PanelCanvas_Paint;
            mouseClickHandler = new MouseClickHandler(sceneManager, picCanvas,
                            gunarbtnVertexes, gunarbtnEdges, gunarbtnFaces, gunarbtnPaintFigures, currentPaintColor);
            picCanvas.MouseClick += picCanvas_MouseClick;
            this.Load += ShapeExplorerForm_Load;
        }



        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            bool isInEditMode = gunarbtnVertexes.Checked || gunarbtnEdges.Checked || gunarbtnFaces.Checked;
            renderer.Draw(e.Graphics, sceneManager.Shapes, picCanvas.Size, sceneManager, isInEditMode, currentPaintColor);

        }

        private void ShapeExplorerForm_Load(object sender, EventArgs e)
        {
            gunarbtnVertexes.Visible = false;
            gunarbtnEdges.Visible = false;
            gunarbtnFaces.Visible = false;
            gunarbtnPaintFigures.Visible = false;
 
            gunacmbMode.SelectedIndex = 0;
            gunbtnSelectColor.Visible = false;

            string imagePath = Path.Combine(Application.StartupPath, "Resources", "paint_bucket.png");
            if (File.Exists(imagePath))
            {
                gunbtnSelectColor.Image = Image.FromFile(imagePath);
                gunbtnSelectColor.ImageSize = new Size(24, 24); // Tamaño del ícono
                gunbtnSelectColor.Text = "";                    // Quitar texto
                gunbtnSelectColor.TextAlign = HorizontalAlignment.Center;
                gunbtnSelectColor.ImageAlign = HorizontalAlignment.Center;
                gunbtnSelectColor.FillColor = Color.Transparent; // Opcional: sin fondo
                gunbtnSelectColor.BorderThickness = 0;           // Opcional: sin bordes
            }

        }



        private void picCanvas_Click(object sender, EventArgs e)
        {

        }


        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            
            mouseClickHandler.HandleMouseClick(e.Location);
        }

        



        private void chkFaces_CheckedChanged(object sender, EventArgs e)
        {

        }



       

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            
        }



        private void SetupComboBoxMode()
        {
            gunacmbMode.Items.Clear();
            gunacmbMode.Items.Add(new ComboBoxItem("📦 Object Mode", "object"));
            gunacmbMode.Items.Add(new ComboBoxItem("✏️ Edition Mode", "edit"));
            gunacmbMode.SelectedIndex = 0;
            gunacmbMode.Font = new Font("Segoe UI Emoji", 11);
        }

        private void SetupComboBoxFigures()
        {
            gunacmbFigures.Items.Clear();
            gunacmbFigures.Items.Add(new ComboBoxItem("🧩 Select a figure...", ""));
            gunacmbFigures.Items.Add(new ComboBoxItem("🧊 Cube", "Cube"));
            gunacmbFigures.Items.Add(new ComboBoxItem("🧱 Cylinder", "Cylinder"));
            gunacmbFigures.Items.Add(new ComboBoxItem("🧿 Dodecagonal", "DodecagonalPrism"));
            gunacmbFigures.Items.Add(new ComboBoxItem("🔶 Octahedron", "Octahedron"));
            gunacmbFigures.Items.Add(new ComboBoxItem("🔺 Pyramid", "Pyramid"));
            gunacmbFigures.SelectedIndex = 0;
            gunacmbFigures.Font = new Font("Segoe UI Emoji", 11);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GunacmbFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gunacmbFigures.SelectedItem is ComboBoxItem selectedItem)
            {
                string value = selectedItem.Value;

                if (string.IsNullOrEmpty(value))
                    return;

                //if (value == lastSelected) return;

                lastSelected = value;
                var shape = ShapeFactory.Create(value);
                if (shape != null)
                {
                    //ShapeFactory.CentrarYGuardarOriginales(shape);
                    sceneManager.AddShape(shape);
                    picCanvas.Invalidate();
                }
            }
        }

        private void GunacmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gunacmbMode.SelectedItem is ComboBoxItem selectedItem)
            {
                string modeValue = selectedItem.Value;

                if (modeValue == "edit")
                {

                    gunarbtnVertexes.Visible = true;
                    gunarbtnEdges.Visible = true;
                    gunarbtnFaces.Visible = true;
                    gunarbtnPaintFigures.Visible = true;

                    gunbtnSelectColor.Visible = gunarbtnPaintFigures.Checked;
                }
                else
                {

                    gunarbtnVertexes.Visible = false;
                    gunarbtnEdges.Visible = false;
                    gunarbtnPaintFigures.Visible = false;
                    gunarbtnFaces.Visible = false;

                    gunarbtnVertexes.Checked = false;
                    gunarbtnEdges.Checked = false;
                    gunarbtnFaces.Checked = false;
                    gunarbtnPaintFigures.Checked = false;

                    sceneManager.SelectedVertexIndex = null;
                    sceneManager.SelectedEdge = null;
                    sceneManager.SelectedFace = null;
                    gunbtnSelectColor.Visible = false;
                }
            }
        }

        private void gunarbtnPaintFigures_CheckedChanged(object sender, EventArgs e)
        {
            gunbtnSelectColor.Visible = gunarbtnPaintFigures.Checked;
        }

        private void gunbtnSelectColor_Click(object sender, EventArgs e)
        {
            var colores = new List<Color> { Color.Black, Color.White, Color.Orange, Color.Gold, Color.Green, Color.Teal,
                                     Color.MidnightBlue, Color.DarkGray, Color.HotPink, Color.MediumPurple };

            var colorForm = new ColorPickerForm(colores);
            var buttonLocation = gunbtnSelectColor.PointToScreen(Point.Empty);
            colorForm.Location = new Point(buttonLocation.X, buttonLocation.Y + gunbtnSelectColor.Height);

            if (colorForm.ShowDialog() == DialogResult.OK)
            {
                currentPaintColor = colorForm.SelectedColor;
                gunbtnSelectColor.BackColor = currentPaintColor;

                mouseClickHandler.UpdatePaintColor(currentPaintColor);

            }
        }
    }
}
