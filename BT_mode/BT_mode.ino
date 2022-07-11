#include <SoftwareSerial.h>
SoftwareSerial hc06(10,11); //rx/tx

void setup(){
  //Initialize Serial Monitor
  Serial.begin(9600);
  Serial.println("ENTER AT Commands:");
  //Initialize Bluetooth Serial Port
  hc06.begin(57600);
  delay(10);
  command("AT", 2000);
  command("AT+VERSION", 2000);
  command("AT+NAMEhc06ww", 2000);
  command("AT+PIN1234", 2000);
}
void loop(){
  //Write data from HC06 to Serial Monitor
  if (hc06.available()){
    Serial.write(hc06.read());
  }
  //Write from Serial Monitor to HC06
  if (Serial.available()){
    hc06.write(Serial.read());
  }
}

String command(const char *toSend, unsigned long milliseconds){
  String result;
  Serial.print("Sending: ");
  Serial.println(toSend);
  hc06.print(toSend);
  unsigned long startTime = millis();
  Serial.print(F("Received: "));
  while (millis() - startTime < milliseconds){
    if(hc06.available()){
      char c = hc06.read();
      Serial.write(c);
      result += c;
    }
  }
  Serial.println();
  return result;
}
