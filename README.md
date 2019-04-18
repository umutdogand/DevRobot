# MvcTool
	* İçerisinde mvc için gerekli olan Helper ve Extension gibi yardımcı yapıları barındırır.
	
# View Creator
	* İçerisinde view create için gerekli temel frameworktür.
	* IFeature, Feature => Component içerisinde saklanacak olan özel ve tanımlı attribute ları saklamak için kullanılır.
	* FeautureBase => Component ve Layoutlar için temel bir elemetdir. İçerisinde FeatureCollection barındırır.
		Render edilebilir ve Place özelliği ile bir place e yerleştirilebilir bir nesnedir.
	* IComponent, Component => Bir html componentini ihtiva eder (Button, Label vb). FeatureBase dir.
		Aynı zamanda bir Class veya Propery için attribute dür. Bir property veya class üzerinde birden fazla
		component bulunabilir.
	* ILayout, Layout => Layout amacı componentleri arayüzde bir arada tutabilmektir. Layoutlarında bir render nesnesi vardır
		ve FeatureBase dir. Layoutlar sunuya istek atarak içerisindeki componentlerin bilgilerini güncelleyebilirler.
		Layoutlar customize edilmediği sürece temel olarak aynı render sınıfını kullanacakmış gibi tasarlanmıştır.
		Bu yüzden parametre olarak LayoutName alır. Bu layout name, render sırasında hangi layout kullanılacağı tespiti için oluşturulmuştur.
		Yani her bir layout için farklı sınıf oluşturulmadanda (Ekstra özellik içermediği sürece) kullanılabilinir.
		Çünkü temel olarak layoutlar içerisindeki componentleri kontrol ve düzenleme amacı taşır.
	* IComponentRegister => Sistem oluşturulurken siteme kayıt edilmek istenen componentler için kullanılır.
	* IRender, RenderBase => Render edilebilir yapılar için kullanılan render sınıf arayüzü
	* IViewBuilder => Startup sırasında creator ayarlamalarını yapar.
	* HtmlFeatures => Html elemanları için gerekli attribute lar.

# ViewCreator.UI
	* İçerisinde tüm component yapıları için tanımlamaları barındırır.

# ViewCreator.MVC
	* ViewCreatorExtension => MVC içerisinde bir componentin yada layout un render edilip gösterilmesini sağlar.
	* IViewCreatorExtension => Extension kullanılabilmesi için inject edilecek olan interface.

# ViewCreator.React
	* ViewCreator altyapısının react dalıdır. Gerekli implementation lar burada yapılır.
	* UI ile ilgili implemention yoktur. Bu kütüphane sistemin react alt yapısını sağlar.
	* Kütüphane React.AspNet ile bağımlıdır ve ChakraCore kullanır.

	* Beautifier => Bu kısımda üretilecek olan react dosyasının beautifier yapılmasını sağlar.
	* Minification => Bu kısımda üretilecek olan react dosyasının minify edilmesini sağlar.
	* ReactViewBuilder => ViewBuilder ın react için implemente edilmiş formatıdır.
	* ReactViewBuilderConfig => React için gerekli ayar dosyasıdır.
	* RenderExtensions => Sisteme react için gerekli dosyaları inject eder ve ayarlamaları yapıp sistemi oluşturur.
	* ReactRender =>
	* IReactFileFounder => Resource dosyalarının bulunmasını sağlamak için kullanılan file founder. Inject edilmesi gerekir.
	* ReactFileGenerator =>
	* ReactViewCreatorExtension => 
	* ReactMiddleware => React dosyası isteği gönderildiğinde oluşturulmuş dosya döndürülür.

# ViewCreator.UI
	* JsxReactFileFounder

# Component'lerin Sıralanma Yerleşme ve Render İlkesi
	* Bir component eğer bir field üzerine eklenmiş ise, field daki değer arayüze elemanın contenti olarak yansır.
	* Bir layout kullanılmak istendi. Fakat bu layout değiştirilmek isteniyor. Bu durumda projede eğer bu dosya varsa,
		sistemde yüklü olan dosya yada class iptal edilerek bu class kullanılır.

# Eksiklikler
	* Component içerisine html elemanları için temel olan propertyler tanımlanacak.
	
	* Layout içerisinde http request propertyleri geliştirilmeli
	* Design için componentlerin label
	* Componentler için Validation ların eklenmesi
	* Çoklu dil desteği
	* ViewCreator.UI içerisine tüm componentler için attribute lar hazırlanması gerekmektedir.
	* ViewCreator.React.JSBeautify ve ViewCreator.React.Minification elden geçirilecek.
	* React render için file founder yapısı.
	* Tasarım apply edilmesi (yüklü css temasının uygulanması)

# Cevapsız Sorular
	*

