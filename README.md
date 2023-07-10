    SAKARYA ÜNİVERSİTESİ BİTİRME ÇALIŞMASI

Bu projenin amacı, trafo merkezlerinde bulunan kesici ve ayırıcıları SCADA  sisteminden interaktif olarak sinyal alarak bir maket modellemektir. Maket model, 3D yazıcı kullanılarak oluşturulan parçalar ve motorlar yardımıyla bir masaüstü uygulaması aracılığıyla kontrol edilmektedir. Bu masaüstü uygulaması, hem SCADA sistemiyle hem de Firebase veri tabanıyla iletişim kurabilmektedir. Sistem, otomatik ve manuel modda çalışabilme özelliğine sahiptir.
Otomatik modda, SCADA sisteminden kendisi otomatik olarak verileri çekmektedir. Bu sayede, kesici ve ayırıcıların durumunu gerçek zamanlı olarak takip edebilmektedir. Manuel modda ise masaüstü uygulamadaki butonlar aracılığıyla motorları hareket ettirmek mümkündür. Kullanıcılar, istedikleri zaman otomatik ve manuel modlar arasında geçiş yapabilirler.

Kullanılan malzemeler:
1- NodeMCU
2- 4 tane servo motor SG90
3- 3D yazıcı

Proje ayarları:

Projeyi ayarlamak için bir takım ayarlamalar mevcuttur. Bunlar:

1- Arduino kodları ile ilgili düzenlemeler:
  - Kendi oluşturduğunuz firebase hesabında bir realtime database oluşturunuz.Ve bu veritabanının host kısmını http:// veya https:// olmadan kod kısmında FIREBASE_HOST alanına yazınız. Ardından size özel olan auth kısmını FIREBASE_AUTH değiştiriniz.
  - WIFI_SSID ve WIFI_PASSWORD kısımlarına kendi wifi adı ve şifresinizi giriniz.

2- Uygylama kodları ile ilgili düzenlemeler:
  - 14 ve 15. satırdaki AuthSecret ve BasePath kısmını aynı arduino kodunda değiştirdiğiniz gibi kendinize göre değiştiriniz.
  - 38, 42, 51, 55, 93, 102, 110, 120. satırdaki resim dosya yollarını kendi bilgisayarınıza göre yazınız. Resimler kodların olduğu dosya klasörünün içindedir.


NOT: Normal şartlarda SCADA'dan verileri API ile çekiyoruz ancak şuanlık API kısmında arıza olduğu için buraya yüklenen projeye entegre edilmemiştir. 
