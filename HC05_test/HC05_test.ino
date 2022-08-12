#include <SoftwareSerial.h>
#include <TimerOne.h>

SoftwareSerial BTSerial(10,11); // (Arduino端的RX, Arduino端的TX)
const byte LEDpin=13;
const int sampling=250, freq=10;
byte data;
float y;
int j;
char val;

void setup()
{
    Serial.begin(9600);
    Serial.println("Enter AT commands:");
    pinMode(9, OUTPUT); // this pin will pull the HC-05 pin 34 (key pin) HIGH to switch module to AT mode
    digitalWrite(9, HIGH);

    for (int i=0;i<5;i++)
    {
      digitalWrite(LEDpin,HIGH);
      delay(1000);
      digitalWrite(LEDpin,LOW); 
    }
    
    BTSerial.begin(38400); // HC-05 default speed in AT command more
    // initialize timer1, and set a 4ms second period
    Timer1.initialize(4000); 
    //Timer1.attachInterrupt(callback); 
    //attaches callback() as a timer overflow interrupt
    j=-1;
}
void callback()
{
  Serial.println("Hi");  
  y=125*sin(2*3.14159*freq*j++/sampling)+125;
  data=(byte)(5); 
  //Serial.write(data)
  //Serial.println(data);
  //BTSerial.println(data);
}
void loop()
{
     
}
