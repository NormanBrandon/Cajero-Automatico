char orden;
void setup() {
Serial.begin(9600);
pinMode(13,OUTPUT);
}
void loop() {
  digitalWrite(13,LOW); 

  delay(200);    
  if(Serial.available()>0){
  orden = Serial.read();

    if(orden=='1'){
      Serial.println("6789 1236 7856 0945");
    
      }
    else if(orden=='2'){
      Serial.println("qbWL1009!$pn");
        digitalWrite(13,HIGH);
        delay(100);
      }
    else if(orden=='3'){
      Serial.println("3000");
        digitalWrite(13,HIGH);
        delay(100);
      }
          else if(orden=='2'){
      Serial.println("debito");
        digitalWrite(13,HIGH);
        delay(100);
      }
    }
}
