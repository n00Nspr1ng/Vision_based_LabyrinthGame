#include <Servo.h> //서보관련 라이브러리를 사용하기 위해
//#include "crc.h"
#include "config.h"
//#include "i2c_cb.h"
//#include "network_fn.h" 
//#include "wt32driver.h" // Gyro, Accel, Mag
#include "led_control.h"

Servo servo1;  // 서보 변수 선언
Servo servo2;  // 서보 변수 선언

int servo1_degree = 90;
int servo2_degree = 90;

int a;
int b;
//char _rcv_data[7] = {0,};

void setup() {

  servo1.attach(servo1Pin); 
  servo2.attach(servo2Pin);

  Serial.begin(115200);

  // Wire.begin(Address); // change this part to socket
  // Wire.onReceive(receiveEvent);
  setupLED();
  
//  setupMQTTCLient();
  // setupWT32(); // imu sensor init

//  pinMode(buttonPin2, INPUT_PULLUP);
//  pinMode(buttonPin3, INPUT_PULLUP);
//  pinMode(buttonPin4, INPUT_PULLUP);
//  pinMode(buttonPin5, INPUT_PULLUP);
  pinMode(ledR,OUTPUT);
  pinMode(ledB,OUTPUT);
  pinMode(buttonPin1, INPUT_PULLUP);
  pinMode(buttonPin2, INPUT_PULLUP);


}

void loop() {
//  Serial.println("inside loop");

  loop_manual();
  
//  if(Serial.available()){
//    a = Serial.parseInt();
//    b = Serial.parseInt();
//    Serial.print("a = ");
//    Serial.print(a); 
//    Serial.print("    b = ");
//    Serial.println(b);
//  }

//  servo1.write(a);
//  servo2.write(b);
//  Serial.println("Done");
  
//  loop_manual();
}
