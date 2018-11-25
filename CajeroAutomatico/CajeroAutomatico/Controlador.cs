
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    public class Controlador
    {
        #region Atributos y Objetos
        private bool estado_base = false;
        private bool estado_lector = false;
        private string cuentaTarjeta;
        private string servicio;
        private string referencia;
        private string cuentaTransferencia;
      
        private short NIP_Nuevo;
        private int cantidad;
        private string estado_datos;
        private string estado_confirmacion;
        private string dato ="";
        private bool tipo;
                
        private Menu menu;
        private Principal principal;
        private LectorTarjetas lector;
        private Confirmacion confirmacion;
        private Ingreso_Datos datos;
        private Servicios servicios;
        private Modelo modelo;
        private Consultas consultas;
        #endregion

        #region Constructor, inicio de conexiones
        public Controlador()
        {

            while (!estado_base)
            {
                modelo = new Modelo();
                estado_base = modelo.ConectarBase();
                if(!estado_base)
                MessageBox.Show("Base de datos \"cajero-automatico\" no Conectada, Inicie el servicio por favor", "Error de conexion");      
            }
            while (!estado_lector)
            {
                lector = new LectorTarjetas();
                estado_lector =lector.Conectar();
                if(!estado_lector)
                MessageBox.Show("Lector de Tarjetas BanFi no conectado", "Error de conexion");

            }
            principal = new Principal(this);
            Application.Run(principal);
            principal.Controls.Add(principal.lbTarjeta);
  
        }
        #endregion


        #region Eventos Vista Principal

        public void Timer()
        {
            if (lector.Password().Equals("qbWL1009!$pn"))
            {
                cuentaTarjeta = lector.NumeroCuenta();
                tipo = lector.Tipo();
                principal.Hide();
                datos = new Ingreso_Datos(this);
                datos.Show();
                datos.lbMensaje1.Text = "Ingrese su NIP";
                estado_datos = "NIP De Inicio";
                principal.timer1.Enabled = false;
            }

        }
        #endregion



        #region Eventos Menu

        public void Menu_Salir()
        {
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
            menu.Close();
            consultas = new Consultas(this);
            consultas.Show();
            consultas.lbTarjeta.Text = cuentaTarjeta;
            consultas.lbSaldo.Text = modelo.obtenerSaldo(cuentaTarjeta, tipo).ToString();
            if (tipo)
            {
                consultas.lbMensaje.Text = "Su crédito Disponible es :";
            }
            else {
                consultas.lbMensaje.Text = "Su saldo Disponible es :";
            }
            List<string[]> tabla = new List<string[]>();
            tabla = modelo.realizarConsulta(cuentaTarjeta, tipo);
  
            
            for (int i = 0; i < tabla.Count; i++) {
                consultas.dgvConsultas.Rows.Add(tabla[i]);
            } 
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
        public void Menu_Depositos() {
            menu.Close();
            datos = new Ingreso_Datos(this);
            datos.Show();
            datos.lbMensaje1.Text = "Ingrese la cantidad que desea Depositar";
            estado_datos = "Deposito";
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
                if (dato.Equals(modelo.obtenerNIP(cuentaTarjeta, tipo).ToString()))
                {
  
                    datos.Close();
                    menu = new Menu(this);
                    menu.Show();
                    menu.lbTarjeta.Text = cuentaTarjeta;
                }
                else {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "NIP Incorrecto");
                }
            }
            else if (estado_datos.Equals("Retiro"))
            {

                if (!dato.Equals(""))
                {
                    cantidad = int.Parse(dato);
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
                else {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Llene este campo");
                }

            }

            //Condicionales de Boton Cambiar Contraseña

            else if (estado_datos.Equals("Nuevo NIP"))
            {
              
                datos.lbMensaje1.Text = "Confirme su nuevo NIP";
                estado_datos = "NIP confirmacion";
                if (dato.Length == 4)
                {
                    NIP_Nuevo = short.Parse(dato);
                }
                else {
                    
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe ser de 4 digitos");
                }
                Limpiar();

            }
            else if (estado_datos.Equals("NIP confirmacion"))
            {
                //Validacion contraseñas coinciden
           
                
                if (dato.Length == 4 )
                {
                    if (short.Parse(dato) == NIP_Nuevo)
                    {
                        NIP_Nuevo = short.Parse(dato);
                        datos.Close();
                        principal = new Principal(this);
                        principal.Show();
                        if (modelo.actualizarNIP(cuentaTarjeta, NIP_Nuevo, tipo))
                        {
                            MessageBox.Show("Su NIP ha sido actualizado", "Cambio de contraseña correcto");
                        }
                        else {
                            MessageBox.Show("Error al actualizar, Intente más tarde", "Cambio de contraseña incorrecto");                        }
                    }
                    else {
                        Limpiar();
                        ErrorProvider errorP = new ErrorProvider();
                        errorP.SetError(datos.txtMonto, "Los NIP no coinciden");
                        MessageBox.Show("Los NIP no coiniden intentelo de nuevo", "Error");
                        datos.Close();
                        datos = new Ingreso_Datos(this);
                        datos.Show();
                        datos.lbMensaje1.Text = "Ingrese su nuevo NIP";
                        estado_datos = "Nuevo NIP";

                    }
                }
                else
                {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe ser de 4 digitos");
                    MessageBox.Show("Los NIP no coiniden intentelo de nuevo", "Error");
                    datos.Close();
                    datos = new Ingreso_Datos(this);
                    datos.Show();
                    datos.lbMensaje1.Text = "Ingrese su nuevo NIP";
                    estado_datos = "Nuevo NIP";
                }
                
            }
     
            else if (estado_datos.Equals("Deposito"))
            {
                if (!dato.Equals(""))
                {
                    cantidad = int.Parse(dato);

                    datos.Close();
                    confirmacion = new Confirmacion(this);
                    confirmacion.lbMensaje3.Visible = false;
                    confirmacion.lbDestino.Visible = false;

                    confirmacion.lbCantidad.Text = cantidad.ToString();
                    confirmacion.lbCuenta.Text = cuentaTarjeta;
                    confirmacion.Show();
                    estado_confirmacion = "Deposito";
                }
                else {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe llenar este campo");
                   
                }
            }
            else if (estado_datos.Equals("Transferencia"))
            {
                if (dato.Length == 16)
                {
                    cuentaTransferencia = dato;
                    datos.Close();
                    datos = new Ingreso_Datos(this);
                    if (modelo.exist(cuentaTransferencia))
                    {
                        datos.lbMensaje1.Text = "Ingrese la cantidad que desea Transferir";
                        estado_datos = "Transferencia_Cantidad";
                    }
                    else {
                        MessageBox.Show("La cuenta no existe o no es de débito");
                        datos.lbMensaje1.Text = "Ingrese la cuenta a la que desea Transferir";
                        estado_datos = "Transferencia";
                    }
                    
                    datos.Show();
                }
                else {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe ser de 16 digitos");
                }
            }
            else if (estado_datos.Equals("Transferencia_Cantidad"))
            {
                if (!dato.Equals(""))
                {
                    cantidad = int.Parse(dato);

                    datos.Close();
                    confirmacion = new Confirmacion(this);
                    confirmacion.Show();
                    confirmacion.lbMensaje3.Visible = true;
                    confirmacion.lbDestino.Visible = true;
                    confirmacion.lbCantidad.Text = cantidad.ToString();
                    confirmacion.lbCuenta.Text = cuentaTarjeta;
                    confirmacion.lbDestino.Text = cuentaTransferencia.ToString();
                    estado_confirmacion = "Transferencia_Cantidad";
                }
                else {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe llenar este campo");
                }
            }
            else if (estado_datos.Equals("Referencia"))
            {
                if (!dato.Equals("") )
                {
                    referencia = dato;
                    cuentaTransferencia = dato;
                    datos.Close();
                    datos = new Ingreso_Datos(this);
                    datos.Show();
                    datos.lbMensaje1.Text = "Ingrese la cantidad que desea Pagar";
                    estado_datos = "Servicios_Cantidad";
                }
                else
                {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe llenar este campo");
                }
            }
            else if (estado_datos.Equals("Servicios_Cantidad"))
            {
                if (!dato.Equals(""))
                {
                    cantidad = int.Parse(dato);
                    datos.Close();
                    confirmacion = new Confirmacion(this);
                    confirmacion.Show();
                    confirmacion.lbMensaje3.Visible = true;
                    confirmacion.lbDestino.Visible = true;
                    confirmacion.lbCantidad.Text = cantidad.ToString();
                    confirmacion.lbCuenta.Text = servicio;
                    confirmacion.lbDestino.Text = referencia;
                    confirmacion.lbMensaje3.Text = "Numero de referencia";
                    confirmacion.lbMensaje1.Text = "Servicio a Pagar";
                    estado_confirmacion = "Servicio_Confirmacion";
                }
                else
                {
                    Limpiar();
                    ErrorProvider errorP = new ErrorProvider();
                    errorP.SetError(datos.txtMonto, "Debe llenar este campo");
                }
            }
            dato = "";
        }
        #endregion

        #region Eventos Vista Confirmacion
        public void Confirmar()
        {
            if (estado_confirmacion.Equals("Retiro"))
            {
                if (cantidad <= modelo.obtenerSaldo(cuentaTarjeta, tipo))
                {
                    //Verifica que haya saldo suficiente en la base de datos, hace la transaccion
                    if (modelo.actualizarSaldo(cuentaTarjeta, cantidad * -1, tipo))
                    {
                        MessageBox.Show("Tome su dinero, por favor", "Retiro Correcto");
                    }
                    else {
                        MessageBox.Show("Ocurrio un error, intente mas tarde", "Retiro Incorrecto");
                    }

                    confirmacion.Close();
                    principal = new Principal(this);
                    principal.Show();

                }
                else
                {
                    MessageBox.Show("Saldo Insuficiente", "Error");
                    datos = new Ingreso_Datos(this);
                    datos.Show();
                    datos.lbMensaje1.Text = "Ingrese la cantidad que desea Retirar";
                    estado_datos = "Retiro";
                    confirmacion.Close();

                }
            }

            else if (estado_confirmacion.Equals("Transferencia_Cantidad"))

            {
                    if (modelo.actualizarSaldo(cuentaTarjeta, cantidad * -1, tipo))
                    {
                        if (modelo.actualizarSaldo(cuentaTransferencia, cantidad, false))
                        {
                            MessageBox.Show("Su transferencia ha sido exitosa", "Transferencia Correcta");

                        }
                        else
                        {
                            MessageBox.Show("Su transferencia ha fallado", "Transferencia Incorrecta");
                        }
                    }
                    else
                    {
                        modelo.actualizarSaldo(cuentaTarjeta, cantidad, tipo);
                        MessageBox.Show("Su transferencia ha fallado", "Transferencia Incorrecta");

                    }
                
              
                confirmacion.Close();
                principal = new Principal(this);
                principal.Show();

            }
            else if (estado_confirmacion.Equals("Deposito"))
            {


                if (modelo.actualizarSaldo(cuentaTarjeta, cantidad , tipo))
                {
                    MessageBox.Show("Deposito exitoso, saldo actualizado", "Deposito Correcto");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error, intente mas tarde", "Deposito Incorrecto");
                }
                    confirmacion.Close();
                    principal = new Principal(this);
                    principal.Show();
                
            }
            else if (estado_confirmacion.Equals("Servicio_Confirmacion"))
            {
                if (modelo.realizarPago(cuentaTarjeta,referencia,cantidad,servicio,tipo))
                {
                    modelo.actualizarSaldo(cuentaTarjeta, cantidad * -1, tipo);
                    MessageBox.Show("Pago exitoso " +servicio, "Transferencia Correcta");
                }
                else
                {
                    MessageBox.Show(servicio +"Ocurrio un error, intente mas tarde", "Transferencia Incorrecta");
                }
                confirmacion.Close();
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
            else if (estado_confirmacion.Equals("Transferencia_Cantidad"))
            {
                confirmacion.Close();
                datos = new Ingreso_Datos(this);
                datos.Show();
                datos.lbMensaje1.Text = "Ingrese la cuenta a la que desea Transferir";
                datos.Show();
                estado_datos = "Transferencia";
            }
            else if (estado_confirmacion.Equals("Deposito"))
            {
                confirmacion.Close();
                datos = new Ingreso_Datos(this);
                datos.Show();
                datos.lbMensaje1.Text = "Ingrese la cantidad que desea Depositar";
                estado_datos = "Deposito";
            }
            else if (estado_confirmacion.Equals("Servicio_Confirmacion"))
            {
                confirmacion.Close();
                servicios = new Servicios(this);
                servicios.Show();

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
                    this.servicio = "CFE";
                break;
                case "pbSat":
                    this.servicio = "SAT";
                    break;
                case "pbTelmex":
                    this.servicio = "Telmex";
                    break;
                case "pbNetflix":
                    this.servicio = "Netflix";
                    break;
            }

        }
        #endregion
        public void Imprimir() {
            consultas.Close();
            MessageBox.Show("Imprimiendo Comprobante...");
            principal = new Principal(this);
            principal.Show();
        }


    }
}
