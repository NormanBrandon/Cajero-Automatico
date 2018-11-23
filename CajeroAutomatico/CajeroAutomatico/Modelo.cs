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
        int NIP;
        string nombreUsuario;
        float saldo;
        string host="127.0.0.1";
        string bd="baseprueba";
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
        public int obtenerNIP() {
            comando = new MySqlCommand("SELECT Numero_ctsa2 FROM TarjetaCredito_Contraseña", conexion);
            consultas = comando.ExecuteReader();
            NIP =int.Parse(consultas.GetString(0));
            return NIP;
        }
        public string obtenerNombre() {
            comando = new MySqlCommand("SELECT Numero_ctsa2 FROM TarjetaCredito_Contraseña", conexion);
            consultas = comando.ExecuteReader();
            consultas.Read();
            nombreUsuario = consultas.GetInt32(0).ToString();
            return nombreUsuario;
        }
        public float obtenerSaldo() {

            return saldo;
        }
        public bool realizarTransferencia() {

            return true;//si la transferencia es exitosa
        }
        public bool realizarRetiro() {

            return true;//si el retiro es exitoso
        }


    }
}
