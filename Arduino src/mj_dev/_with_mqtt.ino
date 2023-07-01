//void loop_mqtt()
//{
//  
//  // mqtt client conn
//  //if (!client.connected()) {
//  //  reconnect();
//  //}
//  //client.loop();
//
//  // need receiving buffer
//  // with some pointer
//
//  // motor control
//  while(state==1)
//  {
//    servo1.write(servo1_degree);
//    servo2.write(servo2_degree);
//
//    if(digitalRead(buttonPin3)==LOW)
//    {
//      state=0;
//      Serial.println("ON");
//      digitalWrite(ledR,LOW);
//      digitalWrite(ledB,HIGH);
//      break;
//    }
//  }
//
//  while(state==0)
//  { 
//    if(!checkCRC(mqtt_sub)){
//      Serial.println("invalid crc");
//      break;
//    }
//    a = int(mqtt_sub[1]);
//    b = int(mqtt_sub[2]);
//    Serial.print(a); Serial.println(b);
//    a=servo1_degree;
//    b=servo2_degree;
//
//    int X = analogRead(0);
//    int Y = analogRead(1);
//
//    int buttonValue2 = digitalRead(2);
//    int buttonValue3 = digitalRead(3);
//    int buttonValue4 = digitalRead(4);
//    int buttonValue5 = digitalRead(5);
//
//    if (X > 500) {
//      servo1_degree = servo1_degree + 2;
//      if (servo1_degree > 180) servo1_degree=180;
//      servo1.write(servo1_degree);
//    }
//
//
//    if (X < 200) {
//      servo1_degree = servo1_degree - 2;
//      if (servo1_degree < 0) servo1_degree=0;
//      servo1.write(servo1_degree);
//    }
//  
//
//    if (Y > 500) {
//      servo2_degree = servo2_degree + 2;
//      if (servo2_degree > 180) servo2_degree=180;
//      servo2.write(servo2_degree);
//    }
//  
//
//    if (Y < 200) {
//      servo2_degree = servo2_degree - 2;
//      if (servo2_degree < 0) servo2_degree=0;
//      servo2.write(servo2_degree);
//    }
//  
//
//    if (buttonValue2 == LOW) {
//      servo1.write(90);
//      servo2.write(90);
//      servo1_degree = 90;
//      servo2_degree = 90;
//
//    }
//
//    if (buttonValue4 == LOW) {
//      state=1;
//      Serial.println("OFF");
//      digitalWrite(ledR,HIGH);
//      digitalWrite(ledB,LOW);
//      delay(100);
//      break;
//    }
//    if (buttonValue5 == LOW) {
//    }
//    delay(10);
//  }
//}
