using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    class Modelo //Aun no implementada
    {
        int NIP;
        string nombreUsuario;
        float saldo;
        //clase que tendra los metodos para obtener informacion de la base de datos
        public bool ConectarBase()
        {

            return true;
        }
        public int obtenerNIP() {

            return NIP;
        }
        public string obtenerNombre() {

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
        public void iniciar() {


        }

    }
}
