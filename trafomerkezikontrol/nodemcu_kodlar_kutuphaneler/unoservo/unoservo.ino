#include <Servo.h>
#include "FirebaseESP8266.h"
#include <ESP8266WiFi.h>
#define FIREBASE_HOST "*******" // http:// veya https:// olmadan 
#define FIREBASE_AUTH "******"
#define WIFI_SSID "****" //wifi_ad
#define WIFI_PASSWORD "****" //wifi_sifre
FirebaseData veritabanim;
Servo servo;
Servo servo2;
Servo servo3;
Servo servo4;  //servolar tanımlandı
int istenilen=0;
int acmakapama=0;
int acmakapama2=0;
void setup() {
servo.attach(5); //D1 pinine bağladık
servo.write(0);
servo2.attach(4); //D2 pinine bağladık
servo2.write(0);
servo3.attach(2); //D4 pinine bağladık
servo3.write(0);
servo4.attach(16); //D0 pinine bağladık
servo4.write(0);
 Serial.begin(9200);

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);// ağ bağlantısı
  Serial.print("Ağ Bağlantısı Oluşturuluyor");
  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("IP adresine bağlanıldı: ");
  Serial.println(WiFi.localIP());
  Serial.println();


  //3. Firebase bağlantısı başlatılıyor

  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);//firebase bağlantısı

  //4. Ağ bağlantısı kesilirse tekrar bağlanmasına izin veriyoruz
 Firebase.reconnectWiFi(true);
delay(1000);
}

void loop() {
  if(Firebase.getInt(veritabanim, "/manuelotomatik/manuelotomatik")) 
  {
     istenilen=veritabanim.stringData().toInt();
     Serial.println(istenilen);
    
  }else{
    Serial.print("Str verisi çekilemedi, ");
    Serial.println(veritabanim.errorReason());
  }
 if(istenilen==1)
 {
   if(Firebase.getInt(veritabanim, "/acmakapama/acmakapama")) 
  {
     acmakapama=veritabanim.stringData().toInt();
     Serial.println("acmakapama: ");
     Serial.println(acmakapama);
    
  }else{
    Serial.print("Str verisi çekilemedi, ");
    Serial.println(veritabanim.errorReason());
  }
  if(Firebase.getInt(veritabanim, "/acmakapama2/acmakapama2")) 
  {
     acmakapama2=veritabanim.stringData().toInt();
     Serial.println("acmakapama2: ");
     Serial.println(acmakapama2);
    
  }else{
    Serial.print("Str verisi çekilemedi, ");
    Serial.println(veritabanim.errorReason());
  }
  if(acmakapama==1)
  {
    servo.write(115); 
    servo2.write(115);
    delay(1000);
    }
  if(acmakapama==0)
  {
     servo.write(0); 
    servo2.write(0);
    delay(1000);
    }
    if(acmakapama2==1)
  {
    servo3.write(115); 
    servo4.write(115);
    delay(1000);
    }
  if(acmakapama2==0)
  {
     servo3.write(0); 
    servo4.write(0);
    delay(1000);
    }
  }
  
  
 

}
