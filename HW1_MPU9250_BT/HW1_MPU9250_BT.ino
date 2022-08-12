#include "MPU9250.h"
#include "math.h"
#include <TimerOne.h>
#include <SoftwareSerial.h>
MPU9250 mpu;
SoftwareSerial hc06(10,11); //tx/rx

float acx,acy,acz,ex,ey,ez;
float x,y,z;
unsigned long myTime;
const byte LEDpin=13;
byte data1,data2,data3;
char masgArray[15] = {"Yaw, Pitch, Roll: "};

void setup() {
  // put your setup code here, to run once:
  Serial.begin(57600);
  hc06.begin(57600);
  Wire.begin();
  mpu.setup(0x68);
  
  delay(1000);
  if (!mpu.setup(0x68)) {  // change to your own address
      while (1) {
          Serial.println("MPU connection failed. Please check your connection with `connection_check` example.");
          delay(5000);
      }
  }
}

void loop() {
  if (mpu.update()) {
      static uint32_t prev_ms = millis();
      if (millis() > prev_ms + 25) {
          print_roll_pitch_yaw();
          print_Acc();
          prev_ms = millis();
      }
  }
}

void print_roll_pitch_yaw() {
  Serial.print("Yaw, Pitch, Roll: ");
  Serial.print(mpu.getYaw(), 2);
  Serial.print(", ");
  Serial.print(mpu.getPitch(), 2);
  Serial.print(", ");
  Serial.println(mpu.getRoll(), 2);
  int Yaw = mpu.getYaw();
  int Pitch = mpu.getPitch();
  int Roll = mpu.getRoll();
  data1=(byte)(Yaw); 
  data2=(byte)(Pitch); 
  data3=(byte)(Roll); 
  //Serial.write(data)
  Serial.println(data1);
  hc06.println(masgArray);
  hc06.println(data1);
  hc06.println(data2);
  hc06.println(data3);
}

void print_Acc(){
  acx=mpu.getAccX();
  acy=mpu.getAccY();
  acz=mpu.getAccZ();

  Serial.print(acx);
  Serial.print(", ");
  Serial.print(acy);
  Serial.print(", ");
  Serial.println(acz);
}
