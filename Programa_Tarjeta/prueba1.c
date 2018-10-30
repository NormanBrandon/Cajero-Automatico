 #include <12f508.h>
 #fuses NOWDT,NOPROTECT,NOMCLR
 #byte OSC = 0x05
 #define GP2 PIN_B2
void main(){
OSC = 0b11111111;
while(true){
   output_high(PIN_B2);
   
}
}
