#include <SoftwareSerial.h>
#include<string.h>
#include<stdio.h>

const int RX=6,TX=7;
SoftwareSerial BT = SoftwareSerial(RX,TX); // Definimos los pines RX y TX del Arduino conectados a la Tarjeta

char *cifrado(char *frase,int n){ 
     
    int i,j; 
     
    for(i=0;i<strlen(frase);i++){ 
        for(j=0;j<n;j++){ 
            if((frase[i]>=33 && frase[i]<122)){ 
                frase[i]++;                
            } 
            else if(frase[i]==122) 
                frase[i]=33; 
        } 
    } 
    return frase; 
} 
 
char *descifrado(char *frase,int n){ 
     
    int i,j; 
     
    for(i=0;i<strlen(frase);i++){ 
        for(j=0;j<n;j++){ 
            if((frase[i]>33 && frase[i]<=122)){ 
                frase[i]--;                
            } 
            else if(frase[i]==33) 
                frase[i]=122; 
        }
    } 
    return frase; 
} 
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
Tarjeta.begin(9600);
}

void loop() {
  //Contraseña qbWL1009!$pn
  char Oso[20];
  String pal="qbWL1009!$pn";
  pal.toCharArray(Oso,20);
  char *P=Oso;
  Serial.println(cifrado(P,3));
  delay(1000);
}
