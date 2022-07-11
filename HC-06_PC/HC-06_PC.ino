#include <TimerOne.h>
#include <SoftwareSerial.h>

SoftwareSerial hc06(10,11); //tx/rx
const byte LEDpin=13;
const int sampling=250, freq=10;
byte data;
float y;

void setup() {
  Serial.begin(9600);
  Serial.println("ENTER AT Commands:");
  //Initialize Bluetooth Serial Port
  hc06.begin(57600);

  for (int i=0;i<5;i++)
  {
    digitalWrite(LEDpin,HIGH);
    delay(1000);
    digitalWrite(LEDpin,LOW); 
  }
  // initialize timer1, and set a 4ms second period
  Timer1.initialize(4000); 
  Timer1.attachInterrupt(callback); 
  //attaches callback() as a timer overflow interrupt

}
void callback()
{
  y=125*sin(2*3.14159*freq*i++/sampling)+125;
  data=(byte)(y+0.5); 
  //Serial.write(data)
  Serial.println(data);
  BT.println(data);
}
void loop() {
  // put your main code here, to run repeatedly:

}
