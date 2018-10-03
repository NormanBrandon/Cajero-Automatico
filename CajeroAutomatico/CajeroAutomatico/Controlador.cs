using System.Collections;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;



namespace CajeroAutomatico
{
    public class Controlador
    {
        private string cuentaTarjeta;
        private string cuentaTransferencia;
        private short NIP_Actual;
        private short NIP_Nuevo;
        private int cantidad;
        private short estado_datos;
        private short estado_confirmacion;
        private Menu menu;
        private Principal principal;
        private LectorTarjetas lector = new LectorTarjetas();
        private Confirmacion confirmacion;
        private Ingreso_Datos datos;

        public Controlador() {
            principal = new Principal(this);
            Application.Run(principal);
            principal.Controls.Add(principal.lbTarjeta);
            
        }
        #region Eventos Vista Principal
        public void Timer()
        {
            if (lector.Conectar())
            {
                if (lector.Password().Equals("qbWL1009!$pn"))
                {
                    menu = new Menu(this);
                    menu.Show();
                    principal.Hide();
                    principal.timer1.Enabled = false;
                    cuentaTarjeta = lector.NumeroCuenta();
                    menu.lbTarjeta.Text = cuentaTarjeta;
                }
            }
            else {
                ErrorProvider errorP = new ErrorProvider();
                errorP.SetError(principal.lbTarjeta, "No se ha conectado el lector o Ingresado Tarjeta");
            }
        }
        #endregion

        #region Eventos Menu

        public void Menu_Salir() {
            lector.CerrarLector();
            menu.Close();
            principal = new Principal(this);
            principal.Show();
        }
      
        public void Menu_Efectivo()
        {
            menu.Close();
            datos = new Ingreso_Datos(this);
            datos.Show();
            datos.lbMensaje1.Text = "Ingrese su NIP";

        }
        public void Menu_Consultas()
        {

        }
        public void Menu_Transferencias()
        {
            menu.Close();
            datos = new Ingreso_Datos(this);
            datos.lbMensaje1.Text = "Ingrese la cuenta a la que desea Transferir";
            datos.Show();
        }
        public void Menu_Servicios()
        {

        }
        public void Menu_Password()
        {
            menu.Close();
            datos = new Ingreso_Datos(this);
            datos.Show();
            datos.lbMensaje1.Text = "Ingrese su NIP Actual";
        }
        #endregion

        #region Eventos Ingreso de Datos
        public void Teclado_Click(object sender) {

            PictureBox pb = new PictureBox();
            pb = (PictureBox)sender;
            string nombre = pb.Name;
            switch (nombre) {
                case "pbNumero1":
                    datos.txtMonto.Text += 1;
                break;
                case "pbNumero2":
                    datos.txtMonto.Text += 2;
                    break;
                case "pbNumero3":
                    datos.txtMonto.Text += 3;
                    break;
                case "pbNumero4":
                    datos.txtMonto.Text += 4;
                    break;
                case "pbNumero5":
                    datos.txtMonto.Text += 5;
                    break;
                case "pbNumero6":
                    datos.txtMonto.Text += 6;
                    break;
                case "pbNumero7":
                    datos.txtMonto.Text += 7;
                    break;
                case "pbNumero8":
                    datos.txtMonto.Text += 8;
                    break;
                case "pbNumero9":
                    datos.txtMonto.Text += 9;
                    break;
                case "pbNumero0":
                    datos.txtMonto.Text += 0;
                    break;
                case "pbBorrar":
                    string original=datos.txtMonto.Text;
                    datos.txtMonto.Text ="";
                    for (int i = 0; i < original.Length - 1; i++)
                    {
                        datos.txtMonto.Text += original[i];
                    }
                    break;
            }
        }
        public void Limpiar()
        {
            datos.txtMonto.Text = "";
        }
        public void Continuar()
        {
            //Condicionales de Boton Retiro de Efectivo
            if (datos.lbMensaje1.Text.Equals("Ingrese su NIP"))
            {
                //Aqui va codigo para validacion del NIP con base de datos
                datos.txtMonto.Text = "";
                datos.lbMensaje1.Text = "Ingrese la cantidad que desea retirar";
            }
            else if (datos.lbMensaje1.Text.Equals("Ingrese la cantidad que desea retirar")) {
                //Valida si el saldo es suficiente, usando base de datos
                datos.Close();
                confirmacion = new Confirmacion(this);
                confirmacion.lbMensaje3.Visible = false;
                confirmacion.lbDestino.Visible = false;
                confirmacion.Show();
                confirmacion.lbMensaje1.Text = "Cuenta de Retiro";
                confirmacion.lbMensaje2.Text = "Cantidad a Retirar";
                confirmacion.lbCuenta.Text = cuentaTarjeta;
               
            }
            //Condicionales de Boton Cambiar Contraseña

            else if (datos.lbMensaje1.Text.Equals("Ingrese su NIP Actual"))
            {
                datos.txtMonto.Text = "";
                datos.lbMensaje1.Text = "Ingrese su nuevo NIP";

            }
            else if (datos.lbMensaje1.Text.Equals("Ingrese su nuevo NIP"))
            {
                datos.txtMonto.Text = "";
                datos.lbMensaje1.Text = "Confirme su nuevo NIP";

            }
            else if (datos.lbMensaje1.Text.Equals("Confirme su nuevo NIP"))
            {
             //Validacion contraseñas coinciden

            }
            else if (datos.lbMensaje1.Text.Equals("Ingrese la cuenta a la que desea Transferir"))
            {
                datos.txtMonto.Text = "";
                datos.lbMensaje1.Text = "Ingrese la Cantidad a Depositar";

            }
        }


        #endregion
        #region Eventos Vista Confirmacion
        public void Confirmar() {
            //Modificar Base de datos en saldo y transaccion 
            confirmacion.Close();

        }
        public void Correguir()
        {

        }

        #endregion

    }
}
