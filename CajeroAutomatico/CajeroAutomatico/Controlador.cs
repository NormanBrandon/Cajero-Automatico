
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public class Controlador
    {
        private bool estado_conexion=false;
        private string cuentaTarjeta;
        private string servicio;
        private string cuentaTransferencia;
        private short NIP_Actual;
        private short NIP_Nuevo;
        private int cantidad;
        private string estado_datos;
        private string estado_confirmacion;
        private string dato;
                
        private Menu menu;
        private Principal principal;
        private LectorTarjetas lector;
        private Confirmacion confirmacion;
        private Ingreso_Datos datos;
        private Servicios servicios;
        private Modelo modelo;

        public Controlador()
        {
            principal = new Principal(this);
            Application.Run(principal);
            
            principal.Controls.Add(principal.lbTarjeta);

        }
        #region Eventos Vista Principal
        public void Timer()
        {
            if (estado_conexion)//Si la base no esta conectada no lee tarjetas ni nada alv
            {
                lector = new LectorTarjetas();
                if (lector.Conectar())
                {
                    if (lector.Password().Equals("qbWL1009!$pn"))
                    {
                        cuentaTarjeta = lector.NumeroCuenta();
                        principal.Hide();
                        principal.timer1.Enabled = false;
                        datos = new Ingreso_Datos(this);
                        datos.Show();
                        datos.lbMensaje1.Text = "Ingrese su NIP";
                        estado_datos = "NIP De Inicio";

                    }

                }
                else
                {
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(principal.lbTarjeta, "No se ha conectado el lector o Ingresado Tarjeta");
                }
            }
            else {
                modelo = new Modelo();
                estado_conexion = modelo.ConectarBase();
            }
        }
        #endregion

        #region Eventos Menu

        public void Menu_Salir()
        {
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
            datos.lbMensaje1.Text = "Ingrese la cantidad que desea Retirar";
            estado_datos = "Retiro";

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
            estado_datos = "Transferencia";
        }
        public void Menu_Servicios()
        {
            menu.Close();
            servicios = new Servicios(this);
            servicios.Show();
        }
        public void Menu_Password()
        {
            menu.Close();
            datos = new Ingreso_Datos(this);
            datos.Show();
            datos.lbMensaje1.Text = "Ingrese su nuevo NIP";
            estado_datos = "Nuevo NIP";
        }
        #endregion

        #region Eventos Ingreso de Datos
        public void Teclado_Click(object sender)
        {

            PictureBox pb = new PictureBox();
            pb = (PictureBox)sender;
            string nombre = pb.Name;
            string tecla_numero="";
            switch (nombre)
            {
                case "pbNumero1":
                    tecla_numero = "1";break;
                case "pbNumero2":
                    tecla_numero = "2"; break;
                case "pbNumero3":
                    tecla_numero = "3"; break;
                case "pbNumero4":
                    tecla_numero = "4"; break;
                case "pbNumero5":
                    tecla_numero = "5"; break;
                case "pbNumero6":
                    tecla_numero = "6"; break;
                case "pbNumero7":
                    tecla_numero = "7"; break;
                case "pbNumero8":
                    tecla_numero = "8"; break;
                case "pbNumero9":
                    tecla_numero = "9"; break;
                case "pbNumero0":
                    tecla_numero = "0";
                    break;
                case "pbBorrar":
                    tecla_numero = "";
                    string original = datos.txtMonto.Text;
                    
                    if (original.Length > 0)
                    {
                        datos.txtMonto.Text = "";
                        dato = dato.Remove(dato.Length - 1);
                        for (int i = 0; i < original.Length - 1; i++)
                        {
                            datos.txtMonto.Text += original[i];
                        }
                    }
                    break;
            }
            dato += tecla_numero;
            if (estado_datos.Contains("NIP") && nombre !="pbBorrar")
                datos.txtMonto.Text += "*";
            else
                datos.txtMonto.Text += tecla_numero;
            datos.txtMonto.Select(datos.txtMonto.Text.Length, 0);
        }
        public void Limpiar()
        {
            datos.txtMonto.Text = "";
            dato = "";

        }
        public void Censurar(KeyPressEventArgs e) {
            if (e.KeyChar >= (char)48 && e.KeyChar <= (char)57)//Sólo escribir numeros
            {
                dato = dato + e.KeyChar;
                if (estado_datos.Contains("NIP"))
                {
                    string original = datos.txtMonto.Text;
                    datos.txtMonto.Text = "";
                    for (int i = 0; i < original.Length + 1; i++)
                    {
                        //Censura con asteriscos
                        datos.txtMonto.Text += "*";
                    }
                }
                else
                {
                    datos.txtMonto.Text = datos.txtMonto.Text + e.KeyChar;
                }
            }
            else if (e.KeyChar == (char)8)
            {

                string original = datos.txtMonto.Text;
                if (original.Length > 0) { 
                datos.txtMonto.Text = "";
                dato = dato.Remove(dato.Length - 1);
                for (int i = 0; i < original.Length - 1; i++)
                {
                    datos.txtMonto.Text += original[i];
                }
                    }
            }
            e.Handled = true;
            datos.txtMonto.Select(datos.txtMonto.Text.Length, 0);
        }

        public void Continuar()
        {

            if (estado_datos.Equals("NIP De Inicio"))
            {
                //Aqui va codigo para validacion del NIP con base de datos
                datos.Close();
                menu = new Menu(this);
                menu.Show();
                menu.lbTarjeta.Text = cuentaTarjeta;
            }
            else if (estado_datos.Equals("Retiro"))
            {
                //Valida si el saldo es suficiente, usando base de datos
                datos.Close();
                confirmacion = new Confirmacion(this);
                confirmacion.lbMensaje3.Visible = false;
                confirmacion.lbDestino.Visible = false;
                confirmacion.Show();
                confirmacion.lbMensaje1.Text = "Cuenta de Retiro";
                confirmacion.lbMensaje2.Text = "Cantidad a Retirar";
                confirmacion.lbCantidad.Text = "$" + dato;
                confirmacion.lbCuenta.Text = cuentaTarjeta;
                estado_confirmacion = "Retiro";
                

            }
            //Condicionales de Boton Cambiar Contraseña

            else if (estado_datos.Equals("Nuevo NIP"))
            {
                datos.txtMonto.Text = modelo.obtenerNombre("123");
                datos.lbMensaje1.Text = "Confirme su nuevo NIP";
                estado_datos = "NIP confirmacion";
            }
            else if (estado_datos.Equals("NIP confirmacion"))
            {
                //Validacion contraseñas coinciden
                datos.Close();
                MessageBox.Show("Su NIP ha sido actualizado", "Cambio de contraseña correcto");
                lector.CerrarLector();
                principal = new Principal(this);
                principal.Show();
            }
            else if (estado_datos.Equals("Transferencia"))
            {
                datos.txtMonto.Text = "";
                datos.lbMensaje1.Text = "Ingrese la Cantidad a Depositar";
                estado_datos = "Deposito";
            }
            else if (estado_datos.Equals("Deposito"))
            {
                datos.Close();
                confirmacion = new Confirmacion(this);
                confirmacion.lbMensaje3.Visible = true;
                confirmacion.lbDestino.Visible = true;
                confirmacion.Show();
                estado_confirmacion = "Transferencia";
            }
            dato = "";
        }


        #endregion

        #region Eventos Vista Confirmacion
        public void Confirmar()
        {
            if (estado_confirmacion.Equals("Retiro"))
            {
                //Verifica que haya saldo suficiente en la base de datos, hace la transaccion
                confirmacion.Close();
                MessageBox.Show("Tome su dinero, por favor", "Retiro Correcto");
                lector.CerrarLector();
                principal = new Principal(this);
                principal.Show();
                modelo.realizarRetiro("456");
            }
            else if (estado_confirmacion.Equals("Transferencia"))
            {
                //Verifica que la cuenta exista y que haya saldo suficiente, HAce la transaccion
                confirmacion.Close();
                MessageBox.Show("Su transferencia ha sido exitosa", "Transferencia Correcta");
                lector.CerrarLector();
                principal = new Principal(this);
                principal.Show();
            }
        }
        public void Correguir()
        {
            if (estado_confirmacion.Equals("Retiro"))
            {
                confirmacion.Close();
                datos = new Ingreso_Datos(this);
                datos.Show();
                datos.lbMensaje1.Text = "Ingrese la cantidad que desea Retirar";
                estado_datos = "Retiro";
            }
            else if (estado_confirmacion.Equals("Transferencia"))
            {
                confirmacion.Close();
                datos = new Ingreso_Datos(this);
                datos.Show();
                datos.lbMensaje1.Text = "Ingrese la cuenta a la que desea Transferir";
                datos.Show();
                estado_datos = "Transferencia";
            }



        }
        #endregion

        #region Eventos Pago Servicios
        public void ServicioPago(object sender) {
            servicios.Close();
            datos = new Ingreso_Datos(this);
            datos.Show();
            datos.lbMensaje1.Text = "Ingrese la referencia de pago";
            estado_datos = "Referencia";
            PictureBox pb = new PictureBox();
            pb = (PictureBox)sender;
            switch (pb.Name)
            {
                case "pbCFE":
                    servicio = "CFE";
                break;
                case "pbSat":
                    servicio = "Sat";
                    break;
                case "pbTelmex":
                    servicio = "Telmex";
                    break;
                case "pbNetflix":
                    servicio = "Netflix";
                    break;
            }

        }
 
        #endregion
    }
}
