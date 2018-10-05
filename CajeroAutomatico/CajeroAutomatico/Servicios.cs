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
    public partial class Servicios : Form
    {
        private delegate void Manejador(object sender);
        private event Manejador pago;

        Controlador controlador;

        public Servicios(Controlador controlador)
        {
            this.controlador = controlador;
            InitializeComponent();
            pago += controlador.ServicioPago;
        }

        private void pbCFE_Click(object sender, EventArgs e)
        {
            pago(sender);
        }

        private void pbTelmex_Click(object sender, EventArgs e)
        {
            pago(sender);
        }

        private void pbNetflix_Click(object sender, EventArgs e)
        {
            pago(sender);
        }

        private void pSat_Click(object sender, EventArgs e)
        {
            pago(sender);
        }
    }
}
