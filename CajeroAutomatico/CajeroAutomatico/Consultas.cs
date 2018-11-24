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
    public partial class Consultas : Form
    {
        public delegate void Manejador();
        public event Manejador Continuar;
        private Controlador controlador;

        public Consultas(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            Continuar += controlador.Imprimir;

        }

        private void pbContinuar_Click(object sender, EventArgs e)
        {
            Continuar();
        }
    }
}
