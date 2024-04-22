namespace Practica4
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
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.btnBoton = new System.Windows.Forms.Button();
            this.textNuevo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxApellido.Location = new System.Drawing.Point(293, 161);
            this.textBoxApellido.MaxLength = 10;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 0;
            this.textBoxApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxApellido_KeyPress);
            // 
            // btnBoton
            // 
            this.btnBoton.Location = new System.Drawing.Point(293, 93);
            this.btnBoton.Name = "btnBoton";
            this.btnBoton.Size = new System.Drawing.Size(100, 29);
            this.btnBoton.TabIndex = 1;
            this.btnBoton.Text = "Agregar";
            this.btnBoton.UseVisualStyleBackColor = true;
            this.btnBoton.Click += new System.EventHandler(this.btnBoton_Click);
            // 
            // textNuevo
            // 
            this.textNuevo.Location = new System.Drawing.Point(293, 214);
            this.textNuevo.Multiline = true;
            this.textNuevo.Name = "textNuevo";
            this.textNuevo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textNuevo.Size = new System.Drawing.Size(100, 20);
            this.textNuevo.TabIndex = 2;
            this.textNuevo.Leave += new System.EventHandler(this.textNuevo_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textNuevo);
            this.Controls.Add(this.btnBoton);
            this.Controls.Add(this.textBoxApellido);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Button btnBoton;
        private System.Windows.Forms.TextBox textNuevo;
    }
}

