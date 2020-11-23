namespace FormUtnStore
{
    partial class Formulario
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
            this.btnVender = new System.Windows.Forms.Button();
            this.rchTextBox = new System.Windows.Forms.RichTextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.btnAgregarJuego = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblPlataforma = new System.Windows.Forms.Label();
            this.lblFormato = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.DarkGray;
            this.btnVender.Location = new System.Drawing.Point(111, 307);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(210, 57);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.button1_Click);
            // 
            // rchTextBox
            // 
            this.rchTextBox.Location = new System.Drawing.Point(111, 12);
            this.rchTextBox.Name = "rchTextBox";
            this.rchTextBox.Size = new System.Drawing.Size(210, 272);
            this.rchTextBox.TabIndex = 3;
            this.rchTextBox.Text = "";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(396, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(170, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(396, 100);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(170, 20);
            this.txtPrecio.TabIndex = 3;
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Location = new System.Drawing.Point(396, 154);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(170, 21);
            this.cmbPlataforma.TabIndex = 4;
            // 
            // cmbFormato
            // 
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Location = new System.Drawing.Point(396, 210);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(170, 21);
            this.cmbFormato.TabIndex = 5;
            // 
            // btnAgregarJuego
            // 
            this.btnAgregarJuego.BackColor = System.Drawing.Color.DarkGray;
            this.btnAgregarJuego.Location = new System.Drawing.Point(427, 248);
            this.btnAgregarJuego.Name = "btnAgregarJuego";
            this.btnAgregarJuego.Size = new System.Drawing.Size(108, 47);
            this.btnAgregarJuego.TabIndex = 6;
            this.btnAgregarJuego.Text = "Agregar Juego";
            this.btnAgregarJuego.UseVisualStyleBackColor = false;
            this.btnAgregarJuego.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Black;
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblDescripcion.Location = new System.Drawing.Point(503, 30);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPrecio.Location = new System.Drawing.Point(529, 84);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 10;
            this.lblPrecio.Text = "Precio";
            // 
            // lblPlataforma
            // 
            this.lblPlataforma.AutoSize = true;
            this.lblPlataforma.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPlataforma.Location = new System.Drawing.Point(509, 138);
            this.lblPlataforma.Name = "lblPlataforma";
            this.lblPlataforma.Size = new System.Drawing.Size(57, 13);
            this.lblPlataforma.TabIndex = 11;
            this.lblPlataforma.Text = "Plataforma";
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblFormato.Location = new System.Drawing.Point(521, 194);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(45, 13);
            this.lblFormato.TabIndex = 12;
            this.lblFormato.Text = "Formato";
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(707, 452);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.lblPlataforma);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnAgregarJuego);
            this.Controls.Add(this.cmbFormato);
            this.Controls.Add(this.cmbPlataforma);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.rchTextBox);
            this.Controls.Add(this.btnVender);
            this.Name = "Formulario";
            this.Text = "Rios Paredes Ricardo Nicolas 2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulario_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.RichTextBox rchTextBox;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cmbPlataforma;
        private System.Windows.Forms.ComboBox cmbFormato;
        private System.Windows.Forms.Button btnAgregarJuego;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblPlataforma;
        private System.Windows.Forms.Label lblFormato;
    }
}

