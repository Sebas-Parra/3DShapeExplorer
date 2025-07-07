using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_SHAPE_EXPLORER
{
    public partial class ColorPickerForm : Form
    {
        public Color SelectedColor { get; private set; } = Color.Transparent;

        public ColorPickerForm(List<Color> colors)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Size = new Size(180, 140); // ajustable
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
                var btn = new Button
                {
                    BackColor = color,
                    Margin = new Padding(2),
                    Width = 24,
                    Height = 24,
                    FlatStyle = FlatStyle.Flat
                };
                btn.FlatAppearance.BorderSize = 1;
                btn.Click += (s, e) =>
                {
                    SelectedColor = ((Button)s).BackColor;
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
