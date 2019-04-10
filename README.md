# MvcTool
	* Ýçerisinde mvc için gerekli olan Helper ve Extension gibi yardýmcý yapýlarý barýndýrýr.

# View Creator
	* Ýçerisinde view create için gerekli temel frameworktür.
	* IFeature, Feature => Component içerisinde saklanacak olan özel ve tanýmlý attribute larý saklamak için kullanýlýr.
	* FeautureBase => Component ve Layoutlar için temel bir elemetdir. Ýçerisinde FeatureCollection barýndýrýr.
		Render edilebilir ve Place özelliði ile bir place e yerleþtirilebilir bir nesnedir.
	* IComponent, Component => Bir html componentini ihtiva eder (Button, Label vb). FeatureBase dir.
		Ayný zamanda bir Class veya Propery için attribute dür. Bir property veya class üzerinde birden fazla
		component bulunabilir.
	* ILayout, Layout => Layout amacý componentleri arayüzde bir arada tutabilmektir. Layoutlarýnda bir render nesnesi vardýr
		ve FeatureBase dir. Layoutlar sunuya istek atarak içerisindeki componentlerin bilgilerini güncelleyebilirler.
		Layoutlar customize edilmediði sürece temel olarak ayný render sýnýfýný kullanacakmýþ gibi tasarlanmýþtýr.
		Bu yüzden parametre olarak LayoutName alýr. Bu layout name, render sýrasýnda hangi layout kullanýlacaðý tespiti için oluþturulmuþtur.
		Yani her bir layout için farklý sýnýf oluþturulmadanda (Ekstra özellik içermediði sürece) kullanýlabilinir.
		Çünkü temel olarak layoutlar içerisindeki componentleri kontrol ve düzenleme amacý taþýr.
	* IComponentRegister => Sistem oluþturulurken siteme kayýt edilmek istenen componentler için kullanýlýr.
	* IRender, RenderBase => Render edilebilir yapýlar için kullanýlan render sýnýf arayüzü
	* IViewBuilder => Startup sýrasýnda creator ayarlamalarýný yapar.
	* HtmlFeatures => Html elemanlarý için gerekli attribute lar.

# ViewCreator.UI
	* Ýçerisinde tüm component yapýlarý için tanýmlamalarý barýndýrýr.

# ViewCreator.MVC
	* ViewCreatorExtension => MVC içerisinde bir componentin yada layout un render edilip gösterilmesini saðlar.
	* IViewCreatorExtension => Extension kullanýlabilmesi için inject edilecek olan interface.

# ViewCreator.React
	* ViewCreator altyapýsýnýn react dalýdýr. Gerekli implementation lar burada yapýlýr.
	* UI ile ilgili implemention yoktur. Bu kütüphane sistemin react alt yapýsýný saðlar.
	* Kütüphane React.AspNet ile baðýmlýdýr ve ChakraCore kullanýr.

	* Beautifier => Bu kýsýmda üretilecek olan react dosyasýnýn beautifier yapýlmasýný saðlar.
	* Minification => Bu kýsýmda üretilecek olan react dosyasýnýn minify edilmesini saðlar.
	* ReactViewBuilder => ViewBuilder ýn react için implemente edilmiþ formatýdýr.
	* ReactViewBuilderConfig => React için gerekli ayar dosyasýdýr.
	* RenderExtensions => Sisteme react için gerekli dosyalarý inject eder ve ayarlamalarý yapýp sistemi oluþturur.
	* ReactRender =>
	* IReactFileFounder => Resource dosyalarýnýn bulunmasýný saðlamak için kullanýlan file founder. Inject edilmesi gerekir.
	* ReactFileGenerator =>
	* ReactViewCreatorExtension => 
	* ReactMiddleware => React dosyasý isteði gönderildiðinde oluþturulmuþ dosya döndürülür.

# ViewCreator.UI
	* JsxReactFileFounder

# Component'lerin Sýralanma Yerleþme ve Render Ýlkesi
	* Bir component eðer bir field üzerine eklenmiþ ise, field daki deðer arayüze elemanýn contenti olarak yansýr.
	* Bir layout kullanýlmak istendi. Fakat bu layout deðiþtirilmek isteniyor. Bu durumda projede eðer bu dosya varsa,
		sistemde yüklü olan dosya yada class iptal edilerek bu class kullanýlýr.

# Eksiklikler
	* Component içerisine html elemanlarý için temel olan propertyler tanýmlanacak.
	* Layout içerisinde http request propertyleri geliþtirilmeli
	* Design için componentlerin label
	* Componentler için Validation larýn eklenmesi
	* Çoklu dil desteði
	* ViewCreator.UI içerisine tüm componentler için attribute lar hazýrlanmasý gerekmektedir.
	* ViewCreator.React.JSBeautify ve ViewCreator.React.Minification elden geçirilecek.
	* React render için file founder yapýsý.
	* Tasarým apply edilmesi (yüklü css temasýnýn uygulanmasý)

# Cevapsýz Sorular
	*

# Olmasý Gerekenler
	* Layoutlarýn içerisinde load methodu olacak ve sunucuya istek atýp kendilerini yenileyebilecekler.
	* Hata kontrol mekanýzmasý. React ve sunucu arasýnda oluþacak hatalarýn kontrolü için bir method izlenmeli.
	* Componentler tamamlandýktan sonra her bir component için özelleþtirme yaparak hazýr eleman eklenmesi saðlanacak.
		(Örnek; SquareButton, CircleButton vs)
	* Tüm kodlarýn üzerinde detaylý açýklama
	* Bir layout, component yada proje içerisinde ki layout modelleri react tarafýnda rahatlýkla kullanýlabilir olmalýdýr.
	+ GenerateBuilderFile fonksiyonu ürttiði dosyayý cache etmeli ve saklamalýdýr. 
	* Üretilecek tasarýmlar css uyumlu olalýdýr. Yani, tasarým ile deðiþtirilmesi için belli bir formatta class isimlendirmesi gerekmektedir.
		Böylece tasarým paleti deðiþtiðinde, componentler de deðiþecektir.
	* Bu proje, react kullanmaya bir sisteme eklendiðinde de arka planda react çalýþsacak ve sistemi etkilemeyecek þekilde tasarlanmalýdýr.

_______________________________________________________________________________________________________________

# React Render
	* Render sýrasýnda sýnýf isimlendirilmesinin önemi

# Bugun yapýlacaklar
	+ Generatefile cache edilecek
	* Componentlerin render iþlemleri tamamlanacak
	* ReactViewCreatorExtension yapýlýp inject edilecek ve denenecek.
	* generate render dosyasý oluþturulmak zorunda mý ? olmasa daha iyi olur.
	* AddFileFounder ile JsxReactFileFounder