using System;
using System.Windows.Forms;


namespace CajeroAutomatico
{
    public partial class Menu : Form
    {
        public delegate void Manejador();
        public event Manejador Menu_Salir;
        public event Manejador Menu_Efectivo;
        public event Manejador Menu_Password;
        public event Manejador Menu_Transferencias;
        public event Manejador Menu_Servicios;
        public event Manejador Menu_Consultas;
        public event Manejador Menu_Depositos;



        private Controlador controlador;

        public Menu(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;    
            Menu_Salir += controlador.Menu_Salir;
            Menu_Efectivo += controlador.Menu_Efectivo;
            Menu_Password += controlador.Menu_Password;
            Menu_Transferencias += controlador.Menu_Transferencias;
            Menu_Servicios += controlador.Menu_Servicios;
            Menu_Consultas += controlador.Menu_Consultas;
            Menu_Depositos += controlador.Menu_Depositos;

        }
        private void pbSalir_Click(object sender, EventArgs e)
        {
            Menu_Salir();
        }
        private void pbPassword_Click(object sender, EventArgs e)
        {
            Menu_Password();
        }

        private void pbTranferencias_Click(object sender, EventArgs e)
        {
            Menu_Transferencias();
        }

        private void pbEfectivo_Click(object sender, EventArgs e)
        {
            Menu_Efectivo();
        }

        private void pbConsultas_Click(object sender, EventArgs e)
        {
            Menu_Consultas();
        }

        private void pbServicios_Click(object sender, EventArgs e)
        {
            Menu_Servicios();
        }

        private void pbDepositos_Click(object sender, EventArgs e)
        {
            Menu_Depositos();
        }
    }
}
