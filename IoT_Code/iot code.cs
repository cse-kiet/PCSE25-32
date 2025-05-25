#include <dht.h>
const int analogInPin = A0; 
int sensorValue = 0; 
unsigned long int avgValue; 
float b;
int buf[10],temp;
const int capteur_D = 4;
const int capteur_A = A0;
int val_analogique;
void setup() {
 Serial.begin(9600);

 pinMode(capteur_D, INPUT);
 pinMode(capteur_A, INPUT);
 Serial.begin(9600);

//initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
}
 
void loop() {
 for(int i=0;i<10;i++) 
 { 
  buf[i]=analogRead(analogInPin);
  delay(100);
 }
 for(int i=0;i<9;i++)
 {
  for(int j=i+1;j<10;j++)
  {
   if(buf[i]>buf[j])
   {
    temp=buf[i];
    buf[i]=buf[j];
    buf[j]=temp;
   }
  }
 }
 avgValue=0;
 for(int i=2;i<8;i++)
 avgValue+=buf[i];
 float pHVol=(float)avgValue*5.0/1024/6;
 float phValue = -5.70 * pHVol + 13.15;
 Serial.print("pH Value = ");
 Serial.println(phValue);
 
 delay(20);

if(digitalRead(capteur_D) == LOW) 
  {
    Serial.println("Digital value : wet"); 
    delay(10); 
  }
else
  {
    Serial.println("Digital value : dry");
    delay(10); 
  }

val_analogique=analogRead(capteur_A); 
 Serial.print("Analog value : ");
 Serial.println(val_analogique); 
 Serial.println("");
delay(1000);

int sensorValue = analogRead(A0);
 //print out the value you read:
  Serial.println(sensorValue);
  delay(1);        // delay in between reads for 
}
//const int capteur_D = 4;
//const int capteur_A = A0;
//
//int val_analogique;
//
//void setup()
//{
//  pinMode(capteur_D, INPUT);
//  pinMode(capteur_A, INPUT);
//  Serial.begin(9600);
//}
//
//void loop()
//{
//if(digitalRead(capteur_D) == LOW) 
//  {
//    Serial.println("Digital value : wet"); 
//    delay(10); 
//  }
//else
//  {
//    Serial.println("Digital value : dry");
//    delay(10); 
//  }
//val_analogique=analogRead(capteur_A); 
// Serial.print("Analog value : ");
// Serial.println(val_analogique); 
// Serial.println("");
//  delay(1000);
//}
//
//void setup() {
//  // initialize serial communication at 9600 bits per second:
//  Serial.begin(9600);
//}
//
//// the loop routine runs over and over again forever:
//void loop() {
//  // read the input on analog pin 0:
//  int sensorValue = analogRead(A0);
//  // print out the value you read:
//  Serial.println(sensorValue);
//  delay(1);        // delay in between reads for stability
//}