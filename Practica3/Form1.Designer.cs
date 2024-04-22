namespace Practica3
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
            this.labelEtiqueta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelEtiqueta
            // 
            this.labelEtiqueta.AutoSize = true;
            this.labelEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEtiqueta.Font = new System.Drawing.Font("MV Boli", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtiqueta.ForeColor = System.Drawing.Color.Blue;
            this.labelEtiqueta.Location = new System.Drawing.Point(232, 77);
            this.labelEtiqueta.Name = "labelEtiqueta";
            this.labelEtiqueta.Size = new System.Drawing.Size(276, 43);
            this.labelEtiqueta.TabIndex = 0;
            this.labelEtiqueta.Text = "hola como estas";
            this.labelEtiqueta.MouseLeave += new System.EventHandler(this.labelEtiqueta_MouseLeave);
            this.labelEtiqueta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelEtiqueta_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelEtiqueta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEtiqueta;
    }
}

