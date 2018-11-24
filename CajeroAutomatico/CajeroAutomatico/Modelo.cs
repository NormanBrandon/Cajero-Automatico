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
        string bd="cajero-automatico";
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
            int nip;
            if (tipo)
            {
                comando = new MySqlCommand("SELECT Numero_ctsa2 FROM TarjetaCredito_Contrasena "+"WHERE Numero_tc2="+tarjeta +";", conexion);
            }
            else {
                comando = new MySqlCommand("SELECT Numero_ctsa1 FROM TarjetaDebito_Contrasena "+"WHERE  Numero_td1="+tarjeta+";", conexion);
            }
            try
            {
                consultas = comando.ExecuteReader();
                consultas.Read();
                nip = consultas.GetInt32(0);
                
            }
            catch(MySqlException error)
            {
                MessageBox.Show(error.Message);
                nip = 0;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }


            return nip;
        }
        public int obtenerSaldo(string tarjeta,bool tipo) {
            int saldo;

            if (tipo)
            {
                comando = new MySqlCommand("SELECT Credito_tc FROM tarjetacredito " + "WHERE Numero_tc=" + tarjeta+";", conexion);
            }
            else
            {
                comando = new MySqlCommand("SELECT Saldo_td FROM tarjetadebito " + "WHERE  Numero_td=" + tarjeta + ";", conexion);
            }
            try
            {
                consultas = comando.ExecuteReader();
                consultas.Read();
                saldo = consultas.GetInt32(0);

            }
            catch (MySqlException error)
            {
                saldo = 0;
            }
            finally {
                comando.Dispose();
                consultas.Dispose();
            }
            return saldo;

        }

        public bool actualizarSaldo(string tarjeta,int cantidad,bool tipo) {

            int saldo = obtenerSaldo(tarjeta,tipo) + cantidad;
            
            if (tipo)
            {
                comando = new MySqlCommand("UPDATE tarjetacredito SET Credito_tc=" + saldo+" WHERE Numero_tc=" +tarjeta +";", conexion);
            }
            else
            {
                comando = new MySqlCommand("UPDATE tarjetadebito SET Saldo_td=" + saldo + " WHERE Numero_td=" + tarjeta + ";", conexion);
            }
            try
            {
                if (comando.ExecuteNonQuery() > 0)

                    return true;
                else {
                    return false;

                }
            }
            catch (MySqlException error)
            {
                return false;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }

        }
        public bool actualizarNIP(string tarjeta, int nip, bool tipo)
        {

            if (tipo)
            {
                comando = new MySqlCommand("UPDATE TarjetaCredito_Contrasena SET Numero_ctsa2 =" + nip + " WHERE Numero_tc2=" + tarjeta, conexion);
            }
            else
            {
                comando = new MySqlCommand("UPDATE TarjetaDebito_Contrasena SET Numero_ctsa1 =" + nip + " WHERE Numero_td1=" + tarjeta, conexion);
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
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }
        }

        public bool realizarTransferencia(string cuentaTarjeta,string cuentaTransferencia,int cantidad) {

            try
            {
                comando = new MySqlCommand("UPDATE TarjetaDebito SET Saldo_td +" + cantidad + "WHERE Numero_td1=" + cuentaTransferencia);
            }
            catch (MySqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return true;//si la transferencia es exitosa
        }
        public bool realizarPago(string tarjeta, string referencia, int cantidad, string empresa,bool tipo) {

            int numero_emp = obtenerEmpresa(empresa);
            int numero_cli =obtenerCliente(tarjeta,tipo);
            comando = new MySqlCommand("INSERT INTO empresas_clientes VALUES (" +numero_emp + "," + numero_cli + ","+ referencia+ "," + cantidad + ");",conexion );
            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException error)
            {
                return false;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }
        }
        public int obtenerEmpresa(string empresa) {
            int numero;
            comando = new MySqlCommand("SELECT Numero_emp FROM empresas " + "WHERE Nombre_emp=\"" + empresa + "\";", conexion);
            try
            {
                consultas = comando.ExecuteReader();
                consultas.Read();
                numero = consultas.GetInt32(0);
            }
            catch (MySqlException error)
            {
                numero = 0;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }
            return numero;
        }
        public int obtenerCliente(string tarjeta,bool tipo)
        {
            int numero;
            if (tipo) {
                comando = new MySqlCommand("SELECT Numero_cli1 FROM clientes_tarjetacredito " + "WHERE Numero_tc1=" + tarjeta + ";", conexion);
            }
            else {
                comando = new MySqlCommand("SELECT Numero_cli2 FROM clientes_tarjetadebito " + "WHERE Numero_td1=" + tarjeta + ";", conexion);

            }
            try
            {
                consultas = comando.ExecuteReader();
                consultas.Read();
                numero = consultas.GetInt32(0);
            }
            catch (MySqlException error)
            {
                numero = 0;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
            }
            return numero;
        }
        public bool exist(string tarjeta) {
            bool retorno=false;
            comando = new MySqlCommand("SELECT Saldo_td FROM tarjetadebito " + "WHERE  Numero_td=" + tarjeta + ";", conexion);      
            try
            {
                consultas = comando.ExecuteReader();
                consultas.Read();
                if (consultas.HasRows)
                {
                    retorno = true;
                }
                else {
                    retorno = false;
                }
                
            }
            catch (MySqlException error)
            {
                retorno= false;
            }
            finally
            {
                comando.Dispose();
                consultas.Dispose();
               
            }
            return retorno;


        }



    }
}
