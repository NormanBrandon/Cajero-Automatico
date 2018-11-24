namespace CajeroAutomatico
{
    partial class Servicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicios));
            this.pbNetflix = new System.Windows.Forms.PictureBox();
            this.pbSat = new System.Windows.Forms.PictureBox();
            this.pbTelmex = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCFE = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNetflix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTelmex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCFE)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNetflix
            // 
            this.pbNetflix.BackColor = System.Drawing.Color.Transparent;
            this.pbNetflix.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbNetflix.BackgroundImage")));
            this.pbNetflix.Location = new System.Drawing.Point(378, 297);
            this.pbNetflix.Name = "pbNetflix";
            this.pbNetflix.Size = new System.Drawing.Size(120, 70);
            this.pbNetflix.TabIndex = 35;
            this.pbNetflix.TabStop = false;
            this.pbNetflix.Click += new System.EventHandler(this.pbNetflix_Click);
            // 
            // pbSat
            // 
            this.pbSat.BackColor = System.Drawing.Color.Transparent;
            this.pbSat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSat.BackgroundImage")));
            this.pbSat.Location = new System.Drawing.Point(76, 309);
            this.pbSat.Name = "pbSat";
            this.pbSat.Size = new System.Drawing.Size(178, 58);
            this.pbSat.TabIndex = 36;
            this.pbSat.TabStop = false;
            this.pbSat.Click += new System.EventHandler(this.pSat_Click);
            // 
            // pbTelmex
            // 
            this.pbTelmex.BackColor = System.Drawing.Color.Transparent;
            this.pbTelmex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTelmex.BackgroundImage")));
            this.pbTelmex.Location = new System.Drawing.Point(362, 197);
            this.pbTelmex.Name = "pbTelmex";
            this.pbTelmex.Size = new System.Drawing.Size(161, 82);
            this.pbTelmex.TabIndex = 38;
            this.pbTelmex.TabStop = false;
            this.pbTelmex.Click += new System.EventHandler(this.pbTelmex_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("PMingLiU-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(145, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 60);
            this.label4.TabIndex = 34;
            this.label4.Text = "Seleccione el Servicio que desea Pagar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(193, -3);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 64);
            this.label2.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(461, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 49);
            this.label3.TabIndex = 39;
            // 
            // pbCFE
            // 
            this.pbCFE.BackColor = System.Drawing.Color.Transparent;
            this.pbCFE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCFE.BackgroundImage")));
            this.pbCFE.Location = new System.Drawing.Point(76, 197);
            this.pbCFE.Name = "pbCFE";
            this.pbCFE.Size = new System.Drawing.Size(145, 82);
            this.pbCFE.TabIndex = 36;
            this.pbCFE.TabStop = false;
            this.pbCFE.Click += new System.EventHandler(this.pbCFE_Click);
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 497);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbNetflix);
            this.Controls.Add(this.pbCFE);
            this.Controls.Add(this.pbSat);
            this.Controls.Add(this.pbTelmex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "Servicios";
            this.Text = "Servicios";
            ((System.ComponentModel.ISupportInitialize)(this.pbNetflix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTelmex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCFE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNetflix;
        private System.Windows.Forms.PictureBox pbSat;
        private System.Windows.Forms.PictureBox pbTelmex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbCFE;
    }
}