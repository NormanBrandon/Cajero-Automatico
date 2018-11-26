using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public class LectorTarjetas
    {
   
        private string[] puertos;
        private SerialPort ArduinoPort = new SerialPort();

        public LectorTarjetas() {
            ArduinoPort.BaudRate = 9600;
            
        }
        public bool Conectar() {

            puertos = SerialPort.GetPortNames();
            bool retorno=false;
            for (int i = 0; i < puertos.Length; i++)
            {
                try
                {
                    ArduinoPort.PortName = puertos[i];
                    ArduinoPort.Open();
            
                    if (ArduinoPort.IsOpen)
                    {
                        retorno = true;
                
                        break;
                    }
                }
                catch (IOException errorC)
                {
                    MessageBox.Show(errorC.Message);
                  
                }         
            }
            return retorno;
          
        }
        public void CerrarLector() {
            ArduinoPort.Close();
        }
        public string NumeroCuenta() {
            ArduinoPort.Write("2");
            string cuenta = ArduinoPort.ReadLine();
            string numcuenta = "";
            for (int i = 0; i < cuenta.Length -1; i++)
            {
                numcuenta += cuenta[i];
            }
            ArduinoPort.DiscardInBuffer();
            return numcuenta;
        }
        public string Password() {
            ArduinoPort.Write("1");
            string password = ArduinoPort.ReadLine();
            string passwd = "";
            for (int i = 0; i < password.Length -1; i++)
            {
                passwd += password[i];
            }
            ArduinoPort.DiscardInBuffer();
            return passwd;
        }
        public bool Tipo() {
            ArduinoPort.Write("3");
            string type = ArduinoPort.ReadLine();
            string tipo = "";
            for (int i = 0; i < type.Length -1; i++)
            {
                tipo += type[i];
            }
            ArduinoPort.DiscardInBuffer();
  
            if (tipo.Equals("1")) {
                return true;
            }
            else {
                return false; 
            }
        }
    }
}
