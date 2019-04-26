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

** Class diagramdan ViewModeller, DTO ve arayüz hızlıca oluşturulacaktır **
** Bununla ilgili bir tool hazırlanabilir ve tüm sistemin yapısını kuran bir proje oluşturur. Geriye sadece Business katmanının içini doldurmak kalır ** 
** Marketing yapılabilabilir, kullanıcılar tasarımlarını yükler, insanlar bunu alarak hızlı bir şekilde kullanabilir **

# Component'lerin Sıralanma Yerleşme ve Render İlkesi
	* Bir component eğer bir field üzerine eklenmiş ise, field daki değer arayüze elemanın contenti olarak yansır. 
		Bu sayede static veriler modelden kontorol edilebilir.
	* Bir layout kullanılmak istendi. Fakat bu layout değiştirilmek isteniyor. Bu durumda projede eğer bu dosya varsa,
		sistemde yüklü olan dosya yada class iptal edilerek bu class kullanılır.
	* Modelde bir dizi yada IEnumerable olursa nasıl render edilecek. Layout veya Component attibuteları bunun için kullanılacak.

# Microservice 
	* Saga
	* Transaction yönetimi		

# Dockerize
	*