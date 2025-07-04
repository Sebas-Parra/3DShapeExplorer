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
            this.btnEditionMode = new System.Windows.Forms.Button();
            this.cmbFigures = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picCanvas.Location = new System.Drawing.Point(-5, 30);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1213, 695);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // btnEditionMode
            // 
            this.btnEditionMode.Location = new System.Drawing.Point(1030, 1);
            this.btnEditionMode.Name = "btnEditionMode";
            this.btnEditionMode.Size = new System.Drawing.Size(159, 23);
            this.btnEditionMode.TabIndex = 1;
            this.btnEditionMode.Text = "Edition Mode";
            this.btnEditionMode.UseVisualStyleBackColor = true;
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
            // ShapeExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 723);
            this.Controls.Add(this.cmbFigures);
            this.Controls.Add(this.btnEditionMode);
            this.Controls.Add(this.picCanvas);
            this.Name = "ShapeExplorerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ShapeExplorerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button btnEditionMode;
        private System.Windows.Forms.ComboBox cmbFigures;
    }
}

