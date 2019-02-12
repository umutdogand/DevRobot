# Project's Main Subjects

## Api Creator
	RESTful service ler ile haberleşmeyi sağlayan bir ara iletişim kanalı oluşturulacaktır.(ApiProxy)
	Bu kanal sayesinde karşı tarafta istenilen fonksiyon HTTP protokolü üzerinden haberleşebilecektir.
	Bu işlem için RestClient kullanılacaktır. Auth altyapısı eklecektir. Custom iletişime açık olarak tasarlanmalıdır.
	WCF için yanlızca auth altyapısı eklenecektir. Serileştirme yöntemi customize edilebilir olarak tasarlanacaktır.
	Otomatik olarak bir yapıya özel tüm önemli fonksiyonları oluşturabilen bir api oluşturmayı sağlayacaktır.
	Customize edilebilir olacaktır. Console uygulaması ile kontrol edilebilecektir.
		
## View Creator
	View creator un amacı kolay bir şekilde view üretebilmektir. 
	Amacımız bir class modeli üzerinden Bir sayfayı veya sayfanın bir kısmının oluşmasını sağlamaktır.
	Sayfa ve bileşen templeteleri olacaktır. Her bir property bir componente denk gelecektir.
	İstenirse özel templete ve bileşen yazılabilecektir.
	Templete içinde templete olabilir. Kullanıcı bir proje için hazırladığı templete i diğer projelerde kullabilecek,
	Bu templete leri ve componentleri project creator a kayıt edilebilecektir. Proje oluştururken oluşturulacak projeye dahil
	edilecektir. Bu sayede yapılmış olan arayüzler reusable olacaktır. Proje içerisinde gömülü olacak olan bir kaç templete olacaktır.
	Bir component veya templete cs, cshtml, css ve js den oluşur. Klasor yapısından bulur. Templete diğer templete lerin veya componentlerin
	nasıl bir araya gelip gösterileceği ile ilgilenir. Projede birden fazla tasarım yüklenebilir. Başlıca önemli componentler gömülü gelecektir.
	
## Cache Mechanizm
	Memory cache, redis cache vb yapılar incelenerek, 
	Entity Framework için veya diğer kullanımlar için DI uyumlu kütüphane oluşturulacaktır.
	Project creator ile bu cache mekanizmaları projeye gömülü gelecektir.		
	
## Identity Mechanizm
	Identity Server 4 kullanılacaktır. Project Creator ile otomatik kodları oluşturulacak, 
	authorize, authanticate, role claim altyapısı hazır şekilde gelecektir.
	Bunu oluşturan bir console app yazılacaktır.
	
## Log Mechanizm
	Log4Net, NLog vs gibi sistemleri kullanabilecek DI uyumlu bir kütüphane. 
	Project creator ile seçim yapılacak ve proje bu şekilde oluşacaktır.
	Db log, file log vb tarzı tüm log işlemlerini destekleyecektir.
	Otomatik oluşturma işlemleri için console app yazılacaktır.
	
## Project Creator
	Bir web uygulamasıdır. Aslında DevRobotun kendisini ihtiva eder. Project creator ile projenin oluşturulmasını sağlar.
	Web uygulamasıdır ve satılacak uygulama budur. Kullanıcı istediği ayarları seçerek projenin otomatik olarak oluşmasını sağlar.
	Oluşturduğu projeye eklemeler veya değişiklikler yapabilir. Örnek olarak bir proje oluşturdu ve başta db belli değildi.
	Bunun entityleri hazırlandı veya db belli oldu yada değişti. Sayfaların modellerini tekrar baştan oluşturmak istedi. 
	Bu işlemi bu creator ile yapabilecektir. Yada projenin arayüzü değişecek, yada unit tesleri oluşturulacak. Yine bu işlemler
	Bu web uygulaması üzerinden yürütülecektir. Program şeklinde kurulacak ve IIS (veya linux dağıtımları için apache vs) yerleşecektir.
	.Net Core projesidir.
	Kullanıcı projesi için api veya web projesi ekleyebilecektir, verilen ayarlara özel proje otomatik oluşacaktır.
	
## Transaction Management
	Aspect programming kullanılacaktır. Api kısmında kullanılmak üzere tüm transaction ların üzerinden geçeceği bir alt yapı olacaktır.
	
## Multi Language Support
	Proje direk olarak çok dil desteği ile birlikte gelecektir.
	
## Exception Handling
	Aspect programming kullanılacaktır. Bir methodun üzerine eklenerek hata oluşur ise başka bir fonksiyonla kontrol edilmesi sağlanır.
	Bir controller üzerine eklenebilir. Middleware olarak eklenerek tüm requestlerin yakalanması kontrol edilebilir.
	Json dönen bir action üzerine eklenir ise json olarak hata mesajı dönülmesini sağlayacaktır. 
	Veya normal bir action için hata sayfasına yönlendirebilir.
	Hata kodlarına göre uygun dilde hata mesajı üretecektir.
	
## Utilities / Tools
	Tar/Zip/ Creator
	Stream Process
	Throttle
	MVCTool
	Pagination
	Extensions
	
## Documentation Creator (Our Tool)
	Bu proje otomatik olarak bizim projemizdeki tüm kodları inceleyerek otomatik bir dokümantasyon web sayfaları oluşturacaktır.
	Bunun için tüm assembly leri okur, açıklamaları uygun bir şekilde db ye kayıt eder ve otomatik bir web sayfası oluşturur.
	Admin portalı kısmında da bu veriler düzenlenebilir olacaktır. Web sayfası oluşturma kısmı DevRobot sayesinde yapılacaktır.
	
