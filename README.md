# Bilgisayar Ağları Lab. Dersi Kodları

[![OMÜ CEng](https://img.shields.io/badge/OM%C3%9C-CEng-blue.svg)](http://bil.muhendislik.omu.edu.tr)

## İçerik

**Ondokuz Mayıs Üniversitesi** (OMÜ) **Bilgisayar Mühendisliği** lisans programı **Programlama Dileri** dersi kapsamında 
verilen projenin **C#** kullanılarak tarafımdan gerçekleştirilen çözümü yer almaktadır.

## C# Hakkında Kısa Bilgi

+ **.Net** platformu için hazırlanmış tamamen nesne yönelimli bir programlama dilidir.
+ **Microsoft** tarafından geliştirilmiştir.
+ Sunucu ve gömülü sistemler için tasarlanmıştır.
+ **Anders Hejberg** dilin tasarlanmasında öncülük etmiştir.
+ **WindowsForm**,  **Web Form**, **Mobil Programlama**, **Web Servisleri**, **DLL** yazma gibi alanlarda kullanılabilir.

### Projenin Tanımı

Bize verilen **.csv** dosya öğrenci bilgileri içermektedir. Bu bilgiler **" Ad, Soyad, Cinsiyet, Dönem"**dir. Konsoldan girilen
bilgilere göre uygun çıktının yazılması ve beklenen çıktı ile karşılaştırılıp test edilmesi beklenmektedir. Test aşamasında 
verilen **.csv** dosyasının PATH doğruluğuna, girilen argumanların belirlenen argümanlardan olmasına ve arguman sayısına bakılmalıdır.

* Örnek Girdiler : **cinsiyet**  - **dönem**  - **dönem, cinsiyet**

## Repo'nun Dizin Yapısı
* **packages** içerisinde Projede kullanılmak üzere eklenen **NuGet**ler almaktadır.
  * **NuGet**ler 3.parti paketlerdir. Genellikle **.dll** olarak derlenmişlerdir. Uzantıları **.nupkg** şeklindedir.
* **sch** içerisinde tarafımdan gerçekleştirilen C# ile problemin çözüm aşaması ve ilgili **.csv** dosyalar yer almaktadır.
* **schTests** içerisinde tarafımdan gerçekleştirilen problemin çözüm aşamasının Test kodları ve ilgili **.csv** dosyalar yer almaktadır.

## Projelerin Dizin Yapısı
* **.cs** uzantılı dosyalar kaynak koddur. **C#** dili ile yazılmıştır.
* **.csv** uzantılı dosyalar problem aşamasında kullanılacak verileri içermektedir.
* **packages.config** uzantılı dosya projeye eklenen **NuGet**lerin tanıtıldığı yerdir.

## Katkıda Bulunanlar

[@tunahanyetimoglu](https://github.com/tunahanyetimoglu) - Tunahan YETİMOĞLU
