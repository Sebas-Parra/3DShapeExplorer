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
        private Color currentPaintColor = Color.Yellow;
        private ContextMenuStrip colorMenu;
        private MouseClickHandler mouseClickHandler;

        public ShapeExplorerForm()
        {
            InitializeComponent();
            SetupComboBoxFigures();
            SetupComboBoxMode();

            sceneManager.Initialize();
            inputController = new KeyboardController(this, picCanvas, sceneManager);
            cmbFigures.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFigures.PreviewKeyDown += (s, e) => e.IsInputKey = true;
            cmbFigures.KeyDown += (s, e) => e.SuppressKeyPress = true;
            cmbFigures.KeyPress += (s, e) => e.Handled = true;

            cmbFigures.SelectedIndexChanged += cmbFigures_SelectedIndexChanged;
            picCanvas.Paint += PanelCanvas_Paint;
            mouseClickHandler = new MouseClickHandler(sceneManager, picCanvas, rbtnVertexes, rbtnEdges, rbtnFaces, rbtnPaintFace, currentPaintColor);

            picCanvas.MouseClick += picCanvas_MouseClick;
            cmbMode.SelectedIndexChanged += ComboMode_SelectedIndexChanged;
            this.Load += ShapeExplorerForm_Load;
            rbtnPaintFace.CheckedChanged += rbtnPaintFace_CheckedChanged;
        }



        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {

            
            bool isInEditMode = rbtnVertexes.Checked || rbtnEdges.Checked || rbtnFaces.Checked;
            renderer.Draw(e.Graphics, sceneManager.Shapes, picCanvas.Size, sceneManager, isInEditMode, currentPaintColor);


        }

        private void ShapeExplorerForm_Load(object sender, EventArgs e)
        {
            rbtnVertexes.Visible = false;
            rbtnEdges.Visible = false;
            rbtnFaces.Visible = false;
            cmbMode.SelectedIndex = 0;
            rbtnPaintFace.Visible = false;
            btnSelectColor.Visible = false;
           
        }

        private void cmbFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFigures.SelectedItem is ComboBoxItem selectedItem)
            {
                string value = selectedItem.Value;

                if (string.IsNullOrEmpty(value))
                    return;

                if (value == lastSelected) return;

                lastSelected = value;
                var shape = ShapeFactory.Create(value);
                if (shape != null)
                {
                    ShapeFactory.CentrarYGuardarOriginales(shape);
                    sceneManager.AddShape(shape);
                    picCanvas.Invalidate();
                }
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

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedItem is ComboBoxItem selectedItem)
            {
                string modeValue = selectedItem.Value; // "object" o "edit"

                if (modeValue == "edit")
                {
                    rbtnVertexes.Visible = true;
                    rbtnEdges.Visible = true;
                    rbtnFaces.Visible = true;
                    rbtnPaintFace.Visible = true;
                    btnSelectColor.Visible = rbtnPaintFace.Checked;
                }
                else
                {
                    rbtnVertexes.Visible = false;
                    rbtnEdges.Visible = false;
                    rbtnFaces.Visible = false;
                    rbtnPaintFace.Visible = false;

                    rbtnVertexes.Checked = false;
                    rbtnEdges.Checked = false;
                    rbtnFaces.Checked = false;
                    rbtnPaintFace.Checked = false;

                    sceneManager.SelectedVertexIndex = null;
                    sceneManager.SelectedEdge = null;
                    sceneManager.SelectedFace = null;
                    btnSelectColor.Visible = false;
                }
            }
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            var colores = new List<Color> { Color.Black, Color.White, Color.Orange, Color.Gold, Color.Green, Color.Teal,
                                     Color.MidnightBlue, Color.DarkGray, Color.HotPink, Color.MediumPurple };

            var colorForm = new ColorPickerForm(colores);
            var buttonLocation = btnSelectColor.PointToScreen(Point.Empty);
            colorForm.Location = new Point(buttonLocation.X, buttonLocation.Y + btnSelectColor.Height);

            if (colorForm.ShowDialog() == DialogResult.OK)
            {
                currentPaintColor = colorForm.SelectedColor;
                btnSelectColor.BackColor = currentPaintColor;

                mouseClickHandler.UpdatePaintColor(currentPaintColor);

            }
        }

        private void rbtnPaintFace_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectColor.Visible = rbtnPaintFace.Checked;
        }

        private void SetupComboBoxMode()
        {
            cmbMode.Items.Clear();
            cmbMode.Items.Add(new ComboBoxItem("📦 Object Mode", "object"));
            cmbMode.Items.Add(new ComboBoxItem("✏️ Edition Mode", "edit"));
            cmbMode.SelectedIndex = 0;
            cmbMode.Font = new Font("Segoe UI Emoji", 11);
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetupComboBoxFigures()
        {
            cmbFigures.Items.Clear();
            cmbFigures.Items.Add(new ComboBoxItem("🧩 Select a figure...", "")); // no seleccionable
            cmbFigures.Items.Add(new ComboBoxItem("🧊 Cube", "Cube"));
            cmbFigures.Items.Add(new ComboBoxItem("🛢️ Cylinder", "Cylinder"));
            cmbFigures.Items.Add(new ComboBoxItem("🔷 Dodecagonal Prism", "DodecagonalPrism"));
            cmbFigures.Items.Add(new ComboBoxItem("🕸️ Octahedron", "Octahedron"));
            cmbFigures.Items.Add(new ComboBoxItem("🔺 Pyramid", "Pyramid"));

            cmbFigures.SelectedIndex = 0;
            cmbFigures.Font = new Font("Segoe UI Emoji", 11);
            cmbFigures.DropDownStyle = ComboBoxStyle.DropDownList;
        }



    }
}
