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
    public partial class Ingreso_Datos : Form
    {
        private Controlador controlador;
        public delegate void Manejador(object sender);
        public event Manejador Teclado;
        public delegate void Manejador2();
        public event Manejador2 Limpiar;
        public event Manejador2 Continuar;
        public delegate void Manejador3(KeyPressEventArgs e);
        public event Manejador3 Censurar;


        public Ingreso_Datos(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            Teclado += controlador.Teclado_Click;
            Limpiar += controlador.Limpiar;
            Censurar += controlador.Censurar;
            Continuar += controlador.Continuar;
            
        }
   

        private void pbNumero1_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero2_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero3_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero4_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero5_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero6_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero7_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero8_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero9_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbNumero0_Click(object sender, EventArgs e)
        {
            Teclado(sender);

        }

        private void pbBorrar_Click(object sender, EventArgs e)
        {
            Teclado(sender);
        }

   
        private void pbLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void pbContinuar_Click(object sender, EventArgs e)
        {
            Continuar();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Censurar(e);
        }
    }
}
