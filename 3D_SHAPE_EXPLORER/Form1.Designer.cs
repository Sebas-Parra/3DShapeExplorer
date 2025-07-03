namespace _3D_SHAPE_EXPLORER
{
    partial class Form1
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
            this.trackRotX = new System.Windows.Forms.TrackBar();
            this.trackRotY = new System.Windows.Forms.TrackBar();
            this.trackRotZ = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotZ)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(-5, -2);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1213, 727);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            // 
            // trackRotX
            // 
            this.trackRotX.Location = new System.Drawing.Point(137, 36);
            this.trackRotX.Maximum = 500;
            this.trackRotX.Name = "trackRotX";
            this.trackRotX.Size = new System.Drawing.Size(161, 56);
            this.trackRotX.TabIndex = 1;
            this.trackRotX.Scroll += new System.EventHandler(this.trackRotX_Scroll);
            // 
            // trackRotY
            // 
            this.trackRotY.Location = new System.Drawing.Point(320, 36);
            this.trackRotY.Maximum = 500;
            this.trackRotY.Name = "trackRotY";
            this.trackRotY.Size = new System.Drawing.Size(161, 56);
            this.trackRotY.TabIndex = 2;
            this.trackRotY.Scroll += new System.EventHandler(this.trackRotY_Scroll);
            // 
            // trackRotZ
            // 
            this.trackRotZ.Location = new System.Drawing.Point(487, 36);
            this.trackRotZ.Maximum = 500;
            this.trackRotZ.Name = "trackRotZ";
            this.trackRotZ.Size = new System.Drawing.Size(161, 56);
            this.trackRotZ.TabIndex = 3;
            this.trackRotZ.Scroll += new System.EventHandler(this.trackRotZ_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 723);
            this.Controls.Add(this.trackRotZ);
            this.Controls.Add(this.trackRotY);
            this.Controls.Add(this.trackRotX);
            this.Controls.Add(this.picCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.TrackBar trackRotX;
        private System.Windows.Forms.TrackBar trackRotY;
        private System.Windows.Forms.TrackBar trackRotZ;
    }
}

