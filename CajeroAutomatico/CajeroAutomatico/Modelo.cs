using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace CajeroAutomatico
{
    class Modelo //Aun no implementada
    {

        string host="127.0.0.1";
        string bd="caja4";
        string user="root";
        string pass="";
        private MySqlConnection conexion = new MySqlConnection();
        private MySqlCommand comando;
        private MySqlDataReader consultas;
        public bool ConectarBase()
        {
            conexion.ConnectionString ="server="+host+";database="+bd+";uid="+user+";pwd="+pass+";";
            try
            {
                conexion.Open();
            }
            catch (Exception error) {
                MessageBox.Show(error.Message); 

            }
            return true;
        }
        public void DesconectarBase() {
            if (conexion.State == System.Data.ConnectionState.Open) {
                try
                {
                    conexion.Dispose();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
        public int obtenerNIP(string tarjeta,bool tipo) {
            if (tipo)
            {
                comando = new MySqlCommand("SELECT Numero_ctsa2 FROM TarjetaCredito_Contraseña"+"WHERE Numero_tc2="+tarjeta, conexion);
            }
            else {
                comando = new MySqlCommand("SELECT Numero_ctsa1 FROM TarjetaDebito_Contraseña"+"WHERE  Numero_td1="+tarjeta, conexion);
            }
            consultas = comando.ExecuteReader();
            int nip =consultas.GetInt32(0);
            return nip;
        }
        public int obtenerSaldo(string tarjeta,bool tipo) {
            int saldo;
            if (tipo)
            {
                comando = new MySqlCommand("SELECT Credito_tc FROM TarjetaCredito_Contraseña" + "WHERE Numero_tc2=" + tarjeta, conexion);
            }
            else
            {
                comando = new MySqlCommand("SELECT Saldo_td FROM TarjetaDebito_Contraseña" + "WHERE  Numero_td1=" + tarjeta, conexion);
            }
            try
            {
                consultas = comando.ExecuteReader();
                saldo = consultas.GetInt32(0);  
            }
            catch (MySqlException error) {
                saldo = 0;
            }
            return saldo;

        }

        public bool actualizarSaldo(string tarjeta,int cantidad,bool tipo) {
            int saldo = obtenerSaldo(tarjeta, tipo) - cantidad;
            if (tipo)
            {
                comando = new MySqlCommand("UPDATE TarjetaCredito_Contraseña SET Credito_tc=" + saldo+"WHERE Numero_tc2=" +tarjeta, conexion);
            }
            else
            {
                comando = new MySqlCommand("UPDATE TarjetaDebito_Contraseña SET Saldo_td=" + saldo + "WHERE Numero_td1=" + tarjeta, conexion);
            }
            try
            {
                 comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException error)
            {
                return false;
            }
            
        }
        public bool actualizarNIP(string tarjeta, int nip, bool tipo)
        {
            if (tipo)
            {
                comando = new MySqlCommand("UPDATE TarjetaCredito_Contraseña SET Numero_ctsa2 =" + nip + "WHERE Numero_tc2=" + tarjeta, conexion);
            }
            else
            {
                comando = new MySqlCommand("UPDATE TarjetaDebito_Contraseña SET Numero_ctsa1 =" + nip + "WHERE Numero_td1=" + tarjeta, conexion);
            }
            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException error)
            {
                return false;
            }
        }

        public bool realizarTransferencia(string cuentaTarjeta,string cuentaTransferencia,int cantidad) {

            return true;//si la transferencia es exitosa
        }
        public bool realizarPago(string tarjeta, string referencia, int cantidad) {


            return true;
        }



    }
}
