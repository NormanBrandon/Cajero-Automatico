namespace CajeroAutomatico
{
    partial class Consultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultas));
            this.pbContinuar = new System.Windows.Forms.PictureBox();
            this.lbMensaje1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.lbTarjeta = new System.Windows.Forms.Label();
            this.lbSaldo = new System.Windows.Forms.Label();
            this.dTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbContinuar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbContinuar
            // 
            this.pbContinuar.BackColor = System.Drawing.Color.Transparent;
            this.pbContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbContinuar.Image = ((System.Drawing.Image)(resources.GetObject("pbContinuar.Image")));
            this.pbContinuar.Location = new System.Drawing.Point(568, 377);
            this.pbContinuar.Name = "pbContinuar";
            this.pbContinuar.Size = new System.Drawing.Size(86, 72);
            this.pbContinuar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbContinuar.TabIndex = 17;
            this.pbContinuar.TabStop = false;
            this.pbContinuar.Click += new System.EventHandler(this.pbContinuar_Click);
            // 
            // lbMensaje1
            // 
            this.lbMensaje1.BackColor = System.Drawing.SystemColors.Window;
            this.lbMensaje1.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje1.Location = new System.Drawing.Point(12, 95);
            this.lbMensaje1.Name = "lbMensaje1";
            this.lbMensaje1.Size = new System.Drawing.Size(287, 60);
            this.lbMensaje1.TabIndex = 15;
            this.lbMensaje1.Text = "Cuenta Bancaria";
            this.lbMensaje1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(226, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 64);
            this.label2.TabIndex = 14;
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.AllowUserToResizeColumns = false;
            this.dgvConsultas.AllowUserToResizeRows = false;
            this.dgvConsultas.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dTransaccion,
            this.dCuenta,
            this.NoReferencia,
            this.dDeposito});
            this.dgvConsultas.Location = new System.Drawing.Point(58, 256);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.Size = new System.Drawing.Size(449, 211);
            this.dgvConsultas.TabIndex = 18;
            // 
            // lbMensaje
            // 
            this.lbMensaje.BackColor = System.Drawing.SystemColors.Window;
            this.lbMensaje.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.Location = new System.Drawing.Point(12, 155);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(287, 60);
            this.lbMensaje.TabIndex = 15;
            this.lbMensaje.Text = "Su saldo disponible :";
            this.lbMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTarjeta
            // 
            this.lbTarjeta.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbTarjeta.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTarjeta.Location = new System.Drawing.Point(323, 104);
            this.lbTarjeta.Name = "lbTarjeta";
            this.lbTarjeta.Size = new System.Drawing.Size(287, 42);
            this.lbTarjeta.TabIndex = 19;
            this.lbTarjeta.Text = "XXXX-XXXX-XXXX-1234";
            this.lbTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSaldo
            // 
            this.lbSaldo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbSaldo.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSaldo.Location = new System.Drawing.Point(323, 164);
            this.lbSaldo.Name = "lbSaldo";
            this.lbSaldo.Size = new System.Drawing.Size(287, 42);
            this.lbSaldo.TabIndex = 19;
            this.lbSaldo.Text = "$1000";
            this.lbSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dTransaccion
            // 
            this.dTransaccion.HeaderText = "Transaccion";
            this.dTransaccion.Name = "dTransaccion";
            // 
            // dCuenta
            // 
            this.dCuenta.HeaderText = "Cuenta";
            this.dCuenta.Name = "dCuenta";
            // 
            // NoReferencia
            // 
            this.NoReferencia.HeaderText = "No.Referencia";
            this.NoReferencia.Name = "NoReferencia";
            // 
            // dDeposito
            // 
            this.dDeposito.HeaderText = "Deposito";
            this.dDeposito.Name = "dDeposito";
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(690, 491);
            this.Controls.Add(this.lbSaldo);
            this.Controls.Add(this.lbTarjeta);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.pbContinuar);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.lbMensaje1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consultas";
            this.Text = "Banco de la Facultad de Ingeniería";
            ((System.ComponentModel.ISupportInitialize)(this.pbContinuar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbContinuar;
        public System.Windows.Forms.Label lbMensaje1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbMensaje;
        public System.Windows.Forms.Label lbTarjeta;
        public System.Windows.Forms.Label lbSaldo;
        public System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDeposito;
    }
}