## Online Demonstration Web Site
	DevRobot unn tanıtımının, danışmanın ve satışın yapıldığı bir web site hazırlanacaktır.

## Hub Mechanizm
	Socket programlama ile iletişim kurabilen bir altyapı kütüphanesidir.
	Bu altyapı sayesinde iki taraflı haberleşme yapılabilecektir (Server->Client, Client->Server)
	Mesajlaşma, notification tarzı uygulamalar için kullanılabilir olacaktır.	

## Nuget Builder
	Projeleri otomatik olarak nuget haline getirip bir nuget store da yayın yapabilecektir.
	CI/CD işlerinde kullanılabilcek bir tool olacaktır. 
	Diğer projeler bağlı oldukları diğer projeler ile versiyon ile bağlı olacaktır.

## Dockerize
	Projeyi docker image haline getirebilen kütüphane.
	Bu sayede proje kolay bir şekilde image haline getirilebilir, repository e kayıt edilebilir.
	Örnek olarak bir proje içerisinde kişiye özel başka bir uygulama ayağıya kaldırmak ve kontrol etmek mümkün olur.
	
## Mail Management
	Tüm mail sunucuları ile haberleşebilen DI uyumlu bir kütüphane yapılacaktır.
	
## SMS Management
	En çok kullanılan SMS provider ları ile uyumlu çalışacak DI uyumlu kütüphane yapılacaktır.

## Captcha Management
	En çok kullanılan Captcha provider ları ile uyumlu çalışacak DI uyumlu kütüphane yapılacaktır.

## Unit Testing
	Bu yapıda otomatik olarak unit testlerin oluşturulması sağlanacaktır. Moq kullanılabilir.
			
## E-Signer
	E-İmza ile yapılacak işlemlerde kullanıcak bir kütüphane yapılcaktır.
		
## Dynamic Class Generation
	Bir class ın dinamik bir şekilde oluşturulması amaçlanır. 
	Burada amaç örnek olarak bir tablo içerisine db den okuyarak veri eklenmesini sağlamaktır.
	Örneğin bir tabloya eklenen yeni bir kolon bu şekilde otomatik görüntülenebilecektir.
	Entity'lerin dinamik veya olması veya normal olacağı project creator ile seçilebilecektir.

## Reporting Tool
	Kolay bir şekilde grafikler oluşturulabilecek bir kütüphane yazılacaktır.	

# Project's Rules
	
**Proje içerisinde tüm kodlar açıklamaları ve detayları içermelidir.**

**Proje açık kaynak olarak sunulabileceği için tüm kodları son derece düzenli ve açıklayıcı olmalıdır. https://docs.microsoft.com/en-us/dotnet/csharp/codedoc**

**Proje ilk aşamada .net core uyumlu olacaktır. Bir sonraki aşamada Dotnet Framework, Xamarin ve WPF projelerine uygun olacaktır**

**Proje bir sonraki aşama için react ve vue projeleri için uyumlu olacaktır** 

**Projeye bir çok templete eklenebilmeli ve proje o şekilde oluşmalıdır.**

**AutoMapper bağımlı olacaktır. Entity, ViewModel ve DTO lar kullanılacaktır**

**Lisanslama da sıkıntı oluşturabilecek kodlardan vaz geçilecektir.**

**UnitOfWork alt yapısına devam edilecektir.**

**Projenin her classında lisans ve haklar damgası olacaktır. Bu yüzden copyalanmış kodlar elden geçirilmelidir.**

**Eğer kaynak kod bizim değilse nerden aldığımızı üzerine belirtmemiz gerekir.**

**Projenin sonraki aşamaları için farklı dil destekleri eklenmesi planlanmaktadır**

**Yazılacak olan console uygulamaları için aynı zamanda dotnet tools olarak da kurulup komutlar ile yönetilebilecektir**

	
# First Version Plan

- Project Creator				: 150 hour	(have to develop)
- View Creator 					: 120 hour 	(have some)
- Api Creator 					: 50  hour 	(have some)
- Cache Mechanizm				: 40  hour	(have some, have to develop)
- Identity Mechanizm			: 40  hour 	(have some)
- Log Mechanizm					: 40  hour  (have some, have to develop)
- Transaction Management		: 20  hour 	(have some, not hard)
- Multi Language Support		: 30  hour	(have to develop)
- Exception Handling			: 30  hour	(have some, have to develop)
- Hub Mechanizm					: 30  hour 	(have some)
- Nuget Builder					: 30  hour 	(have some)
- E-Signer						: 30  hour	(have to develop)
- Reporting Tool				: 60  hour	(have to develop)
- Docker Enable / Dockerize		: 30  hour 	(have some)
- Unit Testing					: 40  hour	(have some, have to develop)
- Captcha Management			: 30  hour	(have some, have to develop)
- Mail Management				: 30  hour	(have some, have to develop)
- SMS Management				: 30  hour	(have some, have to develop)
- Dynamic Class Generation		: 100 hour 	(have some)
- Documentation Creator 		: 60  hour	(have to develop)
- Online Demonstration Web Site : 30  hour	(have to develop)
	
# Second Version Plan
	
- Extended Utilities / Tools
- NHibernate Enabled
- Vue, React Enabled
- Quick CI/CD
- Kubernates, Swarm Enabled
- Xamarin, DotNetFramework, WPF Enabled	