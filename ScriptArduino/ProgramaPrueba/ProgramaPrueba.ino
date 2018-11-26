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

    if(orden=='2'){
      //Serial.println("1234085908236784"); //credito
      //Serial.println("9847619375789138");//credito
      //Serial.println("8247592745762994");//credito
      //Serial.println("5632908851787856");//credito
      
      //Serial.println("1242754383559995"); //debito
      Serial.println("7893462391734713");//debito
      //Serial.println("7761272473896356");//debito
      //Serial.println("1230974561236348");//debito
    
      }
    else if(orden=='1'){
      Serial.println("qbWL1009!$pn");
        digitalWrite(13,HIGH);
        delay(100);
      }
          else if(orden=='3'){
        //Serial.println("1");//credito
        Serial.println("0");//debito
        digitalWrite(13,HIGH);
        delay(100);
      }
    }
}
