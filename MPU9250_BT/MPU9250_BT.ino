#include "MPU9250.h"
#include "math.h"
MPU9250 mpu;
float acx,acy,acz,ex,ey,ez;
float x,y,z;
unsigned long myTime;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
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