# Olması Gerekenler
	* Layoutların içerisinde load methodu olacak ve sunucuya istek atıp kendilerini yenileyebilecekler.
	* Hata kontrol mekanızması. React ve sunucu arasında oluşacak hataların kontrolü için bir method izlenmeli.
	* Componentler tamamlandıktan sonra her bir component için özelleştirme yaparak hazır eleman eklenmesi sağlanacak.
		(Örnek; SquareButton, CircleButton vs)
	* Tüm kodların üzerinde detaylı açıklama
	* Bir layout, component yada proje içerisinde ki layout modelleri react tarafında rahatlıkla kullanılabilir olmalıdır.
	* GenerateBuilderFile fonksiyonu ürttiği dosyayı cache etmeli ve saklamalıdır. 
	* Üretilecek tasarımlar css uyumlu olalıdır. Yani, tasarım ile değiştirilmesi için belli bir formatta class isimlendirmesi gerekmektedir.
		Böylece tasarım paleti değiştiğinde, componentler de değişecektir.
	* Bu proje, react kullanmaya bir sisteme eklendiğinde de arka planda react çalışsacak ve sistemi etkilemeyecek şekilde tasarlanmalıdır.
	* Componentler mesela ButtonAttribute istenirse farlı tsx dosyasını custom olarak kullabilmeli
_______________________________________________________________________________________________________________

# React Render
	* Render sırasında sınıf isimlendirilmesinin önemi
	# Componenler render edillirken Form mu Reloader mu üstde olacak, sırlama belirtilebilmeli

# Bugun yapılacaklar
	+ Generatefile cache edilecek
	* Componentlerin render işlemleri tamamlanacak
	* ReactViewCreatorExtension yapılıp inject edilecek ve denenecek.
	* generate render dosyası oluşturulmak zorunda mı ? olmasa daha iyi olur.
	* AddFileFounder ile JsxReactFileFounder
	* React tarafında button, label, input ve layout hazırlanacak. layout üretimi içn bir react kütüphanesi olacak.
		Layoutlar veya COmponentler oluşturulması için feature bilgilerine ve value bilgilerine ihtiyaç duyar.
		ReactViewCreatorExtension, render sırasında bu bilgileri modelden analiz ederek oluşturacaktır.
		React tarafında bu feature lar componentlere atanacaktır. 
		Eğer reactt tarafında direk olarak component yada layout kullanılmak istenirse bu attribute bilgisine ihtiyaç duyacaktır.
		Böyle bir durum için component yada layout sistemden istenilen yapı için metadata isteği atıp sonuç alabilmelidir.
		Bu tamamen react ile ilgilidir uygun kütüphanede olmalıdır.

# React Kütüphane
	
	# Yetkilendirme
	# Componentler içinde layoutu döndüren fonksiyon lazım
	# Kolay bir şeilde template güncellemesi için load methodu içerecek, Buna karşılık gelen bir attribute tarafıdan request verileri karşılanacak (c# tarafında).
	# Yetkiye göre render işlemi C# tarafında olacaktır. Fakat dynamic olarak istek atlıp yetki kontrolü yapılabilmesi için bir component gerekebilir.
	# Login olmaya çalışırken başarız oldu. Hata gösterilecek, swal ile gösterilebilir veya model verisi güncellenerek kcomponent güncellenir. Bu durumu gerçekleşir.

	# Microservice 
		* Saga
		* Transaction yönetimi		

	# Dockerize


	
	# Template içine getReloaders diye fonksiyon yap.
	# Elemetleri kolaylıkla bulabilmeliyiz. Templateler ReactStartupApp üzerinden keyler ile bulunabilecek. ReactStartupApp adını kısalt. 
		Templatelerden find() diyerek FeatureBase nesnesi bulunabilecek. PropertyAdı, key, type ile ajax query s gibi bulunabilecek.


	# Log mekanizması sağlanacak, LoggerFactory hazırla, interface kullanılarak loger nesnesi oluşturup redux içerisine atıcak. LogRocket kullan.
	# Multilingual işi c# tarafında olacaktır fakat react tarafında istek ile kontrol mekanizması olacaktır.
		Bu yapı interface değiştirilebilir olacaktır DI ya uygun olarak
	# Hata yönetimi => ExceptionHandler testiyle beraber yönet. Mesela bir hata olduğunda swal mesajı ile gösterilebilir. Redux içerisindeki exception handling i yapıya dahil et.
		https://reactjs.org/docs/error-boundaries.html
	* Module şeklinde hazırla. React npm ile çalıştırılabilecek bir module olacak.
	# Modelde bir dizi olursa nasıl render edilecek her bir eleman için belirli bir component yüklenmeli




	# Projelerin nuget paketi haline getirilmesi