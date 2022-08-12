#include <Wire.h>
#include <SoftwareSerial.h>
#include <TimerOne.h>
#include <MPU9250.h>

SoftwareSerial BTSerial(10, 11); // RX | TX
const byte LEDpin=13;
const int sampling=250, freq=10;
byte data;
float AccX=0,AccY=0,AccZ=0,GyroX=0,GyroY=0,GyroZ=0,MagX=0,MagY=0,MagZ=0;
int j;
MPU9250 mpu;

void setup()
{
  Serial.begin(9600);
  Serial.println("Enter AT commands:");
  BTSerial.begin(9600); // HC-05 default speed in AT command more
  Wire.begin();
  mpu.setup(0x68);

  if (!mpu.setup(0x68)) {  // change to your own address
      while (1) {
          Serial.println("MPU connection failed. Please check your connection with `connection_check` example.");
          delay(5000);
      }
  }
  
  for (int i=0;i<5;i++)
  {
    digitalWrite(LEDpin,HIGH);
    delay(1000);
    digitalWrite(LEDpin,LOW); 
  }
  delay(1000);
  //Timer1.initialize(4000); 
  //Timer1.attachInterrupt(callback); 
    //attaches callback() as a timer overflow interrupt
  j=-1;
}
void callback()
{
  
  
//  y=125*sin(2*3.14159*freq*j++/sampling)+125;
//  data=(byte)(y); 
//  //Serial.write(data)
//  Serial.println(data);
//  BTSerial.println(data);
}
void loop()
{
 if (mpu.update()) {
    static uint32_t prev_ms = millis();
    if (millis() > prev_ms + 25) {
      AccX=mpu.getAccX();
      AccY=mpu.getAccY();
      AccZ=mpu.getAccZ();
      GyroX=mpu.getGyroX();
      GyroY=mpu.getGyroY();
      GyroZ=mpu.getGyroZ();
      MagX=mpu.getMagX();
      MagY=mpu.getMagY();
    
      String stringValue=((String)"AccX= " + AccX + "AccY= " + AccY + "AccZ= " + AccZ);
      String stringValue2=((String)"GyroX= " + GyroX + "GyroY= " + GyroY + "GyroZ= " + GyroZ);
      String stringValue3=((String)"MagX= " + MagX + "MagY= " + MagY + "MagZ= " + MagZ);

      char BufAcc[50],BufGyro[50],BufMag[50];
      stringValue.toCharArray(BufAcc, 50);
      stringValue2.toCharArray(BufGyro, 50);
      stringValue3.toCharArray(BufMag, 50);
    
      Serial.println(BufAcc);
      Serial.println(BufGyro);
      Serial.println(BufMag);

      BTSerial.println(BufAcc);
      BTSerial.println(BufGyro);
      BTSerial.println(BufMag);
    }
  }
}
