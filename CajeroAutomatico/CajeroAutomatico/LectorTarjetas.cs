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

            for (int i = 0; i < puertos.Length; i++)
            {
                try
                {
                    ArduinoPort.PortName = puertos[i];
                    ArduinoPort.Open();
                    if (ArduinoPort.IsOpen)
                    {
                        return true;
                    }
                }
                catch (IOException errorC)
                {
                    MessageBox.Show(errorC.Message);
                    
                }
                    continue;
                
            }   
             return false;
        }
        public void CerrarLector() {
            ArduinoPort.Close();
        }
        public string NumeroCuenta() {
            ArduinoPort.WriteLine("1");
            string cuenta = ArduinoPort.ReadLine();
            string numcuenta = "";
            for (int i = 0; i < cuenta.Length - 1; i++)
            {
                numcuenta += cuenta[i];
            }
            ArduinoPort.DiscardInBuffer();
            return numcuenta;
        }
        public string Password() {
            ArduinoPort.WriteLine("2");
            string password = ArduinoPort.ReadLine();
            string passwd = "";
            for (int i = 0; i < password.Length - 1; i++)
            {
                passwd += password[i];
            }
            ArduinoPort.DiscardInBuffer();
            return passwd;
        }
    }
}
