using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class Confirmacion : Form
    {
        Controlador controlador;
        public delegate void Manejador();
        public event Manejador Confirmar;
        public event Manejador Correguir;

        public Confirmacion(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            Confirmar += controlador.Confirmar;
            Correguir += controlador.Correguir;

        }


        private void pbConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        private void pbCorreguir_Click(object sender, EventArgs e)
        {
            Correguir();
        }
    }
}
