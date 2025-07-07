namespace _3D_SHAPE_EXPLORER
{
    partial class ShapeExplorerForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.gunacmbFigures = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunacmbMode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunarbtnVertexes = new Guna.UI2.WinForms.Guna2RadioButton();
            this.gunarbtnEdges = new Guna.UI2.WinForms.Guna2RadioButton();
            this.gunarbtnFaces = new Guna.UI2.WinForms.Guna2RadioButton();
            this.gunarbtnPaintFigures = new Guna.UI2.WinForms.Guna2RadioButton();
            this.gunbtnSelectColor = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picCanvas.Location = new System.Drawing.Point(-5, 47);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1517, 798);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // gunacmbFigures
            // 
            this.gunacmbFigures.BackColor = System.Drawing.Color.Transparent;
            this.gunacmbFigures.BorderColor = System.Drawing.Color.Transparent;
            this.gunacmbFigures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunacmbFigures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunacmbFigures.FillColor = System.Drawing.Color.Transparent;
            this.gunacmbFigures.FocusedColor = System.Drawing.Color.White;
            this.gunacmbFigures.FocusedState.BorderColor = System.Drawing.Color.White;
            this.gunacmbFigures.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunacmbFigures.ForeColor = System.Drawing.Color.White;
            this.gunacmbFigures.ItemHeight = 30;
            this.gunacmbFigures.ItemsAppearance.BackColor = System.Drawing.Color.Black;
            this.gunacmbFigures.ItemsAppearance.ForeColor = System.Drawing.Color.White;
            this.gunacmbFigures.ItemsAppearance.SelectedBackColor = System.Drawing.Color.DimGray;
            this.gunacmbFigures.Location = new System.Drawing.Point(12, 5);
            this.gunacmbFigures.Name = "gunacmbFigures";
            this.gunacmbFigures.Size = new System.Drawing.Size(256, 36);
            this.gunacmbFigures.TabIndex = 12;
            this.gunacmbFigures.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // gunacmbMode
            // 
            this.gunacmbMode.BackColor = System.Drawing.Color.Transparent;
            this.gunacmbMode.BorderColor = System.Drawing.Color.Transparent;
            this.gunacmbMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunacmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunacmbMode.FillColor = System.Drawing.Color.Transparent;
            this.gunacmbMode.FocusedColor = System.Drawing.Color.White;
            this.gunacmbMode.FocusedState.BorderColor = System.Drawing.Color.White;
            this.gunacmbMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunacmbMode.ForeColor = System.Drawing.Color.White;
            this.gunacmbMode.ItemHeight = 30;
            this.gunacmbMode.ItemsAppearance.BackColor = System.Drawing.Color.Black;
            this.gunacmbMode.ItemsAppearance.ForeColor = System.Drawing.Color.White;
            this.gunacmbMode.ItemsAppearance.SelectedBackColor = System.Drawing.Color.DimGray;
            this.gunacmbMode.Location = new System.Drawing.Point(274, 5);
            this.gunacmbMode.Name = "gunacmbMode";
            this.gunacmbMode.Size = new System.Drawing.Size(258, 36);
            this.gunacmbMode.TabIndex = 13;
            this.gunacmbMode.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox2_SelectedIndexChanged);
            // 
            // gunarbtnVertexes
            // 
            this.gunarbtnVertexes.AutoSize = true;
            this.gunarbtnVertexes.CheckedState.BorderColor = System.Drawing.Color.White;
            this.gunarbtnVertexes.CheckedState.BorderThickness = 0;
            this.gunarbtnVertexes.CheckedState.FillColor = System.Drawing.Color.DimGray;
            this.gunarbtnVertexes.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gunarbtnVertexes.CheckedState.InnerOffset = -4;
            this.gunarbtnVertexes.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunarbtnVertexes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gunarbtnVertexes.Location = new System.Drawing.Point(655, 12);
            this.gunarbtnVertexes.Name = "gunarbtnVertexes";
            this.gunarbtnVertexes.Size = new System.Drawing.Size(134, 26);
            this.gunarbtnVertexes.TabIndex = 14;
            this.gunarbtnVertexes.Text = "🟢 Vertexes";
            this.gunarbtnVertexes.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunarbtnVertexes.UncheckedState.BorderThickness = 2;
            this.gunarbtnVertexes.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.gunarbtnVertexes.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // gunarbtnEdges
            // 
            this.gunarbtnEdges.AutoSize = true;
            this.gunarbtnEdges.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnEdges.CheckedState.BorderThickness = 0;
            this.gunarbtnEdges.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnEdges.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gunarbtnEdges.CheckedState.InnerOffset = -4;
            this.gunarbtnEdges.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunarbtnEdges.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gunarbtnEdges.Location = new System.Drawing.Point(809, 12);
            this.gunarbtnEdges.Name = "gunarbtnEdges";
            this.gunarbtnEdges.Size = new System.Drawing.Size(105, 26);
            this.gunarbtnEdges.TabIndex = 15;
            this.gunarbtnEdges.Text = "📏Edges";
            this.gunarbtnEdges.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunarbtnEdges.UncheckedState.BorderThickness = 2;
            this.gunarbtnEdges.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.gunarbtnEdges.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // gunarbtnFaces
            // 
            this.gunarbtnFaces.AutoSize = true;
            this.gunarbtnFaces.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnFaces.CheckedState.BorderThickness = 0;
            this.gunarbtnFaces.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnFaces.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gunarbtnFaces.CheckedState.InnerOffset = -4;
            this.gunarbtnFaces.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunarbtnFaces.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gunarbtnFaces.Location = new System.Drawing.Point(931, 12);
            this.gunarbtnFaces.Name = "gunarbtnFaces";
            this.gunarbtnFaces.Size = new System.Drawing.Size(101, 26);
            this.gunarbtnFaces.TabIndex = 16;
            this.gunarbtnFaces.Text = "🧊Faces";
            this.gunarbtnFaces.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunarbtnFaces.UncheckedState.BorderThickness = 2;
            this.gunarbtnFaces.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.gunarbtnFaces.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // gunarbtnPaintFigures
            // 
            this.gunarbtnPaintFigures.AutoSize = true;
            this.gunarbtnPaintFigures.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnPaintFigures.CheckedState.BorderThickness = 0;
            this.gunarbtnPaintFigures.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunarbtnPaintFigures.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gunarbtnPaintFigures.CheckedState.InnerOffset = -4;
            this.gunarbtnPaintFigures.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunarbtnPaintFigures.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gunarbtnPaintFigures.Location = new System.Drawing.Point(1049, 12);
            this.gunarbtnPaintFigures.Name = "gunarbtnPaintFigures";
            this.gunarbtnPaintFigures.Size = new System.Drawing.Size(166, 26);
            this.gunarbtnPaintFigures.TabIndex = 17;
            this.gunarbtnPaintFigures.Text = "🎨Paint Figures";
            this.gunarbtnPaintFigures.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunarbtnPaintFigures.UncheckedState.BorderThickness = 2;
            this.gunarbtnPaintFigures.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.gunarbtnPaintFigures.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.gunarbtnPaintFigures.CheckedChanged += new System.EventHandler(this.gunarbtnPaintFigures_CheckedChanged);
            // 
            // gunbtnSelectColor
            // 
            this.gunbtnSelectColor.BorderColor = System.Drawing.Color.Transparent;
            this.gunbtnSelectColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunbtnSelectColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunbtnSelectColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunbtnSelectColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunbtnSelectColor.FillColor = System.Drawing.Color.Transparent;
            this.gunbtnSelectColor.FocusedColor = System.Drawing.Color.White;
            this.gunbtnSelectColor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.gunbtnSelectColor.ForeColor = System.Drawing.Color.White;
            this.gunbtnSelectColor.HoverState.BorderColor = System.Drawing.Color.White;
            this.gunbtnSelectColor.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.gunbtnSelectColor.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.gunbtnSelectColor.IndicateFocus = true;
            this.gunbtnSelectColor.Location = new System.Drawing.Point(1294, 9);
            this.gunbtnSelectColor.Name = "gunbtnSelectColor";
            this.gunbtnSelectColor.Size = new System.Drawing.Size(195, 32);
            this.gunbtnSelectColor.TabIndex = 18;
            this.gunbtnSelectColor.Text = "🌈Select Color";
            this.gunbtnSelectColor.Click += new System.EventHandler(this.gunbtnSelectColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(586, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 46);
            this.label1.TabIndex = 19;
            this.label1.Text = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1259, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 46);
            this.label2.TabIndex = 20;
            this.label2.Text = "|";
            // 
            // ShapeExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1501, 846);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunbtnSelectColor);
            this.Controls.Add(this.gunarbtnPaintFigures);
            this.Controls.Add(this.gunarbtnFaces);
            this.Controls.Add(this.gunarbtnEdges);
            this.Controls.Add(this.gunarbtnVertexes);
            this.Controls.Add(this.gunacmbMode);
            this.Controls.Add(this.gunacmbFigures);
            this.Controls.Add(this.picCanvas);
            this.Name = "ShapeExplorerForm";
            this.Text = "3D_SHAPE_EXPLORER";
            this.Load += new System.EventHandler(this.ShapeExplorerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private Guna.UI2.WinForms.Guna2ComboBox gunacmbFigures;
        private Guna.UI2.WinForms.Guna2ComboBox gunacmbMode;
        private Guna.UI2.WinForms.Guna2RadioButton gunarbtnVertexes;
        private Guna.UI2.WinForms.Guna2RadioButton gunarbtnEdges;
        private Guna.UI2.WinForms.Guna2RadioButton gunarbtnFaces;
        private Guna.UI2.WinForms.Guna2RadioButton gunarbtnPaintFigures;
        private Guna.UI2.WinForms.Guna2Button gunbtnSelectColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

