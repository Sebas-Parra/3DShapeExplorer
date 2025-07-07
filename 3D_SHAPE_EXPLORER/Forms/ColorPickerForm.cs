using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace _3D_SHAPE_EXPLORER
{
    public partial class ColorPickerForm : Form
    {
        public Color SelectedColor { get; private set; } = Color.Transparent;

        public ColorPickerForm(List<Color> colors)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Size = new Size(190, 130);
            this.StartPosition = FormStartPosition.Manual;

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                RowCount = (int)Math.Ceiling(colors.Count / 6.0),
                BackColor = Color.White
            };

            foreach (var color in colors)
            {
                var btn = new Guna2Button
                {
                    FillColor = color,
                    Width = 24,
                    Height = 24,
                    Margin = new Padding(2),
                    BorderRadius = 6,
                    BorderThickness = 1,
                    BorderColor = Color.Black,
                    HoverState = { BorderColor = Color.DarkGray },
                    PressedColor = Color.Black,
                    CustomBorderColor = Color.Gray,
                    Text = string.Empty
                };

                btn.Click += (s, e) =>
                {
                    SelectedColor = ((Guna2Button)s).FillColor;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                panel.Controls.Add(btn);
            }

            this.Controls.Add(panel);
        }

        private void ColorPickerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
