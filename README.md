# MvcTool
	* ��erisinde mvc i�in gerekli olan Helper ve Extension gibi yard�mc� yap�lar� bar�nd�r�r.

# View Creator
	* ��erisinde view create i�in gerekli temel frameworkt�r.
	* IFeature, Feature => Component i�erisinde saklanacak olan �zel ve tan�ml� attribute lar� saklamak i�in kullan�l�r.
	* FeautureBase => Component ve Layoutlar i�in temel bir elemetdir. ��erisinde FeatureCollection bar�nd�r�r.
		Render edilebilir ve Place �zelli�i ile bir place e yerle�tirilebilir bir nesnedir.
	* IComponent, Component => Bir html componentini ihtiva eder (Button, Label vb). FeatureBase dir.
		Ayn� zamanda bir Class veya Propery i�in attribute d�r. Bir property veya class �zerinde birden fazla
		component bulunabilir.
	* ILayout, Layout => Layout amac� componentleri aray�zde bir arada tutabilmektir. Layoutlar�nda bir render nesnesi vard�r
		ve FeatureBase dir. Layoutlar sunuya istek atarak i�erisindeki componentlerin bilgilerini g�ncelleyebilirler.
		Layoutlar customize edilmedi�i s�rece temel olarak ayn� render s�n�f�n� kullanacakm�� gibi tasarlanm��t�r.
		Bu y�zden parametre olarak LayoutName al�r. Bu layout name, render s�ras�nda hangi layout kullan�laca�� tespiti i�in olu�turulmu�tur.
		Yani her bir layout i�in farkl� s�n�f olu�turulmadanda (Ekstra �zellik i�ermedi�i s�rece) kullan�labilinir.
		��nk� temel olarak layoutlar i�erisindeki componentleri kontrol ve d�zenleme amac� ta��r.
	* IComponentRegister => Sistem olu�turulurken siteme kay�t edilmek istenen componentler i�in kullan�l�r.
	* IRender, RenderBase => Render edilebilir yap�lar i�in kullan�lan render s�n�f aray�z�
	* IViewBuilder => Startup s�ras�nda creator ayarlamalar�n� yapar.
	* HtmlFeatures => Html elemanlar� i�in gerekli attribute lar.

# ViewCreator.UI
	* ��erisinde t�m component yap�lar� i�in tan�mlamalar� bar�nd�r�r.

# ViewCreator.MVC
	* ViewCreatorExtension => MVC i�erisinde bir componentin yada layout un render edilip g�sterilmesini sa�lar.
	* IViewCreatorExtension => Extension kullan�labilmesi i�in inject edilecek olan interface.

# ViewCreator.React
	* ViewCreator altyap�s�n�n react dal�d�r. Gerekli implementation lar burada yap�l�r.
	* UI ile ilgili implemention yoktur. Bu k�t�phane sistemin react alt yap�s�n� sa�lar.
	* K�t�phane React.AspNet ile ba��ml�d�r ve ChakraCore kullan�r.

	* Beautifier => Bu k�s�mda �retilecek olan react dosyas�n�n beautifier yap�lmas�n� sa�lar.
	* Minification => Bu k�s�mda �retilecek olan react dosyas�n�n minify edilmesini sa�lar.
	* ReactViewBuilder => ViewBuilder �n react i�in implemente edilmi� format�d�r.
	* ReactViewBuilderConfig => React i�in gerekli ayar dosyas�d�r.
	* RenderExtensions => Sisteme react i�in gerekli dosyalar� inject eder ve ayarlamalar� yap�p sistemi olu�turur.
	* ReactRender =>
	* IReactFileFounder => Resource dosyalar�n�n bulunmas�n� sa�lamak i�in kullan�lan file founder. Inject edilmesi gerekir.
	* ReactFileGenerator =>
	* ReactViewCreatorExtension => 
	* ReactMiddleware => React dosyas� iste�i g�nderildi�inde olu�turulmu� dosya d�nd�r�l�r.

# ViewCreator.UI
	* JsxReactFileFounder

# Component'lerin S�ralanma Yerle�me ve Render �lkesi
	* Bir component e�er bir field �zerine eklenmi� ise, field daki de�er aray�ze eleman�n contenti olarak yans�r.
	* Bir layout kullan�lmak istendi. Fakat bu layout de�i�tirilmek isteniyor. Bu durumda projede e�er bu dosya varsa,
		sistemde y�kl� olan dosya yada class iptal edilerek bu class kullan�l�r.

# Eksiklikler
	* Component i�erisine html elemanlar� i�in temel olan propertyler tan�mlanacak.
	* Layout i�erisinde http request propertyleri geli�tirilmeli
	* Design i�in componentlerin label
	* Componentler i�in Validation lar�n eklenmesi
	* �oklu dil deste�i
	* ViewCreator.UI i�erisine t�m componentler i�in attribute lar haz�rlanmas� gerekmektedir.
	* ViewCreator.React.JSBeautify ve ViewCreator.React.Minification elden ge�irilecek.
	* React render i�in file founder yap�s�.
	* Tasar�m apply edilmesi (y�kl� css temas�n�n uygulanmas�)

# Cevaps�z Sorular
	*

# Olmas� Gerekenler
	* Layoutlar�n i�erisinde load methodu olacak ve sunucuya istek at�p kendilerini yenileyebilecekler.
	* Hata kontrol mekan�zmas�. React ve sunucu aras�nda olu�acak hatalar�n kontrol� i�in bir method izlenmeli.
	* Componentler tamamland�ktan sonra her bir component i�in �zelle�tirme yaparak haz�r eleman eklenmesi sa�lanacak.
		(�rnek; SquareButton, CircleButton vs)
	* T�m kodlar�n �zerinde detayl� a��klama
	* Bir layout, component yada proje i�erisinde ki layout modelleri react taraf�nda rahatl�kla kullan�labilir olmal�d�r.
	+ GenerateBuilderFile fonksiyonu �rtti�i dosyay� cache etmeli ve saklamal�d�r. 
	* �retilecek tasar�mlar css uyumlu olal�d�r. Yani, tasar�m ile de�i�tirilmesi i�in belli bir formatta class isimlendirmesi gerekmektedir.
		B�ylece tasar�m paleti de�i�ti�inde, componentler de de�i�ecektir.
	* Bu proje, react kullanmaya bir sisteme eklendi�inde de arka planda react �al��sacak ve sistemi etkilemeyecek �ekilde tasarlanmal�d�r.

_______________________________________________________________________________________________________________

# React Render
	* Render s�ras�nda s�n�f isimlendirilmesinin �nemi

# Bugun yap�lacaklar
	+ Generatefile cache edilecek
	* Componentlerin render i�lemleri tamamlanacak
	* ReactViewCreatorExtension yap�l�p inject edilecek ve denenecek.
	* generate render dosyas� olu�turulmak zorunda m� ? olmasa daha iyi olur.
	* AddFileFounder ile JsxReactFileFounder