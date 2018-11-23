    #include <SoftwareSerial.h>
const int RX=6,TX=12;
SoftwareSerial Tarjeta = SoftwareSerial(RX,TX); // Definimos los pines RX y TX del Arduino conectados a la Tarjeta
void setup() {
  Serial.begin(9600);
  Tarjeta.begin(9600);
}

void loop() {
if(Serial.available()>0){
  char dato= Serial.read();
  Tarjeta.print(dato);
  }
if(Tarjeta.available()>0){
  int dato= Tarjeta.read();
  Serial.println(dato);
  } 
}
