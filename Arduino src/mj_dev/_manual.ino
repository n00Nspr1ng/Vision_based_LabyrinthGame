void loop_manual()
{

  while(state==1) // state 1은 조종할 수 없는 상태
  {
    servo1.write(servo1_degree);
    servo2.write(servo2_degree);

    if(digitalRead(buttonPin1)==LOW)
    {
      state=0;
      Serial.println("ON");
      digitalWrite(ledR,LOW);
      digitalWrite(ledB,HIGH);
      delay(300);
      break;
    }
  }

  while(state==0)
  { 
    
    if(Serial.available()){
      a = Serial.parseInt();
      b = Serial.parseInt();
      Serial.print("a = ");
      Serial.print(a); 
      Serial.print("    b = ");
      Serial.println(b);
      servo1.write(a);
      servo2.write(b);
      }
   
    
    a=servo1_degree;
    b=servo2_degree;
//    servo1.write(a);
//    servo2.write(b);

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
  

    if (digitalRead(buttonPin2) == LOW) {
      servo1.write(90);
      servo2.write(90);
      servo1_degree = 90;
      servo2_degree = 90;
      Serial.println("RESET");
      delay(300);
    }

    if (digitalRead(buttonPin1) == LOW) {
      state=1;
      Serial.println("OFF");
      digitalWrite(ledR,HIGH);
      digitalWrite(ledB,LOW);
      delay(300);
      break;
    }
//    if (buttonValue5 == LOW) {
//    }
    delay(10);
  }
}
