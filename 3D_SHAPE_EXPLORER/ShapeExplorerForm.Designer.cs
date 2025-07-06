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
            this.cmbFigures = new System.Windows.Forms.ComboBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.rbtnVertexes = new System.Windows.Forms.RadioButton();
            this.rbtnFaces = new System.Windows.Forms.RadioButton();
            this.rbtnEdges = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picCanvas.Location = new System.Drawing.Point(-5, 30);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1370, 815);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // cmbFigures
            // 
            this.cmbFigures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFigures.FormattingEnabled = true;
            this.cmbFigures.Items.AddRange(new object[] {
            "Cube",
            "Cylinder",
            "DodecagonalPrism",
            "Octahedron",
            "Pyramid"});
            this.cmbFigures.Location = new System.Drawing.Point(12, 1);
            this.cmbFigures.Name = "cmbFigures";
            this.cmbFigures.Size = new System.Drawing.Size(121, 24);
            this.cmbFigures.TabIndex = 2;
            this.cmbFigures.SelectedIndexChanged += new System.EventHandler(this.cmbFigures_SelectedIndexChanged);
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Object Mode",
            "Edition Mode"});
            this.cmbMode.Location = new System.Drawing.Point(158, 2);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(121, 24);
            this.cmbMode.TabIndex = 3;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // rbtnVertexes
            // 
            this.rbtnVertexes.AutoSize = true;
            this.rbtnVertexes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbtnVertexes.Location = new System.Drawing.Point(285, 4);
            this.rbtnVertexes.Name = "rbtnVertexes";
            this.rbtnVertexes.Size = new System.Drawing.Size(81, 20);
            this.rbtnVertexes.TabIndex = 7;
            this.rbtnVertexes.TabStop = true;
            this.rbtnVertexes.Text = "Vertexes";
            this.rbtnVertexes.UseVisualStyleBackColor = true;
            // 
            // rbtnFaces
            // 
            this.rbtnFaces.AutoSize = true;
            this.rbtnFaces.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbtnFaces.Location = new System.Drawing.Point(446, 6);
            this.rbtnFaces.Name = "rbtnFaces";
            this.rbtnFaces.Size = new System.Drawing.Size(66, 20);
            this.rbtnFaces.TabIndex = 9;
            this.rbtnFaces.TabStop = true;
            this.rbtnFaces.Text = "Faces";
            this.rbtnFaces.UseVisualStyleBackColor = true;
            // 
            // rbtnEdges
            // 
            this.rbtnEdges.AutoSize = true;
            this.rbtnEdges.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbtnEdges.Location = new System.Drawing.Point(372, 4);
            this.rbtnEdges.Name = "rbtnEdges";
            this.rbtnEdges.Size = new System.Drawing.Size(68, 20);
            this.rbtnEdges.TabIndex = 8;
            this.rbtnEdges.TabStop = true;
            this.rbtnEdges.Text = "Edges";
            this.rbtnEdges.UseVisualStyleBackColor = true;
            // 
            // ShapeExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1365, 846);
            this.Controls.Add(this.rbtnFaces);
            this.Controls.Add(this.rbtnEdges);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.rbtnVertexes);
            this.Controls.Add(this.cmbFigures);
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
        private System.Windows.Forms.ComboBox cmbFigures;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.RadioButton rbtnVertexes;
        private System.Windows.Forms.RadioButton rbtnFaces;
        private System.Windows.Forms.RadioButton rbtnEdges;
    }
}

