namespace CajeroAutomatico
{
    partial class Confirmacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirmacion));
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCuenta = new System.Windows.Forms.Label();
            this.lbMensaje1 = new System.Windows.Forms.Label();
            this.lbMensaje2 = new System.Windows.Forms.Label();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.pbConfirmar = new System.Windows.Forms.PictureBox();
            this.pbCorreguir = new System.Windows.Forms.PictureBox();
            this.lbMensaje3 = new System.Windows.Forms.Label();
            this.lbDestino = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCorreguir)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(425, 60);
            this.label5.TabIndex = 27;
            this.label5.Text = "Verifique que la información es correcta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(206, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 64);
            this.label2.TabIndex = 26;
            // 
            // lbCuenta
            // 
            this.lbCuenta.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbCuenta.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCuenta.Location = new System.Drawing.Point(296, 158);
            this.lbCuenta.Name = "lbCuenta";
            this.lbCuenta.Size = new System.Drawing.Size(287, 42);
            this.lbCuenta.TabIndex = 31;
            this.lbCuenta.Text = "987680872";
            this.lbCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMensaje1
            // 
            this.lbMensaje1.BackColor = System.Drawing.SystemColors.Window;
            this.lbMensaje1.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje1.Location = new System.Drawing.Point(3, 149);
            this.lbMensaje1.Name = "lbMensaje1";
            this.lbMensaje1.Size = new System.Drawing.Size(287, 60);
            this.lbMensaje1.TabIndex = 32;
            this.lbMensaje1.Text = "Cuenta de deposito";
            this.lbMensaje1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMensaje2
            // 
            this.lbMensaje2.BackColor = System.Drawing.SystemColors.Window;
            this.lbMensaje2.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje2.Location = new System.Drawing.Point(3, 209);
            this.lbMensaje2.Name = "lbMensaje2";
            this.lbMensaje2.Size = new System.Drawing.Size(287, 60);
            this.lbMensaje2.TabIndex = 34;
            this.lbMensaje2.Text = "Cantidad a depositar";
            this.lbMensaje2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCantidad
            // 
            this.lbCantidad.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbCantidad.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidad.Location = new System.Drawing.Point(296, 218);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(287, 42);
            this.lbCantidad.TabIndex = 33;
            this.lbCantidad.Text = "$4000.00";
            this.lbCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbConfirmar
            // 
            this.pbConfirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbConfirmar.BackgroundImage")));
            this.pbConfirmar.Location = new System.Drawing.Point(397, 352);
            this.pbConfirmar.Name = "pbConfirmar";
            this.pbConfirmar.Size = new System.Drawing.Size(97, 68);
            this.pbConfirmar.TabIndex = 35;
            this.pbConfirmar.TabStop = false;
            this.pbConfirmar.Click += new System.EventHandler(this.pbConfirmar_Click);
            // 
            // pbCorreguir
            // 
            this.pbCorreguir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCorreguir.BackgroundImage")));
            this.pbCorreguir.Location = new System.Drawing.Point(124, 352);
            this.pbCorreguir.Name = "pbCorreguir";
            this.pbCorreguir.Size = new System.Drawing.Size(97, 68);
            this.pbCorreguir.TabIndex = 35;
            this.pbCorreguir.TabStop = false;
            this.pbCorreguir.Click += new System.EventHandler(this.pbCorreguir_Click);
            // 
            // lbMensaje3
            // 
            this.lbMensaje3.BackColor = System.Drawing.SystemColors.Window;
            this.lbMensaje3.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje3.Location = new System.Drawing.Point(3, 266);
            this.lbMensaje3.Name = "lbMensaje3";
            this.lbMensaje3.Size = new System.Drawing.Size(287, 60);
            this.lbMensaje3.TabIndex = 32;
            this.lbMensaje3.Text = "Cuenta de destino";
            this.lbMensaje3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDestino
            // 
            this.lbDestino.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbDestino.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDestino.Location = new System.Drawing.Point(296, 275);
            this.lbDestino.Name = "lbDestino";
            this.lbDestino.Size = new System.Drawing.Size(287, 42);
            this.lbDestino.TabIndex = 31;
            this.lbDestino.Text = "987680872";
            this.lbDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Confirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(this.pbCorreguir);
            this.Controls.Add(this.pbConfirmar);
            this.Controls.Add(this.lbMensaje2);
            this.Controls.Add(this.lbCantidad);
            this.Controls.Add(this.lbMensaje3);
            this.Controls.Add(this.lbMensaje1);
            this.Controls.Add(this.lbDestino);
            this.Controls.Add(this.lbCuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Confirmacion";
            this.Text = "Banco de la Facultad de Ingeniería";
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCorreguir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbCuenta;
        public System.Windows.Forms.Label lbMensaje1;
        public System.Windows.Forms.Label lbMensaje2;
        public System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.PictureBox pbConfirmar;
        private System.Windows.Forms.PictureBox pbCorreguir;
        public System.Windows.Forms.Label lbMensaje3;
        public System.Windows.Forms.Label lbDestino;
    }
}