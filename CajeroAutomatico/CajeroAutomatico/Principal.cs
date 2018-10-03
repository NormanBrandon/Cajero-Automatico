using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class Principal : Form
    {
        
        public delegate void Manejador();
        public event Manejador DisparaEvento1;
        private Controlador controlador;

        public Principal(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            DisparaEvento1 += controlador.Timer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisparaEvento1();
        }
    }
}
